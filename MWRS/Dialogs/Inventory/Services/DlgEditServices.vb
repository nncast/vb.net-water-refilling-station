Public Class DlgEditServices
    Public ServiceID As Integer

    Private Sub DlgEditServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServiceDetails()
    End Sub

    Private Sub LoadServiceDetails()
        Try
            GetQuery("SELECT * FROM tblservices WHERE serviceid = @s", "tblservices", P("@s", ServiceID))

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
            Dim name As String = txtservicename.Text.Trim()
            Dim price As Decimal

            If name = "" Or txtprice.Text.Trim() = "" Then
                MsgBox("Please fill out all fields.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If name.Length > 100 Then
                MsgBox("Service name can be at most 100 characters.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If Not Decimal.TryParse(txtprice.Text.Trim(), price) OrElse price < 0 Then
                MsgBox("Enter a valid numeric price.", MsgBoxStyle.Exclamation)
                txtprice.Focus()
                Exit Sub
            End If

            Dim status As String = cmbstatus.Text.Trim()
            If status <> "Active" AndAlso status <> "Inactive" Then
                MsgBox("Select a status (Active or Inactive).", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If CInt(GetValue("SELECT COUNT(*) FROM tblservices WHERE name = @n AND serviceid <> @s", P("@n", name), P("@s", ServiceID))) > 0 Then
                MsgBox("Another service already has this name.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If Not SetQuery("UPDATE tblservices SET name = @n, price = @p, status = @st WHERE serviceid = @s",
                            P("@n", name), P("@p", price), P("@st", status), P("@s", ServiceID)) Then Exit Sub

            LogActivity("Services", "Updated service: " & name, ServiceID)
            MsgBox("Service updated successfully.", MsgBoxStyle.Information)

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
