Imports QITA_OLTK.QITAInterfaces

Public Class UCPostProcessorBrowser
    Inherits ComboBoxEx

    Public ReadOnly Property SelectedPostProcessor() As IQITATextPostProcessors
        Get
            If TypeOf MyBase.SelectedStoredObject Is IQITATextPostProcessors Then
                Return DirectCast(MyBase.SelectedStoredObject, IQITATextPostProcessors)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub Fill()
        MyBase.Items.Clear()
        MyBase.DropDownStyle = ComboBoxStyle.DropDownList

        MyBase.AddItem("[Nothing]")
        For Each r As IQITATextPostProcessors In Form1.AvailablePostProcessors
            MyBase.AddItem(r.Name, r.Description, r.Group, Nothing, r)
        Next
    End Sub

End Class
