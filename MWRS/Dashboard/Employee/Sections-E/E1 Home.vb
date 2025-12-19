Public Class E1_Home

    Private Sub E_Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDashboardData()
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
End Class