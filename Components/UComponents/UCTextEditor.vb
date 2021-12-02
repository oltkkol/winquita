Public Class UCTextEditor

    Public Sub SetText(ByVal text As String)
        RichTextBox1.Text = text
    End Sub

    Private Sub cmdCopyToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyToClipboard.Click
        Clipboard.SetText(RichTextBox1.Text)
    End Sub

    Private Sub cmdSaveToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveToFile.Click
        Dim d As New SaveFileDialog
        d.Filter = "Text files (*.txt)|*.txt"

        If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim s As IO.StreamWriter = IO.File.CreateText(d.FileName)
            s.Write(RichTextBox1.Text)
            s.Close()
        End If
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub UCTextEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
