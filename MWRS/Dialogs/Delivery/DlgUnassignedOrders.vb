Public Class DlgUnassignedOrders
    Public Property SelectedOrderIDs As New List(Of Integer)

    Private Sub DlgUnassignedOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillReadyOrders()
    End Sub

    Public Sub FillReadyOrders(Optional ByVal keyword As String = "")
        lvreadyorders.Items.Clear()

        Dim sql As String =
            "SELECT o.orderid, " &
            "c.fullname, " &
            "CONCAT(b.barangayname, ' - ', p.purokname) AS fulladdress, " &
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
            If(keyword <> "",
                " AND (c.fullname LIKE '%" & keyword & "%' OR o.orderid LIKE '%" & keyword & "%')",
                "") &
            " GROUP BY o.orderid, c.fullname, fulladdress, cb.balance, o.orderdate " &
            " ORDER BY o.orderdate ASC"


        GetQuery(sql, "readyorders")

        If ds.Tables("readyorders").Rows.Count > 0 Then
            For Each row As DataRow In ds.Tables("readyorders").Rows
                Dim item As ListViewItem = lvreadyorders.Items.Add(row("orderid").ToString())
                item.SubItems.Add(row("fullname").ToString())
                item.SubItems.Add(row("fulladdress").ToString())
                item.SubItems.Add(Format(CDate(row("orderdate")), "yyyy-MM-dd"))
                item.SubItems.Add(Format(CDec(row("totalamount")), "0.00"))
                item.SubItems.Add(Format(CDec(row("balance")), "0.00"))

            Next
        End If
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        SelectedOrderIDs.Clear()

        If lvreadyorders.SelectedItems.Count = 0 Then
            MsgBox("Please select at least one order.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        For Each item As ListViewItem In lvreadyorders.SelectedItems
            SelectedOrderIDs.Add(CInt(item.SubItems(0).Text))
        Next

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
