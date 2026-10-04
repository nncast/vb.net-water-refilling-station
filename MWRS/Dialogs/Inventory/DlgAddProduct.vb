Public Class DlgAddProduct

    Private Sub DlgAddProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllCombos()
        Clear()
    End Sub

    Private Sub LoadAllCombos()
        LoadCategories()
        LoadUnits()
        LoadStatusOptions()
    End Sub

    ' ==========================================================
    ' Load Product Categories
    ' ==========================================================
    Private Sub LoadCategories()
        Dim dtCategories As DataTable = GetDataTable("SELECT categoryid, name FROM tblproductcategories ORDER BY name")
        cmbcategory.DataSource = dtCategories
        cmbcategory.DisplayMember = "name"
        cmbcategory.ValueMember = "categoryid"
        cmbcategory.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' ==========================================================
    ' Load Units
    ' ==========================================================
    Private Sub LoadUnits()
        Dim dtUnits As DataTable = GetDataTable("SELECT unitid, unittype FROM tblproductunit ORDER BY unittype")
        cmbunit.DataSource = dtUnits
        cmbunit.DisplayMember = "unittype"
        cmbunit.ValueMember = "unitid"
        cmbunit.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' ==========================================================
    ' Load Status Options (static)
    ' ==========================================================
    Private Sub LoadStatusOptions()
        cmbstatus.Items.Clear()
        cmbstatus.Items.AddRange(New String() {"Active", "Inactive"})
        cmbstatus.SelectedIndex = 0
        cmbstatus.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' ==========================================================
    ' Validation
    ' ==========================================================
    Private Function ValidateFields(ByRef price As Decimal) As Boolean
        If String.IsNullOrWhiteSpace(txtproductname.Text) Then
            MsgBox("Product name is required.", MsgBoxStyle.Exclamation)
            txtproductname.Focus()
            Return False
        End If

        If txtproductname.Text.Trim().Length > 100 Then
            MsgBox("Product name can be at most 100 characters.", MsgBoxStyle.Exclamation)
            txtproductname.Focus()
            Return False
        End If

        If cmbcategory.SelectedIndex = -1 Then
            MsgBox("Please select a category.", MsgBoxStyle.Exclamation)
            cmbcategory.Focus()
            Return False
        End If

        ' Accepts "1200", "1200.50" or "1,200.50"; the value is sent as a number, not as text.
        If Not Decimal.TryParse(txtprice.Text.Trim(), price) OrElse price < 0 Then
            MsgBox("Enter a valid price.", MsgBoxStyle.Exclamation)
            txtprice.Focus()
            Return False
        End If

        If cmbunit.SelectedIndex = -1 Then
            MsgBox("Please select a unit.", MsgBoxStyle.Exclamation)
            cmbunit.Focus()
            Return False
        End If

        If cmbstatus.SelectedIndex = -1 Then
            MsgBox("Please select product status.", MsgBoxStyle.Exclamation)
            cmbstatus.Focus()
            Return False
        End If

        If CInt(GetValue("SELECT COUNT(*) FROM tblproducts WHERE name = @n", P("@n", txtproductname.Text.Trim()))) > 0 Then
            MsgBox("A product with this name already exists.", MsgBoxStyle.Exclamation)
            txtproductname.Focus()
            Return False
        End If

        Return True
    End Function

    ' ==========================================================
    ' Button: Save
    ' ==========================================================
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim price As Decimal
        If Not ValidateFields(price) Then Exit Sub

        Dim sql As String =
            "INSERT INTO tblproducts (name, categoryid, unitprice, unitid, reorderlevel, status) " &
            "VALUES (@n, @c, @price, @u, @r, @s)"

        If Not SetQuery(sql, P("@n", txtproductname.Text.Trim()), P("@c", cmbcategory.SelectedValue), P("@price", price),
                        P("@u", cmbunit.SelectedValue), P("@r", CInt(nudreorderlevel.Value)), P("@s", cmbstatus.Text)) Then Exit Sub

        Dim newProductId As Integer = GetLastInsertedID()
        LogActivity("Products", "Added new product: " & txtproductname.Text.Trim(), newProductId)
        MsgBox("Product added successfully.", MsgBoxStyle.Information)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If MsgBox("Cancel adding product?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    ' ==========================================================
    ' Helper: Get DataTable
    ' ==========================================================
    Private Function GetDataTable(sql As String) As DataTable
        GetQuery(sql, "temp")
        Return ds.Tables("temp").Copy()
    End Function

    Private Sub Clear()
        txtproductname.Clear()
        cmbcategory.SelectedIndex = -1
        txtprice.Clear()
        cmbunit.SelectedIndex = -1
        nudreorderlevel.Value = nudreorderlevel.Minimum
        cmbstatus.SelectedIndex = -1
    End Sub
End Class
