Module Globals
    Public UserID As Integer = 0
    Public UserName As String
    Public UserRole As String

    Public Sub LogActivity(moduleName As String, action As String, recordID As Integer)
        Try
            Dim sql As String =
                "INSERT INTO tblactivitylogs (userid, module, action, recordid) VALUES (" &
                UserID & ", " &
                "'" & moduleName.Replace("'", "''") & "', " &
                "'" & action.Replace("'", "''") & "', " &
                recordID & ")"
            SetQuery(sql)
        Catch ex As Exception
            MsgBox("Failed to record activity log: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
