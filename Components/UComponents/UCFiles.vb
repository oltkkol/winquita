Imports System.Runtime.CompilerServices
Imports QITA_OLTK.QITAInterfaceImplementations
Imports QITA_OLTK.QITADataTypes
Imports QITA_OLTK.QITAInterfaces
Imports QITA_OLTK.QITAIndexes
Imports QITA_OLTK.QITAMorphoAnalyzers
Imports System.Text

Public Class UCFiles
    Private _TextToRowDictionary As New Dictionary(Of IQITAText, DataGridViewRow)

    Public Enum TextStatus
        Working
        Text
        InQueue
        Ready
    End Enum

#Region ":: Main Functions"
    Private Function AddNewText(ByVal sTextFilePath As String, ByVal bFromFilesDialog As Boolean) As Boolean
        Dim m As New QITAText()
        Dim sError As String = Nothing
        Dim bFileIsOk As Boolean = True

        If Not bFromFilesDialog Then
            If Me.IgnoreBinaryFiles AndAlso (Not IsFileTextFile(sTextFilePath)) Then
                sError = "File is not plain Text."
                bFileIsOk = False
                Return False
            End If
        End If

        If bFileIsOk Then
            If IsTextFileAlreadyLoaded(sTextFilePath) Then
                Return True
            End If

            If m.LoadFromFile(sTextFilePath, sError) Then
                If Me.PrependDirectoryNameToTextName Then
                    m.TextName = "[" & GetLastDirectoryName(sTextFilePath) & "] " & m.TextName
                End If

                AddNewQITAText(m)
                Return True
            End If
        End If

        If Me.IgnoreBinaryFiles Then
            If sError.Contains("Unsupported file extension") Then Return False
        End If

        MsgBox("Could not open: " & sTextFilePath & Environment.NewLine & "Reason: " & sError, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        Return False
    End Function

    Private Function IsTextFileAlreadyLoaded(ByVal sFilePath As String) As Boolean
        For Each t As IQITAText In _TextToRowDictionary.Keys
            If String.Compare(t.TextFile, sFilePath) = 0 Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub AddNewQITAText(ByRef text As IQITAText)
        Dim newRow As DataGridViewRow = AddNewTextToTextGrid(text)
        _TextToRowDictionary.Add(text, newRow)
    End Sub

    Private Sub ReloadText(ByRef text As IQITAText, ByVal sEncodingName As String)
        If text.ReLoadFile(sEncodingName) Then
            ReloadTextGridData()
        End If
    End Sub

    Public Function GetAllTexts() As List(Of IQITAText)
        Dim texts As New List(Of IQITAText)

        For Each r As DataGridViewRow In gridFiles.Rows
            texts.Add(DirectCast(r.Tag, IQITAText))
        Next

        Return texts
    End Function

    Public Sub SetAllTextsStatusToInQueue()
        For Each textRow As DataGridViewRow In gridFiles.Rows
            If IsTextRowChecked(textRow) Then
                SetGridRowIcon(textRow, TextStatus.InQueue)
            End If
        Next
    End Sub

    Public Sub SetTextStatus(ByRef text As IQITAText, ByVal e As TextStatus)
        If _TextToRowDictionary.ContainsKey(text) Then
            SetGridRowIcon(_TextToRowDictionary(text), e)
        End If
    End Sub

    Public ReadOnly Property TextsCount() As Integer
        Get
            Return gridFiles.Rows.Count
        End Get
    End Property

    Public Sub SetRowSelection(ByRef text As IQITAText)
        gridFiles.CurrentCell = gridFiles.Rows(_TextToRowDictionary(text).Index).Cells(0)
    End Sub

    Public Sub Clear()
        If _TextToRowDictionary IsNot Nothing Then
            For Each t As DataGridViewRow In _TextToRowDictionary.Values
                t.Tag = Nothing
                t.Dispose()
            Next

            _TextToRowDictionary.Clear()
            _TextToRowDictionary = Nothing
        End If

        GC.Collect()
    End Sub

    Private Sub UpdateStats()
        Dim size As Long = 0

        For Each row As DataGridViewRow In gridFiles.Rows
            size += Len(DirectCast(row.Tag, IQITAText).TextData)
        Next

        size = size \ 1000000
        SetStatus("Text count: " & gridFiles.Rows.Count & ", Size: " & size & " MB")
    End Sub

    Private Sub SetStatus(ByVal s As String)
        txtStats.Text = s
    End Sub

    Public Function GetFilesListInString() As String
        Dim sFiles As New stringbuilder

        For Each t As IQITAText In Me._TextToRowDictionary.Keys
            sFiles.Append(t.TextFile & vbTab)
        Next

        Return sFiles.ToString()
    End Function

    Public Function LoadFilesFromString(ByVal sFilesList As String) As Integer
        Dim i As Integer
        Dim s As String() = sFilesList.Split(New String() {vbTab}, StringSplitOptions.RemoveEmptyEntries)

        SetWorking(Me, True)

        For Each sFilePath As String In s
            If IO.File.Exists(sFilePath) Then
                Me.AddNewText(sFilePath, False)
                Application.DoEvents()
                i += 1
            End If
        Next

        Me.UpdateStats()
        SetWorking(Me, False)
        Beep()
        Return i
    End Function
#End Region

#Region ":: Abstract DataGrid Operator"
    Private Function AddNewTextToTextGrid(ByRef text As IQITAText) As DataGridViewRow
        Dim i As Integer = gridFiles.Rows.Add(True, _
                                                imgList.Images("text"), _
                                                text.TextName, _
                                                text.TextFile, _
                                                text.TextData.Length, _
                                                text.TextDescription, _
                                                "", _
                                                text.GetPreview())

        Dim encodings As DataGridViewComboBoxCell = gridFiles.Rows(i).Cells("clmnEncoding")
        For Each s As String In GetAllEncodersList()
            encodings.Items.Add(s)
        Next

        encodings.Value = text.Encoding()
        encodings.Tag = text
        gridFiles.Rows(i).Tag = text

        'If text.TextData.Contains("Ă") Then
        '    gridFiles.Rows(i).DefaultCellStyle.BackColor = Color.Red
        'End If

        Return gridFiles.Rows(i)
    End Function

    Private Sub RemoveText(ByRef text As IQITAText)
        _TextToRowDictionary.Remove(text)
    End Sub

    Private Sub CheckTextRow(ByRef textRow As DataGridViewRow)
        textRow.Cells("clmnCheck").Value = Not textRow.Cells("clmnCheck").Value
    End Sub

    Private Function IsTextRowChecked(ByRef textRow As DataGridViewRow) As Boolean
        Return textRow.Cells("clmnCheck").Value
    End Function

    Private Sub SetGridRowIcon(ByRef row As DataGridViewRow, ByRef eImage As TextStatus)
        Dim s As String

        Select Case eImage
            Case TextStatus.Working
                s = "right"
            Case TextStatus.InQueue
                s = "waiting"
            Case TextStatus.Ready
                s = "ready"
            Case Else
                s = "text"
        End Select

        row.Cells("clmnIcon").Value = imgList.Images(s)
        Application.DoEvents()
    End Sub

    Private Function GetTextGridRowText(ByRef r As DataGridViewRow) As IQITAText
        Return r.Tag
    End Function

    Private Sub ReloadTextGridData()
        Dim t As IQITAText

        For Each r As DataGridViewRow In gridFiles.Rows
            t = GetTextGridRowText(r)

            r.Cells("clmnPreview").Value = t.GetPreview()
        Next

    End Sub

    Private Sub AddFilesFromDirectory(ByVal sDirectory As String)
        SetWorking(Me, True)

        Dim iCount As Integer = 0
        Dim fileSize As Long
        Dim fileList As New List(Of String)(113)
        Dim sizeCounter As New Dictionary(Of Long, String)

        For Each sFile As String In IO.Directory.GetFiles(sDirectory, "*.*", IO.SearchOption.AllDirectories)
            fileList.Add(sFile)
            Application.DoEvents()
        Next

        If Me.RandomizeFilesInDictionaries Then
            fileList = RandomizeList(fileList)
        End If

        If Me.ClusterFilesWithSimilarSize > 0 Then
            For Each sFile As String In fileList
                fileSize = My.Computer.FileSystem.GetFileInfo(sFile).Length
                fileSize = fileSize \ Me.ClusterFilesWithSimilarSize

                If Not sizeCounter.ContainsKey(fileSize) Then
                    sizeCounter.Add(fileSize, sFile)
                End If
            Next

            fileList = sizeCounter.Values.ToList()
        End If

        For Each sFile As String In fileList
            If Me.FileSubstringFilter <> "*" Then
                If Not StrContains(sFile, Me.FileSubstringFilter) Then Continue For
            End If

            fileSize = My.Computer.FileSystem.GetFileInfo(sFile).Length

            If Me.MaximumFilesToRead > -1 Then
                If iCount > Me.MaximumFilesToRead Then
                    Exit For
                End If
            End If

            If Me.MaximumFileSize > -1 Then
                If Me.MaximumFileSize < fileSize Then
                    Continue For
                End If
            End If

            If Me.MinimumFileSize > -1 Then
                If Me.MinimumFileSize > fileSize Then
                    Continue For
                End If
            End If

            If AddNewText(sFile, False) Then
                iCount += 1
            End If

            Application.DoEvents()
        Next

        UpdateStats()
        SetWorking(Me, False)
    End Sub
#End Region

#Region "GUI"
    Private Sub ProcessDragDrop(ByVal e As System.Windows.Forms.DragEventArgs)
        Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

        SetWorking(Me, True)

        For Each s As String In files
            If IsPathDirectory(s) Then
                AddFilesFromDirectory(s)
            Else
                AddNewText(s, True)
            End If

            Application.DoEvents()
        Next

        UpdateStats()
        SetWorking(Me, False)
    End Sub

    Private Sub ProcessDragEnter(ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub gridFiles_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles gridFiles.DragDrop
        ProcessDragDrop(e)
    End Sub

    Private Sub gridFiles_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles gridFiles.DragEnter
        ProcessDragEnter(e)
    End Sub

    Private Sub cmdAddText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddText.Click
        Dim k As New UFNewTextWizard

        If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
            AddNewQITAText(k.LoadedText)
        End If
    End Sub

    Private Sub tsCmdAddMultipleTexts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCmdAddMultipleTexts.Click
        Dim k As New OpenFileDialog()
        k.Multiselect = True

        If k.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SetWorking(Me, True)
            SetStatus("Adding files... Wait please...")

            For Each s As String In k.FileNames
                AddNewText(s, True)
            Next

            UpdateStats()
            SetWorking(Me, False)
        End If
    End Sub

    Private Sub tsCmdAddFilesFromDict_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCmdAddFilesFromDict.ButtonClick
        Dim d As New FolderBrowserDialog
        d.SelectedPath = My.Settings.LastViewedDirectoryPath

        If d.ShowDialog = Windows.Forms.DialogResult.OK Then
            SetStatus("Searching directories, addings files... Wait please...")
            AddFilesFromDirectory(d.SelectedPath)
        End If

        My.Settings.LastViewedDirectoryPath = d.SelectedPath
    End Sub

    Private Sub tsLoadRecent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLoadRecent.Click
        Me.LoadFilesFromString(My.Settings.Files_RecentFiles)
    End Sub

    Private Sub gridFiles_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridFiles.CellEndEdit
        Dim o As Object = gridFiles.Rows(e.RowIndex).Tag

        If IsAny(Text) Then
            If TypeOf (o) Is IQITAText Then
                Dim text As IQITAText = o
                Dim sValue As String = gridFiles.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

                Select Case e.ColumnIndex
                    Case gridFiles.Columns("clmnTextName").Index
                        text.TextName = sValue
                    Case gridFiles.Columns("clmnDescription").Index
                        text.TextDescription = sValue

                    Case gridFiles.Columns("clmnComments").Index

                End Select
            End If
        End If
    End Sub

    Private Sub gridFiles_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridFiles.KeyUp
        If e.KeyCode = Keys.Space Then
            If gridFiles.SelectedRows().Count Then
                For Each t As DataGridViewRow In gridFiles.SelectedRows()
                    CheckTextRow(t)
                Next
            End If
        End If
    End Sub

    Private Sub tsClearTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsClearTable.Click
        If MsgBox("Do You really wish to remove all texts?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            gridFiles.Rows.Clear()
            _TextToRowDictionary.Clear()
        End If

        UpdateStats()
    End Sub

    Private Sub cmbTextEncoding_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim c As ComboBox = sender

        ReloadText(c.Tag, c.Text)
        Debug.Print("cmbTextEncoding_SelectedIndexChanged for " & c.Text & " -- " & c.Tag.GetPreview())
    End Sub
#End Region

#Region "GRID GUI"
    Private p_LastCombo As ComboBox = Nothing
    Private Sub gridFiles_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridFiles.EditingControlShowing
        If gridFiles.CurrentCell.ColumnIndex = gridFiles.Columns("clmnEncoding").Index Then
            If TypeOf e.Control Is ComboBox Then
                Dim c As ComboBox = e.Control
                c.Tag = gridFiles.Rows(gridFiles.CurrentCell.RowIndex).Tag

                RemoveHandler c.SelectedIndexChanged, AddressOf cmbTextEncoding_SelectedIndexChanged
                AddHandler c.SelectedIndexChanged, AddressOf cmbTextEncoding_SelectedIndexChanged

                p_LastCombo = c

                Debug.Print("gridFiles_EditingControlShowing")
            End If

        End If
    End Sub

    Private Sub gridFiles_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles gridFiles.RowStateChanged
        If IsAny(p_LastCombo) Then
            RemoveHandler p_LastCombo.SelectedIndexChanged, AddressOf cmbTextEncoding_SelectedIndexChanged
        End If
    End Sub

    Private Sub gridFiles_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles gridFiles.SortCompare
        If e.Column.Index > -1 Then
            If IsNumeric(e.CellValue1) AndAlso IsNumeric(e.CellValue2) Then
                Dim a As Double = ToNumber(e.CellValue1)
                Dim b As Double = ToNumber(e.CellValue2)

                If a > b Then
                    e.SortResult = 1
                ElseIf a = b Then
                    e.SortResult = 0
                ElseIf a < b Then
                    e.SortResult = -1
                End If

                e.Handled = True
            End If
        End If
    End Sub

    Private Sub gridFiles_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles gridFiles.RowsRemoved
        UpdateStats()
    End Sub
#End Region

#Region "FILE CONSTRAINS"
    Private ReadOnly Property MaximumFileSize() As Double
        Get
            Return Val(GetToolStripMenuItemValue(MaximumFileSizeAllToolStripMenuItem))
        End Get
    End Property

    Private ReadOnly Property MinimumFileSize() As Double
        Get
            Return Val(GetToolStripMenuItemValue(MinimumFileSizeAllToolStripMenuItem))
        End Get
    End Property

    Private ReadOnly Property MaximumFilesToRead() As Integer
        Get
            Return Val(GetToolStripMenuItemValue(MaximumFilesCountAllToolStripMenuItem))
        End Get
    End Property

    Private ReadOnly Property PrependDirectoryNameToTextName() As Boolean
        Get
            Return PrependDirectoryNameToFiles.Checked
        End Get
    End Property

    Private ReadOnly Property IgnoreBinaryFiles() As Boolean
        Get
            Return IgnoreBinaryFilesToolStripMenuItem.Checked
        End Get
    End Property

    Private ReadOnly Property FileSubstringFilter() As String
        Get
            Return CStr(GetToolStripMenuItemValue(FilesContainingToolStripMenuItem))
        End Get
    End Property

    Private ReadOnly Property RandomizeFilesInDictionaries() As Boolean
        Get
            Return RandomizeDictionaryFileListToolStripMenuItem.Checked
        End Get
    End Property

    Private ReadOnly Property ClusterFilesWithSimilarSize() As Long
        Get
            Return Val(GetToolStripMenuItemValue(ClusterFilesWithToolStripMenuItem))
        End Get
    End Property

    Private Sub MaximumFileSizeAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaximumFileSizeAllToolStripMenuItem.Click
        EditControlTagAndTextByUserInput(MaximumFileSizeAllToolStripMenuItem, _
                                         "MAXimum File Size", _
                                         "Enter new Maximum size (in Bytes). Use -1 for All.", _
                                         True, _
                                         Nothing, _
                                         "Bytes")

        My.Settings.Files_MaxFileSize = MaximumFileSizeAllToolStripMenuItem.Text
    End Sub

    Private Sub MinimumFileSizeAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimumFileSizeAllToolStripMenuItem.Click
        EditControlTagAndTextByUserInput(MinimumFileSizeAllToolStripMenuItem, "MINimum File Size", "Enter new Minimum size (in Bytes). Use -1 for All.", True, Nothing, "Bytes")

        My.Settings.Files_MinimumFileSize = MinimumFileSizeAllToolStripMenuItem.Text
    End Sub

    Private Sub MaximumFilesCountAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaximumFilesCountAllToolStripMenuItem.Click
        EditControlTagAndTextByUserInput(MaximumFilesCountAllToolStripMenuItem, "Maximum Files Count", "Enter new Maximum Files Count. Use -1 for All.", True, Nothing)
        My.Settings.Files_MaxFilesCount = MaximumFilesCountAllToolStripMenuItem.Text
    End Sub

    Private Sub FilesContainingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilesContainingToolStripMenuItem.Click
        EditControlTagAndTextByUserInput(FilesContainingToolStripMenuItem, "Files containing in name", "Enter substring that has to be contained in file name. Use * for anything.", False, Nothing)
        My.Settings.File_ContainingStringFilter = FilesContainingToolStripMenuItem.Text
    End Sub

    Private Sub ClusterFilesWithToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClusterFilesWithToolStripMenuItem.Click
        EditControlTagAndTextByUserInput(ClusterFilesWithToolStripMenuItem, "Use only one file of similar size", "Enter new file size clustering will (in Bytes). Use 0 for Disable.", True, Nothing)
        My.Settings.Files_ClusterFilesSizeMod = ClusterFilesWithToolStripMenuItem.Text
    End Sub

    Private Sub PrependDirectoryNameToFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrependDirectoryNameToFiles.Click
        My.Settings.Files_PrependDirectoryName = PrependDirectoryNameToFiles.Checked
    End Sub
#End Region
End Class
