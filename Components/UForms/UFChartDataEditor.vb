Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.DataVisualization
Public Class UFChartDataEditor
    Public Enum eChartEditorWhatToEdit
        POINTS
        SERIES
    End Enum

    Private p_DisableEditing As Boolean = False
    Private p_WhatIsShowed As eChartEditorWhatToEdit
    Private p_Chart As Chart = Nothing

    Public Overloads Sub Show(ByRef chartToEdit As Chart, _
                              ByVal eWhatToEdit As eChartEditorWhatToEdit)
        Me.Show()

        p_DisableEditing = True
        p_WhatIsShowed = eWhatToEdit
        p_Chart = chartToEdit
        lvPointsToEdit.BeginUpdate()
        lvPointsToEdit.Items.Clear()

        For Each chartSerie As Series In chartToEdit.Series
            If eWhatToEdit <> eChartEditorWhatToEdit.SERIES Then
                lvPointsToEdit.Groups.Add(chartSerie.Name, chartSerie.LegendText)
            End If

            Select Case eWhatToEdit
                Case eChartEditorWhatToEdit.SERIES
                    AddToLV(chartSerie.Name, Nothing, chartSerie)

                Case eChartEditorWhatToEdit.POINTS
                    For Each p As DataPoint In chartSerie.Points
                        AddToLV(p.ToolTip, Nothing, p)
                    Next
            End Select
        Next

        lvPointsToEdit.EndUpdate()
        p_DisableEditing = False
    End Sub

    Public Sub RefreshAll()
        Me.Show(p_Chart, p_WhatIsShowed)
    End Sub

    Private Sub AddToLV(ByVal sSerieName As String, ByVal sPointName As String, ByRef objToStore As Object)
        With lvPointsToEdit.Items.Add(sSerieName & If(StrIsAny(sPointName), ": " & sPointName, ""))
            .Tag = objToStore

            If CBool(lvPointsToEdit.Groups.Count) Then
                .Group = lvPointsToEdit.Groups(sSerieName)
            End If
        End With
    End Sub

    Private Sub RefreshEditor()
        Dim n As New List(Of Object)

        For Each lvItem As ListViewItem In lvPointsToEdit.CheckedItems
            n.Add(lvItem.Tag)
        Next

        propertyEditor.SelectedObjects = n.ToArray()

        txtStatus.Text = "Selected " & lvPointsToEdit.CheckedItems.Count & " items"
    End Sub

    Private Sub SelectAll(ByVal b As Boolean)
        p_DisableEditing = True
        
        For Each lvItem As ListViewItem In lvPointsToEdit.Items
            lvItem.Checked = b
        Next

        p_DisableEditing = False
        RefreshEditor()
    End Sub

    Private Sub lvPointsToEdit_ItemChecked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvPointsToEdit.ItemChecked
        If Not p_DisableEditing Then
            RefreshEditor()
        End If
    End Sub

    Private Sub lvPointsToEdit_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPointsToEdit.ColumnClick
        SortLV(lvPointsToEdit, e)
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        SelectAll(True)
    End Sub

    Private Sub UnselectAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnselectAllToolStripButton.Click
        SelectAll(False)
    End Sub

    Private Sub InvertSelectionToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertSelectionToolStripButton.Click
        p_DisableEditing = True

        For Each lvItem As ListViewItem In lvPointsToEdit.Items
            lvItem.Checked = Not lvItem.Checked
        Next

        p_DisableEditing = False
        RefreshEditor()
    End Sub

    Private Sub SelectAllContainingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllContainingToolStripMenuItem.Click
        Dim s As String = InputBox("What has to be contained in label? (Use * for anything.", "*")
        p_DisableEditing = True

        If (s = "*") Then
            SelectAll(True)
        Else
            For Each lvItem As ListViewItem In lvPointsToEdit.Items
                lvItem.Checked = StrContains(lvItem.Text, s)
            Next
        End If

        p_DisableEditing = False
        RefreshEditor()
    End Sub

    Private Sub RemoveSelectedToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveSelectedToolStripButton.Click
        For Each lvItem As ListViewItem In lvPointsToEdit.CheckedItems
            Select Case p_WhatIsShowed
                Case eChartEditorWhatToEdit.POINTS
                    MsgBox("Not implemented yet.")

                Case eChartEditorWhatToEdit.SERIES
                    p_Chart.Series.Remove(DirectCast(lvItem.Tag, Series))
            End Select
        Next

        Me.RefreshEditor()
    End Sub
End Class