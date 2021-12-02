Imports QITA_OLTK.QITAInterfaces
Imports QITA_OLTK.QITADataTypes

Public Class UCResults
    Public Event OpenDataResult(ByRef result As IQITAResult)
    Public Event CompareIndexResults(ByRef QITAIndexType As Type)

    Private p_Project As IQITAProject = Nothing
    Private p_AllTexts As List(Of IQITAText) = Nothing

#Region "PROPERTIES"
    Public Property Project() As IQITAProject
        Get
            Return p_Project
        End Get
        Set(ByVal value As IQITAProject)
            p_Project = value
        End Set
    End Property

    Private Property AllTexts() As List(Of IQITAText)
        Get
            Return p_AllTexts
        End Get
        Set(ByVal value As List(Of IQITAText))
            p_AllTexts = value
        End Set
    End Property

    Private ReadOnly Property ShowResultsAsRows() As Boolean
        Get
            Return tsShowStyleRows.Checked
        End Get
    End Property

    ''' <summary>
    ''' Returns datagrid/listview/... containing result data.
    ''' </summary>
    Public ReadOnly Property DataSourceContainer() As Object
        Get
            Return gridResults
        End Get
    End Property

    Public ReadOnly Property SelectedTexts() As List(Of IQITAText)
        Get
            Dim n As New List(Of IQITAText)
            For Each r As DataGridViewRow In gridResults.Rows
                If r.Selected Then
                    n.Add(DirectCast(r.Tag, IQITAText))
                End If
            Next

            Return n
        End Get
    End Property
#End Region

#Region "PUBLIC Subs"
    Public Sub InitializeResults(ByRef textList As List(Of IQITAText))
        AllTexts = textList
        ReLoad()
    End Sub
#End Region

#Region "PRIVATE Table Results"
    Private Sub ReLoad()
        gridResults.Rows.Clear()
        gridResults.Columns.Clear()

        If Me.ShowResultsAsRows Then
            ShowResultsInRows(AllTexts)
        Else
            ShowResultsInColumns(AllTexts)
        End If

        InitializeCompareSubMenu(AllTexts)

        'datagrid scrollbar stuck hack
        gridResults.Dock = DockStyle.None
        gridResults.Dock = DockStyle.Fill
        gridResults.Focus()
    End Sub

    Private Sub PopulateGridColumns(ByRef columnNames As List(Of ColumnTextAndTagPair))
        gridResults.Columns.Clear()
        gridResults.ColumnCount = columnNames.Count
        gridResults.AllowUserToResizeColumns = True
        gridResults.AllowUserToResizeRows = False
        gridResults.AllowUserToOrderColumns = True

        For i As Integer = 0 To columnNames.Count - 1
            gridResults.Columns(i).HeaderText = columnNames(i).ColumnText
            gridResults.Columns(i).Tag = columnNames(i).ColumnTag
            gridResults.Columns(i).Resizable = DataGridViewTriState.True

            If i > 0 Then
                gridResults.Columns(i).ValueType = GetType(Double)
            End If
        Next
    End Sub

    Private Function MakeComplexDataLink(ByRef result As IQITAResult) As DataGridViewTextBoxCell
        Static f As New Font(gridResults.DefaultCellStyle.Font, FontStyle.Underline)
        Dim k As New DataGridViewTextBoxCell

        k.Value = result.ToCellString()
        k.Tag = result
        k.Style.Font = f
        k.Style.ForeColor = Color.Navy

        k.ToolTipText = "Double Click to open data in new tab."
        Return k
    End Function

    Private Function IndexInfosToColumnTextTagPairs(ByRef indexes As List(Of IQITAIndex)) As List(Of ColumnTextAndTagPair)
        Dim m As New List(Of ColumnTextAndTagPair)

        For Each index As IQITAIndex In indexes
            m.Add(New ColumnTextAndTagPair(index.IndexName, index))
        Next

        Return m
    End Function

    Private Function IsCellResult(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs, _
                                       ByRef outResult As IQITAResult) As Boolean
        Dim r As IQITAResult = Nothing

        If (e.ColumnIndex > -1) AndAlso (e.RowIndex > -1) Then
            Dim c As DataGridViewCell = gridResults.Item(e.ColumnIndex, e.RowIndex)

            If IsAny(c.Tag) Then
                If TypeOf c.Tag Is IQITAResult Then
                    r = c.Tag

                    If r.IsComplex() Then
                        outResult = r
                    End If

                    Return True
                End If
            End If
        End If

        Return False
    End Function

    '-- SHOW INDEXES IN COLUMN, TEXTS IN ROWS
    Private Sub ShowResultsInColumns(ByRef texts As List(Of IQITAText))
        Dim text As IQITAText
        Dim columnNames As New List(Of ColumnTextAndTagPair)

        '-- Populate Column Names
        columnNames.Add(New ColumnTextAndTagPair("Index"))
        For Each text In texts
            columnNames.Add(New ColumnTextAndTagPair(text.TextName))
        Next

        PopulateGridColumns(columnNames)
        EnableColumnsSorting(False)

        '-- Create List
        Dim result As IQITAResult
        Dim resultTypes As New HashSet(Of Type)
        For Each text In texts
            For Each result In text.ReadyResults
                If Not result.IsSecondary Then
                    resultTypes.Add(result.IndexReference.GetType())
                End If
            Next
        Next

        Dim bAddHeader As Boolean = True
        Dim rowData As New List(Of Object)

        For Each typeOfIndex As Type In resultTypes
            bAddHeader = True

            For Each text In texts
                result = text.GetResultByIndex(typeOfIndex)

                If IsAny(result) Then
                    If bAddHeader Then
                        rowData.Add(result.ResultName)
                        bAddHeader = False
                    End If

                    If result.IsComplex Then
                        rowData.Add(MakeComplexDataLink(result))
                    Else
                        rowData.Add(result.ToCellString())
                    End If
                Else
                    rowData.Add("n/a")
                End If
            Next

            'gridResults.Rows.Add(rowData.ToArray())
            AddRowDataToGrid(Nothing, Nothing, rowData)
            rowData.Clear()
        Next

    End Sub

    Private Sub AddAllTextAtributeToRow(ByVal sName As String, ByRef texts As List(Of IQITAText), ByVal f As Func(Of IQITAText, String))
        Dim sRow As New List(Of String)
        sRow.Add(sName)

        For Each text As IQITAText In texts
            sRow.Add(f(text))
        Next

        gridResults.Rows.Add(sRow.ToArray)
    End Sub

    '-- SHOW INDEXES IN ROW, TEXTS IN COLUMNS
    Private Sub ShowResultsInRows(ByRef texts As List(Of IQITAText))
        Dim columnNames As New List(Of ColumnTextAndTagPair)

        columnNames.Add(New ColumnTextAndTagPair("Text"))
        columnNames.AddRange(IndexInfosToColumnTextTagPairs(Me.Project.ComputedIndexes))
        PopulateGridColumns(columnNames)
        EnableColumnsSorting(True)

        For Each text As IQITAText In texts
            Dim rowData As New List(Of Object)
            rowData.Add(text.TextName) 'MakeComplexDataLink(text.GetTextTable()))

            For Each r As IQITAResult In text.ReadyResults()
                If Not r.IsSecondary Then
                    If r.IsComplex AndAlso IsAny(r.ComplexValue) Then
                        rowData.Add(MakeComplexDataLink(r))
                    Else
                        rowData.Add(r.ToCellString())
                    End If
                End If
            Next

            AddRowDataToGrid(text.TextName, text, rowData)
        Next
    End Sub

    Public Sub AddRowDataToGrid(ByVal sHeaderCellName As String, _
                                ByRef rowTag As Object, _
                                ByRef rowData As List(Of Object))
        Dim i As Integer = gridResults.Rows.Add
        Dim t As DataGridViewTextBoxCell = Nothing

        gridResults.Rows(i).HeaderCell.Value = sHeaderCellName
        gridResults.Rows(i).Tag = rowTag

        For n As Integer = 0 To rowData.Count - 1
            If (TypeOf rowData(n) Is DataGridViewTextBoxCell) Then
                t = rowData(n)
            Else
                t = New DataGridViewTextBoxCell()
                t.Value = rowData(n).ToString()
            End If

            gridResults.Rows(i).Cells(n) = t
            If t.Value = "[...]" Then
                gridResults.Rows(i).Cells(n).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub EnableColumnsSorting(ByVal bSort As Boolean)
        For Each c As DataGridViewColumn In gridResults.Columns
            c.SortMode = IIf(bSort, _
                                DataGridViewColumnSortMode.Automatic, _
                                DataGridViewColumnSortMode.NotSortable)
        Next
    End Sub

    '-- HELPER FUNCTIONS

    Private Function GetSelectedText() As IQITAText
        If gridResults.SelectedRows.Count > 0 Then
            Return DirectCast(gridResults.SelectedRows(0).Tag, IQITAText)
        End If

        Return Nothing
    End Function

    Private Sub DrawChart(ByVal bDrawNow As Boolean)
        Dim m As New UFNewChartWizard(New QITAProjectDataSource(Me.Project, gridResults), bDrawNow)

        If bDrawNow Then
            Form1.ShowChart(m.OutputChartViewer, m.OutputChartableArray)
        Else
            If m.ShowDialog() = DialogResult.OK Then
                Form1.ShowChart(m.OutputChartViewer, m.OutputChartableArray)
            End If
        End If
    End Sub
#End Region

#Region "PRIVATE Comparing"
    Private Sub InitializeCompareSubMenu(ByRef texts As List(Of IQITAText))
        tsCompareResults.DropDownItems.Clear()

        For Each index As IQITAIndex In Me.Project.ComputedIndexes
            If index.HasComparableResults Then
                Dim mnuItem As New System.Windows.Forms.ToolStripMenuItem

                With mnuItem
                    .Text = index.IndexName
                    .Tag = index
                End With

                AddHandler mnuItem.Click, AddressOf tsCompareIndexResults_Click
                tsCompareResults.DropDownItems.Add(mnuItem)
            End If
        Next
    End Sub

    Private Sub tsCompareIndexResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tsButton As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim index As IQITAIndex = DirectCast(tsButton.Tag, IQITAIndex)

        AddNewResultComparsion(index.GetType())
    End Sub
#End Region

#Region "PRIVATE Add Result Event Raisers"
    Private Sub AddNewResultData(ByRef complexResult As IQITAResult)
        RaiseEvent OpenDataResult(complexResult)
    End Sub

    Private Sub AddNewResultComparsion(ByRef QITAIndexType As Type)
        RaiseEvent CompareIndexResults(QITAIndexType)
    End Sub
#End Region

#Region "PRIVATE Form Events"
    Private Sub gridResults_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridResults.CellMouseEnter
        Dim r As IQITAResult = Nothing

        If IsCellResult(e, r) Then
            If r.IsComplex Then
                gridResults.Cursor = Cursors.Hand
                Exit Sub
            End If
        End If

        gridResults.Cursor = Cursors.Arrow
    End Sub

    Private Sub gridResults_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridResults.CellMouseLeave
        gridResults.Cursor = Cursors.Arrow
    End Sub

    Private Sub gridResults_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridResults.MouseMove
        Static lastRow As DataGridViewRow = Nothing
        Static lastRowBackColor As Color = Color.White

        Dim h As DataGridView.HitTestInfo = gridResults.HitTest(e.X, e.Y)

        If lastRow IsNot Nothing Then
            If lastRow.Index = h.RowIndex Then Exit Sub
            lastRow.DefaultCellStyle.BackColor = lastRowBackColor
        End If

        If h.RowIndex > -1 Then

            lastRow = gridResults.Rows(h.RowIndex)
            lastRowBackColor = lastRow.DefaultCellStyle.BackColor

            lastRow.DefaultCellStyle.BackColor = Color.MintCream
        End If
    End Sub

    Private Sub tsShowStyleRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsShowStyleRows.Click
        ReLoad()
    End Sub

    Private Sub gridResults_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridResults.CellDoubleClick
        Dim r As IQITAResult = Nothing

        If IsCellResult(e, r) Then
            If r.IsComplex Then
                AddNewResultData(r)
            End If
        End If
    End Sub

    Private Sub tsChartData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsChartData.Click
        Me.DrawChart(False)
    End Sub

    Private Sub tsCompareProjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCompareProjects.Click
        UFCompareProjectsValues.Show(Me.Project)
    End Sub

    Private Sub gridResults_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles gridResults.SortCompare
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

    Private Sub tsExportToCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportGridToCSVFile.Click
        SetWorking(Me, True)
        NewTextFileWithPrompt(Me.Project.ProjectName & " - Results", DataGridViewToCSV(gridResults))
        SetWorking(Me, False)
    End Sub

    Private Sub tsExportAllFrequenciesToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportAllFrequenciesToFile.Click
        Dim allFreqs As New Dictionary(Of String, Integer)(p_AllTexts.Count * 100)
        Dim textFrequencyTable As Dictionary(Of String, Integer)

        SetWorking(Me, True)
        For Each text As IQITAText In p_AllTexts
            textFrequencyTable = text.GetWordFrequencyTable().ToDictionary()

            For Each word As String In textFrequencyTable.Keys
                If allFreqs.ContainsKey(word) Then
                    allFreqs(word) += textFrequencyTable(word)
                Else
                    allFreqs.Add(word, textFrequencyTable(word))
                End If
            Next
        Next

        Application.DoEvents()
        allFreqs = DictionarySort(allFreqs)

        Dim output As New System.Text.StringBuilder

        For Each t As String In allFreqs.Keys
            output.AppendLine(t & vbTab & allFreqs(t))
        Next

        NewTextFileWithPrompt(Me.Project.ProjectName & " - AllFrequencies", output.ToString())

        SetWorking(Me, False)
    End Sub

    Private Sub tsExportGridToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportGridToClipboard.Click
        SetWorking(Me, True)
        Clipboard.SetText(DataGridViewToCSV(gridResults))
        SetWorking(Me, False)
    End Sub

    Private Sub tsViewSelectedText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsViewSelectedText.Click
        Dim text As IQITAText = GetSelectedText()

        If IsAny(text) Then
            Dim viewer As New UFTextViewer(text)
            viewer.Show()
        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        gridResults.SelectAll()
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For Each r As DataGridViewRow In gridResults.Rows
            r.Selected = False
        Next
    End Sub

    Private Sub InvertSelectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertSelectionToolStripMenuItem.Click
        For Each r As DataGridViewRow In gridResults.Rows
            r.Selected = Not r.Selected
        Next
    End Sub

    Private Sub SelectAllContainingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllContainingToolStripMenuItem.Click
        Dim s As String = InputBox("What has to be contained in label?")

        For Each r As DataGridViewRow In gridResults.Rows
            r.Selected = StrContains(r.HeaderCell.Value, s)
        Next
    End Sub

    Private Sub SelectRandomRowsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectRandomRowsToolStripMenuItem.Click
        UnselectAllToolStripMenuItem_Click(sender, e)

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim n As Double = ToNumber(InputBox("How many rows to be randomly selected?", , gridResults.Rows.Count \ 3))

        Do
            j = RandomNumber(0, gridResults.Rows.Count - 1)

            If Not gridResults.Rows(j).Selected Then
                gridResults.Rows(j).Selected = True
                i += 1
            End If
        Loop While (i < n)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F5
                Me.DrawChart(False)
            Case Keys.F6
                Me.DrawChart(True)
            Case Keys.F3
                tsViewSelectedText_Click(Nothing, Nothing)
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region

#Region "PRIVATE Helper Classes"
    Private Class ColumnTextAndTagPair
        Inherits Pair

        Public Sub New(ByVal columnText As String, ByRef columnTag As Object)
            MyBase.New(columnText, columnTag)
        End Sub

        Public Sub New(ByVal columnText As String)
            MyBase.New(columnText, Nothing)
        End Sub

        Public ReadOnly Property ColumnText() As String
            Get
                Return MyBase.First
            End Get
        End Property

        Public ReadOnly Property ColumnTag() As Object
            Get
                Return MyBase.Second
            End Get
        End Property
    End Class

    Private Class IndexInfo
        Inherits Pair

        Public Sub New(ByVal indexName As String, ByRef index As IQITAIndex)
            MyBase.New(indexName, index)
        End Sub

        Public ReadOnly Property IndexName() As String
            Get
                Return MyBase.First
            End Get
        End Property

        Public ReadOnly Property IndexInstance() As IQITAIndex
            Get
                Return MyBase.Second
            End Get
        End Property
    End Class
#End Region

    
  
End Class
