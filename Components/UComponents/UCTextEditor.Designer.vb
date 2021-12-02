<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCTextEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCTextEditor))
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdCopyToClipboard = New System.Windows.Forms.Button
        Me.cmdSaveToFile = New System.Windows.Forms.Button
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Image = CType(resources.GetObject("cmdSelectAll.Image"), System.Drawing.Image)
        Me.cmdSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSelectAll.Location = New System.Drawing.Point(0, 334)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(108, 35)
        Me.cmdSelectAll.TabIndex = 11
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdCopyToClipboard
        '
        Me.cmdCopyToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCopyToClipboard.Image = CType(resources.GetObject("cmdCopyToClipboard.Image"), System.Drawing.Image)
        Me.cmdCopyToClipboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCopyToClipboard.Location = New System.Drawing.Point(218, 334)
        Me.cmdCopyToClipboard.Name = "cmdCopyToClipboard"
        Me.cmdCopyToClipboard.Size = New System.Drawing.Size(163, 35)
        Me.cmdCopyToClipboard.TabIndex = 10
        Me.cmdCopyToClipboard.Text = "Copy To Clipboard"
        Me.cmdCopyToClipboard.UseVisualStyleBackColor = True
        '
        'cmdSaveToFile
        '
        Me.cmdSaveToFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveToFile.Image = CType(resources.GetObject("cmdSaveToFile.Image"), System.Drawing.Image)
        Me.cmdSaveToFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSaveToFile.Location = New System.Drawing.Point(387, 334)
        Me.cmdSaveToFile.Name = "cmdSaveToFile"
        Me.cmdSaveToFile.Size = New System.Drawing.Size(163, 35)
        Me.cmdSaveToFile.TabIndex = 9
        Me.cmdSaveToFile.Text = "Save To File..."
        Me.cmdSaveToFile.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(550, 328)
        Me.RichTextBox1.TabIndex = 12
        Me.RichTextBox1.Text = ""
        '
        'UCTextEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdCopyToClipboard)
        Me.Controls.Add(Me.cmdSaveToFile)
        Me.Name = "UCTextEditor"
        Me.Size = New System.Drawing.Size(550, 372)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdCopyToClipboard As System.Windows.Forms.Button
    Friend WithEvents cmdSaveToFile As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox

End Class
