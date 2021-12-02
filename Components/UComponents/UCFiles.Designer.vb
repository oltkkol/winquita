<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCFiles
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCFiles))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.txtStats = New System.Windows.Forms.TextBox
        Me.gridFiles = New System.Windows.Forms.DataGridView
        Me.clmnCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.clmnIcon = New System.Windows.Forms.DataGridViewImageColumn
        Me.clmnTextName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmnFile = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmnDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmnComments = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmnPreview = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmnEncoding = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdAddText = New System.Windows.Forms.ToolStripButton
        Me.tsCmdAddMultipleTexts = New System.Windows.Forms.ToolStripButton
        Me.tsCmdAddFilesFromDict = New System.Windows.Forms.ToolStripSplitButton
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsClearTable = New System.Windows.Forms.ToolStripButton
        Me.tsLoadRecent = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.MaximumFileSizeAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MinimumFileSizeAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClusterFilesWithToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MaximumFilesCountAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FilesContainingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RandomizeDictionaryFileListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IgnoreBinaryFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrependDirectoryNameToFiles = New System.Windows.Forms.ToolStripButton
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.gridFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.txtStats)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.gridFiles)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(774, 412)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(774, 437)
        Me.ToolStripContainer1.TabIndex = 2
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'txtStats
        '
        Me.txtStats.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtStats.Location = New System.Drawing.Point(0, 392)
        Me.txtStats.Name = "txtStats"
        Me.txtStats.ReadOnly = True
        Me.txtStats.Size = New System.Drawing.Size(774, 20)
        Me.txtStats.TabIndex = 1
        '
        'gridFiles
        '
        Me.gridFiles.AllowDrop = True
        Me.gridFiles.AllowUserToAddRows = False
        Me.gridFiles.AllowUserToOrderColumns = True
        Me.gridFiles.AllowUserToResizeRows = False
        Me.gridFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridFiles.BackgroundColor = System.Drawing.Color.White
        Me.gridFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnCheck, Me.clmnIcon, Me.clmnTextName, Me.clmnFile, Me.Column1, Me.clmnDescription, Me.clmnComments, Me.clmnPreview, Me.clmnEncoding})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridFiles.DefaultCellStyle = DataGridViewCellStyle4
        Me.gridFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.gridFiles.Location = New System.Drawing.Point(0, 0)
        Me.gridFiles.Name = "gridFiles"
        Me.gridFiles.RowHeadersVisible = False
        Me.gridFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridFiles.Size = New System.Drawing.Size(774, 386)
        Me.gridFiles.TabIndex = 0
        '
        'clmnCheck
        '
        Me.clmnCheck.HeaderText = ""
        Me.clmnCheck.Name = "clmnCheck"
        Me.clmnCheck.Width = 32
        '
        'clmnIcon
        '
        Me.clmnIcon.HeaderText = ""
        Me.clmnIcon.Name = "clmnIcon"
        Me.clmnIcon.Width = 32
        '
        'clmnTextName
        '
        Me.clmnTextName.HeaderText = "Text Name"
        Me.clmnTextName.Name = "clmnTextName"
        Me.clmnTextName.Width = 200
        '
        'clmnFile
        '
        Me.clmnFile.HeaderText = "File"
        Me.clmnFile.Name = "clmnFile"
        Me.clmnFile.ReadOnly = True
        '
        'Column1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "## ### ###"
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "Size [B]"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'clmnDescription
        '
        Me.clmnDescription.HeaderText = "Description"
        Me.clmnDescription.Name = "clmnDescription"
        Me.clmnDescription.Visible = False
        '
        'clmnComments
        '
        Me.clmnComments.HeaderText = "Comments"
        Me.clmnComments.Name = "clmnComments"
        Me.clmnComments.Visible = False
        '
        'clmnPreview
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.clmnPreview.DefaultCellStyle = DataGridViewCellStyle3
        Me.clmnPreview.HeaderText = "Preview"
        Me.clmnPreview.Name = "clmnPreview"
        Me.clmnPreview.ReadOnly = True
        Me.clmnPreview.Width = 350
        '
        'clmnEncoding
        '
        Me.clmnEncoding.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.clmnEncoding.DropDownWidth = 2
        Me.clmnEncoding.HeaderText = "Encoding"
        Me.clmnEncoding.MaxDropDownItems = 15
        Me.clmnEncoding.Name = "clmnEncoding"
        Me.clmnEncoding.Width = 200
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdAddText, Me.tsCmdAddMultipleTexts, Me.tsCmdAddFilesFromDict, Me.ToolStripSeparator1, Me.tsClearTable, Me.tsLoadRecent, Me.ToolStripSeparator3, Me.PrependDirectoryNameToFiles, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(736, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'cmdAddText
        '
        Me.cmdAddText.Image = CType(resources.GetObject("cmdAddText.Image"), System.Drawing.Image)
        Me.cmdAddText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddText.Name = "cmdAddText"
        Me.cmdAddText.Size = New System.Drawing.Size(109, 22)
        Me.cmdAddText.Text = "&Create New Text"
        '
        'tsCmdAddMultipleTexts
        '
        Me.tsCmdAddMultipleTexts.Image = CType(resources.GetObject("tsCmdAddMultipleTexts.Image"), System.Drawing.Image)
        Me.tsCmdAddMultipleTexts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCmdAddMultipleTexts.Name = "tsCmdAddMultipleTexts"
        Me.tsCmdAddMultipleTexts.Size = New System.Drawing.Size(115, 22)
        Me.tsCmdAddMultipleTexts.Text = "Add &Text File(s)..."
        '
        'tsCmdAddFilesFromDict
        '
        Me.tsCmdAddFilesFromDict.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaximumFileSizeAllToolStripMenuItem, Me.MinimumFileSizeAllToolStripMenuItem, Me.ClusterFilesWithToolStripMenuItem, Me.ToolStripMenuItem1, Me.MaximumFilesCountAllToolStripMenuItem, Me.FilesContainingToolStripMenuItem, Me.ToolStripMenuItem2, Me.RandomizeDictionaryFileListToolStripMenuItem, Me.IgnoreBinaryFilesToolStripMenuItem})
        Me.tsCmdAddFilesFromDict.Image = CType(resources.GetObject("tsCmdAddFilesFromDict.Image"), System.Drawing.Image)
        Me.tsCmdAddFilesFromDict.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCmdAddFilesFromDict.Name = "tsCmdAddFilesFromDict"
        Me.tsCmdAddFilesFromDict.Size = New System.Drawing.Size(179, 22)
        Me.tsCmdAddFilesFromDict.Text = "Add Text Files from &Directory"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(314, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(314, 6)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsClearTable
        '
        Me.tsClearTable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsClearTable.Image = CType(resources.GetObject("tsClearTable.Image"), System.Drawing.Image)
        Me.tsClearTable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClearTable.Name = "tsClearTable"
        Me.tsClearTable.Size = New System.Drawing.Size(52, 22)
        Me.tsClearTable.Text = "Clear"
        '
        'tsLoadRecent
        '
        Me.tsLoadRecent.Image = CType(resources.GetObject("tsLoadRecent.Image"), System.Drawing.Image)
        Me.tsLoadRecent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLoadRecent.Name = "tsLoadRecent"
        Me.tsLoadRecent.Size = New System.Drawing.Size(87, 22)
        Me.tsLoadRecent.Text = "Load Recent"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "newFile")
        Me.imgList.Images.SetKeyName(1, "sum")
        Me.imgList.Images.SetKeyName(2, "text")
        Me.imgList.Images.SetKeyName(3, "newPage")
        Me.imgList.Images.SetKeyName(4, "pencil_add.png")
        Me.imgList.Images.SetKeyName(5, "working")
        Me.imgList.Images.SetKeyName(6, "table_go.png")
        Me.imgList.Images.SetKeyName(7, "waiting")
        Me.imgList.Images.SetKeyName(8, "ready")
        Me.imgList.Images.SetKeyName(9, "inqueue")
        Me.imgList.Images.SetKeyName(10, "calc")
        Me.imgList.Images.SetKeyName(11, "text_uppercase.png")
        Me.imgList.Images.SetKeyName(12, "text_signature.png")
        Me.imgList.Images.SetKeyName(13, "cog_go.png")
        Me.imgList.Images.SetKeyName(14, "text_letterspacing.png")
        Me.imgList.Images.SetKeyName(15, "cog.png")
        Me.imgList.Images.SetKeyName(16, "text_horizontalrule.png")
        Me.imgList.Images.SetKeyName(17, "pencil.png")
        Me.imgList.Images.SetKeyName(18, "right")
        '
        'MaximumFileSizeAllToolStripMenuItem
        '
        Me.MaximumFileSizeAllToolStripMenuItem.Name = "MaximumFileSizeAllToolStripMenuItem"
        Me.MaximumFileSizeAllToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.MaximumFileSizeAllToolStripMenuItem.Tag = "-1"
        Me.MaximumFileSizeAllToolStripMenuItem.Text = Global.QITA_OLTK.My.MySettings.Default.Files_MaxFileSize
        '
        'MinimumFileSizeAllToolStripMenuItem
        '
        Me.MinimumFileSizeAllToolStripMenuItem.Name = "MinimumFileSizeAllToolStripMenuItem"
        Me.MinimumFileSizeAllToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.MinimumFileSizeAllToolStripMenuItem.Tag = "-1"
        Me.MinimumFileSizeAllToolStripMenuItem.Text = Global.QITA_OLTK.My.MySettings.Default.Files_MinimumFileSize
        '
        'ClusterFilesWithToolStripMenuItem
        '
        Me.ClusterFilesWithToolStripMenuItem.Name = "ClusterFilesWithToolStripMenuItem"
        Me.ClusterFilesWithToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.ClusterFilesWithToolStripMenuItem.Tag = "-1"
        Me.ClusterFilesWithToolStripMenuItem.Text = Global.QITA_OLTK.My.MySettings.Default.Files_ClusterFilesSizeMod
        Me.ClusterFilesWithToolStripMenuItem.ToolTipText = "Eg.: For value 1000, all files varying by 1kB in file size are ignored and only o" & _
            "ne of them is used. This helps to have wide range of text samples."
        '
        'MaximumFilesCountAllToolStripMenuItem
        '
        Me.MaximumFilesCountAllToolStripMenuItem.Name = "MaximumFilesCountAllToolStripMenuItem"
        Me.MaximumFilesCountAllToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.MaximumFilesCountAllToolStripMenuItem.Tag = "-1"
        Me.MaximumFilesCountAllToolStripMenuItem.Text = Global.QITA_OLTK.My.MySettings.Default.Files_MaxFilesCount
        '
        'FilesContainingToolStripMenuItem
        '
        Me.FilesContainingToolStripMenuItem.Name = "FilesContainingToolStripMenuItem"
        Me.FilesContainingToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.FilesContainingToolStripMenuItem.Tag = ""
        Me.FilesContainingToolStripMenuItem.Text = Global.QITA_OLTK.My.MySettings.Default.File_ContainingStringFilter
        '
        'RandomizeDictionaryFileListToolStripMenuItem
        '
        Me.RandomizeDictionaryFileListToolStripMenuItem.Checked = Global.QITA_OLTK.My.MySettings.Default.Files_RandomizeDictionaryFileList
        Me.RandomizeDictionaryFileListToolStripMenuItem.CheckOnClick = True
        Me.RandomizeDictionaryFileListToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RandomizeDictionaryFileListToolStripMenuItem.Name = "RandomizeDictionaryFileListToolStripMenuItem"
        Me.RandomizeDictionaryFileListToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.RandomizeDictionaryFileListToolStripMenuItem.Text = "Randomize dictionary file list"
        '
        'IgnoreBinaryFilesToolStripMenuItem
        '
        Me.IgnoreBinaryFilesToolStripMenuItem.Checked = Global.QITA_OLTK.My.MySettings.Default.Files_IgnoreBinaryFiles
        Me.IgnoreBinaryFilesToolStripMenuItem.CheckOnClick = True
        Me.IgnoreBinaryFilesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IgnoreBinaryFilesToolStripMenuItem.Name = "IgnoreBinaryFilesToolStripMenuItem"
        Me.IgnoreBinaryFilesToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.IgnoreBinaryFilesToolStripMenuItem.Text = "Ignore binary files"
        Me.IgnoreBinaryFilesToolStripMenuItem.ToolTipText = "QITA can load binary files like pictures (PNG, BMP, JPG), videos, executable file" & _
            "s and convert them into alphabetic strings."
        '
        'PrependDirectoryNameToFiles
        '
        Me.PrependDirectoryNameToFiles.Checked = Global.QITA_OLTK.My.MySettings.Default.Files_PrependDirectoryName
        Me.PrependDirectoryNameToFiles.CheckOnClick = True
        Me.PrependDirectoryNameToFiles.Image = CType(resources.GetObject("PrependDirectoryNameToFiles.Image"), System.Drawing.Image)
        Me.PrependDirectoryNameToFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrependDirectoryNameToFiles.Name = "PrependDirectoryNameToFiles"
        Me.PrependDirectoryNameToFiles.Size = New System.Drawing.Size(142, 22)
        Me.PrependDirectoryNameToFiles.Text = "Prepend directory name"
        '
        'UCFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UCFiles"
        Me.Size = New System.Drawing.Size(774, 437)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        CType(Me.gridFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents gridFiles As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsCmdAddMultipleTexts As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdAddText As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsClearTable As System.Windows.Forms.ToolStripButton
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents txtStats As System.Windows.Forms.TextBox
    Friend WithEvents tsCmdAddFilesFromDict As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents MaximumFileSizeAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinimumFileSizeAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MaximumFilesCountAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilesContainingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RandomizeDictionaryFileListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IgnoreBinaryFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClusterFilesWithToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsLoadRecent As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents clmnCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmnIcon As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents clmnTextName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnFile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnComments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnPreview As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEncoding As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents PrependDirectoryNameToFiles As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator

End Class
