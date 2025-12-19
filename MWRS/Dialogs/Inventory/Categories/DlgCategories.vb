Public Class DlgCategories

    Private Sub DlgCategories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill()
    End Sub

    Public Sub fill(Optional ByVal keyword As String = "")
        lvcategories.Items.Clear()

        Dim sql As String = "SELECT * FROM tblproductcategories"
        If keyword <> "" Then
            sql &= " WHERE name LIKE '%" & keyword.Replace("'", "''") & "%'"
        End If
        sql &= " ORDER BY name"

        GetQuery(sql, "tblproductcategories")

        For Each row As DataRow In ds.Tables("tblproductcategories").Rows
            Dim item As New ListViewItem(row("categoryid").ToString())
            item.SubItems.Add(row("name").ToString())
            lvcategories.Items.Add(item)
        Next
    End Sub

    Private Sub btnaddcategory_Click(sender As Object, e As EventArgs) Handles btnaddcategory.Click
        Dim dlg As New DlgAddCategories
        If dlg.ShowDialog() = DialogResult.OK Then
            fill()
        End If
    End Sub

    Private Sub btneditcategory_Click(sender As Object, e As EventArgs) Handles btneditcategory.Click
        If lvcategories.SelectedItems.Count = 0 Then
            MsgBox("Please select a category to edit.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim selectedId As Integer = CInt(lvcategories.SelectedItems(0).Text)
        Dim dlg As New DlgEditCategories
        dlg.SelectedCategoryID = selectedId

        If dlg.ShowDialog() = DialogResult.OK Then
            fill()
        End If
    End Sub

    Private Sub btndeletecategory_Click(sender As Object, e As EventArgs) Handles btndeletecategory.Click
        If lvcategories.SelectedItems.Count = 0 Then
            MsgBox("Please select a category to delete.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim selectedId As Integer = CInt(lvcategories.SelectedItems(0).Text)

        ' --- Check if the category is used in tblproducts ---
        Dim checkSql As String = "SELECT productid FROM tblproducts WHERE categoryid = " & selectedId & " LIMIT 1"
        ds.Tables.Clear()
        GetQuery(checkSql, "check")

        If ds.Tables("check").Rows.Count > 0 Then
            MsgBox("Cannot delete this category because it is still used by one or more products.", MsgBoxStyle.Critical, "Delete Blocked")
            Exit Sub
        End If

        ' --- Confirm delete ---
        If MsgBox("Are you sure you want to delete this category?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Deletion") = MsgBoxResult.Yes Then
            Dim sql As String = "DELETE FROM tblproductcategories WHERE categoryid = " & selectedId
            SetQuery(sql)
            MsgBox("Category deleted successfully.", MsgBoxStyle.Information)

            LogActivity("Categories Management", "Delete Category", selectedId)
            fill()
        End If
    End Sub



    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub lvcategories_DoubleClick(sender As Object, e As EventArgs) Handles lvcategories.DoubleClick
        ' Check if an item is selected
        If lvcategories.SelectedItems.Count = 0 Then Exit Sub

        ' Get the selected category ID
        Dim selectedId As Integer = CInt(lvcategories.SelectedItems(0).Text)

        DlgEditCategories.SelectedCategoryID = selectedId

        If DlgEditCategories.ShowDialog() = DialogResult.OK Then
            fill()
        End If
    End Sub

End Class
