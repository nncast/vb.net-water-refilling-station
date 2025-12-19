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

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            If lvemployee.SelectedItems.Count = 0 Then
                MsgBox("Please select a user to delete.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim selectedID As Integer = CInt(lvemployee.SelectedItems(0).Text)

            ' --- Check for linked records ---
            Dim checkSql As String =
                "SELECT COUNT(*) AS cnt FROM (" &
                "SELECT userid FROM tblorders WHERE userid = " & selectedID & " " &
                "UNION ALL " &
                "SELECT userid FROM tblsales WHERE userid = " & selectedID & " " &
                "UNION ALL " &
                "SELECT userid FROM tblinventorytransactions WHERE userid = " & selectedID & " " &
                "UNION ALL " &
                "SELECT userid FROM tblactivitylogs WHERE userid = " & selectedID & " " &
                "UNION ALL " &
                "SELECT userid FROM tblloginlogs WHERE userid = " & selectedID & " " &
                "UNION ALL " &
                "SELECT userid FROM tbldelivery WHERE userid = " & selectedID &
                ") AS linked"

            GetQuery(checkSql, "checklinks")

            Dim recordCount As Integer = 0
            If ds.Tables("checklinks").Rows.Count > 0 Then
                recordCount = CInt(ds.Tables("checklinks").Rows(0)("cnt"))
            End If

            ' --- Suggest Inactivate if linked ---
            If recordCount > 0 Then
                Dim msgResult = MsgBox("Cannot delete this user because they are linked to existing records." &
                                       vbCrLf & "Do you want to set this user as INACTIVE instead?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User Linked")
                If msgResult = MsgBoxResult.Yes Then
                    Dim inactSql As String = "UPDATE tblusers SET status='Inactive' WHERE userid=" & selectedID
                    SetQuery(inactSql)
                    LogActivity("User", "Set User Inactive", selectedID)
                    MsgBox("User has been set to INACTIVE.", MsgBoxStyle.Information)
                    fill()
                End If
                Exit Sub
            End If

            ' --- Confirm deletion ---
            Dim result = MsgBox("Are you sure you want to delete this user?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
            If result = MsgBoxResult.No Then Exit Sub

            Dim sql As String = "DELETE FROM tblusers WHERE userid = " & selectedID
            SetQuery(sql)
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

            Dim sql As String = "SELECT userid, fname, lname, username, password, role, status FROM tblusers"

            If keyword <> "" Then
                sql &= " WHERE CAST(userid AS CHAR) LIKE '%" & keyword & "%' " &
                       "OR fname LIKE '%" & keyword & "%' " &
                       "OR lname LIKE '%" & keyword & "%'" &
                       "OR username LIKE '%" & keyword & "%'" &
                       "OR password LIKE '%" & keyword & "%' " &
                       "OR role LIKE '%" & keyword & "%'" &
                       "OR status LIKE '%" & keyword & "%'"
            End If

            sql &= " ORDER BY lname, fname"

            ds.Tables.Clear()
            GetQuery(sql, "tblusers")

            If ds.Tables("tblusers").Rows.Count = 0 Then Exit Sub

            For Each row As DataRow In ds.Tables("tblusers").Rows
                Dim item As New ListViewItem(row("userid").ToString())
                item.SubItems.Add(row("fname").ToString())
                item.SubItems.Add(row("lname").ToString())
                item.SubItems.Add(row("username").ToString())
                item.SubItems.Add(row("password").ToString())
                item.SubItems.Add(row("role").ToString())
                item.SubItems.Add(row("status").ToString())
                lvemployee.Items.Add(item)
            Next
        Catch ex As Exception
            MsgBox("Error filling user list: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs)
        Try
            fill(txtsearch.Text)
        Catch ex As Exception
            MsgBox("Error searching users: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtsearch_TextChanged_1(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill(txtsearch.Text.Trim)
    End Sub
End Class
