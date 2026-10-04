Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtusername.Text.Trim()
        Dim password As String = txtpassword.Text.Trim()

        If username = Nothing Or password = Nothing Then
            MsgBox("Fields cannot be empty. Please enter your credentials.", MsgBoxStyle.Critical, "Login Failed")
            Exit Sub
        End If

        ' Look the account up by username only; the password is checked against
        ' its stored hash (accounts from before hashing still hold plain text).
        GetQuery("SELECT userid, password, role, status FROM tblusers WHERE username = @u", "tblusers", P("@u", username))

        If ds.Tables("tblusers").Rows.Count = 0 OrElse Not VerifyPassword(password, ds.Tables("tblusers").Rows(0)("password").ToString()) Then
            MsgBox("Incorrect username or password.", MsgBoxStyle.Critical, "Login Failed")
            clearfields()
            Exit Sub
        End If


        Dim row = ds.Tables("tblusers").Rows(0)
        Dim userid As Integer = CInt(row("userid"))
        Dim role As String = row("role").ToString()
        Dim status As String = row("status").ToString()

        ' --- Check if the account is active ---
        If status.ToLower() <> "active" Then
            MsgBox("Your account is inactive. Please contact the administrator.", MsgBoxStyle.Exclamation, "Account Disabled")
            clearfields()
            Exit Sub
        End If

        ' --- Replace a plain-text password with its hash ---
        If NeedsRehash(row("password").ToString()) Then
            SetQuery("UPDATE tblusers SET password = @p WHERE userid = @u", P("@p", HashPassword(password)), P("@u", userid))
        End If

        ' --- Save global user info ---
        Globals.UserID = userid
        Globals.UserName = username
        Globals.UserRole = role

        ' --- Log successful login ---
        SetQuery("INSERT INTO tblloginlogs (userid) VALUES (@u)", P("@u", userid))

        ' --- Role-based redirection ---
        clearfields()

        Select Case role
            Case "Admin"
                MsgBox("Welcome, Admin!", MsgBoxStyle.Information, "Login Successful")
                Me.Hide()
                AdminDashboard.Show()
                AdminDashboard.LoadUserInfo()
                AdminDashboard.switchPanel(A1_Home)
                labelclickedA(AdminDashboard.lblhome)

            Case "Employee"
                MsgBox("Welcome, Employee!", MsgBoxStyle.Information, "Login Successful")
                Me.Hide()
                EmployeeDashboard.Show()
                EmployeeDashboard.LoadUserInfo()
                EmployeeDashboard.switchPanel(E1_Home)
                labelclickedE(EmployeeDashboard.lblhome)

            Case Else
                MsgBox("Invalid user role detected.", MsgBoxStyle.Critical, "Login Error")
                Globals.LogOut()
                clearfields()
        End Select
    End Sub

    ' --- Clear login fields ---
    ' The password box goes back to hidden, so it isn't readable after a logout.
    Public Sub clearfields()
        txtusername.Clear()
        txtpassword.Clear()
        txtpassword.UseSystemPasswordChar = True
        piceyeshow.Visible = True
    End Sub

    ' --- Eye icon toggle ---
    Private Sub piceyeshow_Click(sender As Object, e As EventArgs) Handles piceyeshow.Click
        txtpassword.UseSystemPasswordChar = False
        piceyeshow.Visible = False
    End Sub

    Private Sub piceyehide_Click(sender As Object, e As EventArgs) Handles piceyehide.Click
        txtpassword.UseSystemPasswordChar = True
        piceyeshow.Visible = True
    End Sub
End Class
