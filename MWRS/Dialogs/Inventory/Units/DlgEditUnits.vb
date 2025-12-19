Public Class DlgEditUnits

    ' Property to hold the ID of the unit being edited
    Public Property UnitID As Integer

    Private Sub DlgEditUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load existing unit data
        If UnitID <= 0 Then Exit Sub

        Dim sql As String = "SELECT * FROM tblproductunit WHERE unitid = " & UnitID
        GetQuery(sql, "tblproductunit")

        If ds.Tables("tblproductunit").Rows.Count > 0 Then
            txtUnitType.Text = ds.Tables("tblproductunit").Rows(0)("unittype").ToString()
        End If
    End Sub


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        ' Validate input
        If String.IsNullOrWhiteSpace(txtUnitType.Text) Then
            MessageBox.Show("Unit type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitType.Focus()
            Exit Sub
        End If

        ' Update the database
        Dim sql As String = "UPDATE tblproductunit SET unittype='" & txtunittype.Text.Replace("'", "''") & "' WHERE unitid=" & UnitID
        SetQuery(sql)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
