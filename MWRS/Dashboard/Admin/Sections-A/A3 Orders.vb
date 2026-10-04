Public Class A3_Orders

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
          "WHERE (c.fullname LIKE @k OR o.orderid LIKE @k) " &
          "ORDER BY o.orderdate DESC, o.orderid DESC"




        GetQuery(sql, "orders", P("@k", "%" & keyword & "%"))

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

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        If lvorders.SelectedItems.Count = 0 Then
            MsgBox("Please select an order to update.", MsgBoxStyle.Information, "Update Order")
            Exit Sub
        End If

        Dim selectedOrder As ListViewItem = lvorders.SelectedItems(0)
        Dim orderId As Integer = CInt(selectedOrder.Text)
        Dim status As String = selectedOrder.SubItems(7).Text.Trim().ToLower()

        If status = "cancelled" Or status = "ready to deliver" Or status = "completed" Or status = "out for delivery" Then
            MsgBox("Cannot update an order that is cancelled, ready to deliver, or out for delivery, completed.", MsgBoxStyle.Exclamation, "Update Not Allowed")
            Exit Sub
        End If

        ' Get order date from ListView
        Dim orderDate As Date
        If Not Date.TryParse(selectedOrder.SubItems(9).Text, orderDate) Then
            orderDate = Now ' fallback if parsing fails
        End If

        ' Switch to Sales panel
        labelclickedA(AdminDashboard.lblsales)
        AdminDashboard.switchPanel(A2_Sales)
        AdminDashboard.lbltitle.Text = "Sales"

        ' Load customers, products, services, order types
        A2_Sales.LoadCustomers()
        A2_Sales.LoadProducts()
        A2_Sales.LoadServices()
        A2_Sales.LoadOrderTypes()

        ' Set update mode and current order
        A2_Sales.IsUpdateMode = True
        A2_Sales.CurrentOrderID = orderId

        ' Load existing order details
        A2_Sales.LoadExistingOrder(orderId)

        ' Pass the order date to DateTimePicker
        A2_Sales.dtpdate.Value = orderDate
    End Sub



    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If lvorders.SelectedItems.Count = 0 Then
            MsgBox("Please select an order to delete.", MsgBoxStyle.Information, "Delete Order")
            Exit Sub
        End If

        Dim orderId As Integer = CInt(lvorders.SelectedItems(0).Text)
        Dim confirm As DialogResult = MsgBox("Are you sure you want to delete Order #" & orderId & "?" & vbCrLf &
                                             "This will restore stock and remove all related sales and payment records.",
                                             MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm Delete")
        If confirm = DialogResult.No Then Exit Sub

        Try
            ' Stock and balance are only reversed if cancelling hasn't done it already;
            ' payments, the sale and any delivery link go with the order.
            DeleteOrder(orderId)

            MsgBox("Order #" & orderId & " deleted successfully. Stock restored and records cleared.", MsgBoxStyle.Information, "Deleted")
            FillOrders()

        Catch ex As Exception
            MsgBox("An error occurred while deleting the order: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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

            ' Re-checks the order's current status, returns stock and updates the
            ' balance when cancelling, takes it out of its delivery when it goes
            ' back to Pending or is cancelled, and logs it under the current user.
            Try
                ChangeOrderStatus(orderId, nextStatus)
                MsgBox("Order #" & orderId & " status changed to '" & nextStatus & "'.", MsgBoxStyle.Information, "Status Updated")
            Catch ex As Exception
                MsgBox("Could not change the order status: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
            FillOrders()
        End If
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        Globals.labelclickedA(AdminDashboard.lblsales)
        AdminDashboard.switchPanel(A2_Sales)
        AdminDashboard.lbltitle.Text = "Sales"
        A2_Sales.LoadCustomers()
        A2_Sales.LoadProducts()
        A2_Sales.LoadServices()
        A2_Sales.LoadOrderTypes()
        A2_Sales.LoadNextOrderID()
        A2_Sales.SetSalesFormState("new")
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Open Orders form
        labelclickedA(AdminDashboard.lbldelivery)
        AdminDashboard.switchPanel(A5_Delivery)
        AdminDashboard.lbltitle.Text = "Delivery"
        A5_Delivery.FillReadyOrders()
        A5_Delivery.LoadDeliveries()
        A5_Delivery.LoadDeliveryPersons()
    End Sub
End Class
