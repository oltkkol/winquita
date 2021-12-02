<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCCreateNewText
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCCreateNewText))
        Me.txtTextDescription = New System.Windows.Forms.TextBox
        Me.lblTextName = New System.Windows.Forms.Label
        Me.cmdStorno = New System.Windows.Forms.Button
        Me.txtTextName = New System.Windows.Forms.TextBox
        Me.grpTextInfo = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.pbName = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.grpData = New System.Windows.Forms.GroupBox
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.rtfLoadedData = New System.Windows.Forms.RichTextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsPasteFromClipboard = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsLoadFile = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.tsEncoding = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsLock = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsMakeRandomText = New System.Windows.Forms.ToolStripButton
        Me.grpTextInfo.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpData.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTextDescription
        '
        Me.txtTextDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTextDescription.Location = New System.Drawing.Point(93, 43)
        Me.txtTextDescription.Name = "txtTextDescription"
        Me.txtTextDescription.Size = New System.Drawing.Size(467, 20)
        Me.txtTextDescription.TabIndex = 2
        '
        'lblTextName
        '
        Me.lblTextName.AutoSize = True
        Me.lblTextName.Location = New System.Drawing.Point(24, 22)
        Me.lblTextName.Name = "lblTextName"
        Me.lblTextName.Size = New System.Drawing.Size(38, 13)
        Me.lblTextName.TabIndex = 8
        Me.lblTextName.Text = "Name:"
        '
        'cmdStorno
        '
        Me.cmdStorno.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdStorno.Image = CType(resources.GetObject("cmdStorno.Image"), System.Drawing.Image)
        Me.cmdStorno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdStorno.Location = New System.Drawing.Point(3, 242)
        Me.cmdStorno.Name = "cmdStorno"
        Me.cmdStorno.Size = New System.Drawing.Size(111, 29)
        Me.cmdStorno.TabIndex = 7
        Me.cmdStorno.Text = "&Cancel"
        Me.cmdStorno.UseVisualStyleBackColor = True
        '
        'txtTextName
        '
        Me.txtTextName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTextName.Location = New System.Drawing.Point(93, 17)
        Me.txtTextName.Name = "txtTextName"
        Me.txtTextName.Size = New System.Drawing.Size(467, 20)
        Me.txtTextName.TabIndex = 1
        '
        'grpTextInfo
        '
        Me.grpTextInfo.Controls.Add(Me.PictureBox2)
        Me.grpTextInfo.Controls.Add(Me.Label3)
        Me.grpTextInfo.Controls.Add(Me.pbName)
        Me.grpTextInfo.Controls.Add(Me.txtTextDescription)
        Me.grpTextInfo.Controls.Add(Me.txtTextName)
        Me.grpTextInfo.Controls.Add(Me.Label1)
        Me.grpTextInfo.Controls.Add(Me.lblTextName)
        Me.grpTextInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpTextInfo.Location = New System.Drawing.Point(0, 0)
        Me.grpTextInfo.Name = "grpTextInfo"
        Me.grpTextInfo.Size = New System.Drawing.Size(566, 74)
        Me.grpTextInfo.TabIndex = 0
        Me.grpTextInfo.TabStop = False
        Me.grpTextInfo.Text = "Text info"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(8, 47)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Description:"
        '
        'pbName
        '
        Me.pbName.Image = CType(resources.GetObject("pbName.Image"), System.Drawing.Image)
        Me.pbName.Location = New System.Drawing.Point(8, 21)
        Me.pbName.Name = "pbName"
        Me.pbName.Size = New System.Drawing.Size(16, 16)
        Me.pbName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbName.TabIndex = 11
        Me.pbName.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Name:"
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(449, 242)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(114, 29)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "O&K"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'grpData
        '
        Me.grpData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpData.Controls.Add(Me.ToolStripContainer1)
        Me.grpData.Location = New System.Drawing.Point(0, 74)
        Me.grpData.Name = "grpData"
        Me.grpData.Size = New System.Drawing.Size(566, 161)
        Me.grpData.TabIndex = 3
        Me.grpData.TabStop = False
        Me.grpData.Text = "Data"
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.rtfLoadedData)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(560, 117)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(560, 142)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'rtfLoadedData
        '
        Me.rtfLoadedData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfLoadedData.Location = New System.Drawing.Point(0, 0)
        Me.rtfLoadedData.Name = "rtfLoadedData"
        Me.rtfLoadedData.Size = New System.Drawing.Size(560, 117)
        Me.rtfLoadedData.TabIndex = 5
        Me.rtfLoadedData.Text = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPasteFromClipboard, Me.ToolStripSeparator1, Me.tsLoadFile, Me.ToolStripSeparator2, Me.ToolStripLabel2, Me.tsEncoding, Me.ToolStripSeparator4, Me.tsLock, Me.ToolStripSeparator3, Me.tsMakeRandomText})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(557, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsPasteFromClipboard
        '
        Me.tsPasteFromClipboard.Image = CType(resources.GetObject("tsPasteFromClipboard.Image"), System.Drawing.Image)
        Me.tsPasteFromClipboard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPasteFromClipboard.Name = "tsPasteFromClipboard"
        Me.tsPasteFromClipboard.Size = New System.Drawing.Size(127, 22)
        Me.tsPasteFromClipboard.Text = "&Paste from Clipboard"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsLoadFile
        '
        Me.tsLoadFile.Image = CType(resources.GetObject("tsLoadFile.Image"), System.Drawing.Image)
        Me.tsLoadFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLoadFile.Name = "tsLoadFile"
        Me.tsLoadFile.Size = New System.Drawing.Size(104, 22)
        Me.tsLoadFile.Text = "&Load from file..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(16, 22)
        '
        'tsEncoding
        '
        Me.tsEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tsEncoding.DropDownWidth = 150
        Me.tsEncoding.Name = "tsEncoding"
        Me.tsEncoding.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsLock
        '
        Me.tsLock.CheckOnClick = True
        Me.tsLock.Image = CType(resources.GetObject("tsLock.Image"), System.Drawing.Image)
        Me.tsLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLock.Name = "tsLock"
        Me.tsLock.Size = New System.Drawing.Size(83, 22)
        Me.tsLock.Text = "&Lock Editing"
        Me.tsLock.ToolTipText = "Prevents accidental text editing"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsMakeRandomText
        '
        Me.tsMakeRandomText.Image = CType(resources.GetObject("tsMakeRandomText.Image"), System.Drawing.Image)
        Me.tsMakeRandomText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsMakeRandomText.Name = "tsMakeRandomText"
        Me.tsMakeRandomText.Size = New System.Drawing.Size(131, 20)
        Me.tsMakeRandomText.Text = "Make Random Text..."
        '
        'UCCreateNewText
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.grpData)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdStorno)
        Me.Controls.Add(Me.grpTextInfo)
        Me.Name = "UCCreateNewText"
        Me.Size = New System.Drawing.Size(566, 279)
        Me.grpTextInfo.ResumeLayout(False)
        Me.grpTextInfo.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpData.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTextDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblTextName As System.Windows.Forms.Label
    Friend WithEvents cmdStorno As System.Windows.Forms.Button
    Friend WithEvents txtTextName As System.Windows.Forms.TextBox
    Friend WithEvents grpTextInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents pbName As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpData As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsPasteFromClipboard As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsLoadFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents rtfLoadedData As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsLock As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsEncoding As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsMakeRandomText As System.Windows.Forms.ToolStripButton

End Class
