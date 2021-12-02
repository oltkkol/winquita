'Option Strict On
Imports System.ComponentModel

''' <summary>
''' TabControl extension with close buttons.
''' </summary>
''' <remarks>TabPage Tag property is used for "noClose" string remarking tab page without close buttons.</remarks>
Public Class TabControlEx
    Inherits TabControl
    Private Declare Auto Function SetParent Lib "user32" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    Protected CloseButtonsDictionary As New Dictionary(Of Button, TabPage)

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        RePositionCloseButtons()
    End Sub

    Protected Overrides Sub OnControlAdded(ByVal e As System.Windows.Forms.ControlEventArgs)
        MyBase.OnControlAdded(e)

        Dim newTabPage As TabPage = DirectCast(e.Control, TabPage)

        If Not StrContains(CStr(newTabPage.Tag), "noClose") Then
            Dim newCloseButton As Button = AddCloseButton(newTabPage)

            If IsAny(newCloseButton) Then
                SetParent(newCloseButton.Handle, Me.Handle)
                CloseButtonsDictionary.Add(newCloseButton, newTabPage)

                AddHandler newCloseButton.Click, AddressOf OnCloseButtonClick

                newTabPage.Text += "      "
            End If
        End If

        RePositionCloseButtons()
    End Sub

    Protected Overrides Sub OnControlRemoved(ByVal e As System.Windows.Forms.ControlEventArgs)
        Dim closeButton As Button = GetCloseButton(DirectCast(e.Control, TabPage))

        If IsAny(closeButton) Then
            RemoveHandler closeButton.Click, AddressOf OnCloseButtonClick
            CloseButtonsDictionary.Remove(closeButton)

            SetParent(closeButton.Handle, Nothing)
            closeButton.Dispose()

            MyBase.OnControlRemoved(e)
            MyBase.SelectedTab = MyBase.TabPages(MyBase.TabCount - 2)
        End If
    End Sub

    Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)
        MyBase.OnLayout(levent)
        RePositionCloseButtons()
    End Sub

    Public Event CloseButtonClick As CancelEventHandler

    Protected Overridable Sub OnCloseButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        If Not DesignMode Then
            Dim ee As New CancelEventArgs
            Dim tab As TabPage = CloseButtonsDictionary(DirectCast(sender, Button))

            RaiseEvent CloseButtonClick(sender, ee)

            If Not ee.Cancel Then
                Me.TabPages.Remove(tab)
                RePositionCloseButtons()
            End If
        End If
    End Sub

    Protected Overridable Function AddCloseButton(ByVal tp As TabPage) As Button
        Dim closeButton As New Button

        With closeButton
            .Image = My.Resources.cross
            .FlatStyle = FlatStyle.Flat
            .BackColor = Color.FromKnownColor(KnownColor.ButtonFace)
            .ForeColor = .BackColor
        End With

        Return closeButton
    End Function

    Public Sub RePositionCloseButtons()
        For Each tabPage In CloseButtonsDictionary.Values
            RePositionCloseButtons(tabPage)
        Next
    End Sub

    Public Sub RePositionCloseButtons(ByVal tp As TabPage)
        Dim btn As Button = GetCloseButton(tp)

        If btn IsNot Nothing Then
            Dim tpIndex As Integer = Me.TabPages.IndexOf(tp)

            If tpIndex >= 0 Then
                Dim rect As Rectangle = Me.GetTabRect(tpIndex)

                btn.Size = My.Resources.cross.Size

                btn.Location = New Point(rect.X + rect.Width - btn.Width - 3, _
                                          CInt(IIf(Me.SelectedTab Is tp, _
                                                (rect.Height \ 2) - (btn.Height \ 2), _
                                                (rect.Height \ 2) - (btn.Height \ 2) + 3)))

                btn.BringToFront()
            End If
        End If
    End Sub

    Protected Function GetCloseButton(ByVal tp As TabPage) As Button
        Return (From item In CloseButtonsDictionary Where item.Value Is tp Select item.Key).FirstOrDefault
    End Function
End Class