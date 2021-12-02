Imports QITA_OLTK.QITAInterfaces
Imports System.Math

Public Class UFCompareProjectsValues
    Private _SourceProject As IQITAProject

    Public Overloads Sub Show(ByVal sourceProject As IQITAProject)
        Me.Show()

        Dim iProjectsCount As Integer = 0
        Dim T As Type = sourceProject.GetType()
        Me.Text = "Comparing results of """ & sourceProject.ProjectName & """..."

        For Each project As IQITAProject In Form1.Projects
            If Not project.Equals(sourceProject) Then
                If project.GetType().Equals(T) Then
                    cmbSecondProject.Items.Add(New GIComboBoxItem(project.ProjectName, Nothing, project))
                    iProjectsCount += 1
                End If
            End If
        Next

        If CBool(iProjectsCount > 0) Then
            _SourceProject = sourceProject
            cmbSecondProject.SelectedIndex = 0
            GroupBox1.Text = "Compare results of """ & sourceProject.ProjectName & """ with ..."
            cmbSecondProject.Enabled = True
            lvResults.Enabled = True
        Else
            GroupBox1.Text = "No other projects available for comparing..."
            cmbSecondProject.Enabled = False
            lvResults.Enabled = False
        End If
    End Sub

    Private Sub cmbSecondProject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSecondProject.SelectedIndexChanged
        Dim _SecondProject As IQITAProject = DirectCast(DirectCast(cmbSecondProject.SelectedItem, GIComboBoxItem).StoredObject, IQITAProject)

        Dim sourceHasIndexes As New List(Of String)
        Dim targetHasIndexes As New List(Of String)
        Dim sameIndexes As New List(Of String)

        For Each computedIndex As IQITAIndex In _SourceProject.ComputedIndexes
            sourceHasIndexes.Add(computedIndex.IndexName)
        Next

        For Each computedIndex As IQITAIndex In _SecondProject.ComputedIndexes
            targetHasIndexes.Add(computedIndex.IndexName)
        Next

        For Each indexName As String In sourceHasIndexes
            If targetHasIndexes.Contains(indexName) Then
                sameIndexes.Add(indexName)
            End If
        Next

        Dim s1 As Double
        Dim s2 As Double
        Dim a1 As Double
        Dim a2 As Double
        Dim result As Double
        Dim sourceResults As List(Of IQITAResult)
        Dim targetResults As List(Of IQITAResult)
        Const SG_TRESHOLD As Double = 1.96

        Dim significantlyDifferentCount As Integer = 0
        Dim comparedIndexesCount As Integer = 0
        lvResults.Items.Clear()

        For Each indexName As String In sameIndexes
            sourceResults = _SourceProject.GetResultsOfIndex(indexName)
            targetResults = _SecondProject.GetResultsOfIndex(indexName)

            s1 = (StandardDeviation(sourceResults) ^ 2) / _SourceProject.Texts.Count
            s2 = (StandardDeviation(targetResults) ^ 2) / _SecondProject.Texts.Count

            a1 = Average(sourceResults)
            a2 = Average(targetResults)

            result = Math.Round(Abs(a1 - a2) / Sqrt(s1 + s2), 6)

            If (Not Double.IsInfinity(result)) AndAlso (Not Double.IsNaN(result)) Then
                If result > SG_TRESHOLD Then
                    significantlyDifferentCount += 1
                End If

                With lvResults.Items.Add(indexName)
                    .SubItems.Add(result)
                    .SubItems.Add(If(result > SG_TRESHOLD, "YES", ""))
                    .BackColor = GetColorFromPercentage(Math.Max(Math.Min((result / (SG_TRESHOLD * 2)) * 100, 100), 0))
                End With

                comparedIndexesCount += 1
            End If
        Next

        txtStatus.Text = "Result: " & Round((significantlyDifferentCount / comparedIndexesCount) * 100, 1) & " % (" & _
                            significantlyDifferentCount & "/" & comparedIndexesCount & ") of results are significantly different."
    End Sub

    Private Sub lvResults_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvResults.ColumnClick
        SortLV(lvResults, e)
    End Sub

    Private Sub tsToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsToClipboard.Click
        Clipboard.SetText(ListViewToCSV(lvResults))
        Beep()
    End Sub
End Class