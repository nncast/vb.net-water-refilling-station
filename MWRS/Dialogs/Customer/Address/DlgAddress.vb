Imports System.Windows.Forms
Imports System.Data

Public Class DlgAddress

    ' List columns: 0 = hidden ID, 1 = row number, 2 = name.
    Private Const NameColumn As Integer = 2
    Private Const MaxNameLength As Integer = 100

    Private Sub DlgAddress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBarangays()
        lvpurok.Enabled = False
    End Sub

    '==========================
    ' Load Barangays
    '==========================
    Private Sub LoadBarangays()
        Dim dt As DataTable = GetDataTable("SELECT barangayid, barangayname FROM tblbarangays ORDER BY barangayname")

        lvbarangay.Items.Clear()
        Dim rowNumber As Integer = 1
        For Each r As DataRow In dt.Rows
            Dim item As New ListViewItem(r("barangayid").ToString()) ' hidden ID
            item.SubItems.Add(rowNumber.ToString())                   ' # column
            item.SubItems.Add(r("barangayname").ToString())          ' name column
            lvbarangay.Items.Add(item)
            rowNumber += 1
        Next

        lvpurok.Items.Clear()
        lvpurok.Enabled = False
    End Sub





    '==========================
    ' Barangay Selection Changed
    '==========================
    Private Sub lvbarangay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvbarangay.SelectedIndexChanged
        If lvbarangay.SelectedItems.Count = 0 Then
            lvpurok.Items.Clear()
            lvpurok.Enabled = False
            Exit Sub
        End If

        Dim id As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)
        LoadPuroks(id)
    End Sub

    '==========================
    ' Load Puroks for Selected Barangay
    '==========================
    Private Sub LoadPuroks(barangayId As Integer)
        Dim dt As DataTable = GetDataTable("SELECT purokid, purokname FROM tblpuroks WHERE barangayid = @b ORDER BY purokname", P("@b", barangayId))

        lvpurok.Items.Clear()
        Dim rowNumber As Integer = 1
        For Each r As DataRow In dt.Rows
            Dim item As New ListViewItem(r("purokid").ToString())  ' hidden ID
            item.SubItems.Add(rowNumber.ToString())                 ' # column
            item.SubItems.Add(r("purokname").ToString())           ' name column
            lvpurok.Items.Add(item)
            rowNumber += 1
        Next
        lvpurok.Enabled = True
    End Sub

    Private Function GetDataTable(sql As String, ParamArray params() As MySqlParameter) As DataTable
        Dim tableName As String = "tmp_" & Guid.NewGuid().ToString("N")
        GetQuery(sql, tableName, params)
        Dim copy As DataTable = ds.Tables(tableName).Copy()
        ds.Tables.Remove(tableName)
        Return copy
    End Function

    ' Asks for a name; returns Nothing when cancelled or invalid.
    Private Function AskName(prompt As String, title As String, Optional current As String = "") As String
        Dim name As String = InputBox(prompt, title, current).Trim()
        If name = "" Then Return Nothing

        If name.Length > MaxNameLength Then
            MsgBox("The name can be at most " & MaxNameLength & " characters.", MsgBoxStyle.Exclamation)
            Return Nothing
        End If
        Return name
    End Function

    '==========================
    ' Add Barangay
    '==========================
    Private Sub btnaddbarangay_Click(sender As Object, e As EventArgs) Handles btnaddbarangay.Click
        Dim name As String = AskName("Enter Barangay Name:", "Add Barangay")
        If name Is Nothing Then Exit Sub

        If BarangayExists(name, 0) Then Exit Sub
        SetQuery("INSERT INTO tblbarangays (barangayname) VALUES (@n)", P("@n", name))
        LoadBarangays()
    End Sub

    '==========================
    ' Edit Barangay
    '==========================
    Private Sub btneditbarangay_Click(sender As Object, e As EventArgs) Handles btneditbarangay.Click
        If lvbarangay.SelectedItems.Count = 0 Then Exit Sub

        Dim id As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)
        Dim oldName As String = lvbarangay.SelectedItems(0).SubItems(NameColumn).Text

        Dim newName As String = AskName("Edit Barangay Name:", "Edit Barangay", oldName)
        If newName Is Nothing Then Exit Sub

        If BarangayExists(newName, id) Then Exit Sub
        SetQuery("UPDATE tblbarangays SET barangayname = @n WHERE barangayid = @id", P("@n", newName), P("@id", id))
        LoadBarangays()
    End Sub

    Private Function BarangayExists(name As String, exceptId As Integer) As Boolean
        If CInt(GetValue("SELECT COUNT(*) FROM tblbarangays WHERE barangayname = @n AND barangayid <> @id", P("@n", name), P("@id", exceptId))) > 0 Then
            MsgBox("A barangay named '" & name & "' already exists.", MsgBoxStyle.Exclamation)
            Return True
        End If
        Return False
    End Function

    '==========================
    ' Delete Barangay
    '==========================
    Private Sub btndeletebarangay_Click(sender As Object, e As EventArgs) Handles btndeletebarangay.Click
        If lvbarangay.SelectedItems.Count = 0 Then Exit Sub

        ' Get the selected barangay ID
        Dim id As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)

        ' Check if any customers are using this barangay or one of its puroks
        Dim count As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblcustomers WHERE barangayid = @id OR purokid IN (SELECT purokid FROM tblpuroks WHERE barangayid = @id)", P("@id", id)))

        If count > 0 Then
            MsgBox("Cannot delete this Barangay because it has assigned customers.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("Delete this Barangay? All its Puroks will also be removed.", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm Delete") = MsgBoxResult.No Then Exit Sub

        ' Safe to delete
        SetQuery("DELETE FROM tblbarangays WHERE barangayid = @id", P("@id", id))
        LoadBarangays()
    End Sub



    '==========================
    ' Add Purok
    '==========================
    Private Sub btnaddpurok_Click(sender As Object, e As EventArgs) Handles btnaddpurok.Click
        If lvbarangay.SelectedItems.Count = 0 Then Exit Sub

        Dim barangayId As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)
        Dim name As String = AskName("Enter Purok Name:", "Add Purok")
        If name Is Nothing Then Exit Sub

        If PurokExists(barangayId, name, 0) Then Exit Sub
        SetQuery("INSERT INTO tblpuroks (barangayid, purokname) VALUES (@b, @n)", P("@b", barangayId), P("@n", name))
        LoadPuroks(barangayId)
    End Sub

    '==========================
    ' Edit Purok
    '==========================
    Private Sub btneditpurok_Click(sender As Object, e As EventArgs) Handles btneditpurok.Click
        If lvpurok.SelectedItems.Count = 0 OrElse lvbarangay.SelectedItems.Count = 0 Then Exit Sub

        Dim id As Integer = CInt(lvpurok.SelectedItems(0).SubItems(0).Text)
        Dim oldName As String = lvpurok.SelectedItems(0).SubItems(NameColumn).Text
        Dim barangayId As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)

        Dim newName As String = AskName("Edit Purok Name:", "Edit Purok", oldName)
        If newName Is Nothing Then Exit Sub

        If PurokExists(barangayId, newName, id) Then Exit Sub
        SetQuery("UPDATE tblpuroks SET purokname = @n WHERE purokid = @id", P("@n", newName), P("@id", id))
        LoadPuroks(barangayId)
    End Sub

    Private Function PurokExists(barangayId As Integer, name As String, exceptId As Integer) As Boolean
        If CInt(GetValue("SELECT COUNT(*) FROM tblpuroks WHERE barangayid = @b AND purokname = @n AND purokid <> @id",
                         P("@b", barangayId), P("@n", name), P("@id", exceptId))) > 0 Then
            MsgBox("This barangay already has a purok named '" & name & "'.", MsgBoxStyle.Exclamation)
            Return True
        End If
        Return False
    End Function

    '==========================
    ' Delete Purok
    '==========================
    Private Sub btndeletepurok_Click(sender As Object, e As EventArgs) Handles btndeletepurok.Click
        If lvpurok.SelectedItems.Count = 0 OrElse lvbarangay.SelectedItems.Count = 0 Then Exit Sub

        ' Get the selected purok ID
        Dim id As Integer = CInt(lvpurok.SelectedItems(0).SubItems(0).Text)

        ' Check if any customers are using this purok
        Dim count As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblcustomers WHERE purokid = @id", P("@id", id)))

        If count > 0 Then
            MsgBox("Cannot delete this Purok because it has assigned customers.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("Delete this Purok?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm Delete") = MsgBoxResult.No Then Exit Sub

        ' Safe to delete
        SetQuery("DELETE FROM tblpuroks WHERE purokid = @id", P("@id", id))

        Dim barangayId As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)
        LoadPuroks(barangayId)
    End Sub



    '==========================
    ' Save and Cancel
    '==========================
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
