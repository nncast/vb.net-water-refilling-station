Imports System.Configuration
Imports MySql.Data.MySqlClient

Module Conn
    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public ds As New DataSet
    Private tx As MySqlTransaction

    ' Server, database, user and password come from this connection string in
    ' App.config (MWRS.exe.config next to the program), so they are not
    ' hard-coded and can be changed without rebuilding the app.
    Private Const ConnectionName As String = "MwrsDb"

    Public Sub Connect()
        If tx IsNot Nothing Then Return
        Try
            If conn.State <> ConnectionState.Closed Then conn.Close()

            Dim setting As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(ConnectionName)
            If setting Is Nothing OrElse String.IsNullOrWhiteSpace(setting.ConnectionString) Then
                MsgBox("The """ & ConnectionName & """ connection string is missing from the .config file.", MsgBoxStyle.Critical, "Database Error")
                Return
            End If

            conn.ConnectionString = setting.ConnectionString
            conn.Open()
        Catch ex As Exception
            MsgBox("Could not connect to the database: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        End Try
    End Sub

    ' Query parameter, e.g. P("@id", id). Anything typed by the user must be
    ' passed this way instead of being pasted into the SQL text.
    Public Function P(name As String, value As Object) As MySqlParameter
        Return New MySqlParameter(name, If(value, DBNull.Value))
    End Function

    Private Function NewCommand(query As String, params() As MySqlParameter) As MySqlCommand
        Dim c As New MySqlCommand(query, conn, tx)
        If params IsNot Nothing AndAlso params.Length > 0 Then c.Parameters.AddRange(params)
        Return c
    End Function

    ' Runs a SELECT and loads the result into ds.Tables(Table). Inside a
    ' transaction errors are thrown (so the caller rolls back); otherwise the
    ' error is shown and an empty table is left in place.
    Public Sub GetQuery(Query As String, Table As String, ParamArray params() As MySqlParameter)
        Try
            cmd = NewCommand(Query, params)
            da = New MySqlDataAdapter(cmd)
            If ds.Tables.Contains(Table) Then ds.Tables.Remove(Table)
            da.Fill(ds, Table)
        Catch ex As Exception When tx Is Nothing
            If Not ds.Tables.Contains(Table) Then ds.Tables.Add(Table)
            ShowError(ex)
        End Try
    End Sub

    ' Runs an INSERT/UPDATE/DELETE. Shows the error and returns False if it
    ' fails (inside a transaction the error is thrown instead).
    Public Function SetQuery(Query As String, ParamArray params() As MySqlParameter) As Boolean
        Try
            cmd = NewCommand(Query, params)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception When tx Is Nothing
            ShowError(ex)
            Return False
        End Try
    End Function

    ' Same as SetQuery but throws instead of showing a message, and returns the
    ' number of rows affected. Use it inside BeginTransaction ... CommitTransaction.
    Public Function Execute(Query As String, ParamArray params() As MySqlParameter) As Integer
        cmd = NewCommand(Query, params)
        Return cmd.ExecuteNonQuery()
    End Function

    ' Returns the first column of the first row (Nothing when there is no value).
    ' Inside a transaction errors are thrown so the caller can roll back;
    ' otherwise the error is shown and Nothing is returned.
    Public Function GetValue(Query As String, ParamArray params() As MySqlParameter) As Object
        Try
            cmd = NewCommand(Query, params)
            Dim value As Object = cmd.ExecuteScalar()
            Return If(value Is DBNull.Value, Nothing, value)
        Catch ex As Exception When tx Is Nothing
            ShowError(ex)
            Return Nothing
        End Try
    End Function

    Public Function InTransaction() As Boolean
        Return tx IsNot Nothing
    End Function

    Public Function GetLastInsertedID() As Integer
        Return CInt(GetValue("SELECT LAST_INSERT_ID()"))
    End Function

    Public Sub BeginTransaction()
        tx = conn.BeginTransaction()
    End Sub

    Public Sub CommitTransaction()
        If tx Is Nothing Then Return
        tx.Commit()
        tx = Nothing
    End Sub

    Public Sub RollbackTransaction()
        If tx Is Nothing Then Return
        Try
            tx.Rollback()
        Catch
        End Try
        tx = Nothing
    End Sub

    Private Sub ShowError(ex As Exception)
        MsgBox("Database error: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
    End Sub

End Module
