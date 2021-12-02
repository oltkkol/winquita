<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCChart
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim StripLine3 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine
        Dim StripLine4 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCChart))
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdEditChart = New System.Windows.Forms.ToolStripDropDownButton
        Me.ChartTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator
        Me.EditPointsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditSeriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
        Me.EditXAxisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditYAxisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.AppearanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MarkerSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MarkerMaxsize25ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveImageToClipBoardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveAsPictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.chkReverseX = New System.Windows.Forms.ToolStripMenuItem
        Me.chkReverseY = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.chkInvertAxes = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.chkLog = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripSeparator
        Me.ScaleMarkerSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScaleMarkersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator
        Me.chkXLogaritmic = New System.Windows.Forms.ToolStripMenuItem
        Me.chkYLogaritmic = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.FitChartToWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.chkShowMinorGrid = New System.Windows.Forms.ToolStripButton
        Me.tsShowMargin = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsFastLineChart = New System.Windows.Forms.ToolStripButton
        Me.tsFastPointChart = New System.Windows.Forms.ToolStripButton
        Me.tsDisplayLegend = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ANOVAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CorellationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CovarianceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VarianceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator
        Me.ShowAverageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowMaximumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowMinimumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator
        Me.ShowLinearRegressionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowPolynomialRegressionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowExponentialRegressionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowLogarithmicRegressionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowPowerRegressionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator
        Me.ShowMeanAverageStandardDeviationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator
        Me.DataIsSampleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.cbSortBy = New System.Windows.Forms.ToolStripComboBox
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea2.Area3DStyle.Inclination = 0
        ChartArea2.Area3DStyle.IsRightAngleAxes = False
        ChartArea2.Area3DStyle.Perspective = 45
        ChartArea2.Area3DStyle.Rotation = 0
        ChartArea2.Area3DStyle.WallWidth = 23
        ChartArea2.AxisX.InterlacedColor = System.Drawing.Color.MintCream
        ChartArea2.AxisX.IsMarginVisible = False
        ChartArea2.AxisX.LabelStyle.Interval = 0
        ChartArea2.AxisX.LabelStyle.TruncatedLabels = True
        ChartArea2.AxisX.MajorGrid.Interval = 0
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisX.MinorGrid.Enabled = True
        ChartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea2.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea2.AxisX.ScaleView.Zoomable = False
        ChartArea2.AxisY.LabelStyle.Interval = 0
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea2.AxisY.MinorGrid.Enabled = True
        ChartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea2.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea2.AxisY.ScaleView.Zoomable = False
        StripLine3.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(198, Byte), Integer))
        StripLine3.Text = "Standard Deviation"
        StripLine3.TextLineAlignment = System.Drawing.StringAlignment.Far
        StripLine4.BorderColor = System.Drawing.Color.DarkOrange
        StripLine4.BorderWidth = 2
        StripLine4.Text = "Mean Avg."
        StripLine4.TextLineAlignment = System.Drawing.StringAlignment.Far
        ChartArea2.AxisY.StripLines.Add(StripLine3)
        ChartArea2.AxisY.StripLines.Add(StripLine4)
        ChartArea2.BorderColor = System.Drawing.Color.DimGray
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series2.Legend = "Legend1"
        Series2.MarkerBorderColor = System.Drawing.Color.Blue
        Series2.MarkerColor = System.Drawing.Color.Transparent
        Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square
        Series2.Name = "Series1"
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
        Series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(789, 353)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Chart1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(789, 353)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(789, 403)
        Me.ToolStripContainer1.TabIndex = 3
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdEditChart, Me.ToolStripDropDownButton2, Me.ToolStripDropDownButton1, Me.ToolStripSeparator4, Me.chkShowMinorGrid, Me.tsShowMargin, Me.ToolStripSeparator2, Me.tsFastLineChart, Me.tsFastPointChart, Me.tsDisplayLegend, Me.ToolStripSeparator3, Me.ToolStripDropDownButton3, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.cbSortBy})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(726, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'cmdEditChart
        '
        Me.cmdEditChart.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChartTypeToolStripMenuItem, Me.ToolStripMenuItem5, Me.EditPointsToolStripMenuItem, Me.EditSeriesToolStripMenuItem, Me.ToolStripMenuItem4, Me.EditXAxisToolStripMenuItem, Me.EditYAxisToolStripMenuItem, Me.ToolStripMenuItem2, Me.AppearanceToolStripMenuItem, Me.MarkerSizeToolStripMenuItem, Me.MarkerMaxsize25ToolStripMenuItem, Me.ToolStripMenuItem6, Me.SaveImageToClipBoardToolStripMenuItem, Me.SaveAsPictureToolStripMenuItem, Me.ExportToCSVToolStripMenuItem, Me.ToolStripMenuItem12, Me.PrintPreviewToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.cmdEditChart.Image = CType(resources.GetObject("cmdEditChart.Image"), System.Drawing.Image)
        Me.cmdEditChart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdEditChart.Name = "cmdEditChart"
        Me.cmdEditChart.Size = New System.Drawing.Size(63, 22)
        Me.cmdEditChart.Text = "&Chart"
        '
        'ChartTypeToolStripMenuItem
        '
        Me.ChartTypeToolStripMenuItem.Image = CType(resources.GetObject("ChartTypeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChartTypeToolStripMenuItem.Name = "ChartTypeToolStripMenuItem"
        Me.ChartTypeToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ChartTypeToolStripMenuItem.Text = "Chart &Types"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(206, 6)
        '
        'EditPointsToolStripMenuItem
        '
        Me.EditPointsToolStripMenuItem.Image = CType(resources.GetObject("EditPointsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditPointsToolStripMenuItem.Name = "EditPointsToolStripMenuItem"
        Me.EditPointsToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.EditPointsToolStripMenuItem.Text = "Edit P&oints..."
        '
        'EditSeriesToolStripMenuItem
        '
        Me.EditSeriesToolStripMenuItem.Image = CType(resources.GetObject("EditSeriesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditSeriesToolStripMenuItem.Name = "EditSeriesToolStripMenuItem"
        Me.EditSeriesToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.EditSeriesToolStripMenuItem.Text = "Edit S&eries..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(206, 6)
        '
        'EditXAxisToolStripMenuItem
        '
        Me.EditXAxisToolStripMenuItem.Image = CType(resources.GetObject("EditXAxisToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditXAxisToolStripMenuItem.Name = "EditXAxisToolStripMenuItem"
        Me.EditXAxisToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.EditXAxisToolStripMenuItem.Text = "Edit &X Axis"
        '
        'EditYAxisToolStripMenuItem
        '
        Me.EditYAxisToolStripMenuItem.Image = CType(resources.GetObject("EditYAxisToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditYAxisToolStripMenuItem.Name = "EditYAxisToolStripMenuItem"
        Me.EditYAxisToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.EditYAxisToolStripMenuItem.Text = "Edit &Y Axis"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(206, 6)
        '
        'AppearanceToolStripMenuItem
        '
        Me.AppearanceToolStripMenuItem.Image = CType(resources.GetObject("AppearanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AppearanceToolStripMenuItem.Name = "AppearanceToolStripMenuItem"
        Me.AppearanceToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.AppearanceToolStripMenuItem.Text = "Axis and grid colors..."
        '
        'MarkerSizeToolStripMenuItem
        '
        Me.MarkerSizeToolStripMenuItem.Image = CType(resources.GetObject("MarkerSizeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MarkerSizeToolStripMenuItem.Name = "MarkerSizeToolStripMenuItem"
        Me.MarkerSizeToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.MarkerSizeToolStripMenuItem.Tag = ""
        Me.MarkerSizeToolStripMenuItem.Text = "Marker size: [5]"
        '
        'MarkerMaxsize25ToolStripMenuItem
        '
        Me.MarkerMaxsize25ToolStripMenuItem.Image = CType(resources.GetObject("MarkerMaxsize25ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MarkerMaxsize25ToolStripMenuItem.Name = "MarkerMaxsize25ToolStripMenuItem"
        Me.MarkerMaxsize25ToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.MarkerMaxsize25ToolStripMenuItem.Text = "Marker max-size: [25]"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(206, 6)
        '
        'SaveImageToClipBoardToolStripMenuItem
        '
        Me.SaveImageToClipBoardToolStripMenuItem.Image = CType(resources.GetObject("SaveImageToClipBoardToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveImageToClipBoardToolStripMenuItem.Name = "SaveImageToClipBoardToolStripMenuItem"
        Me.SaveImageToClipBoardToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.SaveImageToClipBoardToolStripMenuItem.Text = "Save image to &Clip Board"
        '
        'SaveAsPictureToolStripMenuItem
        '
        Me.SaveAsPictureToolStripMenuItem.Image = CType(resources.GetObject("SaveAsPictureToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveAsPictureToolStripMenuItem.Name = "SaveAsPictureToolStripMenuItem"
        Me.SaveAsPictureToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsPictureToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.SaveAsPictureToolStripMenuItem.Text = "&Save to image file..."
        '
        'ExportToCSVToolStripMenuItem
        '
        Me.ExportToCSVToolStripMenuItem.Image = CType(resources.GetObject("ExportToCSVToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportToCSVToolStripMenuItem.Name = "ExportToCSVToolStripMenuItem"
        Me.ExportToCSVToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExportToCSVToolStripMenuItem.Text = "Export to CSV..."
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(206, 6)
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Image = CType(resources.GetObject("PrintPreviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print preview"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.PrintToolStripMenuItem.Text = "Print..."
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.chkReverseX, Me.chkReverseY, Me.ToolStripMenuItem1, Me.chkInvertAxes})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripDropDownButton2.Text = "&Inversions"
        '
        'chkReverseX
        '
        Me.chkReverseX.CheckOnClick = True
        Me.chkReverseX.Name = "chkReverseX"
        Me.chkReverseX.Size = New System.Drawing.Size(145, 22)
        Me.chkReverseX.Text = "Reverse X Axe"
        '
        'chkReverseY
        '
        Me.chkReverseY.CheckOnClick = True
        Me.chkReverseY.Name = "chkReverseY"
        Me.chkReverseY.Size = New System.Drawing.Size(145, 22)
        Me.chkReverseY.Text = "Reverse Y Axe"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(142, 6)
        '
        'chkInvertAxes
        '
        Me.chkInvertAxes.CheckOnClick = True
        Me.chkInvertAxes.Name = "chkInvertAxes"
        Me.chkInvertAxes.Size = New System.Drawing.Size(145, 22)
        Me.chkInvertAxes.Text = "Invert Axes"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.chkLog, Me.ToolStripMenuItem13, Me.ScaleMarkerSizeToolStripMenuItem, Me.ScaleMarkersToolStripMenuItem, Me.ToolStripMenuItem7, Me.chkXLogaritmic, Me.chkYLogaritmic, Me.ToolStripMenuItem3, Me.FitChartToWindowToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripDropDownButton1.Text = "Sc&aling"
        '
        'chkLog
        '
        Me.chkLog.CheckOnClick = True
        Me.chkLog.Name = "chkLog"
        Me.chkLog.Size = New System.Drawing.Size(227, 22)
        Me.chkLog.Text = "&Logarithmic"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(224, 6)
        '
        'ScaleMarkerSizeToolStripMenuItem
        '
        Me.ScaleMarkerSizeToolStripMenuItem.Name = "ScaleMarkerSizeToolStripMenuItem"
        Me.ScaleMarkerSizeToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ScaleMarkerSizeToolStripMenuItem.Text = "Scale &Marker Size"
        Me.ScaleMarkerSizeToolStripMenuItem.ToolTipText = "Marker size is based on Z-values of all Series."
        '
        'ScaleMarkersToolStripMenuItem
        '
        Me.ScaleMarkersToolStripMenuItem.Name = "ScaleMarkersToolStripMenuItem"
        Me.ScaleMarkersToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ScaleMarkersToolStripMenuItem.Text = "Scale Marker Size by &Serie"
        Me.ScaleMarkersToolStripMenuItem.ToolTipText = "Marker size is based only on Z-values of owning Serie."
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(224, 6)
        '
        'chkXLogaritmic
        '
        Me.chkXLogaritmic.CheckOnClick = True
        Me.chkXLogaritmic.Name = "chkXLogaritmic"
        Me.chkXLogaritmic.Size = New System.Drawing.Size(227, 22)
        Me.chkXLogaritmic.Text = "X Logarithmic"
        '
        'chkYLogaritmic
        '
        Me.chkYLogaritmic.CheckOnClick = True
        Me.chkYLogaritmic.Name = "chkYLogaritmic"
        Me.chkYLogaritmic.Size = New System.Drawing.Size(227, 22)
        Me.chkYLogaritmic.Text = "Y Logarithmic"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(224, 6)
        '
        'FitChartToWindowToolStripMenuItem
        '
        Me.FitChartToWindowToolStripMenuItem.Image = CType(resources.GetObject("FitChartToWindowToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FitChartToWindowToolStripMenuItem.Name = "FitChartToWindowToolStripMenuItem"
        Me.FitChartToWindowToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.FitChartToWindowToolStripMenuItem.Text = "&Fit Chart Maximum and Minimum"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'chkShowMinorGrid
        '
        Me.chkShowMinorGrid.Checked = True
        Me.chkShowMinorGrid.CheckOnClick = True
        Me.chkShowMinorGrid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowMinorGrid.Image = CType(resources.GetObject("chkShowMinorGrid.Image"), System.Drawing.Image)
        Me.chkShowMinorGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.chkShowMinorGrid.Name = "chkShowMinorGrid"
        Me.chkShowMinorGrid.Size = New System.Drawing.Size(75, 22)
        Me.chkShowMinorGrid.Text = "Minor Grid"
        Me.chkShowMinorGrid.ToolTipText = "Show or hide minor grid"
        '
        'tsShowMargin
        '
        Me.tsShowMargin.Checked = Global.QITA_OLTK.My.MySettings.Default.Chart_ShowMargin
        Me.tsShowMargin.CheckOnClick = True
        Me.tsShowMargin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsShowMargin.Image = CType(resources.GetObject("tsShowMargin.Image"), System.Drawing.Image)
        Me.tsShowMargin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowMargin.Name = "tsShowMargin"
        Me.tsShowMargin.Size = New System.Drawing.Size(23, 22)
        Me.tsShowMargin.Text = "Show Margin"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsFastLineChart
        '
        Me.tsFastLineChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsFastLineChart.Image = CType(resources.GetObject("tsFastLineChart.Image"), System.Drawing.Image)
        Me.tsFastLineChart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFastLineChart.Name = "tsFastLineChart"
        Me.tsFastLineChart.Size = New System.Drawing.Size(23, 22)
        Me.tsFastLineChart.Text = "&Line"
        Me.tsFastLineChart.ToolTipText = "Chart type: Line"
        '
        'tsFastPointChart
        '
        Me.tsFastPointChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsFastPointChart.Image = CType(resources.GetObject("tsFastPointChart.Image"), System.Drawing.Image)
        Me.tsFastPointChart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFastPointChart.Name = "tsFastPointChart"
        Me.tsFastPointChart.Size = New System.Drawing.Size(23, 22)
        Me.tsFastPointChart.Text = "&Points"
        Me.tsFastPointChart.ToolTipText = "Chart type: Point"
        '
        'tsDisplayLegend
        '
        Me.tsDisplayLegend.CheckOnClick = True
        Me.tsDisplayLegend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsDisplayLegend.Image = CType(resources.GetObject("tsDisplayLegend.Image"), System.Drawing.Image)
        Me.tsDisplayLegend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDisplayLegend.Name = "tsDisplayLegend"
        Me.tsDisplayLegend.Size = New System.Drawing.Size(23, 22)
        Me.tsDisplayLegend.Text = "Display Legend"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ANOVAToolStripMenuItem, Me.CorellationToolStripMenuItem, Me.CovarianceToolStripMenuItem, Me.VarianceToolStripMenuItem, Me.ToolStripMenuItem9, Me.ShowAverageToolStripMenuItem, Me.ShowMaximumToolStripMenuItem, Me.ShowMinimumToolStripMenuItem, Me.ToolStripMenuItem8, Me.ShowLinearRegressionToolStripMenuItem, Me.ShowPolynomialRegressionToolStripMenuItem, Me.ShowExponentialRegressionToolStripMenuItem, Me.ShowLogarithmicRegressionToolStripMenuItem, Me.ShowPowerRegressionToolStripMenuItem, Me.ToolStripMenuItem10, Me.ShowMeanAverageStandardDeviationToolStripMenuItem, Me.ToolStripMenuItem11, Me.DataIsSampleToolStripMenuItem})
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripDropDownButton3.Text = "&Statistics"
        '
        'ANOVAToolStripMenuItem
        '
        Me.ANOVAToolStripMenuItem.Enabled = False
        Me.ANOVAToolStripMenuItem.Image = CType(resources.GetObject("ANOVAToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ANOVAToolStripMenuItem.Name = "ANOVAToolStripMenuItem"
        Me.ANOVAToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ANOVAToolStripMenuItem.Text = "ANOVA"
        '
        'CorellationToolStripMenuItem
        '
        Me.CorellationToolStripMenuItem.Image = CType(resources.GetObject("CorellationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CorellationToolStripMenuItem.Name = "CorellationToolStripMenuItem"
        Me.CorellationToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.CorellationToolStripMenuItem.Text = "Correlation"
        '
        'CovarianceToolStripMenuItem
        '
        Me.CovarianceToolStripMenuItem.Image = CType(resources.GetObject("CovarianceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CovarianceToolStripMenuItem.Name = "CovarianceToolStripMenuItem"
        Me.CovarianceToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.CovarianceToolStripMenuItem.Text = "Covariance"
        '
        'VarianceToolStripMenuItem
        '
        Me.VarianceToolStripMenuItem.Image = CType(resources.GetObject("VarianceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VarianceToolStripMenuItem.Name = "VarianceToolStripMenuItem"
        Me.VarianceToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.VarianceToolStripMenuItem.Text = "Variance"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(347, 6)
        '
        'ShowAverageToolStripMenuItem
        '
        Me.ShowAverageToolStripMenuItem.CheckOnClick = True
        Me.ShowAverageToolStripMenuItem.Name = "ShowAverageToolStripMenuItem"
        Me.ShowAverageToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ShowAverageToolStripMenuItem.Text = "Show Average "
        '
        'ShowMaximumToolStripMenuItem
        '
        Me.ShowMaximumToolStripMenuItem.CheckOnClick = True
        Me.ShowMaximumToolStripMenuItem.Name = "ShowMaximumToolStripMenuItem"
        Me.ShowMaximumToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ShowMaximumToolStripMenuItem.Text = "Show Maximum"
        '
        'ShowMinimumToolStripMenuItem
        '
        Me.ShowMinimumToolStripMenuItem.CheckOnClick = True
        Me.ShowMinimumToolStripMenuItem.Name = "ShowMinimumToolStripMenuItem"
        Me.ShowMinimumToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ShowMinimumToolStripMenuItem.Text = "Show Minimum"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(347, 6)
        '
        'ShowLinearRegressionToolStripMenuItem
        '
        Me.ShowLinearRegressionToolStripMenuItem.Name = "ShowLinearRegressionToolStripMenuItem"
        Me.ShowLinearRegressionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.ShowLinearRegressionToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ShowLinearRegressionToolStripMenuItem.Text = "Show Linear Regression"
        '
        'ShowPolynomialRegressionToolStripMenuItem
        '
        Me.ShowPolynomialRegressionToolStripMenuItem.Name = "ShowPolynomialRegressionToolStripMenuItem"
        Me.ShowPolynomialRegressionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ShowPolynomialRegressionToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ShowPolynomialRegressionToolStripMenuItem.Text = "Show Polynomial Regression"
        '
        'ShowExponentialRegressionToolStripMenuItem
        '
        Me.ShowExponentialRegressionToolStripMenuItem.Name = "ShowExponentialRegressionToolStripMenuItem"
        Me.ShowExponentialRegressionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ShowExponentialRegressionToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ShowExponentialRegressionToolStripMenuItem.Text = "Show Exponential Regression"
        '
        'ShowLogarithmicRegressionToolStripMenuItem
        '
        Me.ShowLogarithmicRegressionToolStripMenuItem.Name = "ShowLogarithmicRegressionToolStripMenuItem"
        Me.ShowLogarithmicRegressionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.ShowLogarithmicRegressionToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ShowLogarithmicRegressionToolStripMenuItem.Text = "Show Logarithmic Regression"
        '
        'ShowPowerRegressionToolStripMenuItem
        '
        Me.ShowPowerRegressionToolStripMenuItem.Name = "ShowPowerRegressionToolStripMenuItem"
        Me.ShowPowerRegressionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.ShowPowerRegressionToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ShowPowerRegressionToolStripMenuItem.Text = "Show Power Regression"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(347, 6)
        '
        'ShowMeanAverageStandardDeviationToolStripMenuItem
        '
        Me.ShowMeanAverageStandardDeviationToolStripMenuItem.CheckOnClick = True
        Me.ShowMeanAverageStandardDeviationToolStripMenuItem.Name = "ShowMeanAverageStandardDeviationToolStripMenuItem"
        Me.ShowMeanAverageStandardDeviationToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.ShowMeanAverageStandardDeviationToolStripMenuItem.Text = "Show Mean Average + Standard Deviation"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(347, 6)
        '
        'DataIsSampleToolStripMenuItem
        '
        Me.DataIsSampleToolStripMenuItem.Checked = True
        Me.DataIsSampleToolStripMenuItem.CheckOnClick = True
        Me.DataIsSampleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DataIsSampleToolStripMenuItem.Name = "DataIsSampleToolStripMenuItem"
        Me.DataIsSampleToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.DataIsSampleToolStripMenuItem.Text = "Data is  SAMPLE population (unchek for entire population)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripLabel2.Text = "Sort data:"
        '
        'cbSortBy
        '
        Me.cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSortBy.Name = "cbSortBy"
        Me.cbSortBy.Size = New System.Drawing.Size(121, 25)
        '
        'UCChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Name = "UCChart"
        Me.Size = New System.Drawing.Size(789, 403)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents chkShowMinorGrid As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbSortBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents chkXLogaritmic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkYLogaritmic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents chkReverseX As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkReverseY As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkInvertAxes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdEditChart As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents EditYAxisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditXAxisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditSeriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FitChartToWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AppearanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChartTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MarkerSizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveAsPictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditPointsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton3 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ShowAverageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowMaximumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowMinimumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowLinearRegressionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowPolynomialRegressionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowExponentialRegressionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowLogarithmicRegressionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowPowerRegressionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsFastLineChart As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsFastPointChart As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ANOVAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CorellationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CovarianceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VarianceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsShowMargin As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveImageToClipBoardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowMeanAverageStandardDeviationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataIsSampleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsDisplayLegend As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ScaleMarkerSizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkerMaxsize25ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScaleMarkersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
