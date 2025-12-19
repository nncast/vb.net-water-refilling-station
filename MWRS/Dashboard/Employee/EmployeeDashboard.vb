Public Class EmployeeDashboard
    Private ReadOnly timer As New Timer()

    Private Sub EmployeeDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbmwrs", "3306", "root", "")
        switchPanel(E1_Home) ' Assuming you have an employee home form
        lbltitle.Text = "Dashboard"

        UpdateDateTime()
        LoadUserInfo()

        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()
    End Sub

    ' ---------------------- CLOCK ----------------------
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
        labelclickedE(lblhome)
        switchPanel(E1_Home)
        lbltitle.Text = "Dashboard"
        E1_Home.LoadDashboardData()
    End Sub

    Private Sub lblsales_Click(sender As Object, e As EventArgs) Handles lblsales.Click
        labelclickedE(lblsales)
        switchPanel(E2_Sales)
        lbltitle.Text = "Sales"
        E2_Sales.LoadCustomers()
        E2_Sales.LoadProducts()
        E2_Sales.LoadServices()
        E2_Sales.LoadOrderTypes()
        E2_Sales.LoadNextOrderID()
        E2_Sales.SetSalesFormState("new")
    End Sub


    Private Sub lblorders_Click(sender As Object, e As EventArgs) Handles lblorders.Click
        labelclickedE(lblorders)
        switchPanel(E3_Orders)
        lbltitle.Text = "Orders"
        E3_Orders.FillOrders()
    End Sub

    Private Sub lblinventory_Click(sender As Object, e As EventArgs) Handles lblinventory.Click
        labelclickedE(lblinventory)
        switchPanel(E4_Inventory)
        lbltitle.Text = "Inventory"
        E4_Inventory.Fill()
    End Sub

    Private Sub lbldelivery_Click(sender As Object, e As EventArgs) Handles lbldelivery.Click
        labelclickedE(lbldelivery)
        switchPanel(E5_Delivery)
        lbltitle.Text = "Delivery"
        E5_Delivery.FillReadyOrders()
        E5_Delivery.LoadDeliveries()
        E5_Delivery.LoadDeliveryPersons()
    End Sub

    Private Sub lblcustomers_Click(sender As Object, e As EventArgs) Handles lblcustomers.Click
        labelclickedE(lblcustomers)
        switchPanel(E6_Customer)
        lbltitle.Text = "Customers"
        E6_Customer.fill()
    End Sub

    ' ---------------------- LOGOUT ----------------------
    Private Sub lbllogout_Click(sender As Object, e As EventArgs)
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If UserID <> 0 Then
                SetQuery("UPDATE tblloginlogs SET logouttime = NOW() WHERE userid = " & UserID & " ORDER BY logid DESC LIMIT 1")
            End If

            UserID = 0
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
                lblemployeename.Text = row("fname").ToString() & " " & row("lname").ToString()
            End If
        Else
            MsgBox("Please log in first before accessing the dashboard.", MsgBoxStyle.Exclamation)
            Application.Exit()
        End If
    End Sub


    Private Sub lbllogout_Click_1(sender As Object, e As EventArgs) Handles lbllogout.Click
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If UserID <> 0 Then
                SetQuery("UPDATE tblloginlogs SET logouttime = NOW() WHERE userid = " & UserID & " ORDER BY logid DESC LIMIT 1")
            End If

            UserID = 0
            Me.Hide()
            Login.Show()
        End If
    End Sub
End Class
