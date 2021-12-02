Imports QITA_OLTK.QITAInterfaceImplementations
Imports QITA_OLTK.QITAInterfaces
Imports QITA_OLTK.QITADataTypes
Imports System.Math

Namespace QITAIndexes
#Region "Frequency Structure Indexes"
    Public Class IndexTTR
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("TTR")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Type/Token Ratio")
            Me.SetIndexComments(Nothing)
            Me.SetIndexGroup("Frequency Structure Indexes")
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Return New QITANumberResult(TextData, Me, TextData.TypeCount() / TextData.TokenCount())
        End Function
    End Class
    Public Class IndexHPoint
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("h-Point")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Autosemantic/synsemantic fuzzy border.")
            Me.SetIndexComments(Nothing)
            Me.SetIndexGroup("Frequency Structure Indexes")
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Dim rank As Integer
            Dim f As Integer() = TextData.GetFrequencyPositiveArray()
            Dim borderFound As Boolean = False

            '-- Find place where rank = frequency of rank
            For rank = 1 To f.Count - 1
                If rank = f(rank) Then                           'if rank = frequency, return h-point
                    Return New QITANumberResult(TextData, Me, rank)
                End If

                If rank > f(rank) Then                           'if rank is higher than frequency, we are too far.
                    borderFound = True
                    rank -= 1
                    Exit For
                End If
            Next

            If Not borderFound Then                                 'if there is no h-point
                Return New QITANumberResult(TextData, Me, 0)
            End If

            '-- Else some fuzzy border is needed
            Dim i As Integer = rank
            Dim j As Integer = rank + 1

            Dim h As Double = ((f(i) * j) - (f(j) * i)) / _
                                (j - i + f(i) - f(j))


            Return New QITANumberResult(TextData, Me, h)
        End Function
    End Class
    Public Class IndexEntropy
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("Entropy")
            Me.SetIndexAuthor("Shannon")
            Me.SetIndexDescription("Entropy.")
            Me.SetIndexGroup("Frequency Structure Indexes")
            Me.SetHasComparableResults(True)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Dim entropy As Double

            Dim N As Integer = TextData.TokenCount()
            Dim V As Integer = TextData.TypeCount()

            entropy = Log2(N) - (1 / N) * SumAllFrequencies(TextData, Function(q As Integer) (q * Log2(q)))

            Return New QITANumberResult(TextData, Me, entropy)
        End Function

        Public Overrides Function CalculateDiffusion(ByRef result As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim varH As Double

            Dim N As Integer = result.TextReference.TokenCount()
            Dim V As Integer = result.TextReference.TypeCount()
            Dim H As Double = result.Value
            Dim Text As IQITAText = result.TextReference

            varH = (1 / N) * (SumAllFrequencies(Text, Function(fi) ((fi / N) * ((Log2(fi / N)) ^ 2))) - (H ^ 2))
            varH = Abs(varH)

            Return New QITANumberResult(varH)
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim u As Double

            u = UAsymptoticTest(result1, result2, _
                                Me.CalculateDiffusion(result1), Me.CalculateDiffusion(result2))

            Return New QITANumberResult(u)
        End Function
    End Class
    Public Class IndexTokenLengthsAverage
        Inherits QITAIndexBase
        Public Sub New()
            Me.SetIndexName("Average Tokens Length")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Average length of tokens.")
            Me.SetIndexGroup("Frequency Structure Indexes")
            Me.SetHasComparableResults(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Dim iLengthSum As Long = 0

            For Each t As String In TextData.Tokens()
                iLengthSum += t.Length()
            Next

            Return New QITANumberResult(TextData, Me, iLengthSum / TextData.TokenCount)
        End Function
    End Class
#End Region

#Region "Vocabulary Richness Indexes"
    Public Class IndexVocabularyRichnessR1
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("R1")
            Me.SetIndexAuthor("...")
            Me.SetIndexDescription("Vocabulary Richness -- R1")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(True)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Dim R1 As Double

            Dim h As Double = GetHPoint(TextData)
            Dim N As Integer = TextData.TokenCount()
            Dim fH As Double = SumFrequenciesAboveHPoint(TextData) / N

            If h = 0 Then
                Return New QITAUnknownResult(TextData, Me)
            Else
                R1 = 1 - (fH - ((h ^ 2) / (2 * N)))
                Return New QITANumberResult(TextData, Me, R1)
            End If
        End Function

        Public Overrides Function CalculateDiffusion(ByRef result As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim VarR1 As Double

            Dim h As Double = GetHPoint(result.TextReference)
            Dim N As Integer = result.TextReference.TokenCount()
            Dim fH As Double = SumFrequenciesAboveHPoint(result.TextReference) / N

            If h = 0 Then
                Return New QITAUnknownResult()
            Else
                VarR1 = (fH * (1 - fH)) / N
                Return New QITANumberResult(VarR1)
            End If
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim u As Double
            u = UAsymptoticTest(result1, result2, _
                                Me.CalculateDiffusion(result1), Me.CalculateDiffusion(result2))

            Return New QITANumberResult(u)
        End Function
    End Class

    Public Class IndexRepeatRateRR
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("RR")
            Me.SetIndexAuthor("...")
            Me.SetIndexDescription("RepeatRate -- RR")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(True)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Dim RR As Double

            Try
                Dim N As Integer = TextData.TokenCount()
                Dim fI As Double = SumAllFrequencies(TextData, 2)

                RR = fI / (N ^ 2)

                Return New QITANumberResult(TextData, Me, RR)
            Catch e As Exception

                Return New QITAUnknownResult(TextData, Me)
            End Try
        End Function

        Public Overrides Function CalculateDiffusion(ByRef result As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim varRR As Double = -1
            Dim Text As IQITAText = result.TextReference

            Try
                Dim N As Integer = Text.TokenCount()
                Dim fI As Double = SumAllFrequencies(Text, 3)
                Dim RR As Double = result.Value  'GetIndexVal(Text, New IndexRepeatRateRR)

                varRR = (4 / N) * (((1 / (N ^ 3)) * fI) - RR ^ 2)
                Return New QITANumberResult(Text, Me, varRR)

            Catch ex As Exception
                Return New QITAUnknownResult()
            End Try
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim u As Double

            u = UAsymptoticTest(result1, result2, _
                                Me.CalculateDiffusion(result1), Me.CalculateDiffusion(result2))

            Return New QITANumberResult(u)
        End Function
    End Class

    Public Class IndexDiffusionRepeatRateRRmc
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("RRmc")
            Me.SetIndexAuthor("McIntosh")
            Me.SetIndexDescription("Repeat Rate Relativisation by McIntosh")
            Me.SetIndexGroup("Misc")
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Try
                Dim V As Integer = TextData.TypeCount()
                Dim RR As Double = GetIndexVal(TextData, New IndexRepeatRateRR)

                Dim RRMC As Double = (1 - Math.Sqrt(RR)) / (1 - (1 / Math.Sqrt(V)))

                Return New QITANumberResult(TextData, Me, RRMC)

            Catch e As Exception
                Return New QITAUnknownResult(TextData, Me)
            End Try
        End Function
    End Class

    Public Class IndexThemeConcentration
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("TC")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Theme-concentration of text.")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(True)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            If TextData.AssignedPOSTagger Is Nothing Then
                Me.SetHasComparableResults(False)
                Return New QITAStringResult(TextData, Me, "[no tagger]")
            End If

            '-- Initialize result table
            Dim outputTable As New QITATable(TextData)
            outputTable.AddColumns("Index", "Averaged-Rank", "Frequency", TextData.GetWordOrLemmaLabel(), "Type", "TV", "Calculation")
            outputTable.SetChartableColumns("Index", "TV")
            outputTable.PreferredDisplayType = QITATable.ePreferredDisplay.AsGrid

            '-- Get needed values
            Dim h As Double = GetIndexVal(TextData, New IndexHPoint)
            Dim f As Integer() = TextData.GetFrequencyPositiveArray()
            Dim wordTable As QITAWordFrequencyTable = TextData.GetWordFrequencyTable()
            Dim frequencyToRank As QITAPositiveArray = TextData.GetFrequencyToAveragedRankTable()

            Dim TK As Double = 0
            Dim TV As Double
            Dim ra As Double
            Dim word As String
            Dim type As PartOfSpeechType

            If h = 0 Then
                Return New QITAUnknownResult(TextData, Me)
            End If

            For r As Integer = 1 To wordTable.Count ' h
                If frequencyToRank.At(f(r)) >= h Then
                    Exit For
                End If

                word = wordTable.GetWordAtIndex(r)
                If IsWordMeaningful(TextData, word) Then
                    type = GetWordType(TextData, word)

                    If IsWordTypeAppropriate(word, type) Then

                        ra = frequencyToRank.At(f(r))
                        TV = 2 * ((h - ra) * f(r)) / _
                                    (h * (h - 1) * f(1))
                        TK += TV

                        Dim sCalculation As String = VDump("h", h) + VDump("r'", ra) + VDump("f(r')", f(r)) + VDump("f(1)", f(1))

                        outputTable.AddRow(r, _
                                           frequencyToRank.At(wordTable.GetWordFrequency(word)), _
                                           wordTable.GetWordFrequency(word), _
                                           word, _
                                           type.ToString(), _
                                           TV, _
                                           sCalculation)
                    End If
                End If
            Next

            Return New QITAComplexResult(TextData, Me, TK, outputTable)
        End Function

        'Public Function CalculateP(ByRef result As QITAInterfaces.IQITAResult, ByRef outNH As Double) As Double
        '    Dim sum As Double = 0
        '    Dim Text As IQITAText = result.TextReference
        '    Dim Nh As Double = SumFrequenciesAboveHPointWithAveragedRanks(Text)
        '    Dim wordTable As QITAWordFrequencyTable = Text.GetWordFrequencyTable()
        '    Dim frequencyToRank As QITAPositiveArray = Text.GetFrequencyToAveragedRankTable()
        '    Dim f As Integer() = Text.GetFrequencyPositiveArray()
        '    Dim h As Double = GetHPoint(Text)

        '    Dim p As Double

        '    Dim word As String
        '    Dim type As PartOfSpeechType
        '    Dim ra As Double

        '    For r = 1 To wordTable.Count
        '        If frequencyToRank.At(f(r)) > h Then
        '            Exit For
        '        End If

        '        word = wordTable.GetWordAtIndex(r)
        '        ra = frequencyToRank.At(f(r))
        '        type = GetWordType(Text, word)

        '        If IsWordMeaningful(Text, word) Then
        '            If IsWordTypeAppropriate(type) Then
        '                sum += f(r)
        '            End If
        '        End If
        '    Next

        '    p = 1 / Nh * sum
        '    outNH = Nh
        '    Return p
        'End Function

        'Public Overrides Function CalculateDiffusion(ByRef result As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
        '    Dim p As Double
        '    Dim varP As Double
        '    Dim Nh As Double = 0

        '    p = Me.CalculateP(result, Nh)
        '    varP = (p * (1 - p)) / Nh

        '    Return New QITANumberResult(varP)
        'End Function

        Public Overrides Function CalculateDiffusion(ByRef result As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim a As Double
            Dim b As Double
            Dim h As Double = GetHPoint(result.TextReference)
            Dim n As Double
            Dim f1 As Double = result.TextReference.f(1)
            Dim tcWordsTable As QITATable = DirectCast(result.ComplexValue, QITATable)

            '-- m1r' ---------------------------------------
            Dim m1r As Double
            For i As Integer = 1 To tcWordsTable.RowsCount
                a += CDbl(tcWordsTable(i, "Averaged-Rank")) * CDbl(tcWordsTable(i, "Frequency"))
                b += CDbl(tcWordsTable(i, "Frequency"))
            Next

            m1r = a / b

            '-- m2r'    -----------------------------------
            Dim m2r As Double
            a = 0
            b = 0

            For i As Integer = 1 To tcWordsTable.RowsCount
                a += Pow(CDbl(tcWordsTable(i, "Averaged-Rank")) - m1r, 2) * CDbl(tcWordsTable(i, "Frequency"))
                b += tcWordsTable(i, "Frequency")
            Next

            m2r = a / b

            '-- Var(TC) -----------------------------------
            Dim varTC As Double
            n = tcWordsTable.SumColumn("Frequency")

            varTC = Pow(2 / (h * (h - 1) * f1), 2) * n * m2r

            Return New QITANumberResult(varTC)
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim u As Double

            u = UAsymptoticTest(result1, result2, _
                                Me.CalculateDiffusion(result1), Me.CalculateDiffusion(result2))

            Return New QITANumberResult(u)
        End Function

        Public Shared Function IsWordTypeAppropriate(ByVal token As String, ByVal type As PartOfSpeechType) As Boolean
            Select Case type
                Case PartOfSpeechType.NOUN, PartOfSpeechType.ADJECTIVE, PartOfSpeechType.VERB
                    Return True
                Case PartOfSpeechType.UNKNOWN
                    If token.Length > 1 Then
                        Return True
                    ElseIf token.Length = 1 Then
                        If Char.IsLetter(token(0)) Then
                            Return False
                        End If
                    End If
                Case Else
                    Return False
            End Select

            Return False
        End Function
    End Class

    Public Class IndexSecondaryThemeConcentration
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("STC")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Theme-concentration of text, h-point doubled.")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(True)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            If TextData.AssignedPOSTagger Is Nothing Then
                Me.SetHasComparableResults(False)
                Return New QITAStringResult(TextData, Me, "[no tagger]")
            End If

            '-- Initialize result table
            Dim outputTable As New QITATable(TextData)
            outputTable.AddColumns("Index", "Averaged-Rank", "Frequency", TextData.GetWordOrLemmaLabel(), "Type", "TV", "Calculation")
            outputTable.SetChartableColumns("Index", "TV")
            outputTable.PreferredDisplayType = QITATable.ePreferredDisplay.AsGrid

            '-- Get needed values
            Dim h As Double = GetIndexVal(TextData, New IndexHPoint)
            Dim f As Integer() = TextData.GetFrequencyPositiveArray()
            Dim wordTable As QITAWordFrequencyTable = TextData.GetWordFrequencyTable()
            Dim frequencyToRank As QITAPositiveArray = TextData.GetFrequencyToAveragedRankTable()

            Dim TK As Double = 0
            Dim TV As Double
            Dim ra As Double
            Dim word As String
            Dim type As PartOfSpeechType

            If h = 0 Then
                Return New QITAUnknownResult(TextData, Me)
            End If

            For r As Integer = 1 To wordTable.Count
                word = wordTable.GetWordAtIndex(r)
                If frequencyToRank.At(f(r)) >= (2 * h) Then
                    Exit For
                End If

                If IsWordMeaningful(TextData, word) Then
                    type = GetWordType(TextData, word)

                    If IsWordTypeAppropriate(word, type) Then
                        ra = frequencyToRank.At(f(r))
                        TV = (2 * h - ra) * f(r) / (h * (2 * h - 1) * f(1))
                        TK += TV

                        Dim sCalculation As String = VDump("h", h) + VDump("r'", ra) + VDump("f(r')", f(r)) + VDump("f(1)", f(1))

                        outputTable.AddRow(r, _
                                           frequencyToRank.At(wordTable.GetWordFrequency(word)), _
                                           wordTable.GetWordFrequency(word), _
                                           word, _
                                           type.ToString(), _
                                           TV, _
                                           sCalculation)
                    End If
                End If
            Next

            Return New QITAComplexResult(TextData, Me, TK, outputTable)
        End Function

        Public Overrides Function CalculateDiffusion(ByRef result As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim h As Double = GetHPoint(result.TextReference)
            Dim n As Double = 0
            Dim a As Double = 0
            Dim b As Double = 0
            Dim f1 As Double = result.TextReference.f(1)
            Dim tcWordsTable As QITATable = DirectCast(result.ComplexValue, QITATable)

            '-- m1r ----------------------------------------
            Dim m1r As Double
            For i As Integer = 1 To tcWordsTable.RowsCount
                a += CDbl(tcWordsTable(i, "Averaged-Rank")) * CDbl(tcWordsTable(i, "Frequency"))
                b += CDbl(tcWordsTable(i, "Frequency"))
                n += CDbl(tcWordsTable(i, "Frequency"))
            Next

            m1r = a / b

            '-- m2r ---------------------------------------
            Dim m2r As Double
            a = 0
            b = 0

            For i As Integer = 1 To tcWordsTable.RowsCount
                a += Pow(CDbl(tcWordsTable(i, "Averaged-Rank")) - m1r, 2) * CDbl(tcWordsTable(i, "Frequency"))
                b += tcWordsTable(i, "Frequency")
            Next

            m2r = a / b

            '-- varSTC  -----------------------------------
            Dim varSTC As Double
            varSTC = (n * m2r) / Pow((h * (2 * h - 1) * f1), 2)

            Return New QITANumberResult(varSTC)
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim u As Double

            u = UAsymptoticTest(result1, result2, _
                                Me.CalculateDiffusion(result1), Me.CalculateDiffusion(result2))

            Return New QITANumberResult(u)
        End Function

        Private Function IsWordTypeAppropriate(ByVal token As String, ByVal type As PartOfSpeechType) As Boolean
            Return IndexThemeConcentration.IsWordTypeAppropriate(token, type)
        End Function
    End Class

    Public Class IndexProportionalThemeConcentration
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("PTC")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Proportional theme-concentration of text.")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(True)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            If TextData.AssignedPOSTagger Is Nothing Then
                Me.SetHasComparableResults(False)
                Return New QITAStringResult(TextData, Me, "[no tagger]")
            End If

            '-- make table
            Dim outputTable As New QITATable(TextData)
            outputTable.AddColumns("Index", "Averaged-Rank", "Frequency", TextData.GetWordOrLemmaLabel(), "Type", "TV", "Calculation")
            outputTable.SetChartableColumns("Index", "TV")
            outputTable.PreferredDisplayType = QITATable.ePreferredDisplay.AsGrid

            '-- Get needed values
            Dim h As Double = GetHPoint(TextData)
            Dim f As Integer() = TextData.GetFrequencyPositiveArray()
            Dim wordTable As QITAWordFrequencyTable = TextData.GetWordFrequencyTable()
            Dim frequencyToRank As QITAPositiveArray = TextData.GetFrequencyToAveragedRankTable()

            Dim tkSum As Double = 0
            Dim TV As Double
            Dim ra As Double
            Dim word As String
            Dim type As PartOfSpeechType

            If h = 0 Then
                Return New QITAUnknownResult(TextData, Me)
            End If

            For r As Integer = 1 To wordTable.Count
                word = wordTable.GetWordAtIndex(r)
                If frequencyToRank.At(f(r)) >= (h) Then
                    Exit For
                End If

                If IsWordMeaningful(TextData, word) Then
                    type = GetWordType(TextData, word)

                    If IsWordTypeAppropriate(word, type) Then
                        ra = frequencyToRank.At(f(r))
                        TV = f(r)   '(2 * h - ra) * f(r) / (h * (2 * h - 1) * f(1))
                        tkSum += TV

                        Dim sCalculation As String = VDump("h", h) + VDump("r'", ra) + VDump("f(r')", f(r)) + VDump("f(1)", f(1))

                        outputTable.AddRow(r, _
                                           frequencyToRank.At(wordTable.GetWordFrequency(word)), _
                                           wordTable.GetWordFrequency(word), _
                                           word, _
                                           type.ToString(), _
                                           TV, _
                                           sCalculation)
                    End If
                End If
            Next

            Dim TK As Double
            Dim Nh As Double

            For r As Integer = 1 To wordTable.Count
                word = wordTable.GetWordAtIndex(r)
                If frequencyToRank.At(f(r)) >= (h) Then
                    Exit For
                End If

                Nh += f(r)
            Next

            TK = (1 / Nh) * tkSum

            Return New QITAComplexResult(TextData, Me, TK, outputTable)
        End Function

        Public Overrides Function CalculateDiffusion(ByRef result As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim h As Double = GetHPoint(result.TextReference)
            Dim Nh As Double = 0
            Dim varPTC As Double = 0
            Dim PTC As Double = result.Value

            Dim f As Integer() = result.TextReference.GetFrequencyPositiveArray()
            Dim wordTable As QITAWordFrequencyTable = result.TextReference.GetWordFrequencyTable()
            Dim frequencyToRank As QITAPositiveArray = result.TextReference.GetFrequencyToAveragedRankTable()

            For r As Integer = 1 To wordTable.Count
                If frequencyToRank.At(f(r)) >= (h) Then
                    Exit For
                End If

                Nh += f(r)
            Next

            varPTC = (PTC * (1 - PTC)) / Nh

            Return New QITANumberResult(varPTC)
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim u As Double

            u = UAsymptoticTest(result1, result2, _
                                Me.CalculateDiffusion(result1), Me.CalculateDiffusion(result2))

            Return New QITANumberResult(u)
        End Function

        Private Function IsWordTypeAppropriate(ByVal token As String, ByVal type As PartOfSpeechType) As Boolean
            Return IndexThemeConcentration.IsWordTypeAppropriate(token, type)
        End Function
    End Class

    Public Class IndexActivity
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("Activity")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Activity and descriptivity of text.")
            Me.SetIndexComments("High memory consumption.")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(True)
        End Sub
        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            If TextData.AssignedPOSTagger Is Nothing Then
                Me.SetHasComparableResults(False)
                Return New QITAStringResult(TextData, Me, "[no tagger]")
            End If

            Dim Q As Double = 0
            Dim isVerb As Boolean
            Dim isAdjective As Boolean
            Dim iVerbCount As Long = 0
            Dim iAdjectivesCount As Integer = 0
            Dim output As New QITATable(TextData)

            output.AddColumns("A+V", "Q", TextData.GetWordOrLemmaLabel(), "|V|", "|A|")
            output.SetChartableColumns("A+V", "Q")

            For Each sToken As String In TextData.Tokens()
                isVerb = False
                isAdjective = False

                Select Case TextData.AssignedPOSTagger.GetWordType(sToken)
                    Case PartOfSpeechType.VERB
                        If TextData.AssignedPOSTagger.IsWordMeaningful(sToken) Then
                            iVerbCount += 1
                            isVerb = True
                        End If

                    Case PartOfSpeechType.ADJECTIVE
                        iAdjectivesCount += 1
                        isAdjective = True
                End Select

                If isVerb OrElse isAdjective Then
                    Q = iVerbCount / (iVerbCount + iAdjectivesCount)

                    output.AddRow(iVerbCount + iAdjectivesCount, Q, sToken, iVerbCount, iAdjectivesCount)
                End If
            Next

            Return New QITAComplexResult(TextData, Me, Q, output)
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim u As Double
            Dim result1Table As QITATable = DirectCast(result1.ComplexValue, QITATable)
            Dim result2Table As QITATable = DirectCast(result2.ComplexValue, QITATable)

            Dim Q1 As Double = result1.Value
            Dim Q2 As Double = result2.Value
            Dim V1 As Long = result1Table.LastCellValue("|V|")
            Dim V2 As Long = result2Table.LastCellValue("|V|")
            Dim A1 As Long = result1Table.LastCellValue("|A|")
            Dim A2 As Long = result2Table.LastCellValue("|A|")

            u = Abs(Q1 - Q2) / (Sqrt(Q1 * Q2) * Sqrt(1 / V1 + 1 / A1 + 1 / A2 + 1 / V2))

            Return New QITANumberResult(u)
        End Function
    End Class

    Public Class IndexDescriptivity
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("Descriptivity")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Activity and descriptivity of text.")
            Me.SetIndexComments("High memory consumption.")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(True)
        End Sub
        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            If TextData.AssignedPOSTagger Is Nothing Then
                Me.SetHasComparableResults(False)
                Return New QITAStringResult(TextData, Me, "[no tagger]")
            End If

            Dim Q As Double = 0
            Dim isVerb As Boolean
            Dim isAdjective As Boolean
            Dim iVerbCount As Long = 0
            Dim iAdjectivesCount As Integer = 0
            Dim output As New QITATable(TextData)

            output.AddColumns("A+V", "Q", TextData.GetWordOrLemmaLabel(), "|V|", "|A|")
            output.SetChartableColumns("A+V", "Q")

            For Each sToken As String In TextData.Tokens()
                isVerb = False
                isAdjective = False

                Select Case TextData.AssignedPOSTagger.GetWordType(sToken)
                    Case PartOfSpeechType.VERB
                        If TextData.AssignedPOSTagger.IsWordMeaningful(sToken) Then
                            iVerbCount += 1
                            isVerb = True
                        End If

                    Case PartOfSpeechType.ADJECTIVE
                        iAdjectivesCount += 1
                        isAdjective = True
                End Select

                If isVerb OrElse isAdjective Then
                    Q = iAdjectivesCount / (iVerbCount + iAdjectivesCount)

                    output.AddRow(iVerbCount + iAdjectivesCount, Q, sToken, iVerbCount, iAdjectivesCount)
                End If
            Next

            Return New QITAComplexResult(TextData, Me, Q, output)
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim u As Double
            Dim result1Table As QITATable = DirectCast(result1.ComplexValue, QITATable)
            Dim result2Table As QITATable = DirectCast(result2.ComplexValue, QITATable)

            Dim Q1 As Double = result1.Value
            Dim Q2 As Double = result2.Value
            Dim V1 As Long = result1Table.LastCellValue("|V|")
            Dim V2 As Long = result2Table.LastCellValue("|V|")
            Dim A1 As Long = result1Table.LastCellValue("|A|")
            Dim A2 As Long = result2Table.LastCellValue("|A|")

            u = Abs(Q1 - Q2) / (Sqrt(Q1 * Q2) * Sqrt(1 / V1 + 1 / A1 + 1 / A2 + 1 / V2))

            Return New QITANumberResult(u)
        End Function
    End Class

    Public Class IndexLambda
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("Λ (Lambda)")
            Me.SetIndexAuthor("Popescu, Cech, Altmann")
            Me.SetIndexDescription("")
            Me.SetIndexComments("")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Dim V As Long = TextData.V()
            Dim N As Long = TextData.N()
            Dim h As Double = GetHPoint(TextData)
            Dim f As Integer() = TextData.GetFrequencyPositiveArray()

            Dim L As Double = SumAllFrequencies(TextData, 1, V - 1, _
                                                    Function(fi As Long, i As Integer) _
                                                        (Math.Sqrt((f(i) - f(i + 1)) ^ 2 + 1)))
            Dim Lambda As Double = (L * Log10(N)) / N



            Return New QITANumberResult(TextData, Me, Lambda)
        End Function
    End Class

    Public Class IndexAdjustedModulus
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("Adjusted Modulus")
            Me.SetIndexAuthor("Popescu - Mačutek, Kelih, Čech, Best, Altmann")
            Me.SetIndexDescription("")
            Me.SetIndexComments("")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Dim V As Long = TextData.V()
            Dim N As Long = TextData.N()
            Dim h As Double = GetHPoint(TextData)

            Dim M As Double = (1 / h) * Math.Sqrt((TextData.f(1) ^ 2 + V ^ 2))
            Dim A As Double = M / Log10(N)

            Return New QITANumberResult(TextData, Me, A)
        End Function
    End Class

    Public Class IndexGiniCoeficient
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("G")
            Me.SetIndexAuthor("Gini")
            Me.SetIndexDescription("Ginis Coeficient")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(True)
        End Sub

        Private Function CalculateM1(ByRef TextData As IQITAText) As Double
            Return SumAllFrequencies(TextData, 1, TextData.V, Function(f, r) (r * f)) / TextData.N
        End Function

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Dim G As Double
            Dim m1 As Double

            m1 = CalculateM1(TextData)
            G = (1 / TextData.V) * (TextData.V + 1 - 2 * m1)

            Return New QITANumberResult(TextData, Me, G)
        End Function

        Public Overrides Function CalculateDiffusion(ByRef result As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim varG As Double
            Dim m1 As Double
            Dim m2 As Double

            Dim V As Integer = result.TextReference.V
            Dim N As Integer = result.TextReference.N

            m1 = CalculateM1(result.TextReference)
            m2 = (1 / N) * SumAllFrequencies(result.TextReference, 1, V, Function(fri, ri) (((ri - m1) ^ 2) * fri))
            varG = (4 * m2) / ((V ^ 2) * N)

            Return New QITANumberResult(varG)
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Dim u As Double
            u = UAsymptoticTest(result1, result2, CalculateDiffusion(result1), CalculateDiffusion(result2))

            Return New QITANumberResult(u)
        End Function
    End Class

    Public Class IndexGiniCoeficientR4
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("R4")
            Me.SetIndexAuthor("Gini")
            Me.SetIndexDescription("Ginis Coeficient R4")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Dim G As Double = CDbl(GetIndexVal(TextData, New IndexGiniCoeficient()))
            Dim R4 As Double = 1 - G

            Return New QITANumberResult(TextData, Me, R4)
        End Function
    End Class

    Public Class IndexHapaxPercentage
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("Hapax Percentage")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Percentage of hapaxes in text.")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Dim hapaxCount As Long = TextData.GetFrequencyPositiveArray().Sum(Function(n As Long) (If(n = 1, 1, 0)))

            Return New QITANumberResult(TextData, Me, hapaxCount / TextData.TokenCount)
        End Function
    End Class

#End Region

#Region "Next indexes"
    Public Class IndexCurveLengthL
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("L")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Euclidian Length of curve created by connecting [rank, frequency] points.")
            Me.SetIndexGroup("Misc")
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Dim L As Double

            Dim h As Integer = GetHPoint(TextData)
            Dim V As Integer = TextData.TypeCount()
            Dim f() As Integer = TextData.GetFrequencyPositiveArray()

            L = SumAllFrequencies(TextData, 1, V - 1, Function(frequency As Integer, i As Integer) _
                                                                    (Math.Sqrt((f(i) - f(i + 1)) ^ 2 + 1)))

            Return New QITANumberResult(TextData, Me, L)
        End Function
    End Class

    Public Class IndexWritersView
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("WritersView")
            Me.SetIndexAuthor("A. TUZZI, I. I. POPESCU, G. ALTMANN")
            Me.SetIndexDescription("")
            Me.SetIndexGroup("Misc")
            Me.SetIsSecondary(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Dim h As Double = GetHPoint(TextData)
            Dim V As Double = TextData.V
            Dim f1 As Double = TextData.f(1)

            Dim cosAlpha As Double = (-(((h - 1) * (f1 - h)) + ((h - 1) * (V - h)))) / _
                                        (Math.Sqrt(Math.Pow(h - 1, 2) + Math.Pow(f1 - h, 2)) * Math.Sqrt(Math.Pow(h - 1, 2) + Math.Pow(V - h, 2)))

            Return New QITANumberResult(TextData, Me, Math.Acos(cosAlpha))
        End Function
    End Class

    Public Class IndexCurveLengthAboveHPoint
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("CurveLength Above h-Point")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Euclidian Length of curve created by connecting [rank, frequency] points above h-Point.")
            Me.SetIndexGroup("Misc")
            Me.SetIsSecondary(True)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Dim Lh As Double

            Dim h As Integer = GetHPoint(TextData)
            Dim frequencies() As Integer = TextData.GetFrequencyPositiveArray()

            If IsNumberWhole(h) Then
                If h = TextData.V Then  'When h point is at the end
                    Lh = SumAllFrequencies(TextData, 1, h - 1, Function(f As Integer, r As Integer) _
                                                                    (Math.Sqrt((f - frequencies(r + 1)) ^ 2 + 1)))
                Else                    'h point is at normal rank.

                    Lh = SumAllFrequencies(TextData, 1, h, Function(f As Integer, r As Integer) _
                                                                    (Math.Sqrt((f - frequencies(r + 1)) ^ 2 + 1)))
                End If
            Else
                Lh = SumAllFrequencies(TextData, 1, CInt(h) - 1, Function(f As Integer, r As Integer) _
                                                                (Math.Sqrt((f - frequencies(r + 1)) ^ 2 + 1)))
                Lh += Math.Sqrt((h - frequencies(CInt(h))) ^ 2 + (h - CInt(h)) ^ 2)
            End If

            Return New QITANumberResult(TextData, Me, Lh)
        End Function
    End Class

    Public Class IndexCurveLengthBelowHPoint
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("CurveLength Below h-Point")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Euclidian Length of curve created by connecting [rank, frequency] points below h-Point.")
            Me.SetIndexGroup("Misc")
            Me.SetIsSecondary(True)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Dim CL As Double

            Dim h As Integer = GetHPoint(TextData)
            Dim V As Integer = TextData.TypeCount()
            Dim frequencies() As Integer = TextData.GetFrequencyPositiveArray()

            CL = SumAllFrequencies(TextData, CInt(h) + 1, V - 1, Function(f As Integer, r As Integer) _
                                                            (Math.Sqrt((f - frequencies(r + 1)) ^ 2 + 1)))

            'Dim b As Boolean = CBool((CL + GetIndexVal(TextData, New IndexCurveLengthAboveHPoint) = GetIndexVal(TextData, New IndexCurveLengthL)))

            Return New QITANumberResult(TextData, Me, CL)
        End Function
    End Class

    Public Class IndexCurveLengthProportion
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("CurveLength RIndex")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Proportion of full euclidian curve length to euclidian curve length above h-Point.")
            Me.SetIndexGroup("Misc")
            Me.SetIsSecondary(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As IQITAText) As IQITAResult
            Dim R As Double

            R = 1 - (GetIndexVal(TextData, New IndexCurveLengthAboveHPoint) / _
                        GetIndexVal(TextData, New IndexCurveLengthL))

            Return New QITANumberResult(TextData, Me, R)
        End Function
    End Class

    Public Class IndexVerbCountInBlock
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("Verb Distances")
            Me.SetIndexAuthor("VM")
            Me.SetIndexDescription("Average distance of verbs in text.")
            Me.SetIndexGroup("Misc")
            Me.SetHasComparableResults(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Dim i As Integer = 0
            Dim iLast As Integer = 0
            Dim iVerbCount As Integer = 0
            Dim distanceSum As Double = 0

            If Not IsAny(TextData.AssignedPOSTagger) Then
                Return New QITAStringResult(TextData, Me, "[no tagger]")
            End If

            For Each sToken As String In TextData.Tokens()
                If TextData.AssignedPOSTagger.GetWordType(sToken) = PartOfSpeechType.VERB Then
                    distanceSum += (i - iLast)

                    iVerbCount += 1
                    iLast = i
                End If

                i += 1
            Next

            Return New QITANumberResult(TextData, Me, distanceSum / iVerbCount)
        End Function
    End Class

    Public Class IndexTokenLengthsFrequency
        Inherits QITAIndexBase

        Public Sub New()
            Me.SetIndexName("Token Length Frequency Spectrum")
            Me.SetIndexAuthor("")
            Me.SetIndexDescription("Token lengths diversity (how many various token lengths are used); tokens lengths frequencies.")
            Me.SetIndexGroup("Frequency Structure Indexes")
            Me.SetHasComparableResults(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Dim tokenLength As Integer = 0
            Dim lengths As New Dictionary(Of Integer, Integer)(50)

            For Each token As String In TextData.Tokens
                tokenLength = token.Length

                If Not lengths.ContainsKey(tokenLength) Then
                    lengths.Add(tokenLength, 0)
                End If

                lengths(tokenLength) += 1
            Next

            Dim resultTable As New QITATable(TextData, "Token Length", "Frequency")
            resultTable.SetChartableColumns("Token Length", "Frequency")

            Dim resultList As List(Of KeyValuePair(Of Integer, Integer)) = lengths.ToList()
            resultList.Sort(Function(a As KeyValuePair(Of Integer, Integer), _
                                      b As KeyValuePair(Of Integer, Integer)) _
                                      (a.Key.CompareTo(b.Key)))

            For Each p As KeyValuePair(Of Integer, Integer) In resultList
                resultTable.AddRow(p.Key, p.Value)
            Next

            Return New QITAComplexResult(TextData, Me, resultTable.RowsCount, resultTable)
        End Function
    End Class
#End Region

#Region "Unknown VM Tests"
    Public Class IndexZipfTest
        Inherits QITAIndexBase
        Public Sub New()
            Me.SetIndexName("Zipf Test")
            Me.SetIndexAuthor("VM")
            Me.SetIndexDescription("Zipf law test. Tests how many % of types (except hapaxes) match exact f*r=c equation.")
            Me.SetIndexComments("High memory consumption.")
            Me.SetIndexGroup("ZZ_ EXPERIMENTAL")
            Me.SetHasComparableResults(False)
            Me.SetIsSecondary(False)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            'c = rank * frekvence

            Dim zipfResults As New Dictionary(Of Double, Integer)
            Dim frequencies As Integer() = TextData.GetFrequencyPositiveArray()

            Dim c As Double
            Dim f As Long
            Dim r As Double

            Dim rankToCTable As New QITATable("Frequency * Rank Table")
            rankToCTable.AddColumns("Rank", "Frequency", "Rank*Frequency")
            rankToCTable.SetChartableColumns("Rank", "Rank*Frequency", "Frequency")

            For i As Integer = 1 To frequencies.Count - 1
                f = frequencies(i)

                If f = 1 Then Exit For

                r = TextData.FrequencyToRank(f)
                c = f * r

                If zipfResults.ContainsKey(c) Then
                    zipfResults(c) = zipfResults(c) + 1
                Else
                    rankToCTable.AddRow(r, f, c)
                    zipfResults.Add(c, 1)
                End If
            Next

            'Dim m As Double
            'If zipfResults.Count Then
            '    m = zipfResults.Values.ToArray().Max() / TextData.V
            'Else
            '    m = 0
            'End If

            Return New QITAComplexResult(TextData, Me, Nothing, rankToCTable)
        End Function
    End Class

    Public Class IndexZipfDelta
        Inherits QITAIndexBase
        Public Sub New()
            Me.SetIndexName("Zipf Δ")
            Me.SetIndexAuthor("VM")
            Me.SetIndexDescription("Average distance of Zipfian r*f=c from token*10.")
            Me.SetIndexGroup("ZZ_ EXPERIMENTAL")
            Me.SetHasComparableResults(False)

            Me.SetIsSecondary(True)
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Dim result As IQITAResult = TextData.ComputeIndex(New IndexZipfTest())
            Dim table As QITATable = DirectCast(result.ComplexValue, QITATable)

            Dim k As Double = TextData.TokenCount / 10
            Dim deltas As New List(Of Double)

            For i As Integer = 1 To table.RowsCount
                deltas.Add(k - CDbl(table.CellValue(i, "Rank*Frequency")))
            Next

            If deltas.Count Then
                Return New QITANumberResult(TextData, Me, deltas.Average)
            Else
                Return New QITAUnknownResult(TextData, Me)
            End If
        End Function
    End Class
#End Region


End Namespace