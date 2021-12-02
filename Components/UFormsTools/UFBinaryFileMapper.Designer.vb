<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFBinaryFileMapper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UFBinaryFileMapper))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.txtAlphabete = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFileInfo = New System.Windows.Forms.Label
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.textEditor = New QITA_OLTK.UCTextEditor
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdOK)
        Me.GroupBox1.Controls.Add(Me.txtAlphabete)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblFileInfo)
        Me.GroupBox1.Controls.Add(Me.cmdBrowse)
        Me.GroupBox1.Controls.Add(Me.txtFile)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(597, 108)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(468, 73)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(123, 27)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "Create"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtAlphabete
        '
        Me.txtAlphabete.Location = New System.Drawing.Point(69, 43)
        Me.txtAlphabete.Name = "txtAlphabete"
        Me.txtAlphabete.Size = New System.Drawing.Size(522, 20)
        Me.txtAlphabete.TabIndex = 5
        Me.txtAlphabete.Text = "abcdefghijklmnopqrstuvwxyz"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Alphabete:"
        '
        'lblFileInfo
        '
        Me.lblFileInfo.AutoSize = True
        Me.lblFileInfo.Location = New System.Drawing.Point(10, 73)
        Me.lblFileInfo.Name = "lblFileInfo"
        Me.lblFileInfo.Size = New System.Drawing.Size(28, 13)
        Me.lblFileInfo.TabIndex = 3
        Me.lblFileInfo.Text = "Info:"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Image = CType(resources.GetObject("cmdBrowse.Image"), System.Drawing.Image)
        Me.cmdBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBrowse.Location = New System.Drawing.Point(468, 8)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(123, 25)
        Me.cmdBrowse.TabIndex = 2
        Me.cmdBrowse.Text = "Browse..."
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(69, 13)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(393, 20)
        Me.txtFile.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.textEditor)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 126)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(603, 249)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Result:"
        '
        'textEditor
        '
        Me.textEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textEditor.Location = New System.Drawing.Point(3, 16)
        Me.textEditor.Name = "textEditor"
        Me.textEditor.Size = New System.Drawing.Size(597, 230)
        Me.textEditor.TabIndex = 0
        '
        'UFBinaryFileMapper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 387)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UFBinaryFileMapper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Binary To Alphabete Text Mapper"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents textEditor As QITA_OLTK.UCTextEditor
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtAlphabete As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFileInfo As System.Windows.Forms.Label
End Class
