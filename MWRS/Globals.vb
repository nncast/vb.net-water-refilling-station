Module Globals
    Public UserID As Integer = 0
    Public UserName As String
    Public UserRole As String

    ' Writes an entry to the activity log. Inside a transaction a failure is
    ' thrown so the whole operation rolls back; otherwise it is only shown.
    Public Sub LogActivity(moduleName As String, action As String, recordID As Integer)
        ' Column sizes: module varchar(100), action varchar(50).
        Dim moduleText As String = Truncate(moduleName, 100)
        Dim actionText As String = Truncate(action, 50)
        Const sql As String = "INSERT INTO tblactivitylogs (userid, module, action, recordid) VALUES (@u, @m, @a, @r)"

        If InTransaction() Then
            Execute(sql, P("@u", UserID), P("@m", moduleText), P("@a", actionText), P("@r", recordID))
        Else
            SetQuery(sql, P("@u", UserID), P("@m", moduleText), P("@a", actionText), P("@r", recordID))
        End If
    End Sub

    Public Function Truncate(text As String, maxLength As Integer) As String
        If text Is Nothing Then Return ""
        Return If(text.Length > maxLength, text.Substring(0, maxLength), text)
    End Function

    ' Ends the session: records the logout time and forgets the user.
    Public Sub LogOut()
        If UserID <> 0 Then
            SetQuery("UPDATE tblloginlogs SET logouttime = NOW() WHERE userid = @u ORDER BY logid DESC LIMIT 1", P("@u", UserID))
        End If

        UserID = 0
        UserName = Nothing
        UserRole = Nothing
    End Sub

    Public Sub labelclickedA(lbl As Label)
        Dim labels As Label() = {
            AdminDashboard.lblhome,
            AdminDashboard.lblsales,
            AdminDashboard.lblorders,
            AdminDashboard.lblinventory,
            AdminDashboard.lbldelivery,
            AdminDashboard.lblcustomers,
            AdminDashboard.lblemployee,
            AdminDashboard.lbllogs,
            AdminDashboard.lblreport
        }

        For Each label In labels
            label.BackColor = Color.White
            label.ForeColor = Color.MidnightBlue
        Next

        lbl.BackColor = Color.FromArgb(237, 243, 254)
        lbl.ForeColor = Color.RoyalBlue
    End Sub

    Public Sub labelclickedE(lbl As Label)
        Dim labels As Label() = {
            EmployeeDashboard.lblhome,
            EmployeeDashboard.lblsales,
            EmployeeDashboard.lblorders,
            EmployeeDashboard.lblinventory,
            EmployeeDashboard.lbldelivery,
            EmployeeDashboard.lblcustomers
        }

        For Each label In labels
            label.BackColor = Color.White
            label.ForeColor = Color.MidnightBlue
        Next

        lbl.BackColor = Color.FromArgb(237, 243, 254)
        lbl.ForeColor = Color.RoyalBlue
    End Sub
End Module
