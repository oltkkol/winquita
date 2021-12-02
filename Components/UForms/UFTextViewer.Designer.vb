<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFTextViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UFTextViewer))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsInfo = New System.Windows.Forms.ToolStripStatusLabel
        Me.rtText = New System.Windows.Forms.RichTextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsFind = New System.Windows.Forms.ToolStripSplitButton
        Me.HighlightResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.StatusStrip1)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.rtText)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(571, 399)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(571, 424)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 377)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(571, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsInfo
        '
        Me.tsInfo.Name = "tsInfo"
        Me.tsInfo.Size = New System.Drawing.Size(111, 17)
        Me.tsInfo.Text = "ToolStripStatusLabel1"
        '
        'rtText
        '
        Me.rtText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtText.Location = New System.Drawing.Point(0, 0)
        Me.rtText.Name = "rtText"
        Me.rtText.ReadOnly = True
        Me.rtText.Size = New System.Drawing.Size(571, 374)
        Me.rtText.TabIndex = 0
        Me.rtText.Text = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsFind})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(69, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'tsFind
        '
        Me.tsFind.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HighlightResultsToolStripMenuItem})
        Me.tsFind.Image = CType(resources.GetObject("tsFind.Image"), System.Drawing.Image)
        Me.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFind.Name = "tsFind"
        Me.tsFind.Size = New System.Drawing.Size(59, 22)
        Me.tsFind.Text = "Find"
        '
        'HighlightResultsToolStripMenuItem
        '
        Me.HighlightResultsToolStripMenuItem.Checked = True
        Me.HighlightResultsToolStripMenuItem.CheckOnClick = True
        Me.HighlightResultsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.HighlightResultsToolStripMenuItem.Name = "HighlightResultsToolStripMenuItem"
        Me.HighlightResultsToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.HighlightResultsToolStripMenuItem.Text = "Highlight results"
        '
        'UFTextViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 424)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UFTextViewer"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UFViewText"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents rtText As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsFind As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents HighlightResultsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsInfo As System.Windows.Forms.ToolStripStatusLabel
End Class
