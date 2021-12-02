Imports QITA_OLTK.QITAInterfaces
Imports QITA_OLTK.QITADataTypes

Public Class UFNewChartWizard
    Private _DataSources As New HashSet(Of QITAProjectDataSource)
    Private _DataOutput As List(Of QITAChartableDataArray) = Nothing
    Private _ChartViewer As UFChartViewer = Nothing

#Region "DATA SOURCE And Output"
    ''' <summary>
    ''' Creates new Chart Wizard based on data from given project.
    ''' </summary>
    Public Sub New(ByRef dataSource As QITAProjectDataSource, Optional ByVal bDrawNow As Boolean = False)
        InitializeComponent()
        _DataSources.Add(dataSource)

        Dim columns As New List(Of WizardComboboxItem)
        columns.Add(New WizardComboboxItem(-1, "Text", Nothing))
        columns.Add(New WizardComboboxItem(-1, "Index of Text", Nothing))

        For Each index As IQITAIndex In dataSource.Project.ComputedIndexes
            columns.Add(New WizardComboboxItem(-1, index.IndexName, index))
        Next

        Me.PopulateCoordOptions(columns)
        Me.PopulateExistingCharts()
        Me.SetSerieName(dataSource.Project)

        If bDrawNow Then
            Me.DrawChart()
        End If
    End Sub

    Public ReadOnly Property OutputChartableArray() As List(Of QITAChartableDataArray)
        Get
            Return _DataOutput
        End Get
    End Property

    Public ReadOnly Property OutputChartViewer() As UFChartViewer
        Get
            Return _ChartViewer
        End Get
    End Property

    Public ReadOnly Property UseOnlySelectedRowsAsSource() As Boolean
        Get
            Return raUseOnlySelectedRowsAsSource.Checked
        End Get
    End Property

    Private ReadOnly Property ChartName() As String
        Get
            If Form1.ChartExistsWithName(txtChartName.Text) Then
                txtChartName.Text = txtChartName.Text & TimeOfDay.Ticks
            End If

            Return txtChartName.Text
        End Get
    End Property

    Private ReadOnly Property UseComplexStructure() As Boolean
        Get
            Return chkUseComplexStructure.Checked
        End Get
    End Property
#End Region

#Region "CHART Data GUI Setup"
    Private Sub PopulateExistingCharts()
        For Each f As UFChartViewer In Form1.ChartViewers
            cbExistingChart.Items.Add(New GIComboBoxItem(f.Text, f))
        Next
    End Sub

    Private Sub PopulateCoordOptions(ByRef columns As List(Of WizardComboboxItem))
        For Each c As WizardComboboxItem In columns
            Dim index As IQITAIndex = DirectCast(c.Tag, IQITAIndex)

            If IsAny(index) Then
                c.Description = index.IndexDescription

                cbX.AddItem(index.IndexName, index.IndexDescription, index.IndexGroup, Nothing, c)
                cbY.AddItem(index.IndexName, index.IndexDescription, index.IndexGroup, Nothing, c)
                cbDesc.AddItem(index.IndexName, index.IndexDescription, index.IndexGroup, Nothing, c)
            Else
                cbX.AddItem(c.Text, Nothing, Nothing, Nothing, c)
                cbY.AddItem(c.Text, Nothing, Nothing, Nothing, c)
                cbDesc.AddItem(c.Text, Nothing, Nothing, Nothing, c)
            End If
        Next

        SelectItemInComboBoxByText(cbX, My.Settings.NewChartWizard_LastXIndex)
        SelectItemInComboBoxByText(cbY, My.Settings.NewChartWizard_LastYIndex)
        SelectItemInComboBoxByText(cbDesc, My.Settings.NewChartWizard_LastZIndex)
    End Sub

    Private Sub SetSerieName(ByRef dataSource As IQITAProject)
        txtSerieName.Text = dataSource.ProjectName
    End Sub

    Private Sub DrawChart()
        SetWorking(Me, True)

        If ChartThisForAllProjects() Then
            For Each p As IQITAProject In Form1.Projects
                If Not IsAlreadyListedAsSource(p) Then
                    _DataSources.Add(p.DataSource)
                End If
            Next
        End If

        If CreateChartableDataOutput() Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
            MsgBox("Creation of data for charting failed.", MsgBoxStyle.Critical)
        End If

        SetWorking(Me, False)
        Me.Close()
    End Sub
#End Region

#Region "CHART Data New"
    Private Function GetXColumnIndex() As Integer
        Return GetColumnIndex(cbX)
    End Function

    Private Function GetYColumnIndex() As Integer
        Return GetColumnIndex(cbY)
    End Function

    Private Function GetDColumnIndex() As Integer
        Return GetColumnIndex(cbDesc)
    End Function

    Private Function GetColumnIndex(ByRef cbSourceComboBox As ComboBoxEx) As Integer
        If cbSourceComboBox.SelectedItem Is Nothing Then
            cbSourceComboBox.SelectFirstItem()
        End If

        If TypeOf cbSourceComboBox.SelectedItem Is WizardComboboxItem Then
            Return DirectCast(cbSourceComboBox.SelectedItem, WizardComboboxItem).ColumnIndex
        End If

        If TypeOf cbSourceComboBox.SelectedItem Is GIComboBoxItem Then
            Return DirectCast(DirectCast(cbSourceComboBox.SelectedItem, GIComboBoxItem).StoredObject, WizardComboboxItem).ColumnIndex
        End If

        Throw New Exception("Coordinate combobox does not contain appropriate data container!")

        Return -1
    End Function

    Private Function CreateChartableDataOutput() As Boolean
        If Me.UseComplexStructure Then
            _DataOutput = CreateChartableArrayFromComplexs()
        Else
            _DataOutput = CreateChartableArrayFromSimpleValues()
        End If

        _ChartViewer = GetSelectedChartViewer()

        If IsAny(_DataOutput) Then
            Return CBool(_DataOutput.Count)
        Else
            Return False
        End If
    End Function

    Private Function CreateChartableArrayFromComplexs() As List(Of QITAChartableDataArray)
        If CheckXColumnForComplexData() Then
            Dim storedResult As IQITAResult
            Dim dataContainer As IQITADataType
            Dim sourceIndex As String = cbX.Text
            Dim chartableData As QITAChartableDataArray
            Dim outChartableData As New List(Of QITAChartableDataArray)

            For Each dataSource As QITAProjectDataSource In _DataSources
                For Each Text As IQITAText In If(Me.UseOnlySelectedRowsAsSource, _
                                                  dataSource.Project.SelectedTexts, _
                                                  dataSource.Project.Texts)

                    storedResult = Text.GetResultByIndex(sourceIndex)
                    dataContainer = DirectCast(storedResult.ComplexValue(), IQITADataType)

                    chartableData = dataContainer.ToChartableData()
                    chartableData.DataTitle = Me.ChartName
                    chartableData.DataName = If(Me.ChartThisForAllProjects, dataSource.Project.ProjectName & " - ", "") & storedResult.TextReference.TextName
                    outChartableData.Add(chartableData)

                    Application.DoEvents()
                Next
            Next

            Return outChartableData
        End If

        Return Nothing
    End Function

    Private Function CreateChartableArrayFromSimpleValues() As List(Of QITAChartableDataArray)
        Dim x As Object = 0
        Dim y As Object = 0
        Dim d As String = Nothing
        Dim xIndex As String = Me.cbX.Text
        Dim yIndex As String = Me.cbY.Text
        Dim dIndex As String = Me.cbDesc.Text

        Dim data As QITAChartableDataArray
        Dim allData As New List(Of QITAChartableDataArray)

        For Each dataSource As QITAProjectDataSource In _DataSources
            data = New QITAChartableDataArray(cbX.Text, cbY.Text, cbDesc.Text)
            data.DataTitle = Me.ChartName
            data.DataName = GenerateSerieName(dataSource)

            If Me.UseOnlySelectedRowsAsSource Then
                data.SetRowsCount(dataSource.Project.SelectedTexts.Count)
            Else
                data.SetRowsCount(dataSource.Project.Texts.Count)
            End If

            Dim i As Integer = 0
            For Each Text As IQITAText In If(Me.UseOnlySelectedRowsAsSource, _
                                                dataSource.Project.SelectedTexts, _
                                                dataSource.Project.Texts)
                
                x = GetTextResultByIndexName(i, Text, xIndex)
                y = GetTextResultByIndexName(i, Text, yIndex)
                d = GetTextResultByIndexName(i, Text, dIndex)

                data.SetNextXYD(x, y, d)
                i += 1
            Next

            If data.Done() Then
                allData.Add(data)
            End If
        Next

        Return allData
    End Function
    Private Function GetTextResultByIndexName(ByVal iIndex As Integer, ByVal text As IQITAText, ByVal sIndexName As String) As Object
        Select Case sIndexName
            Case "Text"
                Return text.TextName
            Case "Index of Text"
                Return iIndex
            Case Else
                Return text.GetResultByIndex(sIndexName).Value
        End Select
    End Function

    Private Function GetSelectedChartViewer() As UFChartViewer
        If TypeOf cbExistingChart.SelectedItem Is GIComboBoxItem Then
            Return DirectCast(DirectCast(cbExistingChart.SelectedItem, GIComboBoxItem).StoredObject, UFChartViewer)
        Else
            Return Nothing
        End If
    End Function

    Private Sub CheckSerieNameCollision()
        Dim selectedChartViewer As UFChartViewer = GetSelectedChartViewer()

        If chkChartAllProjects.Checked Then
            txtSerieName.Text = ""
            Exit Sub
        End If

        If IsAny(selectedChartViewer) Then
            If Not Me.UseComplexStructure Then
                If selectedChartViewer.CheckIfSerieAlreadyExistsInChart(txtSerieName.Text) Then
                    SetErrorBox(txtSerieName, True)
                Else
                    SetErrorBox(txtSerieName, False)
                End If
            End If
        End If
    End Sub

    Private Sub EnableChartNaming()
        Dim selectedChartViewer As UFChartViewer = GetSelectedChartViewer()
        txtChartName.Enabled = Not IsAny(selectedChartViewer)
    End Sub

    Private Sub SetErrorBox(ByRef userInputControl As Control, ByVal bError As Boolean)
        txtSerieName.BackColor = If(bError, Color.Coral, Color.White)
        cmdOK.Enabled = Not bError
    End Sub
#End Region

#Region "GUI Actions"
    Private Sub SetChartName()
        If Not StrIsAny(CStr(txtChartName.Tag)) Then
            Dim sCoords As String = ": " & cbX.Text & If(Me.UseComplexStructure, Nothing, ", " & cbY.Text & ", " & cbDesc.Text)

            If ChartThisForAllProjects() Then
                txtChartName.Text = "MultiChart " & (Form1.ChartViewers.Count + 1) & sCoords
            Else
                txtChartName.Text = _DataSources(0).Project.ProjectName & sCoords
            End If
        End If
    End Sub

    Private Function GenerateSerieName(ByRef dataSource As QITAProjectDataSource) As String

        Dim s As String = ""
        s = If(Me.ChartThisForAllProjects, dataSource.Project.ProjectName, "")

        If StrIsAny(txtSerieName.Text) Then
            If StrIsAny(s) Then s += ": "

            s += txtSerieName.Text
        End If

        Return s
    End Function

    Private Function IsAlreadyListedAsSource(ByRef project As IQITAProject) As Boolean
        For Each d As QITAProjectDataSource In _DataSources
            If d.Project.Equals(project) Then Return True
        Next

        Return False
    End Function

    Private Sub cbX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbX.SelectedIndexChanged
        My.Settings.NewChartWizard_LastXIndex = cbX.Text

        CheckXColumnForComplexData()
        SetChartName()
    End Sub

    Private Sub cbY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbY.SelectedIndexChanged
        My.Settings.NewChartWizard_LastYIndex = cbY.Text
        SetChartName()
    End Sub

    Private Sub cbDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDesc.SelectedIndexChanged
        My.Settings.NewChartWizard_LastZIndex = cbDesc.Text
        SetChartName()
    End Sub

    Private Sub chkChartAllProjects_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChartAllProjects.CheckedChanged
        Static lastSerieName As String = txtSerieName.Text
        My.Settings.ChartForAllProjects = chkChartAllProjects.Checked

        grpSerieName.Enabled = Not chkChartAllProjects.Checked
        If chkChartAllProjects.Checked Then
            txtSerieName.Clear()
        Else
            txtSerieName.Text = lastSerieName
        End If

        SetChartName()
    End Sub

    Private Sub chkUseComplexStructure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseComplexStructure.CheckedChanged
        grpY.Enabled = Not chkUseComplexStructure.Checked
        grpDesc.Enabled = Not chkUseComplexStructure.Checked
        txtSerieName.Enabled = Not chkUseComplexStructure.Checked

        SetChartName()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.DrawChart()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UFNewChart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If _DataSources.Count Then
        '    txtChartName.Text = _DataSources(0).Project.ProjectName
        'Else
        '    txtChartName.Text = "Chart " & Form1.ChartViewers.Count + 1
        'End If

        chkChartAllProjects.Checked = My.Settings.ChartForAllProjects
    End Sub

    Private Sub txtSerieName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerieName.TextChanged
        CheckSerieNameCollision()
    End Sub

    Private Sub txtSerieName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSerieName.Validating
        CheckSerieNameCollision()
    End Sub

    Private Sub cbExistingChart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbExistingChart.SelectedIndexChanged
        EnableChartNaming()
        CheckSerieNameCollision()
        SetChartName()
    End Sub

    Private Sub raUseAllRowsAsSource_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles raUseAllRowsAsSource.CheckedChanged
        Static normalStyleFont As Font = New Font(raUseAllRowsAsSource.Font, Nothing)
        Static boldStyleFont As Font = New Font(raUseAllRowsAsSource.Font, FontStyle.Bold)

        If raUseAllRowsAsSource.Checked Then
            raUseAllRowsAsSource.Font = boldStyleFont
            raUseOnlySelectedRowsAsSource.Font = normalStyleFont
        Else
            raUseAllRowsAsSource.Font = normalStyleFont
            raUseOnlySelectedRowsAsSource.Font = boldStyleFont
        End If
    End Sub
#End Region

#Region "CHART Source Data"
    Private Function CheckXColumnForComplexData() As Boolean
        Dim sourceIndex As String = cbX.Text
        Dim result As IQITAResult = Nothing
        Dim sResultValue As String = Nothing
        chkUseComplexStructure.Enabled = False

        For Each dataSource As QITAProjectDataSource In _DataSources
            result = dataSource.Project.Texts(0).GetResultByIndex(sourceIndex)
            If IsAny(result) AndAlso (TypeOf result.ComplexValue Is IQITADataType) Then
                sResultValue = result.ToCellString()

                If result.IsComplex Then
                    If sResultValue = "[...]" Then
                        chkUseComplexStructure.Checked = True
                        chkUseComplexStructure.Enabled = False
                    Else
                        chkUseComplexStructure.Enabled = True
                    End If
                End If
            Else
                chkUseComplexStructure.Checked = False
                chkUseComplexStructure.Enabled = False
            End If
        Next

        Return Me.UseComplexStructure
    End Function

    Private Function ChartThisForAllProjects() As Boolean
        Return chkChartAllProjects.Checked
    End Function
#End Region

#Region "Helper Class"
    Private Class WizardComboboxItem
        Inherits GIComboBoxItem

        Private _Index As Integer
        Private _Text As String
        Private _Tag As Object

        Public Sub New(ByVal index As Integer, ByVal text As String, ByRef tag As Object)
            MyBase.New(text, Nothing, Nothing, Nothing)

            _Index = index
            _Text = text

            Me.Tag = tag
        End Sub

        Public ReadOnly Property ColumnIndex() As Integer
            Get
                Return _Index
            End Get
        End Property

        Public Property Tag() As Object
            Get
                Return _Tag
            End Get
            Set(ByVal value As Object)
                _Tag = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return _Text
        End Function
    End Class
#End Region
End Class