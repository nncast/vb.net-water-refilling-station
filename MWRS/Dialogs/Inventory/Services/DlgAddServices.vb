Public Class DlgAddServices

    Private Sub DlgAddServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate combo box for status
        cmbstatus.Items.Clear()
        cmbstatus.Items.AddRange(New String() {"Active", "Inactive"})
        cmbstatus.SelectedIndex = 0
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim name As String = txtservicename.Text.Trim()
        Dim price As Decimal

        ' --- Validation ---
        If name = "" Then
            MsgBox("Service name is required.", MsgBoxStyle.Exclamation)
            txtservicename.Focus()
            Exit Sub
        End If

        If name.Length > 100 Then
            MsgBox("Service name can be at most 100 characters.", MsgBoxStyle.Exclamation)
            txtservicename.Focus()
            Exit Sub
        End If

        If Not Decimal.TryParse(txtprice.Text.Trim(), price) OrElse price < 0 Then
            MsgBox("Enter a valid numeric price.", MsgBoxStyle.Exclamation)
            txtprice.Focus()
            Exit Sub
        End If

        If cmbstatus.SelectedIndex = -1 Then
            MsgBox("Select a status.", MsgBoxStyle.Exclamation)
            cmbstatus.Focus()
            Exit Sub
        End If

        If CInt(GetValue("SELECT COUNT(*) FROM tblservices WHERE name = @n", P("@n", name))) > 0 Then
            MsgBox("A service with this name already exists.", MsgBoxStyle.Exclamation)
            txtservicename.Focus()
            Exit Sub
        End If

        ' --- Execute ---
        If Not SetQuery("INSERT INTO tblservices (name, price, status) VALUES (@n, @p, @s)",
                        P("@n", name), P("@p", price), P("@s", cmbstatus.SelectedItem.ToString())) Then Exit Sub

        LogActivity("Services", "Added new service: " & name, GetLastInsertedID())
        MsgBox("Service added successfully.", MsgBoxStyle.Information)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
