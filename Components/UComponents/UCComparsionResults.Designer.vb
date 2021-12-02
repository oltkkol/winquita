<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCComparsionResults
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCComparsionResults))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.gridData = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsColorizeCells = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsColorizeTreshold = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsColorize = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsExportGridToClipboard = New System.Windows.Forms.ToolStripMenuItem
        Me.tsExportGridToCSVFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.gridData)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(702, 431)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(702, 456)
        Me.ToolStripContainer1.TabIndex = 0
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
        Me.gridData.RowHeadersWidth = 100
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.gridData.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridData.Size = New System.Drawing.Size(702, 431)
        Me.gridData.TabIndex = 2
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
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsColorizeCells, Me.ToolStripSeparator1, Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(191, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'tsColorizeCells
        '
        Me.tsColorizeCells.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsColorizeTreshold, Me.ToolStripMenuItem1, Me.tsColorize})
        Me.tsColorizeCells.Image = CType(resources.GetObject("tsColorizeCells.Image"), System.Drawing.Image)
        Me.tsColorizeCells.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsColorizeCells.Name = "tsColorizeCells"
        Me.tsColorizeCells.Size = New System.Drawing.Size(79, 22)
        Me.tsColorizeCells.Text = "Statistics"
        '
        'tsColorizeTreshold
        '
        Me.tsColorizeTreshold.Image = CType(resources.GetObject("tsColorizeTreshold.Image"), System.Drawing.Image)
        Me.tsColorizeTreshold.Name = "tsColorizeTreshold"
        Me.tsColorizeTreshold.Size = New System.Drawing.Size(161, 22)
        Me.tsColorizeTreshold.Tag = "1.96"
        Me.tsColorizeTreshold.Text = "Set treshold: 1.96"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(158, 6)
        '
        'tsColorize
        '
        Me.tsColorize.CheckOnClick = True
        Me.tsColorize.Name = "tsColorize"
        Me.tsColorize.Size = New System.Drawing.Size(161, 22)
        Me.tsColorize.Text = "Colorize"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsExportGridToClipboard, Me.tsExportGridToCSVFile})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripDropDownButton1.Text = "Copy results"
        '
        'tsExportGridToClipboard
        '
        Me.tsExportGridToClipboard.Image = CType(resources.GetObject("tsExportGridToClipboard.Image"), System.Drawing.Image)
        Me.tsExportGridToClipboard.Name = "tsExportGridToClipboard"
        Me.tsExportGridToClipboard.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.tsExportGridToClipboard.Size = New System.Drawing.Size(251, 22)
        Me.tsExportGridToClipboard.Text = "Copy Grid to Clipboard"
        '
        'tsExportGridToCSVFile
        '
        Me.tsExportGridToCSVFile.Image = CType(resources.GetObject("tsExportGridToCSVFile.Image"), System.Drawing.Image)
        Me.tsExportGridToCSVFile.Name = "tsExportGridToCSVFile"
        Me.tsExportGridToCSVFile.Size = New System.Drawing.Size(251, 22)
        Me.tsExportGridToCSVFile.Text = "Export Grid to CSV File..."
        '
        'UCComparsionResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UCComparsionResults"
        Me.Size = New System.Drawing.Size(702, 456)
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
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents gridData As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsColorizeCells As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsColorizeTreshold As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsColorize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsExportGridToClipboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsExportGridToCSVFile As System.Windows.Forms.ToolStripMenuItem

End Class
