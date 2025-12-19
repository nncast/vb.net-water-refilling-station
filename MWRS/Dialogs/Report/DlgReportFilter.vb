Imports System.Windows.Forms

Public Class DlgReportFilter

    ' Public properties to pass filter values to main form
    Public Property SelectedPeriodType As String
    Public Property FromDate As Date
    Public Property ToDate As Date
    Public Property SelectedCustomerID As Integer?
    Public Property SelectedProductID As Integer?

    Private Sub DlgReportFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' --- Populate Period Type ComboBox ---
            cbPeriodType.Items.Clear()
            cbPeriodType.Items.Add("Daily")
            cbPeriodType.Items.Add("Monthly")
            cbPeriodType.Items.Add("Yearly")
            cbPeriodType.SelectedIndex = 0

            ' --- Populate Customer ComboBox ---
            GetQuery("SELECT custid, CONCAT(fname,' ',lname) AS fullname FROM tblcustomers ORDER BY fname", "customers")
            Dim dtCustomers As DataTable = ds.Tables("customers").Copy()
            cbCustomer.DataSource = dtCustomers
            cbCustomer.DisplayMember = "fullname"
            cbCustomer.ValueMember = "custid"
            cbCustomer.SelectedIndex = -1 ' No selection by default

            ' --- Populate Product ComboBox ---
            GetQuery("SELECT productid, name FROM tblproducts WHERE status='Active' ORDER BY name", "products")
            Dim dtProducts As DataTable = ds.Tables("products").Copy()
            cbProduct.DataSource = dtProducts
            cbProduct.DisplayMember = "name"
            cbProduct.ValueMember = "productid"
            cbProduct.SelectedIndex = -1 ' No selection by default

            ' --- Populate Employee/User ComboBox ---
            GetQuery("SELECT userid, CONCAT(fname,' ',lname) AS fullname FROM tblusers WHERE role='Employee' AND status='Active' ORDER BY fname", "employees")
            Dim dtEmployees As DataTable = ds.Tables("employees").Copy()
            cbEmployee.DataSource = dtEmployees
            cbEmployee.DisplayMember = "fullname"   ' What shows in the combo box
            cbEmployee.ValueMember = "userid"       ' Actual value used in queries
            cbEmployee.SelectedIndex = -1           ' No selection by default

        Catch ex As Exception
            MsgBox("Error loading filter data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        ' Save selected values
        SelectedPeriodType = cbPeriodType.SelectedItem.ToString()
        FromDate = dtFrom.Value.Date
        ToDate = dtto.Value.Date

        If cbCustomer.SelectedIndex >= 0 Then
            SelectedCustomerID = Convert.ToInt32(cbCustomer.SelectedValue)
        Else
            SelectedCustomerID = Nothing
        End If

        If cbProduct.SelectedIndex >= 0 Then
            SelectedProductID = Convert.ToInt32(cbProduct.SelectedValue)
        Else
            SelectedProductID = Nothing
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
