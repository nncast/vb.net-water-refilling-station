Public Class DlgAddInventoryTransaction
    Private dtProducts As DataTable
    Private Sub DlgAddInventoryTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' The designer default maximum of 100 blocked larger deliveries of stock.
        nudqty.Maximum = 1000000

        loadProducts()
        loadTransTypes()
        clear()
    End Sub

    '----------------------------------------
    ' Load combo data
    '----------------------------------------
    Private Sub LoadProducts()
        ' Use GetQuery but immediately copy to a standalone DataTable
        GetQuery("SELECT productid, name FROM tblproducts ORDER BY name", "tblproducts")

        If ds.Tables("tblproducts").Rows.Count > 0 Then
            ' Copy results to a local DataTable so it’s not affected later
            dtProducts = ds.Tables("tblproducts").Copy()

            cmbproduct.DataSource = dtProducts
            cmbproduct.DisplayMember = "name"
            cmbproduct.ValueMember = "productid"
            cmbproduct.DropDownStyle = ComboBoxStyle.DropDownList
            cmbproduct.SelectedIndex = -1
        End If
    End Sub

    Private Sub loadTransTypes()
        cmbtranstype.Items.Clear()
        cmbtranstype.Items.Add("Stock In")
        cmbtranstype.Items.Add("Stock Out")
        cmbtranstype.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    '----------------------------------------
    ' Save button
    '----------------------------------------
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        ' --- Validation ---
        If Not ValidateFields() Then Exit Sub

        Dim productid As Integer = cmbproduct.SelectedValue
        Dim transtype As String = cmbtranstype.Text
        Dim qty As Integer = CInt(nudqty.Value)
        Dim remarks As String = txtremarks.Text.Trim()

        ' --- Check product status and stock ---
        GetQuery("SELECT stockqty, status FROM tblproducts WHERE productid = @p", "tblproducts", P("@p", productid))

        If ds.Tables("tblproducts").Rows.Count = 0 Then
            MsgBox("Product not found.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim currentStock As Integer = CInt(ds.Tables("tblproducts").Rows(0)("stockqty"))
        Dim status As String = ds.Tables("tblproducts").Rows(0)("status").ToString()

        If status <> "Active" Then
            MsgBox("This product is inactive and cannot be transacted.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If transtype = "Stock Out" AndAlso qty > currentStock Then
            MsgBox("Insufficient stock. Available quantity: " & currentStock, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If IsOrderTransaction(remarks) Then
            MsgBox("Remarks like """ & remarks & """ are reserved for stock moved by orders. Please describe this transaction differently.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' --- Confirm save ---
        If MsgBox("Save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            BeginTransaction()

            ' Re-check the stock inside the transaction in case it changed meanwhile.
            Dim stock As Integer = CInt(GetValue("SELECT stockqty FROM tblproducts WHERE productid = @p FOR UPDATE", P("@p", productid)))
            If transtype = "Stock Out" AndAlso qty > stock Then
                Throw New ApplicationException("Insufficient stock. Available quantity: " & stock)
            End If

            ' --- Insert transaction ---
            Execute("INSERT INTO tblinventorytransactions (productid, userid, transtype, qty, remarks) VALUES (@p, @u, @t, @q, @r)",
                    P("@p", productid), P("@u", Globals.UserID), P("@t", transtype), P("@q", qty), P("@r", remarks))

            ' --- Update stock quantity ---
            If transtype = "Stock In" Then
                Execute("UPDATE tblproducts SET stockqty = stockqty + @q WHERE productid = @p", P("@q", qty), P("@p", productid))
            Else
                Execute("UPDATE tblproducts SET stockqty = stockqty - @q WHERE productid = @p", P("@q", qty), P("@p", productid))
            End If

            LogActivity("Inventory", transtype & " - " & qty & " units", productid)
            CommitTransaction()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Could not save the transaction: " & ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        MsgBox("Transaction recorded successfully.", MsgBoxStyle.Information)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub


    '----------------------------------------
    ' Cancel button
    '----------------------------------------
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If MsgBox("Cancel adding this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidateFields() As Boolean
        If cmbproduct.SelectedIndex = -1 Then
            MsgBox("Please select a product.", MsgBoxStyle.Exclamation)
            cmbproduct.Focus()
            Return False
        End If

        If cmbtranstype.SelectedIndex = -1 Then
            MsgBox("Please select a transaction type.", MsgBoxStyle.Exclamation)
            cmbtranstype.Focus()
            Return False
        End If

        If nudqty.Value <= 0 Then
            MsgBox("Quantity must be greater than zero.", MsgBoxStyle.Exclamation)
            nudqty.Focus()
            Return False
        End If

        Return True
    End Function

    Public Sub clear()
        cmbproduct.SelectedIndex = -1
        cmbtranstype.SelectedIndex = -1
        cmbtranstype.Text = ""
        nudqty.Value = nudqty.Minimum
        txtremarks.Clear()
    End Sub
End Class
