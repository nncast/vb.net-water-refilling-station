Public Class DlgUpdateCustomer

    Public Property SelectedCustID As Integer    ' Passed from parent form

    ' ==========================================================
    ' SAFE COMBOBOX VALUE
    ' ==========================================================
    Private Function GetSafeValue(cb As ComboBox) As Integer
        If cb Is Nothing Then Return 0
        If cb.SelectedIndex = -1 Then Return 0
        If cb.SelectedValue Is Nothing Then Return 0
        If TypeOf cb.SelectedValue Is Integer Then
            Return CInt(cb.SelectedValue)
        End If
        Return 0
    End Function

    ' ==========================================================
    ' Form Load
    ' ==========================================================
    Private Sub EditCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadBarangays()
            LoadCustomerData()   ' After loading combo sources
        Catch ex As Exception
            MsgBox("Error during load: " & ex.Message, MsgBoxStyle.Critical)
            Me.Close()
        End Try
    End Sub


    ' ==========================================================
    ' Load Barangays
    ' ==========================================================
    Private Sub LoadBarangays()
        Dim dt As DataTable = GetDataTable(
            "SELECT barangayid, barangayname FROM tblbarangays ORDER BY barangayname"
        )

        cmbBarangay.DataSource = dt
        cmbBarangay.DisplayMember = "barangayname"
        cmbBarangay.ValueMember = "barangayid"
        cmbBarangay.DropDownStyle = ComboBoxStyle.DropDownList
        cmbBarangay.SelectedIndex = -1
    End Sub

    Private Function GetDataTable(sql As String, ParamArray params() As MySqlParameter) As DataTable
        Dim tableName As String = "tmp_" & Guid.NewGuid().ToString("N")
        GetQuery(sql, tableName, params)
        Dim copy As DataTable = ds.Tables(tableName).Copy()
        ds.Tables.Remove(tableName)
        Return copy
    End Function


    ' ==========================================================
    ' Load Puroks (Filtered)
    ' ==========================================================
    Private Sub LoadPuroks()
        Dim barangayId As Integer = GetSafeValue(cmbBarangay)

        If barangayId = 0 Then
            cmbPurok.DataSource = Nothing
            Exit Sub
        End If

        Dim dt As DataTable = GetDataTable(
            "SELECT purokid, purokname FROM tblpuroks WHERE barangayid = @b ORDER BY purokname", P("@b", barangayId)
        )

        cmbPurok.DataSource = dt
        cmbPurok.DisplayMember = "purokname"
        cmbPurok.ValueMember = "purokid"
        cmbPurok.DropDownStyle = ComboBoxStyle.DropDownList
        cmbPurok.SelectedIndex = -1
    End Sub

    Private Sub cmbBarangay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBarangay.SelectedIndexChanged
        If Not cmbBarangay.Focused Then Exit Sub
        LoadPuroks()
    End Sub


    ' ==========================================================
    ' Load Customer Details
    ' ==========================================================
    Private Sub LoadCustomerData()
        Dim sql As String = "SELECT * FROM tblcustomers WHERE custid = @c"
        GetQuery(sql, "custinfo", P("@c", SelectedCustID))

        If Not ds.Tables.Contains("custinfo") OrElse ds.Tables("custinfo").Rows.Count = 0 Then
            MsgBox("Customer record not found.", MsgBoxStyle.Critical)
            Me.Close()
            Exit Sub
        End If

        Dim row As DataRow = ds.Tables("custinfo").Rows(0)

        ' Load fullname, contact, notes
        txtFullname.Text = row("fullname").ToString()
        txtnumber.Text = row("contact").ToString()
        txtnotes.Text = row("notes").ToString()

        ' Load barangay + purok selection
        ' Customers saved without an address have NULL here.
        Dim barangayId As Integer = If(IsDBNull(row("barangayid")), 0, CInt(row("barangayid")))
        Dim purokId As Integer = If(IsDBNull(row("purokid")), 0, CInt(row("purokid")))

        If barangayId > 0 Then
            cmbBarangay.SelectedValue = barangayId
            LoadPuroks()
            cmbPurok.SelectedValue = purokId
        End If
    End Sub


    ' ==========================================================
    ' Validate Fields
    ' ==========================================================
    Private Function ValidateFields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(txtfullname.Text) Then
                MsgBox("Full name is required.", MsgBoxStyle.Exclamation)
                txtfullname.Focus()
                Return False
            End If

            If txtfullname.Text.Trim().Length > 150 Then
                MsgBox("Full name can be at most 150 characters.", MsgBoxStyle.Exclamation)
                txtfullname.Focus()
                Return False
            End If

            If cmbBarangay.SelectedValue Is Nothing OrElse TypeOf cmbBarangay.SelectedValue Is DataRowView Then
                MsgBox("Select a barangay.", MsgBoxStyle.Exclamation)
                Return False
            End If

            If cmbPurok.SelectedValue Is Nothing OrElse TypeOf cmbPurok.SelectedValue Is DataRowView Then
                MsgBox("Select a purok.", MsgBoxStyle.Exclamation)
                Return False
            End If

            ' Validate PH phone number
            Dim clean As String = txtnumber.Text.Replace("-", "").Trim()
            If clean <> "" Then
                If clean.Length <> 11 OrElse Not clean.StartsWith("09") OrElse Not IsNumeric(clean) Then
                    MsgBox("Enter a valid 11-digit PH mobile number.", MsgBoxStyle.Exclamation)
                    txtnumber.Focus()
                    Return False
                End If
            End If

            Return True

        Catch ex As Exception
            MsgBox("Validation error: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function


    ' ==========================================================
    ' Update Customer
    ' ==========================================================
    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            If Not ValidateFields() Then Exit Sub

            Dim sql As String =
                "UPDATE tblcustomers SET " &
                "fullname = @n, contact = @c, notes = @notes, barangayid = @b, purokid = @p " &
                "WHERE custid = @id"

            If Not SetQuery(sql, P("@n", txtFullname.Text.Trim()), P("@c", txtnumber.Text.Trim()), P("@notes", txtnotes.Text.Trim()),
                            P("@b", GetSafeValue(cmbBarangay)), P("@p", GetSafeValue(cmbPurok)), P("@id", SelectedCustID)) Then Exit Sub

            LogActivity("Customer", "Updated customer information", SelectedCustID)

            MsgBox("Customer updated successfully.", MsgBoxStyle.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Error updating customer: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    ' ==========================================================
    ' Cancel Button
    ' ==========================================================
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If MsgBox("Discard all changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

End Class
