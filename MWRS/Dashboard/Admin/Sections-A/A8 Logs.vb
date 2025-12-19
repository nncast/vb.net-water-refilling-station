Public Class A8_Logs
    Private dtUsers As New DataTable()

    Private Sub A_Logs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserCombo()

        dtpFrom.Value = GetEarliestLogDate()
        dtpTo.Value = Date.Today

        LoadLogsActivity()
        LoadLoginLogs()
    End Sub

    Public Sub LoadLogsActivity(Optional ByVal userId As Integer = 0, Optional ByVal fromDate As Date? = Nothing, Optional ByVal toDate As Date? = Nothing, Optional ByVal searchText As String = "")
        Try
            lvlogactivity.Items.Clear()

            Dim sql As String = "SELECT a.logid, a.timestamp, u.fname, u.lname, a.module, a.action, a.recordid " &
                                "FROM tblactivitylogs a " &
                                "INNER JOIN tblusers u ON a.userid = u.userid WHERE 1=1 "

            If userId <> 0 Then
                sql &= " AND u.userid = " & userId
            End If

            If fromDate.HasValue Then
                sql &= " AND a.timestamp >= '" & fromDate.Value.ToString("yyyy-MM-dd 00:00:00") & "' "
            End If
            If toDate.HasValue Then
                sql &= " AND a.timestamp <= '" & toDate.Value.ToString("yyyy-MM-dd 23:59:59") & "' "
            End If

            If Not String.IsNullOrWhiteSpace(searchText) Then
                sql &= " AND (a.module LIKE '%" & searchText.Replace("'", "''") & "%' OR a.action LIKE '%" & searchText.Replace("'", "''") & "%')"
            End If

            sql &= " ORDER BY a.timestamp DESC"

            GetQuery(sql, "logs")

            If ds.Tables.Contains("logs") AndAlso ds.Tables("logs").Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables("logs").Rows
                    Dim item As New ListViewItem(CDate(row("timestamp")).ToString("yyyy-MM-dd HH:mm:ss"))
                    item.SubItems.Add(row("fname").ToString() & " " & row("lname").ToString())
                    item.SubItems.Add(row("module").ToString())
                    item.SubItems.Add(row("action").ToString())
                    item.SubItems.Add(If(row("recordid") Is DBNull.Value, "", row("recordid").ToString()))
                    item.SubItems.Add(row("logid").ToString())
                    lvlogactivity.Items.Add(item)
                Next
            End If

        Catch ex As Exception
            MsgBox("Error loading activity logs: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadLoginLogs(Optional ByVal userId As Integer = 0, Optional ByVal fromDate As Date? = Nothing, Optional ByVal toDate As Date? = Nothing, Optional ByVal searchText As String = "")
        Try
            lvlogin.Items.Clear()

            Dim sql As String = "SELECT l.logid, u.fname, u.lname, l.logintime, l.logouttime " &
                                "FROM tblloginlogs l " &
                                "INNER JOIN tblusers u ON l.userid = u.userid WHERE 1=1 "

            If userId <> 0 Then
                sql &= " AND u.userid = " & userId
            End If

            If fromDate.HasValue Then
                sql &= " AND l.logintime >= '" & fromDate.Value.ToString("yyyy-MM-dd 00:00:00") & "' "
            End If
            If toDate.HasValue Then
                sql &= " AND l.logintime <= '" & toDate.Value.ToString("yyyy-MM-dd 23:59:59") & "' "
            End If

            If Not String.IsNullOrWhiteSpace(searchText) Then
                sql &= " AND u.fname LIKE '%" & searchText.Replace("'", "''") & "%'"
            End If

            sql &= " ORDER BY l.logintime DESC"

            GetQuery(sql, "loginlogs")

            If ds.Tables.Contains("loginlogs") AndAlso ds.Tables("loginlogs").Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables("loginlogs").Rows
                    Dim item As New ListViewItem(row("logid").ToString())
                    item.SubItems.Add(row("fname").ToString() & " " & row("lname").ToString())
                    item.SubItems.Add(CDate(row("logintime")).ToString("yyyy-MM-dd HH:mm:ss"))
                    item.SubItems.Add(If(row("logouttime") Is DBNull.Value, "", CDate(row("logouttime")).ToString("yyyy-MM-dd HH:mm:ss")))
                    lvlogin.Items.Add(item)
                Next
            End If

        Catch ex As Exception
            MsgBox("Error loading login logs: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadUserCombo()
        Try
            Dim sql As String = "SELECT userid, CONCAT(fname, ' ', lname) AS fullname FROM tblusers WHERE status='Active' ORDER BY fname, lname"
            GetQuery(sql, "users")

            dtUsers = ds.Tables("users").Copy()

            Dim allRow As DataRow = dtUsers.NewRow()
            allRow("userid") = 0
            allRow("fullname") = "All"
            dtUsers.Rows.InsertAt(allRow, 0)

            cmbUser.DataSource = dtUsers
            cmbUser.DisplayMember = "fullname"
            cmbUser.ValueMember = "userid"
            cmbUser.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("Error loading users: " & ex.Message)
        End Try
    End Sub

    Private Function GetEarliestLogDate() As Date
        Try
            Dim sql As String = "SELECT MIN(timestamp) AS earliest FROM tblactivitylogs"
            GetQuery(sql, "earliest")

            If ds.Tables.Contains("earliest") AndAlso ds.Tables("earliest").Rows.Count > 0 Then
                Dim dt = ds.Tables("earliest").Rows(0)("earliest")
                If dt IsNot DBNull.Value Then
                    Return CDate(dt)
                End If
            End If

        Catch ex As Exception
            MsgBox("Error getting earliest log date: " & ex.Message)
        End Try

        Return Date.Today
    End Function

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim selectedUserId As Integer = CInt(cmbUser.SelectedValue)
        Dim fromDate As Date = dtpFrom.Value
        Dim toDate As Date = dtpTo.Value
        Dim searchText As String = txtsearch.Text.Trim()

        LoadLogsActivity(selectedUserId, fromDate, toDate, searchText)
        LoadLoginLogs(selectedUserId, fromDate, toDate, searchText)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            cmbUser.SelectedIndex = 0
            dtpFrom.Value = GetEarliestLogDate()
            dtpTo.Value = Date.Today
            txtsearch.Text = ""

            LoadLogsActivity()
            LoadLoginLogs()
        Catch ex As Exception
            MsgBox("Error clearing filters: " & ex.Message)
        End Try
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim selectedUserId As Integer = CInt(cmbUser.SelectedValue)
        Dim fromDate As Date = dtpFrom.Value
        Dim toDate As Date = dtpTo.Value
        Dim searchText As String = txtsearch.Text.Trim()

        LoadLogsActivity(selectedUserId, fromDate, toDate, searchText)
        LoadLoginLogs(selectedUserId, fromDate, toDate, searchText)
    End Sub


End Class
