Public Class UFRandomTextCreator

    Public Shared Function MakeRandomText(ByVal textSizeInWords As Integer, _
                              ByVal sAlphabete As String, _
                              ByVal minimumWordLength As Integer, _
                              ByVal maximumWordLength As Integer) As String
        Dim s As New System.Text.StringBuilder

        For i As Integer = 1 To textSizeInWords
            s.Append(MakeRandomWord(minimumWordLength, maximumWordLength, sAlphabete) & " ")
        Next

        Return s.ToString()
    End Function

    Public Shared Function MakeRandomWord(ByVal minSize As Integer, ByVal maxSize As String, ByVal sAlphabete As String) As String
        Dim word As String = ""
        Dim wordSize As Integer = RandomNumber(minSize, maxSize)

        For i As Integer = If(minSize = maxSize, 1, minSize) To wordSize
            word += sAlphabete(RandomNumber(0, sAlphabete.Length - 1))
        Next

        Return word
    End Function

    Private Sub cmdMake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMake.Click
        textEditor.SetText(MakeRandomText(Val(txtMaxWordsCount.Text), txtAlphabete.Text, Val(txtWordMinSize.Text), Val(txtWordMaxSize.Text)))
    End Sub

    Private Sub UFRandomTextCreator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class