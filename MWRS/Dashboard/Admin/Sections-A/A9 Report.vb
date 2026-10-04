Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class A9_Report
    Private rptSales As New RPTSales
    Private rptInventory As New RPTInventory

    Private Sub A_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbreporttype.Items.Clear()
        cmbreporttype.Items.Add("Sales Report")
        cmbreporttype.Items.Add("Inventory Report")
        cmbreporttype.SelectedIndex = 0

    End Sub

    Private Sub btngenerate_Click(sender As Object, e As EventArgs) Handles btngenerate.Click
        Dim selectedReport As String = cmbreporttype.SelectedItem.ToString()

        Select Case selectedReport
            Case "Sales Report"
                LogActivity("Report", "Generate Sales Report", 0)
                Dim rpt As New RPTSales()
                LoadReport(rpt)
            Case "Inventory Report"
                LogActivity("Report", "Generate Inventory Report", 0)
                Dim rpt As New RPTInventory()
                LoadReport(rpt)
        End Select
    End Sub

    Private Sub LoadReport(report As ReportDocument)
        Try
            ' Database, user and password come from the MwrsDb connection string in
            ' MWRS.exe.config (the same one the rest of the app uses); the data
            ' source the reports were designed with is the ReportServer setting.
            Dim db As New MySqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings("MwrsDb").ConnectionString)
            Dim server As String = ConfigurationManager.AppSettings("ReportServer")
            If String.IsNullOrWhiteSpace(server) Then server = "POSMWRS"

            For Each table As Table In report.Database.Tables
                Dim logonInfo As TableLogOnInfo = table.LogOnInfo
                logonInfo.ConnectionInfo.ServerName = server
                logonInfo.ConnectionInfo.DatabaseName = db.Database
                logonInfo.ConnectionInfo.UserID = db.UserID
                logonInfo.ConnectionInfo.Password = db.Password
                table.ApplyLogOnInfo(logonInfo)
            Next

            ' Verify database after logon
            report.VerifyDatabase()

            report.Refresh()
            crViewer.ReportSource = report
            crViewer.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error loading report: " & ex.Message)
        End Try
    End Sub




End Class
