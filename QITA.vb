Imports System.Text.RegularExpressions
Imports QITA_OLTK.QITAInterfaces
Imports QITA_OLTK.QITADataTypes
Imports QITA_OLTK.QITAInterfaceImplementations
Imports QITA_OLTK.QITAIndexes
Imports QITA_OLTK.QITAMorphoAnalyzers
Imports System

Namespace QITAInterfaces
    Public Enum IQITAIndexRequisities
        Non = 0
        RequiresLemmatizer = 1
        RequiresPOSTagger = &H10
        RequiresTokenizer = &H100
    End Enum

    ''' <summary>
    ''' Provides interface for general TEXT class used in QITA.
    ''' </summary>
    Public Interface IQITAText
        '== General Text Informations   ======================================
        Property TextName() As String
        Property TextData() As String
        Property TextDescription() As String

        ''' <summary>
        ''' File path.
        ''' </summary>
        Property TextFile() As String

        ''' <summary>
        ''' Gets or sets Lemmatizer used for lemmatizing text.
        ''' </summary>
        Property AssignedLemmatizer() As IQITAMorphologyAnalyzer

        ''' <summary>
        ''' Gets or sets POS Tagger used for tagging text.
        ''' </summary>
        Property AssignedPOSTagger() As IQITAMorphologyAnalyzer

        ''' <summary>
        ''' Gets or sets Tokenizer used for tokenizing text.
        ''' </summary>
        Property AssignedTokenizer() As IQITAMorphologyAnalyzer
        Property Encoding() As String

        '== Text Computation Cache Functions and Properties ==================
        Sub Invalidate()

        Sub ClearContent()

        ''' <summary>
        ''' Sub called before computing indexes on text.
        ''' </summary>
        Sub InitializeBeforeComputing()

        ''' <summary>
        ''' Sub called after Text is Post-Processed (eg. reducing text size by post-processor might
        ''' require recalculating precalculated data).
        ''' </summary>
        Sub InitializeAfterPostProcessing()

        ''' <summary>
        ''' Adds a result to list of computed results available for enumeration and caching.
        ''' </summary>
        ''' <param name="result">Result to add.</param>
        ''' <returns>Result.</returns>
        Function AddResult(ByRef result As IQITAResult) As IQITAResult

        ''' <summary>
        ''' Retreives result of given index type from already computed results.
        ''' </summary>
        ''' <param name="index">Index type.</param>
        ''' <returns>Index result.</returns>
        Function GetResultByIndex(ByRef index As Type) As IQITAResult

        ''' <summary>
        ''' Retreives result of given index type from already computed results.
        ''' </summary>
        ''' <returns>Index result.</returns>
        Function GetResultByIndex(Of T)() As IQITAResult

        ''' <summary>
        ''' Retreives result of given index name from already computed results.
        ''' </summary>
        ''' <returns>Result.</returns>
        Function GetResultByIndex(ByRef indexName As String) As IQITAResult

        ''' <summary>
        ''' Retreives whether index of given type has been already computed for Text.
        ''' </summary>
        ''' <param name="index">Index type.</param>
        ''' <param name="outResult">Retreived result</param>
        ''' <returns>TRUE if appropriate result found.</returns>
        Function IsIndexComputedAlready(ByRef index As IQITAIndex, ByRef outResult As IQITAResult) As Boolean

        ''' <summary>
        ''' Computes given index for Text.
        ''' </summary>
        ''' <param name="index">Instance of Index class.</param>
        ''' <returns>Computation Result.</returns>
        Function ComputeIndex(ByRef index As IQITAIndex) As IQITAResult

        ''' <summary>
        ''' List of computed results for Text. This list is used by IsIndexComputedAlready function and GetResultByIndex.
        ''' </summary>
        ''' <returns>List of results.</returns>
        Property ReadyResults() As List(Of IQITAResult)

        '== Text Loading Functions  =====================================
        ''' <summary>
        ''' Loads Text-Data from given text file.
        ''' </summary>
        ''' <param name="sFile">File path.</param>
        ''' <param name="sOutError">Output string with error description.</param>
        ''' <returns>True if data succesfully loaded.</returns>
        Function LoadFromFile(ByVal sFile As String, Optional ByRef sOutError As String = Nothing) As Boolean

        ''' <summary>
        ''' Reloads file with given encoding.
        ''' </summary>
        ''' <param name="sEncodingName">File encoding.</param>
        ''' <returns>TRUE if success.</returns>
        Function ReLoadFile(ByVal sEncodingName As String) As Boolean

        ''' <summary>
        ''' Reloads file with last used encoding.
        ''' </summary>
        Function ReLoadFile() As Boolean

        ''' <summary>
        ''' Retreives short sample of text.
        ''' </summary>
        Function GetPreview() As String

        ''' <summary>
        ''' Retreives default encoding used by LoadFromFile function.
        ''' </summary>
        ''' <returns>Name of encoding.</returns>
        Function GetDefaultEncoding() As String

        '== Basic Linguistic Functions  =================================
        ''' <summary>
        ''' Returns zero-based array of text tokens.
        ''' </summary>
        ''' <returns>Zero-based array of text tokens.</returns>
        Function Tokens() As String()
        ''' <summary>
        ''' Returns zero-based array of text types.
        ''' </summary>
        ''' <returns>Zero-based array of text types.</returns>
        ''' <remarks></remarks>
        Function Types() As String()

        Function TokenCount() As Integer
        Function TypeCount() As Integer

        ''' <summary>
        ''' Retreives Token count.
        ''' </summary>
        ''' <returns>Token Count.</returns>
        Function N() As Integer

        ''' <summary>
        ''' Retreives Type Count.
        ''' </summary>
        ''' <returns>Type Count.</returns>
        Function V() As Integer

        ''' <summary>
        ''' Creates basic text table containing informations for each word:
        '''  - Word position in text.
        '''  - Word frequency.
        '''  - Word.
        '''  - Word rank.
        '''  - Word averaged rank.
        '''  - Word lemma (optional).
        '''  - Word type (optional).
        ''' </summary>
        ''' <returns>One-indexed table containing all informations above.</returns>
        Function GetTextTable() As QITATextTable

        ''' <summary>
        ''' Creates Frequency analyzis of text.
        ''' </summary>
        ''' <returns>Returns [word]->[frequency] index table.</returns>
        ''' <remarks></remarks>
        Function GetWordFrequencyTable() As QITAWordFrequencyTable

        ''' <summary>
        ''' Creates Frequency analyzis of text.
        ''' </summary>
        ''' <returns>Returns [rank]->[frequency] one-based array.</returns>
        ''' <remarks></remarks>
        Function GetFrequencyPositiveArray() As Integer()

        ''' <summary>
        ''' Retreives frequency at given rank.
        ''' </summary>
        ''' <returns>Frequency.</returns>
        Function f(ByVal index As Integer) As Long

        ''' <summary>
        ''' Creates Frequency to Rank-Averaged lookup table: [frequency]->[averaged rank that belongs to frequency].
        ''' </summary>
        ''' <returns>Lookup table: [frequency]->[its averaged rank].</returns>
        ''' <remarks>Averaged-indexes are based on one-based (positive) index table.</remarks>
        Function GetFrequencyToAveragedRankTable() As QITAPositiveArray

        ''' <summary>
        ''' Retreives (averaged) rank for given frequency.
        ''' </summary>
        ''' <remarks>Ranks are averaged.</remarks>
        Function FrequencyToRank(ByVal frequency As Integer) As Double

        ''' <summary>
        ''' Retreives label for tokens: "lemma" whether lemmatizer is set, "token" otherwise.
        ''' </summary>
        Function GetWordOrLemmaLabel() As String

        ''' <summary>
        ''' Clears cache.
        ''' </summary>
        ''' <returns>TRUE when Cache has been cleared.</returns>
        Function ClearCache() As Boolean
    End Interface

    ''' <summary>
    ''' Provides interface for results used by indexes and other calculations in QITA.
    ''' </summary>
    Public Interface IQITAResult
        Function ToCellString() As String
        Function CompareWith(ByRef anotherResult As IQITAResult) As IQITAResult

        Property Value()
        Property ComplexValue()

        ''' <summary>
        ''' Gets reference to index class.
        ''' </summary>
        ReadOnly Property IndexReference() As IQITAIndex

        ''' <summary>
        ''' Gets reference to text class.
        ''' </summary>
        ReadOnly Property TextReference() As IQITAText

        ''' <summary>
        ''' Gets name of index or other source of result.
        ''' </summary>
        ReadOnly Property ResultName() As String

        ''' <summary>
        ''' Gets whether the result is not important for showin in results table.
        ''' </summary>
        ReadOnly Property IsSecondary() As Boolean

        ''' <summary>
        ''' Gets whether the result is complex and needs complex displaying (eg. table, array, ...)
        ''' or simple (number, string, ...).
        ''' </summary>
        ReadOnly Property IsComplex() As Boolean
    End Interface

    ''' <summary>
    ''' Provides interface for indexes or other calculation classes in QITA.
    ''' </summary>
    Public Interface IQITAIndex
        ''' <summary>
        ''' Gets name of index.
        ''' </summary>
        ReadOnly Property IndexName() As String

        ''' <summary>
        ''' Gets short name of index or it's abbrevation.
        ''' </summary>
        ReadOnly Property IndexShortName() As String

        ''' <summary>
        ''' Gets author of index.
        ''' </summary>
        ReadOnly Property IndexAuthor() As String

        ''' <summary>
        ''' Gets author's description of Index.
        ''' </summary>
        ReadOnly Property IndexDescription() As String

        ''' <summary>
        ''' Gets author's comments for Index.
        ''' </summary>
        ReadOnly Property IndexComments() As String

        ''' <summary>
        ''' Gets general group for Index.
        ''' </summary>
        ReadOnly Property IndexGroup() As String

        ''' <summary>
        ''' Gets whether the result is complex (eg. table, array, ...) or simple (number, string, ...).
        ''' </summary>
        ReadOnly Property HasComplexResults() As Boolean

        ''' <summary>
        ''' Gets whether this index has comparable results or not.
        ''' </summary>
        ReadOnly Property HasComparableResults() As Boolean

        ''' <summary>
        ''' Gets whether the index has results that are not important for showing in results table.
        ''' </summary>
        ReadOnly Property IsSecondary() As Boolean

        ''' <summary>
        ''' Gets requisities for calculating this index.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Requisities() As IQITAIndexRequisities

        ''' <summary>
        ''' Tests whether Text has assigned all neccessary properties for calculating index.
        ''' </summary>
        ''' <param name="Text">Text to be tested.</param>
        ''' <returns>TRUE when index can be calculated, otherwise FALSE is returned.</returns>
        Function TestRequisitiesForText(ByRef Text As IQITAText) As Boolean

        ''' <summary>
        ''' Applies calculation procedure of index on given text.
        ''' </summary>
        ''' <param name="TextData">Text for applying index.</param>
        ''' <returns>Index result.</returns>
        Function Calculate(ByRef TextData As IQITAText) As IQITAResult

        ''' <summary>
        ''' Calculates VAR(...) diffusion for statistical purposes.
        ''' </summary>
        Function CalculateDiffusion(ByRef result As IQITAResult) As IQITAResult

        ''' <summary>
        ''' Compares two results of index.
        ''' </summary>
        Function CompareResults(ByRef result1 As IQITAResult, ByRef result2 As IQITAResult) As IQITAResult

        Function ToString() As String
    End Interface

    ''' <summary>
    ''' Provides interface for morphology analyzers like lemmatizers, pos taggers etc.
    ''' </summary>
    Public Interface IQITAMorphologyAnalyzer
        ReadOnly Property AnalyzerName() As String
        ReadOnly Property AnalyzerDescription() As String
        ReadOnly Property AnalyzerAuthor() As String
        ReadOnly Property AnalyzerTargetLanguage() As String
        ReadOnly Property TokenizerReturnsLemmatizedTokens() As Boolean
        ReadOnly Property AnalyzerScore() As Integer

        ReadOnly Property PluginAuthor() As String
        ReadOnly Property PluginRequisites() As String
        ReadOnly Property PluginVersion() As String

        ReadOnly Property HasLemmatizationAbility() As Boolean
        ReadOnly Property HasPosTaggingAbility() As Boolean
        ReadOnly Property HasTokenizerAbility() As Boolean
        ReadOnly Property HasMeaningfulWordDetection() As Boolean

        ''' <summary>
        ''' Checks whether this morphological analyzer has all needed dependencies and is
        ''' ready to be used.
        ''' </summary>
        ''' <param name="outStatus">[OUTPUT] Status of dependencies.</param>
        ''' <returns>TRUE when morphoanalyzer is ready to use, otherwise FALSE is returned.</returns>
        Function CheckDependencies(ByRef outStatus As String) As Boolean

        ''' <summary>
        ''' Initializes lemmatizer before using. This method is called before
        ''' any of lemmatizer functions usage. Please use this method for initializing
        ''' lemmatizer rather than class constructor which has to serve for filling
        ''' lemmatizer properties.
        ''' </summary>
        ''' <returns>TRUE if initialization has been succesfull.</returns>
        Function Initialize() As Boolean

        ''' <summary>
        ''' Returns tokens of given text.
        ''' </summary>
        ''' <param name="sText">Text to tokenize.</param>
        ''' <returns>Token array.</returns>
        Function TokenizeText(ByVal sText As String) As String()

        ''' <summary>
        ''' Retreives lemma for given word.
        ''' </summary>
        ''' <param name="sWord">Word.</param>
        ''' <returns>Word in lemma form.</returns>
        Function LemmatizeWord(ByVal sWord As String) As String

        ''' <summary>
        ''' Retreives word type (Part of Speech) of give word.
        ''' </summary>
        ''' <param name="sWord">Word.</param>
        ''' <returns>Word type.</returns>
        Function GetWordType(ByVal sWord As String) As PartOfSpeechType

        ''' <summary>
        ''' Tests if word is meaningful.
        ''' </summary>
        ''' <param name="sWord">Word to be tested.</param>
        ''' <returns>TRUE if word has meaning.</returns>
        Function IsWordMeaningful(ByVal sWord As String) As Boolean

        ''' <summary>
        ''' Tests whether given lemma is marked as unknown.
        ''' </summary>
        ''' <param name="sLemma">Lemma to test.</param>
        ''' <returns>TRUE when lemma is marked as unknown.</returns>
        Function IsLemmaUnknown(ByVal sLemma As String) As Boolean
    End Interface

    ''' <summary>
    ''' Provides interface for text post processing like n-gram creators etc.
    ''' </summary>
    Public Interface IQITATextPostProcessors
        ReadOnly Property Name() As String
        ReadOnly Property Description() As String
        ReadOnly Property Group() As String

        ''' <summary>
        ''' Initializes post processor. Called before text computation is set up.
        ''' </summary>
        Function InitializePostProcessor() As Boolean

        ''' <summary>
        ''' Destructively modifies data in given IQITAText by given post processing procedure.
        ''' </summary>
        ''' <param name="text">IQITAText to modify.</param>
        ''' <returns></returns>
        Function PostProcess(ByRef text As IQITAText) As Boolean
    End Interface

    ''' <summary>
    ''' Provides interface for QITA projects.
    ''' </summary>
    Public Interface IQITAProject
        Property ProjectName() As String

        ''' <summary>
        ''' Initializes new project.
        ''' </summary>
        Function NewProject(ByVal sProjectName As String) As IQITAProject

        ''' <summary>
        ''' Returns all results of given index that have been computed for the texts in this project.
        ''' </summary>
        ''' <param name="sIndexName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetResultsOfIndex(ByVal sIndexName As String) As List(Of IQITAResult)

        ''' <summary>
        ''' Calculates all data in project.
        ''' </summary>
        ''' <returns>TRUE when calculation is succesful, else FALSE.</returns>
        Function Calculate() As Boolean

        ''' <summary>
        ''' Retreives list of texts used in this project.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Texts() As List(Of IQITAText)

        ''' <summary>
        ''' Retreives list of "selected" texts.
        ''' </summary>
        ReadOnly Property SelectedTexts() As List(Of IQITAText)

        ''' <summary>
        ''' Retreives list of classes of computed indexes for this project.
        ''' </summary>
        ReadOnly Property ComputedIndexes() As List(Of IQITAIndex)
        ReadOnly Property DataSource() As QITAProjectDataSource
    End Interface

    ''' <summary>
    ''' Provides interface for data types used in QITA.
    ''' </summary>
    Public Interface IQITADataType
        Function ToChartableData() As QITAChartableDataArray
    End Interface
End Namespace

Namespace QITAInterfaceImplementations
#Region "IQITA Interface Base Implementations"
    ''' <summary>
    ''' Implements IQITAResult interface and is dedicated to be inherited.
    ''' </summary>
    Public MustInherit Class QITAResultBase
        Implements IQITAResult

        Private p_IndexReference As IQITAIndex = Nothing
        Private p_TextReference As IQITAText = Nothing

        Public MustOverride Property Value() Implements IQITAResult.Value

        Public Overridable Property ComplexValue() As Object Implements IQITAResult.ComplexValue
            Get
                Return Nothing
            End Get
            Set(ByVal value As Object)
            End Set
        End Property

        Public ReadOnly Property ResultName() As String Implements IQITAResult.ResultName
            Get
                If IsAny(p_IndexReference) Then
                    Return p_IndexReference.IndexName
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property IndexReference() As IQITAIndex Implements IQITAResult.IndexReference
            Get
                Return p_IndexReference
            End Get
        End Property

        Public ReadOnly Property TextReference() As IQITAText Implements IQITAResult.TextReference
            Get
                Return p_TextReference
            End Get
        End Property

        Public MustOverride ReadOnly Property IsComplex() As Boolean Implements IQITAResult.IsComplex

        Public ReadOnly Property IsSecondary() As Boolean Implements IQITAResult.IsSecondary
            Get
                Return p_IndexReference.IsSecondary
            End Get
        End Property

        Public Sub New(ByRef textReference As IQITAText, ByRef indexReference As IQITAIndex)
            p_TextReference = textReference
            p_IndexReference = indexReference
        End Sub

        Public Overridable Function ToCellString() As String Implements IQITAResult.ToCellString
            If IsNumber(Value) Then
                Return Math.Round(ToNumber(Value), 6).ToString()
            End If

            Return CStr(Value)
        End Function

        Public Overridable Function CompareWith(ByRef anotherResult As IQITAResult) As IQITAResult Implements IQITAResult.CompareWith
            If IsAny(Me.IndexReference) Then
                Return IndexReference.CompareResults(Me, anotherResult)
            Else
                Return New QITANumberResult(-1)
            End If
        End Function
    End Class

    ''' <summary>
    ''' Implements IIndex interface, provides protected interface for manipulating internal
    ''' properties and contains helpful functions for writting new indexes. Class IndexBase
    ''' is thus dedicated to be inherited by individual Index calculation classes.
    ''' </summary>
    Public MustInherit Class QITAIndexBase
        Implements IQITAIndex

        Private p_IndexName As String = "My Index"
        Private p_IndexAuthor As String = Nothing
        Private p_Description As String = Nothing
        Private p_IndexComments As String = Nothing
        Private p_Requires As IQITAIndexRequisities = IQITAIndexRequisities.Non
        Private p_Group As String = "Frequency Structure Indexes"

        Private p_HasComplexResults As Boolean = False
        Private p_IsSecondary As Boolean = False
        Private p_HasComparableResults As Boolean = False

#Region ":: IIndex Interface"

        Public ReadOnly Property IndexName() As String Implements IQITAIndex.IndexName
            Get
                Return p_IndexName
            End Get
        End Property

        Public ReadOnly Property IndexShortName() As String Implements IQITAIndex.IndexShortName
            Get
                Return Me.IndexName
            End Get
        End Property

        Public ReadOnly Property IndexAuthor() As String Implements IQITAIndex.IndexAuthor
            Get
                Return p_IndexAuthor
            End Get
        End Property

        Public ReadOnly Property IndexDescription() As String Implements IQITAIndex.IndexDescription
            Get
                Return p_Description
            End Get
        End Property

        Public ReadOnly Property IndexComments() As String Implements IQITAIndex.IndexComments
            Get
                Return p_IndexComments
            End Get
        End Property

        Public ReadOnly Property IndexGroup() As String Implements IQITAIndex.IndexGroup
            Get
                Return p_Group
            End Get
        End Property

        Public ReadOnly Property Requisities() As IQITAIndexRequisities Implements IQITAIndex.Requisities
            Get
                Return p_Requires
            End Get
        End Property

        Public ReadOnly Property HasComplexResults() As Boolean Implements IQITAIndex.HasComplexResults
            Get
                Return p_HasComplexResults
            End Get
        End Property

        Public ReadOnly Property HasComparableResults() As Boolean Implements IQITAIndex.HasComparableResults
            Get
                Return p_HasComparableResults
            End Get
        End Property

        Public ReadOnly Property IsSecondary() As Boolean Implements IQITAIndex.IsSecondary
            Get
                Return p_IsSecondary
            End Get
        End Property

        Public Function TestRequisitiesForText(ByRef Text As IQITAText) As Boolean Implements IQITAIndex.TestRequisitiesForText
            If Me.Requisities = IQITAIndexRequisities.Non Then
                Return True
            End If

            If CBool(Me.Requisities And IQITAIndexRequisities.RequiresLemmatizer) Then
                If Not IsAny(Text.AssignedLemmatizer) Then Return False
            End If

            If CBool(Me.Requisities And IQITAIndexRequisities.RequiresPOSTagger) Then
                If Not IsAny(Text.AssignedPOSTagger) Then Return False
            End If

            If CBool(Me.Requisities And IQITAIndexRequisities.RequiresTokenizer) Then
                If Not IsAny(Text.AssignedTokenizer) Then Return False
            End If

            Return True
        End Function

        Public MustOverride Function Calculate(ByRef TextData As IQITAText) As IQITAResult Implements IQITAIndex.Calculate

        ''' <summary>
        ''' Calculates index diffusion value of given result value.
        ''' </summary>
        ''' <param name="result">Result value to be recalculated.</param>
        ''' <returns>Diffusion value when overriden, otherwise result value.</returns>
        ''' <remarks>Indexes allowing calculating Diffusion MUST OVERRIDE this method, otherwise same result is returned.</remarks>
        Public Overridable Function CalculateDiffusion(ByRef result As IQITAResult) As IQITAResult Implements IQITAIndex.CalculateDiffusion
            Return result
        End Function

        ''' <summary>
        ''' Compares two results.
        ''' </summary>
        ''' <param name="result1">Result 1.</param>
        ''' <param name="result2">Result 2.</param>
        ''' <returns>Comparsion result when overriden, otherwise number distance is returned.</returns>
        ''' <remarks>Indexes allowing calculating Comparation MUST OVERRIDE this method, otherwise number distance is returned.</remarks>
        Public Overridable Function CompareResults(ByRef result1 As IQITAResult, ByRef result2 As IQITAResult) As IQITAResult Implements IQITAIndex.CompareResults
            Return New QITANumberResult(Math.Abs(result1.Value - result2.Value))
        End Function

        Public Overrides Function ToString() As String Implements IQITAIndex.ToString
            Return Me.IndexName
        End Function
#End Region

#Region ":: Index Programmatical-User Interface"
        ''' <summary>
        ''' Sets name of index.
        ''' </summary>
        ''' <param name="sIndexName">Name.</param>
        Protected Sub SetIndexName(ByVal sIndexName As String)
            p_IndexName = sIndexName
        End Sub

        ''' <summary>
        ''' Author of index + bibliography.
        ''' </summary>
        ''' <param name="sIndexAuthor">Informations.</param>
        ''' <remarks></remarks>
        Protected Sub SetIndexAuthor(ByVal sIndexAuthor As String)
            p_IndexAuthor = sIndexAuthor
        End Sub

        ''' <summary>
        ''' Description of index.
        ''' </summary>
        ''' <param name="sDescription">Description.</param>
        Protected Sub SetIndexDescription(ByVal sDescription As String)
            p_Description = sDescription
        End Sub

        ''' <summary>
        ''' Any comments for index.
        ''' </summary>
        ''' <param name="sComments">Comments.</param>
        Protected Sub SetIndexComments(ByVal sComments As String)
            p_IndexComments = sComments
        End Sub

        ''' <summary>
        ''' Sets whether the result of this index is complex (array, table, ...), or simple (string, number, ...).
        ''' Defaultly set to FALSE.
        ''' </summary>
        ''' <param name="b">True when complex. False when simple.</param>
        ''' <remarks>Default value: FALSE.</remarks>
        Protected Sub SetHasComplexResults(ByVal b As Boolean)
            p_HasComplexResults = b
        End Sub

        ''' <summary>
        ''' Sets whether results of this index has comparable results.
        ''' </summary>
        ''' <remarks>Default value: FALSE.</remarks>
        Protected Sub SetHasComparableResults(ByVal b As Boolean)
            p_HasComparableResults = b
        End Sub

        ''' <summary>
        ''' Sets general group that Index belongs in, eg. Vocabulary Richness, information index, ...
        ''' </summary>
        Protected Sub SetIndexGroup(ByVal sGroup As String)
            p_Group = sGroup
        End Sub
        'Protected Function SaveAndReturn(ByRef result As IResult, ByRef text As IText) As IResult
        '    text.AddResult(result)
        '    Return result
        'End Function

        ''' <summary>
        ''' Sets whether this index is (only) supposed to assist other indexes.
        ''' Defaultly set to FALSE. 
        ''' </summary>
        ''' <param name="b">True if secondary.</param>
        Protected Sub SetIsSecondary(ByVal b As Boolean)
            p_IsSecondary = b
        End Sub
#End Region

#Region ":: Linguistic Helpers"
        ''' <summary>
        ''' Counts total sum of all frequencies above h-Point.
        ''' </summary>
        ''' <param name="TextData">Text.</param>
        ''' <returns>Sum.</returns>
        Public Shared Function SumFrequenciesAboveHPoint(ByRef TextData As IQITAText) As Double
            Dim h As Double = TextData.ComputeIndex(New IndexHPoint).Value

            Return SumWhileLessThanIndex(TextData.GetFrequencyPositiveArray(), 1, h)
        End Function

        ''' <summary>
        ''' Counts total sum of all frequencies above h-Point, ranks are averaged.
        ''' </summary>
        ''' <param name="TextData">Text.</param>
        ''' <param name="hPoint">Specification of hPoint.</param>
        ''' <returns>Sum.</returns>
        Public Shared Function SumFrequenciesAboveHPointWithAveragedRanks(ByRef TextData As IQITAText, ByVal hPoint As Double) As Double
            Dim t As QITATextTable = TextData.GetTextTable
            Dim i As Integer = 0

            Dim sum As Double = 0
            Do
                If t.GetAveragedRank(i) > hPoint Then
                    Exit Do
                End If

                sum += t.GetFrequency(i)
                i += 1
            Loop

            Return sum
        End Function

        ''' <summary>
        ''' Counts total sum of all frequencies above h-Point, ranks are averaged.
        ''' </summary>
        ''' <param name="TextData">Text.</param>
        ''' <returns>Sum.</returns>
        Public Shared Function SumFrequenciesAboveHPointWithAveragedRanks(ByRef TextData As IQITAText) As Double
            Return SumFrequenciesAboveHPointWithAveragedRanks(TextData, TextData.ComputeIndex(New IndexHPoint).Value)
        End Function

        ''' <summary>
        ''' Counts total sum of all frequencies of Text powered by iPowerFreqTo.
        ''' </summary>
        ''' <param name="TextData">Text.</param>
        ''' <param name="iPowerFreqTo">Powers frequency to given exponent before adding to sum.</param>
        ''' <returns>Sum.</returns>
        Public Shared Function SumAllFrequencies(ByRef TextData As IQITAText, Optional ByVal iPowerFreqTo As Double = 1) As Double
            Return SumPositiveArray(TextData.GetFrequencyPositiveArray(), Function(f As Double) (Math.Pow(f, iPowerFreqTo)))
        End Function

        ''' <summary>
        ''' Counts total sum of frequencies from rank 1 to given rank untilRank with appliying function f to each frequency before adding it to sum.
        ''' </summary>
        ''' <param name="TextData">Text.</param>
        ''' <param name="f">Function (param1: passed frequency) that is applied to the frequency (passed in param1) before adding to sum.</param>
        ''' <returns>Sum.</returns>
        Public Shared Function SumAllFrequencies(ByRef TextData As IQITAText, _
                                                 ByVal untilRank As Integer, _
                                                 ByRef f As Func(Of Double, Integer, Double)) As Double
            Return SumPositiveArray(TextData.GetFrequencyPositiveArray(), 1, untilRank, f)
        End Function

        ''' <summary>
        ''' Counts total sum of all frequencies of Text with applying sum-function.
        ''' </summary>
        ''' <param name="TextData"></param>
        ''' <param name="f">Function (param1: passed frequency) that is applied to the frequency (passed in param1) before adding to sum.</param>
        ''' <returns>Sum.</returns>
        Public Shared Function SumAllFrequencies(ByRef TextData As IQITAText, ByRef f As Func(Of Double, Double)) As Double
            Return SumPositiveArray(TextData.GetFrequencyPositiveArray(), f)
        End Function

        ''' <summary>
        ''' Counts total sum of all frequencies of Text with applying sum-function.
        ''' </summary>
        ''' <param name="TextData">Text.</param>
        ''' <param name="iStart">Start at index.</param>
        ''' <param name="iEnd">End at index.</param>
        ''' <param name="f">Function (param1: passed frequency, param2: passed iteration index) that is applied to frequency before adding to sum.</param>
        ''' <returns>Sum.</returns>
        Public Shared Function SumAllFrequencies(ByRef TextData As IQITAText, _
                                                    ByVal iStart As Integer, _
                                                    ByVal iEnd As Integer, _
                                                    ByRef f As Func(Of Double, Integer, Double)) As Double
            Return SumPositiveArray(TextData.GetFrequencyPositiveArray(), iStart, iEnd, f)
        End Function

        ''' <summary>
        ''' Computes given index on given text.
        ''' </summary>
        ''' <param name="TextData">Target Text.</param>
        ''' <param name="index">Index to compute.</param>
        ''' <returns>Index value.</returns>
        Public Shared Function GetIndexVal(ByRef TextData As IQITAText, ByRef index As IQITAIndex) As Object
            Dim result As IQITAResult = TextData.ComputeIndex(index)

            If TypeOf result Is QITAUnknownResult Then
                Throw New Exception("Index has unknown or error result.")
                Return Nothing
            End If

            Return result.Value
        End Function

        Public Shared Function GetHPoint(ByRef TextData As IQITAText) As Double
            Return CDbl(GetIndexVal(TextData, New IndexHPoint))
        End Function

        ''' <summary>
        ''' Tests word whether it is meaningful or not. Based on Text AssignedWordTypeGetter.
        ''' </summary>
        ''' <param name="TextData">TextData with AssignedWordTypeGetter.</param>
        ''' <param name="sWord">Word to test.</param>
        ''' <returns>Returns TRUE if word is meaningful. If WordTypeGetter is not assigned, FALSE is returned.</returns>
        Public Shared Function IsWordMeaningful(ByRef TextData As IQITAText, ByVal sWord As String) As Boolean
            If IsAny(TextData.AssignedPOSTagger) Then
                Return TextData.AssignedPOSTagger.IsWordMeaningful(sWord)
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Retreives word type within Text AssignedWordTypeGetter.
        ''' </summary>
        ''' <param name="TextData">Text with assigned WordTypeGetter.</param>
        ''' <param name="sWord">Word.</param>
        ''' <returns>Type of word. If AssignedWordTypeGetter is not set, UNKNOWN is returned.</returns>
        Public Shared Function GetWordType(ByRef TextData As IQITAText, ByVal sWord As String) As PartOfSpeechType
            If IsAny(TextData.AssignedPOSTagger) Then
                Return TextData.AssignedPOSTagger.GetWordType(sWord)
            Else
                Return PartOfSpeechType.UNKNOWN
            End If
        End Function
#End Region
    End Class

    ''' <summary>
    ''' Implements IQITALemmatizer Interface and provides functions for manipulating internal data.
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class QITAMorphoAnalyzerBase
        Implements IQITAMorphologyAnalyzer

        Private p_AnalyzerName As String = Nothing
        Private p_AnalyzerDescription As String = Nothing
        Private p_AnalyzerAuthor As String = Nothing
        Private p_AnalyzerLanguage As String = Nothing
        Private p_PluginRequisites As String = Nothing
        Private p_PluginVersion As String = Nothing
        Private p_AnalyzerScore As Integer = 0

        Private p_HasLemmatizationAbility As Boolean = False
        Private p_HasPosTaggerAbility As Boolean = False
        Private p_HasTokenizerAbility As Boolean = False
        Private p_HasMeaningfulWordDetectionAbility As Boolean = False
        Private p_TokenizerReturnsLemmatizedTokens As Boolean = False

        Private p_QITAImplementationAuthor As String = Nothing
        Private p_Initialized As Boolean = False

#Region ":: Public Properties"
        Public ReadOnly Property AnalyzerName() As String Implements IQITAMorphologyAnalyzer.AnalyzerName
            Get
                Return p_AnalyzerName
            End Get
        End Property
        Public ReadOnly Property AnalyzerDescription() As String Implements IQITAMorphologyAnalyzer.AnalyzerDescription
            Get
                Return p_AnalyzerDescription
            End Get
        End Property
        Public ReadOnly Property AnalyzerAuthor() As String Implements IQITAMorphologyAnalyzer.AnalyzerAuthor
            Get
                Return p_AnalyzerAuthor
            End Get
        End Property
        Public ReadOnly Property AnalyzerTargetLanguage() As String Implements IQITAMorphologyAnalyzer.AnalyzerTargetLanguage
            Get
                Return p_AnalyzerLanguage
            End Get
        End Property
        Public ReadOnly Property AnylzerScore() As Integer Implements IQITAMorphologyAnalyzer.AnalyzerScore
            Get
                Return p_AnalyzerScore
            End Get
        End Property

        Public ReadOnly Property HasLemmatizationAbility() As Boolean Implements IQITAMorphologyAnalyzer.HasLemmatizationAbility
            Get
                Return p_HasLemmatizationAbility
            End Get
        End Property
        Public ReadOnly Property HasPosTaggingAbility() As Boolean Implements IQITAMorphologyAnalyzer.HasPosTaggingAbility
            Get
                Return p_HasPosTaggerAbility
            End Get
        End Property
        Public ReadOnly Property HasMeaningfulWordDetection() As Boolean Implements IQITAMorphologyAnalyzer.HasMeaningfulWordDetection
            Get
                Return p_HasMeaningfulWordDetectionAbility
            End Get
        End Property
        Public ReadOnly Property HasTokenizerAbility() As Boolean Implements IQITAMorphologyAnalyzer.HasTokenizerAbility
            Get
                Return p_HasTokenizerAbility
            End Get
        End Property
        Public ReadOnly Property TokenizerReturnsLemmatizedTokens() As Boolean Implements IQITAMorphologyAnalyzer.TokenizerReturnsLemmatizedTokens
            Get
                Return p_TokenizerReturnsLemmatizedTokens
            End Get
        End Property

        Public ReadOnly Property PluginRequisites() As String Implements IQITAMorphologyAnalyzer.PluginRequisites
            Get
                Return p_PluginRequisites
            End Get
        End Property
        Public ReadOnly Property PluginAuthor() As String Implements IQITAMorphologyAnalyzer.PluginAuthor
            Get
                Return p_QITAImplementationAuthor
            End Get
        End Property
        Public ReadOnly Property PluginVersion() As String Implements IQITAMorphologyAnalyzer.PluginVersion
            Get
                Return p_PluginVersion
            End Get
        End Property
#End Region

#Region ":: Protected Programmer Interface"
        ''' <summary>
        ''' Gets or sets whether is the lemmatizer initialized or not.
        ''' </summary>
        Protected Property Initialized() As Boolean
            Get
                Return p_Initialized
            End Get
            Set(ByVal value As Boolean)
                p_Initialized = value
            End Set
        End Property

        Protected Sub SetAnalyzerName(ByVal sName As String)
            p_AnalyzerName = sName
        End Sub

        Protected Sub SetAnalyzerLanguage(ByVal sLanguage As String)
            p_AnalyzerLanguage = sLanguage
        End Sub

        Protected Sub SetAnalyzerDescription(ByVal sDescription As String)
            p_AnalyzerDescription = sDescription
        End Sub

        Protected Sub SetAnalyzerAuthor(ByVal sAuthor As String)
            p_AnalyzerAuthor = sAuthor
        End Sub

        Protected Sub SetAnalyzerAbilities(ByVal bHasLemmatizationAbility As Boolean, _
                                    ByVal bHasPOSTaggingAbility As Boolean, _
                                    ByVal bHasTokenizerAbility As Boolean, _
                                    ByVal bHasMeaningfulWordDetection As Boolean)
            p_HasLemmatizationAbility = bHasLemmatizationAbility
            p_HasPosTaggerAbility = bHasPOSTaggingAbility
            p_HasMeaningfulWordDetectionAbility = bHasMeaningfulWordDetection
            p_HasTokenizerAbility = bHasTokenizerAbility
        End Sub

        Protected Sub SetTokenizerReturnsLemmatizedTokens(ByVal b As Boolean)
            p_TokenizerReturnsLemmatizedTokens = b
        End Sub

        Protected Sub SetAnalyzerScore(ByVal score As Integer)
            p_AnalyzerScore = score
        End Sub

        Protected Sub SetPluginRequisites(ByVal s As String)
            p_PluginRequisites = s
        End Sub

        Protected Sub SetPluginAuthor(ByVal sAuthor As String)
            p_QITAImplementationAuthor = sAuthor
        End Sub

        Protected Sub SetPluginVersion(ByVal sVersionInfo As String)
            p_PluginVersion = sVersionInfo
        End Sub

        ''' <summary>
        ''' Checks if lemmatizer is initialized. If not, throws an exception.
        ''' </summary>
        Protected Sub CheckIfInitialized()
            If Not Me.Initialized Then
                Throw New Exception("Using " & Me.AnalyzerName & " lemmatizer without proper initialization!")
            End If
        End Sub

        ''' <summary>
        ''' Throws exception with given reason.
        ''' </summary>
        ''' <param name="sProblem">What happened?</param>
        ''' <param name="e">Exception instance if available.</param>
        Protected Sub ThrowInitError(ByVal sProblem As String, Optional ByRef e As Exception = Nothing)
            Me.Initialized = False
            Throw New Exception(Me.AnalyzerName & " could not be initialized. " & Environment.NewLine & _
                                "Problem: " & sProblem & Environment.NewLine & _
                                CStr(IIf(IsAny(e), "Reason: " & e.Message(), Nothing)))
        End Sub

        ''' <summary>
        ''' Sets Initialized property to TRUE.
        ''' </summary>
        ''' <returns>TRUE always.</returns>
        Protected Function InitOK() As Boolean
            Me.Initialized = True
            Return True
        End Function
#End Region

#Region ":: Inherited Public Functions"
        Public MustOverride Function CheckDependencies(ByRef outStatus As String) As Boolean Implements IQITAMorphologyAnalyzer.CheckDependencies

        Public MustOverride Function Initialize() As Boolean Implements IQITAMorphologyAnalyzer.Initialize
        Public MustOverride Function LemmatizeWord(ByVal sWord As String) As String Implements IQITAMorphologyAnalyzer.LemmatizeWord
        Public MustOverride Function GetWordType(ByVal sWord As String) As PartOfSpeechType Implements IQITAMorphologyAnalyzer.GetWordType
        Public MustOverride Function IsWordMeaningful(ByVal sWord As String) As Boolean Implements IQITAMorphologyAnalyzer.IsWordMeaningful
        Public MustOverride Function TokenizeText(ByVal sText As String) As String() Implements IQITAMorphologyAnalyzer.TokenizeText
#End Region

#Region ":: Public Helpers"
        Public Function MakeUnknownLemmaOutput(ByVal sInput As String) As String
            Return "[:" & sInput & "?]"
        End Function

        Public Function IsLemmaUnknown(ByVal sLemma As String) As Boolean Implements IQITAMorphologyAnalyzer.IsLemmaUnknown
            Return Regex.IsMatch(sLemma, "\[:.*\?]")
        End Function
#End Region
    End Class

    ''' <summary>
    ''' Inherits QITAMorphoAnalyzerBase with ignored non-tokenizer functions.
    ''' </summary>
    Public MustInherit Class QITATokenizerOnlyBase
        Inherits QITAMorphoAnalyzerBase

        Public Sub New()
            Me.SetAnalyzerAbilities(False, False, True, False)
        End Sub

        Public Overrides Function Initialize() As Boolean
            Return True
        End Function

        Public Overrides Function GetWordType(ByVal sWord As String) As QITADataTypes.PartOfSpeechType
            Return PartOfSpeechType.UNKNOWN
        End Function

        Public Overrides Function IsWordMeaningful(ByVal sWord As String) As Boolean
            Return False
        End Function

        Public Overrides Function LemmatizeWord(ByVal sWord As String) As String
            Return sWord
        End Function

        Public Overrides Function CheckDependencies(ByRef outStatus As String) As Boolean
            outStatus = "OK"
            Return True
        End Function
    End Class

    ''' <summary>
    ''' Implements IQITATextProstProcessors and provides functions for manipulating internal data.
    ''' </summary>
    Public MustInherit Class QITAPostProcessorBase
        Implements IQITATextPostProcessors

        Private _Name As String = Nothing
        Private _Description As String = Nothing
        Private _Group As String = Nothing

        Public ReadOnly Property Name() As String Implements QITAInterfaces.IQITATextPostProcessors.Name
            Get
                Return _Name
            End Get
        End Property

        Public ReadOnly Property Description() As String Implements QITAInterfaces.IQITATextPostProcessors.Description
            Get
                Return _Description
            End Get
        End Property

        Public ReadOnly Property Group() As String Implements IQITATextPostProcessors.Group
            Get
                Return _Group
            End Get
        End Property

        Protected Sub SetInfo(ByVal sName As String, ByVal sDescription As String, ByVal sGroup As String)
            _Name = sName
            _Description = sDescription
            _Group = sGroup
        End Sub

        Public Overrides Function ToString() As String
            Return _Name & " -- " & _Description
        End Function

        Public Overridable Function InitializePostProcessor() As Boolean Implements IQITATextPostProcessors.InitializePostProcessor
            Return True
        End Function

        Public MustOverride Function PostProcess(ByRef text As QITAInterfaces.IQITAText) As Boolean Implements QITAInterfaces.IQITATextPostProcessors.PostProcess
    End Class
#End Region

#Region "QITA Implementations"
    Public Class QITAUnknownResult
        Inherits QITAResultBase

        Public Sub New()
            MyBase.New(Nothing, Nothing)
        End Sub

        Public Sub New(ByRef textReference As IQITAText, _
                       ByRef indexReference As IQITAIndex)
            MyBase.New(textReference, indexReference)
        End Sub

        Public Overrides ReadOnly Property IsComplex() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property Value() As Object
            Get
                Return "n/a"
            End Get
            Set(ByVal value As Object)

            End Set
        End Property
    End Class

    ''' <summary>
    ''' Inherits QITAResultBase and is used as SIMPLE Number result container.
    ''' </summary>
    Public Class QITANumberResult
        Inherits QITAResultBase
        Private p_Value As Object = -1

        Public Sub New(ByRef textReference As IQITAText, _
                       ByRef indexReference As IQITAIndex, _
                       ByVal resultValue As Object)
            MyBase.New(textReference, indexReference)

            Value = resultValue

            'If IsNumeric(resultValue) Then
            '    Value = resultValue
            'Else
            '    Throw New Exception("QITANumberResult must hold type interpretable as a number.")
            'End If
        End Sub

        Public Sub New(ByVal resultValue As Object)
            MyBase.New(Nothing, Nothing)
            Value = resultValue
        End Sub

        Private Function CheckValue(ByRef resultValue As Object) As Boolean
            If IsNumeric(resultValue) Then
                Return True
            Else
                Throw New Exception("QITANumberResult must hold type interpretable as a number.")
                Return False
            End If
        End Function

        Public Overrides ReadOnly Property IsComplex() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property Value() As Object
            Get
                Return p_Value
            End Get
            Set(ByVal value As Object)
                p_Value = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Inherits QITAResultBase and is used as SIMPLE String result container.
    ''' </summary>
    Public Class QITAStringResult
        Inherits QITAResultBase
        Private p_Value As String = Nothing

        Public Sub New(ByRef textReference As IQITAText, _
                       ByRef indexReference As IQITAIndex, _
                       ByVal resultValue As String)
            MyBase.New(textReference, indexReference)

            Value = resultValue
        End Sub

        Public Overrides ReadOnly Property IsComplex() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property Value() As Object
            Get
                Return p_Value
            End Get
            Set(ByVal value As Object)
                p_Value = CStr(value)
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Inherits QITAResultBase and is used as complex data structures container.
    ''' </summary>
    Public Class QITAComplexResult
        Inherits QITAResultBase
        Private p_Value As Object = Nothing
        Private p_ComplexValue As Object = Nothing

        ''' <summary>
        ''' Creates new result with simple and complex data values.
        ''' </summary>
        ''' <param name="textReference">Reference to Text.</param>
        ''' <param name="indexReference">Reference to Index.</param>
        ''' <param name="resultValue">Primary value (that will be showed in cell). You may use NULL for displyaing "[...]" string.</param>
        ''' <param name="complexResultValue">Complex data (array, table, ...) that will be stored.</param>
        Public Sub New(ByRef textReference As IQITAText, _
                       ByRef indexReference As IQITAIndex, _
                       ByVal resultValue As Object, _
                       ByVal complexResultValue As Object)
            MyBase.New(textReference, indexReference)

            Value = resultValue
            ComplexValue = complexResultValue
        End Sub

        ''' <summary>
        ''' Creates new result with given complex data and specified display string.
        ''' </summary>
        ''' <param name="textReference">Reference to source Text.</param>
        ''' <param name="sResultName">Name of result.</param>
        ''' <param name="sDisplayString">Value used for displaying used by ToCellString() and
        ''' ToFullString() functions. If set to NOTHING, "[...]" will be used.</param>
        ''' <param name="resultValue">Complex value that will be stored.</param>
        Public Sub New(ByRef textReference As IQITAText, _
                       ByVal sResultName As String, _
                       ByVal sDisplayString As String, _
                       ByVal resultValue As Object)
            MyBase.New(textReference, New QITADummyIndex(sResultName))

            Value = sDisplayString
            ComplexValue = resultValue
        End Sub

        Public Overrides ReadOnly Property IsComplex() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Property Value() As Object
            Get
                Return p_Value
            End Get
            Set(ByVal value As Object)
                p_Value = value
            End Set
        End Property

        Public Overrides Property ComplexValue() As Object
            Get
                Return p_ComplexValue
            End Get
            Set(ByVal value As Object)
                p_ComplexValue = value
            End Set
        End Property

        Public Overrides Function ToCellString() As String
            If IsAny(Me.Value) Then
                If IsNumber(Me.Value) Then
                    Return Math.Round(ToNumber(Me.Value), 6).ToString()
                End If

                Return Me.Value.ToString()
            Else
                Return "[...]"
            End If
        End Function
    End Class

    Public Class QITADummyIndex
        Inherits QITAIndexBase

        Public Sub New(ByVal sName As String)
            Me.SetIndexName(sName)
            Me.SetIndexGroup("Frequency Structure Indexes")
        End Sub

        Public Overrides Function Calculate(ByRef TextData As QITAInterfaces.IQITAText) As QITAInterfaces.IQITAResult
            Return Nothing
        End Function

        Public Overrides Function CalculateDiffusion(ByRef result As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Return Nothing
        End Function

        Public Overrides Function CompareResults(ByRef result1 As QITAInterfaces.IQITAResult, ByRef result2 As QITAInterfaces.IQITAResult) As QITAInterfaces.IQITAResult
            Return Nothing
        End Function
    End Class

    ''' <summary>
    ''' Implements IText interface and provides various additional functions for operating 
    ''' linguistic text (aka 'DataText'/'Text').
    ''' </summary>
    Public Class QITAText
        Implements IQITAText
        Private p_TextData As String = Nothing
        Private p_TextDescription As String = Nothing
        Private p_TextName As String = Nothing
        Private p_Results As New List(Of IQITAResult)
        Private p_Lemmatizer As IQITAMorphologyAnalyzer = Nothing
        Private p_WordTypeGetter As IQITAMorphologyAnalyzer = Nothing
        Private p_Tokenizer As IQITAMorphologyAnalyzer = Nothing
        Private p_UsingEncoding As System.Text.Encoding = Nothing

        Private p_TextFile As String = Nothing
        Private p_TextBackup As String = Nothing

        Private p_TokensCache() As String = Nothing
        Private p_TypesCache() As String = Nothing
        Private p_FrequencyAnalysisCache As QITAWordFrequencyTable = Nothing
        Private p_RankTableCache As QITAPositiveArray = Nothing
        Private p_TextTableCache As QITATextTable = Nothing
        Private p_FrequencyPositiveArrayCache() As Integer = Nothing
        Private p_POSFrequencyTableCache As QITATable = Nothing

#Region ":: PROPERTIES"
        Public Property TextData() As String Implements IQITAText.TextData
            Get
                '-- content deleted by cache clearer?
                If (p_TextData Is Nothing) AndAlso StrIsAny(Me.p_TextFile) Then
                    If IO.File.Exists(Me.p_TextFile) Then
                        Return GetFileTextContent(Me.p_TextFile, Me.p_UsingEncoding)
                    End If
                End If

                Return p_TextData
            End Get
            Set(ByVal value As String)
                p_TextData = value

                Invalidate()
            End Set
        End Property

        Public Property TextDescription() As String Implements IQITAText.TextDescription
            Get
                Return p_TextDescription
            End Get
            Set(ByVal value As String)
                p_TextDescription = value
            End Set
        End Property

        Public Property TextFile() As String Implements IQITAText.TextFile
            Get
                Return p_TextFile
            End Get
            Set(ByVal value As String)
                p_TextFile = value
            End Set
        End Property

        Public Property TextName() As String Implements IQITAText.TextName
            Get
                Return p_TextName
            End Get
            Set(ByVal value As String)
                p_TextName = value
            End Set
        End Property

        Public Property ReadyResults() As List(Of IQITAResult) Implements IQITAText.ReadyResults
            Get
                Return p_Results
            End Get
            Set(ByVal value As List(Of IQITAResult))
                p_Results = value
            End Set
        End Property

        Public Property AssignedLemmatizer() As IQITAMorphologyAnalyzer Implements IQITAText.AssignedLemmatizer
            Get
                Return p_Lemmatizer
            End Get
            Set(ByVal value As IQITAMorphologyAnalyzer)
                p_Lemmatizer = value
                Invalidate()
            End Set
        End Property

        Public Property AssignedPOSTagger() As IQITAMorphologyAnalyzer Implements IQITAText.AssignedPOSTagger
            Get
                Return p_WordTypeGetter
            End Get
            Set(ByVal value As IQITAMorphologyAnalyzer)
                p_WordTypeGetter = value
            End Set
        End Property

        Public Property AssignedTokenizer() As IQITAMorphologyAnalyzer Implements IQITAText.AssignedTokenizer
            Get
                Return p_Tokenizer
            End Get
            Set(ByVal value As IQITAMorphologyAnalyzer)
                p_Tokenizer = value
            End Set
        End Property

        Public Property Encoding() As String Implements IQITAText.Encoding
            Get
                If IsAny(p_UsingEncoding) Then
                    Return p_UsingEncoding.WebName
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                p_UsingEncoding = System.Text.Encoding.GetEncoding(value)
            End Set
        End Property
#End Region

#Region ":: GENERAL FUNCTIONS"
        Public Sub New()

        End Sub

        Public Sub New(ByVal sTextName As String, ByVal sText As String, ByVal sDescription As String)
            TextName = sTextName
            TextData = sText
            TextDescription = sDescription

            p_TextBackup = sText
        End Sub

        Public Sub Invalidate() Implements IQITAText.Invalidate
            p_Results.Clear()
            p_TokensCache = Nothing
            p_TypesCache = Nothing
            p_FrequencyAnalysisCache = Nothing
            p_RankTableCache = Nothing
            p_TextTableCache = Nothing
            p_FrequencyPositiveArrayCache = Nothing
            p_POSFrequencyTableCache = Nothing
        End Sub

        Public Sub ClearContent() Implements IQITAText.ClearContent
            Me.p_TextData = Nothing
        End Sub

        Public Sub InitializeBeforeComputing() Implements IQITAText.InitializeBeforeComputing
            If StrIsAny(Me.TextData) Then
                Me.Types()
                Me.Tokens()
                Me.GetWordFrequencyTable()

                If IsAny(Me.AssignedPOSTagger) Then
                    Me.GetPOSFrequencyTable()
                End If

                'Me.GetTextTable()
            End If
        End Sub

        Public Sub InitializeAfterPostProcessing() Implements IQITAText.InitializeAfterPostProcessing
            Me.InitializeBeforeComputing() 'recalculate types, tokens, frequencies and pos frequencies.
        End Sub

        Public Function AddResult(ByRef result As IQITAResult) As IQITAResult Implements IQITAText.AddResult
            p_Results.Add(result)

            Return result
        End Function

        Public Function IsIndexComputedAlready(ByRef index As IQITAIndex, ByRef outResult As IQITAResult) As Boolean Implements IQITAText.IsIndexComputedAlready
            outResult = GetResultByIndex(index.GetType())
            Return CBool(outResult IsNot Nothing)
        End Function

        Public Function GetResultByIndex(ByRef index As Type) As IQITAResult Implements IQITAText.GetResultByIndex
            For Each result As IQITAResult In p_Results
                If index.Equals(result.IndexReference().GetType()) Then
                    Return result
                End If
            Next

            Return Nothing
        End Function

        Public Function GetResultByIndex(Of T)() As IQITAResult Implements IQITAText.GetResultByIndex
            Return Me.GetResultByIndex(TextData.GetType())
        End Function

        Public Function GetResultByIndex(ByRef indexName As String) As IQITAResult Implements IQITAText.GetResultByIndex
            For Each result As IQITAResult In p_Results
                If result.IndexReference.IndexName = indexName Then
                    Return result
                End If
            Next

            Return Nothing
        End Function

        Public Function ComputeIndex(ByRef index As IQITAIndex) As IQITAResult Implements IQITAText.ComputeIndex
            Dim previousResult As IQITAResult = Nothing

            If StrIsAny(Me.TextData) Then
                If IsIndexComputedAlready(index, previousResult) Then
                    Return previousResult
                End If

                Return AddResult(index.Calculate(Me))
            Else
                Return Nothing
            End If
        End Function

        Public Function LoadFromFile(ByVal sFile As String, _
                                     Optional ByRef sOutError As String = Nothing) As Boolean Implements IQITAText.LoadFromFile
            Dim readedFine As Boolean
            Dim extensionIsOk As Boolean = True

            Select Case ToUpper(IO.Path.GetExtension(sFile))
                Case ".TXT", ".FNA", ".HTML", ".HTM"
                    Dim sFileContent As String = Nothing

                    If GetFileTextContent(sFile, sFileContent, p_UsingEncoding, False, sOutError) Then
                        If My.Settings.ExtractTextFromHTMLFiles AndAlso IsHTML(sFileContent) Then
                            sFileContent = ConvertHTMLToPlainText(sFileContent)
                        End If

                        Me.TextData = sFileContent
                        readedFine = True
                    End If

                Case ".EXE", ".DLL", ".BIN", _
                        ".MPG", ".MP3", ".AVI", ".MP4", ".WAV", _
                        ".JPG", ".PNG", ".BMP"

                    readedFine = BinaryFileToAlphabetedText(sFile, My.Settings.DefaultAlphabete, TextData, sOutError)

                Case Else
                    extensionIsOk = False
            End Select

            If extensionIsOk AndAlso readedFine Then
                Me.TextFile = sFile
                Me.TextDescription = ""

                If Not StrIsAny(Me.TextName) Then
                    Me.TextName = IO.Path.GetFileNameWithoutExtension(sFile)
                End If

                StripGutenbergIfAny(Me.TextData)

                Return readedFine
            End If

            If Not extensionIsOk Then
                sOutError = "Unsupported file extension: " & IO.Path.GetExtension(sFile)
                Return False
            End If

            If Not readedFine Then
                sOutError = "Error while reading file: " & sOutError
                Return False
            End If
        End Function

        Public Function ReLoadFile() As Boolean Implements IQITAText.ReLoadFile
            If StrIsAny(Me.TextFile) Then
                Return LoadFromFile(Me.TextFile, Nothing)
            Else
                Me.TextData = p_TextBackup
            End If
        End Function

        Public Function ReLoadFile(ByVal sEncodingName As String) As Boolean Implements IQITAText.ReLoadFile
            Me.Encoding = sEncodingName
            Return Me.LoadFromFile(TextFile, Nothing)
        End Function

        Public Function GetPreview() As String Implements IQITAText.GetPreview
            If StrIsAny(p_TextData) Then
                Return Replace(p_TextData.Substring(0, Math.Min(100, p_TextData.Length - 1)), vbCrLf, " ") & "..."
            End If

            Return Nothing
        End Function

        Public Function GetDefaultEncoding() As String Implements IQITAText.GetDefaultEncoding
            Return Me.Encoding()
        End Function
#End Region

#Region ":: LINGUISTIC BASIC FUNCTIONS"
        Public Function GetTextTable() As QITATextTable Implements IQITAText.GetTextTable
            If p_TextTableCache Is Nothing Then
                Dim t As New QITATextTable(Me)
                Dim frequencies As QITAPositiveArray = Me.GetFrequencyToAveragedRankTable()

                t.AssignRowsToColumn(QITATextTable.TextTableColumns.Word, Me.GetWordFrequencyTable.WordsPositiveArray())
                t.AssignRowsToColumn(QITATextTable.TextTableColumns.WordFrequency, Me.GetWordFrequencyTable.GetFrequenciesInPositiveArray())

                t.Agregate(CInt(QITATextTable.TextTableColumns.WordFrequency), _
                           CInt(QITATextTable.TextTableColumns.AveragedRank), _
                            Function(wordFrequency As Object) (frequencies.At(CInt(wordFrequency))))


                t.Agregate(CInt(QITATextTable.TextTableColumns.Rank), Function(index As Integer, content As Object) (index))

                If IsAny(AssignedPOSTagger) Then
                    t.Agregate(CInt(QITATextTable.TextTableColumns.Word), _
                               CInt(QITATextTable.TextTableColumns.WordType), _
                               Function(word As Object) (AssignedPOSTagger.GetWordType(word)))
                End If

                p_TextTableCache = t
            End If

            Return p_TextTableCache
        End Function

        Public Function Types() As String() Implements IQITAText.Types
            If p_TypesCache Is Nothing Then
                p_TypesCache = Me.Tokens().Distinct().ToArray()

                '-- Add Results to List
                Me.AddResult(New QITAComplexResult(Me, "Types", p_TypesCache.Count().ToString(), p_TypesCache))
                Me.AddResult(New QITAComplexResult(Me, "Tokens", p_TokensCache.Count().ToString(), p_TokensCache))
            End If

            Return p_TypesCache
        End Function

        Public Function Tokens() As String() Implements IQITAText.Tokens
            If p_TokensCache Is Nothing Then
                Dim sAllWords As String()

                If IsAny(AssignedTokenizer) Then
                    sAllWords = AssignedTokenizer.TokenizeText(TextData)
                Else
                    sAllWords = New GenericTokenizer().TokenizeText(TextData)
                End If

                Dim allTokens As New List(Of String)(sAllWords.Count)

                If IsAny(sAllWords) Then
                    For i As Integer = 0 To UBound(sAllWords)
                        If StrIsAny(sAllWords(i)) Then
                            'Token filtering ...
                            If Not My.Settings.Settings_TreatNumbersAsWords Then
                                If IsNumeric(sAllWords(i)) Then
                                    Continue For
                                End If
                            End If

                            If Not My.Settings.Settings_TreatNonAlphaNumericsAsTokens Then
                                Dim bContainsAlphanumerics As Boolean = False

                                For Each t As Char In sAllWords(i)
                                    If Char.IsLetterOrDigit(t) Then
                                        bContainsAlphanumerics = True
                                        Exit For
                                    End If
                                Next

                                If Not bContainsAlphanumerics Then Continue For
                            End If

                            'Add (lemmatized) token...
                            allTokens.Add(LemmatizeIfSet(NormalizeString(sAllWords(i))))
                        End If
                    Next
                End If

                p_TokensCache = allTokens.ToArray()
            End If

            Return p_TokensCache
        End Function

        Public Function TypeCount() As Integer Implements IQITAText.TypeCount
            Return Types().Count
        End Function

        Public Function TokenCount() As Integer Implements IQITAText.TokenCount
            Return Tokens().Count
        End Function

        ''' <summary>
        ''' Token count.
        ''' </summary>
        Public Function N() As Integer Implements IQITAText.N
            Return TokenCount()
        End Function

        ''' <summary>
        ''' Type count.
        ''' </summary>
        Public Function V() As Integer Implements IQITAText.V
            Return TypeCount()
        End Function

        Public Function GetWordFrequencyTable() As QITAWordFrequencyTable Implements IQITAText.GetWordFrequencyTable
            If p_FrequencyAnalysisCache Is Nothing Then
                Dim aTokenCounter As New QITAWordFrequencyTable(Me.GetWordOrLemmaLabel(), "Frequency")

                For Each s As String In Me.Tokens()
                    aTokenCounter.CountWord(s)
                Next

                p_FrequencyAnalysisCache = aTokenCounter

                Me.AddResult(New QITAComplexResult(Me, "Frequencies", Nothing, aTokenCounter.ToTable(Me)))
            End If

            Return p_FrequencyAnalysisCache
        End Function

        Public Function GetPOSFrequencyTable() As QITATable
            If p_POSFrequencyTableCache Is Nothing Then
                If IsAny(Me.AssignedPOSTagger) Then
                    Dim aCounter As New QITAWordFrequencyTable("POS", "Count")

                    For Each token As String In Me.Tokens()
                        aCounter.CountWord(Me.AssignedPOSTagger.GetWordType(token).ToString())
                    Next

                    Dim table As QITATable = aCounter.ToTable(Me)
                    Me.AddResult(New QITAComplexResult(Me, "POS Frequencies", Nothing, table))
                    table.SetChartableColumns("POS", "Count")

                    p_POSFrequencyTableCache = table
                End If
            End If

            Return p_POSFrequencyTableCache
        End Function

        Public Function GetFrequencyPositiveArray() As Integer() Implements IQITAText.GetFrequencyPositiveArray
            If Not IsAny(p_FrequencyPositiveArrayCache) Then
                p_FrequencyPositiveArrayCache = GetWordFrequencyTable().GetFrequenciesInPositiveArray()
            End If

            Return p_FrequencyPositiveArrayCache
        End Function

        Public Function GetFrequencyToAveragedRankTable() As QITAPositiveArray Implements IQITAText.GetFrequencyToAveragedRankTable
            Const positive_array_start As Integer = 1

            If p_RankTableCache Is Nothing Then
                Dim frequencies As Integer() = Me.GetFrequencyPositiveArray()
                Dim rankTable As New QITAPositiveArray(frequencies(positive_array_start))

                Dim iCurrentRank As Integer = frequencies(positive_array_start)
                Dim sameFrequencies As New List(Of Integer)(frequencies.Count \ 3)
                sameFrequencies.Add(positive_array_start)

                For i As Integer = positive_array_start To frequencies.Count - 2
                    If frequencies(i) <> frequencies(i + 1) Then
                        rankTable.Item(iCurrentRank) = sameFrequencies.Average()

                        iCurrentRank = frequencies(i + 1) 'next frequency
                        sameFrequencies.Clear()
                    End If

                    sameFrequencies.Add(i + 1)
                Next

                'save last (hapax averaged ranks)
                rankTable.Item(iCurrentRank) = sameFrequencies.Average()

                p_RankTableCache = rankTable
            End If

            Return p_RankTableCache
        End Function

        ''' <summary>
        ''' Frequency at rank.
        ''' </summary>
        Public Function f(ByVal index As Integer) As Long Implements IQITAText.f
            Return GetFrequencyPositiveArray()(index)
        End Function

        Public Function FrequencyToRank(ByVal frequency As Integer) As Double Implements IQITAText.FrequencyToRank
            Return CDbl(Me.GetFrequencyToAveragedRankTable().At(frequency))
        End Function

        Private Function LemmatizeIfSet(ByVal sWord As String) As String
            If Me.AssignedLemmatizer Is Nothing Then
                Return sWord
            Else
                Return AssignedLemmatizer.LemmatizeWord(sWord)
            End If
        End Function

        Private Function GetWordTypeIfSet(ByVal sWord As String) As String
            If IsAny(AssignedPOSTagger) Then
                Return CStr(AssignedPOSTagger.GetWordType(sWord))
            Else
                Return Nothing
            End If
        End Function

        Public Function GetWordOrLemmaLabel() As String Implements IQITAText.GetWordOrLemmaLabel
            If Me.AssignedLemmatizer Is Nothing Then
                Return "Token"
            Else
                Return "Lemma"
            End If
        End Function

        Public Function ClearCache() As Boolean Implements IQITAText.ClearCache
            Dim t As IQITAResult
            Dim b As Boolean = Not My.Settings.CacheSettings_EnableCaching

            Erase p_TokensCache
            If b OrElse (Not My.Settings.CacheSettings_CacheTokens) Then
                t = Me.GetResultByIndex("Tokens")
                If IsAny(t) Then
                    Erase t.ComplexValue
                    t.ComplexValue = Nothing
                End If
            End If

            Erase p_TypesCache
            If b OrElse (Not My.Settings.CacheSettings_CacheTypes) Then
                t = Me.GetResultByIndex("Types")
                If IsAny(t) Then
                    Erase t.ComplexValue
                    t.ComplexValue = Nothing
                End If
            End If

            If b OrElse (Not My.Settings.CacheSettings_CacheFreqTable) Then
                If IsAny(p_FrequencyAnalysisCache) Then
                    p_FrequencyAnalysisCache.Clear()
                    p_FrequencyAnalysisCache = Nothing
                End If
            End If

            If IO.File.Exists(Me.TextFile) Then
                Me.ClearContent()
            End If

            Erase p_FrequencyPositiveArrayCache

            If IsAny(p_RankTableCache) Then
                p_RankTableCache.Clear()
                p_RankTableCache = Nothing
            End If

            If IsAny(p_TextTableCache) Then
                p_TextTableCache.Clear()
                p_TextTableCache = Nothing
            End If
        End Function
#End Region
    End Class
#End Region

End Namespace

Namespace QITADataTypes
    Public Enum PartOfSpeechType
        VERB
        NOUN
        PRONOUN
        ADJECTIVE
        ADVERB
        PREPOSITION
        CONJUNCTION
        NUMBER
        PARTICLE
        INTERJECTION
        DETERMINATION
        PREDETERMINATION
        UNKNOWN

        MUST_OVERRIDE
    End Enum

    ''' <summary>
    ''' Provides positive (or one-based) array container for linguistic purposes which
    ''' (in oposite to programming) use tables and arrays indexed from 1 and not from 0.
    ''' </summary>
    Public Class QITAPositiveArray
        Private p_data() As Object
        Private p_Column1Name As String = Nothing
        Private p_Column2Name As String = Nothing

#Region ":: Publc Properties"
        Public Property Column1Name() As String
            Get
                Return p_Column1Name
            End Get
            Set(ByVal value As String)
                p_Column1Name = value
            End Set
        End Property

        Public Property Column2Name() As String
            Get
                Return p_Column2Name
            End Get
            Set(ByVal value As String)
                p_Column2Name = value
            End Set
        End Property
#End Region

#Region ":: Public General Subs"
        Public Sub New(ByVal nSize As Integer)
            RedimTab(nSize)
        End Sub

        ''' <summary>
        ''' Creates new one-based array from given zero-based array.
        ''' </summary>
        ''' <param name="aZeroBasedIntArray">Zero-based array.</param>
        Public Sub New(ByRef aZeroBasedIntArray() As Long)
            If CBool(UBound(aZeroBasedIntArray) > -1) Then
                RedimTab(aZeroBasedIntArray.Count)

                For i As Integer = 0 To aZeroBasedIntArray.Count - 1
                    p_data(i + 1) = aZeroBasedIntArray(i)
                Next
            End If
        End Sub

        Public Sub New(ByRef aZeroBasedObjArray() As Integer)
            If CBool(UBound(aZeroBasedObjArray) > -1) Then
                RedimTab(aZeroBasedObjArray.Count)

                For i As Integer = 0 To aZeroBasedObjArray.Count - 1
                    p_data(i + 1) = aZeroBasedObjArray(i)
                Next
            End If
        End Sub

        Public Sub New(ByRef aZeroBasedObjArray() As Object)
            If CBool(UBound(aZeroBasedObjArray) > -1) Then
                RedimTab(aZeroBasedObjArray.Count)

                For i As Integer = 0 To aZeroBasedObjArray.Count - 1
                    p_data(i + 1) = aZeroBasedObjArray(i)
                Next
            End If
        End Sub

        Public Sub New(ByRef aZeroBasedPairArray() As KeyValuePair(Of String, Integer))
            If CBool(UBound(aZeroBasedPairArray) > -1) Then
                RedimTab(aZeroBasedPairArray.Count)

                For i As Integer = 0 To aZeroBasedPairArray.Count - 1
                    p_data(i + 1) = aZeroBasedPairArray(i)
                Next
            End If
        End Sub

        Public Sub Clear()
            Erase p_data
        End Sub
#End Region

#Region ":: Private General Subs"
        Private Sub RedimTab(ByVal nRows As Integer)
            ReDim p_data(nRows)
        End Sub

        Private Function Put(ByVal n As Integer, ByRef data As Object) As Boolean
            If n >= UBound(p_data) Then
                RedimTab(n)
            End If

            p_data(n) = data

            Return True
        End Function
#End Region

#Region ":: Public Table/Array Accessors"
        ''' <summary>
        ''' Retreives a value at index in table.
        ''' </summary>
        ''' <param name="n">Cell index.</param>
        ''' <returns>Value at index n.</returns>
        ''' <remarks></remarks>
        Public Function At(ByVal n As Integer) As Object
            Return p_data(n)
        End Function

        ''' <summary>
        ''' Sets or gets a value to/from index.
        ''' </summary>
        ''' <param name="nIndex">Value index.</param>
        ''' <value>Any value to be stored in array.</value>
        ''' <returns>Stored value.</returns>
        Public Property Item(ByVal nIndex As Integer) As Object
            Get
                Return p_data(nIndex)
            End Get
            Set(ByVal value As Object)
                Put(nIndex, value)
            End Set
        End Property

        Public Function Add(ByRef data As Object) As Long
            Put(UBound(p_data), data)
        End Function

        ''' <summary>
        ''' Retreives the size of table.
        ''' </summary>
        ''' <returns>Table size.</returns>
        ''' <remarks></remarks>
        Public Function Count() As Integer
            Return p_data.Count - 1
        End Function

        Public Function ToPositiveArray(Of T)() As T()
            If p_data Is Nothing Then
                Return Nothing
            End If

            Dim newArray(p_data.Count - 1) As T

            Array.Copy(p_data, 1, newArray, 1, p_data.Count - 1)
            Return newArray
        End Function

        Private Function ToPositiveArrayOf(Of T)() As T()
            If p_data Is Nothing Then
                Return Nothing
            End If

            Dim a(p_data.Count - 1) As T

            For i As Integer = 1 To p_data.Count - 1
                a(i) = p_data(i)
            Next

            Return a
        End Function

        Public Function ToPositiveLongIntegerArray() As Long()
            Return Me.ToPositiveArrayOf(Of Long)()
        End Function

        Public Function ToPositiveIntegerArray() As Integer()
            Return Me.ToPositiveArrayOf(Of Integer)()
        End Function

#End Region
    End Class

    ''' <summary>
    ''' Provides unified Word to numeric value simple table.
    ''' </summary>
    Public Class QITAWordToNumberTable
        Implements IQITADataType

        Private p_Dictionary As New Dictionary(Of String, Integer)
        Private p_IsSorted As Boolean = False

        Private p_Column1Name As String = Nothing
        Private p_Column2Name As String = Nothing

        Private p_WordsCache As QITAPositiveArray = Nothing
        Private p_ValuesCache As QITAPositiveArray = Nothing

#Region ":: Table Settings"
        Private Sub Invalidate()
            p_WordsCache = Nothing
            p_ValuesCache = Nothing
            p_IsSorted = False
        End Sub

        Public Property Column1Name() As String
            Get
                Return p_Column1Name
            End Get
            Set(ByVal value As String)
                p_Column1Name = value
            End Set
        End Property

        Public Property Column2Name() As String
            Get
                Return p_Column2Name
            End Get
            Set(ByVal value As String)
                p_Column2Name = value
            End Set
        End Property
#End Region

#Region ":: Table Data Add/Exists/Count, ..."
        ''' <summary>
        ''' Gets or sets words stored value.
        ''' </summary>
        ''' <param name="sWord">Word thichs value will be used.</param>
        ''' <value>New value.</value>
        ''' <returns>Value stored for given word.</returns>
        Public Property Value(ByVal sWord As String) As Integer
            Get
                Return GetWordValue(sWord)
            End Get
            Set(ByVal value As Integer)
                Add(sWord, value)
                Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' Gets word at given index.
        ''' </summary>
        ''' <param name="index">Index in value sorted table.</param>
        ''' <returns>Word.</returns>
        Public ReadOnly Property Word(ByVal index As Integer) As String
            Get
                Return GetWordOnIndex(index)
            End Get
        End Property

        ''' <summary>
        ''' Retreives wheter given word exists in table.
        ''' </summary>
        ''' <param name="sWord">Word to be tested.</param>
        ''' <returns>TRUE if exists.</returns>
        Public Function ContainsWord(ByVal sWord As String) As Boolean
            Return p_Dictionary.ContainsKey(sWord)
        End Function

        ''' <summary>
        ''' Retreives count of rows in table.
        ''' </summary>
        ''' <returns>Count of rows in table.</returns>
        Public ReadOnly Property Count() As Integer
            Get
                Return p_Dictionary.Count
            End Get
        End Property

        ''' <summary>
        ''' Adds or modifies existing value for given word.
        ''' </summary>
        ''' <param name="sWord">Word.</param>
        ''' <param name="nValue">Integer value to be stored.</param>
        Public Sub Add(ByVal sWord As String, ByVal nValue As Integer)
            If Not p_Dictionary.ContainsKey(sWord) Then
                p_Dictionary.Add(sWord, 1)
            Else
                p_Dictionary(sWord) = nValue
            End If

            Invalidate()
        End Sub

        ''' <summary>
        ''' Retreives value stored for given word.
        ''' </summary>
        ''' <param name="sWord">Word whichs value will be retreived.</param>
        ''' <returns>Stored value for given word.</returns>
        Public Function GetWordValue(ByVal sWord As String) As Integer
            Return p_Dictionary(sWord)
        End Function

        ''' <summary>
        ''' Routine for automatically incrementing value for given word by 1 if exists.
        ''' If given word does not exist, it is automatically added with value 1.
        ''' </summary>
        ''' <param name="sWord">Word to be counted.</param>
        Public Sub CountWord(ByVal sWord As String)
            If StrIsAny(sWord) Then
                If ContainsWord(sWord) Then
                    p_Dictionary(sWord) = p_Dictionary(sWord) + 1
                Else
                    Add(sWord, 1)
                End If

                Invalidate()
            End If
        End Sub

        Private Sub SortByValue()
            If Not p_IsSorted Then
                Dim sortedList As List(Of KeyValuePair(Of String, Integer)) = p_Dictionary.ToList()

                sortedList.Sort(Function(a As KeyValuePair(Of String, Integer), _
                                           b As KeyValuePair(Of String, Integer)) _
                                           (b.Value.CompareTo(a.Value)))

                p_Dictionary = sortedList.ToDictionary(Of String, Integer) _
                                                        (Function(keyPair As KeyValuePair(Of String, Integer)) keyPair.Key, _
                                                         Function(valuePair As KeyValuePair(Of String, Integer)) valuePair.Value)

                Invalidate()
                p_IsSorted = True
            End If
        End Sub

        ''' <summary>
        ''' Clears the table content.
        ''' </summary>
        Public Sub Clear()
            If Me.p_ValuesCache IsNot Nothing Then Me.p_WordsCache.Clear()
            If Me.p_ValuesCache IsNot Nothing Then Me.p_ValuesCache.Clear()

            p_Dictionary.Clear()
        End Sub
#End Region

#Region ":: Table Data Accessors"
        Public ReadOnly Property Rows() As Array
            Get
                SortByValue()
                Return p_Dictionary.ToArray()
            End Get
        End Property

        Public ReadOnly Property Values() As Integer()
            Get
                SortByValue()
                Return p_Dictionary.Values.ToArray()
            End Get
        End Property

        Public ReadOnly Property Words() As String()
            Get
                SortByValue()
                Return p_Dictionary.Keys.ToArray()
            End Get
        End Property

        Public ReadOnly Property ValuesQITAPositiveArray() As QITAPositiveArray
            Get
                'If p_ValuesCache Is Nothing Then
                '    p_ValuesCache = New QITAPositiveArray(Me.Values())
                'End If

                'Return p_ValuesCache

                Return New QITAPositiveArray(Me.Values())
            End Get
        End Property

        Public ReadOnly Property ValuesPositiveArray() As Integer()
            Get
                Return Me.ValuesQITAPositiveArray.ToPositiveIntegerArray()
            End Get
        End Property

        Public ReadOnly Property WordsQITAPositiveArray() As QITAPositiveArray
            Get
                'If p_WordsCache Is Nothing Then
                '    p_WordsCache = New QITAPositiveArray(Me.Words())
                'End If

                'Return p_WordsCache

                Return New QITAPositiveArray(Me.Words())
            End Get
        End Property

        Public ReadOnly Property WordsPositiveArray() As String()
            Get
                Return WordsQITAPositiveArray.ToPositiveArray(Of String)()
            End Get
        End Property

        Public ReadOnly Property GetWordOnIndex(ByVal n As Integer) As String
            Get
                If n <= Me.WordsQITAPositiveArray.Count Then
                    Return Me.WordsQITAPositiveArray.At(n)
                End If

                Return Nothing
            End Get
        End Property
#End Region

#Region ":: IQITADataType"
        Public Function ToChartableData() As QITAChartableDataArray Implements QITAInterfaces.IQITADataType.ToChartableData
            Dim q As New QITAChartableDataArray(Me.Count(), "Index", p_Column1Name, p_Column2Name)
            Dim yValues As Integer() = Me.ValuesPositiveArray()

            For i As Integer = 1 To Me.Count()
                q.SetNextXYD(i, yValues(i), GetWordOnIndex(i))
            Next

            q.Done()
            Return q
        End Function
#End Region
    End Class

    ''' <summary>
    ''' Provides unified Word to frequency simple table.
    ''' </summary>
    Public Class QITAWordFrequencyTable
        Inherits QITAWordToNumberTable

        Public Sub New(ByVal sWordColumnName As String, _
                       ByVal sColumn1Name As String)

            MyBase.Column1Name = sWordColumnName
            MyBase.Column2Name = sColumn1Name
        End Sub

        Public Function GetWordAtIndex(ByVal index As Integer) As String
            Return MyBase.Word(index)
        End Function

        Public Function GetWordFrequency(ByVal sWord As String) As Integer
            If MyBase.ContainsWord(sWord) Then
                Return MyBase.Value(sWord)
            Else
                Throw New Exception("Word is not contained in table!")
                Return -1
            End If
        End Function

        Public Function ToTable(ByRef Text As IQITAText) As QITATable
            Dim frequencies As Integer() = Me.GetFrequenciesInPositiveArray()
            Dim words As String() = Me.GetWordsPositiveArray()
            Dim textTokenCount As Integer = Text.TokenCount

            Dim t As New QITATable("Frequency table", "#", MyBase.Column1Name, MyBase.Column2Name, "%")
            t.SetChartableColumns("#", MyBase.Column2Name)
            t.PopulateAllColumnsRows(frequencies.Count - 1)

            For i As Integer = 1 To words.Count - 1
                t.EditRow(i, _
                             i, _
                             words(i), _
                             Format(frequencies(i), "### ### ###"), _
                             Math.Round(((frequencies(i) / textTokenCount) * 100), 3))
            Next

            Return t
        End Function

        Public Function ToDictionary() As Dictionary(Of String, Integer)
            Dim m As New Dictionary(Of String, Integer)(Me.Rows.Length)
            Dim frequencies As Integer() = Me.GetFrequenciesInPositiveArray()
            Dim wordsLocal As String() = Me.GetWordsPositiveArray()

            For i As Integer = 1 To wordsLocal.Count - 1
                m.Add(wordsLocal(i), frequencies(i))
            Next

            Return m
        End Function

        Public Function GetFrequenciesInPositiveArray() As Integer()
            Return Me.ValuesPositiveArray
        End Function

        Public Function GetWordsPositiveArray() As String()
            Return MyBase.WordsPositiveArray
        End Function

    End Class

    ''' <summary>
    ''' Provides simple table container with few handy functions. Rows are positive-indexed
    ''' (indexed from 1). Columns are accesible throught their name or zero-based index.
    ''' </summary>
    Public Class QITATable
        Inherits QITAResultBase
        Implements IQITADataType

        Public Enum ePreferredDisplay
            AsList
            AsGrid
        End Enum

        Private p_Table(0)() As Object
        Private p_TableName As String = Nothing
        Private p_ColumnNames As New List(Of String)
        Private p_ColumnNamesDictionary As New Dictionary(Of String, Integer)
        Private p_DisplayValue As Object = Nothing
        Private p_ChartableXColumn As Integer = -1
        Private p_ChartableYColumn As Integer = -1
        Private p_ChartableZColumn As Integer = -1
        Private p_PreferredDisplayType As ePreferredDisplay = ePreferredDisplay.AsList

        Public Sub New(ByVal tableName As String)
            MyBase.New(Nothing, Nothing)

            p_TableName = tableName
        End Sub

        Public Sub New(ByVal tableName As String, ByVal ParamArray columnNames() As String)
            MyBase.New(Nothing, Nothing)

            p_TableName = tableName
            Me.AddColumns(columnNames)
        End Sub

        Public Sub New(ByRef text As IQITAText)
            MyBase.New(text, Nothing)

            p_TableName = text.TextName
        End Sub

        Public Sub New(ByRef text As IQITAText, ByVal ParamArray columnNames() As String)
            MyBase.New(text, Nothing)
            p_TableName = text.TextName
            Me.AddColumns(columnNames)
        End Sub

#Region "TABLE Row/Columns Adding"
        ''' <summary>
        ''' Adds a new row.
        ''' </summary>
        ''' <returns>New row index.</returns>
        Public Function AddRow() As Integer
            Dim newSize As Integer = Me.RowsCount + 1
            PopulateAllColumnsRows(newSize)
            Return newSize
        End Function

        ''' <summary>
        ''' Adds data to columns.
        ''' </summary>
        ''' <param name="rowsData"></param>
        ''' <returns>New row index.</returns>
        Public Function AddRow(ByVal ParamArray rowsData() As String) As Integer
            If IsAny(rowsData) Then
                If rowsData.Count <= ColumnCount Then
                    Dim i As Integer = AddRow()
                    For n As Integer = 0 To rowsData.Count() - 1
                        CellValue(i, n) = rowsData(n)
                    Next

                    Return i
                Else
                    Throw New Exception("AddRow has invalid number of data not coresponding with column count.")
                    Return -1
                End If
            End If
        End Function

        ''' <summary>
        ''' Sets all cells of given row into given data.
        ''' </summary>
        ''' <param name="iRowIndex">Index of a row to edit.</param>
        ''' <param name="rowData">New cell values.</param>
        ''' <returns>Row index.</returns>
        ''' <remarks>Number of data has to be the same as number of columns.</remarks>
        Public Function EditRow(ByVal iRowIndex As Integer, ByVal ParamArray rowData() As String) As Integer
            If IsAny(rowData) Then
                If iRowIndex = 0 Then
                    Throw New Exception("QITATable is positive-indexed, row indexes starts at index 1")
                    Return -1
                End If

                If iRowIndex <= Me.RowsCount Then
                    If rowData.Count = ColumnCount Then
                        For i As Integer = 0 To rowData.Count - 1
                            CellValue(iRowIndex, i) = rowData(i)
                        Next

                        Return iRowIndex
                    Else
                        Throw New Exception("EditRow has invalid number of data not coresponding with column count.")
                        Return -1
                    End If
                Else
                    Throw New Exception("Row index is invalid.")
                    Return -1
                End If
            End If
        End Function

        ''' <summary>
        ''' Adds a new column with name.
        ''' </summary>
        ''' <param name="sColumnName">Name of column.</param>
        Public Overridable Sub AddColumn(ByVal sColumnName As String)
            If Not StrIsAny(sColumnName) Then
                Throw New ArgumentException("sColumnName cannot be null!")
            End If

            p_ColumnNames.Add(sColumnName)
            p_ColumnNamesDictionary.Add(sColumnName, Me.p_ColumnNames.Count - 1)

            ReDim Preserve p_Table(Me.p_ColumnNames.Count - 1)

            If RowsCount = -1 Then
                For i As Integer = 0 To (Me.p_ColumnNames.Count - 1)
                    ReDim Preserve p_Table(i)(0)
                Next
            End If
        End Sub

        Public Overridable Sub AddColumns(ByVal ParamArray sColumnNames() As String)
            For Each s As String In sColumnNames
                AddColumn(s)
            Next
        End Sub

        ''' <summary>
        ''' Populates all column rows to same row count.
        ''' </summary>
        ''' <param name="nNewSize">New row count.</param>
        Public Function PopulateAllColumnsRows(ByVal nNewSize As Integer) As Integer
            For i As Integer = 0 To ColumnCount - 1
                ReDim Preserve p_Table(i)(nNewSize)
            Next

            Return nNewSize
        End Function

        ''' <summary>
        ''' Populates rows of table to given row count.
        ''' </summary>
        ''' <param name="nRowsCount">Row count.</param>
        ''' <returns>Row count.</returns>
        Public Function AddRows(ByVal nRowsCount As Integer) As Integer
            Return Me.PopulateAllColumnsRows(nRowsCount)
        End Function

        ''' <summary>
        ''' Removes all rows
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Clear()
            For i As Integer = 0 To ColumnCount - 1
                Erase p_Table(i)
            Next
        End Sub
#End Region

#Region "TABLE Informations"
        ''' <summary>
        ''' Returns list of Text Table Column Names.
        ''' </summary>
        Public Overridable ReadOnly Property ColumnNames() As List(Of String)
            Get
                Return p_ColumnNames
            End Get
        End Property

        ''' <summary>
        ''' Retreives data from all columns.
        ''' </summary>
        Public ReadOnly Property Columns() As List(Of Object())
            Get
                Dim m As New List(Of Object())

                For i As Integer = 0 To UBound(p_Table)
                    m.Add(p_Table(i))
                Next

                Return m
            End Get
        End Property

        ''' <summary>
        ''' Retreives data from given column.
        ''' </summary>
        ''' <param name="sColumnName">Column name.</param>
        ''' <returns>Column data object array.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Column(ByVal sColumnName As String) As Object()
            Get
                Return Me.Column(sColumnName, Nothing)
            End Get
        End Property

        ''' <summary>
        ''' Retreives data from given column and applies a function f on it.
        ''' </summary>
        ''' <param name="sColumnName">Column name.</param>
        ''' <param name="f">Function that is applied on each element of column data array. (Param1: [IN] object stored in array passed to function. Returns: resulting object.)</param>
        ''' <returns>Column data object array.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Column(ByVal sColumnName As String, ByVal f As Func(Of Object, Object)) As Object()
            Get
                Return Me.GetColumnData(Of Object)(sColumnName, f)
            End Get
        End Property

        ''' <summary>
        ''' Retreives data from given column and applies a function f on it.
        ''' </summary>
        ''' <param name="sColumnName">Column name.</param>
        ''' <param name="f">Function that is applied on each element of column data array. Function: [IN] Param1 -- object stored in array. [OUT] Result.</param>
        ''' <returns>Data from given column.</returns>
        ''' <remarks></remarks>
        Public Function GetColumnData(Of T)(ByVal sColumnName As String, ByVal f As Func(Of Object, T)) As T()
            If Me.HasColumn(sColumnName) Then
                Return Me.GetColumnData(Me.GetColumnIndex(sColumnName), f)
            Else
                Throw New ExecutionEngineException(NoColumnWithGivenNameMessage(sColumnName))
            End If
        End Function

        Public Function GetColumnData(Of T)(ByVal columnIndex As Integer, ByVal f As Func(Of Object, T)) As T()
            If Me.RowsCount > 0 Then
                Dim o() As Object = Column(columnIndex)
                Dim m(o.Count - 1) As T

                If f IsNot Nothing Then
                    For i As Integer = 1 To o.Count - 1
                        m(i) = f(o(i))
                    Next
                End If

                Return m
            End If

            Return Nothing
        End Function

        ''' <summary>
        ''' Retreives data from given column.
        ''' </summary>
        ''' <param name="columnIndex">Column index.</param>
        ''' <returns>Column data object array.</returns>
        Public ReadOnly Property Column(ByVal columnIndex As Integer) As Object()
            Get
                Return p_Table(columnIndex)
            End Get
        End Property

        ''' <summary>
        ''' Retreives number of rows in table.
        ''' </summary>
        Public ReadOnly Property RowsCount() As Integer
            Get
                If IsAny(p_Table(0)) Then
                    Return p_Table(0).Count - 1
                Else
                    Return -1
                End If
            End Get
        End Property

        Public ReadOnly Property ColumnCount() As Integer
            Get
                Return p_Table.Count
            End Get
        End Property

        ''' <summary>
        ''' Sets or gets name of table.
        ''' </summary>
        Public Property TableName() As String
            Get
                Return p_TableName
            End Get
            Set(ByVal value As String)
                p_TableName = value
            End Set
        End Property

        ''' <summary>
        ''' Sets or gets type of control which is preffered for displaying contained data.
        ''' </summary>
        Public Property PreferredDisplayType() As ePreferredDisplay
            Get
                Return p_PreferredDisplayType
            End Get
            Set(ByVal value As ePreferredDisplay)
                p_PreferredDisplayType = value
            End Set
        End Property

        Public Function HasColumn(ByVal sColumnName As String) As Boolean
            Return p_ColumnNamesDictionary.ContainsKey(sColumnName)
        End Function

        Public Function GetColumnIndex(ByVal sColumnName As String) As Integer
            If p_ColumnNamesDictionary.ContainsKey(sColumnName) Then
                Return p_ColumnNamesDictionary(sColumnName)
            Else
                Return -1
            End If
        End Function

        ''' <summary>
        ''' Retreives name of given column.
        ''' </summary>
        ''' <param name="index">Index of column.</param>
        ''' <returns>Name of column if exists. Nothing otherwise.</returns>
        Public Function GetColumnName(ByVal index As Integer) As String
            If index = -1 Then
                Return Nothing
            End If

            If index < Me.ColumnCount Then
                Return Me.ColumnNames(index)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Converts table to CSV table string
        ''' </summary>
        ''' <returns>CSV String of the table.</returns>
        Public Function TableToString() As String
            Dim sOutput As New Text.StringBuilder

            For j As Integer = 0 To Me.ColumnCount - 1
                sOutput.Append(Me.GetColumnName(j) & vbTab)
            Next

            sOutput.Append(Environment.NewLine)

            For i As Integer = 1 To Me.RowsCount
                For j As Integer = 0 To Me.ColumnCount - 1
                    sOutput.Append(Me.CellValue(i, j).ToString() & vbTab)
                Next

                sOutput.Append(Environment.NewLine)
            Next

            Return sOutput.ToString()
        End Function
#End Region

#Region "CELL/COLUMN Accessors"
        ''' <summary>
        ''' Gets or sets value of given table cell.
        ''' </summary>
        ''' <param name="iRow">Table row (1-based) index.</param>
        ''' <param name="sColumnName">Table column name.</param>
        ''' <value>Any object to be stored to table.</value>
        ''' <returns>Object stored in table cell.</returns>
        Default Public Property CellValue(ByVal iRow As Integer, ByVal sColumnName As String) As Object
            Get
                If Me.HasColumn(sColumnName) Then
                    Return CellValue(iRow, Me.GetColumnIndex(sColumnName))
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Object)
                If Me.HasColumn(sColumnName) Then
                    CellValue(iRow, Me.GetColumnIndex(sColumnName)) = value
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets value of given table cell.
        ''' </summary>
        ''' <param name="iRow">Table row index.</param>
        ''' <param name="column">Table column descriptor.</param>
        ''' <value>Any object to be stored to table.</value>
        ''' <returns>Object stored in table cell.</returns>
        Default  Public Property CellValue(ByVal iRow As Integer, ByVal column As Integer) As Object
            Get
                If column <= -1 Then
                    Return Nothing
                Else
                    Return p_Table(column)(iRow)
                End If
            End Get
            Set(ByVal value As Object)
                p_Table(column)(iRow) = value
            End Set
        End Property

        Public Property LastCellValue(ByVal sColumnName As String) As Object
            Get
                Return CellValue(Me.RowsCount, sColumnName)
            End Get
            Set(ByVal value As Object)
                CellValue(Me.RowsCount, sColumnName) = value
            End Set
        End Property

        Public Property LastCellValue(ByVal column As Integer) As Object
            Get
                Return CellValue(Me.RowsCount, column)
            End Get
            Set(ByVal value As Object)
                CellValue(Me.RowsCount, column) = value
            End Set
        End Property

        ''' <summary>
        ''' Assigns row values for given column.
        ''' </summary>
        ''' <param name="column">Destination column that will be filled.</param>
        ''' <param name="rows">Array of values that will be used as values.</param>
        ''' <returns>New rows count.</returns>
        Public Function AssignRowsToColumn(ByVal column As Integer, ByRef rows As Array) As Integer
            p_Table(column) = Me.TypeCastHelper(rows)
            Return PopulateAllColumnsRows(p_Table(column).Count - 1)
        End Function

        Private Function TypeCastHelper(ByRef rows As Array) As Object()
            Dim m As Object()

            If TypeOf rows Is Int32() Then
                ReDim m(UBound(rows))

                For i As Integer = 0 To UBound(rows)
                    m(i) = rows(i)
                Next

                Return m
            End If

            Return rows
        End Function
#End Region

#Region "TABLE Agregators"
        ''' <summary>
        ''' Iterates throught all values in source column and uses function f to
        ''' transform these values into their neighbourhooding cells in destination column.
        ''' </summary>
        ''' <param name="sourceColumn">Source column to be iterated.</param>
        ''' <param name="destinationColumn">Destination column to be filled.</param>
        ''' <param name="f">Function (param1: cell value) that will be applied to source value and its return value will be saved in destination.</param>
        ''' <returns>True.</returns>
        Public Function Agregate(ByVal sourceColumn As Integer, _
                                 ByVal destinationColumn As Integer, _
                                 ByRef f As Func(Of Object, Object)) As Boolean

            For i As Integer = 1 To Me.RowsCount
                p_Table(destinationColumn)(i) = f(p_Table(sourceColumn)(i))
            Next

            Return True
        End Function

        ''' <summary>
        ''' Iterates throught all values in source column and uses function f to
        ''' transform these values into their neighbourhooding cells in destination column.
        ''' </summary>
        ''' <param name="sourceColumn">Source column to be iterated.</param>
        ''' <param name="destinationColumn">Destination column to be filled.</param>
        ''' <param name="f">Function (param1: cell value) that will be applied to source value and its return value will be saved in destination.</param>
        ''' <returns>True when all columns are existing. False when any of given columns do not exist.</returns>
        Public Function Agregate(ByVal sourceColumn As String, _
                                 ByVal destinationColumn As String, _
                                 ByRef f As Func(Of Object, Object)) As Boolean
            If Me.HasColumn(sourceColumn) AndAlso Me.HasColumn(destinationColumn) Then
                Return Me.Agregate(Me.GetColumnIndex(sourceColumn), Me.GetColumnIndex(destinationColumn), f)
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' Iterates throught all values in column and applies function f to them.
        ''' </summary>
        ''' <param name="column">Column to be iterated.</param>
        ''' <param name="f">Function (param1: cell row index, param2: cell value) that will be applied to cell value and used to replace its value by f result.</param>
        ''' <returns>True.</returns>
        Public Function Agregate(ByVal column As Integer, _
                                 ByRef f As Func(Of Integer, Object, Object)) As Boolean
            For i As Integer = 1 To Me.RowsCount
                p_Table(column)(i) = f(i, p_Table(column)(i))
            Next

            Return True
        End Function

        ''' <summary>
        ''' Iterates throught all values in column and applies function f to them.
        ''' </summary>
        ''' <param name="column">Column to be iterated.</param>
        ''' <param name="f">Function (param1: cell row index, param2: cell value) that will be applied to cell value and used to replace its value by f result.</param>
        ''' <returns>True when column exists, else False.</returns>
        Public Function Agregate(ByVal column As String, _
                                 ByRef f As Func(Of Integer, Object, Object)) As Boolean
            If Me.HasColumn(column) Then
                Return Me.Agregate(Me.GetColumnIndex(column), f)
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Iterates throught all rows and summing value returned by given function f.
        ''' </summary>
        ''' <param name="f">Function (PARAM1: [in] row index) that is applied to row index.</param>
        ''' <returns>Sum.</returns>
        Public Function IterateThroughtRows(ByVal f As Func(Of Integer, Double)) As Double
            Dim dOutput As Double = 0

            For i As Integer = 1 To Me.RowsCount
                dOutput += f(i)
            Next

            Return dOutput
        End Function

        Public Function SumColumn(ByVal sColumnName As String) As Double
            If Me.HasColumn(sColumnName) Then
                Return SumColumn(Me.GetColumnIndex(sColumnName))
            Else
                Throw New ExecutionEngineException(NoColumnWithGivenNameMessage(sColumnName))
            End If
        End Function

        Public Function AverageColumn(ByVal sColumnName As String) As Double
            If Me.HasColumn(sColumnName) Then
                Return AverageColumn(Me.GetColumnIndex(sColumnName))
            Else
                Throw New ExecutionEngineException(NoColumnWithGivenNameMessage(sColumnName))
            End If
        End Function

        Public Function SumColumn(ByVal column As Integer) As Double
            Dim dSum As Double = 0

            For i As Integer = 1 To Me.RowsCount
                dSum += ToNumber(Me.CellValue(i, column))
            Next

            Return dSum
        End Function

        Public Function AverageColumn(ByVal column As Integer) As Double
            Return (Me.SumColumn(column) / Me.RowsCount)
        End Function
#End Region

#Region "IQITAResult"
        ''' <summary>
        ''' Reference to QITATable
        ''' </summary>
        Public Overrides Property Value() As Object
            Get
                Return Me
            End Get
            Set(ByVal value As Object)

            End Set
        End Property

        Public Overrides Property ComplexValue() As Object
            Get
                Return Me
            End Get
            Set(ByVal value As Object)

            End Set
        End Property

        Public Overrides ReadOnly Property IsComplex() As Boolean
            Get
                Return True
            End Get
        End Property
#End Region

#Region "IQITADataType"
        ''' <summary>
        ''' Sets columns from which the chartable data will be derived from.
        ''' </summary>
        ''' <param name="xColumnName">Column for X coord. If NOTHING is passed, actual row index will be used.</param>
        ''' <param name="yColumnName">Column for Y coord.</param>
        Public Sub SetChartableColumns(ByVal xColumnName As String, ByVal yColumnName As String, Optional ByVal zColumnName As String = Nothing)
            Dim x As Integer = -1
            Dim y As Integer = -1
            Dim z As Integer = -1

            If StrIsAny(xColumnName) Then
                If Me.HasColumn(xColumnName) Then
                    x = Me.GetColumnIndex(xColumnName)
                End If
            End If

            If Me.HasColumn(yColumnName) Then
                y = Me.GetColumnIndex(yColumnName)
            End If

            If y = -1 Then
                Throw New Exception("Given chartable Y column is invalid.")
            End If

            If StrIsAny(zColumnName) Then
                z = Me.GetColumnIndex(zColumnName)
            End If

            SetChartableColumns(x, y, z)
        End Sub

        ''' <summary>
        ''' Sets columns from which the chartable data will be derived from.
        ''' </summary>
        ''' <param name="iXColumn">Column for X coord. If -1, actual row index will be used.</param>
        ''' <param name="iYColumn">Column for Y coord.</param>
        Public Sub SetChartableColumns(ByVal iXColumn As Integer, ByVal iYColumn As Integer, Optional ByVal iZColumn As Integer = -1)
            p_ChartableXColumn = iXColumn
            p_ChartableYColumn = iYColumn
            p_ChartableZColumn = iZColumn
        End Sub

        ''' <summary>
        ''' Converts actual table to chartable data.
        ''' </summary>
        ''' <returns>Chartable Data.</returns>
        Public Function ToChartableData() As QITAChartableDataArray Implements IQITADataType.ToChartableData
            If p_ChartableYColumn > -1 Then
                Dim q As New QITAChartableDataArray(Me.RowsCount, _
                                                    Me.GetColumnName(p_ChartableXColumn), _
                                                    Me.GetColumnName(p_ChartableYColumn), _
                                                    Me.GetColumnName(p_ChartableZColumn))

                For i As Integer = 1 To Me.RowsCount
                    If p_ChartableXColumn > -1 Then
                        q.SetNextXYD(Me.CellValue(i, p_ChartableXColumn), _
                                     Me.CellValue(i, p_ChartableYColumn), _
                                     Me.CellValue(i, p_ChartableZColumn))
                    Else
                        q.SetNextXYD(i, _
                                     Me.CellValue(i, p_ChartableYColumn), _
                                     Me.CellValue(i, p_ChartableZColumn))
                    End If
                Next

                q.Done()
                Return q
            Else
                Return Nothing
            End If
        End Function
#End Region

#Region "ERROR Messages"
        Private Function NoColumnWithGivenNameMessage(ByVal sGivenColumnName As String) As String
            Return "No column named: " & sGivenColumnName & " is contained in table!"
        End Function
#End Region
    End Class

    ''' <summary>
    ''' Provides basic informations about Text.
    ''' </summary>
    Public Class QITATextTable
        Inherits QITATable

        ''' <summary>
        ''' Describes column names and column order of Text table.
        ''' </summary>
        Public Enum TextTableColumns As Integer
            ''' <summary>
            ''' Frequency rank of word.
            ''' </summary>
            Rank
            ''' <summary>
            ''' Averaged word rank by frequencies.
            ''' </summary>
            AveragedRank
            ''' <summary>
            ''' Word frequency in text.
            ''' </summary>
            WordFrequency
            ''' <summary>
            ''' Word itself.
            ''' </summary>
            ''' <remarks></remarks>
            Word

            WordType
        End Enum

        Public Sub New(ByRef text As IQITAText)
            MyBase.New(text)

            For Each s As String In [Enum].GetNames(GetType(TextTableColumns)).ToList()
                MyBase.AddColumn(s)
            Next
        End Sub

        Public Overrides Function ToCellString() As String
            Return MyBase.TableName
        End Function

        Public Function GetWord(ByVal row As Integer) As String
            Return CDbl(Me.CellValue(row, TextTableColumns.Word))
        End Function

        Public Function GetRank(ByVal row As Integer) As Double
            Return CDbl(Me.CellValue(row, TextTableColumns.Rank))
        End Function

        Public Function GetAveragedRank(ByVal row As Integer) As String
            Return CStr(Me.CellValue(row, TextTableColumns.AveragedRank))
        End Function

        Public Function GetFrequency(ByVal row As Integer) As Long
            Return CLng(Me.CellValue(row, TextTableColumns.WordFrequency))
        End Function

    End Class

    ''' <summary>
    ''' Provides container for chartable data in X, Y, Z (description) format. After
    ''' saving data, function "Done" must be called, otherwise charting may fail.
    ''' ChartableDataArray is ZERO-BASED and thus all row initializations have to
    ''' pass ZERO-based (zero-indexed) row count.
    ''' </summary>
    Public Class QITAChartableDataArray
        Public Enum Coordinate
            X
            Y
        End Enum

        Private _xValues() As Object
        Private _yValues() As Object
        Private _Description() As Object
        Private _currentIndex As Integer = 0
        Private _isDimensed As Boolean = False
        Private _RowsCount As Integer = -1
        Private _DataName As String = Nothing
        Private _DataTitle As String = Nothing
        Private _DataXTitle As String = Nothing
        Private _DataYTitle As String = Nothing
        Private _DataDTitle As String = Nothing

        Public Property DataName() As String
            Get
                Return _DataName
            End Get
            Set(ByVal value As String)
                _DataName = value
            End Set
        End Property

        Public Property DataTitle() As String
            Get
                Return _DataTitle
            End Get
            Set(ByVal value As String)
                _DataTitle = value
            End Set
        End Property

        Public Sub New(ByVal xTitle As String, ByVal yTitle As String, ByVal dTitle As String)
            SetDataTitles(xTitle, yTitle, dTitle)
        End Sub

        Public Sub New(ByVal iRowsCount As Integer, _
                       ByVal xTitle As String, _
                       ByVal yTitle As String, _
                       ByVal dTitle As String)

            SetRowsCount(iRowsCount)
            SetDataTitles(xTitle, yTitle, dTitle)
        End Sub

#Region "PUBLIC Main Functions"
        Public Sub SetRowsCount(ByVal iRowsCount As Integer)
            If iRowsCount > 0 Then
                ReDim _xValues(iRowsCount - 1)
                ReDim _yValues(iRowsCount - 1)
                ReDim _Description(iRowsCount - 1)

                _RowsCount = iRowsCount
                _isDimensed = True
            End If
        End Sub

        Public Sub SetNextXYD(ByVal x As Object, ByVal y As Object, ByVal description As String)
            If Not _isDimensed Then
                Throw New Exception("ChartableDataArray must have known row count before setting data. Use SetRowCount first.")
                Exit Sub
            End If

            If _currentIndex > UBound(_xValues) Then
                Throw New Exception("Accessing unexisting row.")
                Exit Sub
            End If

            _xValues(_currentIndex) = If(IsNumber(CStr(x)), ToNumber(x), x)  'ToNumber(x)
            _yValues(_currentIndex) = ToNumber(y)
            _Description(_currentIndex) = description
            _currentIndex += 1
        End Sub

        Public Sub SortBy(ByVal column As Coordinate, ByVal order As SortOrder)
            Dim sortList As New List(Of TripletContainer)(_xValues.Count)

            For i As Integer = 0 To UBound(_xValues)
                sortList.Add(New TripletContainer(_xValues(i), _yValues(i), _Description(i)))
            Next

            Select Case column
                Case Coordinate.X
                    If order = SortOrder.Ascending Then
                        sortList.Sort(Function(t1 As TripletContainer, t2 As TripletContainer) _
                                          (t1.A.CompareTo(t2.A)))
                    Else
                        sortList.Sort(Function(t1 As TripletContainer, t2 As TripletContainer) _
                                          (t2.A.CompareTo(t1.A)))
                    End If

                Case Coordinate.Y
                    If order = SortOrder.Ascending Then
                        sortList.Sort(Function(t1 As TripletContainer, t2 As TripletContainer) _
                                          (t1.B.CompareTo(t2.B)))
                    Else
                        sortList.Sort(Function(t1 As TripletContainer, t2 As TripletContainer) _
                                          (t2.B.CompareTo(t1.B)))
                    End If
            End Select

            For i As Integer = 0 To UBound(_xValues)
                _xValues(i) = sortList(i).A
                _yValues(i) = sortList(i).B
                _Description(i) = sortList(i).C
            Next

            Application.DoEvents()
        End Sub

        ''' <summary>
        ''' Finalizes data input to DataArray.
        ''' </summary>
        ''' <returns>TRUE when data suitable for charting are contained.</returns>
        Public Function Done() As Boolean
            If _isDimensed Then
                SortBy(Coordinate.X, SortOrder.Ascending)
                Return True
            End If

            Return False
        End Function
#End Region

#Region "COORD Getters & Data Info"
        ''' <summary>
        ''' Retreives X coord of point at index.
        ''' </summary>
        ''' <param name="index">Index of point.</param>
        ''' <returns>X coord.</returns>
        Public Function GetX(ByVal index As Integer) As Object
            Return _xValues(index)
        End Function

        ''' <summary>
        ''' Retreives Y coord of point at index.
        ''' </summary>
        ''' <param name="index">Index of point.</param>
        ''' <returns>Y coord.</returns>
        Public Function GetY(ByVal index As Integer) As Object
            Return _yValues(index)
        End Function

        ''' <summary>
        ''' Retreives description of point at index.
        ''' </summary>
        ''' <param name="index">Index of point.</param>
        ''' <returns>Description of point.</returns>
        Public Function GetDescription(ByVal index As Integer) As Object
            If _Description IsNot Nothing Then
                Return _Description(index)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Sets title (axes labels) for stored data.
        ''' </summary>
        ''' <param name="xTitle">X axis title.</param>
        ''' <param name="yTitle">Y axis title.</param>
        ''' <param name="dTitle">Description source title.</param>
        Public Sub SetDataTitles(ByVal xTitle As String, ByVal yTitle As String, ByVal dTitle As String)
            _DataXTitle = xTitle
            _DataYTitle = yTitle
            _DataDTitle = dTitle
        End Sub

        ''' <summary>
        ''' Retreives X-axis title.
        ''' </summary>
        Public Function GetXAxisTitle() As String
            Return _DataXTitle
        End Function

        ''' <summary>
        ''' Retreives Y-axis title.
        ''' </summary>
        Public Function GetYAxisTitle() As String
            Return _DataYTitle
        End Function

        ''' <summary>
        ''' Retreives description source title.
        ''' </summary>
        Public Function GetDAxisTitle() As String
            Return _DataDTitle
        End Function

        ''' <summary>
        ''' Returns count of rows.
        ''' </summary>
        ''' <returns>Rows count.</returns>
        Public Function Count() As Long
            Return _RowsCount
        End Function
#End Region
    End Class

    ''' <summary>
    ''' Provides data container with QITA Project reference.
    ''' </summary>
    Public Class QITAProjectDataSource
        Private _project As IQITAProject = Nothing
        Private _dataSource As Object = Nothing

        Public ReadOnly Property Project() As IQITAProject
            Get
                Return _project
            End Get
        End Property

        Public ReadOnly Property DataContainer() As Object
            Get
                Return _dataSource
            End Get
        End Property

        Public Sub New(ByRef project As IQITAProject, ByRef dataSource As Object)
            _project = project
            _dataSource = dataSource
        End Sub
    End Class
End Namespace

Public Class QITA

End Class
