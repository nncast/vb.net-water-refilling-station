Public Class DlgEditProduct
    Dim dtCategories As New DataTable()
    Dim dtUnits As New DataTable()
    Dim dtStatus As New DataTable()
    Public Property SelectedProductID As Integer

    Private Sub DlgEditProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        LoadUnits()
        LoadStatus()
        LoadProductData()
    End Sub

    ' ---------------- LOAD UNITS ----------------
    Private Sub LoadUnits()
        dtUnits.Clear()

        GetQuery("SELECT unitid, unittype FROM tblproductunit ORDER BY unittype", "tblunits")
        dtUnits = ds.Tables("tblunits").Copy()

        cmbunit.DataSource = dtUnits
        cmbunit.DisplayMember = "unittype"
        cmbunit.ValueMember = "unitid"
        cmbunit.SelectedIndex = -1
        cmbunit.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' ---------------- LOAD CATEGORIES ----------------
    Private Sub LoadCategories()
        dtCategories.Clear()

        GetQuery("SELECT categoryid, name FROM tblproductcategories ORDER BY name", "tblcategories")
        dtCategories = ds.Tables("tblcategories").Copy()

        cmbcategory.DataSource = dtCategories
        cmbcategory.DisplayMember = "name"
        cmbcategory.ValueMember = "categoryid"
        cmbcategory.SelectedIndex = -1
    End Sub

    ' ---------------- LOAD STATUS ----------------
    Private Sub LoadStatus()
        dtStatus.Clear()

        If dtStatus.Columns.Count = 0 Then
            dtStatus.Columns.Add("status")
        End If

        dtStatus.Rows.Add("Active")
        dtStatus.Rows.Add("Inactive")

        cmbstatus.DataSource = Nothing
        cmbstatus.DataSource = dtStatus
        cmbstatus.DisplayMember = "status"
        cmbstatus.ValueMember = "status"
        cmbstatus.SelectedIndex = -1
    End Sub

    ' ---------------- LOAD EXISTING PRODUCT ----------------
    Private Sub LoadProductData()
        GetQuery("SELECT * FROM tblproducts WHERE productid = @p", "tblproducts", P("@p", SelectedProductID))

        If ds.Tables("tblproducts").Rows.Count = 0 Then
            MsgBox("Product record not found.", MsgBoxStyle.Critical, "Error")
            Me.Close()
            Exit Sub
        End If

        Dim row As DataRow = ds.Tables("tblproducts").Rows(0)
        txtproductname.Text = row("name").ToString()
        cmbcategory.SelectedValue = row("categoryid")
        txtprice.Text = Format(CDec(row("unitprice")), "0.00")
        cmbunit.SelectedValue = row("unitid") ' uses database ID instead of text

        ' Products saved elsewhere may have a reorder level outside this box's range
        ' (the database default is 0); setting it as-is would throw.
        Dim reorder As Decimal = CDec(row("reorderlevel"))
        nudreorderlevel.Value = Math.Min(Math.Max(reorder, nudreorderlevel.Minimum), nudreorderlevel.Maximum)
        cmbstatus.Text = row("status").ToString()
    End Sub

    ' ---------------- UPDATE PRODUCT ----------------
    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim name As String = txtproductname.Text.Trim()
        If name = "" Then
            MsgBox("Product name is required.", MsgBoxStyle.Exclamation)
            txtproductname.Focus()
            Exit Sub
        End If

        If name.Length > 100 Then
            MsgBox("Product name can be at most 100 characters.", MsgBoxStyle.Exclamation)
            txtproductname.Focus()
            Exit Sub
        End If

        If cmbcategory.SelectedIndex = -1 OrElse cmbunit.SelectedIndex = -1 OrElse cmbstatus.SelectedIndex = -1 Then
            MsgBox("Please select a category, unit and status.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Val() read "1,200.00" as 1; TryParse reads the whole amount or rejects it.
        Dim price As Decimal
        If Not Decimal.TryParse(txtprice.Text.Trim(), price) OrElse price < 0 Then
            MsgBox("Enter a valid price.", MsgBoxStyle.Exclamation)
            txtprice.Focus()
            Exit Sub
        End If

        If CInt(GetValue("SELECT COUNT(*) FROM tblproducts WHERE name = @n AND productid <> @p", P("@n", name), P("@p", SelectedProductID))) > 0 Then
            MsgBox("Another product already has this name.", MsgBoxStyle.Exclamation)
            txtproductname.Focus()
            Exit Sub
        End If

        Dim sql As String =
            "UPDATE tblproducts SET name = @n, categoryid = @c, unitprice = @price, unitid = @u, reorderlevel = @r, status = @s " &
            "WHERE productid = @p"

        If Not SetQuery(sql, P("@n", name), P("@c", cmbcategory.SelectedValue), P("@price", price), P("@u", cmbunit.SelectedValue),
                        P("@r", CInt(nudreorderlevel.Value)), P("@s", cmbstatus.Text), P("@p", SelectedProductID)) Then Exit Sub

        LogActivity("Products", "Update product", SelectedProductID)
        MsgBox("Product updated successfully.", MsgBoxStyle.Information, "Update Successful")
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' ---------------- CANCEL ----------------
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
