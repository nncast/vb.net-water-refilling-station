Public Class DlgUpdateUser
    Public Property SelectedUserID As Integer

    Private Sub DlgUpdateUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboboxes()
        ' Load user data from DB
        Dim sql As String = "SELECT * FROM tblusers WHERE userid = " & SelectedUserID
        GetQuery(sql, "tblusers")

        If ds.Tables("tblusers").Rows.Count > 0 Then
            Dim row = ds.Tables("tblusers").Rows(0)
            txtfname.Text = row("fname").ToString()
            txtlname.Text = row("lname").ToString()
            txtusername.Text = row("username").ToString()
            txtpassword.Text = row("password").ToString()
            cmbrole.Text = row("role").ToString()
            cmbstatus.Text = row("status").ToString()
        End If
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        ' Check if username already exists for another user
        Dim checkSql As String = "SELECT COUNT(*) AS total FROM tblusers WHERE username = '" & txtusername.Text.Replace("'", "''") & "' AND userid <> " & SelectedUserID
        GetQuery(checkSql, "checkuser")

        If ds.Tables("checkuser").Rows(0)("total") > 0 Then
            MsgBox("Username already exists. Choose a different one.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Update user info (including status)
        Dim sql As String =
            "UPDATE tblusers SET " &
            "fname = '" & txtfname.Text.Replace("'", "''") & "', " &
            "lname = '" & txtlname.Text.Replace("'", "''") & "', " &
            "username = '" & txtusername.Text.Replace("'", "''") & "', " &
            "password = '" & txtpassword.Text.Replace("'", "''") & "', " &
            "role = '" & cmbrole.Text.Replace("'", "''") & "', " &
            "status = '" & cmbstatus.Text.Replace("'", "''") & "' " &
            "WHERE userid = " & SelectedUserID

        SetQuery(sql)
        MsgBox("User updated successfully.", MsgBoxStyle.Information)

        ' --- Log Activity ---
        LogActivity("User", "Update user", SelectedUserID)

        Me.DialogResult = DialogResult.OK
        clear()
        Me.Close()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
