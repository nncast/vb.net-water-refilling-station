<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A8_Logs
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
        Me.lvlogactivity = New System.Windows.Forms.ListView()
        Me.tsact = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.user = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.actmod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.act = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.recid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.logid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvlogin = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabativity = New System.Windows.Forms.TabPage()
        Me.tablogs = New System.Windows.Forms.TabControl()
        Me.tablogins = New System.Windows.Forms.TabPage()
        Me.cmbuser = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabativity.SuspendLayout()
        Me.tablogs.SuspendLayout()
        Me.tablogins.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlogactivity
        '
        Me.lvlogactivity.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.tsact, Me.user, Me.actmod, Me.act, Me.recid, Me.logid})
        Me.lvlogactivity.FullRowSelect = True
        Me.lvlogactivity.GridLines = True
        Me.lvlogactivity.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvlogactivity.Location = New System.Drawing.Point(1, 0)
        Me.lvlogactivity.MultiSelect = False
        Me.lvlogactivity.Name = "lvlogactivity"
        Me.lvlogactivity.Size = New System.Drawing.Size(1121, 512)
        Me.lvlogactivity.TabIndex = 0
        Me.lvlogactivity.UseCompatibleStateImageBehavior = False
        Me.lvlogactivity.View = System.Windows.Forms.View.Details
        '
        'tsact
        '
        Me.tsact.Text = "Timestamp"
        Me.tsact.Width = 265
        '
        'user
        '
        Me.user.Text = "User "
        Me.user.Width = 155
        '
        'actmod
        '
        Me.actmod.Text = "Module"
        Me.actmod.Width = 170
        '
        'act
        '
        Me.act.Text = "Action"
        Me.act.Width = 420
        '
        'recid
        '
        Me.recid.Text = "Record ID"
        Me.recid.Width = 105
        '
        'logid
        '
        Me.logid.Text = "LogID"
        Me.logid.Width = 0
        '
        'lvlogin
        '
        Me.lvlogin.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lvlogin.FullRowSelect = True
        Me.lvlogin.GridLines = True
        Me.lvlogin.Location = New System.Drawing.Point(1, 1)
        Me.lvlogin.Name = "lvlogin"
        Me.lvlogin.Size = New System.Drawing.Size(1116, 550)
        Me.lvlogin.TabIndex = 1
        Me.lvlogin.UseCompatibleStateImageBehavior = False
        Me.lvlogin.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Login ID"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "User"
        Me.ColumnHeader8.Width = 390
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Login Timestamp"
        Me.ColumnHeader9.Width = 310
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Logout Timestamp"
        Me.ColumnHeader10.Width = 310
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.White
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(796, 7)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(324, 34)
        Me.txtsearch.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(751, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 28)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "🔍"
        '
        'tabativity
        '
        Me.tabativity.Controls.Add(Me.lvlogactivity)
        Me.tabativity.Location = New System.Drawing.Point(4, 37)
        Me.tabativity.Name = "tabativity"
        Me.tabativity.Padding = New System.Windows.Forms.Padding(3)
        Me.tabativity.Size = New System.Drawing.Size(1122, 512)
        Me.tabativity.TabIndex = 0
        Me.tabativity.Text = "🚨   Activity  "
        Me.tabativity.UseVisualStyleBackColor = True
        '
        'tablogs
        '
        Me.tablogs.Controls.Add(Me.tabativity)
        Me.tablogs.Controls.Add(Me.tablogins)
        Me.tablogs.Location = New System.Drawing.Point(-3, 132)
        Me.tablogs.Name = "tablogs"
        Me.tablogs.SelectedIndex = 0
        Me.tablogs.Size = New System.Drawing.Size(1130, 553)
        Me.tablogs.TabIndex = 17
        '
        'tablogins
        '
        Me.tablogins.Controls.Add(Me.lvlogin)
        Me.tablogins.Location = New System.Drawing.Point(4, 37)
        Me.tablogins.Name = "tablogins"
        Me.tablogins.Padding = New System.Windows.Forms.Padding(3)
        Me.tablogins.Size = New System.Drawing.Size(1122, 512)
        Me.tablogins.TabIndex = 1
        Me.tablogins.Text = "🔐   Logins  "
        Me.tablogins.UseVisualStyleBackColor = True
        '
        'cmbuser
        '
        Me.cmbuser.FormattingEnabled = True
        Me.cmbuser.Location = New System.Drawing.Point(323, 6)
        Me.cmbuser.Name = "cmbuser"
        Me.cmbuser.Size = New System.Drawing.Size(308, 36)
        Me.cmbuser.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 28)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From:"
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "yyyy-MM-dd"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(60, 6)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(174, 34)
        Me.dtpFrom.TabIndex = 20
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "yyyy-MM-dd"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(60, 49)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(174, 34)
        Me.dtpTo.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 28)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 28)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "User:"
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilter.ForeColor = System.Drawing.Color.White
        Me.btnFilter.Location = New System.Drawing.Point(323, 46)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(151, 44)
        Me.btnFilter.TabIndex = 24
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.White
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClear.Location = New System.Drawing.Point(480, 46)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(151, 44)
        Me.btnClear.TabIndex = 25
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.btnFilter)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.cmbuser)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 105)
        Me.Panel1.TabIndex = 26
        '
        'A8_Logs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tablogs)
        Me.Controls.Add(Me.txtsearch)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "A8_Logs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Logs"
        Me.tabativity.ResumeLayout(False)
        Me.tablogs.ResumeLayout(False)
        Me.tablogins.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvlogactivity As System.Windows.Forms.ListView
    Friend WithEvents tsact As System.Windows.Forms.ColumnHeader
    Friend WithEvents user As System.Windows.Forms.ColumnHeader
    Friend WithEvents actmod As System.Windows.Forms.ColumnHeader
    Friend WithEvents act As System.Windows.Forms.ColumnHeader
    Friend WithEvents recid As System.Windows.Forms.ColumnHeader
    Friend WithEvents logid As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvlogin As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tabativity As System.Windows.Forms.TabPage
    Friend WithEvents tablogs As System.Windows.Forms.TabControl
    Friend WithEvents tablogins As System.Windows.Forms.TabPage
    Friend WithEvents cmbuser As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
