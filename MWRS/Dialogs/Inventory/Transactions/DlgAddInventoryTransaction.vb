Public Class DlgAddInventoryTransaction
    Private dtProducts As DataTable
    Private Sub DlgAddInventoryTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim userid As Integer = Globals.UserID

        ' --- Check product status and stock ---
        GetQuery("SELECT stockqty, status FROM tblproducts WHERE productid = " & productid, "tblproducts")

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

        ' --- Confirm save ---
        If MsgBox("Save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        ' --- Insert transaction ---
        Dim sqlInsert As String =
            "INSERT INTO tblinventorytransactions (productid, userid, transtype, qty, remarks) VALUES (" &
            productid & ", " & userid & ", '" & transtype.Replace("'", "''") & "', " &
            qty & ", '" & remarks.Replace("'", "''") & "')"

        SetQuery(sqlInsert)

        ' --- Update stock quantity ---
        Dim sqlUpdate As String
        If transtype = "Stock In" Then
            sqlUpdate = "UPDATE tblproducts SET stockqty = stockqty + " & qty & " WHERE productid = " & productid
        Else
            sqlUpdate = "UPDATE tblproducts SET stockqty = stockqty - " & qty & " WHERE productid = " & productid
        End If

        SetQuery(sqlUpdate)
        LogActivity("Inventory", transtype & " - " & qty & " units", productid)
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
        nudqty.Value = 0
        txtremarks.Clear()
    End Sub
End Class
