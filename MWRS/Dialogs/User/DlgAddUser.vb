Public Class DlgAddUser

    Private Sub DlgAddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboboxes()
        Clear()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim fname As String = txtfname.Text.Trim()
        Dim lname As String = txtlname.Text.Trim()
        Dim username As String = txtusername.Text.Trim()
        Dim password As String = txtpassword.Text.Trim()

        ' Basic validation
        If fname = "" OrElse lname = "" OrElse username = "" OrElse password = "" Then
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

        If password.Length < MinPasswordLength Then
            MsgBox("Password must be at least " & MinPasswordLength & " characters.", MsgBoxStyle.Exclamation)
            txtpassword.Focus()
            Exit Sub
        End If

        ' Check if username already exists
        If CInt(GetValue("SELECT COUNT(*) FROM tblusers WHERE username = @u", P("@u", username))) > 0 Then
            MsgBox("Username already exists. Choose a different one.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Only a salted hash of the password is stored.
        If Not SetQuery("INSERT INTO tblusers (fname, lname, username, password, role, status) VALUES (@f, @l, @u, @p, @r, @s)",
                        P("@f", fname), P("@l", lname), P("@u", username), P("@p", HashPassword(password)),
                        P("@r", cmbrole.Text), P("@s", cmbstatus.Text)) Then Exit Sub

        ' --- Log Activity ---
        LogActivity("User", "Add user", GetLastInsertedID())
        MsgBox("New user added successfully.", MsgBoxStyle.Information)

        ' Close dialog
        Me.DialogResult = DialogResult.OK
        clear()
        Me.Close()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        clear()
        Me.Close()
    End Sub

    Private Sub LoadComboboxes()
        ' Populate role options
        cmbrole.Items.Clear()
        cmbrole.Items.AddRange(New String() {"Admin", "Employee"})
        cmbrole.DropDownStyle = ComboBoxStyle.DropDownList

        ' Populate status options
        cmbstatus.Items.Clear()
        cmbstatus.Items.AddRange(New String() {"Active", "Inactive"})
        cmbstatus.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub Clear()
        txtfname.Clear()
        txtlname.Clear()
        txtpassword.Clear()
        txtusername.Clear()

        ' New accounts start as active employees; Admin has to be chosen on purpose.
        cmbrole.SelectedItem = "Employee"
        cmbstatus.SelectedItem = "Active"
    End Sub

End Class
