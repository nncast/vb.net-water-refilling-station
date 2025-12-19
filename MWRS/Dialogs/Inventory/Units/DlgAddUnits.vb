Public Class DlgAddUnits

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        ' Validate input
        If String.IsNullOrWhiteSpace(txtunittype.Text) Then
            MessageBox.Show("Unit type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtunittype.Focus()
            Exit Sub
        End If

        ' Optional: Check if unit type already exists
        Dim checkSql As String = "SELECT * FROM tblproductunit WHERE unittype = '" & txtunittype.Text.Replace("'", "''") & "'"
        GetQuery(checkSql, "checkDup")
        If ds.Tables("checkDup").Rows.Count > 0 Then
            MessageBox.Show("Unit type already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtunittype.Focus()
            Exit Sub
        End If

        ' Insert into database
        Dim sql As String = "INSERT INTO tblproductunit (unittype) VALUES ('" & txtunittype.Text.Replace("'", "''") & "')"
        SetQuery(sql)

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
