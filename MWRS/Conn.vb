Imports MySql.Data.MySqlClient
Module Conn
    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public ds As New DataSet
    Public desc As String = Nothing
    Public Sub Connect(Server As String, Database As String, Port As String, Username As String, Password As String)
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.ConnectionString = "Server=" & Server & ";Port=" & Port & ";Database=" &
           Database & ";Username=" & Username & ";Password=" & Password
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                'MsgBox("Connected")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Public Sub GetQuery(Query As String, Table As String)
        Try
            cmd = New MySqlCommand(Query, conn)
            da = New MySqlDataAdapter(Query, conn)
            cmd.ExecuteNonQuery()
            ds.Clear()
            da.fill(ds, Table)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub SetQuery(Query As String)
        Try
            cmd = New MySqlCommand(Query, conn)
            da = New MySqlDataAdapter(Query, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function Encrypt(ByRef Text As String) As String
        Try
            Dim encData_Byte() = New Byte(Text.Length - 1) {}
            encData_Byte = System.Text.Encoding.UTF8.GetBytes(Text)
            Dim encodedData As String = Convert.ToBase64String(encData_Byte)
            Return encodedData
        Catch ex As Exception
            Throw (New Exception("Error in Encrypting Password" & ex.Message))
        End Try
    End Function
    Public Function Decrypt(ByVal Text As String) As String
        Dim encoder As New System.Text.UTF8Encoding()
        Dim utf8Decode As System.Text.Decoder = encoder.GetDecoder()
        Dim todecode_byte As Byte() = Convert.FromBase64String(Text)
        Dim charCount As Integer = utf8Decode.GetCharCount(todecode_byte, 0,
       todecode_byte.Length)
        Dim decoded_char As Char() = New Char(charCount - 1) {}
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
        Dim result As String = New [String](decoded_char)
        Return result
    End Function
    Public Function GetLastInsertedID() As Integer
        Dim query As String = "SELECT LAST_INSERT_ID()"
        Dim cmd As New MySqlCommand(query, conn)
        Return CInt(cmd.ExecuteScalar())
    End Function
End Module
