Imports QITA_OLTK.QITAInterfaceImplementations
Imports QITA_OLTK.QITAInterfaces

Public Class UCCreateNewText
    Private p_TextData As IQITAText = Nothing
    Private p_TextFile As String = Nothing
    Public Event FileLoaded(ByRef outLoadedText As IQITAText)
    Public Event FileLoadStorno()

#Region "Properties"
    Public Property TextFile() As String
        Get
            Return p_TextFile
        End Get
        Set(ByVal value As String)
            p_TextFile = value
        End Set
    End Property

    ''' <summary>
    ''' Text contained in Text Data.
    ''' </summary>
    Public Property DraftText() As String
        Get
            Return rtfLoadedData.Text
        End Get
        Set(ByVal value As String)
            rtfLoadedData.Text = value
        End Set
    End Property
#End Region

#Region "Load Text Data File And Info"

    ''' <summary>
    ''' Loads given file.
    ''' </summary>
    ''' <param name="sFile">Path to file.</param>
    ''' <param name="e">If set to NOTHING, encoding is detected.</param>
    ''' <returns>TRUE if succesfull.</returns>
    Private Function LoadFile(ByVal sFile As String, ByRef e As System.Text.Encoding) As Boolean
        Dim sError As String = Nothing
        Dim sContent As String = Nothing

        SetFileName(Nothing)
        SetEncoding(e)

        If GetFileTextContent(sFile, sContent, e, False, sError) Then
            TextFile = sFile
            ShowBasicStats(sContent)
            SetFileName(sFile)
            SetContent(sContent)
            SetEncoding(e)


        Else
            MsgBox("Error while loading file:" & Environment.NewLine & sFile & Environment.NewLine & sError, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Function

    Private Function ReloadFileContent() As Boolean
        If StrIsAny(TextFile) Then
            LoadFile(TextFile, GetEncoding())
        End If
    End Function

    Private Sub LoadFileFromDialogue()
        Dim k As New OpenFileDialog
        k.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadFile(k.FileName, Nothing)
            LockEdit()
        End If
    End Sub

    Private Sub ShowBasicStats(ByVal sText As String)

    End Sub

    Private Sub SetFileName(ByVal s As String)
        If Not StrIsAny(txtTextName.Text) Then
            txtTextName.Text = GetFileNameFromPath(s)
        End If
    End Sub

    Private Sub SetContent(ByVal sContent As String)
        rtfLoadedData.Text = sContent
        rtfLoadedData.Refresh()
    End Sub

    Private Sub LockEdit()
        tsLock.Checked = True
    End Sub

    Private Sub SetEncoding(ByRef e As System.Text.Encoding)
        If IsAny(e) Then
            tsEncoding.Text = e.WebName
        Else
            tsEncoding.Text = "[Try Detect]"
        End If
    End Sub

    Private Function GetEncoding() As System.Text.Encoding
        Dim t As System.Text.Encoding = Nothing

        Try
            t = System.Text.Encoding.GetEncoding(tsEncoding.Text)
        Catch e As Exception
        End Try

        Return t
    End Function
#End Region

#Region "Form Events"
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If StrIsAny(rtfLoadedData.Text) Then
            If Not StrIsAny(txtTextName.Text) Then
                txtTextName.Text = "Text" & TimeOfDay.Ticks.ToString()
            End If

            p_TextData = New QITAText(txtTextName.Text, rtfLoadedData.Text, txtTextDescription.Text)
            RaiseEvent FileLoaded(p_TextData)

            ClearForm()
        Else
            Beep()
        End If
    End Sub

    Private Sub UCOpenNewFile_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

        For Each s As String In files
            LoadFile(s, Nothing)
            Exit For                            'load only one file
        Next
    End Sub

    Private Sub UCOpenNewFile_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub cmdStorno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStorno.Click
        ClearForm()
        Storno()
    End Sub

    Private Sub Storno()
        RaiseEvent FileLoadStorno()
    End Sub

    Private Sub ClearForm()
        txtTextDescription.Clear()
        txtTextName.Clear()
    End Sub

    Private Sub tsLoadFile_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLoadFile.Click
        LoadFileFromDialogue()
    End Sub

    Private Sub tsPasteFromClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPasteFromClipboard.Click
        rtfLoadedData.Text = Clipboard.GetText()
    End Sub

    Private Sub tsLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLock.CheckedChanged
        rtfLoadedData.ReadOnly = tsLock.Checked
    End Sub

    Private Sub tsEncoding_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsEncoding.SelectedIndexChanged
        ReloadFileContent()
    End Sub

    Private Sub UCOpenNewFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each s As String In GetAllEncodersList()
            tsEncoding.Items.Add(s)
        Next

        SetEncoding(Nothing)
    End Sub

    Private Sub tsMakeRandomText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMakeRandomText.Click
        UFRandomTextCreator.ShowDialog()
    End Sub
#End Region

End Class
