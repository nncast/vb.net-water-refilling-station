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
        cmbStatus.Text = DeliveryStatus

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
                    For Each orderID As Integer In dlg.SelectedOrderIDs
                        ' Link the order to this delivery
                        SetQuery("INSERT INTO tbldeliveryorders (deliveryid, orderid) VALUES (" & DeliveryID & ", " & orderID & ")")

                        ' Update the order’s status
                        SetQuery("UPDATE tblorders SET status = 'Out For Delivery' WHERE orderid = " & orderID)
                    Next

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
                ' --- Delete link ---
                SetQuery("DELETE FROM tbldeliveryorders WHERE deliveryid = " & DeliveryID & " AND orderid = " & orderID)

                ' --- Reset order status ---
                SetQuery("UPDATE tblorders SET status = 'Ready To Deliver' WHERE orderid = " & orderID)

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
                "WHERE do.deliveryid = " & deliveryID & " " &
                "GROUP BY o.orderid, c.fullname, o.status"


            GetQuery(sql, "assignedorders")

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
                    SetQuery("DELETE FROM tbldelivery WHERE deliveryid = " & DeliveryID)
                    LogActivity("Delivery", "Deleted Delivery #" & DeliveryID & " because it had no assigned orders.", DeliveryID)
                    MsgBox("Delivery deleted successfully.", MsgBoxStyle.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
                Exit Sub
            End If

            Dim newDate As String = dtpDeliveryDate.Value.ToString("yyyy-MM-dd HH:mm:ss")
            Dim newUserID As Integer = CInt(cmbDeliveryPerson.SelectedValue)
            Dim newStatus As String = cmbStatus.Text.Trim()

            ' --- Update delivery info ---
            SetQuery("UPDATE tbldelivery SET userid = " & newUserID & ", deliverydate = '" & newDate & "' WHERE deliveryid = " & DeliveryID)

            ' --- Map delivery-level status to order statuses ---
            Dim orderStatus As String = ""
            Select Case newStatus
                Case "Out For Delivery"
                    orderStatus = "Out For Delivery"
                Case "Delivered"
                    orderStatus = "Completed"
                Case "Cancelled"
                    orderStatus = "Ready To Deliver"
                Case Else
                    orderStatus = "Ready To Deliver"
            End Select

            ' --- Update all orders tied to this delivery ---
            SetQuery("UPDATE tblorders SET status = '" & orderStatus & "' " &
                     "WHERE orderid IN (SELECT orderid FROM tbldeliveryorders WHERE deliveryid = " & DeliveryID & ")")

            ' --- Log activity ---
            LogActivity("Delivery", "Updated Delivery", DeliveryID)

            MsgBox("Delivery and order statuses updated successfully.", MsgBoxStyle.Information)
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
