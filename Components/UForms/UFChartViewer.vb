Imports QITA_OLTK.QITADataTypes

Public Class UFChartViewer
    Inherits DockContent

    Public Sub ViewChart(ByRef chartData As List(Of QITAChartableDataArray))
        SetWorking(Me, True)

        InitializeChart()

        SetWindowTitle(chartData(0).DataTitle)
        AddToChart(chartData)

        SetWorking(Me, False)
    End Sub

    Public Sub AddToChart(ByRef chartableData As List(Of QITAChartableDataArray))
        SetWorking(Me, True)

        For Each q As QITAChartableDataArray In chartableData
            UcChart1.AddSerie(q)
            Application.DoEvents()
        Next

        UcChart1.Done()
        SetWorking(Me, False)
    End Sub

    Public Function CheckIfSerieAlreadyExistsInChart(ByVal sName As String) As Boolean
        Return UcChart1.CheckIfSerieAlreadExists(sName)
    End Function

    Private Sub InitializeChart()
        UcChart1.ClearAll()
        UcChart1.Initialize()
    End Sub

    Private Sub SetWindowTitle(ByVal sTitle As String)
        Me.Text = "Chart: " & sTitle
        UcChart1.ChartName = sTitle
    End Sub
End Class