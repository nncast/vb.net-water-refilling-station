Public Class DlgAddCategories
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim categoryName As String = txtcategoryname.Text.Trim()

        If categoryName = "" Then
            MsgBox("Please enter a category name.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If categoryName.Length > 50 Then
            MsgBox("Category name can be at most 50 characters.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Check if category already exists
        If CInt(GetValue("SELECT COUNT(*) FROM tblproductcategories WHERE name = @n", P("@n", categoryName))) > 0 Then
            MsgBox("Category name already exists.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Insert new category
        If Not SetQuery("INSERT INTO tblproductcategories (name) VALUES (@n)", P("@n", categoryName)) Then Exit Sub

        LogActivity("Categories", "Add Category", GetLastInsertedID())
        MsgBox("Category added successfully.", MsgBoxStyle.Information)

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
