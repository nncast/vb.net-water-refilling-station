Public Class A6_Customer
    Public Property NewCustID As Integer

    Private Sub Customers_A_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadBarangays()
            LoadPuroks()
            fill()
        Catch ex As Exception
            MsgBox("Error loading customers: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        Try
            If DlgAddCustomer.ShowDialog() = DialogResult.OK Then
                fill()
            End If
        Catch ex As Exception
            MsgBox("Error adding new customer: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        Try
            If lvcustomers.SelectedItems.Count = 0 Then
                MsgBox("Please select a customer to edit.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim selectedID As Integer = CInt(lvcustomers.SelectedItems(0).Text)
            DlgUpdateCustomer.SelectedCustID = selectedID

            If DlgUpdateCustomer.ShowDialog() = DialogResult.OK Then
                fill()
                LogActivity("Customer", "Updated customer information", selectedID)
            End If
        Catch ex As Exception
            MsgBox("Error editing customer: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            If lvcustomers.SelectedItems.Count = 0 Then
                MsgBox("Please select a customer to delete.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim selectedID As Integer = CInt(lvcustomers.SelectedItems(0).Text)

            ' --- Check for linked records ---
            Dim checkSql As String =
                "SELECT COUNT(*) AS cnt FROM (" &
                "SELECT custid FROM tblorders WHERE custid = " & selectedID & " " &
                "UNION ALL " &
                "SELECT custid FROM tblsales WHERE custid = " & selectedID & " " &
                "UNION ALL " &
                "SELECT custid FROM tblcustomertransactions WHERE custid = " & selectedID &
                ") AS linked"

            GetQuery(checkSql, "checklinks")

            Dim recordCount As Integer = 0
            If ds.Tables("checklinks").Rows.Count > 0 Then
                recordCount = CInt(ds.Tables("checklinks").Rows(0)("cnt"))
            End If

            ' --- Prevent deletion if linked ---
            If recordCount > 0 Then
                MsgBox("Cannot delete this customer because they have existing transactions.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            ' --- Confirm deletion ---
            Dim result = MsgBox("Are you sure you want to delete this customer?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
            If result = MsgBoxResult.No Then Exit Sub

            ' --- Remove balance record first ---
            Dim sqlBalance As String = "DELETE FROM tblcustomerbalance WHERE custid = " & selectedID
            SetQuery(sqlBalance)

            ' --- Delete customer ---
            Dim sqlCust As String = "DELETE FROM tblcustomers WHERE custid = " & selectedID
            SetQuery(sqlCust)

            LogActivity("Customer", "Deleted customer record", selectedID)
            MsgBox("Customer deleted successfully.", MsgBoxStyle.Information)
            fill()

        Catch ex As Exception
            MsgBox("Error deleting customer: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Try
            fill(txtsearch.Text.Trim())
        Catch ex As Exception
            MsgBox("Error searching customers: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub fill(Optional ByVal keyword As String = "")
        Try
            lvcustomers.Items.Clear()

            Dim barangayId As Integer = CInt(cmbbarangay.SelectedValue)
            Dim purokId As Integer = CInt(cmbpurok.SelectedValue)

            Dim sql As String =
                "SELECT c.custid, c.fullname, " &
                "COALESCE(b.barangayname, '') AS barangay, " &
                "COALESCE(p.purokname, '') AS purok, " &
                "c.contact, c.notes, IFNULL(cb.balance, 0.00) AS balance " &
                "FROM tblcustomers c " &
                "LEFT JOIN tblbarangays b ON c.barangayid = b.barangayid " &
                "LEFT JOIN tblpuroks p ON c.purokid = p.purokid " &
                "LEFT JOIN tblcustomerbalance cb ON c.custid = cb.custid " &
                "WHERE 1=1 "

            ' Filter barangay
            If barangayId > 0 Then
                sql &= " AND c.barangayid=" & barangayId
            End If

            ' Filter purok
            If purokId > 0 Then
                sql &= " AND c.purokid=" & purokId
            End If

            ' Keyword filter
            If keyword <> "" Then
                Dim k As String = keyword.Replace("'", "''")
                sql &= " AND (c.fullname LIKE '%" & k & "%' " &
                       "OR b.barangayname LIKE '%" & k & "%' " &
                       "OR p.purokname LIKE '%" & k & "%' " &
                       "OR c.contact LIKE '%" & k & "%' " &
                       "OR c.notes LIKE '%" & k & "%')"
            End If

            sql &= " ORDER BY c.fullname"

            ds.Tables.Clear()
            GetQuery(sql, "tblcustomers")

            If Not ds.Tables.Contains("tblcustomers") Then Exit Sub

            For Each row As DataRow In ds.Tables("tblcustomers").Rows
                Dim item As New ListViewItem(row("custid").ToString())
                item.SubItems.Add(row("fullname").ToString())
                item.SubItems.Add(row("barangay").ToString())
                item.SubItems.Add(row("purok").ToString())
                item.SubItems.Add(row("contact").ToString())
                item.SubItems.Add(row("notes").ToString())
                item.SubItems.Add(Format(CDec(row("balance")), "0.00"))
                lvcustomers.Items.Add(item)
            Next

        Catch ex As Exception
            MsgBox("Error filtering customers: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub lvcustomers_DoubleClick(sender As Object, e As EventArgs) Handles lvcustomers.DoubleClick
        Try
            If lvcustomers.SelectedItems.Count = 0 Then Exit Sub

            Dim selectedID As Integer = CInt(lvcustomers.SelectedItems(0).Text)
            Dim editDlg As New DlgUpdateCustomer()
            editDlg.SelectedCustID = selectedID

            If editDlg.ShowDialog() = DialogResult.OK Then
                fill()
                LogActivity("Customer", "Updated customer via double-click", selectedID)
            End If
        Catch ex As Exception
            MsgBox("Error editing customer via double-click: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnadjustbalance_Click(sender As Object, e As EventArgs) Handles btnadjustbalance.Click
        Try
            If lvcustomers.SelectedItems.Count = 0 Then
                MsgBox("Please select a customer to adjust balance.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim selectedId As Integer = CInt(lvcustomers.SelectedItems(0).SubItems(0).Text)
            With DlgAdjustCustomerBalance
                .SelectedCustID = selectedId
                If .ShowDialog() = DialogResult.OK Then
                    fill()
                End If
            End With
        Catch ex As Exception
            MsgBox("Error adjusting customer balance: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub LoadBarangays()
        Dim dt As DataTable = GetDataTable("SELECT barangayid, barangayname FROM tblbarangays ORDER BY barangayname")

        Dim row As DataRow = dt.NewRow()
        row("barangayid") = 0
        row("barangayname") = "-- All Barangays --"
        dt.Rows.InsertAt(row, 0)

        cmbbarangay.ValueMember = "barangayid"
        cmbbarangay.DisplayMember = "barangayname"
        cmbbarangay.DataSource = dt

        cmbbarangay.SelectedIndex = 0   ' Prevent DataRowView problems
    End Sub

    Public Sub LoadPuroks(Optional barangayId As Integer = 0)
        Dim dt As New DataTable
        dt.Columns.Add("purokid", GetType(Integer))
        dt.Columns.Add("purokname", GetType(String))

        Dim rowAll As DataRow = dt.NewRow()
        rowAll("purokid") = 0
        rowAll("purokname") = "-- All Puroks --"
        dt.Rows.Add(rowAll)

        ' No selected barangay → return only ALL
        If barangayId = 0 Then
            cmbpurok.ValueMember = "purokid"
            cmbpurok.DisplayMember = "purokname"
            cmbpurok.DataSource = dt
            cmbpurok.SelectedIndex = 0
            Exit Sub
        End If

        ' Load real puroks
        Dim realPuroks As DataTable =
            GetDataTable("SELECT purokid, purokname FROM tblpuroks WHERE barangayid=" & barangayId & " ORDER BY purokname")

        For Each r As DataRow In realPuroks.Rows
            Dim nr As DataRow = dt.NewRow()
            nr("purokid") = CInt(r("purokid"))
            nr("purokname") = r("purokname").ToString()
            dt.Rows.Add(nr)
        Next

        cmbpurok.ValueMember = "purokid"
        cmbpurok.DisplayMember = "purokname"
        cmbpurok.DataSource = dt

        cmbpurok.SelectedIndex = 0
    End Sub


    Private Function GetDataTable(sql As String) As DataTable
        Dim tableName As String = "tmp_" & Guid.NewGuid().ToString("N")
        GetQuery(sql, tableName)
        Return ds.Tables(tableName).Copy()
    End Function
    Private Sub cmbbarangay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbarangay.SelectedIndexChanged
        Try
            ' When barangay changes, reload filtered puroks
            Dim barangayId As Integer = CInt(cmbbarangay.SelectedValue)
            LoadPuroks(barangayId)

            fill()
        Catch
        End Try
    End Sub

    Private Sub cmbpurok_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpurok.SelectedIndexChanged
        Try
            fill()
        Catch
        End Try
    End Sub

    Private Sub btnAddress_Click(sender As Object, e As EventArgs) Handles btnAddress.Click
        Try
            If DlgAddress.ShowDialog() = DialogResult.OK Then
                fill()
            End If
        Catch ex As Exception
            MsgBox("Error adding new customer: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
