Imports QITA_OLTK.QITAInterfaces

Public Class UFTextViewer
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByRef text As IQITAText)
        InitializeComponent()
        SetText(text)
    End Sub

    Public Sub SetText(ByRef text As IQITAText)
        rtText.Text = text.TextData
        tsInfo.Text = "Size: " & Format(Len(text.TextData), "### ### ### ### ### B")
        Me.Text = "Vieweing: " & text.TextName & EnBraceIfNeeded(text.TextDescription)
    End Sub

    Private Sub tsFind_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFind.ButtonClick
        MsgBox("Not implemented yet.")
    End Sub
End Class