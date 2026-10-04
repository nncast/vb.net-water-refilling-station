Public Class DlgServices

    Private Sub DlgServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServices()
    End Sub

    Private Sub LoadServices(Optional ByVal keyword As String = "")
        lvservices.Items.Clear()

        Dim sql As String = "SELECT serviceid, name, price, status FROM tblservices"

        If keyword <> "" Then
            sql &= " WHERE name LIKE @k"
        End If

        GetQuery(sql, "tblservices", P("@k", "%" & keyword & "%"))

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

        ' Orders keep a link to the services they used, so those can't be deleted.
        Dim used As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblorderitems WHERE serviceid = @s", P("@s", id)))
        If used > 0 Then
            If MsgBox("'" & name & "' is used in " & used & " order item(s) and can't be deleted." & vbCrLf &
                      "Would you like to set its status to Inactive instead?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Cannot Delete") = MsgBoxResult.Yes Then
                If SetQuery("UPDATE tblservices SET status = 'Inactive' WHERE serviceid = @s", P("@s", id)) Then
                    LogActivity("Services", "Set Inactive: " & name, id)
                    LoadServices()
                End If
            End If
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete '" & name & "'?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            If SetQuery("DELETE FROM tblservices WHERE serviceid = @s", P("@s", id)) Then
                LogActivity("Services", "Deleted service: " & name, id)
            End If
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
