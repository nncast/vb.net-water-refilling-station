Public Class DlgUpdateUser
    Public Property SelectedUserID As Integer
    Private ReadOnly passwordTip As New ToolTip()

    Private Sub DlgUpdateUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboboxes()
        passwordTip.SetToolTip(txtpassword, "Leave blank to keep the current password.")

        ' Load user data from DB
        GetQuery("SELECT * FROM tblusers WHERE userid = @u", "tblusers", P("@u", SelectedUserID))

        If ds.Tables("tblusers").Rows.Count > 0 Then
            Dim row = ds.Tables("tblusers").Rows(0)
            txtfname.Text = row("fname").ToString()
            txtlname.Text = row("lname").ToString()
            txtusername.Text = row("username").ToString()
            ' Passwords are stored hashed and can't be shown; a blank box keeps the current one.
            txtpassword.Clear()
            cmbrole.Text = row("role").ToString()
            cmbstatus.Text = row("status").ToString()
        End If
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim fname As String = txtfname.Text.Trim()
        Dim lname As String = txtlname.Text.Trim()
        Dim username As String = txtusername.Text.Trim()
        Dim password As String = txtpassword.Text.Trim()
        Dim role As String = cmbrole.Text
        Dim status As String = cmbstatus.Text

        If fname = "" OrElse lname = "" OrElse username = "" Then
            MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If fname.Length > 50 OrElse lname.Length > 50 OrElse username.Length > 50 Then
            MsgBox("Names and username can be at most 50 characters.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If cmbrole.SelectedIndex = -1 OrElse cmbstatus.SelectedIndex = -1 Then
            MsgBox("Please select a role and a status.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If password <> "" AndAlso password.Length < MinPasswordLength Then
            MsgBox("Password must be at least " & MinPasswordLength & " characters (or leave it blank to keep the current one).", MsgBoxStyle.Exclamation)
            txtpassword.Focus()
            Exit Sub
        End If

        ' Check if username already exists for another user
        If CInt(GetValue("SELECT COUNT(*) FROM tblusers WHERE username = @u AND userid <> @id", P("@u", username), P("@id", SelectedUserID))) > 0 Then
            MsgBox("Username already exists. Choose a different one.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' An admin can't lock themselves out, and there must always be an active admin.
        Dim staysActiveAdmin As Boolean = (role = "Admin" AndAlso status = "Active")
        If Not staysActiveAdmin Then
            If SelectedUserID = Globals.UserID Then
                MsgBox("You can't remove the Admin role from, or deactivate, your own account.", MsgBoxStyle.Exclamation, "Not Allowed")
                Exit Sub
            End If

            Dim otherAdmins As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblusers WHERE role = 'Admin' AND status = 'Active' AND userid <> @id", P("@id", SelectedUserID)))
            If otherAdmins = 0 Then
                MsgBox("This is the last active Admin account; it must stay an active Admin.", MsgBoxStyle.Exclamation, "Not Allowed")
                Exit Sub
            End If
        End If

        ' Update user info (including status); the password only changes when a new one is typed.
        Dim sql As String = "UPDATE tblusers SET fname = @f, lname = @l, username = @u, role = @r, status = @s"
        If password <> "" Then sql &= ", password = @p"
        sql &= " WHERE userid = @id"

        If Not SetQuery(sql, P("@f", fname), P("@l", lname), P("@u", username), P("@r", role), P("@s", status),
                        P("@p", If(password <> "", HashPassword(password), Nothing)), P("@id", SelectedUserID)) Then Exit Sub

        ' --- Log Activity ---
        LogActivity("User", "Update user", SelectedUserID)
        MsgBox("User updated successfully.", MsgBoxStyle.Information)

        Me.DialogResult = DialogResult.OK
        clear()
        Me.Close()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        clear()
        Me.Close()
    End Sub

    Private Sub LoadComboboxes()
        ' Define available roles
        cmbrole.Items.Clear()
        cmbrole.Items.AddRange(New String() {"Admin", "Employee"})
        cmbrole.DropDownStyle = ComboBoxStyle.DropDownList

        ' Define available status options
        cmbstatus.Items.Clear()
        cmbstatus.Items.AddRange(New String() {"Active", "Inactive"})
        cmbstatus.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub clear()
        txtfname.Clear()
        txtlname.Clear()
        txtpassword.Clear()
        txtusername.Clear()
        cmbrole.SelectedIndex = -1
        cmbstatus.SelectedIndex = -1

    End Sub


End Class
