Imports System.Windows.Forms
Imports System.Data

Public Class DlgAddress

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
        Dim dt As DataTable = GetDataTable("SELECT purokid, purokname FROM tblpuroks WHERE barangayid=" & barangayId & " ORDER BY purokname")

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

    Private Function GetDataTable(sql As String) As DataTable
        Dim tableName As String = "tmp_" & Guid.NewGuid().ToString("N")
        GetQuery(sql, tableName)
        Return ds.Tables(tableName).Copy()
    End Function

    '==========================
    ' Add Barangay
    '==========================
    Private Sub btnaddbarangay_Click(sender As Object, e As EventArgs) Handles btnaddbarangay.Click
        Dim name As String = InputBox("Enter Barangay Name:", "Add Barangay")
        If String.IsNullOrWhiteSpace(name) Then Exit Sub

        SetQuery("INSERT INTO tblbarangays (barangayname) VALUES ('" & name.Replace("'", "''") & "')")
        LoadBarangays()
    End Sub

    '==========================
    ' Edit Barangay
    '==========================
    Private Sub btneditbarangay_Click(sender As Object, e As EventArgs) Handles btneditbarangay.Click
        If lvbarangay.SelectedItems.Count = 0 Then Exit Sub

        Dim id As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)
        Dim oldName As String = lvbarangay.SelectedItems(0).SubItems(1).Text

        Dim newName As String = InputBox("Edit Barangay Name:", "Edit Barangay", oldName)
        If String.IsNullOrWhiteSpace(newName) Then Exit Sub

        SetQuery("UPDATE tblbarangays SET barangayname='" & newName.Replace("'", "''") & "' WHERE barangayid=" & id)
        LoadBarangays()
    End Sub

    '==========================
    ' Delete Barangay
    '==========================
    Private Sub btndeletebarangay_Click(sender As Object, e As EventArgs) Handles btndeletebarangay.Click
        If lvbarangay.SelectedItems.Count = 0 Then Exit Sub

        ' Get the selected barangay ID
        Dim id As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)

        ' Check if any customers are using this barangay
        Dim dt As DataTable = GetDataTable("SELECT COUNT(*) AS cnt FROM tblcustomers WHERE barangayid=" & id)
        Dim count As Integer = CInt(dt.Rows(0)("cnt"))

        If count > 0 Then
            MsgBox("Cannot delete this Barangay because it has assigned customers.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("Delete this Barangay? All its Puroks will also be removed.", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm Delete") = MsgBoxResult.No Then Exit Sub

        ' Safe to delete
        SetQuery("DELETE FROM tblbarangays WHERE barangayid=" & id)
        LoadBarangays()
    End Sub



    '==========================
    ' Add Purok
    '==========================
    Private Sub btnaddpurok_Click(sender As Object, e As EventArgs) Handles btnaddpurok.Click
        If lvbarangay.SelectedItems.Count = 0 Then Exit Sub

        Dim barangayId As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)
        Dim name As String = InputBox("Enter Purok Name:", "Add Purok")
        If String.IsNullOrWhiteSpace(name) Then Exit Sub

        SetQuery("INSERT INTO tblpuroks (barangayid, purokname) VALUES (" & barangayId & ", '" & name.Replace("'", "''") & "')")
        LoadPuroks(barangayId)
    End Sub

    '==========================
    ' Edit Purok
    '==========================
    Private Sub btneditpurok_Click(sender As Object, e As EventArgs) Handles btneditpurok.Click
        If lvpurok.SelectedItems.Count = 0 Then Exit Sub

        Dim id As Integer = CInt(lvpurok.SelectedItems(0).SubItems(0).Text)
        Dim oldName As String = lvpurok.SelectedItems(0).SubItems(1).Text

        Dim newName As String = InputBox("Edit Purok Name:", "Edit Purok", oldName)
        If String.IsNullOrWhiteSpace(newName) Then Exit Sub

        SetQuery("UPDATE tblpuroks SET purokname='" & newName.Replace("'", "''") & "' WHERE purokid=" & id)

        Dim barangayId As Integer = CInt(lvbarangay.SelectedItems(0).SubItems(0).Text)
        LoadPuroks(barangayId)
    End Sub

    '==========================
    ' Delete Purok
    '==========================
    Private Sub btndeletepurok_Click(sender As Object, e As EventArgs) Handles btndeletepurok.Click
        If lvpurok.SelectedItems.Count = 0 Then Exit Sub

        ' Get the selected purok ID
        Dim id As Integer = CInt(lvpurok.SelectedItems(0).SubItems(0).Text)

        ' Check if any customers are using this purok
        Dim dt As DataTable = GetDataTable("SELECT COUNT(*) AS cnt FROM tblcustomers WHERE purokid=" & id)
        Dim count As Integer = CInt(dt.Rows(0)("cnt"))

        If count > 0 Then
            MsgBox("Cannot delete this Purok because it has assigned customers.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("Delete this Purok?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm Delete") = MsgBoxResult.No Then Exit Sub

        ' Safe to delete
        SetQuery("DELETE FROM tblpuroks WHERE purokid=" & id)

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
