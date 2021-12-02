<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFRandomTextCreator
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
        Me.txtAlphabete = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdMake = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtWordMaxSize = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtWordMinSize = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMaxWordsCount = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.textEditor = New QITA_OLTK.UCTextEditor
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAlphabete
        '
        Me.txtAlphabete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlphabete.Location = New System.Drawing.Point(70, 13)
        Me.txtAlphabete.Name = "txtAlphabete"
        Me.txtAlphabete.Size = New System.Drawing.Size(466, 20)
        Me.txtAlphabete.TabIndex = 4
        Me.txtAlphabete.Text = "abcdefghijklmnopqrstuvwxyz"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdMake)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtWordMaxSize)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtWordMinSize)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMaxWordsCount)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAlphabete)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(546, 73)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'cmdMake
        '
        Me.cmdMake.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMake.Location = New System.Drawing.Point(426, 37)
        Me.cmdMake.Name = "cmdMake"
        Me.cmdMake.Size = New System.Drawing.Size(110, 22)
        Me.cmdMake.TabIndex = 12
        Me.cmdMake.Text = "OK"
        Me.cmdMake.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(295, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Word max size:"
        '
        'txtWordMaxSize
        '
        Me.txtWordMaxSize.Location = New System.Drawing.Point(377, 39)
        Me.txtWordMaxSize.Name = "txtWordMaxSize"
        Me.txtWordMaxSize.Size = New System.Drawing.Size(35, 20)
        Me.txtWordMaxSize.TabIndex = 10
        Me.txtWordMaxSize.Text = "8"
        Me.txtWordMaxSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(142, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Word min size:"
        '
        'txtWordMinSize
        '
        Me.txtWordMinSize.Location = New System.Drawing.Point(224, 39)
        Me.txtWordMinSize.Name = "txtWordMinSize"
        Me.txtWordMinSize.Size = New System.Drawing.Size(65, 20)
        Me.txtWordMinSize.TabIndex = 8
        Me.txtWordMinSize.Text = "1"
        Me.txtWordMinSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Words:"
        '
        'txtMaxWordsCount
        '
        Me.txtMaxWordsCount.Location = New System.Drawing.Point(70, 39)
        Me.txtMaxWordsCount.Name = "txtMaxWordsCount"
        Me.txtMaxWordsCount.Size = New System.Drawing.Size(66, 20)
        Me.txtMaxWordsCount.TabIndex = 6
        Me.txtMaxWordsCount.Text = "1000"
        Me.txtMaxWordsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Alphabete:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.textEditor)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(546, 368)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Result"
        '
        'textEditor
        '
        Me.textEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textEditor.Location = New System.Drawing.Point(3, 16)
        Me.textEditor.Name = "textEditor"
        Me.textEditor.Size = New System.Drawing.Size(540, 349)
        Me.textEditor.TabIndex = 0
        '
        'UFRandomTextCreator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 471)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UFRandomTextCreator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "(CPU) Random Text Creator:"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAlphabete As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWordMaxSize As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtWordMinSize As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMaxWordsCount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdMake As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents textEditor As QITA_OLTK.UCTextEditor
End Class
