Imports QITA_OLTK.QITAInterfaces
Imports System.Reflection
Imports QITA_OLTK.QITADataTypes
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports QITA_OLTK.QITAMorphoAnalyzers

Public Class Form1
    Public _DockManager As DockPanel = Nothing

    Private _ProjectCount As Integer = 1
    Private _ChartViewers As New List(Of UFChartViewer)
    Private _Projects As New List(Of IQITAProject)

#Region "PUBLIC Enumerators"
    Public ReadOnly Property ChartViewers() As List(Of UFChartViewer)
        Get
            Return _ChartViewers
        End Get
    End Property

    Public ReadOnly Property AvailableMorphoAnalyzers() As List(Of IQITAMorphologyAnalyzer)
        Get
            Return GetQITATextProcessors(Of IQITAMorphologyAnalyzer)(".QITAMorphoAnalyzers.")
        End Get
    End Property

    Public ReadOnly Property AvailableIndexes() As List(Of IQITAIndex)
        Get
            Return GetQITATextProcessors(Of IQITAIndex)(".QITAIndexes.")
        End Get
    End Property

    Public ReadOnly Property AvailablePostProcessors() As List(Of IQITATextPostProcessors)
        Get
            Return GetQITATextProcessors(Of IQITATextPostProcessors)(".QITAPostProcessors.")
        End Get
    End Property

    Public ReadOnly Property Projects() As List(Of IQITAProject)
        Get
            Return _Projects
        End Get
    End Property

    Private Function GetQITATextProcessors(Of T)(ByVal sImplementationPath As String) As List(Of T)
        Dim sInterfaceName As String = GetType(T).UnderlyingSystemType.Name
        Dim results As New List(Of T)

        For Each s As System.Type In Assembly.GetAssembly(GetType(QITA)).GetTypes()
            If (s.IsVisible) AndAlso (Not s.IsAbstract()) Then
                If s.GetInterface(sInterfaceName, True) IsNot Nothing Then
                    Dim o As Object = CreateQITAObject(s.FullName, sImplementationPath)

                    If IsAny(o) Then
                        results.Add(o)
                    End If
                End If
            End If
        Next

        Return results
    End Function
#End Region

#Region "PROJECT Setups"
    Private Sub NewMultiTextProject(ByVal basic As Boolean)
        Dim k As New UFProjectTexts

        k.MdiParent = Me
        k.Show(_DockManager, DockState.Document)
        k.NewProject("Multiple Text Project " & _ProjectCount)

        AddNewProject(DirectCast(k, IQITAProject))
    End Sub

    Private Sub AddNewProject(ByRef k As IQITAProject)
        _ProjectCount += 1
        _Projects.Add(k)
    End Sub

    Public Sub UnregisterProject(ByRef project As IQITAProject)
        _Projects.Remove(project)
        GC.Collect()
    End Sub
#End Region

#Region "CHART Operators"
    Private Sub AddNewChartViewer(ByRef chartViewer As UFChartViewer)
        'statusStripCharts.Items.Add(New ToolStripButton(k.Text, k.Icon.ToBitmap()))

        AddHandler chartViewer.FormClosed, AddressOf ChartViewerClosed
        _ChartViewers.Add(chartViewer)
    End Sub

    Public Sub ShowChart(ByRef existingChartViewer As UFChartViewer, ByRef chartData As List(Of QITAChartableDataArray))
        If IsAny(existingChartViewer) Then
            existingChartViewer.AddToChart(chartData)
        Else
            AddNewChartViewer(CreateChartViewer(chartData))
        End If
    End Sub

    Public Function CreateChartViewer(ByRef chartData As List(Of QITAChartableDataArray)) As UFChartViewer
        Dim k As New UFChartViewer
        k.ViewChart(chartData)
        k.MdiParent = Me
        k.Show(_DockManager, DockState.DockBottom)

        Return k
    End Function

    Private Sub ChartViewerClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        _ChartViewers.Remove(sender)
    End Sub

    Public Function ChartExistsWithName(ByVal sName As String) As Boolean
        For Each m As UFChartViewer In Me.ChartViewers
            If m.CheckIfSerieAlreadyExistsInChart(sName) Then
                Return True
            End If
        Next

        Return False
    End Function
#End Region

#Region "GUI"
    Private Sub tsNewMultiTextProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNewMultiTextProject.Click
        Me.Cursor = Cursors.AppStarting
        NewMultiTextProject(False)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tvProjects_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
        If IsAny(e.Node) Then
            DirectCast(e.Node.Tag, Form).BringToFront()
        End If
    End Sub

    Private Sub tsToolsStandardDeviationCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsToolsStandardDeviationCalc.Click
        UFCalculator.Show(_DockManager, DockState.DockBottom)
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        UFAbout.ShowDialog()
    End Sub
#End Region


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "QUITA - Quantitative Text Analyzer " + My.Application.Info.Version.ToString()
        My.Settings.Last_NGramSize = 0
        'Dim k As New QITA_OLTK.QITAMorphoAnalyzers.MorphoAnalyzerNLTKArabic
        'Dim k As New QITA_OLTK.QITAMorphoAnalyzers.MorphoAnalyzerNLTKEnglish
        'Dim k As New QITA_OLTK.QITAMorphoAnalyzers.MorphoAnalyzerNLTKDeutch
        'Dim k As New QITA_OLTK.QITAMorphoAnalyzers.MorphoAnalyzerNLTKRussian
        'k.Initialize()

        'Debug.Print(k.LemmatizeWord("Märchen")) > "march" ????
        'Debug.Print(k.LemmatizeWord("اللغات"))
        'Debug.Print(k.LemmatizeWord("важных"))
        'Application.Exit()

    End Sub

    Private Sub RandomTextCratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomTextCratorToolStripMenuItem.Click
        UFRandomTextCreator.Show(Me)
    End Sub

    Private Sub BinaryFileToAlphabeteTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BinaryFileToAlphabeteTextToolStripMenuItem.Click
        UFBinaryFileMapper.Show(Me)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Settings_TreatNumbersAsWords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Settings_TreatNumbersAsWords.Click
        My.Settings.Settings_TreatNumbersAsWords = Settings_TreatNumbersAsWords.Checked
    End Sub

    Private Sub Settings_TreatNonAlphasAsWords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Settings_TreatNonAlphasAsWords.Click
        My.Settings.Settings_TreatNonAlphaNumericsAsTokens = Settings_TreatNonAlphasAsWords.Checked
    End Sub

    Private Sub ResetNGramsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetNGramsToolStripMenuItem.Click
        Me.ResetNGrams()
    End Sub

    Private Sub RecalculateAllProjectsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecalculateAllProjectsToolStripMenuItem.Click
        Me.ResetNGrams()

        For Each p As IQITAProject In Me.Projects
            p.Calculate()
        Next
    End Sub

    Private Sub ResetNGrams()
        My.Settings.Last_NGramSize = 0
    End Sub

    
End Class

