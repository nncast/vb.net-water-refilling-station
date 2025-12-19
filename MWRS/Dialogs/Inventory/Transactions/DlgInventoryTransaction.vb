Public Class DlgInventoryTransaction
    Private Sub DlgInventoryTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill()
    End Sub

    Public Sub fill(Optional ByVal keyword As String = "")
        lvtransactions.Items.Clear()

        Dim sql As String =
            "SELECT t.transid, p.name AS product_name, " &
            "CONCAT(u.fname, ' ', u.lname) AS user_name, " &
            "t.transtype, t.qty, t.transdate, t.remarks " &
            "FROM tblinventorytransactions t " &
            "INNER JOIN tblproducts p ON t.productid = p.productid " &
            "INNER JOIN tblusers u ON t.userid = u.userid"

        If keyword <> "" Then
            sql &= " WHERE p.name LIKE '%" & keyword.Replace("'", "''") & "%' " &
                   "OR CONCAT(u.fname, ' ', u.lname) LIKE '%" & keyword.Replace("'", "''") & "%' " &
                   "OR t.transtype LIKE '%" & keyword.Replace("'", "''") & "%' " &
                   "OR t.remarks LIKE '%" & keyword.Replace("'", "''") & "%'"
        End If

        sql &= " ORDER BY t.transdate DESC, t.transid DESC"

        ds.Tables.Clear()
        GetQuery(sql, "tblinventorytransactions")

        If ds.Tables("tblinventorytransactions").Rows.Count = 0 Then Exit Sub

        For Each row As DataRow In ds.Tables("tblinventorytransactions").Rows
            Dim item As New ListViewItem(row("transid").ToString())
            item.SubItems.Add(row("product_name").ToString())
            item.SubItems.Add(row("user_name").ToString())
            item.SubItems.Add(row("transtype").ToString())
            item.SubItems.Add(row("qty").ToString())
            item.SubItems.Add(Format(CDate(row("transdate")), "yyyy-MM-dd HH:mm:ss"))
            item.SubItems.Add(row("remarks").ToString())
            lvtransactions.Items.Add(item)
        Next
    End Sub


    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill(txtsearch.Text)
    End Sub

    Private Sub btnaddtransaction_Click(sender As Object, e As EventArgs) Handles btnaddtransaction.Click
        If DlgAddInventoryTransaction.ShowDialog() = DialogResult.OK Then
            ' Assuming A_Inventory is a reference to the main inventory form/module
            A4_Inventory.fill()
            fill()
        End If
    End Sub

    Private Sub EditSelectedTransaction()
        If lvtransactions.SelectedItems.Count = 0 Then
            MsgBox("Select a transaction first.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim transId As Integer = CInt(lvtransactions.SelectedItems(0).Text)

        Dim dlg As New DlgEditInventoryTransaction()
        dlg.TransactionId = transId

        If dlg.ShowDialog() = DialogResult.OK Then
            ' Assuming A_Inventory is a reference to the main inventory form/module
            A4_Inventory.fill()
            fill()
        End If
    End Sub

    Private Sub btnedittransaction_Click(sender As Object, e As EventArgs) Handles btnedittransaction.Click
        EditSelectedTransaction() ' Call the shared logic
    End Sub

    Private Sub lvtransactions_DoubleClick(sender As Object, e As EventArgs) Handles lvtransactions.DoubleClick
        EditSelectedTransaction()
    End Sub

    Private Sub btndeletetransaction_Click(sender As Object, e As EventArgs) Handles btndeletetransaction.Click
        If lvtransactions.SelectedItems.Count = 0 Then
            MsgBox("Select a transaction to delete.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim transId As Integer = CInt(lvtransactions.SelectedItems(0).Text)

        If MsgBox("Are you sure you want to delete this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            ' Optional: Capture details before deletion for logging
            If ds.Tables.Contains("tbltransdel") Then ds.Tables("tbltransdel").Clear()
            GetQuery("SELECT productid, transtype, qty FROM tblinventorytransactions WHERE transid = " & transId, "tbltransdel")

            Dim productId As Integer = 0
            Dim transtype As String = ""
            Dim qty As Integer = 0

            If ds.Tables("tbltransdel").Rows.Count > 0 Then
                productId = CInt(ds.Tables("tbltransdel").Rows(0)("productid"))
                transtype = ds.Tables("tbltransdel").Rows(0)("transtype").ToString()
                qty = CInt(ds.Tables("tbltransdel").Rows(0)("qty"))
            End If

            If transtype = "Stock In" Then
                ' Remove the stock added
                SetQuery("UPDATE tblproducts SET stockqty = stockqty - " & qty & " WHERE productid = " & productId)
            ElseIf transtype = "Stock Out" Then
                ' Restore the stock removed
                SetQuery("UPDATE tblproducts SET stockqty = stockqty + " & qty & " WHERE productid = " & productId)
            End If


            ' Delete the transaction
            Dim sql As String = "DELETE FROM tblinventorytransactions WHERE transid = " & transId
            SetQuery(sql)

            ' --- Log deletion ---
            LogActivity("Inventory", "Deleted transaction ID " & transId & _
                        " - " & transtype & " of " & qty & " units for product ID " & productId, transId)

            ' Refresh
            A4_Inventory.fill()
            fill()
        End If
    End Sub

End Class