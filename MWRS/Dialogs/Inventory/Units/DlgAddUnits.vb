Public Class DlgAddUnits

    Private Sub DlgAddUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' The dialog is reused, so don't show the unit typed last time.
        txtunittype.Clear()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim unitType As String = txtunittype.Text.Trim()

        ' Validate input
        If unitType = "" Then
            MessageBox.Show("Unit type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtunittype.Focus()
            Exit Sub
        End If

        If unitType.Length > 50 Then
            MessageBox.Show("Unit type can be at most 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtunittype.Focus()
            Exit Sub
        End If

        ' Check if unit type already exists
        If CInt(GetValue("SELECT COUNT(*) FROM tblproductunit WHERE unittype = @u", P("@u", unitType))) > 0 Then
            MessageBox.Show("Unit type already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtunittype.Focus()
            Exit Sub
        End If

        ' Insert into database
        If Not SetQuery("INSERT INTO tblproductunit (unittype) VALUES (@u)", P("@u", unitType)) Then Exit Sub
        LogActivity("Units", "Added unit: " & unitType, GetLastInsertedID())

        ' Success message
        MessageBox.Show("Unit added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Close dialog with OK result
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
