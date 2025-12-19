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
    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(txtproductname.Text) Then
            MsgBox("Product name is required.", MsgBoxStyle.Exclamation)
            txtproductname.Focus()
            Return False
        End If

        If cmbcategory.SelectedIndex = -1 Then
            MsgBox("Please select a category.", MsgBoxStyle.Exclamation)
            cmbcategory.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtprice.Text) OrElse Not IsNumeric(txtprice.Text) Then
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

        Return True
    End Function

    ' ==========================================================
    ' Button: Save
    ' ==========================================================
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If Not ValidateFields() Then Exit Sub

        Dim sql As String =
            "INSERT INTO tblproducts (name, categoryid, unitprice, unitid, reorderlevel, status) VALUES (" &
            "'" & txtproductname.Text.Replace("'", "''") & "', " &
            cmbcategory.SelectedValue & ", " &
            txtprice.Text.Replace("'", "''") & ", " &
            cmbunit.SelectedValue & ", " &
            nudreorderlevel.Value & ", " &
            "'" & cmbstatus.Text.Replace("'", "''") & "')"

        SetQuery(sql)
        MsgBox("Product added successfully.", MsgBoxStyle.Information)

        ' Get last inserted ID
        Dim dt As DataTable = GetDataTable("SELECT LAST_INSERT_ID() AS lastid")
        Dim newProductId As Integer = CInt(dt.Rows(0)("lastid"))

        LogActivity("Products", "Added new product: " & txtproductname.Text, newProductId)

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
