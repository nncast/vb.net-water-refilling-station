Imports System.Windows.Forms.DataVisualization.Charting

Public Class A1_Home

    Private Sub A_Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbtype.Items.AddRange(New String() {"Sales", "Inventory"})
        cmbperiod.Items.AddRange(New String() {"Daily", "Monthly", "Yearly"})
        cmbtype.SelectedIndex = 0
        cmbperiod.SelectedIndex = 1

        LoadDashboardData()
        LoadChart()
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        LoadChart()
    End Sub

    Private Sub cmbperiod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperiod.SelectedIndexChanged
        LoadChart()
    End Sub

    Public Sub LoadChart()
        Try
            DataChart.Series.Clear()
            DataChart.ChartAreas.Clear()

            ' Validate controls exist and have selections
            If cmbtype Is Nothing OrElse cmbtype.Items.Count = 0 OrElse cmbtype.SelectedIndex = -1 Then
                Return
            End If

            If cmbperiod Is Nothing OrElse cmbperiod.Items.Count = 0 OrElse cmbperiod.SelectedIndex = -1 Then
                Return
            End If

            ' Add ChartArea
            Dim chartArea As New ChartArea()
            DataChart.ChartAreas.Add(chartArea)

            Dim selectedType As String = cmbtype.SelectedItem.ToString()
            Dim selectedPeriod As String = cmbperiod.SelectedItem.ToString()

            ' Set chart based on selected type
            If selectedType = "Sales" Then
                LoadSalesChart(selectedPeriod)
            ElseIf selectedType = "Inventory" Then
                LoadInventoryChart(selectedPeriod)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading chart: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSalesChart(period As String)
        ' Create series for Bar chart
        Dim series As New Series("Sales")
        series.ChartType = SeriesChartType.Column
        series.Color = Color.DodgerBlue

        Dim query As String = ""

        ' Build query based on selected period
        Select Case period
            Case "Daily"
                query = "SELECT DATE(saledate) as period, SUM(totalamount) as total " &
                        "FROM tblsales " &
                        "WHERE saledate >= DATE_SUB(CURDATE(), INTERVAL 7 DAY) " &
                        "GROUP BY DATE(saledate) " &
                        "ORDER BY DATE(saledate)"

            Case "Monthly"
                query = "SELECT DATE_FORMAT(saledate, '%Y-%m') as period, SUM(totalamount) as total " &
                        "FROM tblsales " &
                        "WHERE saledate >= DATE_SUB(CURDATE(), INTERVAL 12 MONTH) " &
                        "GROUP BY DATE_FORMAT(saledate, '%Y-%m') " &
                        "ORDER BY DATE_FORMAT(saledate, '%Y-%m')"

            Case "Yearly"
                query = "SELECT YEAR(saledate) as period, SUM(totalamount) as total " &
                        "FROM tblsales " &
                        "WHERE saledate >= DATE_SUB(CURDATE(), INTERVAL 5 YEAR) " &
                        "GROUP BY YEAR(saledate) " &
                        "ORDER BY YEAR(saledate)"
        End Select

        ' Execute query and populate chart
        GetQuery(query, "salesData")

        For Each row As DataRow In ds.Tables("salesData").Rows
            Dim periodValue As String = row("period").ToString()
            Dim total As Decimal = CDec(row("total"))

            series.Points.AddXY(periodValue, total)
        Next

        DataChart.Series.Add(series)

        ' Format chart
        DataChart.ChartAreas(0).AxisX.Title = period
        DataChart.ChartAreas(0).AxisY.Title = "Sales Amount (₱)"
        DataChart.Titles.Clear()
        DataChart.Titles.Add(period & " Sales Report")

        ' Format Y-axis to show currency
        DataChart.ChartAreas(0).AxisY.LabelStyle.Format = "₱0"
    End Sub

    Private Sub LoadInventoryChart(period As String)
        ' Create series for Line chart
        Dim series As New Series("Inventory Levels")
        series.ChartType = SeriesChartType.Line
        series.Color = Color.DodgerBlue
        series.BorderWidth = 3
        series.MarkerStyle = MarkerStyle.Circle
        series.MarkerSize = 8
        series.MarkerColor = Color.MidnightBlue

        Dim query As String = ""

        ' Build query based on selected period
        Select Case period
            Case "Daily"
                query = "SELECT p.name as productname, p.stockqty " &
                        "FROM tblproducts p " &
                        "WHERE p.status = 'Active' " &
                        "ORDER BY p.stockqty DESC " &
                        "LIMIT 10"

            Case "Monthly"
                query = "SELECT p.name as productname, " &
                        "(SELECT SUM(qty) FROM tblinventorytransactions it " &
                        " WHERE it.productid = p.productid " &
                        " AND it.transtype = 'Stock In' " &
                        " AND it.transdate >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)) as stock_in, " &
                        "(SELECT SUM(qty) FROM tblinventorytransactions it " &
                        " WHERE it.productid = p.productid " &
                        " AND it.transtype = 'Stock Out' " &
                        " AND it.transdate >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)) as stock_out " &
                        "FROM tblproducts p " &
                        "WHERE p.status = 'Active' " &
                        "ORDER BY (COALESCE(stock_in, 0) - COALESCE(stock_out, 0)) DESC " &
                        "LIMIT 10"

            Case "Yearly"
                query = "SELECT p.name as productname, " &
                        "(SELECT SUM(qty) FROM tblinventorytransactions it " &
                        " WHERE it.productid = p.productid " &
                        " AND it.transtype = 'Stock In' " &
                        " AND YEAR(it.transdate) = YEAR(CURDATE())) as stock_in, " &
                        "(SELECT SUM(qty) FROM tblinventorytransactions it " &
                        " WHERE it.productid = p.productid " &
                        " AND it.transtype = 'Stock Out' " &
                        " AND YEAR(it.transdate) = YEAR(CURDATE())) as stock_out " &
                        "FROM tblproducts p " &
                        "WHERE p.status = 'Active' " &
                        "ORDER BY (COALESCE(stock_in, 0) - COALESCE(stock_out, 0)) DESC " &
                        "LIMIT 10"
        End Select

        ' Execute query and populate chart
        GetQuery(query, "inventoryData")

        For Each row As DataRow In ds.Tables("inventoryData").Rows
            Dim productName As String = row("productname").ToString()
            Dim value As Decimal

            If period = "Daily" Then
                value = CDec(row("stockqty"))
            Else
                Dim stockIn As Decimal = If(row.IsNull("stock_in"), 0, CDec(row("stock_in")))
                Dim stockOut As Decimal = If(row.IsNull("stock_out"), 0, CDec(row("stock_out")))
                value = stockIn - stockOut
            End If

            series.Points.AddXY(productName, value)
        Next

        DataChart.Series.Add(series)

        ' Format chart
        DataChart.ChartAreas(0).AxisX.Title = "Products"
        DataChart.ChartAreas(0).AxisY.Title = "Quantity"
        DataChart.Titles.Clear()
        DataChart.Titles.Add(period & " Inventory Levels")

        ' Rotate X-axis labels for better readability
        DataChart.ChartAreas(0).AxisX.LabelStyle.Angle = -45
        DataChart.ChartAreas(0).AxisX.Interval = 1
    End Sub


    Public Sub LoadDashboardData()
        ' --- Total Sales (Today) ---
        GetQuery("SELECT IFNULL(SUM(totalamount),0) AS totalsales FROM tblsales WHERE DATE(saledate)=CURDATE()", "salesToday")
        lblsalestoday.Text = "₱" & Format(CDec(ds.Tables("salesToday").Rows(0)("totalsales")), "0.00")

        ' --- Unpaid Orders ---
        Dim sqlUnpaid As String =
            "SELECT IFNULL(SUM(s.totalamount - IFNULL(p.totalpaid,0)),0) AS unpaidtotal " &
            "FROM tblsales s " &
            "LEFT JOIN (SELECT saleid, SUM(amountpaid) AS totalpaid FROM tblpayments GROUP BY saleid) p " &
            "ON s.saleid = p.saleid " &
            "WHERE s.paymentstatus IN ('Unpaid','Partial')"
        GetQuery(sqlUnpaid, "unpaidTotal")
        lblunpaidorders.Text = "₱" & Format(CDec(ds.Tables("unpaidTotal").Rows(0)("unpaidtotal")), "0.00")

        ' --- Pending Orders ---
        GetQuery("SELECT COUNT(*) AS pendingcount FROM tblorders WHERE status='Pending'", "pending")
        lblpendingorders.Text = ds.Tables("pending").Rows(0)("pendingcount").ToString()

        ' --- Delivered Orders ---
        GetQuery("SELECT COUNT(*) AS deliveredcount FROM tblorders WHERE status='Completed'", "delivered")

        lbldeliveredorders.Text = ds.Tables("delivered").Rows(0)("deliveredcount").ToString()
    End Sub

    Private Sub btnnewsale_Click(sender As Object, e As EventArgs) Handles btnnewsale.Click
        Globals.labelclickedA(AdminDashboard.lblsales)
        AdminDashboard.switchPanel(A2_Sales)
        AdminDashboard.lbltitle.Text = "Sales"
        A2_Sales.LoadCustomers()
        A2_Sales.LoadProducts()
        A2_Sales.LoadServices()
        A2_Sales.LoadOrderTypes()
        A2_Sales.LoadNextOrderID()
        A2_Sales.SetSalesFormState("new")
    End Sub

    Private Sub btnnewdelivery_Click(sender As Object, e As EventArgs) Handles btnnewdelivery.Click
        labelclickedA(AdminDashboard.lbldelivery)
        AdminDashboard.switchPanel(A5_Delivery)
        AdminDashboard.lbltitle.Text = "Delivery"
        A5_Delivery.FillReadyOrders()
        A5_Delivery.LoadDeliveries()
        A5_Delivery.LoadDeliveryPersons()
    End Sub

    Private Sub btnnewcustomer_Click(sender As Object, e As EventArgs) Handles btnnewcustomer.Click
        Dim dlg As New DlgAddCustomer
        dlg.ShowDialog()
    End Sub

   
    Private Sub btnupdateinventory_Click(sender As Object, e As EventArgs) Handles btnupdateinventory.Click
        Dim dlg As New DlgInventoryTransaction
        dlg.ShowDialog()
    End Sub

End Class
