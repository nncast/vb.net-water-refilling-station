Public Class A7_User

    Private Sub A_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            fill()
        Catch ex As Exception
            MsgBox("Error loading users: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        Try
            If DlgAddUser.ShowDialog() = DialogResult.OK Then
                fill()
            End If
        Catch ex As Exception
            MsgBox("Error adding new user: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        Try
            If lvemployee.SelectedItems.Count = 0 Then
                MsgBox("Please select a user to edit.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim selectedID As Integer = CInt(lvemployee.SelectedItems(0).Text)
            DlgUpdateUser.SelectedUserID = selectedID

            If DlgUpdateUser.ShowDialog() = DialogResult.OK Then
                fill()

            End If
        Catch ex As Exception
            MsgBox("Error editing user: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' Explains why the account can't be deleted or deactivated, or returns Nothing if it can.
    Private Function BlockReason(userID As Integer) As String
        If userID = Globals.UserID Then
            Return "You can't delete or deactivate your own account while you are logged in."
        End If

        Dim isActiveAdmin As Boolean = CInt(GetValue("SELECT COUNT(*) FROM tblusers WHERE userid = @u AND role = 'Admin' AND status = 'Active'", P("@u", userID))) > 0
        If isActiveAdmin AndAlso CInt(GetValue("SELECT COUNT(*) FROM tblusers WHERE role = 'Admin' AND status = 'Active' AND userid <> @u", P("@u", userID))) = 0 Then
            Return "This is the last active Admin account, so it can't be deleted or deactivated."
        End If

        Return Nothing
    End Function

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            If lvemployee.SelectedItems.Count = 0 Then
                MsgBox("Please select a user to delete.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim selectedID As Integer = CInt(lvemployee.SelectedItems(0).Text)

            Dim reason As String = BlockReason(selectedID)
            If reason IsNot Nothing Then
                MsgBox(reason, MsgBoxStyle.Exclamation, "Not Allowed")
                Exit Sub
            End If

            ' --- Check for linked records ---
            Dim recordCount As Integer = CInt(GetValue(
                "SELECT (SELECT COUNT(*) FROM tblorders WHERE userid = @u) + " &
                "(SELECT COUNT(*) FROM tblsales WHERE userid = @u) + " &
                "(SELECT COUNT(*) FROM tblinventorytransactions WHERE userid = @u) + " &
                "(SELECT COUNT(*) FROM tblactivitylogs WHERE userid = @u) + " &
                "(SELECT COUNT(*) FROM tblloginlogs WHERE userid = @u) + " &
                "(SELECT COUNT(*) FROM tbldelivery WHERE userid = @u)", P("@u", selectedID)))

            ' --- Suggest Inactivate if linked ---
            If recordCount > 0 Then
                Dim msgResult = MsgBox("Cannot delete this user because they are linked to existing records." &
                                       vbCrLf & "Do you want to set this user as INACTIVE instead?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User Linked")
                If msgResult = MsgBoxResult.Yes Then
                    If SetQuery("UPDATE tblusers SET status = 'Inactive' WHERE userid = @u", P("@u", selectedID)) Then
                        LogActivity("User", "Set User Inactive", selectedID)
                        MsgBox("User has been set to INACTIVE.", MsgBoxStyle.Information)
                        fill()
                    End If
                End If
                Exit Sub
            End If

            ' --- Confirm deletion ---
            Dim result = MsgBox("Are you sure you want to delete this user?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
            If result = MsgBoxResult.No Then Exit Sub

            If Not SetQuery("DELETE FROM tblusers WHERE userid = @u", P("@u", selectedID)) Then Exit Sub
            LogActivity("User", "Delete User", selectedID)

            MsgBox("User deleted successfully.", MsgBoxStyle.Information)
            fill()

        Catch ex As Exception
            MsgBox("Error deleting user: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub lvemployee_DoubleClick(sender As Object, e As EventArgs) Handles lvemployee.DoubleClick
        Try
            If lvemployee.SelectedItems.Count = 0 Then Exit Sub

            Dim selectedID As Integer = CInt(lvemployee.SelectedItems(0).Text)
            DlgUpdateUser.SelectedUserID = selectedID

            If DlgUpdateUser.ShowDialog() = DialogResult.OK Then
                fill()
            End If
        Catch ex As Exception
            MsgBox("Error opening user for edit: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub fill(Optional ByVal keyword As String = "")
        Try
            lvemployee.Items.Clear()

            ' Passwords are stored hashed; they are neither listed nor searchable.
            Dim sql As String = "SELECT userid, fname, lname, username, role, status FROM tblusers"

            If keyword <> "" Then
                sql &= " WHERE CAST(userid AS CHAR) LIKE @k OR fname LIKE @k OR lname LIKE @k OR username LIKE @k OR role LIKE @k OR status LIKE @k"
            End If

            sql &= " ORDER BY lname, fname"

            GetQuery(sql, "tblusers", P("@k", "%" & keyword & "%"))

            If ds.Tables("tblusers").Rows.Count = 0 Then Exit Sub

            For Each row As DataRow In ds.Tables("tblusers").Rows
                Dim item As New ListViewItem(row("userid").ToString())
                item.SubItems.Add(row("fname").ToString())
                item.SubItems.Add(row("lname").ToString())
                item.SubItems.Add(row("username").ToString())
                item.SubItems.Add(row("role").ToString())
                item.SubItems.Add(row("status").ToString())
                lvemployee.Items.Add(item)
            Next
        Catch ex As Exception
            MsgBox("Error filling user list: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtsearch_TextChanged_1(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill(txtsearch.Text.Trim)
    End Sub
End Class
