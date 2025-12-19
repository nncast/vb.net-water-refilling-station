Public Class DlgAddCustomer
    Public Property NewCustID As Integer

    ' ==========================================================
    ' Form Load
    ' ==========================================================
    Private Sub AddCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadBarangays()
            Clear()
        Catch ex As Exception
            MsgBox("Error initializing form: " & ex.Message, MsgBoxStyle.Critical)
            Me.Close()
        End Try
    End Sub

    ' ==========================================================
    ' Load Barangays
    ' ==========================================================
    Private Sub LoadBarangays()
        Dim dt As DataTable = GetDataTable("SELECT barangayid, barangayname FROM tblbarangays ORDER BY barangayname")

        cmbBarangay.DataSource = dt
        cmbBarangay.DisplayMember = "barangayname"
        cmbBarangay.ValueMember = "barangayid"
        cmbBarangay.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' ==========================================================
    ' Load Puroks
    ' ==========================================================
    Private Sub LoadPuroks(barangayId As Integer)
        Dim sql As String = "SELECT purokid, purokname FROM tblpuroks WHERE barangayid = " & barangayId & " ORDER BY purokname"
        Dim dt As DataTable = GetDataTable(sql)

        cmbPurok.DataSource = dt
        cmbPurok.DisplayMember = "purokname"
        cmbPurok.ValueMember = "purokid"
        cmbPurok.DropDownStyle = ComboBoxStyle.DropDownList
        cmbPurok.SelectedIndex = -1
    End Sub

    ' ==========================================================
    ' Safe DataTable loader (prevents shared table overwrite)
    ' ==========================================================
    Private Function GetDataTable(sql As String) As DataTable
        Dim tableName As String = "tmp_" & Guid.NewGuid().ToString("N")
        GetQuery(sql, tableName)
        Return ds.Tables(tableName).Copy()
    End Function

    ' ==========================================================
    ' Barangay Changed → Load Puroks
    ' ==========================================================
    Private Sub cmbBarangay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBarangay.SelectedIndexChanged
        Try
            If cmbBarangay.SelectedValue Is Nothing Then Exit Sub
            If TypeOf cmbBarangay.SelectedValue Is DataRowView Then Exit Sub

            Dim barangayId As Integer = Convert.ToInt32(cmbBarangay.SelectedValue)
            LoadPuroks(barangayId)

        Catch ex As Exception
            MsgBox("Error loading puroks: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' ==========================================================
    ' Save Customer
    ' ==========================================================
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If Not ValidateFields() Then Exit Sub

            Dim barangayId As Integer = Convert.ToInt32(cmbBarangay.SelectedValue)
            Dim purokId As Integer = Convert.ToInt32(cmbPurok.SelectedValue)

            Dim fullname As String = txtfullname.Text.Replace("'", "''")
            Dim number As String = txtnumber.Text.Replace("'", "''")
            Dim notes As String = txtnotes.Text.Replace("'", "''")

            Dim sql As String = _
                "INSERT INTO tblcustomers (fullname, barangayid, purokid, contact, notes) VALUES (" & _
                "'" & fullname & "', " & barangayId & ", " & purokId & ", '" & number & "', '" & notes & "')"

            SetQuery(sql)

            ' Get new ID
            GetQuery("SELECT LAST_INSERT_ID() AS lastid", "newid")

            Dim newCustID As Integer = 0
            If ds.Tables("newid").Rows.Count > 0 Then
                newCustID = Convert.ToInt32(ds.Tables("newid").Rows(0)("lastid"))
            End If

            If newCustID = 0 Then
                MsgBox("Failed to obtain new customer ID.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Me.NewCustID = newCustID

            ' Insert starting balance
            Dim balanceSql As String = "INSERT INTO tblcustomerbalance (custid, balance) VALUES (" & newCustID & ", 0.00)"
            SetQuery(balanceSql)

            LogActivity("Customer", "Added new customer", newCustID)

            MsgBox("Customer added successfully.", MsgBoxStyle.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Error saving customer: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' ==========================================================
    ' Cancel
    ' ==========================================================
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Try
            If MsgBox("Are you sure you want to cancel?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                Clear()
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Error during cancel: " & ex.Message, MsgBoxStyle.Critical)
        End Try
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

            If cmbBarangay.SelectedValue Is Nothing OrElse TypeOf cmbBarangay.SelectedValue Is DataRowView Then
                MsgBox("Select a barangay.", MsgBoxStyle.Exclamation)
                Return False
            End If

            If cmbPurok.SelectedValue Is Nothing OrElse TypeOf cmbPurok.SelectedValue Is DataRowView Then
                MsgBox("Select a purok.", MsgBoxStyle.Exclamation)
                Return False
            End If

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
    ' Clear fields
    ' ==========================================================
    Private Sub Clear()
        txtfullname.Clear()
        txtnumber.Clear()
        txtnotes.Clear()
        cmbBarangay.SelectedIndex = -1
        cmbPurok.DataSource = Nothing
    End Sub

End Class
