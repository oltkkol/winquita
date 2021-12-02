<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFChartDataEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UFChartDataEditor))
        Me.propertyEditor = New System.Windows.Forms.PropertyGrid
        Me.lvPointsToEdit = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectAllContainingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.UnselectAllToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.InvertSelectionToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.RemoveSelectedToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'propertyEditor
        '
        Me.propertyEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.propertyEditor.Location = New System.Drawing.Point(3, 16)
        Me.propertyEditor.Name = "propertyEditor"
        Me.propertyEditor.Size = New System.Drawing.Size(260, 387)
        Me.propertyEditor.TabIndex = 0
        '
        'lvPointsToEdit
        '
        Me.lvPointsToEdit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPointsToEdit.CheckBoxes = True
        Me.lvPointsToEdit.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvPointsToEdit.Location = New System.Drawing.Point(0, 0)
        Me.lvPointsToEdit.Name = "lvPointsToEdit"
        Me.lvPointsToEdit.Size = New System.Drawing.Size(415, 336)
        Me.lvPointsToEdit.TabIndex = 0
        Me.lvPointsToEdit.UseCompatibleStateImageBehavior = False
        Me.lvPointsToEdit.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Label"
        Me.ColumnHeader1.Width = 261
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Size = New System.Drawing.Size(691, 406)
        Me.SplitContainer1.SplitterDistance = 421
        Me.SplitContainer1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ToolStripContainer1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(421, 406)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "&Chart"
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.txtStatus)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.lvPointsToEdit)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(415, 362)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(415, 387)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtStatus.Location = New System.Drawing.Point(0, 342)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(415, 20)
        Me.txtStatus.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator1, Me.UnselectAllToolStripButton, Me.InvertSelectionToolStripButton, Me.ToolStripSeparator2, Me.RemoveSelectedToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(381, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectAllContainingToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripDropDownButton1.Text = "&Select"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Image = CType(resources.GetObject("SelectAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectAllToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'SelectAllContainingToolStripMenuItem
        '
        Me.SelectAllContainingToolStripMenuItem.Image = CType(resources.GetObject("SelectAllContainingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectAllContainingToolStripMenuItem.Name = "SelectAllContainingToolStripMenuItem"
        Me.SelectAllContainingToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllContainingToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.SelectAllContainingToolStripMenuItem.Text = "Select All Containing..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'UnselectAllToolStripButton
        '
        Me.UnselectAllToolStripButton.Image = CType(resources.GetObject("UnselectAllToolStripButton.Image"), System.Drawing.Image)
        Me.UnselectAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnselectAllToolStripButton.Name = "UnselectAllToolStripButton"
        Me.UnselectAllToolStripButton.Size = New System.Drawing.Size(82, 22)
        Me.UnselectAllToolStripButton.Text = "&Unselect All"
        '
        'InvertSelectionToolStripButton
        '
        Me.InvertSelectionToolStripButton.Image = CType(resources.GetObject("InvertSelectionToolStripButton.Image"), System.Drawing.Image)
        Me.InvertSelectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InvertSelectionToolStripButton.Name = "InvertSelectionToolStripButton"
        Me.InvertSelectionToolStripButton.Size = New System.Drawing.Size(103, 22)
        Me.InvertSelectionToolStripButton.Text = "&Invert Selection"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'RemoveSelectedToolStripButton
        '
        Me.RemoveSelectedToolStripButton.Image = CType(resources.GetObject("RemoveSelectedToolStripButton.Image"), System.Drawing.Image)
        Me.RemoveSelectedToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RemoveSelectedToolStripButton.Name = "RemoveSelectedToolStripButton"
        Me.RemoveSelectedToolStripButton.Size = New System.Drawing.Size(109, 22)
        Me.RemoveSelectedToolStripButton.Text = "Remove selected"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.propertyEditor)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(266, 406)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "&Editable Properties"
        '
        'UFChartDataEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 406)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "UFChartDataEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chart Data Editor"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents propertyEditor As System.Windows.Forms.PropertyGrid
    Friend WithEvents lvPointsToEdit As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllContainingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UnselectAllToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InvertSelectionToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents RemoveSelectedToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
End Class
