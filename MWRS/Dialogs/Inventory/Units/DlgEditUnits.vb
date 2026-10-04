Public Class DlgEditUnits

    ' Property to hold the ID of the unit being edited
    Public Property UnitID As Integer

    Private Sub DlgEditUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load existing unit data
        If UnitID <= 0 Then Exit Sub

        GetQuery("SELECT * FROM tblproductunit WHERE unitid = @u", "tblproductunit", P("@u", UnitID))

        If ds.Tables("tblproductunit").Rows.Count > 0 Then
            txtUnitType.Text = ds.Tables("tblproductunit").Rows(0)("unittype").ToString()
        End If
    End Sub


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim unitType As String = txtUnitType.Text.Trim()

        ' Validate input
        If unitType = "" Then
            MessageBox.Show("Unit type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitType.Focus()
            Exit Sub
        End If

        If unitType.Length > 50 Then
            MessageBox.Show("Unit type can be at most 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitType.Focus()
            Exit Sub
        End If

        If CInt(GetValue("SELECT COUNT(*) FROM tblproductunit WHERE unittype = @t AND unitid <> @u", P("@t", unitType), P("@u", UnitID))) > 0 Then
            MessageBox.Show("Unit type already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitType.Focus()
            Exit Sub
        End If

        ' Update the database
        If Not SetQuery("UPDATE tblproductunit SET unittype = @t WHERE unitid = @u", P("@t", unitType), P("@u", UnitID)) Then Exit Sub
        LogActivity("Units", "Updated unit: " & unitType, UnitID)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
