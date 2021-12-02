Public Class UFObjectEditor
    Public Sub New(ByVal sWindowName As String, ByRef objectToEdit As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        PropertyGrid1.SelectedObject = objectToEdit
        Me.Text = sWindowName
    End Sub
End Class