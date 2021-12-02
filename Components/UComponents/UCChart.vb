Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.DataVisualization
Imports QITA_OLTK.QITADataTypes
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Public Class UCChart
    Private Const CONTROL_SERIE As String = "CTRL_SERIE"

    Private _Initialized As Boolean = False
    Private _ChartedData As New List(Of QITAChartableDataArray)
    Private _HasXAnyNull As Boolean = False
    Private _HasYAnyNull As Boolean = False
    Private _ChartName As String = Nothing

#Region ":: Properties"
    Private Property HasXAnyNull() As Boolean
        Get
            Return _HasXAnyNull
        End Get
        Set(ByVal value As Boolean)
            _HasXAnyNull = value

            chkXLogaritmic.Enabled = Not value
        End Set
    End Property

    Private Property HasYAnyNull() As Boolean
        Get
            Return _HasYAnyNull
        End Get
        Set(ByVal value As Boolean)
            _HasYAnyNull = value
            chkYLogaritmic.Enabled = Not value
        End Set
    End Property

    Private Property XAxisTitle() As String
        Get
            Return Chart1.ChartAreas(0).Axes(0).Title
        End Get
        Set(ByVal value As String)
            Chart1.ChartAreas(0).Axes(0).Title = StrRemoveEnding(value, ", ")
        End Set
    End Property

    Private Property YAxisTitle() As String
        Get
            Return Chart1.ChartAreas(0).Axes(1).Title
        End Get
        Set(ByVal value As String)
            Chart1.ChartAreas(0).Axes(1).Title = StrRemoveEnding(value, ", ")
        End Set
    End Property

    Public Property ChartName() As String
        Get
            Return _ChartName
        End Get
        Set(ByVal value As String)
            _ChartName = value
        End Set
    End Property
#End Region

#Region ":: PUBLIC"
    Public Sub Initialize()
        If Not _Initialized Then
            Me.FillChartTypes()
            Me.FillChartSortingTypes()
            Me.LoadChartSettings()

            _Initialized = True
        End If
    End Sub

    Public Sub AddSerie(ByRef dataArray As QITAChartableDataArray, _
                              Optional ByVal bInvertedAxis As Boolean = False)
        SetWorking(Me, True)
        Me.ChartData(dataArray, Me.GetSetupChartType(), bInvertedAxis)
        _ChartedData.Add(dataArray)

        LoadChartSettings()
        SetWorking(Me, False)
    End Sub

    Public Sub Done()
        tsDisplayLegend.Checked = My.Settings.Chart_DisplayLegend
        tsShowMargin.Checked = My.Settings.Chart_ShowMargin
        chkShowMinorGrid.Checked = My.Settings.Chart_DisplayMinorGrid

        Me.ActualisePostSettings()
    End Sub

    Public Function CheckIfSerieAlreadExists(ByVal sName As String) As Boolean
        For Each m As QITAChartableDataArray In _ChartedData
            If StrIsSame(m.DataName, sName) Then
                Return True
            End If
        Next

        Return False
    End Function
#End Region

#Region ":: MAIN CHART Controlling"
    Private Sub AddToXAxisTitle(ByVal s As String)
        If Not XAxisTitle.Contains(s) Then
            XAxisTitle += s & ", "
        End If
    End Sub

    Private Sub AddToYAxisTitle(ByVal s As String)
        If Not YAxisTitle.Contains(s) Then
            YAxisTitle += s & ", "
        End If

        'Title overleap hack :-/
        Static titleFont As Font = New Font(Chart1.ChartAreas(0).AxisX.TitleFont.FontFamily, 9, FontStyle.Regular)
        Chart1.ChartAreas(0).AxisX.TitleFont = titleFont
        Chart1.ChartAreas(0).AxisY.TitleFont = titleFont
    End Sub

    Private Sub ChartData(ByRef dataArray As QITAChartableDataArray, _
                          ByVal serieChartType As SeriesChartType, _
                          ByVal bInvertedAxis As Boolean)
        Dim newSerie As Series
        Dim isStringXAxis As Boolean = False

        If Not StrIsAny(XAxisTitle) Then XAxisTitle = ""
        If Not StrIsAny(YAxisTitle) Then YAxisTitle = ""
        Application.DoEvents()

        AddToXAxisTitle(If(Not bInvertedAxis, dataArray.GetXAxisTitle(), dataArray.GetYAxisTitle()))
        AddToYAxisTitle(If(Not bInvertedAxis, dataArray.GetYAxisTitle(), dataArray.GetXAxisTitle()))

        If IsAny(Chart1.Series.FindByName(dataArray.DataName)) Then
            MsgBox("Serie named: " & dataArray.DataName & " already exists in this Chart and will be skipped.", MsgBoxStyle.Information)
            Exit Sub
        End If

        newSerie = Chart1.Series.Add(dataArray.DataName)

        With newSerie
            .Name = Replace(dataArray.DataName, ",", "_")
            .LegendText = dataArray.DataName
            .MarkerStyle = Chart1.Series.Count Mod 10
            .ChartType = serieChartType
            .YValuesPerPoint = 2
            .CustomProperties = "BubbleMaxSize=5"
            '.MarkerBorderWidth = 1
            '.MarkerBorderColor = .MarkerColor
            '.MarkerColor = Color.Transparent

            For i As Integer = 0 To dataArray.Count - 1
                If IsNumber(dataArray.GetX(i)) Then
                    If Double.IsInfinity(dataArray.GetX(i)) OrElse Double.IsInfinity(dataArray.GetY(i)) Then
                        Continue For
                    End If
                Else
                    Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
                    isStringXAxis = True
                End If

                Dim xAxisValue As Object = dataArray.GetX(i)
                Dim yAxisValue As Object = dataArray.GetY(i)
                Dim zAxisValue As Object = dataArray.GetDescription(i)

                If bInvertedAxis Then
                    Swap(xAxisValue, yAxisValue)
                End If

                With .Points(.Points.AddXY(xAxisValue, _
                                            yAxisValue, _
                                            zAxisValue))
                    .ToolTip = newSerie.LegendText & ": " & dataArray.GetDescription(i) & " [" & xAxisValue & "; " & .YValues(0) & If(.YValues.Count > 1, "; " & .YValues(1), "") & "]"
                    .AxisLabel = xAxisValue
                    .LabelAngle = -45

                    If .XValue = 0 Then
                        Me.HasXAnyNull = True
                    End If

                    If .YValues(0) = 0 Then
                        Me.HasYAnyNull = True
                    End If
                End With
            Next
        End With

        With Chart1.ChartAreas(0)
            .Axes(0).IntervalAutoMode = IntervalAutoMode.VariableCount
            .Axes(1).IntervalAutoMode = IntervalAutoMode.VariableCount
        End With

        If isStringXAxis Then
            Chart1.AlignDataPointsByAxisLabel()
        End If

        Application.DoEvents()
    End Sub

    Private Sub ReChart()
        SetWorking(Me, True)
        For Each s As QITAChartableDataArray In _ChartedData
            Me.ChartData(s, Me.GetSetupChartType(), chkInvertAxes.Checked)
        Next

        Me.Done()
        SetChartType(GetSetupChartType())
        SetWorking(Me, False)
    End Sub

    Public Sub ClearAll()
        For Each s As Series In Chart1.Series
            s.Points.Clear()
        Next

        Chart1.Series.Clear()
        Chart1.ResetAutoValues()

        chkXLogaritmic.Checked = False
        chkYLogaritmic.Checked = False

        XAxisTitle = ""
        YAxisTitle = ""


        HasXAnyNull = False
        HasYAnyNull = False
    End Sub

    Private Sub ReSortData(ByVal coordinate As QITAChartableDataArray.Coordinate, ByVal order As SortOrder)
        ClearAll()

        For Each m As QITAChartableDataArray In _ChartedData
            m.SortBy(coordinate, order)
        Next

        ReChart()
    End Sub

    Public Sub InvertAxis()
        ClearAll()
        ReChart()
    End Sub

    Public Sub SetSeriesMarkerSize(ByVal n As Integer)
        My.Settings.LastChartMarkersSize = n

        For Each serie As Charting.Series In Chart1.Series
            serie.MarkerSize = n
        Next
    End Sub

    Public Sub SetMaxMarkerSize(ByVal n As Integer)
        My.Settings.Chart_MaxMarkSize = n
    End Sub

#End Region

#Region ":: CHART TYPE HELPERS"
    Private Sub RescaleMarkerSizes(ByVal bSerieStrict As Boolean)
        Dim max As Double = Double.MinValue
        Dim min As Double = Double.MaxValue
        Dim zVal As Double = 0

        For Each s As Series In Chart1.Series
            If bSerieStrict Then
                max = Double.MinValue
                min = Double.MaxValue
            End If

            For Each p As DataPoint In s.Points
                If p.YValues.Count = 2 Then
                    zVal = p.YValues(1)
                    max = Math.Max(max, zVal)
                    min = Math.Min(min, zVal)
                End If
            Next

            If bSerieStrict Then
                If (max <> min) AndAlso (max <> Double.MaxValue) AndAlso (min <> Double.MinValue) Then
                    ScaleSerieMarkerSize(s, min, max)
                End If
            End If
        Next

        If Not bSerieStrict Then
            If (max <> min) AndAlso (max <> Double.MaxValue) AndAlso (min <> Double.MinValue) Then
                For Each s As Series In Chart1.Series
                    ScaleSerieMarkerSize(s, min, max)
                Next
            End If
        End If
    End Sub

    Private Sub ScaleSerieMarkerSize(ByRef s As Series, ByVal minVal As Double, ByVal maxVal As Double)
        Dim MAX_SIZE_OF_MARKER = My.Settings.Chart_MaxMarkSize
        Dim MIN_SIZE_OF_MARKER = 1

        Dim zVal As Double = 0
        Dim perc As Double = 0
        Dim mSize As Integer = 0

        For Each p As DataPoint In s.Points
            zVal = p.YValues(1)
            perc = ((zVal - minVal) / (maxVal - minVal))
            mSize = MIN_SIZE_OF_MARKER + ((MAX_SIZE_OF_MARKER - MIN_SIZE_OF_MARKER) * perc)

            p.MarkerSize = mSize
        Next
    End Sub

    Private Sub FillChartTypes()
        Dim chartTypes As Array = [Enum].GetValues(GetType(SeriesChartType))

        For Each n As Object In chartTypes
            Dim m As New GIComboBoxItem([Enum].GetName(GetType(SeriesChartType), n).ToString(), n)

            Dim item As ToolStripMenuItem = ChartTypeToolStripMenuItem.DropDownItems.Add(m.Text)
            item.Tag = m.StoredObject
            item.CheckOnClick = True

            AddHandler item.Click, AddressOf ChartTypesToolStripMenuItem_Click

            If m.Text = My.Settings.Chart_ChartType Then
                item.Checked = True
            End If
        Next
    End Sub

    Private Sub tsFastLineChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFastLineChart.Click
        SetChartType(SeriesChartType.Line)
    End Sub

    Private Sub tsFastPointChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFastPointChart.Click
        SetChartType(SeriesChartType.Point)
    End Sub

    Private Sub tsDisplayLegend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDisplayLegend.Click
        My.Settings.Chart_DisplayLegend = tsDisplayLegend.Checked
        Me.ActualisePostSettings()
    End Sub

    Private Sub ActualisePostSettings()
        For Each l As Legend In Chart1.Legends
            l.Enabled = My.Settings.Chart_DisplayLegend
        Next

        Chart1.ChartAreas(0).AxisX.IsMarginVisible = My.Settings.Chart_ShowMargin

        ShowMinorGrid(My.Settings.Chart_DisplayMinorGrid)
    End Sub

    Private Sub ChartTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim clickedItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

        SetChartType(DirectCast(clickedItem.Tag, SeriesChartType))
    End Sub

    Private Sub SetSerieChartType(ByRef s As Charting.Series, ByRef ChartType As SeriesChartType)
        s.ChartType = ChartType
    End Sub

    Private Sub SetChartType(ByVal chartType As SeriesChartType)
        My.Settings.Chart_ChartType = chartType.ToString()

        For Each m As ToolStripMenuItem In ChartTypeToolStripMenuItem.DropDownItems
            m.Checked = CBool(m.Tag = chartType)
        Next

        Try
            Dim testVal As Integer = -1
            Dim bAllHasSameSize As Boolean = True

            For Each s As Series In Chart1.Series
                If testVal = -1 Then
                    testVal = s.Points.Count
                Else
                    If s.Points.Count <> testVal Then
                        bAllHasSameSize = False
                        Exit For
                    End If
                End If
            Next

            If (Not bAllHasSameSize) AndAlso (chartType > 7) Then
                Exit Sub
            End If

            If (Chart1.Series.Count > 1) AndAlso (chartType > 28) Then
                Exit Sub
            End If

            For Each s As Series In Chart1.Series
                If Not IsSerieControl(s) Then
                    SetSerieChartType(s, chartType)
                End If
            Next

            Chart1.Update()

        Catch e As Exception

        End Try
    End Sub

    Private Function GetSetupChartType() As SeriesChartType
        For Each m As ToolStripMenuItem In ChartTypeToolStripMenuItem.DropDownItems
            If m.Checked Then
                Return DirectCast(m.Tag, SeriesChartType)
            End If
        Next

        Return SeriesChartType.Point
    End Function
#End Region

#Region ":: GUI MISC CONTROLS"
    Private Sub LoadChartSettings()
        MarkerSizeToolStripMenuItem.Text = "Marker size: " & CStr(My.Settings.LastChartMarkersSize)
        MarkerMaxsize25ToolStripMenuItem.Text = "Marker max-size: " & CStr(My.Settings.Chart_MaxMarkSize)
        MarkerSizeToolStripMenuItem.Tag = My.Settings.LastChartMarkersSize

        SetSeriesMarkerSize(My.Settings.LastChartMarkersSize)
    End Sub

    Private Sub FillChartSortingTypes()
        cbSortBy.Items.Add(New GIComboBoxItem("by X Ascending", _
                                                  New Pair(QITAChartableDataArray.Coordinate.X, _
                                                           SortOrder.Ascending)))

        cbSortBy.Items.Add(New GIComboBoxItem("by X Descending", _
                                                  New Pair(QITAChartableDataArray.Coordinate.X, _
                                                           SortOrder.Descending)))

        cbSortBy.Items.Add(New GIComboBoxItem("by Y Ascending", _
                                                  New Pair(QITAChartableDataArray.Coordinate.Y, _
                                                           SortOrder.Ascending)))

        cbSortBy.Items.Add(New GIComboBoxItem("by Y Descending", _
                                                  New Pair(QITAChartableDataArray.Coordinate.Y, _
                                                           SortOrder.Descending)))
    End Sub

    Private Sub ShowMinorGrid(ByVal b As Boolean)
        Chart1.ChartAreas(0).Axes(0).MinorGrid.Enabled = b
        Chart1.ChartAreas(0).Axes(1).MinorGrid.Enabled = b
    End Sub

    Private Sub chkInvertAxes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInvertAxes.Click
        InvertAxis()
    End Sub

    Private Sub chkShowValueAsLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each s As Series In Chart1.Series
            's.IsValueShownAsLabel = chkShowValueAsLabel.Checked
        Next
    End Sub

    Private Sub SetLogarithmic(ByVal bX As Boolean, ByVal bY As Boolean)
        Chart1.ChartAreas(0).Axes(0).IsLogarithmic = bX
        Chart1.ChartAreas(0).Axes(1).IsLogarithmic = bY
    End Sub

    Private Sub FitPlot()
        Dim dBiggestY As Double = 0
        Dim dLittlestY As Double = Double.MaxValue

        For Each s As Series In Chart1.Series
            For Each p As DataPoint In s.Points
                If p.YValues(0) > dBiggestY Then
                    dBiggestY = p.YValues(0)
                End If

                If p.YValues(0) < dLittlestY Then
                    dLittlestY = p.YValues(0)
                End If
            Next
        Next

        Chart1.ChartAreas(0).AxisY.Minimum = dLittlestY - dLittlestY / 10
        Chart1.ChartAreas(0).AxisY.Maximum = dBiggestY + dBiggestY / 10
    End Sub

    Private Sub ScaleMarkerSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScaleMarkerSizeToolStripMenuItem.Click
        RescaleMarkerSizes(False)
    End Sub


    Private Sub ScaleMarkersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScaleMarkersToolStripMenuItem.Click
        RescaleMarkerSizes(True)
    End Sub

    Private Sub LogarithmicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLog.Click
        Chart1.ChartAreas(0).Axes(0).IsLogarithmic = chkLog.Checked
        Chart1.ChartAreas(0).Axes(1).IsLogarithmic = chkLog.Checked
        chkXLogaritmic.Checked = chkLog.Checked
        chkYLogaritmic.Checked = chkLog.Checked

        SetLogarithmic(chkLog.Checked, chkLog.Checked)
        FitPlot()
    End Sub

    Private Sub chkXLogaritmic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkXLogaritmic.Click
        SetLogarithmic(chkXLogaritmic.Checked, chkYLogaritmic.Checked)
    End Sub

    Private Sub chkYLogaritmic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYLogaritmic.Click
        SetLogarithmic(chkXLogaritmic.Checked, chkYLogaritmic.Checked)
    End Sub

    Private Sub ReverseXAxeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReverseX.Click
        Chart1.ChartAreas(0).Axes(0).IsReversed = chkReverseX.Checked
    End Sub

    Private Sub chkReverseY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReverseY.Click
        Chart1.ChartAreas(0).Axes(1).IsReversed = chkReverseY.Checked
    End Sub

    Private Sub FitChartToWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FitChartToWindowToolStripMenuItem.Click
        FitPlot()
    End Sub

    Private Sub AppearanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppearanceToolStripMenuItem.Click
        ShowEditor("Chart Appearance", New ChartEditorAdaptor(Chart1))
    End Sub

    Private Sub MarkerSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkerSizeToolStripMenuItem.Click
        Dim s As String = EditControlTagAndTextByUserInput(MarkerSizeToolStripMenuItem, _
                                                           "Marker size", _
                                                           "Set new marker size (0 - 50)", _
                                                           True, _
                                                           Function(input As String) _
                                                            (IIf(IsNumber(input), _
                                                                Math.Min(Math.Max(ToNumber(input), 0), 50), 1)))

        SetSeriesMarkerSize(Val(s))
    End Sub

    Private Sub MarkerMaxsize25ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkerMaxsize25ToolStripMenuItem.Click
        Dim s As String = EditControlTagAndTextByUserInput(MarkerMaxsize25ToolStripMenuItem, _
                                                           "Maximum Marker size", _
                                                           "Set new maximum marker size (1 - 100)", _
                                                           True, _
                                                           Function(input As String) _
                                                            (IIf(IsNumber(input), _
                                                                Math.Min(Math.Max(ToNumber(input), 1), 100), 25)))

        SetMaxMarkerSize(Val(s))
    End Sub

    Private Sub chkShowMinorGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowMinorGrid.CheckedChanged
        My.Settings.Chart_DisplayMinorGrid = chkShowMinorGrid.Checked
        Me.ActualisePostSettings()
    End Sub

    Private Sub tsShowMargin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsShowMargin.CheckedChanged
        My.Settings.Chart_ShowMargin = tsShowMargin.Checked
        Me.ActualisePostSettings()
    End Sub

    Private Sub cbSortBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSortBy.SelectedIndexChanged
        If IsAny(cbSortBy.SelectedItem) Then
            Dim item As GIComboBoxItem = cbSortBy.SelectedItem
            Dim setting As Pair = item.StoredObject

            ReSortData(setting.First, setting.Second)
        End If
    End Sub

    Private Sub Chart1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseDoubleClick
        Dim oClickedObject As Object = Chart1.HitTest(e.X, e.Y).Object

        If IsAny(oClickedObject) Then
            Select Case True
                Case TypeOf oClickedObject Is Charting.DataPoint
                    ShowEditor(oClickedObject.GetType().Name, oClickedObject)

                Case TypeOf oClickedObject Is Charting.LegendItem
                    Dim s As Series = Chart1.Series(DirectCast(oClickedObject, Charting.LegendItem).SeriesName)
                    ShowEditor(s.Name, s)

                Case TypeOf oClickedObject Is Charting.StripLine
                    ShowEditor(oClickedObject.GetType().Name, oClickedObject)

                Case TypeOf oClickedObject Is Charting.Axis
                    ShowEditor(DirectCast(oClickedObject, Charting.Axis).Name, oClickedObject)
            End Select
        End If
    End Sub

    Private Sub Chart1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseMove
        Dim oClickedObject As Object = Chart1.HitTest(e.X, e.Y).Object

        If IsAny(oClickedObject) Then
            Select Case True
                Case (TypeOf oClickedObject Is Charting.DataPoint), _
                     (TypeOf oClickedObject Is Charting.LegendItem), _
                     (TypeOf oClickedObject Is Charting.Axis), _
                     (TypeOf oClickedObject Is Charting.StripLine)

                    Chart1.Cursor = Cursors.Hand
                Case Else
                    Chart1.Cursor = Cursors.Arrow
            End Select
        End If
    End Sub

    Private Sub EditXAxisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditXAxisToolStripMenuItem.Click
        ShowEditor("X Axis", Chart1.ChartAreas(0).Axes(0))
    End Sub

    Private Sub EditYAxisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditYAxisToolStripMenuItem.Click
        ShowEditor("Y Axis", Chart1.ChartAreas(0).Axes(1))
    End Sub

    Private Sub EditSeriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowEditor("Series", DirectCast(sender, ToolStripMenuItem).Tag)
    End Sub

    Private Sub EditPointsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPointsToolStripMenuItem.Click
        UFChartDataEditor.Show(Chart1, UFChartDataEditor.eChartEditorWhatToEdit.POINTS)
    End Sub

    Private Sub EditSeriesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSeriesToolStripMenuItem.Click
        UFChartDataEditor.Show(Chart1, UFChartDataEditor.eChartEditorWhatToEdit.SERIES)
    End Sub

    Private Sub SaveAsPictureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsPictureToolStripMenuItem.Click
        Dim d As New SaveFileDialog()

        d.FileName = Me.ChartName.Trim().Replace(":", "_").Replace(" ", "_").Replace(",", "_").Replace("/", "-").Replace("\", "-").Replace("__", "_")
        d.Filter = "PNG Image (*.png)|*.png|GIF Image (*.gif)|*.gif|EMF Image (*.emf)|*.emf"

        If d.ShowDialog() = DialogResult.OK Then
            Dim imageFormat As ChartImageFormat

            Select Case IO.Path.GetExtension(d.FileName).ToLower()
                Case ".gif"
                    imageFormat = ChartImageFormat.Gif
                Case ".png"
                    imageFormat = ChartImageFormat.Png
                Case ".emf"
                    imageFormat = ChartImageFormat.Emf
                Case Else
                    imageFormat = ChartImageFormat.Png
            End Select

            SetWorking(Me, True)
            Chart1.SaveImage(d.FileName, imageFormat)

            Do
                Threading.Thread.Sleep(50)
            Loop Until (IO.File.Exists(d.FileName) AndAlso _
                            CBool(My.Computer.FileSystem.GetFileInfo(d.FileName).Length))

            Try
                Shell("explorer " & d.FileName)
            Catch n As Exception

            End Try

            SetWorking(Me, False)
        End If
    End Sub

    Private Sub SaveImageToClipBoardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveImageToClipBoardToolStripMenuItem.Click
        SetWorking(Me, True)

        Using ms As New MemoryStream()
            Chart1.SaveImage(ms, ChartImageFormat.Bmp)
            Dim bm As Bitmap = New Bitmap(ms)
            Clipboard.SetImage(bm)
        End Using

        SetWorking(Me, False)
        Beep()
    End Sub

    Private Function IsSerieOkToExportToCSV(ByVal s As Series) As Boolean
        Return s.Enabled AndAlso (s.Points.Count > 0)
    End Function
    Private Sub ExportToCSVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToCSVToolStripMenuItem.Click
        Dim s As New StringBuilder

        Dim i As Integer = 0


        For Each serie In Chart1.Series
            If IsSerieOkToExportToCSV(serie) Then
                s.Append(serie.Name & vbTab & vbTab & vbTab)
            End If
        Next

        s.AppendLine()

        For Each serie In Chart1.Series
            If IsSerieOkToExportToCSV(serie) Then
                s.Append("X" & vbTab & "Y" & vbTab & "Z" & vbTab)
            End If
        Next

        s.AppendLine()

        Dim p As DataPoint
        Dim hasDataYet As Boolean

        i = 0

        Do
            hasDataYet = False

            For Each serie In Chart1.Series
                If IsSerieOkToExportToCSV(serie) Then
                    If serie.Points.Count > i Then
                        hasDataYet = True

                        p = serie.Points(i)

                        s.Append(p.XValue.ToString() & vbTab & p.YValues(0).ToString() & vbTab & CDbl(p.Tag).ToString() & vbTab)
                    Else
                        s.Append("" & vbTab & "" & vbTab & "" & vbTab)
                    End If
                End If
            Next

            s.AppendLine()
            i += 1
        Loop While hasDataYet

        SaveAndOpen(s.ToString(), ".csv")
    End Sub
    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Chart1.Printing.PrintPreview()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Chart1.Printing.Print(True)
    End Sub

    Private Sub ShowEditor(ByVal sTitle As String, ByRef objectToEdit As Object)
        Dim objectEditor As New UFObjectEditor("Edit - " & Me.Parent.Text & ": " & sTitle, objectToEdit)
        objectEditor.Show()
    End Sub

    Private Sub EditControlSerie(ByVal sSerieName As String, _
                          ByVal serieChartType As SeriesChartType, _
                          ByVal newColor As Color, _
                                Optional ByVal borderWidth As Integer = 1)

        With Chart1.Series(sSerieName)
            .Color = newColor
            .ChartType = serieChartType
            .BorderWidth = borderWidth
        End With

        MarkSerieAsControl(Chart1.Series(sSerieName))
    End Sub

    Private Sub MarkSerieAsControl(ByRef s As Series)
        s.Tag = CONTROL_SERIE
    End Sub

    Private Function IsSerieControl(ByRef s As Series) As Boolean
        Return CBool(s.Tag = CONTROL_SERIE)
    End Function
#End Region

#Region ":: GUI STATISTICS"
    Private Sub RemoveSerieIfExists(ByVal sSerieName As String)
        If Chart1.Series.IndexOf(sSerieName) > -1 Then
            Chart1.Series.Remove(Chart1.Series(sSerieName))
        End If
    End Sub

    Private Function MakeAllSeriesListString() As String
        Dim s As String = ""

        For Each serie As Series In Chart1.Series
            s += serie.Name & ","
        Next

        Return StrRemoveEnding(s, ",")
    End Function

    Private Sub ShowAverageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAverageToolStripMenuItem.Click
        RemoveSerieIfExists("[Average]")

        If ShowAverageToolStripMenuItem.Checked Then
            DrawStatisticalSerie("[Average]", Function(yValues As List(Of Double)) (yValues.Average))
        End If

    End Sub

    Private Sub ShowMaximumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowMaximumToolStripMenuItem.Click
        RemoveSerieIfExists("[Maximum]")

        If ShowMaximumToolStripMenuItem.Checked Then
            DrawStatisticalSerie("[Maximum]", Function(yValues As List(Of Double)) (yValues.Max))
        End If
    End Sub

    Private Sub ShowMinimumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowMinimumToolStripMenuItem.Click
        RemoveSerieIfExists("[Minimum]")

        If ShowMinimumToolStripMenuItem.Checked Then
            DrawStatisticalSerie("[Minimum]", Function(yValues As List(Of Double)) (yValues.Min))
        End If
    End Sub

    Private Function RegressionsCheckRadio(ByRef sender As System.Object) As Boolean
        Dim ts As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim bPreviousState As Boolean = ts.Checked

        ShowLinearRegressionToolStripMenuItem.Checked = False
        ShowPolynomialRegressionToolStripMenuItem.Checked = False
        ShowPowerRegressionToolStripMenuItem.Checked = False
        ShowExponentialRegressionToolStripMenuItem.Checked = False
        ShowLogarithmicRegressionToolStripMenuItem.Checked = False
        ShowPowerRegressionToolStripMenuItem.Checked = False

        ts.Checked = Not bPreviousState
        Return ts.Checked
    End Function

    Private Sub ShowLinearRegressionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLinearRegressionToolStripMenuItem.Click
        DrawRegression("Linear Regression", "Linear", RegressionsCheckRadio(sender))
    End Sub

    Private Sub ShowPolynomialRegressionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPolynomialRegressionToolStripMenuItem.Click
        DrawRegression("Polynomial Regression", "Polynomial", RegressionsCheckRadio(sender))
    End Sub

    Private Sub ShowExponentialRegressionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowExponentialRegressionToolStripMenuItem.Click
        DrawRegression("Exponential Regression", "Exponential", RegressionsCheckRadio(sender))
    End Sub

    Private Sub ShowLogarithmicRegressionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLogarithmicRegressionToolStripMenuItem.Click
        DrawRegression("Logarithmic Regression", "IsLogarithmic", RegressionsCheckRadio(sender))
    End Sub

    Private Sub ShowPowerRegressionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPowerRegressionToolStripMenuItem.Click
        DrawRegression("Power Regression", "Power", RegressionsCheckRadio(sender))
    End Sub

    Private Sub DrawRegression(ByVal sName As String, ByVal sType As String, ByVal bShow As Boolean)
        Dim sSerieName As String = Chart1.Series(0).Name
        Dim sRangeName As String = sName & " Range"
        Dim seriesToRemove As New List(Of Series)

        For Each s As Series In Chart1.Series
            If IsSerieControl(s) Then seriesToRemove.Add(s)
            If s.IsXValueIndexed Then
                MsgBox("Serie: " + s.Label.ToString() + " can not be calculated. Missing X values.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Next

        For Each s As Series In seriesToRemove
            Chart1.Series.Remove(s)
        Next

        If bShow Then
            sName = sName.Replace(" ", "-")
            sRangeName = sRangeName.Replace(" ", "-")

            Chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, _
                                                    sType & ",10,True,False", _
                                                    sSerieName & ":Y", _
                                                    sName & ":Y," & sRangeName & ":Y," & sRangeName & ":Y2")

            EditControlSerie(sName, SeriesChartType.Line, Color.Red, 3)
            EditControlSerie(sRangeName, SeriesChartType.Range, Color.FromArgb(20, 220, 90, 220), 1)
        End If
    End Sub

    Private Sub DrawStatisticalSerie(ByVal sName As String, ByVal f As Func(Of List(Of Double), Double))
        Dim d As New Dictionary(Of Double, List(Of Double))

        For Each s As Series In Chart1.Series
            For Each p As DataPoint In s.Points
                If Not d.ContainsKey(p.XValue) Then
                    d.Add(p.XValue, New List(Of Double))
                End If

                d(p.XValue).Add(p.YValues(0))
            Next
        Next

        Dim averagedPoints As New QITAChartableDataArray(d.Keys.Count, "x", "y", Nothing)
        averagedPoints.DataName = sName

        For Each xValue As Double In d.Keys
            averagedPoints.SetNextXYD(xValue, f(d(xValue)), Nothing)
        Next

        averagedPoints.Done()

        Me.ChartData(averagedPoints, SeriesChartType.Line, chkInvertAxes.Checked)
    End Sub

    Private Sub ShowMeanAverageStandardDeviationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowMeanAverageStandardDeviationToolStripMenuItem.Click
        Static hasMinorGrid As Boolean = My.Settings.Chart_DisplayMinorGrid

        Chart1.ChartAreas(0).AxisY.StripLines(0).IntervalOffset = -1
        Chart1.ChartAreas(0).AxisY.StripLines(0).StripWidth = 0
        Chart1.ChartAreas(0).AxisY.StripLines(1).IntervalOffset = -1

        If ShowMeanAverageStandardDeviationToolStripMenuItem.Checked Then
            Dim seriesSelector As New UFChartSelectSerie(Chart1, 1)

            If seriesSelector.HasAnyOption() Then
                If seriesSelector.ShowDialog() <> DialogResult.OK Then
                    Exit Sub
                End If
            End If

            Dim mean As Double = Chart1.DataManipulator.Statistics.Mean(seriesSelector.SelectedSerie.Name)
            Dim variance As Double = Chart1.DataManipulator.Statistics.Variance(seriesSelector.SelectedSerie.Name, Me.IsDataSample)
            Dim standardDeviation As Double = Math.Sqrt(variance)

            Chart1.ChartAreas(0).AxisY.StripLines(0).IntervalOffset = mean - Math.Sqrt(variance)
            Chart1.ChartAreas(0).AxisY.StripLines(0).StripWidth = 2.0 * Math.Sqrt(variance)
            Chart1.ChartAreas(0).AxisY.StripLines(1).IntervalOffset = mean

            Dim populationSizeInStDev As Integer = 0
            Dim populationSize As Integer = seriesSelector.SelectedSerie.Points.Count

            For Each t As DataPoint In seriesSelector.SelectedSerie.Points
                If MathExt.IsInIntervalInclusive(t.YValues(0), mean - standardDeviation, mean + standardDeviation) Then
                    populationSizeInStDev += 1
                End If
            Next

            Chart1.ChartAreas(0).AxisY.StripLines(0).Text = "Standard deviation (" & CStr(Math.Round((populationSizeInStDev / populationSize) * 100, 2)) & " % of population)"
        End If
    End Sub

    Private Sub ANOVAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ANOVAToolStripMenuItem.Click
        MsgBox("Not implemented yet.")
    End Sub

    Private Sub CorellationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorellationToolStripMenuItem.Click
        Dim seriesSelector As New UFChartSelectSerie(Chart1, 2)

        If seriesSelector.ShowDialog() = DialogResult.OK Then
            Try


                ShowStatisticalResult("Correlation", _
                                      Chart1.DataManipulator.Statistics.Correlation(seriesSelector.SelectedSeries(0).Name, _
                                                                                    seriesSelector.SelectedSeries(1).Name))
            Catch ex As Exception
                MsgBox(ex.Message.ToString(), MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub CovarianceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CovarianceToolStripMenuItem.Click
        Dim seriesSelector As New UFChartSelectSerie(Chart1, 2)

        If seriesSelector.ShowDialog() = DialogResult.OK Then
            Try
                ShowStatisticalResult("Covariance", _
                                      Chart1.DataManipulator.Statistics.Covariance(seriesSelector.SelectedSeries(0).Name, _
                                                                                   seriesSelector.SelectedSeries(1).Name))
            Catch ex As Exception
                MsgBox(ex.Message.ToString(), MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub VarianceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VarianceToolStripMenuItem.Click
        Dim seriesSelector As New UFChartSelectSerie(Chart1, 1)

        If seriesSelector.ShowDialog() = DialogResult.OK Then
            Try
                ShowStatisticalResult("Variance", _
                                      Chart1.DataManipulator.Statistics.Variance(seriesSelector.SelectedSerie.Name, Me.IsDataSample))

            Catch ex As Exception
                MsgBox(ex.Message.ToString(), MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub ShowStatisticalResult(ByVal sName As String, ByRef d As Double)
        MsgBox(sName & ": " & d.ToString(), MsgBoxStyle.OkOnly Or MsgBoxStyle.Information)
    End Sub

    ''' <summary>
    ''' Retreives user settings whether data is sample population or entire population
    ''' </summary>
    ''' <returns>TRUE on Sample population. FALSE on entire population.</returns>
    Private Function IsDataSample() As Boolean
        Return DataIsSampleToolStripMenuItem.Checked
    End Function
#End Region
    
End Class

Public Class ChartEditorAdaptor
    Inherits ExpandableObjectConverter
    Private _Chart As Chart = Nothing

    Public Sub New(ByRef editableChart As Chart)
        _Chart = editableChart
    End Sub

    Public Property Palette() As ChartColorPalette
        Get
            Return _Chart.Palette
        End Get
        Set(ByVal value As ChartColorPalette)
            _Chart.Palette = value
        End Set
    End Property

    Public Property BackgroundColor() As Color
        Get
            Return _Chart.ChartAreas(0).BackColor
        End Get
        Set(ByVal value As Color)
            _Chart.ChartAreas(0).BackColor = value
        End Set
    End Property

    Public Property MajorGridColor() As Color
        Get
            Return _Chart.ChartAreas(0).Axes(0).MajorGrid.LineColor
        End Get
        Set(ByVal value As Color)
            _Chart.ChartAreas(0).Axes(0).MajorGrid.LineColor = value
            _Chart.ChartAreas(0).Axes(1).MajorGrid.LineColor = value
        End Set
    End Property

    Public Property MinorGridColor() As Color
        Get
            Return _Chart.ChartAreas(0).Axes(0).MinorGrid.LineColor
        End Get
        Set(ByVal value As Color)
            _Chart.ChartAreas(0).Axes(0).MinorGrid.LineColor = value
            _Chart.ChartAreas(0).Axes(1).MinorGrid.LineColor = value
        End Set
    End Property

    Public Property AxesColor() As Color
        Get
            Return _Chart.ChartAreas(0).Axes(0).LineColor
        End Get
        Set(ByVal value As Color)
            _Chart.ChartAreas(0).Axes(0).LineColor = value
            _Chart.ChartAreas(0).Axes(1).LineColor = value
        End Set
    End Property

    Public Property AxesLineWidth() As Integer
        Get
            Return _Chart.ChartAreas(0).Axes(0).LineWidth
        End Get
        Set(ByVal value As Integer)
            _Chart.ChartAreas(0).Axes(0).LineWidth = value
            _Chart.ChartAreas(0).Axes(1).LineWidth = value
        End Set
    End Property
End Class
