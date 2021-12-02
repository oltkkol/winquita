Option Strict On
Imports System.ComponentModel

'!!!    THIS IS PAID AND COPYRIGHTED CODE, READ FUTHER PLEASE   !!!!!!!!!!!!!!!!!!!!!!!!!
'   This code is licensed.
'   Groups & Images ComboBox Extended (2013), version: 16.9.2013

'
'   LICENCE:
'           You can: - modify this code,
'                    - use this code in your software,
'                    - compile this code and use binaries in your software.
'
'           You cannot: - sell, lend or distribute this source code,
'                       - sell, lend or distribute derived component.
'
'   http://dotNetComponents.lodusweb.net
'!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

<Browsable(True), Serializable()> _
Public Class ComboBoxEx
    Inherits ComboBox
    Private NO_GROUP As String = "__00_[_NO_GROUPUSED$_!]"

    Private _ImageList As ImageList = Nothing
    Private _DisplayImagesForAllItems As Boolean = True
    Private _DisplayEmptyGroups As Boolean = False
    Private _DisplayDescriptions As Boolean = True
    Private _HideSelectedItemWhenControlDisabled As Boolean = False
    Private _DisplayPrependedSpace As Boolean = True
    Private _DisplayGroupsHeaders As Boolean = True
    Private _DisplaySelectedItemImage As Boolean = True
    Private _DisplayGroupHeadersImages As Boolean = True

    Private _GroupHeaderBackBrush As Brush = New SolidBrush(Color.FromArgb(187, 195, 204))
    Private _DescriptionFontColor As Brush = Brushes.DarkGray
    Private _DescriptionFontColorInGroupHeader As Brush = Brushes.DarkGray

    Private _GroupsDisplayComplexSubItemsList As New Dictionary(Of String, List(Of GIComboBoxItem))
    Private _GroupsHeaders As New Dictionary(Of String, GIComboBoxGroupHeader)

#Region ":: PUBLIC Properties"
    Private Shadows Property DrawMode() As DrawMode
        Get
            Return MyBase.DrawMode
        End Get
        Set(ByVal value As DrawMode)
            MyBase.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets image list used by GIComboBoxEx.
    ''' </summary>
    <Description("ImageList for images. Images are matched by Name.")> _
    Public Property ImageList() As ImageList
        Get
            Return _ImageList
        End Get
        Set(ByVal ListaImagem As ImageList)
            _ImageList = ListaImagem

            If _ImageList IsNot Nothing Then
                MyBase.ItemHeight = Math.Max(_ImageList.ImageSize.Height, MyBase.ItemHeight)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets wheter images are displayed for sub-items (non group headers).
    ''' </summary>
    <Description("Sets wheter images are displayed for sub-items (non group headers).")> _
    Public Property DisplayImagesForAllItems() As Boolean
        Get
            Return _DisplayImagesForAllItems
        End Get
        Set(ByVal value As Boolean)
            _DisplayImagesForAllItems = value
            Me.Refresh()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets wheter groups headers will be displayed or not.
    ''' </summary>
    <Description("Sets wheter groups headers will be displayed or not.")> _
    Public Property DisplayGroupsHeaders() As Boolean
        Get
            Return _DisplayGroupsHeaders
        End Get
        Set(ByVal value As Boolean)
            _DisplayGroupsHeaders = value
            ReList()
        End Set
    End Property

    ''' <summary>
    ''' Retreives StoredObject of currently selected item.
    ''' </summary>
    ''' <remarks>When no item is selected, Nothing is returned.</remarks>
    Public ReadOnly Property SelectedStoredObject() As Object
        Get
            Return Me.GetSelectedStoredObject()
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets whether headers of empty groups will be displayed or not.
    ''' </summary>
    ''' <remarks>Defaultly set to False.</remarks>
    <Description("Sets whether headers of empty groups will be displayed or not.")> _
    Public Property DisplayEmptyGroups() As Boolean
        Get
            Return _DisplayEmptyGroups
        End Get
        Set(ByVal value As Boolean)
            _DisplayEmptyGroups = value
            ReList()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets whether items will be prepended by space.
    ''' </summary>
    <Description("Sets whether items will be prepended by space.")> _
    Public Property DisplayPrependedSpace() As Boolean
        Get
            Return _DisplayPrependedSpace
        End Get
        Set(ByVal value As Boolean)
            _DisplayPrependedSpace = value
            Me.Refresh()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets whether descriptions are displayed or not.
    ''' </summary>
    ''' <remarks>Set to True by default.</remarks>
    <Description("Sets whether descriptions of items are displayed or not.")> _
    Public Property DisplayDescriptions() As Boolean
        Get
            Return _DisplayDescriptions
        End Get
        Set(ByVal value As Boolean)
            _DisplayDescriptions = value
            Me.Refresh()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets whether image will be displayed for selected item or not.
    ''' </summary>
    <Description("Sets whether image will be displayed for selected item or not.")> _
    Public Property DisplaySelectedItemImage() As Boolean
        Get
            Return _DisplaySelectedItemImage
        End Get
        Set(ByVal value As Boolean)
            _DisplaySelectedItemImage = value
            Me.Refresh()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets whether images in group headers will be displayed or not.
    ''' </summary>
    <Description("Sets whether images in group headers will be displayed or not.")> _
    Public Property DisplayGroupHeadersImage() As Boolean
        Get
            Return _DisplayGroupHeadersImages
        End Get
        Set(ByVal value As Boolean)
            _DisplayGroupHeadersImages = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets group header background color.
    ''' </summary>
    <Description("Background color of group headers.")> _
    Public Property GroupHeaderBackColor() As Color
        Get
            Using p As New Pen(Me._GroupHeaderBackBrush)
                Return p.Color
            End Using
        End Get
        Set(ByVal value As Color)
            _GroupHeaderBackBrush = New SolidBrush(value)
            Me.Refresh()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets fore color of descriptions.
    ''' </summary>
    <Description("Fore color of descriptions.")> _
    Public Property ForeColorDescription() As Color
        Get
            Using p As New Pen(Me._DescriptionFontColor)
                Return p.Color
            End Using
        End Get
        Set(ByVal value As Color)
            _DescriptionFontColor = New SolidBrush(value)
            Me.Refresh()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets fore color of descriptions in group headers.
    ''' </summary>
    <Description("Fore color of descriptions in group headers.")> _
    Public Property ForeColorDescriptionInGroupHeaders() As Color
        Get
            Using p As New Pen(Me._DescriptionFontColorInGroupHeader)
                Return p.Color
            End Using
        End Get
        Set(ByVal value As Color)
            _DescriptionFontColorInGroupHeader = New SolidBrush(value)
            Me.Refresh()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets whether the selected item is visible or not while the control is disabled.
    ''' This helps to make it more cleaner for user that "really no data from this control will be used".
    ''' </summary>
    <Description("Sets whether the selected item is visible or not while the control is disabled.")> _
    Public Property HideSelectedItemWhenControlDisabled() As Boolean
        Get
            Return _HideSelectedItemWhenControlDisabled
        End Get
        Set(ByVal value As Boolean)
            _HideSelectedItemWhenControlDisabled = value
            Me.Refresh()
        End Set
    End Property

    Public Shadows Property SelectedItem() As GIComboBoxItem
        Get
            Return DirectCast(MyBase.SelectedItem, GIComboBoxItem)
        End Get
        Set(ByVal value As GIComboBoxItem)
            MyBase.SelectedItem = value
        End Set
    End Property

    ''' <summary>
    ''' Read-only list of all items contained in Combobox.
    ''' </summary>
    <Description("Read-only list of items contained in Combobox.")> _
    Public ReadOnly Property AllItems() As List(Of GIComboBoxItem)
        Get
            Dim l As New List(Of GIComboBoxItem)

            For Each group As String In _GroupsDisplayComplexSubItemsList.Keys
                l.Add(_GroupsHeaders(group))

                For Each item As GIComboBoxItem In _GroupsDisplayComplexSubItemsList(group)
                    l.Add(item)
                Next
            Next

            Return l
        End Get
    End Property

    ''' <summary>
    ''' Read-only list of displayed items contained in Combobox. Editing Combobox content is available
    ''' only programmatically.
    ''' </summary>
    <Description("Read-only list of displayed items contained in Combobox.")> _
    Public Shadows ReadOnly Property Items() As List(Of GIComboBoxItem)
        Get
            Dim l As New List(Of GIComboBoxItem)

            For Each t As GIComboBoxItem In MyBase.Items
                l.Add(t)
            Next

            Return l
        End Get
    End Property
#End Region

#Region ":: PUBLIC Functions"
    Public Sub New()
        Me.DrawMode = DrawMode.OwnerDrawFixed
    End Sub

    Private Sub CB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Right) OrElse (e.KeyCode = Keys.Down) Then
            Me.SelectNextItem()
            e.Handled = True
            Exit Sub
        End If

        If (e.KeyCode = Keys.Left) OrElse (e.KeyCode = Keys.Up) Then
            Me.SelectPreviousItem()
            e.Handled = True
            Exit Sub
        End If
    End Sub

    ''' <summary>
    ''' Adds a new Group header.
    ''' </summary>
    ''' <param name="sGroupName">Name of group.</param>
    ''' <returns>Combobox group header.</returns>
    Public Function AddGroup(ByVal sGroupName As String) As GIComboBoxGroupHeader
        Return Me.AddGroup(sGroupName, Nothing, Nothing)
    End Function

    ''' <summary>
    ''' Adds a new Group header.
    ''' </summary>
    ''' <param name="sGroupName">Name of group.</param>
    ''' <param name="sDescription">Group description.</param>
    ''' <param name="sImageKey">Image key of group.</param>
    ''' <returns>Combobox group header.</returns>
    Public Function AddGroup(ByVal sGroupName As String, _
                                      ByVal sDescription As String, _
                                      ByVal sImageKey As String) As GIComboBoxGroupHeader
        Return Me.AddGroup(New GIComboBoxGroupHeader(sGroupName, sDescription, sImageKey))
    End Function

    ''' <summary>
    ''' Adds a new Group header.
    ''' </summary>
    Public Function AddGroup(ByRef groupHeader As GIComboBoxGroupHeader) As GIComboBoxGroupHeader
        If groupHeader IsNot Nothing Then
            AddHandler groupHeader.ItemVisibilityChanged, AddressOf ItemVisibilityChanged

            If Not _GroupsDisplayComplexSubItemsList.ContainsKey(groupHeader.Text) Then
                _GroupsDisplayComplexSubItemsList.Add(groupHeader.Text, New List(Of GIComboBoxItem))
                _GroupsHeaders.Add(groupHeader.Text, groupHeader)
            End If

            Return groupHeader
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Adds a new item into the GIComboboxEx without affiliating it with any group.
    ''' </summary>
    ''' <param name="sText">Text.</param>
    ''' <returns>Added item.</returns>
    Public Function AddItem(ByVal sText As String) As GIComboBoxItem
        Return Me.AddItem(sText, Nothing, NO_GROUP, Nothing, Nothing)
    End Function

    ''' <summary>
    ''' Adds a new item into the GIComboBoxEx.
    ''' </summary>
    ''' <param name="sText">Text to display.</param>
    ''' <param name="sDescription">Description of item.</param>
    ''' <param name="sGroupName">Name of group.</param>
    ''' <returns>Added item.</returns>
    ''' <remarks>When non-existing group name is supplied, GIComboboxEx will create it with the same image and null description.
    ''' Image info is inherited from Group.</remarks>
    Public Function AddItem(ByVal sText As String, ByVal sDescription As String, ByVal sGroupName As String) As GIComboBoxItem
        Return Me.AddItem(sText, sDescription, Me.GetGroupHeader(sGroupName))
    End Function

    ''' <summary>
    ''' Adds a new item into the GIComboBoxEx.
    ''' </summary>
    ''' <param name="sText">Text to display.</param>
    ''' <param name="sDescription">Description of item.</param>
    ''' <param name="groupHeader">Group.</param>
    ''' <returns>Added item.</returns>
    ''' <remarks>When non-existing group name is supplied, GIComboboxEx will create it with the same image and null description.
    ''' Image info is inherited from Group.</remarks>
    Public Function AddItem(ByVal sText As String, ByVal sDescription As String, ByVal groupHeader As GIComboBoxGroupHeader) As GIComboBoxItem
        If groupHeader Is Nothing Then
            Return Me.AddItem(sText, sDescription, Nothing, Nothing, Nothing)
        Else
            Return Me.AddItem(sText, sDescription, groupHeader.Text, groupHeader.ImageKey, Nothing)
        End If
    End Function

    ''' <summary>
    ''' Adds a new item into the GIComboboxEx without affilating it with any group.
    ''' </summary>
    ''' <param name="sText">Text.</param>
    ''' <returns>Added item.</returns>
    Public Function AddItem(ByVal sText As String, ByVal sImageKey As String, ByRef oStoreObject As Object) As GIComboBoxItem
        Return Me.AddItem(sText, Nothing, Nothing, sImageKey, oStoreObject)
    End Function

    ''' <summary>
    ''' Adds a new item into the GIComboboxEx without affilating it with any group.
    ''' </summary>
    ''' <param name="sText">Text.</param>
    ''' <returns>Added item.</returns>
    Public Function AddItem(ByVal sText As String, ByVal sImageKey As String) As GIComboBoxItem
        Return Me.AddItem(sText, Nothing, Nothing, sImageKey, Nothing)
    End Function

    ''' <summary>
    ''' Adds a new item into the GIComboBoxEx.
    ''' </summary>
    ''' <param name="sText">Text to display.</param>
    ''' <param name="sDescription">Description of item.</param>
    ''' <param name="sGroupName">Name of group.</param>
    ''' <param name="sImageKey">Name of Image.</param>
    ''' <returns>Added item.</returns>
    ''' <remarks>When non-existing group name is supplied, GIComboboxEx will create it with the same Image and null description.</remarks>
    Public Function AddItem(ByVal sText As String, _
                           ByVal sDescription As String, _
                           ByVal sGroupName As String, _
                           ByVal sImageKey As String) As GIComboBoxItem
        Return Me.AddItem(sText, sDescription, sGroupName, sImageKey, Nothing)
    End Function

    ''' <summary>
    ''' Adds a new item into the GIComboBoxEx.
    ''' </summary>
    ''' <param name="sText">Text to display.</param>
    ''' <param name="sDescription">Description of item.</param>
    ''' <param name="sGroupName">Name of group.</param>
    ''' <param name="sImageKey">Name of Image.</param>
    ''' <param name="oStoreObject">Object to be stored.</param>
    ''' <returns>Added item.</returns>
    ''' <remarks>When non-existing group name is supplied, GIComboboxEx will create it with the same Image and null description.</remarks>
    Public Function AddItem(ByVal sText As String, _
                               ByVal sDescription As String, _
                               ByVal sGroupName As String, _
                               ByVal sImageKey As String, _
                               ByRef oStoreObject As Object) As GIComboBoxItem

        Dim t As New GIComboBoxItem(sText, sDescription, sGroupName, sImageKey, oStoreObject)
        Return Me.AddItem(t)
    End Function

    ''' <summary>
    ''' Adds a new item into the GIComboboxEx.
    ''' </summary>
    Public Function AddItem(ByVal item As GIComboBoxItem) As GIComboBoxItem
        If TypeOf item Is GIComboBoxGroupHeader Then
            Return Me.AddGroup(DirectCast(item, GIComboBoxGroupHeader))
        End If

        AddHandler item.ItemVisibilityChanged, AddressOf ItemVisibilityChanged

        Dim sGroupName As String = item.GroupName

        If String.IsNullOrEmpty(sGroupName) Then
            sGroupName = NO_GROUP
        End If

        If Not _GroupsDisplayComplexSubItemsList.ContainsKey(sGroupName) Then
            Me.AddGroup(sGroupName, Nothing, item.ImageKey)
        End If

        _GroupsDisplayComplexSubItemsList(sGroupName).Add(item)
        ReList()

        Return item
    End Function

    ''' <summary>
    ''' Adds a new image item.
    ''' </summary>
    ''' <param name="sImageKey">Key of image.</param>
    ''' <param name="sGroupName">Group name.</param>
    ''' <returns>Added GIComboBoxItem.</returns>
    Public Function AddItemImage(ByVal sImageKey As String, ByVal sGroupName As String) As GIComboBoxItem
        Return Me.AddItem("", Nothing, sGroupName, sImageKey, Nothing)
    End Function

    Private Sub ItemVisibilityChanged()
        ReList()
    End Sub

    Private Sub ReList()
        MyBase.Items.Clear()
        Dim lastSelectedItem As GIComboBoxItem = Me.SelectedItem

        For Each groupName As String In _GroupsDisplayComplexSubItemsList.Keys
            If _GroupsHeaders(groupName).Visible Then
                If Me.DisplayGroupsHeaders Then
                    If Not Me.DisplayEmptyGroups Then
                        If _GroupsDisplayComplexSubItemsList(groupName).Count = 0 Then
                            Continue For
                        End If
                    End If

                    If groupName <> NO_GROUP Then
                        MyBase.Items.Add(_GroupsHeaders(groupName))
                    End If
                End If

                For Each subItem As GIComboBoxItem In _GroupsDisplayComplexSubItemsList(groupName)
                    If subItem.Visible Then
                        MyBase.Items.Add(subItem)
                    End If
                Next
            End If
        Next

        If lastSelectedItem IsNot Nothing Then
            If MyBase.Items.Contains(lastSelectedItem) Then
                MyBase.SelectedItem = lastSelectedItem
            End If
        End If
    End Sub

    ''' <summary>
    ''' Tests given group whether it is contained in GIComboboxEx or not.
    ''' </summary>
    ''' <param name="groupHeader">Group to test.</param>
    ''' <returns>TRUE when exists.</returns>
    Public Function ContainsGroup(ByVal groupHeader As GIComboBoxGroupHeader) As Boolean
        If groupHeader IsNot Nothing Then
            Return Me.ContainsGroup(groupHeader.Text)
        Else
            Return Me.ContainsGroup(NO_GROUP)
        End If
    End Function

    ''' <summary>
    ''' Tests given group name whether it is contained in GIComboboxEx or not.
    ''' </summary>
    ''' <param name="sGroupName">Group name to test.</param>
    ''' <returns>TRUE when exists.</returns>
    Public Function ContainsGroup(ByVal sGroupName As String) As Boolean
        Return _GroupsHeaders.ContainsKey(sGroupName)
    End Function

    ''' <summary>
    ''' Retreives StoredObject of currently selected item.
    ''' </summary>
    ''' <returns>Stored object.</returns>
    Public Function GetSelectedStoredObject() As Object
        Dim t As Object = Me.SelectedItem

        If t IsNot Nothing Then
            Return DirectCast(t, GIComboBoxItem).StoredObject
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Retreives all group headers.
    ''' </summary>
    ''' <returns>List of group headers.</returns>
    Public Function GetGroupHeaders() As IEnumerable(Of GIComboBoxGroupHeader)
        Return _GroupsHeaders.Values.ToList()
    End Function

    ''' <summary>
    ''' Retreives group header for given group.
    ''' </summary>
    Public Function GetGroupHeader(ByVal sGroupName As String) As GIComboBoxGroupHeader
        If Me.ContainsGroup(sGroupName) Then
            Return _GroupsHeaders(sGroupName)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Retreives all items affiliated within given group.
    ''' </summary>
    ''' <param name="sGroupName">Name of group.</param>
    ''' <returns>List of items within given group.</returns>
    ''' <remarks>When supplied group does not exist, Nothing is returned.</remarks>
    Public Function GetGroupItems(ByVal sGroupName As String) As IEnumerable(Of GIComboBoxItem)
        If Me.ContainsGroup(sGroupName) Then
            Return _GroupsDisplayComplexSubItemsList(sGroupName).ToList()
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Finds first item matching given sItemText (except Group headers).
    ''' </summary>
    ''' <returns>Found GIComboBoxItem. Returns Nothing when nothing found.</returns>
    Public Function GetItem(ByVal sItemText As String) As GIComboBoxItem
        For Each group As String In _GroupsHeaders.Keys
            For Each item As GIComboBoxItem In _GroupsDisplayComplexSubItemsList(group)
                If item.Text = sItemText Then
                    Return item
                End If
            Next
        Next

        Return Nothing
    End Function

    ''' <summary>
    ''' Sets whether whole group is visible or not.
    ''' </summary>
    ''' <param name="sGroupName">Name of group.</param>
    ''' <param name="bVisible">TRUE for visible, FALSE for hidden.</param>
    ''' <returns>TRUE when visiblity successfully set.</returns>
    Public Function SetGroupVisibility(ByVal sGroupName As String, ByVal bVisible As Boolean) As Boolean
        If Me.ContainsGroup(sGroupName) Then
            _GroupsHeaders(sGroupName).Visible = bVisible
            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' Selects first non-group-header item in item list.
    ''' </summary>
    Public Sub SelectFirstItem()
        For i As Integer = 0 To MyBase.Items.Count - 1
            If Not (TypeOf MyBase.Items(i) Is GIComboBoxGroupHeader) Then
                Me.SelectedIndex = i
                Exit Sub
            End If
        Next
    End Sub

    ''' <summary>
    ''' Selects first item in given group.
    ''' </summary>
    Public Sub SelectFirstItemFromGroup(ByVal group As GIComboBoxGroupHeader)
        If group IsNot Nothing Then
            Me.SelectFirstItemFromGroup(group.Text)
        Else
            Me.SelectFirstItem()
        End If
    End Sub

    ''' <summary>
    ''' Selects first item in given group.
    ''' </summary>
    ''' <param name="sGroupName">Name of group.</param>
    Public Sub SelectFirstItemFromGroup(ByVal sGroupName As String)
        If Me.ContainsGroup(sGroupName) Then
            If CBool(_GroupsDisplayComplexSubItemsList(sGroupName).Count) Then
                MyBase.SelectedItem = _GroupsDisplayComplexSubItemsList(sGroupName).First()
                Exit Sub
            End If
        End If

        Me.SelectFirstItem()
    End Sub

    ''' <summary>
    ''' Selects next non-header item.
    ''' </summary>
    ''' <returns>Newly selected item index.</returns>
    Public Function SelectNextItem() As Integer
        Dim i As Integer = MyBase.SelectedIndex + 1

        Do While (i < MyBase.Items.Count)
            If TypeOf MyBase.Items(i) Is GIComboBoxGroupHeader Then
                i += 1
            Else
                MyBase.SelectedItem = MyBase.Items(i)
                Exit Do
            End If
        Loop

        Return i
    End Function

    ''' <summary>
    ''' Selects previous non-header item.
    ''' </summary>
    ''' <returns>Newly selected item index.</returns>
    Public Function SelectPreviousItem() As Integer
        Dim i As Integer = MyBase.SelectedIndex - 1

        Do While (i > -1)
            If TypeOf MyBase.Items(i) Is GIComboBoxGroupHeader Then
                i -= 1
            Else
                MyBase.SelectedItem = MyBase.Items(i)
                Exit Do
            End If
        Loop

        Return i
    End Function

    ''' <summary>
    ''' Removes given item.
    ''' </summary>
    ''' <param name="item">Item to remove.</param>
    ''' <returns>TRUE when item has been successfully removed.</returns>
    ''' <remarks>If ComboBoxGroupHeader class is passed as item, whole group is removed.</remarks>
    Public Function RemoveItem(ByRef item As GIComboBoxItem) As Boolean
        If TypeOf item Is GIComboBoxGroupHeader Then
            Return Me.RemoveGroup(DirectCast(item, GIComboBoxGroupHeader))
        End If

        Dim removed As Boolean = False

        For Each group As String In _GroupsDisplayComplexSubItemsList.Keys
            If _GroupsDisplayComplexSubItemsList(group).Contains(item) Then
                _GroupsDisplayComplexSubItemsList(group).Remove(item)

                RemoveItemHandlers(item)
                removed = True
                Exit For
            End If
        Next

        If removed Then
            Me.ReList()
        End If

        Return removed
    End Function

    ''' <summary>
    ''' Removes item whichs users stored object equals with passed parameter.
    ''' </summary>
    ''' <returns>TRUE when removed successfully, otherwise FALSE.</returns>
    Public Function RemoveItemByStoredObject(ByRef oStoredObject As Object) As Boolean
        Dim toRemove As GIComboBoxItem = Nothing

        For Each t As GIComboBoxItem In MyBase.Items
            If TypeOf t Is GIComboBoxItem Then
                If t.StoredObject.Equals(oStoredObject) Then
                    toRemove = DirectCast(t, GIComboBoxItem)
                    Exit For
                End If
            End If
        Next

        If toRemove IsNot Nothing Then
            Me.RemoveItem(toRemove)
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Removes whole group.
    ''' </summary>
    ''' <param name="sGroupName">Name of group to remove.</param>
    ''' <returns>TRUE when group has been successfully removed.</returns>
    Public Function RemoveGroup(ByVal sGroupName As String) As Boolean
        If Me.ContainsGroup(sGroupName) Then
            Dim group As GIComboBoxGroupHeader = _GroupsHeaders(sGroupName)

            Return Me.RemoveGroup(group)
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Removes whole group.
    ''' </summary>
    ''' <param name="groupHeaderItem">Group to remove.</param>
    ''' <returns>TRUE when group has been successfully removed.</returns>
    Public Function RemoveGroup(ByRef groupHeaderItem As GIComboBoxGroupHeader) As Boolean
        If Me.ContainsGroup(groupHeaderItem.Text) Then
            RemoveItemHandlers(_GroupsHeaders(groupHeaderItem.Text))

            For Each item As GIComboBoxItem In _GroupsDisplayComplexSubItemsList(groupHeaderItem.Text)
                RemoveItemHandlers(item)
            Next

            _GroupsDisplayComplexSubItemsList.Remove(groupHeaderItem.Text)
            _GroupsHeaders.Remove(groupHeaderItem.Text)

            Me.ReList()
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub RemoveItemHandlers(ByVal item As GIComboBoxItem)
        RemoveHandler item.ItemVisibilityChanged, AddressOf ItemVisibilityChanged
    End Sub

    ''' <summary>
    ''' Removes all items and groups.
    ''' </summary>
    Public Sub Clear()
        For Each group As String In _GroupsHeaders.Keys
            Me.RemoveGroup(group)
        Next

        _GroupsHeaders.Clear()
        _GroupsDisplayComplexSubItemsList.Clear()
        Me.ReList()
    End Sub
#End Region

#Region ":: PUBLIC Functions: SORTING"
    ''' <summary>
    ''' Sorts all items in all groups by given comparer function.
    ''' </summary>
    ''' <param name="comparerFunction">Comparer function.</param>
    Public Sub SortGroupsItems(ByVal comparerFunction As Comparison(Of GIComboBoxItem))
        For Each group As String In _GroupsDisplayComplexSubItemsList.Keys
            SortGroupsItems(group, comparerFunction)
        Next
    End Sub

    ''' <summary>
    ''' Sorts all items of given group by given comparer function.
    ''' </summary>
    ''' <param name="sGroupName">Name of group to be sorted.</param>
    ''' <param name="compareFunction">Comparer function.</param>
    Public Sub SortGroupsItems(ByVal sGroupName As String, _
                                ByVal compareFunction As Comparison(Of GIComboBoxItem))
        If Me.ContainsGroup(sGroupName) Then
            _GroupsDisplayComplexSubItemsList(sGroupName).Sort(compareFunction)
        End If

        Me.ReList()
    End Sub

    ''' <summary>
    ''' Sorts all items of given group ascending by items Text.
    ''' </summary>
    Public Sub SortGroupsItemsAscendByText(ByVal sGroupName As String)
        Me.SortGroupsItems(sGroupName, Function(a As GIComboBoxItem, b As GIComboBoxItem) _
                                        (a.Text.CompareTo(b.Text)))
    End Sub

    ''' <summary>
    ''' Sorts all items of given group descending by items Text.
    ''' </summary>
    Public Sub SortGroupsItemsDescByText(ByVal sGroupName As String)
        Me.SortGroupsItems(sGroupName, Function(a As GIComboBoxItem, b As GIComboBoxItem) _
                                        (b.Text.CompareTo(a.Text)))
    End Sub

    ''' <summary>
    ''' Sorts all items of all groups ascending by items Text.
    ''' </summary>
    Public Sub SortGroupsItemsAscendByText()
        For Each group As String In _GroupsHeaders.Keys
            Me.SortGroupsItemsAscendByText(group)
        Next
    End Sub

    ''' <summary>
    ''' Sorts all items of all groups descending by items Text.
    ''' </summary>
    Public Sub SortGroupsItemsDescByText()
        For Each group As String In _GroupsHeaders.Keys
            Me.SortGroupsItemsDescByText(group)
        Next
    End Sub

    Private Sub SortGroupsDone(ByRef sortedGroupsList As List(Of KeyValuePair(Of String, List(Of GIComboBoxItem))))
        _GroupsDisplayComplexSubItemsList = _
            sortedGroupsList.ToDictionary(Of String, List(Of GIComboBoxItem)) _
                                            (Function(keyPair As KeyValuePair(Of String, List(Of GIComboBoxItem))) keyPair.Key, _
                                             Function(valuePair As KeyValuePair(Of String, List(Of GIComboBoxItem))) valuePair.Value)

        Me.ReList()
    End Sub

    ''' <summary>
    ''' Sorts groups by their header text: ascendent.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SortGroupsAscendByText()
        Dim groups As List(Of KeyValuePair(Of String, List(Of GIComboBoxItem))) = _GroupsDisplayComplexSubItemsList.ToList()

        groups.Sort(Function(a As KeyValuePair(Of String, List(Of GIComboBoxItem)), _
                                b As KeyValuePair(Of String, List(Of GIComboBoxItem))) _
                                (a.Key.CompareTo(b.Key)))

        SortGroupsDone(groups)
    End Sub

    ''' <summary>
    ''' Sorts groups by their header text: descendent.
    ''' </summary>
    Public Sub SortGroupsDescendByText()
        Dim groups As List(Of KeyValuePair(Of String, List(Of GIComboBoxItem))) = _GroupsDisplayComplexSubItemsList.ToList()

        groups.Sort(Function(a As KeyValuePair(Of String, List(Of GIComboBoxItem)), _
                                b As KeyValuePair(Of String, List(Of GIComboBoxItem))) _
                                (b.Key.CompareTo(a.Key)))

        SortGroupsDone(groups)
    End Sub

    ''' <summary>
    ''' Sorts groups by their items count: ascendent.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SortGroupsAscendByItemsCount()
        Dim groups As List(Of KeyValuePair(Of String, List(Of GIComboBoxItem))) = _GroupsDisplayComplexSubItemsList.ToList()

        groups.Sort(Function(a As KeyValuePair(Of String, List(Of GIComboBoxItem)), _
                                b As KeyValuePair(Of String, List(Of GIComboBoxItem))) _
                                (a.Value.Count.CompareTo(b.Value.Count)))

        SortGroupsDone(groups)
    End Sub

    ''' <summary>
    ''' Sorts groups by their items count: descendent.
    ''' </summary>
    Public Sub SortGroupsDescByItemsCount()
        Dim groups As List(Of KeyValuePair(Of String, List(Of GIComboBoxItem))) = _GroupsDisplayComplexSubItemsList.ToList()

        groups.Sort(Function(a As KeyValuePair(Of String, List(Of GIComboBoxItem)), _
                                b As KeyValuePair(Of String, List(Of GIComboBoxItem))) _
                                (b.Value.Count.CompareTo(a.Value.Count)))

        SortGroupsDone(groups)
    End Sub
#End Region

#Region ":: PRIVATE COMBOBOX Functions"
    Protected Function GetImageIndexForItem(ByRef comboItem As GIComboBoxItem, ByRef outIndex As Integer) As Boolean
        If Me.ImageList IsNot Nothing Then
            If (Not String.IsNullOrEmpty(comboItem.ImageKey)) Then
                outIndex = Me.ImageList.Images.IndexOfKey(comboItem.ImageKey)

                Return CBool(outIndex > -1)
            End If
        End If

        Return False
    End Function

    Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)

        If TypeOf Me.SelectedItem Is GIComboBoxGroupHeader Then
            Me.SelectFirstItemFromGroup(DirectCast(Me.SelectedItem, GIComboBoxGroupHeader))
        End If

        MyBase.OnSelectedIndexChanged(e)
    End Sub

    Private Function MeassureWidest(ByVal text As Boolean, _
                                    ByVal e As System.Windows.Forms.DrawItemEventArgs, _
                                    ByRef outHeight As Single) As Single
        Dim l As Single = 0
        Dim iLargestWidth As Single = 0
        Dim iLargestHeight As Single = 0

        For Each t As GIComboBoxItem In MyBase.Items
            With e.Graphics.MeasureString(If(text, t.Text, t.Description), e.Font)
                If .Width > iLargestWidth Then
                    iLargestWidth = .Width
                End If

                If .Height > iLargestHeight Then
                    iLargestHeight = .Height
                End If
            End With
        Next

        outHeight = iLargestHeight
        Return iLargestWidth
    End Function

    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Static descriptionFont As New Font(e.Font, FontStyle.Italic)

        If e.Index <> -1 Then
            Dim n As Integer
            Dim item As GIComboBoxItem = DirectCast(MyBase.Items(e.Index), GIComboBoxItem)
            Dim iTextLeft As Integer
            Dim iTextTop As Integer
            Dim prependSpace As Boolean

            Dim textHeight As Single = 0
            Dim widestText As Single = MeassureWidest(True, e, textHeight)
            Dim widestDescription As Single = MeassureWidest(False, e, Nothing)

            Dim isGroupHeader As Boolean = CBool(TypeOf item Is GIComboBoxGroupHeader)
            Dim isInEditMode As Boolean = CBool(e.State And DrawItemState.ComboBoxEdit)

            Dim hasImage As Boolean = False
            Dim hasImagesAtAll As Boolean = CBool(Me.ImageList IsNot Nothing)
            Dim imageSizeWidth As Integer = If(hasImagesAtAll, Me.ImageList.ImageSize.Width, 0)
            Dim imageSizeHeight As Integer = If(hasImagesAtAll, Me.ImageList.ImageSize.Height, 0)

            '-- Initialization  ----------------------------------------------------
            If Me.Enabled Then
                e.DrawBackground()
                e.DrawFocusRectangle()
            End If

            If (Not Me.Enabled) AndAlso Me.HideSelectedItemWhenControlDisabled Then
                MyBase.OnDrawItem(e)
                Return
            End If

            If isGroupHeader Then
                e.Graphics.FillRectangle(_GroupHeaderBackBrush, e.Bounds)
            End If

            '-- 1. Display Image Or Not --------------------------------------------
            If isInEditMode OrElse Me.DisplayImagesForAllItems OrElse (Me.DisplayGroupHeadersImage AndAlso isGroupHeader) Then
                If Not ((isInEditMode) AndAlso (Not Me.DisplaySelectedItemImage)) Then
                    If (Not isGroupHeader) OrElse (isGroupHeader AndAlso Me.DisplayGroupHeadersImage) Then
                        If GetImageIndexForItem(item, n) Then
                            'e.Graphics.FillRectangle(Brushes.Red, e.Bounds.Left, e.Bounds.Top, imageSizeWidth, imageSizeHeight)

                            Me.ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top + CInt(((e.Bounds.Height / 2) - (imageSizeHeight / 2))), n)
                            hasImage = True
                        End If
                    End If
                End If
            End If

            '-- 2. Prepend By Space Or Not  ----------------------------------------
            If isInEditMode Then
                prependSpace = hasImage
            Else
                If isGroupHeader Then
                    prependSpace = hasImage OrElse Me.DisplayGroupHeadersImage
                Else
                    prependSpace = hasImage OrElse Me.DisplayPrependedSpace
                End If
            End If

            '-- 3. Displaying Text And Description  --------------------------------
            iTextLeft = e.Bounds.Left + If(prependSpace, imageSizeWidth, 0)
            iTextTop = e.Bounds.Top + CInt((e.Bounds.Height / 2) - (textHeight / 2))

            If Me.Enabled Then
                Using br As New SolidBrush(e.ForeColor)
                    e.Graphics.DrawString(item.Text, e.Font, br, iTextLeft, iTextTop)
                End Using
            Else
                e.Graphics.DrawString(item.Text, e.Font, System.Drawing.SystemBrushes.InactiveCaption, iTextLeft, iTextTop)
            End If

            If Me.DisplayDescriptions Then
                If Not String.IsNullOrEmpty(item.Description) Then
                    If (Me.Width > (widestText + (CInt(widestDescription) \ 2))) Then
                        If (Me.Width < (widestDescription + Me.Width \ 2)) Then
                            iTextLeft = CInt(widestText) + Me.Width \ 10
                        Else
                            iTextLeft = Me.Width \ 2
                        End If

                        Dim descriptionColor As Brush = If(isGroupHeader, _
                                                           _DescriptionFontColorInGroupHeader, _
                                                           _DescriptionFontColor)

                        e.Graphics.DrawString(item.Description, _
                                              descriptionFont, _
                                              descriptionColor, _
                                              iTextLeft, _
                                              iTextTop)
                    End If
                End If
            End If
        End If

        MyBase.OnDrawItem(e)
    End Sub
#End Region
End Class

''' <summary>
''' Class used as a basic item for GIComboBox.
''' </summary>
<Browsable(True), Serializable()> _
Public Class GIComboBoxItem
    Private _Text As String = Nothing
    Private _Description As String = Nothing
    Private _GroupName As String = Nothing
    Private _Visible As Boolean = True
    Private _object As Object = Nothing
    Private _imageKey As String = Nothing

    Public Event ItemVisibilityChanged()

    Property ImageKey() As String
        Get
            Return _imageKey
        End Get

        Set(ByVal Value As String)
            _imageKey = Value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal sItemText As String, ByRef o As Object)
        Me.New(sItemText, Nothing, Nothing, Nothing, o)
    End Sub

    Public Sub New(ByVal sItemText As String, ByVal sDescription As String, ByRef o As Object)
        Me.New(sItemText, sDescription, Nothing, Nothing, o)
    End Sub

    Public Sub New(ByVal text As String, _
                   ByVal description As String, _
                   ByVal imageKey As String, _
                   ByRef oStoreObject As Object)
        Me.New(text, description, Nothing, imageKey, oStoreObject)
    End Sub

    Public Sub New(ByVal text As String, _
                   ByVal description As String, _
                   ByVal groupName As String, _
                   ByVal imageKey As String, _
                   ByRef oStoreObject As Object)

        Me.Text = text
        Me.Description = description
        Me.ImageKey = imageKey
        Me.StoredObject = oStoreObject

        _GroupName = groupName
    End Sub


    Public Overrides Function ToString() As String
        Return _Text
    End Function

    ''' <summary>
    ''' Gets or sets text of this item.
    ''' </summary>
    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets description of this item.
    ''' </summary>
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    ''' <summary>
    ''' Gets name of group into which is item affiliated.
    ''' </summary>
    Public ReadOnly Property GroupName() As String
        Get
            Return _GroupName
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets whether this item is displayed or not.
    ''' </summary>
    Public Property Visible() As Boolean
        Get
            Return _Visible
        End Get
        Set(ByVal value As Boolean)
            _Visible = value

            RaiseEvent ItemVisibilityChanged()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets any stored object by user.
    ''' </summary>
    Public Property StoredObject() As Object
        Get
            Return _object
        End Get
        Set(ByVal value As Object)
            _object = value
        End Set
    End Property
End Class

''' <summary>
''' Class used as a group head for GIComboBox.
''' </summary>
<Browsable(True), Serializable()> _
Public Class GIComboBoxGroupHeader
    Inherits GIComboBoxItem

    Public Sub New(ByVal sText As String, _
                   ByVal sDescription As String, _
                   ByVal sImageKey As String)
        MyBase.New(sText, sDescription, sImageKey, Nothing)
    End Sub
End Class

