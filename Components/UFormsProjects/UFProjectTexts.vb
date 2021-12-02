Imports QITA_OLTK.QITAInterfaceImplementations
Imports QITA_OLTK.QITADataTypes
Imports QITA_OLTK.QITAInterfaces
Imports QITA_OLTK.QITAIndexes
Imports QITA_OLTK.QITAMorphoAnalyzers

Public Class UFProjectTexts
    Inherits DockContent
    Implements IQITAProject

    Private _ProjectName As String = "Multiple Text Project 1"
    Private _AllComputedTexts As New List(Of IQITAText)
    Private _StopComputing As Boolean = False

#Region ":: IQITAProject Interface"
    Public Function NewProject(ByVal sProjectName As String) As IQITAProject Implements IQITAProject.NewProject
        ProjectName = sProjectName

        FillSettings()
        Return Me
    End Function

    Public Property ProjectName() As String Implements QITAInterfaces.IQITAProject.ProjectName
        Get
            Return _ProjectName
        End Get
        Set(ByVal value As String)
            _ProjectName = value
            UpdateProjectWindowTitle()
        End Set
    End Property

    Public ReadOnly Property Texts() As List(Of IQITAText) Implements IQITAProject.Texts
        Get
            Return _AllComputedTexts
        End Get
    End Property

    Public ReadOnly Property SelectedTexts() As List(Of IQITAText) Implements IQITAProject.SelectedTexts
        Get
            Return UcResults1.SelectedTexts
        End Get
    End Property

    Public ReadOnly Property ComputedIndexes() As List(Of IQITAIndex) Implements IQITAProject.ComputedIndexes
        Get
            Dim indexes As New Dictionary(Of String, IQITAIndex)
            Dim results As New List(Of IQITAIndex)

            For Each text As IQITAText In Texts
                For Each r As IQITAResult In text.ReadyResults()
                    If Not r.IsSecondary Then
                        If Not indexes.ContainsKey(r.IndexReference.IndexName) Then
                            indexes.Add(r.IndexReference.IndexName, r.IndexReference)
                        End If
                    End If
                Next
            Next

            For Each t As KeyValuePair(Of String, IQITAIndex) In indexes.ToList()
                results.Add(t.Value)
            Next

            Return results
        End Get
    End Property

    Public Function GetResultsOfIndex(ByVal sIndexName As String) As List(Of IQITAResult) Implements IQITAProject.GetResultsOfIndex
        Dim results As New List(Of IQITAResult)

        For Each text As IQITAText In Me.Texts
            For Each result As IQITAResult In text.ReadyResults
                If StrIsSame(result.IndexReference.IndexName, sIndexName) Then
                    results.Add(result)
                End If
            Next
        Next

        Return results
    End Function

    Public ReadOnly Property DataSource() As QITAProjectDataSource Implements IQITAProject.DataSource
        Get
            Return New QITAProjectDataSource(Me, UcResults1.DataSourceContainer)
        End Get
    End Property
#End Region

#Region ":: Properties"
    Public ReadOnly Property SelectedLemmatizer() As IQITAMorphologyAnalyzer
        Get
            Return ucLemmatizerBrowser.GetCheckedItem(Of IQITAMorphologyAnalyzer)()
        End Get
    End Property

    Public ReadOnly Property SelectedTokenizer() As IQITAMorphologyAnalyzer
        Get
            Return ucTokenizerBrowser.GetCheckedItem(Of IQITAMorphologyAnalyzer)()
        End Get
    End Property

    Public ReadOnly Property SelectedPOSTagger() As IQITAMorphologyAnalyzer
        Get
            Return ucPOSTaggerBrowser.GetCheckedItem(Of IQITAMorphologyAnalyzer)()
        End Get
    End Property

    Public ReadOnly Property SelectedPostProcessor() As IQITATextPostProcessors
        Get
            Return cmbPostProcessor.SelectedPostProcessor
        End Get
    End Property

    Public Property StopComputing() As Boolean
        Get
            Return _StopComputing
        End Get
        Set(ByVal value As Boolean)
            _StopComputing = value

            cmdCompute.Enabled = value
            cmdStopCompute.Enabled = Not value
        End Set
    End Property
#End Region

#Region ":: Project"
    Private Sub UpdateProjectWindowTitle()
        Me.Text = "MTP-" & ProjectName
    End Sub

    Private Sub UFProjectTexts_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tabProjectSettingsPageProjectTextsGroup.Focus()
        txtSettingsProjectName.Focus()
        txtSettingsProjectName.SelectAll()
    End Sub

    Private Sub UFProjectTexts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AddNewText("D:\_SKOLA\OLTK\OKA\Svejk_1\Svejk_1\svejk_05.txt")
        ucTokenizerBrowser.LinkWithCombobox(cmbTokenizer, True)
        ucLemmatizerBrowser.LinkWithCombobox(cmbLemmatizer)
        ucPOSTaggerBrowser.LinkWithCombobox(cmbPOSTagger)
        cmbPostProcessor.Fill()

        SelectItemInComboBoxByText(cmbTokenizer, My.Settings.LastUsedTokenizer)
        SelectItemInComboBoxByText(cmbLemmatizer, My.Settings.LastUsedLemmatizer)
        SelectItemInComboBoxByText(cmbPOSTagger, My.Settings.LastUsedPOSTagger)
        SelectItemInComboBoxByText(cmbPostProcessor, My.Settings.LastUsedPostProcessor)

        tabProject.TabPages.Remove(tabResultsOverview)
    End Sub
#End Region

#Region ":: Computation & Results"
    Private Function Calculate() As Boolean Implements IQITAProject.Calculate
        If UcFiles1.GetAllTexts().Count = 0 Then
            MsgBox("No texts available.", MsgBoxStyle.Exclamation)
            Exit Function
        End If

        SetMeWorking(True)

        Dim i = 1
        Dim iCount As Integer = UcFiles1.TextsCount
        Dim lemmatizer As IQITAMorphologyAnalyzer = Me.SelectedLemmatizer
        Dim tokenizer As IQITAMorphologyAnalyzer = Me.SelectedTokenizer
        Dim posTagger As IQITAMorphologyAnalyzer = Me.SelectedPOSTagger
        Dim postProcessor As IQITATextPostProcessors = Me.SelectedPostProcessor

        If IsAny(lemmatizer) Then
            SetComputeProgressStatus("Initializing lemmatizer...")
            lemmatizer.Initialize()
        End If

        If IsAny(posTagger) Then
            SetComputeProgressStatus("Initializing POS Tagger...")
            posTagger.Initialize()
        End If

        If IsAny(tokenizer) Then
            SetComputeProgressStatus("Initializing tokenizer...")
            tokenizer.Initialize()
        End If

        If IsAny(postProcessor) Then
            SetComputeProgressStatus("Initializing post processor...")
            postProcessor.InitializePostProcessor()
        End If

        SetComputeProgressStatus("Initializing computation...")
        UcFiles1.SetAllTextsStatusToInQueue()

        Me.Texts.Clear()
        Me.ComputedIndexes.Clear()
        Me.StopComputing = False

        For Each Text As IQITAText In UcFiles1.GetAllTexts()
            Text.ReLoadFile()
            Text.AssignedLemmatizer = lemmatizer
            Text.AssignedPOSTagger = posTagger
            Text.AssignedTokenizer = tokenizer
            Me.Texts.Add(Text)

            SetComputeProgressStatus("Processing " & Text.TextName & "...", i, iCount)
            UcFiles1.SetTextStatus(Text, UCFiles.TextStatus.Working)
            Text.InitializeBeforeComputing()

            SetComputeProgressStatus("Post-Processing " & Text.TextName & "...", i, iCount)
            If IsAny(postProcessor) Then
                postProcessor.PostProcess(Text)
                Text.InitializeAfterPostProcessing()
            End If

            SetComputeProgressStatus("Calculating indexes " & Text.TextName & "...", i, iCount)
            For Each index As IQITAIndex In UcIndexBrowser1.GetCheckedItems()
                Text.ComputeIndex(index)
            Next

            SetComputeProgressStatus("Clearing Cache " & Text.TextName & "...", i, iCount)
            Text.ClearCache()

            UcFiles1.SetTextStatus(Text, UCFiles.TextStatus.Ready)
            Application.DoEvents()
            i += 1

            If My.Computer.Info.AvailablePhysicalMemory < (0.05 * My.Computer.Info.TotalPhysicalMemory) Then
                MsgBox("Currently available RAM memory is not sufficient for processing all loaded texts." & Environment.NewLine & _
                       "Processing will be canceled to prevent your system from slowing down." & Environment.NewLine & Environment.NewLine & _
                       "Texts processed: " & i & "/" & iCount & Environment.NewLine & Environment.NewLine & _
                       "Further Recommendations: " & Environment.NewLine & _
                       "(1) Disable Cache in Cache tab" & Environment.NewLine & _
                       "(2) Try to use as least texts as possible -- you can use limitting constrains for loading files from directory." & Environment.NewLine & _
                       "(3) Select only indexes that are necessary.", MsgBoxStyle.Exclamation)
                Exit For
            End If

            If Me.StopComputing Then Exit For
        Next

        Me.StopComputing = True
        SetComputeProgressStatus("Populating results...")
        ShowResultTab()

        UcResults1.Project = Me
        UcResults1.InitializeResults(Texts)

        OpenResultTab()
        SetComputeProgressStatus("Ready.")
        SetMeWorking(False)

        SetResultsFocus()
        Return True
    End Function

    Private Sub ComputeComparsionForIndex(ByRef QITAIndexType As Type)
        Dim text As IQITAText = Nothing
        Dim output As New QITATable("Index Comparsion")
        Dim textsWithIndexResult As New List(Of IQITAText)
        Dim sIndexName As String = Nothing

        For Each text In Me.Texts
            If IsAny(text.GetResultByIndex(QITAIndexType)) Then
                textsWithIndexResult.Add(text)
            End If
        Next

        If textsWithIndexResult.Count Then
            output.AddColumn(" ")

            For Each text In textsWithIndexResult
                output.AddColumn(text.TextName)
                output.AddRow(text.TextName)
            Next

            Dim x As Integer = 1
            Dim y As Integer = 1
            Dim resultSource As IQITAResult = Nothing
            Dim resultDestination As IQITAResult = Nothing
            Dim result As IQITAResult = Nothing

            For Each textSource As IQITAText In textsWithIndexResult
                x = 1

                For Each textDestination As IQITAText In textsWithIndexResult
                    resultSource = textSource.GetResultByIndex(QITAIndexType)
                    resultDestination = textDestination.GetResultByIndex(QITAIndexType)
                    result = resultSource.CompareWith(resultDestination)

                    If IsAny(result) Then
                        output.CellValue(y, x) = result.Value
                    End If

                    If sIndexName Is Nothing Then
                        sIndexName = resultSource.IndexReference.IndexName
                    End If

                    x += 1
                Next

                y += 1
            Next

        End If

        AddNewComparsionResults(sIndexName, output)
    End Sub

    Private Sub SetComputeProgressStatus(ByVal sActualText As String, _
                                               Optional ByVal iOrdinal As Integer = 1, _
                                               Optional ByVal iCount As Integer = 1)

        lblComputeStatus.Text = sActualText
        pgComputeStatus.Value = (iOrdinal / iCount) * 100
        Application.DoEvents()
    End Sub

    Private Sub OpenResultTab()
        tabProject.SelectedTab = tabResultsOverview
        tabProject.Focus()
        UcResults1.Focus()
    End Sub

    Private Sub SetResultsFocus()
        tabResultsOverview.Focus()
        UcResults1.Focus()
    End Sub

    Private Sub ShowResultTab()
        If Not tabProject.TabPages.Contains(tabResultsOverview) Then
            tabProject.TabPages.Add(tabResultsOverview)
        End If
    End Sub

    Private Sub AddNewResults(ByRef result As IQITAResult)
        Static pageFont As Font = UcFiles1.Font

        SetMeWorking(True)
        Dim newResultsTab As New TabPage(result.TextReference.TextName & "> " & _
                                            IIf(StrIsAny(result.ResultName), _
                                                    result.ResultName, _
                                                    "Table"))

        tabProject.TabPages.Add(newResultsTab)
        newResultsTab.ImageKey = "table"

        Dim resultControl As New UCResultData
        newResultsTab.Controls.Add(resultControl)

        resultControl.Font = pageFont
        resultControl.Dock = DockStyle.Fill
        tabProject.SelectedTab = newResultsTab

        resultControl.ShowData(result)
        SetMeWorking(False)
    End Sub

    Private Sub AddNewComparsionResults(ByVal sIndexName As String, ByRef comparsionResults As QITATable)
        Static pageFont As Font = UcFiles1.Font

        SetMeWorking(True)
        Dim newResultsTab As New TabPage("Comparsion: " & sIndexName)

        tabProject.TabPages.Add(newResultsTab)
        newResultsTab.ImageKey = "calc"

        Dim resultControl As New UCComparsionResults
        newResultsTab.Controls.Add(resultControl)

        resultControl.Font = pageFont
        resultControl.Dock = DockStyle.Fill
        tabProject.SelectedTab = newResultsTab

        resultControl.ShowComparsionResults(Me, comparsionResults)
        SetMeWorking(False)
    End Sub

    Private Sub UcResults1_OpenDataResult(ByRef result As QITA_OLTK.QITAInterfaces.IQITAResult) Handles UcResults1.OpenDataResult
        AddNewResults(result)
    End Sub

    Private Sub UcResults1_CompareIndexResults(ByRef QITAIndexType As Type) Handles UcResults1.CompareIndexResults
        ComputeComparsionForIndex(QITAIndexType)
    End Sub

#End Region

#Region ":: Project Settings"
    Public Sub FillSettings()
        txtSettingsProjectName.Text = ProjectName
    End Sub
#End Region

#Region ":: Form Events"
    Private Sub ProcessDragEnter(ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub gridFiles_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        ProcessDragEnter(e)
    End Sub

    Private Sub cmdCompute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompute.Click
        Me.SaveSettings()
        Me.Calculate()
    End Sub

    Private Sub cmdStopCompute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStopCompute.Click
        Me.StopComputing = True
    End Sub

    Private Sub SetMeWorking(ByVal b As Boolean)
        Me.Cursor = IIf(b, Cursors.AppStarting, Cursors.Arrow)
        tabProject.Enabled = Not b
    End Sub

    Private Sub txtSettingsProjectName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSettingsProjectName.TextChanged
        ProjectName = txtSettingsProjectName.Text
    End Sub

    Private Sub TabControl2_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles tabControlProjectSettings.DrawItem
        Const icon_width As Integer = 16
        Const icon_height As Integer = 16

        Dim g As Graphics = e.Graphics
        Dim tabControl As TabControl = DirectCast(sender, TabControl)
        Dim tabPage As TabPage = tabControl.TabPages(e.Index)
        Dim icon As Image = Nothing

        Dim sText As String
        Dim iX As Integer
        Dim iY As Integer
        Dim sizeText As SizeF

        If Not String.IsNullOrEmpty(tabPage.ImageKey) Then
            icon = tabControl.ImageList.Images(tabPage.ImageKey)
        End If

        sText = tabPage.Text
        sizeText = g.MeasureString(sText, tabControl.Font)

        iX = e.Bounds.Left + 6
        iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2

        If icon IsNot Nothing Then
            g.DrawImage(icon, iX, iY, icon_width, icon_height)
        End If

        g.DrawString(sText, tabControl.Font, Brushes.Black, iX + icon_width + 3, iY)
    End Sub

    Private Sub tabControlProjectSettings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabControlProjectSettings.SelectedIndexChanged
        If IsAny(tabControlProjectSettings.SelectedTab) Then
            Dim selectedPage As TabPage = tabControlProjectSettings.SelectedTab

            Select Case True
                Case selectedPage.Equals(tabProjectSettingsPageProject)
                    UcFiles1.Parent = tabProjectSettingsPageProjectTextsGroup

                Case selectedPage.Equals(tabProjectSettingsPageTexts)
                    UcFiles1.Parent = tabProjectSettingsPageTexts
            End Select
        End If
    End Sub

    Private Sub UFProjectTexts_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox("Do you really wish to CLOSE this project?", _
                  MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question, _
                  Me.ProjectName) = MsgBoxResult.Yes Then

            Me.SaveSettings()
            Form1.UnregisterProject(Me)

            UcFiles1.Clear()
            _AllComputedTexts.Clear()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub CacheSettings_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CacheSettings_rtbDisableCacheAtAll.CheckedChanged, CacheSettings_ChkCacheFreqTable.CheckedChanged, CacheSettings_ChkCacheTypes.CheckedChanged, CacheSettings_ChkCacheTokens.CheckedChanged, CacheSettings_rtbEnableCache.CheckedChanged
        CacheSettings_CacheGroup.Enabled = CacheSettings_rtbEnableCache.Checked
        CacheSettings_rtbDisableCacheAtAll.Checked = Not CacheSettings_rtbEnableCache.Checked
    End Sub

    Private Sub SaveSettings()
        My.Settings.LastUsedTokenizer = cmbTokenizer.Text
        My.Settings.LastUsedLemmatizer = cmbLemmatizer.Text
        My.Settings.LastUsedPOSTagger = cmbPOSTagger.Text
        My.Settings.LastUsedPostProcessor = cmbPostProcessor.Text

        My.Settings.CacheSettings_EnableCaching = CacheSettings_rtbEnableCache.Checked
        My.Settings.CacheSettings_CacheTokens = CacheSettings_ChkCacheTokens.Checked
        My.Settings.CacheSettings_CacheTypes = CacheSettings_ChkCacheTypes.Checked
        My.Settings.CacheSettings_CacheFreqTable = CacheSettings_ChkCacheFreqTable.Checked

        My.Settings.Files_RecentFiles = UcFiles1.GetFilesListInString()
    End Sub

    Private Sub ClearTemporarySettings()
        My.Settings.Last_NGramSize = 0
        My.Settings.Last_TextReduceSize = 0
    End Sub
#End Region

End Class