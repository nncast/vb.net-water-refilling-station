Public Class DlgEditServices
    Public ServiceID As Integer

    Private Sub DlgEditServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServiceDetails()
    End Sub

    Private Sub LoadServiceDetails()
        Try
            Dim sql As String = "SELECT * FROM tblservices WHERE serviceid = " & ServiceID
            GetQuery(sql, "tblservices")

            If ds.Tables("tblservices").Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables("tblservices").Rows(0)
                txtservicename.Text = row("name").ToString()
                txtprice.Text = Format(CDec(row("price")), "0.00")
                cmbstatus.Text = row("status").ToString()
            End If
        Catch ex As Exception
            MsgBox("Failed to load service details: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            If txtservicename.Text.Trim() = "" Or txtprice.Text.Trim() = "" Then
                MsgBox("Please fill out all fields.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim sql As String =
                "UPDATE tblservices SET " &
                "name = '" & txtservicename.Text.Replace("'", "''") & "', " &
                "price = " & CDec(txtprice.Text) & ", " &
                "status = '" & cmbstatus.Text & "' " &
                "WHERE serviceid = " & ServiceID

            SetQuery(sql)
            MsgBox("Service updated successfully.", MsgBoxStyle.Information)

            ' Optional: Log activity
            LogActivity("Services", "Updated service: " & txtservicename.Text, ServiceID)

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("Failed to update service: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
