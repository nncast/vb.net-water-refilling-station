Public Class DlgAddUser

    Private Sub DlgAddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboboxes()
        Clear()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        ' Basic validation
        If txtfname.Text.Trim() = "" OrElse txtlname.Text.Trim() = "" OrElse
           txtusername.Text.Trim() = "" OrElse txtpassword.Text.Trim() = "" Then
            MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Check if username already exists
        Dim checkSql As String = "SELECT COUNT(*) AS total FROM tblusers WHERE username = '" & txtusername.Text.Replace("'", "''") & "'"
        GetQuery(checkSql, "checkuser")

        If ds.Tables("checkuser").Rows(0)("total") > 0 Then
            MsgBox("Username already exists. Choose a different one.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If


        ' Build insert query
        Dim sql As String =
            "INSERT INTO tblusers (fname, lname, username, password, role, status) VALUES (" &
            "'" & txtfname.Text.Replace("'", "''") & "', " &
            "'" & txtlname.Text.Replace("'", "''") & "', " &
            "'" & txtusername.Text.Replace("'", "''") & "', " &
            "'" & txtpassword.Text.Replace("'", "''") & "', " &
            "'" & cmbrole.Text.Replace("'", "''") & "', " &
            "'" & cmbstatus.Text.Replace("'", "''") & "')"

        ' Execute query
        SetQuery(sql)
        MsgBox("New user added successfully.", MsgBoxStyle.Information)

        ' --- Log Activity ---
        Dim getNewIdSql As String = "SELECT MAX(userid) AS newID FROM tblusers"
        GetQuery(getNewIdSql, "newuser")
        Dim newID As Integer = CInt(ds.Tables("newuser").Rows(0)("newID"))
        LogActivity("User", "Add user", newID)

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

        ' Set default selections
        If cmbrole.Items.Count > 0 Then cmbrole.SelectedIndex = 0
        If cmbstatus.Items.Count > 0 Then cmbstatus.SelectedIndex = 0
    End Sub

    Private Sub Clear()
        txtfname.Clear()
        txtlname.Clear()
        txtpassword.Clear()
        txtusername.Clear()
        cmbrole.SelectedIndex = -1
        cmbstatus.SelectedIndex = -1
    End Sub

End Class
