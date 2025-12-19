<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A3_Orders
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.lvorders = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.otype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalamount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.paidamount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.custbalance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.paystatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.user = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.odate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btnpayment = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.pnlbuttons = New System.Windows.Forms.Panel()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnchangestatus = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.pnlbuttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtsearch)
        Me.Panel2.Controls.Add(Me.lvorders)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Location = New System.Drawing.Point(0, 155)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 464)
        Me.Panel2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(785, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 28)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "🔍"
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(830, 15)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(270, 34)
        Me.txtsearch.TabIndex = 0
        '
        'lvorders
        '
        Me.lvorders.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvorders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.cid, Me.cname, Me.otype, Me.totalamount, Me.paidamount, Me.custbalance, Me.paystatus, Me.user, Me.odate})
        Me.lvorders.FullRowSelect = True
        Me.lvorders.GridLines = True
        Me.lvorders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvorders.Location = New System.Drawing.Point(10, 75)
        Me.lvorders.Name = "lvorders"
        Me.lvorders.Size = New System.Drawing.Size(1100, 366)
        Me.lvorders.TabIndex = 2
        Me.lvorders.TabStop = False
        Me.lvorders.UseCompatibleStateImageBehavior = False
        Me.lvorders.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "ID"
        '
        'cid
        '
        Me.cid.Text = "CustomerID"
        Me.cid.Width = 0
        '
        'cname
        '
        Me.cname.Text = "Customer Name"
        Me.cname.Width = 160
        '
        'otype
        '
        Me.otype.Text = "Order Type"
        Me.otype.Width = 100
        '
        'totalamount
        '
        Me.totalamount.Text = "Total Amount"
        Me.totalamount.Width = 130
        '
        'paidamount
        '
        Me.paidamount.Text = "Amount Paid"
        Me.paidamount.Width = 130
        '
        'custbalance
        '
        Me.custbalance.Text = "Balance"
        Me.custbalance.Width = 80
        '
        'paystatus
        '
        Me.paystatus.Text = "Status"
        Me.paystatus.Width = 150
        '
        'user
        '
        Me.user.Text = "Processed By"
        Me.user.Width = 140
        '
        'odate
        '
        Me.odate.Text = "Order Date"
        Me.odate.Width = 150
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1125, 464)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.Enabled = False
        Me.RectangleShape1.FillColor = System.Drawing.Color.White
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(0, 0)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(1122, 458)
        '
        'btnpayment
        '
        Me.btnpayment.BackColor = System.Drawing.Color.White
        Me.btnpayment.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen
        Me.btnpayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpayment.ForeColor = System.Drawing.Color.LimeGreen
        Me.btnpayment.Location = New System.Drawing.Point(888, 105)
        Me.btnpayment.Name = "btnpayment"
        Me.btnpayment.Size = New System.Drawing.Size(237, 42)
        Me.btnpayment.TabIndex = 11
        Me.btnpayment.Text = "Add Payment"
        Me.btnpayment.UseVisualStyleBackColor = False
        '
        'btnedit
        '
        Me.btnedit.BackColor = System.Drawing.Color.White
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnedit.Location = New System.Drawing.Point(243, 1)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(121, 42)
        Me.btnedit.TabIndex = 12
        Me.btnedit.Text = "✏️  Edit"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'pnlbuttons
        '
        Me.pnlbuttons.Controls.Add(Me.btnnew)
        Me.pnlbuttons.Controls.Add(Me.btndelete)
        Me.pnlbuttons.Controls.Add(Me.btnedit)
        Me.pnlbuttons.Location = New System.Drawing.Point(0, 105)
        Me.pnlbuttons.Name = "pnlbuttons"
        Me.pnlbuttons.Size = New System.Drawing.Size(501, 43)
        Me.pnlbuttons.TabIndex = 14
        '
        'btnnew
        '
        Me.btnnew.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnnew.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnew.ForeColor = System.Drawing.Color.White
        Me.btnnew.Location = New System.Drawing.Point(1, 1)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(234, 42)
        Me.btnnew.TabIndex = 0
        Me.btnnew.Text = "➕ New Order"
        Me.btnnew.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.Red
        Me.btndelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndelete.ForeColor = System.Drawing.Color.White
        Me.btndelete.Location = New System.Drawing.Point(370, 1)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(121, 42)
        Me.btndelete.TabIndex = 2
        Me.btndelete.Text = "🗑️  Delete"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'btnchangestatus
        '
        Me.btnchangestatus.BackColor = System.Drawing.Color.White
        Me.btnchangestatus.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnchangestatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnchangestatus.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnchangestatus.Location = New System.Drawing.Point(888, 57)
        Me.btnchangestatus.Name = "btnchangestatus"
        Me.btnchangestatus.Size = New System.Drawing.Size(237, 42)
        Me.btnchangestatus.TabIndex = 15
        Me.btnchangestatus.Text = "Change Status"
        Me.btnchangestatus.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.ForeColor = System.Drawing.Color.White
        Me.btnNext.Location = New System.Drawing.Point(1002, 643)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(123, 42)
        Me.btnNext.TabIndex = 16
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'A3_Orders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnchangestatus)
        Me.Controls.Add(Me.pnlbuttons)
        Me.Controls.Add(Me.btnpayment)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "A3_Orders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orders_A"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlbuttons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents lvorders As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents cname As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents totalamount As System.Windows.Forms.ColumnHeader
    Friend WithEvents paidamount As System.Windows.Forms.ColumnHeader
    Friend WithEvents custbalance As System.Windows.Forms.ColumnHeader
    Friend WithEvents paystatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents user As System.Windows.Forms.ColumnHeader
    Friend WithEvents odate As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnpayment As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents otype As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlbuttons As System.Windows.Forms.Panel
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnchangestatus As System.Windows.Forms.Button
    Friend WithEvents cid As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNext As System.Windows.Forms.Button
End Class
