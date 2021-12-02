Imports QITA_OLTK.QITAInterfaces
Imports QITA_OLTK.QITAInterfaceImplementations
Imports QITA_OLTK.QITADataTypes

Public Class UCResultData
    Private _Project As IQITAProject = Nothing
    Private _Result As IQITAResult = Nothing

#Region "  MAIN PUBLIC"
    Public Property Project() As IQITAProject
        Get
            Return _Project
        End Get
        Set(ByVal value As IQITAProject)
            _Project = value
        End Set
    End Property

    Public ReadOnly Property Result() As IQITAResult
        Get
            Return _Result
        End Get
    End Property

    Public Sub ShowData(ByRef resultData As IQITAResult)
        If IsAny(resultData) Then
            _Result = resultData

            SetMeWorking(True)
            If resultData.IsComplex Then
                Dim value As Object = resultData.ComplexValue

                Select Case True
                    Case TypeOf value Is String
                        ShowString(value)

                    Case TypeOf value Is Array
                        ShowDataArray(value)

                    Case TypeOf value Is List(Of String)
                        ShowDataListOfString(value)

                    Case TypeOf value Is QITAPositiveArray
                        ShowDataPositiveTable(value)

                    Case TypeOf value Is QITATextTable
                        ShowDataTable(value)

                    Case TypeOf value Is QITATable
                        ShowDataTable(value)
                End Select
            End If

            ResizeColumns()
            SetMeWorking(False)
        End If
    End Sub
#End Region

#Region "  LISTVIEW CONTROL"
    Private Sub AddRow(ByRef iRowIndex As Integer, ByVal sData As String, Optional ByVal sData2 As String = Nothing)
        With lvData.Items.Add(iRowIndex).SubItems
            .Add(iRowIndex)
            .Add(sData)
            .Add(sData2)
        End With
    End Sub

    Private Sub SetColumn1Name(ByVal sName As String)
        lvData.Columns(2).Text = sName
    End Sub

    Private Sub SetColumn2Name(ByVal sName As String)
        lvData.Columns(3).Text = sName
    End Sub

    Private Sub ResizeColumns()
        'Dim contentSizes As New List(Of Integer)
        'lvData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

        'For i As Integer = 0 To lvData.Columns.Count - 1
        '    contentSizes.Add(lvData.Columns(i).Width)
        'Next

        Application.DoEvents()
        lvData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        'Application.DoEvents()

        'For i As Integer = 0 To lvData.Columns.Count - 1
        '    lvData.Columns(i).Width = Math.Max(contentSizes(i), lvData.Columns(i).Width)
        'Next
    End Sub

    Private Sub lvData_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvData.ColumnClick
        SortLV(lvData, e)
    End Sub

#End Region

#Region "  DATA SHOW"
    Private Sub ShowDataTable(ByRef p As QITATable)
        Dim b As Boolean = CBool(p.PreferredDisplayType = QITATable.ePreferredDisplay.AsList)

        lvData.Visible = b
        gridData.Visible = Not b

        'ShowDataTableDataGrid(p)

        ShowDataTableListView(p)

        'If p.PreferredDisplayType = QITATable.ePreferredDisplay.AsList Then
        '    ShowDataTableListView(p)
        'Else
        '    ShowDataTableDataGrid(p)
        'End If
    End Sub

    Private Sub ShowDataTableDataGrid(ByRef p As QITATable)
        gridData.Columns.Clear()
        gridData.ColumnCount = p.ColumnCount
        gridData.AllowUserToResizeColumns = True
        gridData.AllowUserToResizeRows = False
        gridData.AllowUserToOrderColumns = True

        For i As Integer = 0 To p.ColumnCount - 1
            gridData.Columns(i).HeaderText = p.ColumnNames(i)
            gridData.Columns(i).Resizable = DataGridViewTriState.True
        Next

        For i As Integer = 1 To p.RowsCount
            Dim row As Integer = gridData.Rows.Add()

            For iColumn As Integer = 0 To p.ColumnCount - 1
                gridData.Item(iColumn, row) = New DataGridViewTextBoxCell()
                gridData.Item(iColumn, row).Value = p.CellValue(i, iColumn)
            Next
        Next

        gridData.BringToFront()
    End Sub

    Private Sub ShowDataTableListView(ByRef p As QITATable)
        lvData.Columns.Clear()

        For i As Integer = 0 To p.Columns.Count - 1
            lvData.Columns.Add(p.ColumnNames(i))
        Next

        For i As Integer = 1 To p.RowsCount
            With lvData.Items.Add(CStr(p.CellValue(i, 0))).SubItems

                For j As Integer = 1 To p.Columns.Count - 1
                    If IsAny(p.CellValue(i, j)) Then
                        .Add(p.CellValue(i, j).ToString())
                    Else
                        .Add("")
                    End If
                Next
            End With

            DoEventsWhen(i)
        Next

        lvData.BringToFront()
    End Sub

    Private Sub ShowDataPositiveTable(ByRef p As QITAPositiveArray)
        For i As Integer = 1 To p.Count - 1
            AddRow(i, p.At(i))

            DoEventsWhen(i)
        Next
    End Sub

    Private Sub ShowDataListOfString(ByRef p As List(Of String))
        For i As Integer = 0 To p.Count - 1
            AddRow(i + 1, p(i))

            DoEventsWhen(i)
        Next
    End Sub

    Private Sub ShowString(ByRef s As Object)
        AddRow(0, s)
    End Sub

    Private Sub ShowDataArray(ByRef p() As Object)
        For i As Integer = 0 To p.Count - 1
            AddRow(i + 1, p(i))

            DoEventsWhen(i)
        Next
    End Sub
#End Region

#Region "  STYLE EDITOR"
    Private Sub tsMarkRowColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMarkRed.Click, tsMarkPurple.Click, tsMarkOrange.Click, tsMarkGreen.Click, tsMarkBlue.Click, tsMarkColorDef.Click
        ColorSelectedRows(sender.Text)
    End Sub

    Private Sub RowTextStyleChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldToolStripMenuItem.Click, UnderlineToolStripMenuItem.Click, ItalicToolStripMenuItem.Click, StrikeoutToolStripMenuItem.Click
        If lvData.SelectedItems.Count Then
            Dim s As FontStyle

            For Each lvItem As ListViewItem In lvData.SelectedItems
                s = lvItem.Font.Style

                Select Case DirectCast(sender, ToolStripMenuItem).Text
                    Case "Bold"
                        AddOrRemoveStyle(s, FontStyle.Bold)
                    Case "Italic"
                        AddOrRemoveStyle(s, FontStyle.Italic)
                    Case "Underline"
                        AddOrRemoveStyle(s, FontStyle.Underline)
                    Case "Strike-out"
                        AddOrRemoveStyle(s, FontStyle.Strikeout)
                    Case Else

                        s = FontStyle.Regular
                End Select

                lvItem.Font = New Font(lvData.Font, s)
            Next
        End If
    End Sub

    Private Sub ColorSelectedRows(ByVal sColorName As String)
        If lvData.SelectedItems.Count Then
            Dim c As Color

            Select Case sColorName
                Case "Red"
                    c = Color.FromArgb(255, &H66, &H66)
                Case "Blue"
                    c = Color.FromArgb(&H77, &HCC, &HFF)
                Case "Orange"
                    c = Color.FromArgb(&HFF, &H99, &H66)
                Case "Purple"
                    c = Color.FromArgb(&HCC, &H66, &HCC)
                Case "Green"
                    c = Color.FromArgb(&H66, &HFF, &H66)
                Case Else
                    c = Color.White
            End Select

            For Each lvItem As ListViewItem In lvData.SelectedItems
                If lvItem.BackColor = c Then
                    lvItem.BackColor = Color.White
                    lvItem.ImageKey = Nothing
                Else
                    lvItem.BackColor = c
                    lvItem.ImageKey = IIf(sColorName = "Default", Nothing, sColorName)
                End If
            Next
        End If
    End Sub
#End Region

#Region "  DATA EXPORT"
    Private Sub CopyGridToClipboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyGridToClipboardToolStripMenuItem.Click
        SetWorking(Me, True)
        Clipboard.SetText(GridToCSV())
        SetWorking(Me, False)
    End Sub

    Private Sub ExportGridToCSVFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportGridToCSVFileToolStripMenuItem.Click
        SetWorking(Me, True)

        Dim sSuggestedName As String = ""

        If IsAny(Me.Project) Then
            sSuggestedName = Me.Project.ProjectName & " - "
        End If

        sSuggestedName += Me.Result.ResultName

        NewTextFileWithPrompt(sSuggestedName, GridToCSV())
        SetWorking(Me, False)
    End Sub

    Private Function GridToCSV() As String
        'If gridData.Visible Then
        '    Return DataGridViewToCSV(gridData)
        'Else
        Return ListViewToCSV(lvData)
        'End If
    End Function
#End Region

    Private Sub SetMeWorking(ByVal b As Boolean)
        lvData.Visible = Not b
        gridData.Visible = Not b
        lblStatus.Visible = b
        Application.DoEvents()

        If b Then
            lblStatus.BringToFront()
            lvData.BeginUpdate()
        Else
            lvData.EndUpdate()
        End If
    End Sub

    Private Sub UCResultData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

End Class

