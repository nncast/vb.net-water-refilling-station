Public Class DlgAddCategories
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim categoryName As String = txtcategoryname.Text.Trim()

        If categoryName = "" Then
            MsgBox("Please enter a category name.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Check if category already exists
        Dim checkSql As String = "SELECT * FROM tblproductcategories WHERE name = '" & categoryName.Replace("'", "''") & "'"
        GetQuery(checkSql, "checkCat")

        If ds.Tables("checkCat").Rows.Count > 0 Then
            MsgBox("Category name already exists.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Insert new category
        Dim sql As String = "INSERT INTO tblproductcategories (name) VALUES ('" & categoryName.Replace("'", "''") & "')"
        SetQuery(sql)
        MsgBox("Category added successfully.", MsgBoxStyle.Information)

        Dim getIdSql As String = "SELECT LAST_INSERT_ID() AS lastid"
        GetQuery(getIdSql, "newCat")
        Dim newCatID As Integer = 0
        If ds.Tables("newCat").Rows.Count > 0 Then
            newCatID = CInt(ds.Tables("newCat").Rows(0)("lastid"))
        End If
        LogActivity("Categories", "Add Category", newCatID)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        If MsgBox("Discard changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub
End Class
