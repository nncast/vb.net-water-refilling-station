<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgEditDelivery
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.cmbDeliveryPerson = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.lvAssignedOrders = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cust = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.stat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblDeliveryID = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRemoveOrder = New System.Windows.Forms.Button()
        Me.btnAddOrder = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btncancel, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnupdate, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(488, 340)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(219, 52)
        Me.TableLayoutPanel1.TabIndex = 35
        '
        'btncancel
        '
        Me.btncancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btncancel.BackColor = System.Drawing.Color.Gainsboro
        Me.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Location = New System.Drawing.Point(114, 6)
        Me.btncancel.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(100, 40)
        Me.btncancel.TabIndex = 6
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'btnupdate
        '
        Me.btnupdate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnupdate.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnupdate.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdate.ForeColor = System.Drawing.Color.White
        Me.btnupdate.Location = New System.Drawing.Point(5, 6)
        Me.btnupdate.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(99, 40)
        Me.btnupdate.TabIndex = 5
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'cmbDeliveryPerson
        '
        Me.cmbDeliveryPerson.FormattingEnabled = True
        Me.cmbDeliveryPerson.Location = New System.Drawing.Point(148, 13)
        Me.cmbDeliveryPerson.Name = "cmbDeliveryPerson"
        Me.cmbDeliveryPerson.Size = New System.Drawing.Size(200, 31)
        Me.cmbDeliveryPerson.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 23)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Delivery Person:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 23)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Date:"
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(148, 50)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(200, 30)
        Me.dtpDeliveryDate.TabIndex = 39
        '
        'lvAssignedOrders
        '
        Me.lvAssignedOrders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.cust, Me.total, Me.stat})
        Me.lvAssignedOrders.FullRowSelect = True
        Me.lvAssignedOrders.GridLines = True
        Me.lvAssignedOrders.Location = New System.Drawing.Point(372, 44)
        Me.lvAssignedOrders.Name = "lvAssignedOrders"
        Me.lvAssignedOrders.Size = New System.Drawing.Size(302, 252)
        Me.lvAssignedOrders.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvAssignedOrders.TabIndex = 40
        Me.lvAssignedOrders.UseCompatibleStateImageBehavior = False
        Me.lvAssignedOrders.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "ID"
        '
        'cust
        '
        Me.cust.Text = "Customer"
        Me.cust.Width = 100
        '
        'total
        '
        Me.total.Text = "Total"
        Me.total.Width = 100
        '
        'stat
        '
        Me.stat.Text = "Status"
        Me.stat.Width = 100
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblDeliveryID)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbStatus)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lvAssignedOrders)
        Me.Panel1.Controls.Add(Me.cmbDeliveryPerson)
        Me.Panel1.Controls.Add(Me.dtpDeliveryDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(695, 319)
        Me.Panel1.TabIndex = 41
        '
        'lblDeliveryID
        '
        Me.lblDeliveryID.AutoSize = True
        Me.lblDeliveryID.BackColor = System.Drawing.Color.White
        Me.lblDeliveryID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeliveryID.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblDeliveryID.Location = New System.Drawing.Point(655, 0)
        Me.lblDeliveryID.Name = "lblDeliveryID"
        Me.lblDeliveryID.Size = New System.Drawing.Size(33, 28)
        Me.lblDeliveryID.TabIndex = 44
        Me.lblDeliveryID.Text = "ID"
        Me.lblDeliveryID.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 23)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Status:"
        '
        'cmbStatus
        '
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(148, 85)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(200, 31)
        Me.cmbStatus.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(367, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 28)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Delivery Orders"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnRemoveOrder, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAddOrder, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(162, 148)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(186, 110)
        Me.TableLayoutPanel2.TabIndex = 41
        '
        'btnRemoveOrder
        '
        Me.btnRemoveOrder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRemoveOrder.BackColor = System.Drawing.Color.Red
        Me.btnRemoveOrder.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnRemoveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveOrder.ForeColor = System.Drawing.Color.White
        Me.btnRemoveOrder.Location = New System.Drawing.Point(5, 61)
        Me.btnRemoveOrder.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnRemoveOrder.Name = "btnRemoveOrder"
        Me.btnRemoveOrder.Size = New System.Drawing.Size(176, 42)
        Me.btnRemoveOrder.TabIndex = 2
        Me.btnRemoveOrder.Text = "🗑️  Remove Order"
        Me.btnRemoveOrder.UseVisualStyleBackColor = False
        '
        'btnAddOrder
        '
        Me.btnAddOrder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAddOrder.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnAddOrder.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddOrder.ForeColor = System.Drawing.Color.White
        Me.btnAddOrder.Location = New System.Drawing.Point(5, 7)
        Me.btnAddOrder.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnAddOrder.Name = "btnAddOrder"
        Me.btnAddOrder.Size = New System.Drawing.Size(176, 40)
        Me.btnAddOrder.TabIndex = 0
        Me.btnAddOrder.Text = "➕ Add Order"
        Me.btnAddOrder.UseVisualStyleBackColor = False
        '
        'DlgEditDelivery
        '
        Me.AcceptButton = Me.btnupdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btncancel
        Me.ClientSize = New System.Drawing.Size(721, 407)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgEditDelivery"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Delivery"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents cmbDeliveryPerson As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lvAssignedOrders As System.Windows.Forms.ListView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnRemoveOrder As System.Windows.Forms.Button
    Friend WithEvents btnAddOrder As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents cust As System.Windows.Forms.ColumnHeader
    Friend WithEvents total As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents stat As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblDeliveryID As System.Windows.Forms.Label

End Class
