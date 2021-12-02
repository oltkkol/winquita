Imports QITA_OLTK.QITAInterfaces
Imports QITA_OLTK.QITADataTypes
Imports QITA_OLTK.QITAInterfaceImplementations
Imports QITA_OLTK.QITAMorphoAnalyzers
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO

''' <summary>
''' Class providing access to pipe-based communication with given executable file or script.
''' Limitted queries with results are localy cached.
''' </summary>
Public MustInherit Class QITAGenericPipeMorphoAnalyzer
    Inherits QITAMorphoAnalyzerBase

    Private p_Pipe As PipedLineExecution = Nothing
    Private p_QueryCache As New QueryPrivateCache(2017)

    Public Sub New()

    End Sub

#Region ":: PIPE CREATORS"

    ''' <summary>
    ''' Initializes pipe communication with target executable file.
    ''' </summary>
    ''' <param name="sExecutablePath">Analyzer executable path.</param>
    ''' <param name="sAnalyzerCommands">Additional commands and arguments for executing.</param>
    ''' <param name="encoding">Encoding of input/ouput data.</param>
    ''' <param name="outError">Output: Exception if any.</param>
    ''' <returns>TRUE if pipe has been succesfully established.</returns>
    ''' <remarks>Working directory is set to executable path directory.</remarks>
    Protected Function CreatePipeWithExecutable(ByVal sExecutablePath As String, _
                                                    ByVal sAnalyzerCommands As String, _
                                                    ByVal encoding As System.Text.Encoding, _
                                                    ByRef outError As Exception) As Boolean

        p_Pipe = New PipedLineExecution(sExecutablePath, _
                                    sAnalyzerCommands, _
                                    Path.GetDirectoryName(sExecutablePath), _
                                    encoding, _
                                    outError)

        Return p_Pipe.IsOk
    End Function

    ''' <summary>
    ''' Initializes pipe communication with target script.
    ''' </summary>
    ''' <param name="sScriptPath">Full path to script destination.</param>
    ''' <param name="sCommands">Command arguments for script.</param>
    ''' <param name="encoding">Encoding of input/output data.</param>
    ''' <param name="outError">Output: Exception if any.</param>
    ''' <returns>TRUE if pipe has been succesfully established.</returns>
    ''' <remarks>Working directory is set to script path directory.</remarks>
    Protected Function CreatePipeWithScript(ByVal sScriptPath As String, _
                                            ByVal sCommands As String, _
                                            ByVal encoding As System.Text.Encoding, _
                                            ByRef outError As Exception) As Boolean

        p_Pipe = New PipedLineExecution(GetApplicationByFileExtension(Path.GetExtension(sScriptPath)), _
                                            EncapsulateStringWithDoubleQuotes(sScriptPath) & IIf(StrIsAny(sCommands), " " & sCommands, Nothing), _
                                            Path.GetDirectoryName(sScriptPath), _
                                            encoding, _
                                            outError)
        Return p_Pipe.IsOk
    End Function

    Protected Function IsSuccesfullyEstablished() As Boolean
        If IsAny(p_Pipe) Then
            Return p_Pipe.IsOk
        End If

        Return False
    End Function
#End Region

#Region ":: PIPED ANALYZER COMMUNICATION"
    ''' <summary>
    ''' Function asks Lemmatizer for given question (passes command to analyzer and reads response).
    ''' This function uses internal query-result cache.
    ''' </summary>
    ''' <param name="sQuestion">Command or question for analyzer.</param>
    ''' <returns>Analyzer response.</returns>
    Protected Function AskAnalyzer(ByVal sQuestion As String) As String
        Dim sOut As String = Nothing

        If p_QueryCache.GetQuery(sQuestion, sOut) Then
            Return sOut
        End If

        If Me.IsSuccesfullyEstablished() Then
            sOut = p_Pipe.WriteLineAndReadOutput(sQuestion)

            p_QueryCache.Add(sQuestion, sOut)
            Return sOut
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Inherited. This function MUST be overrided by using class.
    ''' </summary>
    ''' <param name="sWord">Ignored.</param>
    ''' <returns>Nothing.</returns>
    Public Overrides Function LemmatizeWord(ByVal sWord As String) As String
        Throw New Exception("Use AskAnalyzer function to communicate with analyzer. This function has to been overriden.")

        Return Nothing
    End Function

    ''' <summary>
    ''' Inherited. This function MUST be overrided by using class.
    ''' </summary>
    ''' <param name="sWord">Ignored.</param>
    ''' <returns>WordType.MUST_OVERRIDE value.</returns>
    Public Overrides Function GetWordType(ByVal sWord As String) As QITADataTypes.PartOfSpeechType
        Throw New Exception("QITAGenericPipeLemmatizer GetWordType() MUST be overrided by lemmatizer class.")

        Return PartOfSpeechType.MUST_OVERRIDE
    End Function

    ''' <summary>
    ''' Inherited. This function MUST be overrided by using class.
    ''' </summary>
    ''' <param name="sWord">Ignored.</param>
    ''' <returns>Boolean.</returns>
    Public Overrides Function IsWordMeaningful(ByVal sWord As String) As Boolean
        Throw New Exception("QITAGenericPipeLemmatizer IsWordMeaningful() MUST be overrided by lemmatizer class.")

        Return PartOfSpeechType.MUST_OVERRIDE
    End Function
#End Region
End Class

Public MustInherit Class MorphoAnalyzerTextProcessingCom
    Inherits QITAMorphoAnalyzerBase
    Private _Language As String = "english"
    Private _Stemmer As String = Nothing

    Public Sub New(ByVal sLanguageName As String, ByVal sStemmerName As String)
        If Not StrIsAny(sLanguageName) Then
            ThrowInitError("Language cannot be NULL.")
        End If

        _Language = sLanguageName.ToLower()
        _Stemmer = If(StrIsAny(sStemmerName), sStemmerName.ToLower(), Nothing)

        Me.SetAnalyzerName("Text-Processing.com")
        Me.SetAnalyzerLanguage(sLanguageName.Substring(0, 2))
        Me.SetAnalyzerAuthor("Text-Processing.com")
        Me.SetAnalyzerDescription("http://www.text-processing.com")

        Me.SetPluginVersion("1.0")
        Me.SetPluginAuthor("VM")
        Me.SetPluginRequisites("Internet")
    End Sub

    Public Overrides Function CheckDependencies(ByRef outStatus As String) As Boolean
        If CheckIfInternetIsAvailable() Then
            outStatus = "OK"
            Return True
        End If
    End Function

    Public Overrides Function Initialize() As Boolean
        Return HTTPPostHandler.CheckConnection()
    End Function

    Public Overrides Function TokenizeText(ByVal sText As String) As String()
        Dim e As Exception = Nothing
        Dim output As String = Nothing
        Dim postRequest As New HTTPPostHandler("http://text-processing.com/api/stem/")

        postRequest.AddRequestField("language", _Language)
        postRequest.AddRequestField("stemmer", _Stemmer)
        postRequest.AddRequestField("text", sText)

        If postRequest.TransferData(output, e) Then
            output = DecodeUnicodeSequences(output)
            Return Split(StrMidCharTermE(output, "{""text"": """, """}"))
        Else
            ThrowInitError("Could not TokenizeText.", e)
            Return Nothing
        End If
    End Function

    Public Overrides Function LemmatizeWord(ByVal sWord As String) As String
        Return sWord
    End Function

    Public Overrides Function GetWordType(ByVal sWord As String) As QITADataTypes.PartOfSpeechType
        Return PartOfSpeechType.UNKNOWN
    End Function

    Public Overrides Function IsWordMeaningful(ByVal sWord As String) As Boolean
        Return True
    End Function
End Class

Namespace QITAMorphoAnalyzers

#Region "Only Tokenizers"
    Public Class GenericTokenizer
        Inherits QITATokenizerOnlyBase

        Public Sub New()
            Me.SetAnalyzerName("Default generic tokenizer")
            Me.SetAnalyzerLanguage("[ GENERIC ]")
            Me.SetAnalyzerDescription("Default Tokenizer. Generic (all languages) regex word split: """"\W+""")
        End Sub

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            Return Regex.Split(sText, "\W+")
        End Function
    End Class

    Public Class GenericCharTokenizer
        Inherits QITATokenizerOnlyBase

        Public Sub New()
            Me.SetAnalyzerName("Generic char tokenizer")
            Me.SetAnalyzerLanguage("[ GENERIC ]")
            Me.SetAnalyzerDescription("Treats each character as a token.")
        End Sub

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            Dim sTokens(sText.Length - 1) As String

            For i As Integer = 0 To sText.Length() - 1
                sTokens(i) = CStr(sText(i))
            Next

            Return sTokens
        End Function
    End Class

    'Public Class GenericCharTokenizerExceptSpaces
    '    Inherits QITATokenizerOnlyBase

    '    Public Sub New()
    '        Me.SetAnalyzerName("Generic char tokenizer (No Spaces)")
    '        Me.SetAnalyzerLanguage("[ GENERIC ]")
    '        Me.SetAnalyzerDescription("Treats each character as a token (spaces are ignored)")
    '    End Sub

    '    Public Overrides Function TokenizeText(ByVal sText As String) As String()
    '        sText = sText.Replace(" ", Nothing)
    '        Dim sTokens(sText.Length - 1) As String

    '        For i As Integer = 0 To sText.Length() - 1
    '            sTokens(i) = CStr(sText(i))
    '        Next

    '        Return sTokens
    '    End Function
    'End Class

    Public Class GenericLineTokenizer
        Inherits QITATokenizerOnlyBase

        Public Sub New()
            Me.SetAnalyzerName("Line Tokenizer")
            Me.SetAnalyzerLanguage("[ GENERIC ]")
            Me.SetAnalyzerDescription("Treats line as a token.")
        End Sub

        Public Overrides Function CheckDependencies(ByRef outStatus As String) As Boolean
            outStatus = "OK"
            Return True
        End Function

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            Dim sTokens() As String = sText.Split(vbLf)

            For i As Integer = 0 To sTokens.Count - 1
                sTokens(i) = Replace(sTokens(i), vbCr, Nothing)
            Next

            Return sTokens
        End Function
    End Class

    Public Class DNATripletTokenizer
        Inherits QITATokenizerOnlyBase

        Public Sub New()
            Me.SetAnalyzerName("DNA Triplet Tokenizer")
            Me.SetAnalyzerLanguage("[DNA]")
            Me.SetAnalyzerDescription("Splits DNA nucleotide string into triplets.")
        End Sub

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            sText = RemoveFNAInfoHeaders(sText)
            sText = StandardizeDNA(sText)

            Dim s As New StringBuilder(sText.Length + (sText.Length \ 3))

            For i As Integer = 0 To sText.Length - 3
                s.Append(sText(i) & sText(i + 1) & sText(i + 2) & " ")
            Next

            Return s.ToString().Split(" ")
        End Function
    End Class

    Public Class DNANucleotideTokenizer
        Inherits QITATokenizerOnlyBase

        Public Sub New()
            Me.SetAnalyzerName("DNA Nucleotide Tokenizer")
            Me.SetAnalyzerLanguage("[DNA]")
            Me.SetAnalyzerDescription("Treats each nucleotide as a token.")
        End Sub

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            sText = RemoveFNAInfoHeaders(sText)
            sText = StandardizeDNA(sText)

            Dim sTokens(sText.Length - 1) As String

            For i As Integer = 0 To sText.Length() - 1
                sTokens(i) = CStr(sText(i))
            Next

            Return sTokens
        End Function
    End Class
#End Region

#Region "MorphoAnalyzers: Natural Language -- Various"
    Public Class LemmatizerCzechMajka
        Inherits QITAGenericPipeMorphoAnalyzer

        Private _LemmatizerPath As String = GetQITAAnalyzersDirectory() & "\majka\majka.exe"
        Private _LemmatizerWLTFile As String = GetQITAAnalyzersDirectory() & "\majka\majka.w-lt"
        Private _LemmatizerCommands As String = "-f """ & _LemmatizerWLTFile & """ -p"

        Public Sub New()
            SetAnalyzerName("MAJKA")
            SetAnalyzerLanguage("CZ")
            SetAnalyzerAuthor("Pavel Šmerk (MUNI)")
            SetAnalyzerDescription("http://nlp.fi.muni.cz/ma/free.html")
            SetAnalyzerAbilities(True, True, False, False)
            SetAnalyzerScore(60)

            SetPluginVersion("1.0")
            SetPluginAuthor("VM")
        End Sub

        Public Overrides Function CheckDependencies(ByRef outStatus As String) As Boolean
            If Not File.Exists(_LemmatizerPath) Then
                outStatus = "Not found: " & _LemmatizerPath
                Return False
            End If

            If Not File.Exists(_LemmatizerWLTFile) Then
                outStatus = "Not found: " & _LemmatizerWLTFile
                Return False
            End If

            outStatus = "OK"
            Return True
        End Function

        Public Overrides Function Initialize() As Boolean
            Dim e As Exception = Nothing

            If Not MyBase.CreatePipeWithExecutable(_LemmatizerPath, _LemmatizerCommands, Encoding.GetEncoding(1250), e) Then
                Me.ThrowInitError("Could not create pipe.", e)
                Return False
            End If

            Return Me.InitOK()
        End Function

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            Return Nothing
        End Function

        Public Overrides Function LemmatizeWord(ByVal sWord As String) As String
            Me.CheckIfInitialized()

            Dim sMAJKAResult As String = Me.AskAnalyzer(sWord)
            Dim sLemma As String = Nothing

            If ParseMajkaResult(sMAJKAResult, sLemma, Nothing) Then
                Return sLemma
            Else
                Return MakeUnknownLemmaOutput(sWord)
            End If
        End Function

        Public Overrides Function GetWordType(ByVal sWord As String) As QITADataTypes.PartOfSpeechType
            Me.CheckIfInitialized()

            Dim sMAJKAResult As String = Me.AskAnalyzer(sWord)
            Dim sTag As String = Nothing

            ParseMajkaResult(sMAJKAResult, Nothing, sTag)
            Return ParseMajkaTagToWordType(sTag)
        End Function

        Public Overrides Function IsWordMeaningful(ByVal sWord As String) As Boolean
            Return True
        End Function

        Private Function ParseMajkaResult(ByVal sMajkaResult As String, ByRef sOutFirstLemma As String, ByRef sOutFirstTag As String) As Boolean
            If StrIsAny(sMajkaResult) Then
                Dim s() As String = sMajkaResult.Split(":")

                'Example output:
                'pes:pes:k1gMnSc1:peso:k1gNnPc2

                If s.Count > 2 Then                 'result contains lemma and tag
                    sOutFirstLemma = s(1)
                    sOutFirstTag = s(2)

                    Return True
                End If
            End If

            Return False
        End Function

        Private Function ParseMajkaTagToWordType(ByVal sMajkaTag As String) As PartOfSpeechType
            'NOUN nouns (common and proper)     k1.*
            'ADJ adjectives                     k2.*, k4.*xO, k4.*xR
            'PRON pronouns                      k3.*
            'NUM cardinal numbers               k4.*xC
            'VERB verbs (all tenses and modes)  k5.*
            'ADV adverbs                        k6.*
            'ADP adpositions (prepositions and postpositions) k7.*
            'CONJ conjunctions                  k8.*
            'PRT particles or other function words k9.*

            If StrIsAny(sMajkaTag) Then
                If Len(sMajkaTag) > 1 Then
                    Select Case True
                        Case Regex.IsMatch(sMajkaTag, "k1.*")
                            Return PartOfSpeechType.NOUN

                        Case Regex.IsMatch(sMajkaTag, "k2.*"), _
                                Regex.IsMatch(sMajkaTag, "k4.*xO"), _
                                Regex.IsMatch(sMajkaTag, "k4.*xR")

                            Return PartOfSpeechType.ADJECTIVE

                        Case Regex.IsMatch(sMajkaTag, "k3.*")
                            Return PartOfSpeechType.PRONOUN

                        Case Regex.IsMatch(sMajkaTag, "k4.*xC")
                            Return PartOfSpeechType.NUMBER

                        Case Regex.IsMatch(sMajkaTag, "k5.*")
                            Return PartOfSpeechType.VERB

                        Case Regex.IsMatch(sMajkaTag, "k6.*")
                            Return PartOfSpeechType.ADVERB

                        Case Regex.IsMatch(sMajkaTag, "k7.*")
                            Return PartOfSpeechType.PREPOSITION

                        Case Regex.IsMatch(sMajkaTag, "k8.*")
                            Return PartOfSpeechType.CONJUNCTION

                        Case Regex.IsMatch(sMajkaTag, "k9.*")
                            Return PartOfSpeechType.PARTICLE

                        Case Else
                            Return PartOfSpeechType.UNKNOWN
                    End Select
                End If
            End If

            Return PartOfSpeechType.UNKNOWN
        End Function
    End Class

    Public Class LemmatizerCzechCorpusStatic
        Inherits QITAMorphoAnalyzerBase

        Private p_HashTable As Hashtable = Nothing
        Private p_UnmeaningfullHashSet As HashSet(Of String) = Nothing

        Private p_DBFilePath As String = GetQITAAnalyzersDirectory() & "\czc-s\db.dat"
        Private p_DBUnmeanFile As String = GetQITAAnalyzersDirectory() & "\czc-s\unmean.txt"

        Public Sub New()
            SetAnalyzerName("Czech-National-Corpus Static")
            SetAnalyzerAuthor("Czech-National-Corpus www.korpus.cz")
            SetAnalyzerDescription("Lemmatizer based on data from www.korpus.cz")
            SetAnalyzerLanguage("CZ")
            SetAnalyzerAbilities(True, True, False, True)
            SetAnalyzerScore(70)

            SetPluginAuthor("VM")
            SetPluginVersion("1.0")
        End Sub

        Public Overrides Function CheckDependencies(ByRef outStatus As String) As Boolean
            If Not File.Exists(p_DBFilePath) Then
                outStatus = "Not found: " & p_DBFilePath
                Return False
            End If

            If Not File.Exists(p_DBUnmeanFile) Then
                outStatus = "Not found: " & p_DBUnmeanFile
                Return False
            End If

            outStatus = "OK"
            Return True
        End Function

        Public Overrides Function Initialize() As Boolean
            If Not LoadDBFile(p_DBFilePath) Then
                Me.ThrowInitError("Could not read main db file: " & p_DBUnmeanFile, Nothing)
                Return False
            End If

            If Not LoadUnmeaningfullWords(p_DBUnmeanFile) Then
                Me.ThrowInitError("Could not read unmeaningful db file: " & p_DBUnmeanFile, Nothing)
                Return False
            End If

            Return Me.InitOK()
        End Function

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            Return Nothing
        End Function

        Public Overrides Function GetWordType(ByVal sWord As String) As QITADataTypes.PartOfSpeechType
            Me.CheckIfInitialized()

            Dim sType As String = Nothing

            If IsNumeric(sWord) Then
                Return PartOfSpeechType.NUMBER
            End If

            If ParseResult(GetResult(sWord), Nothing, sType) Then
                Return ParseResultWordType(sType)
            End If

            Return PartOfSpeechType.UNKNOWN
        End Function

        Public Overrides Function LemmatizeWord(ByVal sWord As String) As String
            Me.CheckIfInitialized()

            Dim sLemma As String = Nothing

            If IsNumeric(sWord) Then
                Return sWord
            End If

            If ParseResult(GetResult(sWord), sLemma, Nothing) Then
                Return sLemma
            End If

            Return MakeUnknownLemmaOutput(sWord)
        End Function

        Public Overrides Function IsWordMeaningful(ByVal sWord As String) As Boolean
            Me.CheckIfInitialized()

            If IsUnmeaningDbOK() Then
                Return Not p_UnmeaningfullHashSet.Contains(LemmatizeWord(sWord))
            End If

            Return True
        End Function

        Private Function IsLemmatizerOk() As Boolean
            If IsAny(p_HashTable) Then
                Return CBool(p_HashTable.Count)
            End If

            Return False
        End Function

        Private Function IsUnmeaningDbOK() As Boolean
            If IsAny(p_UnmeaningfullHashSet) Then
                Return CBool(p_UnmeaningfullHashSet.Count)
            End If

            Return False
        End Function

        Private Function GetResult(ByVal sWord As String) As String
            If IsLemmatizerOk() Then
                If p_HashTable.ContainsKey(sWord) Then
                    Return p_HashTable(sWord)
                End If
            End If

            Return Nothing
        End Function

        Private Function ParseResult(ByVal sResult As String, ByRef sOutLemma As String, ByRef sOutType As String) As Boolean
            If StrIsAny(sResult) Then
                Dim s() As String = Split(sResult, "::{")

                If s.Count > 1 Then
                    sOutLemma = s(0)
                    sOutType = StrMidCharTerm(sResult, "{", "}")
                    Return True
                End If
            End If

            Return False
        End Function

        Private Function ParseResultWordType(ByVal sTypeResult As String) As PartOfSpeechType
            'A  adjektivum (přídavné jméno) 
            'C  numerál (číslovka, nebo číselný výraz s číslicemi) 
            'D  (adverbium(příslovce))
            'I  (interjekce(citoslovce))
            'J  (konjunkce(spojka))
            'N  substantivum (podstatné jméno) 
            'P  (pronomen(zájmeno))
            'R  (prepozice(předložka))
            'T  (partikule(částice))
            'V  (verbum(sloveso))
            'X  neznámý, neurčený, neurčitelný slovní druh 
            'Z  interpunkce, hranice věty 

            Select Case sTypeResult
                Case "A"
                    Return PartOfSpeechType.ADJECTIVE
                Case "C"
                    Return PartOfSpeechType.NUMBER
                Case "D"
                    Return PartOfSpeechType.ADVERB
                Case "I"
                    Return PartOfSpeechType.INTERJECTION
                Case "J"
                    Return PartOfSpeechType.CONJUNCTION
                Case "N"
                    Return PartOfSpeechType.NOUN
                Case "P"
                    Return PartOfSpeechType.PRONOUN
                Case "R"
                    Return PartOfSpeechType.PREPOSITION
                Case "T"
                    Return PartOfSpeechType.PARTICLE
                Case "V"
                    Return PartOfSpeechType.VERB
                Case Else
                    Return PartOfSpeechType.UNKNOWN
            End Select
        End Function

        Private Function LoadDBFile(ByVal sFile As String) As Boolean
            If IO.File.Exists(sFile) Then
                Dim fs As New IO.FileStream(sFile, IO.FileMode.Open)
                Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                p_HashTable = bf.Deserialize(fs)
                fs.Close()

                Return True
            End If

            Return False
        End Function

        Private Function LoadUnmeaningfullWords(ByVal sFile As String) As Boolean
            Dim sContent As String = Nothing

            If GetFileTextContent(sFile, sContent, System.Text.Encoding.UTF8, Nothing) Then
                Dim sWords() As String = sContent.Split(",")

                p_UnmeaningfullHashSet = New HashSet(Of String)

                For Each s As String In sWords
                    p_UnmeaningfullHashSet.Add(Trim(s))
                Next

                Return True
            End If
        End Function
    End Class

    Public Class LemmatizerCzechCorpusAndMajka
        Inherits QITAMorphoAnalyzerBase
        Private p_Majka As LemmatizerCzechMajka = New LemmatizerCzechMajka
        Private p_Korpus As LemmatizerCzechCorpusStatic = New LemmatizerCzechCorpusStatic

        Public Sub New()
            SetAnalyzerName("Majka+Corpus")
            SetAnalyzerAuthor("Pavel Šmerk (MUNI), Czech-National-Corpus www.korpus.cz")
            SetAnalyzerDescription("Compounded lemmatizer based on 'Czech-National-Corpus Static' and 'Majka' (in same order).")
            SetAnalyzerLanguage("CZ")
            SetAnalyzerAbilities(True, True, False, True)
            SetAnalyzerScore(80)

            SetPluginAuthor("VM")
            SetPluginVersion("1.0")
        End Sub

        Public Overrides Function CheckDependencies(ByRef outStatus As String) As Boolean
            If Not p_Majka.CheckDependencies(outStatus) Then
                Return False
            End If

            If Not p_Korpus.CheckDependencies(outStatus) Then
                Return False
            End If

            outStatus = "OK"
            Return True
        End Function

        Public Overrides Function Initialize() As Boolean
            If p_Majka.Initialize() AndAlso p_Korpus.Initialize() Then
                Return Me.InitOK()
            End If
        End Function

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            Return Nothing
        End Function

        Public Overrides Function GetWordType(ByVal sWord As String) As QITADataTypes.PartOfSpeechType
            Dim e As PartOfSpeechType
            e = p_Korpus.GetWordType(sWord)

            If e = PartOfSpeechType.UNKNOWN Then
                e = p_Majka.GetWordType(sWord)
            End If

            Return e
        End Function

        Public Overrides Function LemmatizeWord(ByVal sWord As String) As String
            Dim e As String
            e = p_Korpus.LemmatizeWord(sWord)

            If IsLemmaUnknown(e) Then
                e = p_Majka.LemmatizeWord(sWord)
            End If

            Return e
        End Function

        Public Overrides Function IsWordMeaningful(ByVal sWord As String) As Boolean
            Return p_Korpus.IsWordMeaningful(sWord)
        End Function
    End Class

    Public Class LemmatizerEnglishAlexanderPakMorphology
        Inherits QITAGenericPipeMorphoAnalyzer
        Private _LemmatizerPath As String = GetQITAAnalyzersDirectory() & "\AlexanderPaksMorphology\lemmatize.py"

        Public Sub New()
            SetAnalyzerName("Alexander Pak's Morphology")
            SetAnalyzerLanguage("EN")
            SetAnalyzerAuthor("Alexander Pak")
            SetAnalyzerDescription("")
            SetAnalyzerAbilities(True, False, False, False)
            SetAnalyzerScore(60)

            SetPluginVersion("1.0")
            SetPluginAuthor("VM")
            SetPluginRequisites("Python")
        End Sub

        Public Overrides Function CheckDependencies(ByRef outStatus As String) As Boolean
            If Not File.Exists(_LemmatizerPath) Then
                outStatus = "Not found: " & _LemmatizerPath
                Return False
            End If

            If Not CheckIfPythonIsInstalled() Then
                outStatus = "Python is not installed!"
                Return False
            End If

            outStatus = "OK"
            Return True
        End Function

        Public Overrides Function Initialize() As Boolean
            Dim e As Exception = Nothing

            If Not MyBase.CreatePipeWithScript(_LemmatizerPath, Nothing, Encoding.ASCII, e) Then
                Me.ThrowInitError("Could not create pipe.", e)
                Return False
            End If

            Return Me.InitOK()
        End Function

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            Return Nothing
        End Function

        Public Overrides Function LemmatizeWord(ByVal sWord As String) As String
            Me.CheckIfInitialized()

            Dim sOutput As String = Me.AskAnalyzer(sWord)

            If StrIsAny(sOutput) Then
                Dim sLemma As String = StrMidCharTerm(sOutput, "'", "'")

                If StrIsAny(sLemma) Then
                    Return sLemma
                End If
            End If

            Return MakeUnknownLemmaOutput(sWord)
        End Function

        Public Overrides Function IsWordMeaningful(ByVal sWord As String) As Boolean
            Return True
        End Function

        Public Overrides Function GetWordType(ByVal sWord As String) As QITADataTypes.PartOfSpeechType
            Return PartOfSpeechType.UNKNOWN
        End Function
    End Class

#End Region

#Region "MorphoAnalyzers: Natural Language -- NLTK"
    Public MustInherit Class MorphoAnalyzerNLTKStemmerOnly
        Inherits QITAGenericPipeMorphoAnalyzer
        Private _LemmatizerPath As String = GetQITAAnalyzersDirectory() & "\nltk\nltkbridge_stemmerOnly.py"
        Private _LanguageMarker As String = Nothing

        Public Sub New(ByVal sLanguageName As String)
            SetAnalyzerAuthor("NLTK")
            SetAnalyzerDescription("Stemmer only - http://nltk.org/")
            SetAnalyzerAbilities(True, False, False, False)
            SetAnalyzerScore(80)
            SetAnalyzerLanguage(sLanguageName)

            SetPluginVersion("1.0")
            SetPluginAuthor("VM")
            SetPluginRequisites("Python, NLTK")

            _LanguageMarker = "[" & Me.AnalyzerTargetLanguage & "]"
        End Sub

        Public Overrides Function CheckDependencies(ByRef outStatus As String) As Boolean
            If Not File.Exists(_LemmatizerPath) Then
                outStatus = "Not found: " & _LemmatizerPath
                Return False
            End If

            If Not CheckIfPythonIsInstalled() Then
                outStatus = "Python not installed!"
                Return False
            End If

            outStatus = "OK"
            Return True
        End Function

        Public Overrides Function Initialize() As Boolean
            Dim e As Exception = Nothing

            If Not MyBase.CreatePipeWithScript(_LemmatizerPath, Nothing, Encoding.ASCII, e) Then
                Me.ThrowInitError("Could not create pipe.", e)
                Return False
            End If

            Return Me.InitOK()
        End Function

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            Return Nothing
        End Function

        Public Overrides Function LemmatizeWord(ByVal sWord As String) As String
            Me.CheckIfInitialized()

            Dim sOutput As String = Me.AskAnalyzer(_LanguageMarker & EncodeUnicodeToSequence(sWord))

            If StrIsAny(sOutput) Then
                Return DecodeUnicodeSequences(sOutput)
            End If

            Return MakeUnknownLemmaOutput(sWord)
        End Function

        Public Overrides Function IsWordMeaningful(ByVal sWord As String) As Boolean
            Return True
        End Function
    End Class

    Public Class MorphoAnalyzerNLTKEnglish
        Inherits QITAGenericPipeMorphoAnalyzer
        Private _LemmatizerPath As String = GetQITAAnalyzersDirectory() & "\nltk\en_nltkbridge.py"

        Public Sub New()
            SetAnalyzerName("NLTK")
            SetAnalyzerLanguage("EN")
            SetAnalyzerAuthor("NLTK")
            SetAnalyzerDescription("http://nltk.org/")
            SetAnalyzerAbilities(True, True, True, True)
            SetAnalyzerScore(100)

            SetPluginVersion("1.0")
            SetPluginAuthor("VM")
            SetPluginRequisites("Python, NLTK")
        End Sub

        Public Overrides Function CheckDependencies(ByRef outStatus As String) As Boolean
            If Not File.Exists(_LemmatizerPath) Then
                outStatus = "Not found: " & _LemmatizerPath
                Return False
            End If

            If Not CheckIfPythonIsInstalled() Then
                outStatus = "Python not installed!"
                Return False
            End If

            outStatus = "OK"
            Return True
        End Function

        Public Overrides Function Initialize() As Boolean
            Dim e As Exception = Nothing

            If Not MyBase.CreatePipeWithScript(_LemmatizerPath, Nothing, Encoding.ASCII, e) Then
                Me.ThrowInitError("Could not create pipe.", e)
                Return False
            End If

            Return Me.InitOK()
        End Function

        Public Overrides Function TokenizeText(ByVal sText As String) As String()
            Dim tokenizer As New PipedHugeDataExecution(GetQITAAnalyzersDirectory() & "\nltk\en_tokenizer.py", Nothing, Nothing, Encoding.ASCII)

            Dim sOutput As String = tokenizer.TransferHugeData(sText)

            '['Hello', 'my', 'little', 'piglet', '!']
            If StrIsAny(sOutput) Then
                Dim tokens As MatchCollection = Regex.Matches(sOutput, "('[^<]+?')|(""[^<]+?"")")
                Dim sTokens(tokens.Count - 1) As String
                Dim sTemp As String

                For i As Integer = 0 To tokens.Count - 1
                    sTemp = DecodeUnicodeSequences(tokens(i).Value)
                    sTemp = sTemp.Remove(0, 1)
                    sTemp = sTemp.Remove(sTemp.Length - 1, 1)

                    sTokens(i) = sTemp
                Next

                Return sTokens
            End If

            Return Nothing
        End Function

        Public Overrides Function LemmatizeWord(ByVal sWord As String) As String
            Me.CheckIfInitialized()

            Dim sOutput As String = Me.AskAnalyzer("{LM}" & sWord)

            If StrIsAny(sOutput) Then
                Return DecodeUnicodeSequences(sOutput)
            End If

            Return MakeUnknownLemmaOutput(sWord)
        End Function

        Public Overrides Function IsWordMeaningful(ByVal sWord As String) As Boolean
            Me.CheckIfInitialized()

            Select Case LemmatizeWord(sWord)
                Case "be", "is", "are"
                    Return False
            End Select

            Dim sOutput As String = Me.AskAnalyzer("{PT}" & sWord)

            Select Case sOutput
                Case "MD", "EX"
                    Return False
            End Select

            Return True
        End Function

        Public Overrides Function GetWordType(ByVal sWord As String) As QITADataTypes.PartOfSpeechType
            Me.CheckIfInitialized()

            Dim sOutput As String = Me.AskAnalyzer("{PT}" & sWord)

            Select Case sOutput
                Case "CC"
                    'CC	coordinating conjunction	and
                    Return PartOfSpeechType.CONJUNCTION

                Case "CD"
                    'CD	cardinal number	1, third
                    Return PartOfSpeechType.NUMBER

                Case "DT"
                    'DT	determiner	the
                    Return PartOfSpeechType.DETERMINATION

                Case "EX"
                    'EX	existential there	there is
                    Return PartOfSpeechType.VERB

                Case "FW"
                    'FW	foreign word	d’hoevre
                    Return PartOfSpeechType.UNKNOWN

                Case "IN"
                    'IN	preposition/subordinating conjunction	in, of, like
                    Return PartOfSpeechType.PREPOSITION

                Case "JJ", "JJR", "JJS"
                    'JJ	adjective	big
                    'JJR	adjective, comparative	bigger
                    'JJS	adjective, superlative	biggest
                    Return PartOfSpeechType.ADJECTIVE

                Case "MD"
                    'MD	modal	could, will
                    Return PartOfSpeechType.VERB

                Case "NN", "NNS", "NNP", "NNPS"
                    'NN	noun, singular or mass	door
                    'NNS	noun plural	doors
                    'NNP	proper noun, singular	John
                    'NNPS	proper noun, plural	Vikings
                    Return PartOfSpeechType.NOUN

                Case "PDT"
                    'PDT	predeterminer	both the boys
                    Return PartOfSpeechType.PREDETERMINATION

                Case "POS"
                    'POS	possessive ending	friend‘s
                    Return PartOfSpeechType.PARTICLE

                Case "PRP", "PRP$"
                    'PRP	personal pronoun	I, he, it
                    'PRP$	possessive pronoun	my, his
                    Return PartOfSpeechType.PRONOUN

                Case "RB", "RBR", "RBS"
                    'RB	adverb	however, usually, naturally, here, good
                    'RBR	adverb, comparative	better
                    'RBS	adverb, superlative	best
                    Return PartOfSpeechType.ADVERB

                Case "RP"
                    'RP	particle	give  up 
                    Return PartOfSpeechType.PARTICLE

                Case "TO"
                    'TO	to	to go, to him
                    Return PartOfSpeechType.PREPOSITION

                Case "UH"
                    'UH	interjection	uhhuhhuhh
                    Return PartOfSpeechType.INTERJECTION

                Case "VB", "VBD", "VBG", "VBN", "VBP", "VBZ"
                    'VB	verb, base form	take
                    'VBD	verb, past tense	took
                    'VBG	verb, gerund/present participle	taking
                    'VBN	verb, past participle	taken
                    'VBP	verb, sing. present, non-3d	take
                    'VBZ	verb, 3rd person sing. present	takes
                    Return PartOfSpeechType.VERB

                Case "WDT"
                    'WDT	wh-determiner	which
                    'WP	wh-pronoun	who, what
                    'WP$	possessive wh-pronoun	whose
                    Return PartOfSpeechType.PRONOUN

                Case "WRB"
                    'WRB	wh-abverb	where, when
                    Return PartOfSpeechType.ADVERB

                Case Else
                    Return PartOfSpeechType.UNKNOWN
            End Select
        End Function

    End Class

    Public Class MorphoAnalyzerNLTKDeutch
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("DE")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKArabic
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("AR")
            MyBase.SetAnalyzerName("NLTK ISRI Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKRussian
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("RU")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKFrench
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("FR")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKSpanish
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("ES")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKItalian
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("IT")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKRomanian
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("RO")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKPortuguese
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("PT")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKDutch
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("NL")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKSwedish
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("SE")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKNorwegian
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("NO")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKDenmark
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("DK")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class

    Public Class MorphoAnalyzerNLTKFinnish
        Inherits MorphoAnalyzerNLTKStemmerOnly

        Public Sub New()
            MyBase.New("FI")
            MyBase.SetAnalyzerName("NLTK Snowball Stemmer")
        End Sub
    End Class
#End Region

#Region "MorphoAnalyzers: Natural Language -- Text-Processing.Com"
    Public Class MorphoAnalyzerTextProcessingComEn
        Inherits MorphoAnalyzerTextProcessingCom

        Public Sub New()
            MyBase.New("english", "wordnet")
            MyBase.SetAnalyzerAbilities(True, False, True, False)
            MyBase.SetAnalyzerScore(90)
        End Sub
    End Class

    Public Class MorphoAnalyzerTextProcessingComAr
        Inherits MorphoAnalyzerTextProcessingCom

        Public Sub New()
            MyBase.New("arabic", "isri")
            MyBase.SetAnalyzerAbilities(True, False, True, False)
            MyBase.SetAnalyzerScore(90)
        End Sub
    End Class

    Public Class MorphoAnalyzerTextProcessingComRu
        Inherits MorphoAnalyzerTextProcessingCom

        Public Sub New()
            MyBase.New("russian", "snowball")
            MyBase.SetAnalyzerAbilities(True, False, True, False)
            MyBase.SetAnalyzerScore(90)
        End Sub
    End Class
#End Region
End Namespace

Namespace QITAPostProcessors
    Public MustInherit Class NGrammizerBase
        Inherits QITAPostProcessorBase

        Protected Sub NGramize(ByRef text As IQITAText, ByVal nGramSize As Integer)
            Dim i As Integer
            Dim n As Integer
            Dim sNewText As New StringBuilder(text.TextData.Length * nGramSize)
            Dim sTokens() As String = text.Tokens()

            For i = 0 To sTokens.Count - nGramSize
                For n = 0 To nGramSize - 1
                    sNewText.Append(sTokens(i + n) + "_")
                Next

                sNewText.AppendLine()
            Next

            text.TextData = sNewText.ToString()
            text.AssignedLemmatizer = Nothing           'ensure to not lemmatize n-grams
            text.AssignedTokenizer = New GenericLineTokenizer()
        End Sub
    End Class

    Public Class BiGrammizer
        Inherits NGrammizerBase

        Public Sub New()
            MyBase.SetInfo("2-Gram", "Bi-Gram creator", "N-Grams")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.NGramize(text, 2)
        End Function
    End Class

    Public Class TriGrammizer
        Inherits NGrammizerBase

        Public Sub New()
            MyBase.SetInfo("3-Gram", "Tri-Gram creator", "N-Grams")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.NGramize(text, 3)
        End Function
    End Class

    Public Class TetraGrammizer
        Inherits NGrammizerBase

        Public Sub New()
            MyBase.SetInfo("4-Gram", "Tetra-Gram creator", "N-Grams")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.NGramize(text, 4)
        End Function
    End Class

    Public Class PentaGrammizer
        Inherits NGrammizerBase

        Public Sub New()
            MyBase.SetInfo("5-Gram", "Penta-Gram creator", "N-Grams")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.NGramize(text, 5)
        End Function
    End Class

    Public Class HeptaGrammizer
        Inherits NGrammizerBase

        Public Sub New()
            MyBase.SetInfo("6-Gram", "Hepta-Gram creator", "N-Grams")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.NGramize(text, 6)
        End Function
    End Class

    Public Class SeptaGrammizer
        Inherits NGrammizerBase

        Public Sub New()
            MyBase.SetInfo("7-Gram", "Septa-Gram creator", "N-Grams")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.NGramize(text, 7)
        End Function
    End Class

    Public Class UserNGrammizer
        Inherits NGrammizerBase

        Private _N As Integer = 2

        Public Sub New()
            MyBase.SetInfo("N-Gram", "User defined n-gram creator", "N-Grams")
        End Sub

        Public Overrides Function InitializePostProcessor() As Boolean
            Dim n As Integer

            If My.Settings.Last_NGramSize <= 0 Then
                Do
                    Dim s As String
                    s = InputBox("Please, write a number of n grams you would like to use (MAX 10 000):", , "5")
                    s = Trim(Replace(s, " ", Nothing))

                    If IsNumber(s) Then
                        n = Val(s)

                        If (n > 0) AndAlso (n < 10000) Then
                            Exit Do
                        End If
                    End If
                Loop

                My.Settings.Last_NGramSize = n
            End If

            _N = My.Settings.Last_NGramSize
        End Function

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.NGramize(text, _N)
        End Function
    End Class

    Public MustInherit Class TextTokenReducerN
        Inherits QITAPostProcessorBase

        Protected Sub ReduceText(ByRef text As IQITAText, ByVal newTokensCount As Integer)
            Dim newText As New StringBuilder(newTokensCount * 8)
            Dim tokens() As String = text.Tokens()

            For i As Integer = 0 To Math.Min(newTokensCount - 1, tokens.Count - 1)
                newText.Append(tokens(i) & " ")
            Next

            text.TextData = newText.ToString().Trim()
        End Sub
    End Class

    Public Class TextTokenReducer100
        Inherits TextTokenReducerN

        Public Sub New()
            MyBase.SetInfo("Reduce text to: First 100 Tokens.", "Reduces text size into given number of tokens.", "Reducing")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.ReduceText(text, 100)
        End Function
    End Class

    Public Class TextTokenReducer1000
        Inherits TextTokenReducerN

        Public Sub New()
            MyBase.SetInfo("Reduce text to: First 1 000 Tokens.", "Reduces text size into given number of tokens.", "Reducing")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.ReduceText(text, 1000)
        End Function
    End Class

    Public Class TextTokenReducer10000
        Inherits TextTokenReducerN

        Public Sub New()
            MyBase.SetInfo("Reduce text to: First 10 000 Tokens.", "Reduces text size into given number of tokens.", "Reducing")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.ReduceText(text, 10000)
        End Function
    End Class

    Public Class TextTokenReducer100000
        Inherits TextTokenReducerN

        Public Sub New()
            MyBase.SetInfo("Reduce text to: First 100 000 Tokens.", "Reduces text size into given number of tokens.", "Reducing")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            MyBase.ReduceText(text, 100000)
        End Function
    End Class

    Public Class TextTokenReducerNUser
        Inherits TextTokenReducerN

        Public Sub New()
            MyBase.SetInfo("Reduce text to: User defined First Tokens.", "Reduces text size into given number of tokens.", "Reducing")
        End Sub

        Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
            Dim iReduceTo As Integer

            If My.Settings.Last_TextReduceSize <= 0 Then
                Do
                    Dim n As String = InputBox("Please specify the number of tokens to reduce original text:", "PostProcessor: Reducing text to given number of tokens", "100")

                    If IsNumber(n) Then
                        iReduceTo = CInt(n)
                        Exit Do
                    End If
                Loop

                My.Settings.Last_TextReduceSize = iReduceTo
            End If

            MyBase.ReduceText(text, My.Settings.Last_TextReduceSize)
        End Function
    End Class


    'Public MustInherit Class WindowMakerBase
    '    Inherits QITAPostProcessorBase

    '    Protected Sub CreateWindows(ByRef text As IQITAText, ByVal nWindowSize As Integer)
    '        Dim i As Integer = 0
    '        Dim j As Integer = 0
    '        Dim tokens() As String = text.Tokens()
    '        Dim windows As New StringBuilder(tokens.Count * 8)

    '        For i = 0 To tokens.Count - nWindowSize Step nWindowSize
    '            For j = 0 To nWindowSize - 1
    '                windows.Append(tokens(i + j) & "_")
    '            Next

    '            windows.AppendLine()
    '        Next

    '        text.TextData = windows.ToString()
    '        text.AssignedLemmatizer = Nothing           'ensure to not lemmatize n-grams
    '        text.AssignedTokenizer = New GenericLineTokenizer()
    '    End Sub
    'End Class

    'Public Class TextWindowMaker
    '    Inherits WindowMakerBase

    '    Public Sub New()
    '        MyBase.SetInfo("Window Maker: 3", "Creates windows of given length.", "Window Makers")
    '    End Sub

    '    Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
    '        MyBase.CreateWindows(text, 3)
    '    End Function
    'End Class

    'Public Class TextWindowMakerUserN
    '    Inherits WindowMakerBase

    '    Public Sub New()
    '        MyBase.SetInfo("Window Maker: N", "Creates windows of given length.", "Window Makers")
    '    End Sub

    '    Public Overrides Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean
    '        Dim iWindowSize As Integer = My.Settings.Last_WindowMakerLength

    '        If My.Settings.Last_WindowMakerLength <= 0 Then
    '            Do
    '                Dim n As String = InputBox("Please specify the number of tokens to reduce original text:", "PostProcessor: Reducing text to given number of tokens", "100")

    '                If IsNumber(n) Then
    '                    iWindowSize = CInt(n)
    '                    Exit Do
    '                End If
    '            Loop

    '            My.Settings.Last_WindowMakerLength = iWindowSize
    '        End If

    '        MyBase.CreateWindows(text, iWindowSize)
    '    End Function
    'End Class
End Namespace