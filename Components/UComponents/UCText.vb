Imports QITA_OLTK.QITADataTypes
Imports QITA_OLTK.QITAInterfaces

Public Class UCText
    Private p_TextData As IQITAText = Nothing

    Public Event TextDataChanged(ByRef sender As UCText)

    Public Property TextData() As IQITAText
        Get
            Return p_TextData
        End Get

        Set(ByVal value As IQITAText)
            p_TextData = value
            DisplayText(value.TextData)
        End Set
    End Property

    Private Sub SetNewText(ByVal sNewText As String)
        p_TextData.TextData = sNewText

        RaiseEvent TextDataChanged(Me)
    End Sub

    Private Sub DisplayText(ByVal sTextContent As String)
        rtbText.Text = sTextContent
    End Sub

    Private Sub rtbText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbText.TextChanged
        SetNewText(rtbText.Text)
    End Sub
End Class
