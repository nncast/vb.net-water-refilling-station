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
            sql &= " WHERE p.name LIKE @k OR CONCAT(u.fname, ' ', u.lname) LIKE @k OR t.transtype LIKE @k OR t.remarks LIKE @k"
        End If

        sql &= " ORDER BY t.transdate DESC, t.transid DESC"

        GetQuery(sql, "tblinventorytransactions", P("@k", "%" & keyword & "%"))

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

        If IsOrderTransaction(lvtransactions.SelectedItems(0).SubItems(6).Text) Then
            MsgBox("This stock movement was made by an order. Change or cancel the order instead.", MsgBoxStyle.Exclamation, "Order Transaction")
            Exit Sub
        End If

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
            Try
                BeginTransaction()

                GetQuery("SELECT t.productid, t.transtype, t.qty, t.remarks, p.stockqty FROM tblinventorytransactions t " &
                         "JOIN tblproducts p ON p.productid = t.productid WHERE t.transid = @t FOR UPDATE", "tbltransdel", P("@t", transId))
                If ds.Tables("tbltransdel").Rows.Count = 0 Then Throw New ApplicationException("Transaction not found.")

                Dim row As DataRow = ds.Tables("tbltransdel").Rows(0)
                Dim productId As Integer = CInt(row("productid"))
                Dim transtype As String = row("transtype").ToString()
                Dim qty As Integer = CInt(row("qty"))

                If IsOrderTransaction(row("remarks").ToString()) Then
                    Throw New ApplicationException("This stock movement was made by an order. Change or cancel the order instead.")
                End If

                ' Deleting a stock-in takes its quantity back out of stock.
                If transtype = "Stock In" AndAlso CInt(row("stockqty")) < qty Then
                    Throw New ApplicationException("Only " & row("stockqty").ToString() & " of these " & qty & " units are still in stock, so this stock-in can't be deleted.")
                End If

                If transtype = "Stock In" Then
                    ' Remove the stock added
                    Execute("UPDATE tblproducts SET stockqty = stockqty - @q WHERE productid = @p", P("@q", qty), P("@p", productId))
                ElseIf transtype = "Stock Out" Then
                    ' Restore the stock removed
                    Execute("UPDATE tblproducts SET stockqty = stockqty + @q WHERE productid = @p", P("@q", qty), P("@p", productId))
                End If

                ' Delete the transaction
                Execute("DELETE FROM tblinventorytransactions WHERE transid = @t", P("@t", transId))

                ' --- Log deletion ---
                LogActivity("Inventory", "Deleted " & transtype & " of " & qty, transId)
                CommitTransaction()
            Catch ex As Exception
                RollbackTransaction()
                MsgBox("Could not delete the transaction: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try

            ' Refresh
            A4_Inventory.fill()
            fill()
        End If
    End Sub

End Class
