Imports QITA_OLTK.QITADataTypes
Imports QITA_OLTK.QITAInterfaces

Public Class UFNewTextWizard
    Private p_Text As IQITAText = Nothing

    Public ReadOnly Property LoadedText() As IQITAText
        Get
            Return p_Text
        End Get
    End Property

    Private Sub UcOpenNewFile1_FileLoaded(ByRef outLoadedText As IQITAText) Handles UcOpenNewFile1.FileLoaded
        p_Text = outLoadedText
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub UcOpenNewFile1_FileLoadStorno() Handles UcOpenNewFile1.FileLoadStorno
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class