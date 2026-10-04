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
        Dim sql As String = "SELECT purokid, purokname FROM tblpuroks WHERE barangayid = @b ORDER BY purokname"
        Dim dt As DataTable = GetDataTable(sql, P("@b", barangayId))

        cmbPurok.DataSource = dt
        cmbPurok.DisplayMember = "purokname"
        cmbPurok.ValueMember = "purokid"
        cmbPurok.DropDownStyle = ComboBoxStyle.DropDownList
        cmbPurok.SelectedIndex = -1
    End Sub

    ' ==========================================================
    ' Safe DataTable loader (prevents shared table overwrite)
    ' ==========================================================
    Private Function GetDataTable(sql As String, ParamArray params() As MySqlParameter) As DataTable
        Dim tableName As String = "tmp_" & Guid.NewGuid().ToString("N")
        GetQuery(sql, tableName, params)
        Dim copy As DataTable = ds.Tables(tableName).Copy()
        ds.Tables.Remove(tableName)
        Return copy
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

            ' The customer and their starting balance are saved together.
            Dim newCustID As Integer
            Try
                BeginTransaction()
                Execute("INSERT INTO tblcustomers (fullname, barangayid, purokid, contact, notes) VALUES (@n, @b, @p, @c, @notes)",
                        P("@n", txtfullname.Text.Trim()), P("@b", barangayId), P("@p", purokId),
                        P("@c", txtnumber.Text.Trim()), P("@notes", txtnotes.Text.Trim()))
                newCustID = GetLastInsertedID()

                Execute("INSERT INTO tblcustomerbalance (custid, balance) VALUES (@id, 0.00)", P("@id", newCustID))
                LogActivity("Customer", "Added new customer", newCustID)
                CommitTransaction()
            Catch
                RollbackTransaction()
                Throw
            End Try

            Me.NewCustID = newCustID

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
