Imports QITA_OLTK.QITADataTypes
Imports QITA_OLTK.QITAInterfaces

Public Class UCComparsionResults
    Private _project As IQITAProject = Nothing

#Region ":: PROPERTIES"
    Private ReadOnly Property ColorizeTreshold() As Double
        Get
            Return ToNumber(tsColorizeTreshold.Tag)
        End Get
    End Property

    Private ReadOnly Property Project() As IQITAProject
        Get
            Return _project
        End Get
    End Property
#End Region

#Region ":: PUBLIC Results Interface"
    Public Sub ShowComparsionResults(ByRef project As IQITAProject, ByRef comparsionResults As QITATable)
        _project = project

        PopulateData(comparsionResults)

        'again, datagrid hack
        gridData.Dock = DockStyle.None
        gridData.Dock = DockStyle.Fill
        gridData.Focus()
    End Sub
#End Region

#Region ":: PRIVATE Results Functions"
    Private Sub PopulateData(ByRef results As QITATable)
        gridData.Columns.Clear()
        gridData.ColumnCount = results.ColumnCount - 1
        gridData.AllowUserToResizeColumns = True
        gridData.AllowUserToResizeRows = False
        gridData.AllowUserToOrderColumns = True

        For i As Integer = 0 To results.ColumnCount - 2
            gridData.Columns(i).HeaderText = results.ColumnNames(i + 1)
            gridData.Columns(i).Resizable = DataGridViewTriState.True
        Next

        Dim row As Integer
        For i As Integer = 1 To results.RowsCount
            row = gridData.Rows.Add()
            gridData.Rows(row).HeaderCell.Value = results.CellValue(i, 0)

            For iColumn As Integer = 1 To results.ColumnCount - 1
                If (iColumn - 1) <> row Then
                    gridData.Item(iColumn - 1, row) = New DataGridViewTextBoxCell()
                    gridData.Item(iColumn - 1, row).Value = results.CellValue(i, iColumn)
                    gridData.Item(iColumn - 1, row).Tag = "result"
                End If
            Next
        Next

        gridData.Rows(gridData.Rows.Add()).Tag = "stats"
        AddColumnStatsRow(results, "Average", Function(columnData As Double()) (columnData.Average))
        AddColumnStatsRow(results, "Standard deviation", Function(columnData As Double()) (StandardDeviation(columnData)))
    End Sub

    Private Sub ColorizeCells()
        Const RED_START As Integer = 190

        Dim m As Double
        Dim red As Integer
        Dim green As Integer
        Dim exceedTest As Integer

        Dim newColor As Color = Color.White
        Dim bColorize As Boolean = tsColorize.Checked
        Dim multiplier As Double = (255 - RED_START) / ColorizeTreshold

        Try

            For i As Integer = 0 To gridData.ColumnCount - 1
                For j As Integer = 0 To gridData.Rows.Count - 1
                    If (i = j) OrElse (gridData.Item(i, j).Tag <> "result") Then
                        newColor = Color.White
                    Else
                        If bColorize Then
                            m = ToNumber(gridData.Item(i, j).Value)

                            If Double.IsInfinity(m) Then
                                red = 255
                                green = 140
                            Else
                                exceedTest = RED_START + m * multiplier

                                If exceedTest > 255 Then
                                    red = 255
                                    green = Math.Max(240 - Math.Log(m * multiplier), 140)
                                Else
                                    red = exceedTest
                                    green = 255
                                End If
                            End If
                        End If

                        newColor = Color.FromArgb(red, green, 196)
                    End If

                    gridData.Item(i, j).Style.BackColor = newColor
                Next
            Next

        Catch e As Exception

        End Try
    End Sub

    Private Sub AddColumnStatsRow(ByRef resultTable As QITATable, _
                                  ByVal sName As String, _
                                  ByVal f As Func(Of Double(), Object))

        Dim columnData() As Double
        Dim row As Integer = gridData.Rows.Add()

        For iColumn As Integer = 1 To resultTable.ColumnCount - 1
            columnData = ObjArrayToNumberArray(resultTable.Column(iColumn))

            With gridData.Rows(row)
                .HeaderCell.Value = sName
                .Tag = "stats"
            End With

            gridData.Item(iColumn - 1, row).Value = f(columnData)
            gridData.Item(iColumn - 1, row).Tag = "stats"
        Next
    End Sub
#End Region

#Region ":: FORM Control"
    Private Sub tsColorizeCells_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsColorize.Click
        ColorizeCells()
    End Sub

    Private Sub tsTreshold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsColorizeTreshold.Click
        Dim sInput As String = InputBox("Please enter new treshold value:", , tsColorizeTreshold.Tag)

        If IsNumber(sInput) Then
            tsColorizeTreshold.Text = "Set treshold: " & sInput
            tsColorizeTreshold.Tag = ToNumber(sInput)

            ColorizeCells()
        End If
    End Sub

    Private Sub tsExportGridToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportGridToClipboard.Click
        SetWorking(Me, True)
        Clipboard.SetText(DataGridViewToCSV(gridData))
        SetWorking(Me, False)
    End Sub

    Private Sub tsExportGridToCSVFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportGridToCSVFile.Click
        SetWorking(Me, True)
        NewTextFileWithPrompt(Me.Project.ProjectName & " - Results", DataGridViewToCSV(gridData))
        SetWorking(Me, False)
    End Sub
#End Region
End Class
