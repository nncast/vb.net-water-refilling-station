<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A1_Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbperiod = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.DataChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnupdateinventory = New System.Windows.Forms.Button()
        Me.btnnewdelivery = New System.Windows.Forms.Button()
        Me.btnnewsale = New System.Windows.Forms.Button()
        Me.btnnewcustomer = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbldeliveredorders = New System.Windows.Forms.Label()
        Me.ShapeContainer6 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape6 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblpendingorders = New System.Windows.Forms.Label()
        Me.ShapeContainer5 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape5 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblunpaidorders = New System.Windows.Forms.Label()
        Me.ShapeContainer4 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape4 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblsalestoday = New System.Windows.Forms.Label()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel2.SuspendLayout()
        CType(Me.DataChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.cmbperiod)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cmbtype)
        Me.Panel2.Controls.Add(Me.DataChart)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Location = New System.Drawing.Point(0, 194)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(850, 488)
        Me.Panel2.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(340, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 28)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Period:"
        '
        'cmbperiod
        '
        Me.cmbperiod.FormattingEnabled = True
        Me.cmbperiod.Location = New System.Drawing.Point(418, 11)
        Me.cmbperiod.Name = "cmbperiod"
        Me.cmbperiod.Size = New System.Drawing.Size(173, 36)
        Me.cmbperiod.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(597, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 28)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Type:"
        '
        'cmbtype
        '
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Location = New System.Drawing.Point(660, 11)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(171, 36)
        Me.cmbtype.TabIndex = 5
        '
        'DataChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.DataChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.DataChart.Legends.Add(Legend1)
        Me.DataChart.Location = New System.Drawing.Point(12, 53)
        Me.DataChart.Name = "DataChart"
        Me.DataChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.DataChart.Series.Add(Series1)
        Me.DataChart.Size = New System.Drawing.Size(821, 408)
        Me.DataChart.TabIndex = 1
        Me.DataChart.Text = "Chart1"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(850, 488)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape1.CornerRadius = 10
        Me.RectangleShape1.Enabled = False
        Me.RectangleShape1.FillColor = System.Drawing.Color.White
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(3, 1)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(843, 480)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.ShapeContainer2)
        Me.Panel3.Location = New System.Drawing.Point(856, 194)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(268, 488)
        Me.Panel3.TabIndex = 4
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.Controls.Add(Me.btnupdateinventory)
        Me.Panel8.Controls.Add(Me.btnnewdelivery)
        Me.Panel8.Controls.Add(Me.btnnewsale)
        Me.Panel8.Controls.Add(Me.btnnewcustomer)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Location = New System.Drawing.Point(12, 17)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(245, 460)
        Me.Panel8.TabIndex = 1
        '
        'btnupdateinventory
        '
        Me.btnupdateinventory.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnupdateinventory.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnupdateinventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdateinventory.ForeColor = System.Drawing.Color.White
        Me.btnupdateinventory.Location = New System.Drawing.Point(20, 273)
        Me.btnupdateinventory.Name = "btnupdateinventory"
        Me.btnupdateinventory.Size = New System.Drawing.Size(208, 42)
        Me.btnupdateinventory.TabIndex = 8
        Me.btnupdateinventory.Text = "Update Inventory"
        Me.btnupdateinventory.UseVisualStyleBackColor = False
        '
        'btnnewdelivery
        '
        Me.btnnewdelivery.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnnewdelivery.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnnewdelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnewdelivery.ForeColor = System.Drawing.Color.White
        Me.btnnewdelivery.Location = New System.Drawing.Point(20, 141)
        Me.btnnewdelivery.Name = "btnnewdelivery"
        Me.btnnewdelivery.Size = New System.Drawing.Size(208, 42)
        Me.btnnewdelivery.TabIndex = 7
        Me.btnnewdelivery.Text = "➕ New Delivery"
        Me.btnnewdelivery.UseVisualStyleBackColor = False
        '
        'btnnewsale
        '
        Me.btnnewsale.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnnewsale.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnnewsale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnewsale.ForeColor = System.Drawing.Color.White
        Me.btnnewsale.Location = New System.Drawing.Point(20, 75)
        Me.btnnewsale.Name = "btnnewsale"
        Me.btnnewsale.Size = New System.Drawing.Size(208, 42)
        Me.btnnewsale.TabIndex = 6
        Me.btnnewsale.Text = "➕ New Sale"
        Me.btnnewsale.UseVisualStyleBackColor = False
        '
        'btnnewcustomer
        '
        Me.btnnewcustomer.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnnewcustomer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnnewcustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnewcustomer.ForeColor = System.Drawing.Color.White
        Me.btnnewcustomer.Location = New System.Drawing.Point(20, 207)
        Me.btnnewcustomer.Name = "btnnewcustomer"
        Me.btnnewcustomer.Size = New System.Drawing.Size(208, 42)
        Me.btnnewcustomer.TabIndex = 5
        Me.btnnewcustomer.Text = "➕ New Customer"
        Me.btnnewcustomer.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(60, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quick Actions"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer2.Size = New System.Drawing.Size(268, 488)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape2.CornerRadius = 10
        Me.RectangleShape2.Enabled = False
        Me.RectangleShape2.FillColor = System.Drawing.Color.White
        Me.RectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape2.Location = New System.Drawing.Point(3, 2)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(261, 481)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1124, 188)
        Me.Panel1.TabIndex = 2
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label13)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Controls.Add(Me.lbldeliveredorders)
        Me.Panel7.Controls.Add(Me.ShapeContainer6)
        Me.Panel7.Location = New System.Drawing.Point(852, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(269, 176)
        Me.Panel7.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label13.Location = New System.Drawing.Point(177, 117)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 45)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "📨"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(22, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 28)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Delivered Orders"
        '
        'lbldeliveredorders
        '
        Me.lbldeliveredorders.AutoSize = True
        Me.lbldeliveredorders.BackColor = System.Drawing.Color.White
        Me.lbldeliveredorders.Font = New System.Drawing.Font("Segoe UI", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldeliveredorders.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbldeliveredorders.Location = New System.Drawing.Point(57, 53)
        Me.lbldeliveredorders.Name = "lbldeliveredorders"
        Me.lbldeliveredorders.Size = New System.Drawing.Size(80, 65)
        Me.lbldeliveredorders.TabIndex = 7
        Me.lbldeliveredorders.Text = "00"
        '
        'ShapeContainer6
        '
        Me.ShapeContainer6.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer6.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer6.Name = "ShapeContainer6"
        Me.ShapeContainer6.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape6})
        Me.ShapeContainer6.Size = New System.Drawing.Size(269, 176)
        Me.ShapeContainer6.TabIndex = 0
        Me.ShapeContainer6.TabStop = False
        '
        'RectangleShape6
        '
        Me.RectangleShape6.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape6.CornerRadius = 20
        Me.RectangleShape6.Enabled = False
        Me.RectangleShape6.FillColor = System.Drawing.Color.White
        Me.RectangleShape6.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape6.Location = New System.Drawing.Point(2, 2)
        Me.RectangleShape6.Name = "RectangleShape6"
        Me.RectangleShape6.Size = New System.Drawing.Size(262, 171)
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.lblpendingorders)
        Me.Panel6.Controls.Add(Me.ShapeContainer5)
        Me.Panel6.Location = New System.Drawing.Point(569, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(269, 176)
        Me.Panel6.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.Location = New System.Drawing.Point(197, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 45)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "⏳"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(22, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 28)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Pending Orders"
        '
        'lblpendingorders
        '
        Me.lblpendingorders.AutoSize = True
        Me.lblpendingorders.BackColor = System.Drawing.Color.White
        Me.lblpendingorders.Font = New System.Drawing.Font("Segoe UI", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpendingorders.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblpendingorders.Location = New System.Drawing.Point(55, 53)
        Me.lblpendingorders.Name = "lblpendingorders"
        Me.lblpendingorders.Size = New System.Drawing.Size(80, 65)
        Me.lblpendingorders.TabIndex = 6
        Me.lblpendingorders.Text = "00"
        '
        'ShapeContainer5
        '
        Me.ShapeContainer5.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer5.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer5.Name = "ShapeContainer5"
        Me.ShapeContainer5.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape5})
        Me.ShapeContainer5.Size = New System.Drawing.Size(269, 176)
        Me.ShapeContainer5.TabIndex = 0
        Me.ShapeContainer5.TabStop = False
        '
        'RectangleShape5
        '
        Me.RectangleShape5.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape5.CornerRadius = 20
        Me.RectangleShape5.Enabled = False
        Me.RectangleShape5.FillColor = System.Drawing.Color.White
        Me.RectangleShape5.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape5.Location = New System.Drawing.Point(1, 2)
        Me.RectangleShape5.Name = "RectangleShape5"
        Me.RectangleShape5.Size = New System.Drawing.Size(262, 171)
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.lblunpaidorders)
        Me.Panel5.Controls.Add(Me.ShapeContainer4)
        Me.Panel5.Location = New System.Drawing.Point(286, 5)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(269, 176)
        Me.Panel5.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label11.Location = New System.Drawing.Point(199, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 45)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "❌"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(22, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 28)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Unpaid Orders"
        '
        'lblunpaidorders
        '
        Me.lblunpaidorders.AutoSize = True
        Me.lblunpaidorders.BackColor = System.Drawing.Color.White
        Me.lblunpaidorders.Font = New System.Drawing.Font("Segoe UI", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblunpaidorders.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblunpaidorders.Location = New System.Drawing.Point(47, 53)
        Me.lblunpaidorders.Name = "lblunpaidorders"
        Me.lblunpaidorders.Size = New System.Drawing.Size(80, 65)
        Me.lblunpaidorders.TabIndex = 5
        Me.lblunpaidorders.Text = "00"
        '
        'ShapeContainer4
        '
        Me.ShapeContainer4.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer4.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer4.Name = "ShapeContainer4"
        Me.ShapeContainer4.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape4})
        Me.ShapeContainer4.Size = New System.Drawing.Size(269, 176)
        Me.ShapeContainer4.TabIndex = 0
        Me.ShapeContainer4.TabStop = False
        '
        'RectangleShape4
        '
        Me.RectangleShape4.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape4.CornerRadius = 20
        Me.RectangleShape4.Enabled = False
        Me.RectangleShape4.FillColor = System.Drawing.Color.White
        Me.RectangleShape4.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape4.Location = New System.Drawing.Point(1, 3)
        Me.RectangleShape4.Name = "RectangleShape4"
        Me.RectangleShape4.Size = New System.Drawing.Size(262, 171)
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.lblsalestoday)
        Me.Panel4.Controls.Add(Me.ShapeContainer3)
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(269, 176)
        Me.Panel4.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(22, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 28)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Today’s Sales"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(197, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 45)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "💵"
        '
        'lblsalestoday
        '
        Me.lblsalestoday.AutoSize = True
        Me.lblsalestoday.BackColor = System.Drawing.Color.White
        Me.lblsalestoday.Font = New System.Drawing.Font("Segoe UI", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsalestoday.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblsalestoday.Location = New System.Drawing.Point(47, 53)
        Me.lblsalestoday.Name = "lblsalestoday"
        Me.lblsalestoday.Size = New System.Drawing.Size(80, 65)
        Me.lblsalestoday.TabIndex = 3
        Me.lblsalestoday.Text = "00"
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape3})
        Me.ShapeContainer3.Size = New System.Drawing.Size(269, 176)
        Me.ShapeContainer3.TabIndex = 0
        Me.ShapeContainer3.TabStop = False
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape3.CornerRadius = 20
        Me.RectangleShape3.Enabled = False
        Me.RectangleShape3.FillColor = System.Drawing.Color.White
        Me.RectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape3.Location = New System.Drawing.Point(1, 3)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(262, 171)
        '
        'A1_Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Name = "A1_Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home_A"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer3 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer6 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape6 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer5 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape5 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer4 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape4 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnnewcustomer As System.Windows.Forms.Button
    Friend WithEvents DataChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblsalestoday As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbldeliveredorders As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblpendingorders As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblunpaidorders As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbperiod As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents btnnewsale As System.Windows.Forms.Button
    Friend WithEvents btnupdateinventory As System.Windows.Forms.Button
    Friend WithEvents btnnewdelivery As System.Windows.Forms.Button
End Class
