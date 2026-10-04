Public Class DlgEditInventoryTransaction
    Public Property TransactionId As Integer
    Private dtProducts As New DataTable()

    Private Sub DlgEditInventoryTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' The designer default maximum of 100 cut larger quantities down when loading.
        nudqty.Maximum = 1000000

        LoadTransType()
        LoadProducts()
        LoadTransactionData()
    End Sub

    ' ---------------- LOAD PRODUCTS ----------------
    Private Sub LoadProducts()
        ' Active products, plus this transaction's own product even if it is inactive now.
        GetQuery("SELECT productid, name FROM tblproducts WHERE status = 'Active' " &
                 "OR productid = (SELECT productid FROM tblinventorytransactions WHERE transid = @t) ORDER BY name", "tblproducts", P("@t", TransactionId))
        dtProducts = ds.Tables("tblproducts").Copy()

        cmbproduct.DataSource = dtProducts
        cmbproduct.DisplayMember = "name"
        cmbproduct.ValueMember = "productid"
        cmbproduct.DropDownStyle = ComboBoxStyle.DropDownList
        cmbproduct.SelectedIndex = -1
    End Sub

    ' ---------------- LOAD TRANSACTION TYPES ----------------
    Private Sub LoadTransType()
        cmbtranstype.DropDownStyle = ComboBoxStyle.DropDownList
        cmbtranstype.Items.Clear()
        cmbtranstype.Items.Add("Stock In")
        cmbtranstype.Items.Add("Stock Out")
        cmbtranstype.SelectedIndex = -1
    End Sub

    ' ---------------- LOAD EXISTING TRANSACTION ----------------
    Private Sub LoadTransactionData()
        If TransactionId <= 0 Then Exit Sub

        GetQuery("SELECT productid, transtype, qty, transdate, remarks FROM tblinventorytransactions WHERE transid = @t", "tbltransaction", P("@t", TransactionId))

        If ds.Tables("tbltransaction").Rows.Count = 0 Then
            MsgBox("Transaction not found.", MsgBoxStyle.Critical)
            Me.Close()
            Exit Sub
        End If

        Dim row As DataRow = ds.Tables("tbltransaction").Rows(0)
        Dim productId As Integer = CInt(row("productid"))
        Dim transtype As String = row("transtype").ToString()
        Dim qty As Integer = CInt(row("qty"))
        Dim transdate As Date = CDate(row("transdate"))
        Dim remarks As String = row("remarks").ToString()

        ' --- Ensure comboboxes are populated before setting values ---
        BeginInvoke(Sub()
                        ' Product
                        If cmbproduct.DataSource IsNot Nothing AndAlso dtProducts.Rows.Count > 0 Then
                            cmbproduct.SelectedValue = productId
                        End If

                        ' Transaction type
                        cmbtranstype.SelectedItem = transtype

                        ' Quantity (safe range)
                        If qty < nudqty.Minimum Then
                            nudqty.Value = nudqty.Minimum
                        ElseIf qty > nudqty.Maximum Then
                            nudqty.Value = nudqty.Maximum
                        Else
                            nudqty.Value = qty
                        End If

                        dtptransdate.Value = transdate
                        txtremarks.Text = remarks
                    End Sub)
    End Sub

    ' ---------------- UPDATE TRANSACTION ----------------
    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If cmbproduct.SelectedIndex = -1 OrElse cmbtranstype.SelectedIndex = -1 Then
            MsgBox("Please fill all required fields.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If nudqty.Value <= 0 Then
            MsgBox("Quantity must be greater than zero.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim newProductId As Integer = CInt(cmbproduct.SelectedValue)
        Dim newType As String = cmbtranstype.Text
        Dim newQty As Integer = CInt(nudqty.Value)
        Dim remarks As String = txtremarks.Text.Trim()

        If IsOrderTransaction(remarks) Then
            MsgBox("Remarks like """ & remarks & """ are reserved for stock moved by orders. Please describe this transaction differently.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            BeginTransaction()

            ' --- Get previous transaction details ---
            GetQuery("SELECT productid, transtype, qty, remarks FROM tblinventorytransactions WHERE transid = @t FOR UPDATE", "tblprevtrans", P("@t", TransactionId))
            If ds.Tables("tblprevtrans").Rows.Count = 0 Then Throw New ApplicationException("Previous transaction not found.")

            Dim oldProductId As Integer = CInt(ds.Tables("tblprevtrans").Rows(0)("productid"))
            Dim oldType As String = ds.Tables("tblprevtrans").Rows(0)("transtype").ToString()
            Dim oldQty As Integer = CInt(ds.Tables("tblprevtrans").Rows(0)("qty"))

            If IsOrderTransaction(ds.Tables("tblprevtrans").Rows(0)("remarks").ToString()) Then
                Throw New ApplicationException("This stock movement was made by an order. Change or cancel the order instead.")
            End If

            ' --- Undo the old stock effect, apply the new one, never below zero ---
            Dim undo As Integer = If(oldType = "Stock In", -oldQty, oldQty)
            Dim redo As Integer = If(newType = "Stock In", newQty, -newQty)
            If oldProductId = newProductId Then
                AdjustStock(newProductId, undo + redo)
            Else
                AdjustStock(oldProductId, undo)
                AdjustStock(newProductId, redo)
            End If

            ' --- Update transaction record ---
            Execute("UPDATE tblinventorytransactions SET productid = @p, transtype = @t, qty = @q, transdate = @d, remarks = @r WHERE transid = @id",
                    P("@p", newProductId), P("@t", newType), P("@q", newQty), P("@d", dtptransdate.Value), P("@r", remarks), P("@id", TransactionId))
            LogActivity("Inventory", "Updated Transaction", TransactionId)
            CommitTransaction()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Could not update the transaction: " & ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        MsgBox("Transaction updated successfully.", MsgBoxStyle.Information)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' Adds change to a product's stock inside the open transaction; refuses to go below zero.
    Private Sub AdjustStock(productId As Integer, change As Integer)
        GetQuery("SELECT name, stockqty FROM tblproducts WHERE productid = @p FOR UPDATE", "tblstockcheck", P("@p", productId))
        If ds.Tables("tblstockcheck").Rows.Count = 0 Then Throw New ApplicationException("Product not found.")

        Dim stock As Integer = CInt(ds.Tables("tblstockcheck").Rows(0)("stockqty"))
        If stock + change < 0 Then
            Throw New ApplicationException("Not enough stock for " & ds.Tables("tblstockcheck").Rows(0)("name").ToString() &
                                           " (has " & stock & ", this change needs " & -change & ").")
        End If

        Execute("UPDATE tblproducts SET stockqty = stockqty + @c WHERE productid = @p", P("@c", change), P("@p", productId))
    End Sub


    ' ---------------- CANCEL ----------------
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If MsgBox("Cancel editing this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

End Class
