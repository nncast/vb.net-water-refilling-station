Imports System.Text.RegularExpressions

' Order, payment and delivery operations shared by the admin and employee
' screens. Each one runs in a single database transaction, so stock, sales,
' payments, the customer balance and the logs are either all updated or not
' at all. Rule violations are thrown as ApplicationException with a message
' that can be shown to the user as-is.
Module OrderLogic

    ' One line of the order cart.
    Public Class CartLine
        Public ItemType As String   ' "Product" or "Service"
        Public ItemID As Integer
        Public Name As String
        Public Qty As Integer
        Public Price As Decimal
    End Class

    ' Reads the cart ListView of the sales screens
    ' (columns: #, name, qty, price, total, order id, item id, item type).
    Public Function ReadCart(lv As ListView) As List(Of CartLine)
        Dim lines As New List(Of CartLine)
        For Each item As ListViewItem In lv.Items
            lines.Add(New CartLine With {
                .Name = item.SubItems(1).Text,
                .Qty = CInt(item.SubItems(2).Text),
                .Price = CDec(item.SubItems(3).Text),
                .ItemID = CInt(item.SubItems(6).Text),
                .ItemType = item.SubItems(7).Text
            })
        Next
        Return lines
    End Function

    Public Function CartTotal(lines As List(Of CartLine)) As Decimal
        Dim total As Decimal = 0
        For Each line As CartLine In lines
            total += line.Qty * line.Price
        Next
        Return total
    End Function

    Public Function PaymentStatus(total As Decimal, paid As Decimal) As String
        If paid >= total Then Return "Full"
        If paid > 0 Then Return "Partial"
        Return "Unpaid"
    End Function

    ' Inventory transactions written by orders ("Order #12", "Updated Order #12", ...).
    ' Editing or deleting them by hand would put stock out of step with the orders.
    Public Function IsOrderTransaction(remarks As String) As Boolean
        If remarks Is Nothing Then Return False
        Return Regex.IsMatch(remarks.Trim(), "^(Order|Updated Order|Order Cancelled|Order cancel/delete) #\d+$", RegexOptions.IgnoreCase)
    End Function

    ' ------------------------------------------------------------------ orders

    ' Saves a new order with its sale. Returns {orderId, saleId}.
    Public Function CreateOrder(custId As Integer, orderType As String, lines As List(Of CartLine)) As Integer()
        Dim total As Decimal = CartTotal(lines)

        BeginTransaction()
        Try
            Execute("INSERT INTO tblorders (custid, userid, ordertype, status) VALUES (@c, @u, @t, 'Pending')",
                    P("@c", custId), P("@u", UserID), P("@t", orderType))
            Dim orderId As Integer = GetLastInsertedID()

            For Each line As CartLine In lines
                InsertItem(orderId, line)
            Next
            For Each kv As KeyValuePair(Of Integer, Integer) In ProductQuantities(lines)
                TakeStock(kv.Key, kv.Value, "Order #" & orderId)
            Next

            Execute("INSERT INTO tblsales (orderid, custid, userid, totalamount, paymentstatus) VALUES (@o, @c, @u, @t, 'Unpaid')",
                    P("@o", orderId), P("@c", custId), P("@u", UserID), P("@t", total))
            Dim saleId As Integer = GetLastInsertedID()
            Execute("INSERT INTO tblcustomertransactions (custid, saleid, amount, type) VALUES (@c, @s, @a, 'Sale')",
                    P("@c", custId), P("@s", saleId), P("@a", total))

            ' Credit the customer already has (a negative balance) pays for this sale first.
            Dim before As Decimal = CurrentBalance(custId)
            If before < 0 AndAlso total > 0 Then
                Dim credit As Decimal = Math.Min(-before, total)
                Execute("INSERT INTO tblpayments (saleid, amountpaid) VALUES (@s, @a)", P("@s", saleId), P("@a", credit))
                Execute("INSERT INTO tblcustomertransactions (custid, saleid, amount, type) VALUES (@c, @s, @a, 'Payment')",
                        P("@c", custId), P("@s", saleId), P("@a", credit))
            End If

            ' The credit is already part of the balance, so the balance only grows by the order total.
            AddToBalance(custId, total)
            RefreshPaymentStatus(saleId)

            LogActivity("Sales", "Created Order", saleId)
            CommitTransaction()
            Return {orderId, saleId}
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Function

    ' Replaces the items of a pending order. Only the difference in quantity
    ' moves stock; the sale total and customer balance follow the new total,
    ' and the order and sale dates stay as they were.
    Public Sub UpdateOrder(orderId As Integer, orderType As String, lines As List(Of CartLine))
        Dim newTotal As Decimal = CartTotal(lines)

        BeginTransaction()
        Try
            Dim status As Object = GetValue("SELECT status FROM tblorders WHERE orderid = @o FOR UPDATE", P("@o", orderId))
            If status Is Nothing Then Throw New ApplicationException("Order #" & orderId & " no longer exists.")
            If status.ToString() <> "Pending" Then
                Throw New ApplicationException("Only pending orders can be changed (Order #" & orderId & " is " & status.ToString() & ").")
            End If

            Dim oldQty As Dictionary(Of Integer, Integer) = OrderProductQuantities(orderId)
            Dim newQty As Dictionary(Of Integer, Integer) = ProductQuantities(lines)
            For Each kv As KeyValuePair(Of Integer, Integer) In oldQty
                Dim keep As Integer = If(newQty.ContainsKey(kv.Key), newQty(kv.Key), 0)
                If keep < kv.Value Then ReturnStock(kv.Key, kv.Value - keep, "Updated Order #" & orderId)
            Next
            For Each kv As KeyValuePair(Of Integer, Integer) In newQty
                Dim had As Integer = If(oldQty.ContainsKey(kv.Key), oldQty(kv.Key), 0)
                If kv.Value > had Then TakeStock(kv.Key, kv.Value - had, "Updated Order #" & orderId)
            Next

            Execute("DELETE FROM tblorderitems WHERE orderid = @o", P("@o", orderId))
            For Each line As CartLine In lines
                InsertItem(orderId, line)
            Next
            Execute("UPDATE tblorders SET ordertype = @t WHERE orderid = @o", P("@t", orderType), P("@o", orderId))

            GetQuery("SELECT saleid, custid, totalamount FROM tblsales WHERE orderid = @o", "ol_sale", P("@o", orderId))
            For Each sale As DataRow In ds.Tables("ol_sale").Rows
                Dim saleId As Integer = CInt(sale("saleid"))
                Execute("UPDATE tblsales SET totalamount = @t WHERE saleid = @s", P("@t", newTotal), P("@s", saleId))
                Execute("UPDATE tblcustomertransactions SET amount = @t WHERE saleid = @s AND type = 'Sale'", P("@t", newTotal), P("@s", saleId))
                AddToBalance(CInt(sale("custid")), newTotal - CDec(sale("totalamount")))
                RefreshPaymentStatus(saleId)
            Next

            LogActivity("Sales", "Update Order", orderId)
            CommitTransaction()
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Sub

    ' Next statuses an order may move to from its current one.
    Public Function AllowedNextStatuses(orderType As String, current As String) As String()
        Select Case orderType.Trim().ToLower() & "|" & current.Trim().ToLower()
            Case "pickup|pending"
                Return {"Completed", "Cancelled"}
            Case "delivery|pending"
                Return {"Ready To Deliver", "Cancelled"}
            Case "delivery|ready to deliver", "delivery|out for delivery"
                Return {"Pending", "Cancelled"}
        End Select
        Return New String() {}
    End Function

    ' Moves an order to a new status. Cancelling returns its stock and takes it
    ' off the customer's balance; going back to Pending or being cancelled also
    ' takes it out of its delivery.
    Public Sub ChangeOrderStatus(orderId As Integer, nextStatus As String)
        BeginTransaction()
        Try
            GetQuery("SELECT custid, ordertype, status FROM tblorders WHERE orderid = @o FOR UPDATE", "ol_order", P("@o", orderId))
            If ds.Tables("ol_order").Rows.Count = 0 Then Throw New ApplicationException("Order #" & orderId & " no longer exists.")
            Dim order As DataRow = ds.Tables("ol_order").Rows(0)
            Dim current As String = order("status").ToString()

            If Array.IndexOf(AllowedNextStatuses(order("ordertype").ToString(), current), nextStatus) < 0 Then
                Throw New ApplicationException("Order #" & orderId & " is " & current & " and can't be changed to " & nextStatus & ".")
            End If

            If nextStatus = "Cancelled" Then
                For Each kv As KeyValuePair(Of Integer, Integer) In OrderProductQuantities(orderId)
                    ReturnStock(kv.Key, kv.Value, "Order Cancelled #" & orderId)
                Next
                AddToBalance(CInt(order("custid")), -OrderTotal(orderId))
            End If

            If nextStatus = "Pending" OrElse nextStatus = "Cancelled" Then RemoveFromDelivery(orderId, True)

            Execute("UPDATE tblorders SET status = @s WHERE orderid = @o", P("@s", nextStatus), P("@o", orderId))
            LogActivity("Orders", "Status Changed to " & nextStatus, orderId)
            CommitTransaction()
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Sub

    ' Deletes an order with its sale and payments, as if it never happened.
    Public Sub DeleteOrder(orderId As Integer)
        BeginTransaction()
        Try
            GetQuery("SELECT custid, status FROM tblorders WHERE orderid = @o FOR UPDATE", "ol_order", P("@o", orderId))
            If ds.Tables("ol_order").Rows.Count = 0 Then Throw New ApplicationException("Order not found.")
            Dim custId As Integer = CInt(ds.Tables("ol_order").Rows(0)("custid"))
            Dim status As String = ds.Tables("ol_order").Rows(0)("status").ToString()

            If status = "Out For Delivery" Or status = "Ready To Deliver" Then
                Throw New ApplicationException("Cannot delete this order because it is currently in delivery or ready for delivery.")
            End If

            ' A cancelled order already gave its stock back and left the balance.
            If status <> "Cancelled" Then
                For Each kv As KeyValuePair(Of Integer, Integer) In OrderProductQuantities(orderId)
                    ReturnStock(kv.Key, kv.Value, "Order cancel/delete #" & orderId)
                Next
                AddToBalance(custId, -OrderTotal(orderId))
            End If

            ' Its payments are deleted too, so they stop counting toward the balance.
            GetQuery("SELECT saleid FROM tblsales WHERE orderid = @o", "ol_sales", P("@o", orderId))
            For Each sale As DataRow In ds.Tables("ol_sales").Rows
                Dim saleId As Integer = CInt(sale("saleid"))
                Dim paid As Decimal = TotalPaid(saleId)
                If paid <> 0 Then AddToBalance(custId, paid)
                Execute("DELETE FROM tblpayments WHERE saleid = @s", P("@s", saleId))
                Execute("DELETE FROM tblcustomertransactions WHERE saleid = @s", P("@s", saleId))
                Execute("DELETE FROM tblsales WHERE saleid = @s", P("@s", saleId))
            Next

            RemoveFromDelivery(orderId, True)
            Execute("DELETE FROM tblorderitems WHERE orderid = @o", P("@o", orderId))
            Execute("DELETE FROM tblorders WHERE orderid = @o", P("@o", orderId))

            LogActivity("Orders", "Deleted Order #" & orderId, orderId)
            CommitTransaction()
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Sub

    ' ---------------------------------------------------------------- payments

    ' Unpaid amount of an order's sale (total minus payments so far).
    Public Function OrderRemaining(orderId As Integer) As Decimal
        Dim value As Object = GetValue("SELECT s.totalamount - IFNULL((SELECT SUM(p.amountpaid) FROM tblpayments p WHERE p.saleid = s.saleid), 0) " &
                                       "FROM tblsales s WHERE s.orderid = @o LIMIT 1", P("@o", orderId))
        Return If(value Is Nothing, 0D, CDec(value))
    End Function

    ' Records a payment against an order. The amount may not be more than what
    ' is still unpaid on that order. Returns the sale's new payment status.
    Public Function AddPayment(orderId As Integer, amount As Decimal) As String
        BeginTransaction()
        Try
            GetQuery("SELECT s.saleid, s.custid, s.totalamount, o.status FROM tblsales s JOIN tblorders o ON o.orderid = s.orderid " &
                     "WHERE s.orderid = @o LIMIT 1 FOR UPDATE", "ol_pay", P("@o", orderId))
            If ds.Tables("ol_pay").Rows.Count = 0 Then
                Throw New ApplicationException("No sales record found for this order. Cannot proceed with payment.")
            End If

            Dim sale As DataRow = ds.Tables("ol_pay").Rows(0)
            If sale("status").ToString() = "Cancelled" Then Throw New ApplicationException("This order was cancelled, so it can't take payments.")

            Dim saleId As Integer = CInt(sale("saleid"))
            Dim custId As Integer = CInt(sale("custid"))
            Dim total As Decimal = CDec(sale("totalamount"))
            Dim paid As Decimal = TotalPaid(saleId)
            Dim remaining As Decimal = total - paid

            If amount <= 0 Then Throw New ApplicationException("Payment amount must be greater than zero.")
            If amount > remaining Then
                Throw New ApplicationException("Payment amount cannot exceed the remaining balance of this order (" & remaining.ToString("F2") & ").")
            End If

            Execute("INSERT INTO tblpayments (saleid, amountpaid) VALUES (@s, @a)", P("@s", saleId), P("@a", amount))
            Execute("INSERT INTO tblcustomertransactions (custid, saleid, amount, type) VALUES (@c, @s, @a, 'Payment')",
                    P("@c", custId), P("@s", saleId), P("@a", amount))
            AddToBalance(custId, -amount)
            RefreshPaymentStatus(saleId)

            LogActivity("Sales", "Payment of " & amount.ToString("F2") & " added", saleId)
            CommitTransaction()
            Return PaymentStatus(total, paid + amount)
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Function

    ' -------------------------------------------------------------- deliveries

    ' Creates a delivery for orders that are Ready To Deliver. Returns its id.
    Public Function AssignDelivery(personId As Integer, deliveryDate As Date, orderIds As List(Of Integer)) As Integer
        BeginTransaction()
        Try
            Execute("INSERT INTO tbldelivery (userid, deliverydate) VALUES (@u, @d)", P("@u", personId), P("@d", deliveryDate))
            Dim deliveryId As Integer = GetLastInsertedID()
            For Each orderId As Integer In orderIds
                LinkOrder(deliveryId, orderId)
            Next

            LogActivity("Delivery", "Assigned orders " & String.Join(", ", orderIds), deliveryId)
            CommitTransaction()
            Return deliveryId
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Function

    Public Sub AddOrdersToDelivery(deliveryId As Integer, orderIds As List(Of Integer))
        BeginTransaction()
        Try
            For Each orderId As Integer In orderIds
                LinkOrder(deliveryId, orderId)
            Next
            LogActivity("Delivery", "Added orders " & String.Join(", ", orderIds), deliveryId)
            CommitTransaction()
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Sub

    ' Takes an order that is still on the road out of a delivery.
    Public Sub RemoveOrderFromDelivery(deliveryId As Integer, orderId As Integer)
        BeginTransaction()
        Try
            Dim status As Object = GetValue("SELECT o.status FROM tblorders o JOIN tbldeliveryorders d ON d.orderid = o.orderid " &
                                            "WHERE d.deliveryid = @d AND o.orderid = @o FOR UPDATE", P("@d", deliveryId), P("@o", orderId))
            If status Is Nothing Then Throw New ApplicationException("Order #" & orderId & " is not part of this delivery.")
            If status.ToString() <> "Out For Delivery" Then
                Throw New ApplicationException("Only orders that are Out For Delivery can be removed (Order #" & orderId & " is " & status.ToString() & ").")
            End If

            Execute("DELETE FROM tbldeliveryorders WHERE deliveryid = @d AND orderid = @o", P("@d", deliveryId), P("@o", orderId))
            Execute("UPDATE tblorders SET status = 'Ready To Deliver' WHERE orderid = @o", P("@o", orderId))
            LogActivity("Delivery", "Removed Order #" & orderId, deliveryId)
            CommitTransaction()
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Sub

    ' Saves the delivery person, date and status. Delivered completes the orders
    ' still on the road; Cancelled sends them back to Ready To Deliver and
    ' deletes the delivery if no completed orders are left in it.
    ' Returns True when the delivery itself was deleted.
    Public Function UpdateDelivery(deliveryId As Integer, personId As Integer, deliveryDate As Date, status As String) As Boolean
        If status <> "Out For Delivery" AndAlso status <> "Delivered" AndAlso status <> "Cancelled" Then
            Throw New ApplicationException("Please choose a delivery status: Out For Delivery, Delivered or Cancelled.")
        End If

        Dim deleted As Boolean = False
        BeginTransaction()
        Try
            Execute("UPDATE tbldelivery SET userid = @u, deliverydate = @d WHERE deliveryid = @id", P("@u", personId), P("@d", deliveryDate), P("@id", deliveryId))

            Const onTheRoad As String = "status = 'Out For Delivery' AND orderid IN (SELECT orderid FROM tbldeliveryorders WHERE deliveryid = @id)"
            Select Case status
                Case "Out For Delivery"
                    Execute("UPDATE tblorders SET status = 'Out For Delivery' WHERE status = 'Ready To Deliver' AND " &
                            "orderid IN (SELECT orderid FROM tbldeliveryorders WHERE deliveryid = @id)", P("@id", deliveryId))
                Case "Delivered"
                    Execute("UPDATE tblorders SET status = 'Completed' WHERE " & onTheRoad, P("@id", deliveryId))
                Case "Cancelled"
                    GetQuery("SELECT orderid FROM tblorders WHERE " & onTheRoad, "ol_cancel", P("@id", deliveryId))
                    For Each row As DataRow In ds.Tables("ol_cancel").Rows
                        Execute("DELETE FROM tbldeliveryorders WHERE deliveryid = @id AND orderid = @o", P("@id", deliveryId), P("@o", row("orderid")))
                        Execute("UPDATE tblorders SET status = 'Ready To Deliver' WHERE orderid = @o", P("@o", row("orderid")))
                    Next
                    deleted = DeleteDeliveryIfEmpty(deliveryId)
            End Select

            LogActivity("Delivery", If(deleted, "Cancelled and deleted Delivery", "Updated Delivery (" & status & ")"), deliveryId)
            CommitTransaction()
            Return deleted
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Function

    ' Deletes a delivery and sends its orders that are still on the road back to
    ' Ready To Deliver. A delivery with completed orders is kept as a record.
    Public Sub DeleteDelivery(deliveryId As Integer)
        BeginTransaction()
        Try
            Dim completed As Integer = CInt(GetValue("SELECT COUNT(*) FROM tbldeliveryorders d JOIN tblorders o ON o.orderid = d.orderid " &
                                                     "WHERE d.deliveryid = @d AND o.status = 'Completed'", P("@d", deliveryId)))
            If completed > 0 Then
                Throw New ApplicationException("This delivery has " & completed & " completed order(s), so it is kept as a record and can't be deleted.")
            End If

            Execute("UPDATE tblorders SET status = 'Ready To Deliver' WHERE status = 'Out For Delivery' AND " &
                    "orderid IN (SELECT orderid FROM tbldeliveryorders WHERE deliveryid = @d)", P("@d", deliveryId))
            Execute("DELETE FROM tbldeliveryorders WHERE deliveryid = @d", P("@d", deliveryId))
            Execute("DELETE FROM tbldelivery WHERE deliveryid = @d", P("@d", deliveryId))

            LogActivity("Delivery", "Deleted Delivery", deliveryId)
            CommitTransaction()
        Catch
            RollbackTransaction()
            Throw
        End Try
    End Sub

    ' ------------------------------------------------------------------ helpers

    Private Sub InsertItem(orderId As Integer, line As CartLine)
        If line.ItemType = "Product" Then
            Execute("INSERT INTO tblorderitems (orderid, productid, qty, price, itemtype) VALUES (@o, @i, @q, @p, 'Product')",
                    P("@o", orderId), P("@i", line.ItemID), P("@q", line.Qty), P("@p", line.Price))
        Else
            Execute("INSERT INTO tblorderitems (orderid, serviceid, qty, price, itemtype) VALUES (@o, @i, @q, @p, 'Service')",
                    P("@o", orderId), P("@i", line.ItemID), P("@q", line.Qty), P("@p", line.Price))
        End If
    End Sub

    ' Total quantity per product in a cart.
    Private Function ProductQuantities(lines As List(Of CartLine)) As Dictionary(Of Integer, Integer)
        Dim result As New Dictionary(Of Integer, Integer)
        For Each line As CartLine In lines
            If line.ItemType = "Product" Then
                result(line.ItemID) = If(result.ContainsKey(line.ItemID), result(line.ItemID), 0) + line.Qty
            End If
        Next
        Return result
    End Function

    ' Total quantity per product saved on an order.
    Private Function OrderProductQuantities(orderId As Integer) As Dictionary(Of Integer, Integer)
        GetQuery("SELECT productid, SUM(qty) AS qty FROM tblorderitems WHERE orderid = @o AND itemtype = 'Product' GROUP BY productid", "ol_qty", P("@o", orderId))
        Dim result As New Dictionary(Of Integer, Integer)
        For Each row As DataRow In ds.Tables("ol_qty").Rows
            result(CInt(row("productid"))) = CInt(row("qty"))
        Next
        Return result
    End Function

    Private Function OrderTotal(orderId As Integer) As Decimal
        Return CDec(GetValue("SELECT IFNULL(SUM(qty * price), 0) FROM tblorderitems WHERE orderid = @o", P("@o", orderId)))
    End Function

    Private Function TotalPaid(saleId As Integer) As Decimal
        Return CDec(GetValue("SELECT IFNULL(SUM(amountpaid), 0) FROM tblpayments WHERE saleid = @s", P("@s", saleId)))
    End Function

    Private Sub RefreshPaymentStatus(saleId As Integer)
        Dim total As Decimal = CDec(GetValue("SELECT totalamount FROM tblsales WHERE saleid = @s", P("@s", saleId)))
        Execute("UPDATE tblsales SET paymentstatus = @st WHERE saleid = @s", P("@st", PaymentStatus(total, TotalPaid(saleId))), P("@s", saleId))
    End Sub

    Private Function CurrentBalance(custId As Integer) As Decimal
        Dim value As Object = GetValue("SELECT balance FROM tblcustomerbalance WHERE custid = @c FOR UPDATE", P("@c", custId))
        Return If(value Is Nothing, 0D, CDec(value))
    End Function

    ' Changes what the customer owes (positive = owes more), creating the balance row if needed.
    Private Sub AddToBalance(custId As Integer, amount As Decimal)
        If amount = 0 Then Return
        Execute("INSERT INTO tblcustomerbalance (custid, balance) VALUES (@c, @a) " &
                "ON DUPLICATE KEY UPDATE balance = IFNULL(balance, 0) + @a, lastupdate = NOW()", P("@c", custId), P("@a", amount))
    End Sub

    Private Sub TakeStock(productId As Integer, qty As Integer, remarks As String)
        GetQuery("SELECT name, stockqty FROM tblproducts WHERE productid = @p FOR UPDATE", "ol_stock", P("@p", productId))
        If ds.Tables("ol_stock").Rows.Count = 0 Then Throw New ApplicationException("Product #" & productId & " no longer exists.")

        Dim product As DataRow = ds.Tables("ol_stock").Rows(0)
        Dim stock As Integer = CInt(product("stockqty"))
        If stock < qty Then
            Throw New ApplicationException("Not enough stock for " & product("name").ToString() & " (needs " & qty & ", has " & stock & ").")
        End If

        Execute("UPDATE tblproducts SET stockqty = stockqty - @q WHERE productid = @p", P("@q", qty), P("@p", productId))
        Execute("INSERT INTO tblinventorytransactions (productid, userid, transtype, qty, remarks) VALUES (@p, @u, 'Stock Out', @q, @r)",
                P("@p", productId), P("@u", UserID), P("@q", qty), P("@r", remarks))
    End Sub

    Private Sub ReturnStock(productId As Integer, qty As Integer, remarks As String)
        Execute("UPDATE tblproducts SET stockqty = stockqty + @q WHERE productid = @p", P("@q", qty), P("@p", productId))
        Execute("INSERT INTO tblinventorytransactions (productid, userid, transtype, qty, remarks) VALUES (@p, @u, 'Stock In', @q, @r)",
                P("@p", productId), P("@u", UserID), P("@q", qty), P("@r", remarks))
    End Sub

    ' Puts a Ready To Deliver order into a delivery and marks it Out For Delivery.
    Private Sub LinkOrder(deliveryId As Integer, orderId As Integer)
        Dim status As Object = GetValue("SELECT status FROM tblorders WHERE orderid = @o FOR UPDATE", P("@o", orderId))
        If status Is Nothing OrElse status.ToString() <> "Ready To Deliver" Then
            Throw New ApplicationException("Order #" & orderId & " is no longer ready to deliver.")
        End If
        If CInt(GetValue("SELECT COUNT(*) FROM tbldeliveryorders WHERE orderid = @o", P("@o", orderId))) > 0 Then
            Throw New ApplicationException("Order #" & orderId & " is already assigned to another delivery.")
        End If

        Execute("INSERT INTO tbldeliveryorders (deliveryid, orderid) VALUES (@d, @o)", P("@d", deliveryId), P("@o", orderId))
        Execute("UPDATE tblorders SET status = 'Out For Delivery' WHERE orderid = @o", P("@o", orderId))
    End Sub

    ' Takes an order out of any delivery it is in.
    Private Sub RemoveFromDelivery(orderId As Integer, deleteEmptyDeliveries As Boolean)
        GetQuery("SELECT deliveryid FROM tbldeliveryorders WHERE orderid = @o", "ol_links", P("@o", orderId))
        Dim deliveryIds As New List(Of Integer)
        For Each row As DataRow In ds.Tables("ol_links").Rows
            deliveryIds.Add(CInt(row("deliveryid")))
        Next

        Execute("DELETE FROM tbldeliveryorders WHERE orderid = @o", P("@o", orderId))
        If deleteEmptyDeliveries Then
            For Each deliveryId As Integer In deliveryIds
                DeleteDeliveryIfEmpty(deliveryId)
            Next
        End If
    End Sub

    Private Function DeleteDeliveryIfEmpty(deliveryId As Integer) As Boolean
        Return Execute("DELETE FROM tbldelivery WHERE deliveryid = @d AND NOT EXISTS (SELECT 1 FROM tbldeliveryorders WHERE deliveryid = @d)", P("@d", deliveryId)) > 0
    End Function
End Module
