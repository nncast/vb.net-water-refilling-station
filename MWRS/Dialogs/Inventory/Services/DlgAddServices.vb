Public Class DlgAddServices

    Private Sub DlgAddServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate combo box for status
        cmbstatus.Items.Clear()
        cmbstatus.Items.AddRange(New String() {"Active", "Inactive"})
        cmbstatus.SelectedIndex = 0
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        ' --- Validation ---
        If String.IsNullOrWhiteSpace(txtservicename.Text) Then
            MsgBox("Service name is required.", MsgBoxStyle.Exclamation)
            txtservicename.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtprice.Text) OrElse Not IsNumeric(txtprice.Text) Then
            MsgBox("Enter a valid numeric price.", MsgBoxStyle.Exclamation)
            txtprice.Focus()
            Exit Sub
        End If

        If cmbstatus.SelectedIndex = -1 Then
            MsgBox("Select a status.", MsgBoxStyle.Exclamation)
            cmbstatus.Focus()
            Exit Sub
        End If

        ' --- Build Insert Query ---
        Dim sql As String =
            "INSERT INTO tblservices (name, price, status) VALUES (" &
            "'" & txtservicename.Text.Trim().Replace("'", "''") & "', " &
            Convert.ToDecimal(txtprice.Text).ToString("F2") & ", " &
            "'" & cmbstatus.SelectedItem.ToString() & "')"

        ' --- Execute ---
        Try
            SetQuery(sql)
            MsgBox("Service added successfully.", MsgBoxStyle.Information)

            ' Optional: Log activity
            LogActivity("Services", "Added new service: " & txtservicename.Text, GetLastInsertedID())

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Error saving service: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
