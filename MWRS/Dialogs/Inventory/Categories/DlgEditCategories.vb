Public Class DlgEditCategories
    Public Property SelectedCategoryID As Integer

    Private Sub DlgEditCategories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetQuery("SELECT * FROM tblproductcategories WHERE categoryid = @c", "tblproductcategories", P("@c", SelectedCategoryID))

        If ds.Tables("tblproductcategories").Rows.Count > 0 Then
            txtcategoryname.Text = ds.Tables("tblproductcategories").Rows(0)("name").ToString()
        End If
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim newName As String = txtcategoryname.Text.Trim()
        If newName = "" Then
            MsgBox("Please enter a category name.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If newName.Length > 50 Then
            MsgBox("Category name can be at most 50 characters.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Check if new name already exists (except for current one)
        If CInt(GetValue("SELECT COUNT(*) FROM tblproductcategories WHERE name = @n AND categoryid <> @c", P("@n", newName), P("@c", SelectedCategoryID))) > 0 Then
            MsgBox("Category name already exists.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not SetQuery("UPDATE tblproductcategories SET name = @n WHERE categoryid = @c", P("@n", newName), P("@c", SelectedCategoryID)) Then Exit Sub
        MsgBox("Category updated successfully.", MsgBoxStyle.Information)

        LogActivity("Categories", "Update Category", SelectedCategoryID)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If MsgBox("Discard changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub
End Class
