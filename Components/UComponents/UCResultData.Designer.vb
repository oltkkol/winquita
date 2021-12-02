<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCResultData
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCResultData))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lvData = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.gridData = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblStatus = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsMarkRed = New System.Windows.Forms.ToolStripMenuItem
        Me.tsMarkBlue = New System.Windows.Forms.ToolStripMenuItem
        Me.tsMarkGreen = New System.Windows.Forms.ToolStripMenuItem
        Me.tsMarkOrange = New System.Windows.Forms.ToolStripMenuItem
        Me.tsMarkPurple = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsMarkColorDef = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.BoldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ItalicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnderlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StrikeoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.RegularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton
        Me.CopyGridToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportGridToCSVFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvData
        '
        Me.lvData.AllowColumnReorder = True
        Me.lvData.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvData.FullRowSelect = True
        Me.lvData.GridLines = True
        Me.lvData.HideSelection = False
        Me.lvData.Location = New System.Drawing.Point(0, 0)
        Me.lvData.Name = "lvData"
        Me.lvData.Size = New System.Drawing.Size(478, 351)
        Me.lvData.SmallImageList = Me.ImageList1
        Me.lvData.TabIndex = 0
        Me.lvData.UseCompatibleStateImageBehavior = False
        Me.lvData.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 85
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = ""
        Me.ColumnHeader2.Width = 84
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 166
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = ""
        Me.ColumnHeader4.Width = 115
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = ""
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Yellow")
        Me.ImageList1.Images.SetKeyName(1, "Red")
        Me.ImageList1.Images.SetKeyName(2, "Purple")
        Me.ImageList1.Images.SetKeyName(3, "Green")
        Me.ImageList1.Images.SetKeyName(4, "Orange")
        Me.ImageList1.Images.SetKeyName(5, "Blue")
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.lvData)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.gridData)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.lblStatus)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(478, 351)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(478, 376)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'gridData
        '
        Me.gridData.AllowUserToAddRows = False
        Me.gridData.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.gridData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridData.BackgroundColor = System.Drawing.Color.White
        Me.gridData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.gridData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.gridData.Location = New System.Drawing.Point(0, 0)
        Me.gridData.Name = "gridData"
        Me.gridData.RowHeadersWidth = 25
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.gridData.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridData.Size = New System.Drawing.Size(478, 351)
        Me.gridData.TabIndex = 1
        Me.gridData.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Column4"
        Me.Column4.Name = "Column4"
        '
        'lblStatus
        '
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.Location = New System.Drawing.Point(0, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(478, 351)
        Me.lblStatus.TabIndex = 2
        Me.lblStatus.Text = "Wait please, populating data..."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2, Me.ToolStripSeparator2, Me.ToolStripDropDownButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(328, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(78, 22)
        Me.ToolStripLabel1.Text = "Selected rows:"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMarkRed, Me.tsMarkBlue, Me.tsMarkGreen, Me.tsMarkOrange, Me.tsMarkPurple, Me.ToolStripMenuItem1, Me.tsMarkColorDef})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripDropDownButton1.Text = "Color"
        '
        'tsMarkRed
        '
        Me.tsMarkRed.Image = CType(resources.GetObject("tsMarkRed.Image"), System.Drawing.Image)
        Me.tsMarkRed.Name = "tsMarkRed"
        Me.tsMarkRed.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.tsMarkRed.Size = New System.Drawing.Size(148, 22)
        Me.tsMarkRed.Text = "Red"
        '
        'tsMarkBlue
        '
        Me.tsMarkBlue.Image = CType(resources.GetObject("tsMarkBlue.Image"), System.Drawing.Image)
        Me.tsMarkBlue.Name = "tsMarkBlue"
        Me.tsMarkBlue.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.tsMarkBlue.Size = New System.Drawing.Size(148, 22)
        Me.tsMarkBlue.Text = "Blue"
        '
        'tsMarkGreen
        '
        Me.tsMarkGreen.Image = CType(resources.GetObject("tsMarkGreen.Image"), System.Drawing.Image)
        Me.tsMarkGreen.Name = "tsMarkGreen"
        Me.tsMarkGreen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D3), System.Windows.Forms.Keys)
        Me.tsMarkGreen.Size = New System.Drawing.Size(148, 22)
        Me.tsMarkGreen.Text = "Green"
        '
        'tsMarkOrange
        '
        Me.tsMarkOrange.Image = CType(resources.GetObject("tsMarkOrange.Image"), System.Drawing.Image)
        Me.tsMarkOrange.Name = "tsMarkOrange"
        Me.tsMarkOrange.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D4), System.Windows.Forms.Keys)
        Me.tsMarkOrange.Size = New System.Drawing.Size(148, 22)
        Me.tsMarkOrange.Text = "Orange"
        '
        'tsMarkPurple
        '
        Me.tsMarkPurple.Image = CType(resources.GetObject("tsMarkPurple.Image"), System.Drawing.Image)
        Me.tsMarkPurple.Name = "tsMarkPurple"
        Me.tsMarkPurple.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D5), System.Windows.Forms.Keys)
        Me.tsMarkPurple.Size = New System.Drawing.Size(148, 22)
        Me.tsMarkPurple.Text = "Purple"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(145, 6)
        '
        'tsMarkColorDef
        '
        Me.tsMarkColorDef.Name = "tsMarkColorDef"
        Me.tsMarkColorDef.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)
        Me.tsMarkColorDef.Size = New System.Drawing.Size(148, 22)
        Me.tsMarkColorDef.Text = "Default"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BoldToolStripMenuItem, Me.ItalicToolStripMenuItem, Me.UnderlineToolStripMenuItem, Me.StrikeoutToolStripMenuItem, Me.ToolStripMenuItem2, Me.RegularToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(84, 22)
        Me.ToolStripDropDownButton2.Text = "Text style"
        '
        'BoldToolStripMenuItem
        '
        Me.BoldToolStripMenuItem.Image = CType(resources.GetObject("BoldToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BoldToolStripMenuItem.Name = "BoldToolStripMenuItem"
        Me.BoldToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BoldToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.BoldToolStripMenuItem.Text = "Bold"
        '
        'ItalicToolStripMenuItem
        '
        Me.ItalicToolStripMenuItem.Image = CType(resources.GetObject("ItalicToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItalicToolStripMenuItem.Name = "ItalicToolStripMenuItem"
        Me.ItalicToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.ItalicToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ItalicToolStripMenuItem.Text = "Italic"
        '
        'UnderlineToolStripMenuItem
        '
        Me.UnderlineToolStripMenuItem.Image = CType(resources.GetObject("UnderlineToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UnderlineToolStripMenuItem.Name = "UnderlineToolStripMenuItem"
        Me.UnderlineToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.UnderlineToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.UnderlineToolStripMenuItem.Text = "Underline"
        '
        'StrikeoutToolStripMenuItem
        '
        Me.StrikeoutToolStripMenuItem.Image = CType(resources.GetObject("StrikeoutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StrikeoutToolStripMenuItem.Name = "StrikeoutToolStripMenuItem"
        Me.StrikeoutToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.StrikeoutToolStripMenuItem.Text = "Strike-out"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(155, 6)
        '
        'RegularToolStripMenuItem
        '
        Me.RegularToolStripMenuItem.Name = "RegularToolStripMenuItem"
        Me.RegularToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.RegularToolStripMenuItem.Text = "Regular"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyGridToClipboardToolStripMenuItem, Me.ExportGridToCSVFileToolStripMenuItem})
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripDropDownButton3.Text = "Copy results"
        '
        'CopyGridToClipboardToolStripMenuItem
        '
        Me.CopyGridToClipboardToolStripMenuItem.Image = CType(resources.GetObject("CopyGridToClipboardToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyGridToClipboardToolStripMenuItem.Name = "CopyGridToClipboardToolStripMenuItem"
        Me.CopyGridToClipboardToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.CopyGridToClipboardToolStripMenuItem.Text = "Copy Grid to Clipboard"
        '
        'ExportGridToCSVFileToolStripMenuItem
        '
        Me.ExportGridToCSVFileToolStripMenuItem.Image = CType(resources.GetObject("ExportGridToCSVFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportGridToCSVFileToolStripMenuItem.Name = "ExportGridToCSVFileToolStripMenuItem"
        Me.ExportGridToCSVFileToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ExportGridToCSVFileToolStripMenuItem.Text = "Export Grid to CSV file..."
        '
        'UCResultData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UCResultData"
        Me.Size = New System.Drawing.Size(478, 376)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvData As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsMarkRed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMarkBlue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMarkGreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMarkOrange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMarkPurple As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsMarkColorDef As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents BoldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItalicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnderlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RegularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StrikeoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripDropDownButton3 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CopyGridToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportGridToCSVFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gridData As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader

End Class
