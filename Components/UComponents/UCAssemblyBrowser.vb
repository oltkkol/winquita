Imports QITA_OLTK.QITAInterfaces

Public Class UCAssemblyBrowser
    Private _ShowType As ShowType = ShowType.ShowLemmatizers
    Private _CheckedAllByDefault As Boolean = False
    Private _SingleSelection As Boolean = False
    Private _Initialized As Boolean = False
    Private _LinkedCombobox As ComboBox = Nothing

#Region "PUBLIC Properties"
    Public Enum ShowType
        ShowLemmatizers
        ShowTokenizers
        ShowPOSTaggers
        ShowIndexes
    End Enum

    Public Property ShowCheckBoxes() As Boolean
        Get
            Return lvIndexes.CheckBoxes
        End Get
        Set(ByVal value As Boolean)
            lvIndexes.CheckBoxes = value
        End Set
    End Property

    Public Property ShowAssemblies() As ShowType
        Get
            Return _ShowType
        End Get
        Set(ByVal value As ShowType)
            _ShowType = value

            lvIndexes.Items.Clear()
            lvIndexes.Columns.Clear()
            lvIndexes.Groups.Clear()

            Select Case value
                Case ShowType.ShowLemmatizers, ShowType.ShowTokenizers, ShowType.ShowPOSTaggers
                    lvIndexes.Columns.Add("Name", 140)
                    lvIndexes.Columns.Add("Description", 193)
                    lvIndexes.Columns.Add("Author", 77)

                    lvIndexes.Columns.Add("Plugin Requisites", 120)
                    lvIndexes.Columns.Add("Plugin Version", 80)
                    lvIndexes.Columns.Add("Plugin Author", 80)
                    lvIndexes.Columns.Add("Status", 95)

                    lvIndexes.Columns.Add("Score", "Reliability", 95)

                Case ShowType.ShowIndexes
                    lvIndexes.Columns.Add("Name", 112)
                    lvIndexes.Columns.Add("Short Name", 60)
                    lvIndexes.Columns.Add("Description", 108)
                    lvIndexes.Columns.Add("Comments", 95)
                    lvIndexes.Columns.Add("Author", 60)
            End Select
        End Set
    End Property

    Public Property CheckAllByDefault() As Boolean
        Get
            Return _CheckedAllByDefault
        End Get
        Set(ByVal value As Boolean)
            _CheckedAllByDefault = value

            CheckAll(value)
        End Set
    End Property

    Public Property SingleSelection() As Boolean
        Get
            Return _SingleSelection
        End Get
        Set(ByVal value As Boolean)
            _SingleSelection = value
        End Set
    End Property
#End Region

#Region "MAIN Subs"
    Private Sub InitControl()
        If Not _Initialized Then
            _Initialized = True

            Dim items As IEnumerable = Nothing
            Dim groups As New HashSet(Of String)

            '-- 1. Enumerate appropriate assemblies ---------------------------

            Select Case ShowAssemblies
                Case ShowType.ShowLemmatizers, ShowType.ShowPOSTaggers, ShowType.ShowTokenizers
                    items = Form1.AvailableMorphoAnalyzers
                Case ShowType.ShowIndexes
                    items = Form1.AvailableIndexes
            End Select

            For Each item In items
                Select Case True
                    Case TypeOf item Is IQITAIndex
                        groups.Add(ToUpper(DirectCast(item, IQITAIndex).IndexGroup))

                    Case TypeOf item Is IQITAMorphologyAnalyzer
                        groups.Add(ToUpper(DirectCast(item, IQITAMorphologyAnalyzer).AnalyzerTargetLanguage))
                End Select
            Next

            '-- 2. Create Groups assemblies groups  ---------------------------
            Dim sortedGroups As List(Of String) = groups.ToList()
            sortedGroups.Sort()

            Dim newGroup As ListViewGroup
            newGroup = New ListViewGroup("nongroup", "Un-grouped")

            For Each sGroupName As String In sortedGroups
                If StrIsAny(sGroupName) Then
                    sGroupName = sGroupName
                Else
                    sGroupName = "General"
                End If

                newGroup = New ListViewGroup(ToUpper(sGroupName), sGroupName)
                lvIndexes.Groups.Add(newGroup)
            Next

            '-- 3. Add Assemblies to ListView   -------------------------------

            For Each item In items
                Select Case True
                    Case TypeOf item Is IQITAIndex
                        Dim m As IQITAIndex = item

                        If Not m.IsSecondary Then
                            With lvIndexes.Items.Add(m.IndexName)
                                .Group = lvIndexes.Groups(ToUpper(m.IndexGroup))
                                .Tag = m

                                With .SubItems
                                    .Add(m.IndexShortName)
                                    .Add(m.IndexDescription)
                                    .Add(m.IndexComments)
                                    .Add("[See Help]") 'm.IndexAuthor)
                                End With
                            End With
                        End If

                    Case TypeOf item Is IQITAMorphologyAnalyzer
                        Dim m As IQITAMorphologyAnalyzer = item

                        Select Case ShowAssemblies
                            Case ShowType.ShowLemmatizers
                                If Not m.HasLemmatizationAbility Then
                                    Continue For
                                End If

                            Case ShowType.ShowPOSTaggers
                                If Not m.HasPosTaggingAbility Then
                                    Continue For
                                End If

                            Case ShowType.ShowTokenizers
                                If Not m.HasTokenizerAbility Then
                                    Continue For
                                End If
                        End Select

                        Dim sStatus As String = Nothing
                        With lvIndexes.Items.Add(m.AnalyzerName)
                            .Group = lvIndexes.Groups(ToUpper(m.AnalyzerTargetLanguage))
                            .Tag = m
                            .BackColor = BoolToOKOrErrorColor(m.CheckDependencies(sStatus))

                            With .SubItems
                                .Add(m.AnalyzerDescription)
                                .Add(m.AnalyzerAuthor)

                                .Add(m.PluginRequisites)
                                .Add(m.PluginVersion)
                                .Add(m.PluginAuthor)
                                .Add(sStatus)

                                .Add(m.AnalyzerScore)
                            End With
                        End With
                End Select
            Next

            If CheckAllByDefault Then
                CheckAll(True)
            End If
        End If
    End Sub

    Private Function GroupNameToGroup(ByVal sGroupName As String, ByRef translator As Dictionary(Of String, ListViewGroup))
        If StrIsAny(sGroupName) Then
            Return translator(sGroupName)
        Else
            Return "nongroup"
        End If
    End Function

    Private Function BoolToOKOrErrorColor(ByVal b As Boolean) As Color
        Return If(b, Color.White, Color.MistyRose)
    End Function

    Public Sub CheckAll(ByVal b As Boolean)
        _CheckingBulk = True
        For Each t As ListViewItem In lvIndexes.Items
            t.Checked = b
        Next
        _CheckingBulk = False
    End Sub

    Public Function GetCheckedItems(Of T)() As List(Of T)
        Dim out As New List(Of T)

        InitControl()

        For Each lvItem As ListViewItem In lvIndexes.Items
            If lvItem.Checked Then
                out.Add(DirectCast(lvItem.Tag, T))
            End If
        Next

        Return out
    End Function

    Public Function GetCheckedItem(Of T)() As T
        InitControl()

        If lvIndexes.CheckedItems.Count Then
            Return DirectCast(lvIndexes.CheckedItems(0).Tag, T)
        End If

        Return Nothing
    End Function

    Public Function GetCheckedItems() As IEnumerable
        Return GetCheckedItems(Of Object)()
    End Function

    Public Function GetCheckedItem() As Object
        Return GetCheckedItem(Of Object)()
    End Function

    Public Function SetCheckedItem(ByRef oAssemblyObject As Object) As Boolean
        CheckAll(False)

        If IsAny(oAssemblyObject) Then
            For Each l As ListViewItem In lvIndexes.Items
                If l.Tag.Equals(oAssemblyObject) Then
                    l.Checked = True
                End If
            Next
        End If
    End Function

    Public Function LinkWithCombobox(ByRef destination As ComboBox, _
                                           Optional ByVal bHasDefault As Boolean = False) As Boolean
        InitControl()
        _LinkedCombobox = destination

        destination.DropDownStyle = ComboBoxStyle.DropDownList
        AddHandler destination.SelectedIndexChanged, AddressOf LinkedCombobox_SelectedIndexChanged

        Select Case True
            Case TypeOf destination Is ComboBoxEx
                With DirectCast(destination, ComboBoxEx)
                    .ImageList = Me.imgFlags
                    .SelectFirstItem()

                    If Not bHasDefault Then
                        .AddItem("[Nothing]")
                    End If
                End With

            Case Else
                destination.SelectedIndex = 0

                If Not bHasDefault Then
                    destination.Items.Add(New GIComboBoxItem("[Nothing]", Nothing))
                End If
        End Select

        Dim o As Object
        Dim sText As String
        Dim sDescription As String
        Dim sPercentage As String
        Dim add As Boolean = True

        For Each l As ListViewItem In lvIndexes.Items
            Select Case True
                Case TypeOf destination Is ComboBoxEx
                    Dim destinationEx As ComboBoxEx = DirectCast(destination, ComboBoxEx)


                    If Not destinationEx.ContainsGroup(l.Group.Name) Then
                        destinationEx.AddGroup(l.Group.Name, Nothing, l.Group.Name & ".png")
                    End If

                    o = l.Tag
                    Select Case True
                        Case TypeOf o Is IQITAMorphologyAnalyzer
                            Dim analyzer As IQITAMorphologyAnalyzer = DirectCast(o, IQITAMorphologyAnalyzer)

                            sPercentage = Nothing

                            If analyzer.AnalyzerScore > 0 Then
                                sPercentage = "[" & Format(analyzer.AnalyzerScore, "###") & "%] " & vbTab
                            End If

                            sText = sPercentage & l.Text
                            sDescription = analyzer.AnalyzerDescription

                            add = analyzer.CheckDependencies(Nothing)
                        Case Else
                            sText = l.Text
                            sDescription = Nothing
                    End Select

                    If add Then
                        destinationEx.AddItem(sText, sDescription, l.Group.Name, l.Group.Name & ".png", l.Tag)
                    End If
                Case Else
                    destination.Items.Add(New GIComboBoxItem(l.Group.Name & ": " & l.Text, l.Tag))
            End Select
        Next

        Select Case True
            Case TypeOf destination Is ComboBoxEx
                With DirectCast(destination, ComboBoxEx)
                    .SortGroupsItemsAscendByText()
                    .SortGroupsAscendByText()
                    .SelectFirstItem()
                End With
            Case Else
                destination.SelectedIndex = 0
        End Select
    End Function

    Private Sub ActualizeLinkedCombobox(ByRef selectedAssembly As Object)
        If IsAny(_LinkedCombobox) Then
            If Not IsAny(selectedAssembly) Then
                _LinkedCombobox.SelectedIndex = 0
            Else
                For Each t As GIComboBoxItem In _LinkedCombobox.Items
                    If selectedAssembly.Equals(t.StoredObject) Then
                        _LinkedCombobox.SelectedItem = t
                        Exit Sub
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub LinkedCombobox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim selectedItem As GIComboBoxItem = DirectCast(sender, ComboBox).SelectedItem
        If selectedItem Is Nothing Then
            SetCheckedItem(Nothing)
        Else
            SetCheckedItem(selectedItem.StoredObject)
        End If
    End Sub
#End Region

#Region "CONTROL Subs"
    Private _CheckingBulk As Boolean = False

    Private Sub lvIndexes_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvIndexes.ColumnClick
        SortLV(lvIndexes, e)
    End Sub

    Private Sub lvIndexes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvIndexes.ItemCheck
        Static killing As Boolean = False

        If SingleSelection Then
            If killing Then Exit Sub

            killing = True
            _CheckingBulk = True
            For Each t As ListViewItem In lvIndexes.Items
                t.Checked = False
            Next

            _CheckingBulk = False
            killing = False
        End If
    End Sub

    Private Sub lvIndexes_ItemChecked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvIndexes.ItemChecked
        If Not _CheckingBulk Then
            ActualizeLinkedCombobox(Me.GetCheckedItem())
        End If
    End Sub

    Private Sub UCAssemblyBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitControl()
    End Sub
#End Region

    Private Sub lvIndexes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub y(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvIndexes.SelectedIndexChanged

    End Sub
End Class
