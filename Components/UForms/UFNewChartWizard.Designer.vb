<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFNewChartWizard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UFNewChartWizard))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbX = New QITA_OLTK.ComboBoxEx
        Me.chkUseComplexStructure = New System.Windows.Forms.CheckBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.grpY = New System.Windows.Forms.GroupBox
        Me.cbY = New QITA_OLTK.ComboBoxEx
        Me.grpDesc = New System.Windows.Forms.GroupBox
        Me.cbDesc = New QITA_OLTK.ComboBoxEx
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cbExistingChart = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtChartName = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkChartAllProjects = New System.Windows.Forms.CheckBox
        Me.grpSerieName = New System.Windows.Forms.GroupBox
        Me.txtSerieName = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.raUseOnlySelectedRowsAsSource = New System.Windows.Forms.RadioButton
        Me.raUseAllRowsAsSource = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.grpY.SuspendLayout()
        Me.grpDesc.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grpSerieName.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbX)
        Me.GroupBox1.Controls.Add(Me.chkUseComplexStructure)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(485, 47)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "&X values / Source column:"
        '
        'cbX
        '
        Me.cbX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbX.DisplayDescriptions = False
        Me.cbX.DisplayEmptyGroups = False
        Me.cbX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbX.FormattingEnabled = True
        Me.cbX.GroupHeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.cbX.HideSelectedItemWhenControlDisabled = False
        Me.cbX.ImageList = Nothing
        Me.cbX.Location = New System.Drawing.Point(6, 17)
        Me.cbX.Name = "cbX"
        Me.cbX.Size = New System.Drawing.Size(346, 21)
        Me.cbX.TabIndex = 2
        '
        'chkUseComplexStructure
        '
        Me.chkUseComplexStructure.AutoSize = True
        Me.chkUseComplexStructure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkUseComplexStructure.Location = New System.Drawing.Point(358, 21)
        Me.chkUseComplexStructure.Name = "chkUseComplexStructure"
        Me.chkUseComplexStructure.Size = New System.Drawing.Size(121, 17)
        Me.chkUseComplexStructure.TabIndex = 1
        Me.chkUseComplexStructure.Text = "Use alternative &data"
        Me.chkUseComplexStructure.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(12, 433)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(114, 29)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(383, 433)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(114, 29)
        Me.cmdOK.TabIndex = 7
        Me.cmdOK.Text = "O&K"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'grpY
        '
        Me.grpY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpY.Controls.Add(Me.cbY)
        Me.grpY.Location = New System.Drawing.Point(12, 118)
        Me.grpY.Name = "grpY"
        Me.grpY.Size = New System.Drawing.Size(485, 51)
        Me.grpY.TabIndex = 1
        Me.grpY.TabStop = False
        Me.grpY.Text = "&Y values column:"
        '
        'cbY
        '
        Me.cbY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbY.DisplayDescriptions = True
        Me.cbY.DisplayEmptyGroups = False
        Me.cbY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbY.FormattingEnabled = True
        Me.cbY.GroupHeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.cbY.HideSelectedItemWhenControlDisabled = True
        Me.cbY.ImageList = Nothing
        Me.cbY.Location = New System.Drawing.Point(6, 19)
        Me.cbY.Name = "cbY"
        Me.cbY.Size = New System.Drawing.Size(473, 21)
        Me.cbY.TabIndex = 0
        '
        'grpDesc
        '
        Me.grpDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDesc.Controls.Add(Me.cbDesc)
        Me.grpDesc.Location = New System.Drawing.Point(12, 175)
        Me.grpDesc.Name = "grpDesc"
        Me.grpDesc.Size = New System.Drawing.Size(485, 51)
        Me.grpDesc.TabIndex = 2
        Me.grpDesc.TabStop = False
        Me.grpDesc.Text = "D&escription column (or Z values for Bubble chart):"
        '
        'cbDesc
        '
        Me.cbDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDesc.DisplayDescriptions = True
        Me.cbDesc.DisplayEmptyGroups = False
        Me.cbDesc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDesc.FormattingEnabled = True
        Me.cbDesc.GroupHeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.cbDesc.HideSelectedItemWhenControlDisabled = True
        Me.cbDesc.ImageList = Nothing
        Me.cbDesc.Location = New System.Drawing.Point(6, 19)
        Me.cbDesc.Name = "cbDesc"
        Me.cbDesc.Size = New System.Drawing.Size(473, 21)
        Me.cbDesc.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.cbExistingChart)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 277)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(485, 42)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Add &to existing chart:"
        '
        'cbExistingChart
        '
        Me.cbExistingChart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbExistingChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbExistingChart.FormattingEnabled = True
        Me.cbExistingChart.Items.AddRange(New Object() {" "})
        Me.cbExistingChart.Location = New System.Drawing.Point(6, 15)
        Me.cbExistingChart.Name = "cbExistingChart"
        Me.cbExistingChart.Size = New System.Drawing.Size(473, 21)
        Me.cbExistingChart.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtChartName)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 325)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(485, 47)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Chart &name:"
        '
        'txtChartName
        '
        Me.txtChartName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtChartName.Location = New System.Drawing.Point(6, 19)
        Me.txtChartName.Name = "txtChartName"
        Me.txtChartName.Size = New System.Drawing.Size(473, 20)
        Me.txtChartName.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chkChartAllProjects)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 232)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(485, 39)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Multi-charting:"
        '
        'chkChartAllProjects
        '
        Me.chkChartAllProjects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkChartAllProjects.AutoSize = True
        Me.chkChartAllProjects.Checked = Global.QITA_OLTK.My.MySettings.Default.NewChartWizard_DoForAllProjects
        Me.chkChartAllProjects.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.QITA_OLTK.My.MySettings.Default, "NewChartWizard_DoForAllProjects", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkChartAllProjects.Location = New System.Drawing.Point(6, 16)
        Me.chkChartAllProjects.Name = "chkChartAllProjects"
        Me.chkChartAllProjects.Size = New System.Drawing.Size(248, 17)
        Me.chkChartAllProjects.TabIndex = 0
        Me.chkChartAllProjects.Text = "Do for All &Projects (into the same chart window)"
        Me.chkChartAllProjects.UseVisualStyleBackColor = True
        '
        'grpSerieName
        '
        Me.grpSerieName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSerieName.Controls.Add(Me.txtSerieName)
        Me.grpSerieName.Location = New System.Drawing.Point(12, 378)
        Me.grpSerieName.Name = "grpSerieName"
        Me.grpSerieName.Size = New System.Drawing.Size(485, 47)
        Me.grpSerieName.TabIndex = 6
        Me.grpSerieName.TabStop = False
        Me.grpSerieName.Text = "Se&rie name:"
        '
        'txtSerieName
        '
        Me.txtSerieName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSerieName.Location = New System.Drawing.Point(6, 19)
        Me.txtSerieName.Name = "txtSerieName"
        Me.txtSerieName.Size = New System.Drawing.Size(473, 20)
        Me.txtSerieName.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.raUseOnlySelectedRowsAsSource)
        Me.GroupBox5.Controls.Add(Me.raUseAllRowsAsSource)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(485, 47)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "&Rows to chart:"
        '
        'raUseOnlySelectedRowsAsSource
        '
        Me.raUseOnlySelectedRowsAsSource.AutoSize = True
        Me.raUseOnlySelectedRowsAsSource.Checked = Global.QITA_OLTK.My.MySettings.Default.NewChartWizard_OnlySelectedRows
        Me.raUseOnlySelectedRowsAsSource.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.QITA_OLTK.My.MySettings.Default, "NewChartWizard_OnlySelectedRows", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.raUseOnlySelectedRowsAsSource.Location = New System.Drawing.Point(122, 19)
        Me.raUseOnlySelectedRowsAsSource.Name = "raUseOnlySelectedRowsAsSource"
        Me.raUseOnlySelectedRowsAsSource.Size = New System.Drawing.Size(114, 17)
        Me.raUseOnlySelectedRowsAsSource.TabIndex = 1
        Me.raUseOnlySelectedRowsAsSource.TabStop = True
        Me.raUseOnlySelectedRowsAsSource.Text = "Only &selected rows"
        Me.raUseOnlySelectedRowsAsSource.UseVisualStyleBackColor = True
        '
        'raUseAllRowsAsSource
        '
        Me.raUseAllRowsAsSource.AutoSize = True
        Me.raUseAllRowsAsSource.Checked = True
        Me.raUseAllRowsAsSource.Location = New System.Drawing.Point(10, 19)
        Me.raUseAllRowsAsSource.Name = "raUseAllRowsAsSource"
        Me.raUseAllRowsAsSource.Size = New System.Drawing.Size(61, 17)
        Me.raUseAllRowsAsSource.TabIndex = 0
        Me.raUseAllRowsAsSource.TabStop = True
        Me.raUseAllRowsAsSource.Text = "&All rows"
        Me.raUseAllRowsAsSource.UseVisualStyleBackColor = True
        '
        'UFNewChartWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 464)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.grpSerieName)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grpDesc)
        Me.Controls.Add(Me.grpY)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(357, 487)
        Me.Name = "UFNewChartWizard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Chart Wizard..."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpY.ResumeLayout(False)
        Me.grpDesc.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grpSerieName.ResumeLayout(False)
        Me.grpSerieName.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grpY As System.Windows.Forms.GroupBox
    Friend WithEvents grpDesc As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbExistingChart As System.Windows.Forms.ComboBox
    Friend WithEvents chkUseComplexStructure As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtChartName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkChartAllProjects As System.Windows.Forms.CheckBox
    Friend WithEvents grpSerieName As System.Windows.Forms.GroupBox
    Friend WithEvents txtSerieName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents raUseOnlySelectedRowsAsSource As System.Windows.Forms.RadioButton
    Friend WithEvents raUseAllRowsAsSource As System.Windows.Forms.RadioButton
    Friend WithEvents cbY As QITA_OLTK.ComboBoxEx
    Friend WithEvents cbDesc As QITA_OLTK.ComboBoxEx
    Friend WithEvents cbX As QITA_OLTK.ComboBoxEx
End Class
