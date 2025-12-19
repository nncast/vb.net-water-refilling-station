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
        Dim sql As String = "SELECT * FROM tblproducts WHERE productid = " & SelectedProductID
        GetQuery(sql, "tblproducts")

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
        nudreorderlevel.Value = CInt(row("reorderlevel"))
        cmbstatus.Text = row("status").ToString()
    End Sub

    ' ---------------- UPDATE PRODUCT ----------------
    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim sql As String =
            "UPDATE tblproducts SET " &
            "name = '" & txtproductname.Text.Replace("'", "''") & "', " &
            "categoryid = " & cmbcategory.SelectedValue & ", " &
            "unitprice = " & Val(txtprice.Text) & ", " &
            "unitid = " & cmbunit.SelectedValue & ", " &
            "reorderlevel = " & nudreorderlevel.Value & ", " &
            "status = '" & cmbstatus.Text & "' " &
            "WHERE productid = " & SelectedProductID

        SetQuery(sql)
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
