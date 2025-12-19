Public Class E3_Orders


    Private Sub A_Orders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillOrders()
    End Sub

    Public Sub FillOrders(Optional ByVal keyword As String = "")
        lvorders.Items.Clear()

        Dim sql As String =
          "SELECT o.orderid, " &
          "c.custid, " &
          "c.fullname AS customer_name, " &
          "o.ordertype, " &
          "o.status, " &
          "IFNULL(items.totalamount, 0) AS totalamount, " &
          "IFNULL(payments.amountpaid, 0) AS amountpaid, " &
          "IFNULL(cb.balance, 0) AS balance, " &
          "CONCAT(u.fname, ' ', IFNULL(u.lname, '')) AS processed_by, " &
          "o.orderdate " &
          "FROM tblorders o " &
          "LEFT JOIN tblcustomers c ON o.custid = c.custid " &
          "LEFT JOIN ( " &
          "    SELECT orderid, SUM(qty * price) AS totalamount " &
          "    FROM tblorderitems " &
          "    GROUP BY orderid " &
          ") items ON o.orderid = items.orderid " &
          "LEFT JOIN ( " &
          "    SELECT s.orderid, SUM(p.amountpaid) AS amountpaid " &
          "    FROM tblsales s " &
          "    LEFT JOIN tblpayments p ON s.saleid = p.saleid " &
          "    GROUP BY s.orderid " &
          ") payments ON o.orderid = payments.orderid " &
          "LEFT JOIN tblcustomerbalance cb ON o.custid = cb.custid " &
          "LEFT JOIN tblusers u ON o.userid = u.userid " &
          "WHERE (c.fullname LIKE '%" & keyword & "%' OR o.orderid LIKE '%" & keyword & "%') " &
          "ORDER BY o.orderdate DESC, o.orderid DESC"




        GetQuery(sql, "orders")

        If ds.Tables("orders").Rows.Count > 0 Then
            For Each row As DataRow In ds.Tables("orders").Rows
                Dim item As ListViewItem = lvorders.Items.Add(row("orderid").ToString())
                item.SubItems.Add(row("custid").ToString())
                item.SubItems.Add(row("customer_name").ToString())
                item.SubItems.Add(row("ordertype").ToString())
                item.SubItems.Add(Format(CDec(row("totalamount")), "0.00"))
                item.SubItems.Add(Format(CDec(row("amountpaid")), "0.00"))
                item.SubItems.Add(Format(CDec(row("balance")), "0.00"))
                item.SubItems.Add(row("status").ToString().Trim())
                item.SubItems.Add(row("processed_by").ToString())
                item.SubItems.Add(Format(CDate(row("orderdate")), "yyyy-MM-dd"))

                Dim status As String = row("status").ToString().Trim().ToLower()

                Select Case status
                    Case "completed"
                        item.ForeColor = Color.Green
                    Case "cancelled"
                        item.ForeColor = Color.Red
                    Case "ready to deliver"
                        item.ForeColor = Color.RoyalBlue
                End Select
            Next
        End If


    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        FillOrders(txtsearch.Text.Trim())
    End Sub


    Private Sub btnpayment_Click(sender As Object, e As EventArgs) Handles btnpayment.Click
        If lvorders.SelectedItems.Count = 0 Then
            MsgBox("Please select an order first.", MsgBoxStyle.Exclamation, "No Order Selected")
            Exit Sub
        End If

        Dim selectedOrder As ListViewItem = lvorders.SelectedItems(0)

        Dim orderID As Integer = CInt(selectedOrder.SubItems(0).Text)
        Dim customerID As Integer = CInt(selectedOrder.SubItems(1).Text)
        Dim customerName As String = selectedOrder.SubItems(2).Text
        Dim orderType As String = selectedOrder.SubItems(3).Text

        Dim totalAmount As Decimal = 0
        If Not Decimal.TryParse(selectedOrder.SubItems(4).Text, totalAmount) Then
            MsgBox("Invalid total amount.", MsgBoxStyle.Critical, "Data Error")
            Exit Sub
        End If

        Dim paidAmount As Decimal = 0
        If Not Decimal.TryParse(selectedOrder.SubItems(5).Text, paidAmount) Then
            MsgBox("Invalid paid amount.", MsgBoxStyle.Critical, "Data Error")
            Exit Sub
        End If

        Dim balance As Decimal = 0
        If Not Decimal.TryParse(selectedOrder.SubItems(6).Text, balance) Then
            MsgBox("Invalid balance amount.", MsgBoxStyle.Critical, "Data Error")
            Exit Sub
        End If

        If totalAmount <= paidAmount Then
            MsgBox("This order is already fully paid.", MsgBoxStyle.Information, "No Payment Needed")
            Exit Sub
        End If

        Dim orderDate As Date
        If Not Date.TryParse(selectedOrder.SubItems(9).Text, orderDate) Then
            orderDate = Now
        End If

        With DlgPayment
            .OrderID = orderID
            .CustomerID = customerID
            .CustomerName = customerName
            .TotalAmount = totalAmount
            .PaidAmount = paidAmount
            .Balance = balance
            .OrderDate = orderDate
            .CurrentUserID = Globals.UserID
        End With

        If DlgPayment.ShowDialog() = DialogResult.OK Then
            FillOrders()
        End If
    End Sub

    Private Sub btnchangestatus_Click(sender As Object, e As EventArgs) Handles btnchangestatus.Click
        If lvorders.SelectedItems.Count = 0 Then
            MsgBox("Please select an order to change status.", MsgBoxStyle.Exclamation, "No Order Selected")
            Exit Sub
        End If

        Dim selectedOrder As ListViewItem = lvorders.SelectedItems(0)
        Dim orderId As Integer = CInt(selectedOrder.SubItems(0).Text)
        Dim currentStatus As String = selectedOrder.SubItems(7).Text.Trim()
        Dim orderType As String = selectedOrder.SubItems(3).Text.Trim().ToLower()

        Dim allowedNextStatuses As New List(Of String)

        If orderType = "pickup" Then
            Select Case currentStatus.ToLower()
                Case "pending"
                    allowedNextStatuses.AddRange({"Completed", "Cancelled"})
                Case "completed", "cancelled"
                    MsgBox("This order cannot be changed because it is already " & currentStatus & ".", MsgBoxStyle.Information, "Invalid Status")
                    Exit Sub

                Case Else
                    MsgBox("Unknown order status. Cannot change.", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
            End Select
        ElseIf orderType = "delivery" Then
            Select Case currentStatus.ToLower()
                Case "pending"
                    allowedNextStatuses.AddRange({"Ready To Deliver", "Cancelled"})
                Case "ready to deliver"
                    allowedNextStatuses.AddRange({"Pending", "Cancelled"})
                Case "out for delivery"
                    allowedNextStatuses.AddRange({"Pending", "Cancelled"})
                Case "completed", "cancelled"
                    MsgBox("This order cannot be changed because it is already " & currentStatus & ".", MsgBoxStyle.Information, "Invalid Status")
                    Exit Sub

                Case Else
                    MsgBox("Unknown order status. Cannot change.", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
            End Select
        Else
            MsgBox("Unknown order type.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        Dim dlg As New DlgOrderStatus()
        dlg.cmborderstatus.Items.Clear()
        dlg.cmborderstatus.Items.AddRange(allowedNextStatuses.ToArray())
        dlg.cmborderstatus.SelectedIndex = 0

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim nextStatus As String = dlg.cmborderstatus.SelectedItem.ToString().Trim()

            GetQuery("SELECT custid FROM tblorders WHERE orderid = " & orderId, "cust")
            Dim custid As Integer = 0
            If ds.Tables("cust").Rows.Count > 0 Then
                custid = CInt(ds.Tables("cust").Rows(0)("custid"))
            End If

            If nextStatus.ToLower() = "cancelled" Then
                GetQuery("SELECT productid, qty FROM tblorderitems WHERE orderid = " & orderId & " AND itemtype='Product'", "restoreStock")
                For Each row As DataRow In ds.Tables("restoreStock").Rows
                    Dim pid As Integer = CInt(row("productid"))
                    Dim qty As Integer = CInt(row("qty"))

                    SetQuery("UPDATE tblproducts SET stockqty = stockqty + " & qty & " WHERE productid = " & pid)

                    SetQuery("INSERT INTO tblinventorytransactions (productid, userid, transtype, qty, remarks) " &
                             "VALUES (" & pid & ", 1, 'Stock In', " & qty & ", 'Order Cancelled #" & orderId & "')")
                Next

                GetQuery("SELECT IFNULL(SUM(qty * price),0) AS total FROM tblorderitems WHERE orderid = " & orderId, "ordertotal")
                Dim orderTotal As Decimal = 0
                If ds.Tables("ordertotal").Rows.Count > 0 Then
                    orderTotal = CDec(ds.Tables("ordertotal").Rows(0)("total"))
                End If
                If custid > 0 Then
                    SetQuery("UPDATE tblcustomerbalance SET balance = balance - " & orderTotal & ", lastupdate = NOW() WHERE custid = " & custid)
                End If
            End If

            SetQuery("UPDATE tblorders SET status = '" & nextStatus & "' WHERE orderid = " & orderId)

            Dim currentUserId As Integer = 1
            SetQuery("INSERT INTO tblactivitylogs (userid, module, action, recordid) " &
                     "VALUES (" & currentUserId & ", 'Orders', 'Status Changed to " & nextStatus & "', " & orderId & ")")

            MsgBox("Order #" & orderId & " status changed to '" & nextStatus & "'.", MsgBoxStyle.Information, "Status Updated")
            FillOrders()
        End If
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        Globals.labelclickedA(AdminDashboard.lblsales)
        AdminDashboard.switchPanel(E2_Sales)
        AdminDashboard.lbltitle.Text = "Sales"
        E2_Sales.LoadCustomers()
        E2_Sales.LoadProducts()
        E2_Sales.LoadServices()
        E2_Sales.LoadOrderTypes()
        E2_Sales.LoadNextOrderID()
        E2_Sales.SetSalesFormState("new")
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Open Orders form
        labelclickedE(EmployeeDashboard.lbldelivery)
        EmployeeDashboard.switchPanel(E5_Delivery)
        EmployeeDashboard.lbltitle.Text = "Delivery"
        E5_Delivery.FillReadyOrders()
        E5_Delivery.LoadDeliveries()
        E5_Delivery.LoadDeliveryPersons()
    End Sub
End Class