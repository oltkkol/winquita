Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class UFChartSelectSerie
    Private _SelectionSizeNeeded As Integer = 1

    Public Sub New(ByRef c As Chart, ByVal iNumberOfAllowedSelectionSize As Integer)
        Me.InitializeComponent()

        If iNumberOfAllowedSelectionSize = 1 Then
            lbSeries.SelectionMode = SelectionMode.One
        Else
            lbSeries.SelectionMode = SelectionMode.MultiExtended
        End If

        For Each s As Series In c.Series
            lbSeries.Items.Add(New GIComboBoxItem(s.LegendText, Nothing, s))
        Next

        If iNumberOfAllowedSelectionSize = lbSeries.Items.Count Then
            For i As Integer = 0 To lbSeries.Items.Count - 1
                lbSeries.SetSelected(i, True)
            Next
        End If

        _SelectionSizeNeeded = iNumberOfAllowedSelectionSize
        lbSeries.SelectedIndex = 0
    End Sub

    Public ReadOnly Property SelectedSerie() As Series
        Get
            Return DirectCast(DirectCast(lbSeries.SelectedItem, GIComboBoxItem).StoredObject, Series)
        End Get
    End Property

    Public ReadOnly Property HasAnyOption() As Boolean
        Get
            Return CBool(lbSeries.Items.Count > 1)
        End Get
    End Property

    Public ReadOnly Property SelectedSeries() As List(Of Series)
        Get
            Dim m As New List(Of Series)

            For Each t As GIComboBoxItem In lbSeries.SelectedItems
                m.Add(DirectCast(t.StoredObject, Series))
            Next

            Return m
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If lbSeries.SelectedItems.Count = _SelectionSizeNeeded Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("You have to select " & _SelectionSizeNeeded.ToString() & " series.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UFChartSelectSerie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
