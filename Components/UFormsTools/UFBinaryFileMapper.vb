Public Class UFBinaryFileMapper

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim result As String = Nothing
        Dim sError As String = Nothing

        If BinaryFileToAlphabetedText(txtFile.Text, txtAlphabete.Text, result, sError) Then
            textEditor.SetText(result)
        Else
            MsgBox(sError, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Dim d As New OpenFileDialog
        If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFile.Text = d.FileName
        End If
    End Sub
End Class