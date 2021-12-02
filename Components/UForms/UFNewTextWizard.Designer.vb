<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFNewTextWizard
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
        Me.UcOpenNewFile1 = New QITA_OLTK.UCCreateNewText
        Me.SuspendLayout()
        '
        'UcOpenNewFile1
        '
        Me.UcOpenNewFile1.AllowDrop = True
        Me.UcOpenNewFile1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOpenNewFile1.Location = New System.Drawing.Point(0, 0)
        Me.UcOpenNewFile1.Name = "UcOpenNewFile1"
        Me.UcOpenNewFile1.Size = New System.Drawing.Size(569, 361)
        Me.UcOpenNewFile1.TabIndex = 0
        Me.UcOpenNewFile1.TextFile = Nothing
        '
        'UFNewTextWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 361)
        Me.Controls.Add(Me.UcOpenNewFile1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "UFNewTextWizard"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Text"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcOpenNewFile1 As QITA_OLTK.UCCreateNewText
End Class
