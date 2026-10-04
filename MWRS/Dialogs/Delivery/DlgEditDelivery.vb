Public Class DlgEditDelivery
    Public Property DeliveryID As Integer
    Public Property DeliveryPerson As String
    Public Property DeliveryDate As Date
    Public Property DeliveryStatus As String

    Private Sub DlgEditDelivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate delivery status options (derived from order statuses)
        cmbStatus.Items.Clear()
        cmbStatus.Items.AddRange(New String() {
            "Out For Delivery",
            "Delivered",
            "Cancelled"
        })

        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.SelectedIndex = cmbStatus.Items.IndexOf(DeliveryStatus)

        lblDeliveryID.Text = DeliveryID.ToString()
        dtpDeliveryDate.Value = DeliveryDate

        LoadDeliveryPersons()
        cmbDeliveryPerson.Text = DeliveryPerson

        LoadAssignedOrders(DeliveryID)
    End Sub


    Private Sub LoadDeliveryPersons()
        Try
            ' --- Fetch active employees ---
            GetQuery("SELECT userid, CONCAT(fname, ' ', lname) AS fullname FROM tblusers WHERE status='Active'", "employees")

            ' --- Use a DataTable ---
            Dim dt As DataTable = ds.Tables("employees").Copy()

            cmbDeliveryPerson.DataSource = dt
            cmbDeliveryPerson.DisplayMember = "fullname"  ' What is shown in the combo box
            cmbDeliveryPerson.ValueMember = "userid"      ' Actual value used in queries
            cmbDeliveryPerson.SelectedIndex = -1          ' Optional: no selection by default
        Catch ex As Exception
            MsgBox("Error loading delivery persons: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnAddOrder_Click(sender As Object, e As EventArgs) Handles btnAddOrder.Click
        Dim dlg As New DlgUnassignedOrders()
        If dlg.ShowDialog() = DialogResult.OK Then
            If dlg.SelectedOrderIDs.Count > 0 Then
                Try
                    ' Each order must still be Ready To Deliver and not in another delivery.
                    AddOrdersToDelivery(DeliveryID, dlg.SelectedOrderIDs)

                    MsgBox(dlg.SelectedOrderIDs.Count & " order(s) added to delivery.", MsgBoxStyle.Information)
                    LoadAssignedOrders(DeliveryID)

                Catch ex As Exception
                    MsgBox("Error adding orders: " & ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
        End If
    End Sub


    Private Sub btnRemoveOrder_Click(sender As Object, e As EventArgs) Handles btnRemoveOrder.Click
        If lvAssignedOrders.SelectedItems.Count = 0 Then
            MsgBox("Select an order to remove.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim selectedItem As ListViewItem = lvAssignedOrders.SelectedItems(0)
        Dim orderID As Integer = CInt(selectedItem.SubItems(0).Text)

        If MsgBox("Remove this order from the delivery?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.Yes Then
            Try
                ' Only an order that is still Out For Delivery goes back to Ready To Deliver;
                ' completed or cancelled orders keep their status.
                RemoveOrderFromDelivery(DeliveryID, orderID)

                MsgBox("Order removed and reverted to 'Ready To Deliver'.", MsgBoxStyle.Information)
                LoadAssignedOrders(DeliveryID)
            Catch ex As Exception
                MsgBox("Error removing order: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub


    Private Sub LoadAssignedOrders(ByVal deliveryID As Integer)
        Try
            Dim sql As String =
                "SELECT o.orderid, c.fullname, o.status, " &
                "IFNULL(SUM(oi.qty * oi.price), 0) AS total " &
                "FROM tbldeliveryorders do " &
                "LEFT JOIN tblorders o ON do.orderid = o.orderid " &
                "LEFT JOIN tblcustomers c ON o.custid = c.custid " &
                "LEFT JOIN tblorderitems oi ON o.orderid = oi.orderid " &
                "WHERE do.deliveryid = @d " &
                "GROUP BY o.orderid, c.fullname, o.status"


            GetQuery(sql, "assignedorders", P("@d", deliveryID))

            lvAssignedOrders.Items.Clear()
            For Each row As DataRow In ds.Tables("assignedorders").Rows
                Dim item As ListViewItem = lvAssignedOrders.Items.Add(row("orderid").ToString())
                item.SubItems.Add(row("fullname").ToString())

                item.SubItems.Add(Format(CDec(row("total")), "0.00"))
                item.SubItems.Add(row("status").ToString())
            Next
        Catch ex As Exception
            MsgBox("Error loading assigned orders: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            ' --- Validate delivery person ---
            If cmbDeliveryPerson.SelectedIndex = -1 OrElse cmbDeliveryPerson.SelectedValue Is Nothing Then
                MsgBox("Please select a delivery person.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' --- Check if any orders are assigned ---
            If lvAssignedOrders.Items.Count = 0 Then
                ' No orders, delete the delivery record
                If MsgBox("No orders assigned to this delivery. Delete the delivery record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete") = MsgBoxResult.Yes Then
                    DeleteDelivery(DeliveryID)
                    MsgBox("Delivery deleted successfully.", MsgBoxStyle.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
                Exit Sub
            End If

            ' --- Validate status ---
            If cmbStatus.SelectedIndex = -1 Then
                MsgBox("Please select a delivery status.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' Delivered completes the orders that are still on the road; Cancelled
            ' sends them back to Ready To Deliver and removes them from this delivery.
            Dim deleted As Boolean = UpdateDelivery(DeliveryID, CInt(cmbDeliveryPerson.SelectedValue), dtpDeliveryDate.Value, cmbStatus.Text)

            If deleted Then
                MsgBox("Delivery cancelled. Its orders are back in 'Ready To Deliver' and the empty delivery was removed.", MsgBoxStyle.Information)
            Else
                MsgBox("Delivery and order statuses updated successfully.", MsgBoxStyle.Information)
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Error updating delivery: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
