<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCResults
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCResults))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.gridResults = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectAllContainingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectRandomRowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.InvertSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.UnselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsViewSelectedText = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsCompareResults = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsCompareProjects = New System.Windows.Forms.ToolStripButton
        Me.tsChartData = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsExportGridToClipboard = New System.Windows.Forms.ToolStripMenuItem
        Me.tsExportGridToCSVFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsExportAllFrequenciesToFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.tsShowStyleRows = New System.Windows.Forms.ToolStripButton
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.gridResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.gridResults)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(682, 365)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(682, 390)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'gridResults
        '
        Me.gridResults.AllowUserToAddRows = False
        Me.gridResults.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.gridResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridResults.BackgroundColor = System.Drawing.Color.White
        Me.gridResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.gridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.gridResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.gridResults.Location = New System.Drawing.Point(0, 0)
        Me.gridResults.Name = "gridResults"
        Me.gridResults.RowHeadersWidth = 25
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.gridResults.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridResults.Size = New System.Drawing.Size(682, 365)
        Me.gridResults.TabIndex = 0
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
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton2, Me.tsViewSelectedText, Me.ToolStripSeparator2, Me.tsCompareResults, Me.tsCompareProjects, Me.tsChartData, Me.ToolStripSeparator3, Me.ToolStripDropDownButton1, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.tsShowStyleRows})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(679, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectAllContainingToolStripMenuItem, Me.SelectRandomRowsToolStripMenuItem, Me.ToolStripMenuItem1, Me.InvertSelectionToolStripMenuItem, Me.ToolStripMenuItem2, Me.UnselectAllToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripDropDownButton2.Text = "Select"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Image = CType(resources.GetObject("SelectAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'SelectAllContainingToolStripMenuItem
        '
        Me.SelectAllContainingToolStripMenuItem.Image = CType(resources.GetObject("SelectAllContainingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectAllContainingToolStripMenuItem.Name = "SelectAllContainingToolStripMenuItem"
        Me.SelectAllContainingToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.SelectAllContainingToolStripMenuItem.Text = "Select All Containing..."
        '
        'SelectRandomRowsToolStripMenuItem
        '
        Me.SelectRandomRowsToolStripMenuItem.Image = CType(resources.GetObject("SelectRandomRowsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectRandomRowsToolStripMenuItem.Name = "SelectRandomRowsToolStripMenuItem"
        Me.SelectRandomRowsToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.SelectRandomRowsToolStripMenuItem.Text = "Select Random Rows..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(183, 6)
        '
        'InvertSelectionToolStripMenuItem
        '
        Me.InvertSelectionToolStripMenuItem.Image = CType(resources.GetObject("InvertSelectionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InvertSelectionToolStripMenuItem.Name = "InvertSelectionToolStripMenuItem"
        Me.InvertSelectionToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.InvertSelectionToolStripMenuItem.Text = "Invert Selection"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(183, 6)
        '
        'UnselectAllToolStripMenuItem
        '
        Me.UnselectAllToolStripMenuItem.Image = CType(resources.GetObject("UnselectAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem"
        Me.UnselectAllToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.UnselectAllToolStripMenuItem.Text = "Unselect All"
        '
        'tsViewSelectedText
        '
        Me.tsViewSelectedText.Image = CType(resources.GetObject("tsViewSelectedText.Image"), System.Drawing.Image)
        Me.tsViewSelectedText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsViewSelectedText.Name = "tsViewSelectedText"
        Me.tsViewSelectedText.Size = New System.Drawing.Size(95, 22)
        Me.tsViewSelectedText.Text = "&View text (F3)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsCompareResults
        '
        Me.tsCompareResults.Image = CType(resources.GetObject("tsCompareResults.Image"), System.Drawing.Image)
        Me.tsCompareResults.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCompareResults.Name = "tsCompareResults"
        Me.tsCompareResults.Size = New System.Drawing.Size(113, 22)
        Me.tsCompareResults.Text = "Compare values"
        '
        'tsCompareProjects
        '
        Me.tsCompareProjects.Image = CType(resources.GetObject("tsCompareProjects.Image"), System.Drawing.Image)
        Me.tsCompareProjects.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCompareProjects.Name = "tsCompareProjects"
        Me.tsCompareProjects.Size = New System.Drawing.Size(112, 22)
        Me.tsCompareProjects.Text = "Compare Projects"
        '
        'tsChartData
        '
        Me.tsChartData.Image = CType(resources.GetObject("tsChartData.Image"), System.Drawing.Image)
        Me.tsChartData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsChartData.Name = "tsChartData"
        Me.tsChartData.Size = New System.Drawing.Size(113, 22)
        Me.tsChartData.Text = "Chart &Wizard (F5)"
        Me.tsChartData.ToolTipText = "Opens chart wizard. Press F6 to plot chart with last settings."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsExportGridToClipboard, Me.tsExportGridToCSVFile, Me.ToolStripMenuItem3, Me.tsExportAllFrequenciesToFile})
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
        Me.tsExportGridToClipboard.Size = New System.Drawing.Size(261, 22)
        Me.tsExportGridToClipboard.Text = "Copy Grid to Clipboard"
        '
        'tsExportGridToCSVFile
        '
        Me.tsExportGridToCSVFile.Image = CType(resources.GetObject("tsExportGridToCSVFile.Image"), System.Drawing.Image)
        Me.tsExportGridToCSVFile.Name = "tsExportGridToCSVFile"
        Me.tsExportGridToCSVFile.Size = New System.Drawing.Size(261, 22)
        Me.tsExportGridToCSVFile.Text = "Export Grid to CSV File..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(258, 6)
        '
        'tsExportAllFrequenciesToFile
        '
        Me.tsExportAllFrequenciesToFile.Image = CType(resources.GetObject("tsExportAllFrequenciesToFile.Image"), System.Drawing.Image)
        Me.tsExportAllFrequenciesToFile.Name = "tsExportAllFrequenciesToFile"
        Me.tsExportAllFrequenciesToFile.Size = New System.Drawing.Size(261, 22)
        Me.tsExportAllFrequenciesToFile.Text = "Export Sum of All Frequencies to File..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(45, 13)
        Me.ToolStripLabel1.Text = "Display:"
        '
        'tsShowStyleRows
        '
        Me.tsShowStyleRows.Checked = True
        Me.tsShowStyleRows.CheckOnClick = True
        Me.tsShowStyleRows.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsShowStyleRows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsShowStyleRows.Enabled = False
        Me.tsShowStyleRows.Image = CType(resources.GetObject("tsShowStyleRows.Image"), System.Drawing.Image)
        Me.tsShowStyleRows.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowStyleRows.Name = "tsShowStyleRows"
        Me.tsShowStyleRows.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.tsShowStyleRows.Size = New System.Drawing.Size(23, 22)
        Me.tsShowStyleRows.Text = "ToolStripButton2"
        Me.tsShowStyleRows.ToolTipText = "Display results in column/row mode"
        '
        'UCResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UCResults"
        Me.Size = New System.Drawing.Size(682, 390)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        CType(Me.gridResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents gridResults As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsShowStyleRows As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsChartData As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsExportGridToCSVFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsExportGridToClipboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsCompareResults As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsViewSelectedText As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllContainingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UnselectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InvertSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectRandomRowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsCompareProjects As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsExportAllFrequenciesToFile As System.Windows.Forms.ToolStripMenuItem

End Class
