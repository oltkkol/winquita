<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFCompareProjectsValues
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UFCompareProjectsValues))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbSecondProject = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.lvResults = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.tsCopyToClipboard = New System.Windows.Forms.ToolStrip
        Me.tsToClipboard = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tsCopyToClipboard.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbSecondProject)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(531, 46)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'cmbSecondProject
        '
        Me.cmbSecondProject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbSecondProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSecondProject.FormattingEnabled = True
        Me.cmbSecondProject.Location = New System.Drawing.Point(3, 16)
        Me.cmbSecondProject.Name = "cmbSecondProject"
        Me.cmbSecondProject.Size = New System.Drawing.Size(525, 21)
        Me.cmbSecondProject.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.tsCopyToClipboard)
        Me.GroupBox2.Controls.Add(Me.txtStatus)
        Me.GroupBox2.Controls.Add(Me.lvResults)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(531, 401)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Results of comparsion"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtStatus.Location = New System.Drawing.Point(3, 378)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(525, 20)
        Me.txtStatus.TabIndex = 1
        '
        'lvResults
        '
        Me.lvResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvResults.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvResults.FullRowSelect = True
        Me.lvResults.Location = New System.Drawing.Point(3, 44)
        Me.lvResults.Name = "lvResults"
        Me.lvResults.Size = New System.Drawing.Size(525, 328)
        Me.lvResults.TabIndex = 0
        Me.lvResults.UseCompatibleStateImageBehavior = False
        Me.lvResults.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Index"
        Me.ColumnHeader1.Width = 208
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Result"
        Me.ColumnHeader2.Width = 244
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Significant"
        Me.ColumnHeader3.Width = 71
        '
        'tsCopyToClipboard
        '
        Me.tsCopyToClipboard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsToClipboard})
        Me.tsCopyToClipboard.Location = New System.Drawing.Point(3, 16)
        Me.tsCopyToClipboard.Name = "tsCopyToClipboard"
        Me.tsCopyToClipboard.Size = New System.Drawing.Size(525, 25)
        Me.tsCopyToClipboard.TabIndex = 2
        Me.tsCopyToClipboard.Text = "ToolStrip1"
        '
        'tsToClipboard
        '
        Me.tsToClipboard.Image = CType(resources.GetObject("tsToClipboard.Image"), System.Drawing.Image)
        Me.tsToClipboard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsToClipboard.Name = "tsToClipboard"
        Me.tsToClipboard.Size = New System.Drawing.Size(115, 22)
        Me.tsToClipboard.Text = "Copy To Clipboard"
        '
        'UFCompareProjectsValues
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 477)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Name = "UFCompareProjectsValues"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Projects results comparsion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tsCopyToClipboard.ResumeLayout(False)
        Me.tsCopyToClipboard.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSecondProject As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lvResults As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tsCopyToClipboard As System.Windows.Forms.ToolStrip
    Friend WithEvents tsToClipboard As System.Windows.Forms.ToolStripButton
End Class
