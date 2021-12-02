<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCText
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
        Me.rtbText = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'rtbText
        '
        Me.rtbText.BackColor = System.Drawing.Color.White
        Me.rtbText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rtbText.Location = New System.Drawing.Point(0, 0)
        Me.rtbText.Name = "rtbText"
        Me.rtbText.ReadOnly = True
        Me.rtbText.Size = New System.Drawing.Size(558, 429)
        Me.rtbText.TabIndex = 0
        Me.rtbText.Text = ""
        '
        'UCText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Controls.Add(Me.rtbText)
        Me.Name = "UCText"
        Me.Size = New System.Drawing.Size(558, 429)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbText As System.Windows.Forms.RichTextBox

End Class
