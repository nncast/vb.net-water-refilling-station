<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A6_Customer
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
        Me.btnedit = New System.Windows.Forms.Button()
        Me.pnlbuttons = New System.Windows.Forms.Panel()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbpurok = New System.Windows.Forms.ComboBox()
        Me.cmbbarangay = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.lvcustomers = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.brgy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.purok = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.phonenumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.notes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btnadjustbalance = New System.Windows.Forms.Button()
        Me.btnAddress = New System.Windows.Forms.Button()
        Me.pnlbuttons.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnedit
        '
        Me.btnedit.BackColor = System.Drawing.Color.White
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnedit.Location = New System.Drawing.Point(242, 1)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(121, 42)
        Me.btnedit.TabIndex = 1
        Me.btnedit.Text = "✏️  Edit"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'pnlbuttons
        '
        Me.pnlbuttons.Controls.Add(Me.btnnew)
        Me.pnlbuttons.Controls.Add(Me.btnedit)
        Me.pnlbuttons.Controls.Add(Me.btndelete)
        Me.pnlbuttons.Location = New System.Drawing.Point(0, 105)
        Me.pnlbuttons.Name = "pnlbuttons"
        Me.pnlbuttons.Size = New System.Drawing.Size(501, 43)
        Me.pnlbuttons.TabIndex = 0
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
        Me.btnnew.Text = "➕ New Customer"
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmbpurok)
        Me.Panel2.Controls.Add(Me.cmbbarangay)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtsearch)
        Me.Panel2.Controls.Add(Me.lvcustomers)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Location = New System.Drawing.Point(0, 155)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 532)
        Me.Panel2.TabIndex = 2
        '
        'cmbpurok
        '
        Me.cmbpurok.FormattingEnabled = True
        Me.cmbpurok.Location = New System.Drawing.Point(292, 14)
        Me.cmbpurok.Name = "cmbpurok"
        Me.cmbpurok.Size = New System.Drawing.Size(132, 36)
        Me.cmbpurok.TabIndex = 12
        '
        'cmbbarangay
        '
        Me.cmbbarangay.FormattingEnabled = True
        Me.cmbbarangay.Location = New System.Drawing.Point(46, 14)
        Me.cmbbarangay.Name = "cmbbarangay"
        Me.cmbbarangay.Size = New System.Drawing.Size(218, 36)
        Me.cmbbarangay.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(811, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 28)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "🔍"
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(856, 12)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(250, 34)
        Me.txtsearch.TabIndex = 0
        '
        'lvcustomers
        '
        Me.lvcustomers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvcustomers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.fname, Me.brgy, Me.purok, Me.phonenumber, Me.notes, Me.balance})
        Me.lvcustomers.FullRowSelect = True
        Me.lvcustomers.GridLines = True
        Me.lvcustomers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvcustomers.Location = New System.Drawing.Point(10, 75)
        Me.lvcustomers.Name = "lvcustomers"
        Me.lvcustomers.Size = New System.Drawing.Size(1100, 440)
        Me.lvcustomers.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvcustomers.TabIndex = 2
        Me.lvcustomers.TabStop = False
        Me.lvcustomers.UseCompatibleStateImageBehavior = False
        Me.lvcustomers.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "ID"
        '
        'fname
        '
        Me.fname.Text = "Fullname"
        Me.fname.Width = 150
        '
        'brgy
        '
        Me.brgy.Text = "Barangay"
        Me.brgy.Width = 150
        '
        'purok
        '
        Me.purok.Text = "Purok"
        Me.purok.Width = 200
        '
        'phonenumber
        '
        Me.phonenumber.Text = "Phone Number"
        Me.phonenumber.Width = 150
        '
        'notes
        '
        Me.notes.Text = "Notes"
        Me.notes.Width = 250
        '
        'balance
        '
        Me.balance.Text = "balance"
        Me.balance.Width = 100
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1125, 532)
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
        Me.RectangleShape1.Size = New System.Drawing.Size(1122, 527)
        '
        'btnadjustbalance
        '
        Me.btnadjustbalance.BackColor = System.Drawing.Color.White
        Me.btnadjustbalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadjustbalance.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnadjustbalance.Location = New System.Drawing.Point(907, 107)
        Me.btnadjustbalance.Name = "btnadjustbalance"
        Me.btnadjustbalance.Size = New System.Drawing.Size(218, 42)
        Me.btnadjustbalance.TabIndex = 1
        Me.btnadjustbalance.Text = "💲  Adjust Balance"
        Me.btnadjustbalance.UseVisualStyleBackColor = False
        '
        'btnAddress
        '
        Me.btnAddress.BackColor = System.Drawing.Color.White
        Me.btnAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddress.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnAddress.Location = New System.Drawing.Point(907, 59)
        Me.btnAddress.Name = "btnAddress"
        Me.btnAddress.Size = New System.Drawing.Size(218, 42)
        Me.btnAddress.TabIndex = 3
        Me.btnAddress.Text = "  Address"
        Me.btnAddress.UseVisualStyleBackColor = False
        '
        'A6_Customer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.btnAddress)
        Me.Controls.Add(Me.btnadjustbalance)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlbuttons)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "A6_Customer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customers_A"
        Me.pnlbuttons.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents pnlbuttons As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lvcustomers As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents fname As System.Windows.Forms.ColumnHeader
    Friend WithEvents brgy As System.Windows.Forms.ColumnHeader
    Friend WithEvents purok As System.Windows.Forms.ColumnHeader
    Friend WithEvents phonenumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents notes As System.Windows.Forms.ColumnHeader
    Friend WithEvents balance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnadjustbalance As System.Windows.Forms.Button
    Friend WithEvents cmbpurok As System.Windows.Forms.ComboBox
    Friend WithEvents cmbbarangay As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddress As System.Windows.Forms.Button
End Class
