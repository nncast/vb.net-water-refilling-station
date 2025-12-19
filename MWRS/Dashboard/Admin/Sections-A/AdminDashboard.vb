Public Class AdminDashboard
    Private ReadOnly timer As New Timer()

    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbmwrs", "3306", "root", "")

        switchPanel(A1_Home)
        lbltitle.Text = "Dashboard"

        UpdateDateTime()
        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()

        LoadUserInfo()
    End Sub

    ' ---------------------- TIME AND DATE ----------------------
    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        UpdateDateTime()
    End Sub

    Private Sub UpdateDateTime()
        lbldate.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lbltime.Text = DateTime.Now.ToString("h:mm:ss tt")
    End Sub

    ' ---------------------- PANEL SWITCH ----------------------
    Public Sub switchPanel(frm As Form)
        pnlform.Controls.Clear()
        frm.TopLevel = False
        pnlform.Controls.Add(frm)
        frm.Dock = DockStyle.fill
        frm.Show()
    End Sub

    ' ---------------------- NAVIGATION ----------------------
    Private Sub lblhome_Click(sender As Object, e As EventArgs) Handles lblhome.Click
        labelclickedA(lblhome)
        switchPanel(A1_Home)
        lbltitle.Text = "Dashboard"
        A1_Home.loadchart()
        A1_Home.LoadDashboardData()
    End Sub

    Private Sub lblsales_Click(sender As Object, e As EventArgs) Handles lblsales.Click
        labelclickedA(lblsales)
        switchPanel(A2_Sales)
        lbltitle.Text = "Sales"
        A2_Sales.LoadCustomers()
        A2_Sales.LoadProducts()
        A2_Sales.LoadServices()
        A2_Sales.LoadOrderTypes()
        A2_Sales.LoadNextOrderID()
        A2_Sales.SetSalesFormState("new")
    End Sub

    Private Sub lblorders_Click(sender As Object, e As EventArgs) Handles lblorders.Click
        labelclickedA(lblorders)
        switchPanel(A3_Orders)
        lbltitle.Text = "Orders"
        A3_Orders.FillOrders()
    End Sub

    Private Sub lblinventory_Click(sender As Object, e As EventArgs) Handles lblinventory.Click
        labelclickedA(lblinventory)
        switchPanel(A4_Inventory)
        lbltitle.Text = "Inventory"
        A4_Inventory.fill()
    End Sub

    Private Sub lbldelivery_Click(sender As Object, e As EventArgs) Handles lbldelivery.Click
        labelclickedA(lbldelivery)
        switchPanel(A5_Delivery)
        lbltitle.Text = "Delivery"
        A5_Delivery.FillReadyOrders()
        A5_Delivery.LoadDeliveries()
        A5_Delivery.LoadDeliveryPersons()
    End Sub

    Private Sub lblcustomers_Click(sender As Object, e As EventArgs) Handles lblcustomers.Click
        labelclickedA(lblcustomers)
        switchPanel(A6_Customer)
        lbltitle.Text = "Customers"
        A6_Customer.LoadBarangays()
        A6_Customer.LoadPuroks()
        A6_Customer.fill()
    End Sub

    Private Sub lbllogs_Click(sender As Object, e As EventArgs) Handles lbllogs.Click
        labelclickedA(lbllogs)
        switchPanel(A8_Logs)
        lbltitle.Text = "Logs"
        A8_Logs.LoadLoginLogs()
        A8_Logs.LoadLogsActivity()
        A8_Logs.LoadUserCombo()
    End Sub

    Private Sub lblreport_Click(sender As Object, e As EventArgs) Handles lblreport.Click
        labelclickedA(lblreport)
        switchPanel(A9_Report)
        lbltitle.Text = "Report"
    End Sub

    Private Sub lblemployee_Click(sender As Object, e As EventArgs) Handles lblemployee.Click
        labelclickedA(lblemployee)
        switchPanel(A7_User)
        lbltitle.Text = "Employee"
        A7_User.fill()
    End Sub

    ' ---------------------- LOGOUT ----------------------
    Private Sub lbllogout_Click(sender As Object, e As EventArgs) Handles lbllogout.Click
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If userid <> 0 Then
                SetQuery("UPDATE tblloginlogs SET logouttime = NOW() WHERE userid = " & userid & " ORDER BY logid DESC LIMIT 1")
            End If

            userid = 0
            Me.Hide()
            Login.Show()
        End If
    End Sub

    ' ---------------------- USER INFO ----------------------
    Public Sub LoadUserInfo()
        If userid > 0 Then
            GetQuery("SELECT fname, lname FROM tblusers WHERE userid = " & userid, "tblusers")

            If ds.Tables("tblusers").Rows.Count > 0 Then
                Dim row = ds.Tables("tblusers").Rows(0)
                lblempname.Text = row("fname").ToString() & " " & row("lname").ToString()
            End If
        Else
            MsgBox("Please log in first before accessing the dashboard.", MsgBoxStyle.Exclamation)
            Application.Exit()
        End If
    End Sub

    
End Class
