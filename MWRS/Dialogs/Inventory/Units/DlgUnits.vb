Public Class DlgUnits

    ' fill the ListView
    Public Sub Fill(Optional ByVal keyword As String = "")
        lvunits.Items.Clear()

        Dim sql As String = "SELECT * FROM tblproductunit"
        If keyword <> "" Then
            ' NOTE: While Replace("'", "''") offers basic protection, 
            ' it's safer to use parameterized queries for production code.
            sql &= " WHERE unittype LIKE '%" & keyword.Replace("'", "''") & "%'"
        End If
        sql &= " ORDER BY unittype"

        ' Populate the DataSet
        GetQuery(sql, "tblproductunit")

        ' Loop through dataset and add to ListView
        For Each row As DataRow In ds.Tables("tblproductunit").Rows
            Dim item As New ListViewItem(row("unitid").ToString())
            item.SubItems.Add(row("unittype").ToString())
            lvunits.Items.Add(item)
        Next
    End Sub


    Private Sub DlgUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill()
    End Sub

    Private Sub btnaddunit_Click(sender As Object, e As EventArgs) Handles btnaddunit.Click
        If DlgAddUnits.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Fill()
        End If
    End Sub

    '=============================
    ' EDIT UNIT Logic (Extracted)
    '=============================
    Private Sub EditSelectedUnit()
        If lvunits.SelectedItems.Count = 0 Then
            MessageBox.Show("Select a unit to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Use a local variable for the dialog for best practice
        Dim dlg As New DlgEditUnits
        dlg.UnitID = Convert.ToInt32(lvunits.SelectedItems(0).Text)

        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Fill()
        End If
    End Sub

    Private Sub btneditunit_Click(sender As Object, e As EventArgs) Handles btneditunit.Click
        EditSelectedUnit() ' Call the shared logic
    End Sub

    '======================================
    ' DOUBLE-CLICK TO EDIT UNIT (New Handler)
    '======================================
    Private Sub lvunits_DoubleClick(sender As Object, e As EventArgs) Handles lvunits.DoubleClick
        EditSelectedUnit() ' Trigger the edit dialog
    End Sub

    Private Sub btndeleteunit_Click(sender As Object, e As EventArgs) Handles btndeleteunit.Click
        If lvunits.SelectedItems.Count = 0 Then
            MessageBox.Show("Select a unit to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim unitId As Integer = Convert.ToInt32(lvunits.SelectedItems(0).Text)
        Dim unitType As String = lvunits.SelectedItems(0).SubItems(1).Text

        If MessageBox.Show("Are you sure you want to delete the unit '" & unitType & "'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            ' Use SetQuery to delete
            SetQuery("DELETE FROM tblproductunit WHERE unitid=" & unitId)
            Fill()
        End If
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class