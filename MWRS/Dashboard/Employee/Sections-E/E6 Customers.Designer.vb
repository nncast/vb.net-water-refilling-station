<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class E6_Customer
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
        Me.cmbpurok = New System.Windows.Forms.ComboBox()
        Me.cmbbarangay = New System.Windows.Forms.ComboBox()
        Me.lvcustomers = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.address = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.phonenumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.notes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.pnlbuttons = New System.Windows.Forms.Panel()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.pnlbuttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbpurok)
        Me.Panel2.Controls.Add(Me.cmbbarangay)
        Me.Panel2.Controls.Add(Me.lvcustomers)
        Me.Panel2.Controls.Add(Me.txtsearch)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Location = New System.Drawing.Point(0, 155)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 532)
        Me.Panel2.TabIndex = 3
        '
        'cmbpurok
        '
        Me.cmbpurok.FormattingEnabled = True
        Me.cmbpurok.Location = New System.Drawing.Point(292, 14)
        Me.cmbpurok.Name = "cmbpurok"
        Me.cmbpurok.Size = New System.Drawing.Size(132, 36)
        Me.cmbpurok.TabIndex = 14
        '
        'cmbbarangay
        '
        Me.cmbbarangay.FormattingEnabled = True
        Me.cmbbarangay.Location = New System.Drawing.Point(46, 14)
        Me.cmbbarangay.Name = "cmbbarangay"
        Me.cmbbarangay.Size = New System.Drawing.Size(218, 36)
        Me.cmbbarangay.TabIndex = 13
        '
        'lvcustomers
        '
        Me.lvcustomers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvcustomers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.fname, Me.lname, Me.address, Me.phonenumber, Me.notes})
        Me.lvcustomers.FullRowSelect = True
        Me.lvcustomers.GridLines = True
        Me.lvcustomers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvcustomers.Location = New System.Drawing.Point(10, 75)
        Me.lvcustomers.Name = "lvcustomers"
        Me.lvcustomers.Size = New System.Drawing.Size(1100, 440)
        Me.lvcustomers.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvcustomers.TabIndex = 4
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
        'lname
        '
        Me.lname.Text = "Barangay"
        Me.lname.Width = 150
        '
        'address
        '
        Me.address.Text = "Purok"
        Me.address.Width = 300
        '
        'phonenumber
        '
        Me.phonenumber.Text = "Phone Number"
        Me.phonenumber.Width = 150
        '
        'notes
        '
        Me.notes.Text = "Notes"
        Me.notes.Width = 300
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(830, 16)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(270, 34)
        Me.txtsearch.TabIndex = 0
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
        Me.RectangleShape1.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.Enabled = False
        Me.RectangleShape1.FillColor = System.Drawing.Color.White
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(0, 0)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(1122, 527)
        '
        'pnlbuttons
        '
        Me.pnlbuttons.Controls.Add(Me.btnedit)
        Me.pnlbuttons.Location = New System.Drawing.Point(0, 105)
        Me.pnlbuttons.Name = "pnlbuttons"
        Me.pnlbuttons.Size = New System.Drawing.Size(171, 43)
        Me.pnlbuttons.TabIndex = 2
        '
        'btnedit
        '
        Me.btnedit.BackColor = System.Drawing.Color.White
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnedit.Location = New System.Drawing.Point(1, 1)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(161, 42)
        Me.btnedit.TabIndex = 1
        Me.btnedit.Text = "✏️  Edit"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(785, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 28)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "🔍"
        '
        'E6_Customer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlbuttons)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "E6_Customer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlbuttons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents pnlbuttons As System.Windows.Forms.Panel
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents lvcustomers As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents fname As System.Windows.Forms.ColumnHeader
    Friend WithEvents lname As System.Windows.Forms.ColumnHeader
    Friend WithEvents address As System.Windows.Forms.ColumnHeader
    Friend WithEvents phonenumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents notes As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbpurok As System.Windows.Forms.ComboBox
    Friend WithEvents cmbbarangay As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
