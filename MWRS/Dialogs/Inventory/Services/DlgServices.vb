Public Class DlgServices

    Private Sub DlgServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServices()
    End Sub

    Private Sub LoadServices(Optional ByVal keyword As String = "")
        lvservices.Items.Clear()

        Dim sql As String = "SELECT serviceid, name, price, status FROM tblservices"

        If keyword <> "" Then
            sql &= " WHERE name LIKE '%" & keyword.Replace("'", "''") & "%'"
        End If

        GetQuery(sql, "tblservices")

        For Each row As DataRow In ds.Tables("tblservices").Rows
            Dim item As New ListViewItem(row("serviceid").ToString())
            item.SubItems.Add(row("name").ToString())
            item.SubItems.Add(Format(CDec(row("price")), "₱#,##0.00"))
            item.SubItems.Add(row("status").ToString())
            lvservices.Items.Add(item)
        Next
    End Sub

    '=============================
    ' ADD SERVICE
    '=============================
    Private Sub btnaddservice_Click(sender As Object, e As EventArgs) Handles btnaddservice.Click
        Dim dlg As New DlgAddServices
        If dlg.ShowDialog() = DialogResult.OK Then
            LoadServices()
        End If
    End Sub

    '=============================
    ' EDIT SERVICE
    '=============================
    Private Sub btneditservice_Click(sender As Object, e As EventArgs) Handles btneditservice.Click
        EditSelectedService() ' Call the shared logic
    End Sub

    ' Helper method to contain the edit logic
    Private Sub EditSelectedService()
        If lvservices.SelectedItems.Count = 0 Then
            MsgBox("Select a service to edit.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim id As Integer = CInt(lvservices.SelectedItems(0).Text)
        Dim dlg As New DlgEditServices
        dlg.ServiceID = id
        If dlg.ShowDialog() = DialogResult.OK Then
            LoadServices()
        End If
    End Sub

    '=============================
    ' DELETE SERVICE
    '=============================
    Private Sub btndeleteservice_Click(sender As Object, e As EventArgs) Handles btndeleteservice.Click
        If lvservices.SelectedItems.Count = 0 Then
            MsgBox("Select a service to delete.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim id As Integer = CInt(lvservices.SelectedItems(0).Text)
        Dim name As String = lvservices.SelectedItems(0).SubItems(1).Text

        If MsgBox("Are you sure you want to delete '" & name & "'?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Dim sql As String = "DELETE FROM tblservices WHERE serviceid = " & id
            SetQuery(sql)
            LogActivity("Services", "Deleted service: " & name, id)
            LoadServices()
        End If
    End Sub

    '=============================
    ' DOUBLE CLICK TO EDIT SERVICE
    '=============================
    Private Sub lvservices_DoubleClick(sender As Object, e As EventArgs) Handles lvservices.DoubleClick
        EditSelectedService() ' *** This is the change: Call the edit logic ***
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