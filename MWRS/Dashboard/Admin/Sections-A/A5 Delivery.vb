Public Class A5_Delivery

    Private Sub A_Delivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillReadyOrders()
        LoadDeliveryPersons()
        LoadDeliveries()
    End Sub

    Public Sub LoadDeliveryPersons()
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

    Public Sub FillReadyOrders(Optional ByVal keyword As String = "")
        lvreadyorders.Items.Clear()

        Dim sql As String =
            "SELECT o.orderid, " &
            "c.fullname, " &
            "b.barangayname, " &
            "p.purokname, " &
            "IFNULL(SUM(oi.qty * oi.price), 0) AS totalamount, " &
            "IFNULL(cb.balance, 0) AS balance, " &
            "o.orderdate " &
            "FROM tblorders o " &
            "LEFT JOIN tblcustomers c ON o.custid = c.custid " &
            "LEFT JOIN tblbarangays b ON c.barangayid = b.barangayid " &
            "LEFT JOIN tblpuroks p ON c.purokid = p.purokid " &
            "LEFT JOIN tblorderitems oi ON o.orderid = oi.orderid " &
            "LEFT JOIN tblcustomerbalance cb ON o.custid = cb.custid " &
            "WHERE o.status = 'Ready To Deliver' " &
            If(keyword <> "", " AND (c.fullname LIKE @k OR o.orderid LIKE @k)", "") &
            " GROUP BY o.orderid, c.fullname, b.barangayname, p.purokname, cb.balance, o.orderdate " &
            " ORDER BY o.orderdate ASC"

        GetQuery(sql, "readyorders", P("@k", "%" & keyword & "%"))

        If ds.Tables("readyorders").Rows.Count > 0 Then
            For Each row As DataRow In ds.Tables("readyorders").Rows
                Dim item As ListViewItem = lvreadyorders.Items.Add(row("orderid").ToString())
                item.SubItems.Add(row("fullname").ToString())
                ' Combine purok and barangay as address
                Dim address As String = ""
                If Not IsDBNull(row("purokname")) Then address &= row("purokname")
                If Not IsDBNull(row("barangayname")) Then
                    If address <> "" Then address &= ", "
                    address &= row("barangayname")
                End If
                item.SubItems.Add(address)
                item.SubItems.Add(Format(CDate(row("orderdate")), "yyyy-MM-dd"))
                item.SubItems.Add(Format(CDec(row("totalamount")), "0.00"))
                item.SubItems.Add(Format(CDec(row("balance")), "0.00"))
            Next
        End If
    End Sub




    Private Sub btnAssignDelivery_Click(sender As Object, e As EventArgs) Handles btnAssignDelivery.Click
        ' --- Validation ---
        If lvreadyorders.SelectedItems.Count = 0 Then
            MsgBox("Select at least one order.", MsgBoxStyle.Exclamation, "No Order Selected")
            Exit Sub
        End If

        If dtpDeliveryDate.Value.Date < DateTime.Now.Date Then
            MsgBox("Delivery date cannot be earlier than today.", MsgBoxStyle.Exclamation, "Invalid Date")
            Exit Sub
        End If

        If cmbDeliveryPerson.SelectedIndex = -1 OrElse cmbDeliveryPerson.SelectedValue Is Nothing Then
            MsgBox("Please select a delivery person.", MsgBoxStyle.Exclamation, "No Delivery Person")
            Exit Sub
        End If

        Dim deliveryUserID As Integer = CInt(cmbDeliveryPerson.SelectedValue)

        Try
            ' --- Keep only orders that are still ready and not in another delivery ---
            Dim orderIDs As New List(Of Integer)
            For Each item As ListViewItem In lvreadyorders.SelectedItems
                Dim orderID As Integer = CInt(item.SubItems(0).Text)

                Dim currentStatus As Object = GetValue("SELECT status FROM tblorders WHERE orderid = @o", P("@o", orderID))
                If currentStatus Is Nothing Then
                    MsgBox("Order ID " & orderID & " not found.", MsgBoxStyle.Exclamation, "Missing Order")
                    Continue For
                End If

                If currentStatus.ToString() <> "Ready To Deliver" Then
                    MsgBox("Order ID " & orderID & " is not ready to deliver (current: " & currentStatus.ToString() & ").", MsgBoxStyle.Information, "Skipped")
                    Continue For
                End If

                ' Prevent duplicate linking
                If CInt(GetValue("SELECT COUNT(*) FROM tbldeliveryorders WHERE orderid = @o", P("@o", orderID))) > 0 Then
                    MsgBox("Order ID " & orderID & " is already assigned to another delivery.", MsgBoxStyle.Information, "Skipped")
                    Continue For
                End If

                orderIDs.Add(orderID)
            Next

            If orderIDs.Count = 0 Then
                MsgBox("No delivery was created because none of the selected orders can be assigned.", MsgBoxStyle.Information, "Nothing Assigned")
                FillReadyOrders()
                Exit Sub
            End If

            ' --- Create the delivery and link the orders in one transaction ---
            AssignDelivery(deliveryUserID, dtpDeliveryDate.Value, orderIDs)

            MsgBox("Delivery assigned successfully.", MsgBoxStyle.Information, "Success")

            ' --- Refresh UI ---
            FillReadyOrders()
            LoadDeliveries()

        Catch ex As Exception
            MsgBox("Failed to assign delivery: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub



    Public Sub LoadDeliveries(Optional ByVal keyword As String = "")
        lvDeliveries.Items.Clear()

        Try
            ' --- Build SQL to fetch deliveries and compute status dynamically ---
            Dim sql As String =
                "SELECT d.deliveryid, " &
                "CONCAT(u.fname, ' ', u.lname) AS deliveryperson, " &
                "d.deliverydate, " &
                "CASE " &
                "   WHEN COUNT(o.orderid) = 0 THEN 'No Orders' " &
                "   WHEN SUM(CASE WHEN o.status <> 'Completed' THEN 1 ELSE 0 END) = 0 THEN 'Delivered' " &
                "   WHEN SUM(CASE WHEN o.status = 'Out For Delivery' THEN 1 ELSE 0 END) > 0 THEN 'Out For Delivery' " &
                "   WHEN SUM(CASE WHEN o.status = 'Ready To Deliver' THEN 1 ELSE 0 END) > 0 THEN 'Pending' " &
                "   ELSE 'Unknown' " &
                "END AS deliverystatus, " &
                "GROUP_CONCAT(o.orderid SEPARATOR ', ') AS orders " &
                "FROM tbldelivery d " &
                "LEFT JOIN tblusers u ON d.userid = u.userid " &
                "LEFT JOIN tbldeliveryorders do ON d.deliveryid = do.deliveryid " &
                "LEFT JOIN tblorders o ON do.orderid = o.orderid " &
                "WHERE 1=1 " &
                If(keyword <> "", " AND (CONCAT(u.fname, ' ', u.lname) LIKE @k OR d.deliveryid LIKE @k)", "") &
                " GROUP BY d.deliveryid, u.fname, u.lname, d.deliverydate " &
                "ORDER BY d.deliverydate DESC"

            GetQuery(sql, "deliveries", P("@k", "%" & keyword & "%"))

            If ds.Tables("deliveries").Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables("deliveries").Rows
                    Dim item As ListViewItem = lvDeliveries.Items.Add(row("deliveryid").ToString())
                    item.SubItems.Add(row("deliveryperson").ToString())
                    item.SubItems.Add(Format(CDate(row("deliverydate")), "yyyy-MM-dd"))
                    item.SubItems.Add(row("deliverystatus").ToString()) ' computed status
                    item.SubItems.Add(If(IsDBNull(row("orders")), "", row("orders").ToString()))
                Next
            End If

        Catch ex As Exception
            MsgBox("Error loading deliveries: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        editdeliverie()
    End Sub

    Private Sub lvdeliveries_DoubleClick(sender As Object, e As EventArgs) Handles lvdeliveries.DoubleClick
        editdeliverie()
    End Sub

    Public Sub editdeliverie()
        If lvdeliveries.SelectedItems.Count = 0 Then
            MsgBox("Select a delivery to edit.", MsgBoxStyle.Exclamation, "No Selection")
            Exit Sub
        End If

        Dim selectedItem As ListViewItem = lvdeliveries.SelectedItems(0)
        Dim deliveryID As Integer = CInt(selectedItem.SubItems(0).Text)
        Dim deliveryPerson As String = selectedItem.SubItems(1).Text
        Dim deliveryDate As Date = CDate(selectedItem.SubItems(2).Text)
        Dim deliveryStatus As String = selectedItem.SubItems(3).Text.Trim()


        ' --- Proceed with edit ---
        With DlgEditDelivery
            .DeliveryID = deliveryID
            .DeliveryPerson = deliveryPerson
            .DeliveryDate = deliveryDate
            .DeliveryStatus = deliveryStatus
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                LoadDeliveries()
                FillReadyOrders()
            End If
        End With
    End Sub


    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If lvDeliveries.SelectedItems.Count = 0 Then
            MsgBox("Select a delivery to delete.", MsgBoxStyle.Exclamation, "No Selection")
            Exit Sub
        End If

        Dim selectedItem As ListViewItem = lvDeliveries.SelectedItems(0)
        Dim deliveryID As Integer = CInt(selectedItem.SubItems(0).Text)

        Dim confirm As DialogResult = MsgBox("Are you sure you want to delete Delivery #" & deliveryID & "?" & vbCrLf & _
                                            "Orders in this delivery that are still Out For Delivery will be set back to 'Ready To Deliver'.", _
                                            MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm Delete")
        If confirm = DialogResult.No Then Exit Sub

        Try
            ' Refused when any order in it is already Completed; cancelled or
            ' pending orders are not brought back.
            DeleteDelivery(deliveryID)

            MsgBox("Delivery #" & deliveryID & " deleted successfully. Orders have been reset.", MsgBoxStyle.Information, "Deleted")

            ' Refresh UI
            LoadDeliveries()
            FillReadyOrders()

        Catch ex As Exception
            MsgBox("Failed to delete delivery: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub txtsearchready_TextChanged(sender As Object, e As EventArgs) Handles txtsearchready.TextChanged
        FillReadyOrders(txtsearchready.Text)
    End Sub

    Private Sub txtsearchdeliveries_TextChanged(sender As Object, e As EventArgs) Handles txtsearchdeliveries.TextChanged
        LoadDeliveries(txtsearchdeliveries.Text)
    End Sub
End Class