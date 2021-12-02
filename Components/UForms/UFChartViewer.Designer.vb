<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFChartViewer
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UFChartViewer))
        Me.UcChart1 = New QITA_OLTK.UCChart
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'UcChart1
        '
        Me.UcChart1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcChart1.Location = New System.Drawing.Point(0, 0)
        Me.UcChart1.Name = "UcChart1"
        Me.UcChart1.Size = New System.Drawing.Size(641, 447)
        Me.UcChart1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "chart_line.png")
        Me.ImageList1.Images.SetKeyName(1, "database_table.png")
        '
        'UFChartViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 447)
        Me.Controls.Add(Me.UcChart1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Name = "UFChartViewer"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "UFChartViewer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcChart1 As QITA_OLTK.UCChart
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
