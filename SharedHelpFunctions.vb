Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Reflection
Imports System.Text
Imports System.Diagnostics
Imports System.Threading
Imports System.ComponentModel
Imports Microsoft.Win32.SafeHandles
Imports Microsoft.Win32
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports QITA_OLTK.QITAInterfaces
Imports QITA_OLTK.QITADataTypes
Imports QITA_OLTK.QITAMorphoAnalyzers

Module SharedHelpFunctions
#Region "FILES, PROGRAMS"
    Public Function GetFileTextContent(ByVal sFile As String, ByVal encoding As System.Text.Encoding) As String
        Dim sContent As String = Nothing
        If GetFileTextContent(sFile, sContent, encoding, False, Nothing) Then
            Return sContent
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' Reads text file content.
    ''' </summary>
    ''' <param name="sFile">File to be readed.</param>
    ''' <param name="sOutContent">Readed content.</param>
    ''' <param name="InOutEncoding">If set to NOTHING, encoding will be detected and returned.</param>
    ''' <param name="reserved">Reserved for further usage. Set to FALSE.</param>
    ''' <param name="sOutError">Error message output.</param>
    ''' <returns>TRUE if success.</returns>
    Public Function GetFileTextContent(ByVal sFile As String, _
                                       ByRef sOutContent As String, _
                                       ByRef InOutEncoding As System.Text.Encoding, _
                                       ByVal reserved As Boolean, _
                                       ByRef sOutError As String) As Boolean

        If Not IsAny(InOutEncoding) Then
            If GetFileTextContent(sFile, sOutContent, Text.Encoding.UTF8, sOutError) Then
                If Not ContainsUTF8InvalidChar(sOutContent) Then
                    InOutEncoding = Text.Encoding.UTF8
                    Return True
                End If
            End If

            If GetFileTextContent(sFile, sOutContent, Text.Encoding.Default, sOutError) Then
                InOutEncoding = Text.Encoding.Default
                Return True
            End If
        Else
            If GetFileTextContent(sFile, sOutContent, InOutEncoding, sOutError) Then
                Return True
            End If
        End If

    End Function

    ''' <summary>
    ''' Reads text file content.
    ''' </summary>
    ''' <param name="sFile">File to be readed.</param>
    ''' <param name="sOutContent">Readed content.</param>
    ''' <param name="eEncoding">Encoding of file content.</param>
    ''' <param name="sOutError">Output: Error message.</param>
    ''' <returns>TRUE if success.</returns>
    Public Function GetFileTextContent(ByVal sFile As String, _
                                       ByRef sOutContent As String, _
                                       ByVal eEncoding As System.Text.Encoding, _
                                       ByRef sOutError As String) As Boolean
        Try
            Using sr As New StreamReader(sFile, eEncoding, False)
                sOutContent = sr.ReadToEnd()
            End Using

            Return True
        Catch e As Exception
            sOutContent = e.Message

            Return False
        End Try
    End Function

    ''' <summary>
    ''' Extracts file name from path.
    ''' </summary>
    ''' <param name="sPath">File path.</param>
    ''' <returns>File name.</returns>
    Public Function GetFileNameFromPath(ByVal sPath As String)
        Return Path.GetFileName(sPath)
    End Function

    Public Function SaveAndOpen(ByVal sData As String, ByVal sExtension As String) As Boolean
        Dim d As New SaveFileDialog
        d.FileName = "Data.txt"

        If d.ShowDialog() = DialogResult.OK Then
            IO.File.WriteAllText(d.FileName, sData)
            Do While Not IO.File.Exists(d.FileName)
                Application.DoEvents()
            Loop

            System.Diagnostics.Process.Start(d.FileName)
            Return True
        End If

        Return False
    End Function


    ''' <summary>
    ''' Prompts Save file dialog and saves given text.
    ''' </summary>
    ''' <param name="sSuggestedFileName">Suggested file name prompted in Save file dialog.</param>
    ''' <param name="sData">Text data to save.</param>
    ''' <returns>TRUE if succesfull.</returns>
    Public Function NewTextFileWithPrompt(ByVal sSuggestedFileName As String, ByVal sData As String) As Boolean
        Dim d As New SaveFileDialog
        d.AddExtension = True
        d.DefaultExt = ".csv"
        d.FileName = sSuggestedFileName

        If d.ShowDialog = DialogResult.OK Then
            Dim writter As StreamWriter = File.CreateText(d.FileName)

            writter.Write(sData)
            writter.Close()

            Return True
        End If

        Return False
    End Function

    Public Function GetAllEncodersList() As List(Of String)
        Static sList As List(Of String) = Nothing

        If Not IsAny(sList) Then
            sList = New List(Of String)

            For Each encode As System.Text.EncodingInfo In System.Text.Encoding.GetEncodings()
                sList.Add(encode.Name)
            Next

            sList.Sort()

            sList.Add("[Try Detect]")
        End If

        Return sList
    End Function

    ''' <summary>
    ''' Tries to obtain executable file that is being used for executing given file extension
    ''' from system register. Eg. ".py" returns full path to python.exe.
    ''' </summary>
    ''' <param name="ext">Extension in dot format (.py, .pl, ...).</param>
    ''' <returns>Path to executable file associated with given file extension.</returns>
    ''' <remarks>When not found, null string is returned.</remarks>
    Public Function GetApplicationByFileExtension(ByVal ext As String) As String
        Dim regApplication As RegistryKey = Nothing
        Dim regExtension As RegistryKey = Registry.ClassesRoot.OpenSubKey(ext)

        If IsAny(regExtension) Then
            regApplication = Registry.ClassesRoot.OpenSubKey(regExtension.GetValue("") & "\shell\open\command")

            If IsAny(regApplication) Then
                Return StrMidCharTerm(regApplication.GetValue(""), """", """")
            End If
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Checks, whether given extension has any assigned program.
    ''' </summary>
    ''' <param name="sExtension">Extension in dot format (.py, .pl, ...).</param>
    ''' <returns>TRUE whether any program for given extension has been found.</returns>
    Public Function CheckExtensionCanBeExecuted(ByVal sExtension As String) As Boolean
        Return StrIsAny(GetApplicationByFileExtension(sExtension))
    End Function

    Public Function EncapsulateStringWithDoubleQuotes(ByVal s As String) As String
        Return """" & s & """"
    End Function

    ''' <summary>
    ''' Returns application directory.
    ''' </summary>
    Public Function GetAppDirectory() As String
        Return (Path.GetDirectoryName(Application.ExecutablePath))
    End Function

    Public Function IsPathDirectory(ByVal sPath As String) As Boolean
        Return CBool(IO.File.GetAttributes(sPath) = FileAttributes.Directory)
    End Function

    ''' <summary>
    ''' Retreives name of directory that is last in given path, eg.: D:\test\folderX\file.gif
    ''' returns "folderX".
    ''' </summary>
    Public Function GetLastDirectoryName(ByVal sPath As String) As String
        Dim s() As String = Split(sPath, "\")

        If IsAny(s) Then
            If s.Count > 2 Then
                Return s(s.Count - 2)
            End If
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Converts binary file to string by mapping bytes onto given alphabete.
    ''' </summary>
    ''' <param name="sFile">File to read.</param>
    ''' <param name="sAlphabete">Alphabete to use.</param>
    ''' <returns>File content after mapping bytes.</returns>
    Public Function BinaryFileToAlphabetedText(ByVal sFile As String, _
                                               ByVal sAlphabete As String, _
                                               ByRef outResult As String, _
                                                     ByRef sOutError As String) As Boolean
        Try
            Dim data() As Byte = File.ReadAllBytes(sFile)

            Dim out As New StringBuilder(data.Length * (255 \ sAlphabete.Length))

            For i As Integer = 0 To data.Length - 1
                out.Append(ByteToAlphabeteCharacter(data(i), sAlphabete))
            Next

            outResult = out.ToString()
            Return True

        Catch ex As Exception
            sOutError = ex.Message.ToString()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Retreives whether the file has known plain text extension (.TXT, .FNA, ...)
    ''' </summary>
    Public Function IsFileTextFile(ByVal sFileName As String) As Boolean
        Select Case ToUpper(IO.Path.GetExtension(sFileName))
            Case ".TXT", _
                    ".FNA", _
                    ".HTML", ".HTM"

                Return True
            Case Else
                Return False
        End Select
    End Function

    ''' <summary>
    ''' Retreives plain text from HTML content.
    ''' </summary>
    Public Function ConvertHTMLToPlainText(ByVal sHTML As String) As String
        Return Regex.Replace(sHTML, "<.*?>", "")
    End Function

    ''' <summary>
    ''' Examines string whether it seems as html tagged.
    ''' </summary>
    Public Function IsHTML(ByVal sContent As String) As Boolean
        If StrIsAny(sContent) Then
            Return sContent.StartsWith("<HTML") OrElse sContent.StartsWith("<!DOCTYPE ")
        End If

        Return False
    End Function
#End Region

#Region "DEPENDENCIES"
    Public Function CheckIfPythonIsInstalled() As Boolean
        Return CheckExtensionCanBeExecuted(".py")
    End Function

    Public Function CheckIfPerlIsInstalled() As Boolean
        Return CheckExtensionCanBeExecuted(".pl")
    End Function

    Public Function CheckIfInternetIsAvailable() As Boolean
        Return My.Computer.Network.IsAvailable
    End Function
#End Region

#Region "STRING / NUMBER HELPER FUNCTIONS"
    ''' <summary>
    ''' Tests if string is not null or empty.
    ''' </summary>
    ''' <param name="s">String to test.</param>
    ''' <returns>TRUE whether the string is not null or empty.</returns>
    Public Function StrIsAny(ByVal s As String) As Boolean
        If s Is Nothing Then
            Return False
        End If

        If Len(s) = 0 Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Tests two strings whether they are same or not (without case sensitivity).
    ''' </summary>
    ''' <param name="a">First string.</param>
    ''' <param name="b">Second string.</param>
    ''' <returns>TRUE when both strings are same.</returns>
    Public Function StrIsSame(ByVal a As String, ByVal b As String) As Boolean
        Return CBool(StrComp(a, b, CompareMethod.Text) = 0)
    End Function

    ''' <summary>
    ''' Tests object whether it is not null.
    ''' </summary>
    ''' <param name="o">Object to test.</param>
    ''' <returns>TRUE if object is set.</returns>
    Public Function IsAny(ByRef o) As Boolean
        Return CBool(o IsNot Nothing)
    End Function

    Public Function IsAny(ByRef o As IQITAMorphologyAnalyzer) As Boolean
        Return CBool(o IsNot Nothing)
    End Function

    Public Function IsAny(ByRef o()) As Boolean
        Return CBool(o IsNot Nothing)
    End Function

    Public Function IsAny(ByRef o As IQITAIndex) As Boolean
        Return CBool(o IsNot Nothing)
    End Function

    ''' <summary>
    ''' Extracts string surrounded by simple strings.
    ''' </summary>
    ''' <param name="sString">String.</param>
    ''' <param name="sBegin">String at beggining.</param>
    ''' <param name="sEnd">String at end.</param>
    ''' <returns>String between sBegin and sEnd.</returns>
    Public Function StrMidCharTerm(ByVal sString As String, ByVal sBegin As String, ByVal sEnd As String) As String
        If StrIsAny(sString) AndAlso StrIsAny(sBegin) AndAlso StrIsAny(sEnd) Then
            Dim I As Integer = sBegin.Length
            Dim iStartPos As Integer = InStr(1, sString, sBegin, CompareMethod.Text)
            Dim iEndPos As Integer = InStr(iStartPos + sBegin.Length + 1, sString, sEnd, CompareMethod.Text)

            If (iStartPos > 0) AndAlso (iEndPos > 0) Then
                If (iStartPos < iEndPos) Then
                    Try
                        Return Mid$(sString, iStartPos + I, iEndPos - iStartPos - I)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Same as StrMidCharTerm but end delimitter is searched from end.
    ''' </summary>
    Public Function StrMidCharTermE(ByVal sString As String, ByVal sBegin As String, ByVal sEnd As String) As String
        If StrIsAny(sString) AndAlso StrIsAny(sBegin) AndAlso StrIsAny(sEnd) Then
            Dim I As Integer = sBegin.Length
            Dim iStartPos As Integer = InStr(1, sString, sBegin, CompareMethod.Text)
            Dim iEndPos As Integer = InStrRev(sString, sEnd, , CompareMethod.Text)

            If (iStartPos > 0) AndAlso (iEndPos > 0) Then
                If (iStartPos < iEndPos) Then
                    Try
                        Return Mid$(sString, iStartPos + I, iEndPos - iStartPos - I)

                    Catch ex As Exception
                    End Try
                End If
            End If
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Normalizes string (turns it into lower case).
    ''' </summary>
    ''' <param name="s">String to normalize.</param>
    ''' <returns>Normalized string.</returns>
    Public Function NormalizeString(ByVal s As String) As String
        If StrIsAny(s) Then
            Return s.ToLower()
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Removes given ending from string if exists.
    ''' </summary>
    ''' <param name="s">String to be truncated.</param>
    ''' <param name="sEnding">String to remove.</param>
    ''' <returns>String without given ending.</returns>
    Public Function StrRemoveEnding(ByVal s As String, ByVal sEnding As String) As String
        If StrIsAny(s) Then
            If s.EndsWith(sEnding) Then
                Return s.Remove(s.Length - sEnding.Length, sEnding.Length)
            End If
        End If

        Return s
    End Function

    ''' <summary>
    ''' Removes given substring by start index and delimitter (inclusive).
    ''' </summary>
    ''' <param name="s">String expression.</param>
    ''' <param name="startIndex">Zero based start index.</param>
    ''' <param name="sDelimitter">String delimitting the end of removal. This string is removed also.</param>
    Public Function StrRemove(ByVal s As String, ByVal startIndex As Integer, ByVal sDelimitter As String) As String
        Return s.Remove(startIndex, s.IndexOf(sDelimitter) + sDelimitter.Length)
    End Function

    Public Function ToUpper(ByVal s As String) As String
        If StrIsAny(s) Then
            Return s.ToUpper()
        End If

        Return s
    End Function

    ''' <summary>
    ''' Converts any number in string format to Double. 
    ''' </summary>
    ''' <param name="sString">Number in string format.</param>
    ''' <returns>Double value.</returns>
    Public Function ToNumber(ByVal sString As String) As Double
        Return Val(Replace(sString, ",", "."))
    End Function

    Public Function ToNumber(ByRef o As Object) As Double
        If o Is Nothing Then
            Return 0
        End If

        If IsNumeric(o) Then
            Return o
        Else
            Return ToNumber(o.ToString())
        End If
    End Function

    ''' <summary>
    ''' Tests whether given string is number or not.
    ''' </summary>
    ''' <param name="sString">String to test.</param>
    ''' <returns>TRUE when string is number.</returns>
    Public Function IsNumber(ByVal sString As String) As Boolean
        Return IsNumeric(sString)
    End Function

    ''' <summary>
    ''' Converts object array containing numbers to array of Double.
    ''' </summary>
    ''' <param name="o">Object array with ToString() returning numbers.</param>
    ''' <returns>Array of doubles.</returns>
    ''' <remarks>When given object number is NULL, NULL is returned.</remarks>
    Public Function ObjArrayToNumberArray(ByRef o() As Object) As Double()
        If IsAny(o) Then
            Dim m(o.Count - 1) As Double

            For i As Integer = 0 To o.Count - 1
                m(i) = ToNumber(o(i))
            Next

            Return m
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Tests whether string contains given substring.
    ''' </summary>
    Public Function StrContains(ByVal sWhere As String, ByVal sWhat As String) As Boolean
        If StrIsAny(sWhere) Then
            Return CBool(InStr(sWhere, sWhat, CompareMethod.Text) > 0)
            'Return sWhere.Contains(sWhat)
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Encloses string into brackets if it is not already.
    ''' </summary>
    ''' <param name="s">String to be enclosed by brackets.</param>
    ''' <param name="bMakePreceedingSpace">When TRUE, prepends space before first bracket.</param>
    ''' <returns>String in brackets.</returns>
    Public Function EnBraceIfNeeded(ByVal s As String, Optional ByVal bMakePreceedingSpace As Boolean = True) As String
        Return (If(bMakePreceedingSpace, " ", Nothing) & If(StrIsAny(s), "(" & s & ")", s))
    End Function

    ''' <summary>
    ''' Tests string whether contains UTF8 invalid character.
    ''' </summary>
    ''' <param name="s">String to test.</param>
    ''' <returns>TRUE when UTF8 invalid character has been found.</returns>
    Public Function ContainsUTF8InvalidChar(ByVal s As String) As Boolean
        If StrIsAny(s) Then
            Return s.Contains("�")
        End If

        Return False
    End Function

    Public Function EncodeUnicodeToSequence(ByVal input As String) As String
        Dim output As New StringBuilder(input.Length * 6)

        Dim i As Integer = 0
        Dim code As Integer = 0

        Do While (i < input.Length)
            code = Char.ConvertToUtf32(input, i)
            output.Append(String.Format("\u{0:X4}", code))

            i += If(Char.IsSurrogatePair(input, i), 2, 1)
        Loop

        Return output.ToString()
    End Function

    ''' <summary>
    ''' Decodes unicode sequences like "\u231\u242" to character string.
    ''' </summary>
    ''' <param name="s">String containing unicode sequences.</param>
    ''' <returns>String with with decoded uncode sequences.</returns>
    Public Function DecodeUnicodeSequences(ByVal s As String) As String
        Static _regex As Regex = New Regex("\\u(?<Value>[a-zA-Z0-9]{4})", RegexOptions.Compiled)

        Return _regex.Replace(s, Function(m) (Char.ConvertFromUtf32(Int32.Parse(m.Groups("Value").Value, NumberStyles.HexNumber))).ToString())
    End Function

    ''' <summary>
    ''' Maps integer onto alphabete character.
    ''' </summary>
    ''' <param name="character"></param>
    ''' <param name="alphabete"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ByteToAlphabeteCharacter(ByVal character As Integer, _
                                             ByVal alphabete As String) As String
        Dim s As New System.Text.StringBuilder(5)
        Dim base As Integer = alphabete.Length

        Do While character
            s.Insert(0, alphabete.Chars(character Mod base))
            character = character \ base
        Loop

        Return s.ToString()
    End Function
#End Region

#Region "VIEW OBJECTS AND VARIABLES HELPERS"
    ''' <summary>
    ''' Exports content of given DataGridView to CSV formatted data.
    ''' </summary>
    ''' <param name="dataGrid">DataGridView for export.</param>
    ''' <param name="sDelimitter">Delimitter to be used.</param>
    ''' <returns>CSV formatted data.</returns>
    Public Function DataGridViewToCSV(ByRef dataGrid As DataGridView, _
                                      Optional ByVal sDelimitter As String = vbTab) As String
        Dim s As String
        Dim sCSV As New StringBuilder

        If IsAny(dataGrid) Then
            sCSV.Append(" " & vbTab)

            For i As Integer = 0 To dataGrid.ColumnCount - 1
                sCSV.Append(dataGrid.Columns(i).HeaderText & sDelimitter)
            Next

            sCSV.AppendLine()

            For i As Integer = 0 To dataGrid.RowCount - 1
                sCSV.Append(dataGrid.Rows(i).HeaderCell.Value & vbTab)

                For j As Integer = 0 To dataGrid.ColumnCount - 1

                    If dataGrid(j, i).Value Is Nothing Then
                        s = ""
                    Else
                        s = dataGrid(j, i).Value.ToString()
                    End If

                    sCSV.Append(s & vbTab)
                Next

                sCSV.AppendLine()
            Next
        End If

        Return sCSV.ToString()
    End Function

    ''' <summary>
    ''' Exports content of given ListView to CSV formatted data.
    ''' </summary>
    ''' <param name="lv">ListView for export.</param>
    ''' <param name="sDelimitter">Delimitter to be used.</param>
    ''' <returns>CSV formatted data.</returns>
    Public Function ListViewToCSV(ByRef lv As ListView, _
                                    Optional ByVal sDelimitter As String = vbTab) As String
        Dim sCSV As New StringBuilder

        If IsAny(lv) Then
            For Each c As ColumnHeader In lv.Columns
                sCSV.Append(c.Text & sDelimitter)
            Next

            sCSV.AppendLine()

            For Each myItem As ListViewItem In lv.Items
                For i As Integer = 0 To myItem.SubItems.Count - 1
                    sCSV.Append(myItem.SubItems(i).Text & sDelimitter)
                Next

                sCSV.AppendLine()
            Next
        End If

        Return sCSV.ToString()
    End Function

    ''' <summary>
    ''' Class providing listview sorting comparer.
    ''' Author: http://www.vb-helper.com/howto_net_listview_sort_clicked_column.html
    ''' </summary>
    Private Class ListViewComparer
        Implements IComparer

        Private m_ColumnNumber As Integer
        Private m_SortOrder As SortOrder

        Public Sub New(ByVal column_number As Integer, ByVal _
            sort_order As SortOrder)
            m_ColumnNumber = column_number
            m_SortOrder = sort_order
        End Sub

        ' Compare the items in the appropriate column
        ' for objects x and y.
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim item_x As ListViewItem = DirectCast(x, ListViewItem)
            Dim item_y As ListViewItem = DirectCast(y, ListViewItem)

            ' Get the sub-item values.
            Dim string_x As String
            If item_x.SubItems.Count <= m_ColumnNumber Then
                string_x = ""
            Else
                string_x = item_x.SubItems(m_ColumnNumber).Text
            End If

            Dim string_y As String
            If item_y.SubItems.Count <= m_ColumnNumber Then
                string_y = ""
            Else
                string_y = item_y.SubItems(m_ColumnNumber).Text
            End If

            ' Compare them.
            If m_SortOrder = SortOrder.Ascending Then
                If IsNumeric(string_x) And IsNumeric(string_y) _
                    Then
                    Return Val(string_x).CompareTo(Val(string_y))
                Else
                    Return String.Compare(string_x, string_y)
                End If
            Else
                If IsNumeric(string_x) And IsNumeric(string_y) _
                    Then
                    Return Val(string_y).CompareTo(Val(string_x))
                Else
                    Return String.Compare(string_y, string_x)
                End If
            End If
        End Function
    End Class

    ''' <summary>
    ''' Sub providing sorting of listview.
    ''' Author: http://www.vb-helper.com/howto_net_listview_sort_clicked_column.html
    ''' </summary>
    Public Sub SortLV(ByRef lv As ListView, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        ' Get the new sorting column.
        Static m_SortingColumn As ColumnHeader = Nothing
        Dim new_sorting_column As ColumnHeader = lv.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text = _
                m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        lv.ListViewItemSorter = New  _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        lv.Sort()
        lv.Sorting = SortOrder.None
        lv.ListViewItemSorter = Nothing
    End Sub

    ''' <summary>
    ''' Dumps variable to string.
    ''' </summary>
    ''' <param name="sName">Variable name.</param>
    ''' <param name="o">Object to be dumped.</param>
    ''' <returns>Dumped variable.</returns>
    Public Function VDump(ByVal sName As String, ByRef o As Object) As String
        Return sName & "=" & o.ToString() & ";"
    End Function

    ''' <summary>
    ''' Edits text and tag property of given object by user input. Entered value is stored in TAG property
    ''' of given object and thus should contain default value.
    ''' </summary>
    ''' <param name="obj">Object to be edited.</param>
    ''' <param name="sPrependText">Text that is prepended prior to actual value. Eg. PrependText "Value" creates "Value: " string.</param>
    ''' <param name="sQueryText">Text that will be displayed in user input query.</param>
    ''' <param name="inputIsNumber">Sets whether input data have to be numeric.</param>
    ''' <param name="testFunction">Function (param1: input string; returns new string). User function that gets input string and returned
    ''' string is used as a new value. This parameter can be NULL.</param>
    ''' <returns>New value.</returns>
    Public Function EditControlTagAndTextByUserInput(ByRef obj As Object, _
                                                     ByVal sPrependText As String, _
                                                     ByVal sQueryText As String, _
                                                     ByVal inputIsNumber As Boolean, _
                                                     ByVal testFunction As Func(Of String, String), _
                                                           Optional ByVal sAfix As String = Nothing) As String
        Dim bIsOk As Boolean = False
        Dim s As String = InputBox(sQueryText & ":", sPrependText, GetToolStripMenuItemValue(obj))

        If ToUpper(s) = "ALL" Then
            s = If(inputIsNumber, "-1", "*")
        End If

        If IsAny(testFunction) Then
            s = testFunction(s)
            bIsOk = True
        End If

        If inputIsNumber AndAlso IsNumber(s) Then
            bIsOk = True
        End If

        If Not inputIsNumber Then
            bIsOk = True
        End If

        If bIsOk Then
            obj.Text = sPrependText & ": [" & s & "] " & sAfix
        Else
            Beep()
        End If

        Return s
    End Function

    Public Function GetToolStripMenuItemValue(ByRef ts As Object) As String
        Dim s As String = StrMidCharTerm(ts.Text, "[", "]")

        If ts.tag = "-1" Then
            s = Replace(s, "all", "-1", , , CompareMethod.Text)
        End If

        Return s
    End Function

    Public Function DictionarySort(ByVal d As Dictionary(Of String, Integer)) As Dictionary(Of String, Integer)
        Dim sorted = From pair In d Order By pair.Value Descending
        Dim sortedDictionary = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)

        Return sortedDictionary
    End Function
#End Region

#Region "VARIOUS"
    ''' <summary>
    ''' Modifies Font style by given style.
    ''' </summary>
    Public Sub AddOrRemoveStyle(ByRef style As FontStyle, ByRef s As FontStyle)
        If style And s Then
            style -= s
        Else
            style += s
        End If
    End Sub

    Public Function RandomizeList(ByVal myList As List(Of String)) As List(Of String)
        Dim r As New Random(Now.Millisecond)
        Return (From k As String In myList Order By r.Next() Select k).ToList()
    End Function

    Public Sub SelectItemInComboBoxByText(ByRef c As ComboBox, ByVal sTextToMatch As String)
        c.SelectedIndex = Math.Max(0, c.FindStringExact(sTextToMatch))
    End Sub

    ''' <summary>
    ''' Swaps two objects.
    ''' </summary>
    Public Sub Swap(ByRef a As Object, ByRef b As Object)
        Dim k As Object = a
        a = b
        b = k
    End Sub

    Public Sub DoEventsWhen(ByVal n As Integer)
        If (n Mod 200) = 0 Then
            Application.DoEvents()
        End If
    End Sub
    Public Sub SetWorking(ByRef control As Object, ByVal b As Boolean)
        Dim o As Object = control

        If TypeOf control Is UserControl Then
            o = DirectCast(control, UserControl).ParentForm
        End If

        o.Cursor = IIf(b, Cursors.AppStarting, Cursors.Arrow)
        Application.DoEvents()
    End Sub
#End Region
End Module

Module QITAObjects
    Public Function CreateQITAIndexByName(ByVal sIQITAIndexFullName As String) As IQITAIndex
        Dim s As [Assembly] = Assembly.GetAssembly(GetType(QITAInterfaces.IQITAIndex))

        If StrIsAny(sIQITAIndexFullName) Then
            If sIQITAIndexFullName.Contains(".QITAIndexes.") Then
                Return DirectCast(s.CreateInstance(sIQITAIndexFullName), IQITAIndex)
            End If
        End If

        Return Nothing
    End Function

    Public Function CreateQITALemmatizerByName(ByVal sIQITALemmatizerFullName As String) As IQITAMorphologyAnalyzer
        Dim s As [Assembly] = Assembly.GetAssembly(GetType(QITAInterfaces.IQITAMorphologyAnalyzer))

        If StrIsAny(sIQITALemmatizerFullName) Then
            If sIQITALemmatizerFullName.Contains(".QITAMorphoAnalyzers.") Then
                Return DirectCast(s.CreateInstance(sIQITALemmatizerFullName), IQITAMorphologyAnalyzer)
            End If
        End If

        Return Nothing
    End Function

    Public Function CreateQITAObject(ByVal sObjectName As String, _
                                     ByVal sImplementationPath As String) As Object
        Dim s As [Assembly] = Assembly.GetAssembly(GetType(QITA))

        If StrIsAny(sObjectName) Then
            If sObjectName.Contains(sImplementationPath) Then
                Return s.CreateInstance(sObjectName)
            End If
        End If

        Return Nothing
    End Function

    Public Function GetQITAAnalyzersDirectory() As String
        Return GetAppDirectory() & "\morphoanalyzers"
    End Function
End Module

Module MathExt
    ''' <summary>
    ''' Calculates Sum of given array with given boundings (Classical Sum).
    ''' </summary>
    ''' <param name="data">Data array to sum.</param>
    ''' <param name="iStart">Start index.</param>
    ''' <param name="dEndIndex">End index.</param>
    ''' <returns>Sum.</returns>
    Public Function SumWhileLessThanIndex(ByRef data() As Integer, _
                                          ByVal iStart As Integer, _
                                          ByVal dEndIndex As Double) As Double
        Dim i As Integer = iStart
        Dim dSum As Double = 0

        If UBound(data) > -1 Then
            Do While (dEndIndex >= i)
                dSum += data(i)
                i += 1
            Loop
        End If

        Return dSum
    End Function

    ''' <summary>
    ''' Calculates sum of positive (one-based) integer array with applying function f to each 
    ''' item before it is added to sum.
    ''' </summary>
    ''' <param name="data">Positive one-based integer array.</param>
    ''' <param name="f">Function (param1: passed item value) that is applied to array-item.</param>
    ''' <returns>Sum.</returns>
    Public Function SumPositiveArray(ByRef data() As Integer, ByVal f As Func(Of Double, Double)) As Double
        Dim dSum As Double = 0

        For i As Integer = 1 To data.Count() - 1
            dSum += f(data(i))
        Next

        Return dSum
    End Function

    ''' <summary>
    ''' Calculates sum of positive (one-based) integer array with applying function f to each 
    ''' item before it is added to sum.
    ''' </summary>
    ''' <param name="data">Positive one-based integer array.</param>
    ''' <param name="iStart">Start at index.</param>
    ''' <param name="iEnd">End at index.</param>
    ''' <param name="f">Function (param1: passed array item, param2: passed iteration index) that is applied to array-item.</param>
    ''' <returns>Sum.</returns>
    Public Function SumPositiveArray(ByRef data() As Integer, _
                                     ByVal iStart As Integer, _
                                     ByVal iEnd As Integer, _
                                     ByVal f As Func(Of Double, Integer, Double)) As Double
        Dim dSum As Double = 0

        For i As Integer = iStart To iEnd
            dSum += f(data(i), i)
        Next

        Return dSum
    End Function

    ''' <summary>
    ''' Calculates distance between two points in 2D.
    ''' </summary>
    ''' <param name="a1">Point1.X</param>
    ''' <param name="a2">Point1.Y</param>
    ''' <param name="b1">Point2.X</param>
    ''' <param name="b2">Point2.Y</param>
    ''' <returns>Euclidian distance.</returns>
    Public Function EuclidianDistance(ByVal a1 As Integer, ByVal a2 As Integer, ByVal b1 As Integer, ByVal b2 As Integer) As Double
        Return Math.Sqrt((a1 - b1) ^ 2 + (a2 - b2) ^ 2)
    End Function

    ''' <summary>
    ''' Tests, whether given number does not contain any decimal digits.
    ''' </summary>
    ''' <param name="d">Number to test.</param>
    ''' <returns>TRUE if the number has not any decimal digits.</returns>
    Public Function IsNumberWhole(ByVal d As Double) As Boolean
        Return CBool(CLng(d) = d)
    End Function

    ''' <summary>
    ''' Returns natural logarithm of given number.
    ''' </summary>
    ''' <param name="n">Number.</param>
    ''' <returns>Natural logarithm.</returns>
    Public Function Log2(ByVal n As Double) As Double
        Static m As Double = Math.Log(2)

        Return Math.Log(n) / m
    End Function

    ''' <summary>
    ''' Calculates standard deviation of given two numbers.
    ''' </summary>
    ''' <returns>Standard deviation.</returns>
    Public Function StandardDeviation(ByRef value1 As IQITAResult, ByRef value2 As IQITAResult) As Double
        Return StandardDeviation(value1.Value, value2.Value)
    End Function

    ''' <summary>
    ''' Calculates standard deviation of given number QITA Results array.
    ''' </summary>
    ''' <param name="results">Results whichs values will be used for deviation calculation.</param>
    ''' <returns>Standard deviation.</returns>
    Public Function StandardDeviation(ByRef results As List(Of IQITAResult)) As Double
        Dim doubles As New List(Of Double)

        For Each r As IQITAResult In results
            doubles.Add(ToNumber(r.Value))
        Next

        Return StandardDeviation(doubles.ToArray())
    End Function

    ''' <summary>
    ''' Calculates standard deviation of given two numbers.
    ''' </summary>
    ''' <returns>Standard deviation.</returns>
    Public Function StandardDeviation(ByRef value1 As Double, ByRef value2 As Double) As Double
        Return StandardDeviation(New Double() {value1, value2})
    End Function

    ''' <summary>
    ''' Calculates standard deviation of given number array.
    ''' </summary>
    ''' <param name="values">Values to be calculated.</param>
    ''' <returns>Standard deviation.</returns>
    Public Function StandardDeviation(ByRef values() As Double) As Double
        Dim m As Double = 0
        Dim avg As Double = values.Average

        For Each d As Double In values
            m += CDbl((d - avg) ^ 2)
        Next

        Return CDbl(Math.Sqrt(m / values.Length))
    End Function

    ''' <summary>
    ''' Calculates average of IQITA Results values.
    ''' </summary>
    ''' <param name="results"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Average(ByRef results As List(Of IQITAResult)) As Double
        Dim doubles As New List(Of Double)

        For Each r As IQITAResult In results
            doubles.Add(ToNumber(r.Value))
        Next

        Return doubles.Average()
    End Function

    'dodelat: prumerne hodnoty pod kazdy vypocitany index, pri vkladani do kalkulacky na s nutne poslat 
    'i pocet prvku/textu

    ''' <summary>
    ''' Calculates Asymptotic u-test within given values and their diffusion.
    ''' </summary>
    ''' <param name="value1">Value 1.</param>
    ''' <param name="value2">Value 2.</param>
    ''' <param name="varValue1">Diffusion of Value 1.</param>
    ''' <param name="varValue2">Diffusion of Value 2.</param>
    Public Function UAsymptoticTest(ByRef value1 As IQITAResult, ByRef value2 As IQITAResult, _
                                    ByRef varValue1 As IQITAResult, ByRef varValue2 As IQITAResult) As Double

        If IsNumeric(value1.Value) AndAlso IsNumeric(value2.Value) Then
            If IsNumeric(varValue1.Value) AndAlso IsNumeric(varValue2.Value) Then
                Return UAsymptoticTest(value1.Value, value2.Value, varValue1.Value, varValue2.Value)
            End If
        End If

        Return -1
    End Function

    ''' <summary>
    ''' Calculates Asymptotic u-test within given values and their diffusion.
    ''' </summary>
    ''' <param name="value1">Value 1.</param>
    ''' <param name="value2">Value 2.</param>
    ''' <param name="varValue1">Diffusion of Value 1.</param>
    ''' <param name="varValue2">Diffusion of Value 2.</param>
    Public Function UAsymptoticTest(ByRef value1 As Double, ByRef value2 As Double, _
                                    ByRef varValue1 As IQITAResult, ByRef varValue2 As IQITAResult) As Double

        If IsNumeric(varValue1.Value) AndAlso IsNumeric(varValue2.Value) Then
            Return UAsymptoticTest(value1, value2, varValue1.Value, varValue2.Value)
        End If

        Return -1
    End Function

    ''' <summary>
    ''' Calculates Asymptotic u-test within given values and their diffusion.
    ''' </summary>
    ''' <param name="value1">Value 1.</param>
    ''' <param name="value2">Value 2.</param>
    ''' <param name="varValue1">Diffusion of Value 1.</param>
    ''' <param name="varValue2">Diffusion of Value 2.</param>
    Public Function UAsymptoticTest(ByRef value1 As Double, ByRef value2 As Double, ByRef varValue1 As Double, ByRef varValue2 As Double) As Double
        Dim u As Double = Math.Abs(value1 - value2) / Math.Sqrt(varValue1 + varValue2)
        Return u
    End Function

    ''' <summary>
    ''' Generates random number at given interval.
    ''' </summary>
    ''' <returns>Random number.</returns>
    Public Function RandomNumber(ByVal low As Int32, ByVal high As Int32) As Integer
        Static RandomNumGen As New System.Random
        Return RandomNumGen.Next(low, high + 1)
    End Function

    ''' <summary>
    ''' Tests, wheter given number is in given interval (inclusive).
    ''' </summary>
    ''' <param name="dTestedNumber">Number to test.</param>
    ''' <param name="dLow">Low interval border.</param>
    ''' <param name="dHigh">High interval border.</param>
    ''' <returns>TRUE when number is in given interval. Otherwise FALSE.</returns>
    Public Function IsInIntervalInclusive(ByVal dTestedNumber As Double, ByVal dLow As Double, ByVal dHigh As Double) As Boolean
        Return CBool((dTestedNumber >= dLow) AndAlso (dTestedNumber <= dHigh))
    End Function

    ''' <summary>
    ''' Generates color in Green-Yellow-Red scale by given percentage. 
    ''' 0 % is green. 100 % is red.
    ''' </summary>
    Public Function GetColorFromPercentage(ByVal percent As Integer) As Color
        Dim r As Integer
        Dim g As Integer

        percent = 100 - percent
        If percent < 50 Then
            r = 255
            g = (percent / 50) * 255
        Else
            r = ((100 - percent) / 50) * 255
            g = 255
        End If

        Return Color.FromArgb(250, r, g, 0)
    End Function
End Module

Module TextFileFormats
    Public Sub StripGutenbergIfAny(ByRef sInOutText As String)
        If StrContains(sInOutText, "*** START OF THIS PROJECT") Then
            sInOutText = StrRemove(sInOutText, 0, "*** START OF THIS PROJECT")
            sInOutText = StrRemove(sInOutText, 0, "***")

            Select Case True
                Case sInOutText.Contains("End of Project Gutenberg")
                    sInOutText = sInOutText.Substring(0, sInOutText.IndexOf("End of Project Gutenberg"))

                Case sInOutText.Contains("End of the Project Gutenberg")
                    sInOutText = sInOutText.Substring(0, sInOutText.IndexOf("End of the Project Gutenberg"))
            End Select
        End If
    End Sub
End Module

Module DNAFileFormats
    Public Function StandardizeDNA(ByVal sText As String) As String
        Return sText.ToUpper().Replace("U", "T")
    End Function
    Public Function RemoveFNAInfoHeaders(ByVal sText As String) As String
        Dim infoStart As Integer = 0
        Dim infoEnds As Integer = 0

        Do While (sText.Contains(">"))
            infoStart = sText.IndexOf(">")
            infoEnds = sText.IndexOf(vbLf, infoStart)
            sText = sText.Remove(infoStart, infoEnds - infoStart)
        Loop

        sText = sText.Replace(" ", Nothing)   ' Replace(sText, " ", Nothing)
        sText = sText.Replace(vbCr, Nothing)  ' Replace(sText, vbCr, Nothing)
        sText = sText.Replace(vbLf, Nothing)  ' Replace(sText, vbLf, Nothing)

        Return sText
    End Function
End Module

Module HelperClasses
    Public Class QueryPrivateCache
        Private _maxCaheSize As Integer = 0
        Private _maxQuerySize As Integer = 15
        Private _cache As Dictionary(Of String, String)

        Public Sub New(ByVal nSize As Integer)
            _maxCaheSize = nSize
            _cache = New Dictionary(Of String, String)(nSize)
        End Sub

        Public Function GetQuery(ByVal sQuery As String, ByRef outResult As String) As Boolean
            If IsQueryFine(sQuery) Then
                If _cache.ContainsKey(sQuery) Then
                    outResult = _cache(sQuery)
                    Return True
                End If
            End If
        End Function

        Public Function Add(ByVal sQuery As String, ByRef outResult As String) As Boolean
            If IsQueryFine(sQuery) Then
                If _cache.Count < _maxCaheSize Then
                    _cache.Add(sQuery, outResult)
                    Return True
                End If
            End If
        End Function

        Private Function IsQueryFine(ByVal sQuery As String) As Boolean
            If Not String.IsNullOrEmpty(sQuery) Then
                Return CBool(sQuery.Length < _maxQuerySize)
            End If
        End Function
    End Class

    ''' <summary>
    ''' Encapsulates Windows pipe IO with given executable file. Works with single lines.
    ''' </summary>
    ''' <remarks>WorkingDirectory is set to directory given in executable file path.</remarks>
    Public Class PipedLineExecution
        Private _inputWriter As StreamWriter = Nothing
        Private _pipedProcess As Process = Nothing
        Private _OutputData As String = Nothing
        Private _Semaphored As Boolean = False
        Private _BlockOutputEdit As Boolean = False
        Private _Encoding As System.Text.Encoding
        Private _IsOk As Boolean = False

        Public ReadOnly Property IsOk() As Boolean
            Get
                Return _IsOk
            End Get
        End Property

        ''' <summary>
        ''' Initializes piped communication with given executable file.
        ''' </summary>
        ''' <param name="sExecutableFilePath">Path to executable file.</param>
        ''' <param name="sArguments">Arguments that will be passed to executable file.</param>
        ''' <param name="encoding">Encoding of target program IO.</param>
        ''' <param name="outError">Output: Exception.</param>
        Public Sub New(ByVal sExecutableFilePath As String, _
                       ByVal sArguments As String, _
                       ByVal sWorkingDirectory As String, _
                       ByVal encoding As Text.Encoding, _
                       ByRef outError As Exception)

            _pipedProcess = New Process()
            _Encoding = encoding

            Try
                With _pipedProcess.StartInfo
                    .FileName = sExecutableFilePath
                    .Arguments = sArguments
                    .UseShellExecute = False
                    .CreateNoWindow = True
                    .RedirectStandardOutput = True
                    .RedirectStandardInput = True
                    .StandardOutputEncoding = encoding

                    .WorkingDirectory = sWorkingDirectory
                End With

                AddHandler _pipedProcess.OutputDataReceived, AddressOf OutputHandler
                AddHandler _pipedProcess.ErrorDataReceived, AddressOf OutputHandler

                If _pipedProcess.Start() Then
                    _inputWriter = _pipedProcess.StandardInput()
                    _pipedProcess.BeginOutputReadLine()

                    _IsOk = True
                End If
            Catch ex As Exception
                outError = ex
            End Try
        End Sub

        ''' <summary>
        ''' Writes line to pipe and reads output.
        ''' </summary>
        ''' <param name="s">Data to write.</param>
        ''' <returns>Readed response.</returns>
        Public Function WriteLineAndReadOutput(ByVal s As String) As String
            _OutputData = ""
            _Semaphored = False

            _inputWriter.WriteLine(s)

            Do While (Not _Semaphored)
                Application.DoEvents()
            Loop

            If StrIsAny(_OutputData) Then
                Dim sOut As String = String.Copy(_OutputData)

                _BlockOutputEdit = False

                Return sOut
            Else
                Return Nothing
            End If
        End Function

        Private Sub OutputHandler(ByVal sendingProcess As Object, ByVal outLine As DataReceivedEventArgs)
            If Not String.IsNullOrEmpty(outLine.Data) Then
                If Not _BlockOutputEdit Then
                    _OutputData = outLine.Data
                    _BlockOutputEdit = True
                End If
            End If

            _Semaphored = True
        End Sub

        Public Sub CloseAll()
            On Error Resume Next
            _inputWriter.Close()
            _pipedProcess.Close()
        End Sub

        Protected Overrides Sub Finalize()
            CloseAll()
        End Sub
    End Class

    Public Class PipedHugeDataExecution
        Private _pipedProcess As Process = Nothing
        Private _OutputData As String = Nothing
        Private _BlockOutputEdit As Boolean = False
        Private _Encoding As System.Text.Encoding
        Private _ExecutableFilePath As String = Nothing
        Private _Arguments As String = Nothing
        Private _WorkingDirectory As String = Nothing

        Public Sub New(ByVal sExecutableFilePath As String, _
                               ByVal sArguments As String, _
                               ByVal sWorkingDirectory As String, _
                               ByVal encoding As Text.Encoding)
            _ExecutableFilePath = sExecutableFilePath
            _Arguments = sArguments
            _WorkingDirectory = sWorkingDirectory
            _Encoding = encoding

            Dim sExtension As String = Path.GetExtension(_ExecutableFilePath)
            If StrComp(sExtension, ".exe", CompareMethod.Text) Then
                _ExecutableFilePath = GetApplicationByFileExtension(sExtension)
                _Arguments = EncapsulateStringWithDoubleQuotes(sExecutableFilePath)
            End If
        End Sub

        Private Sub StartReadOutput()
            _pipedProcess = New Process()
            _Encoding = _Encoding

            Try
                With _pipedProcess.StartInfo
                    .FileName = _ExecutableFilePath
                    .Arguments = _Arguments
                    .UseShellExecute = False
                    .CreateNoWindow = True
                    .RedirectStandardOutput = True
                    .RedirectStandardInput = True
                    .StandardOutputEncoding = _Encoding

                    .WorkingDirectory = _WorkingDirectory
                End With

                AddHandler _pipedProcess.OutputDataReceived, AddressOf OutputHandler
                AddHandler _pipedProcess.ErrorDataReceived, AddressOf OutputHandler

                If _pipedProcess.Start() Then
                    _pipedProcess.BeginOutputReadLine()

                    _pipedProcess.WaitForExit()
                    _pipedProcess.Close()
                End If

            Catch ex As Exception

            End Try
        End Sub

        Public Function TransferHugeData(ByVal sData As String) As String
            Dim sFile As String = Path.GetTempFileName()
            Dim sw As StreamWriter = New StreamWriter(sFile, False, _Encoding) 'File.CreateText(sFile )
            sw.Write(sData)
            sw.Close()

            _Arguments += " " & EncapsulateStringWithDoubleQuotes(sFile)
            StartReadOutput()

            File.Delete(sFile)

            Return _OutputData
        End Function

        Private Sub OutputHandler(ByVal sendingProcess As Object, ByVal outLine As DataReceivedEventArgs)
            If Not String.IsNullOrEmpty(outLine.Data) Then
                _OutputData = outLine.Data
            End If
        End Sub
    End Class

    ''' <summary>
    ''' Encapsulates HTTP Post request functions with definable POST form fields.
    ''' </summary>
    Public Class HTTPPostHandler
        Private _Server As String = Nothing
        Private _RequestFields As New List(Of HTTPPostHandlerRequestField)

        ''' <summary>
        ''' Creates new instance of HTTPPostHandler within given server.
        ''' </summary>
        ''' <param name="sServerURL">Server url.</param>
        Public Sub New(ByVal sServerURL As String)
            If StrIsAny(sServerURL) Then
                _Server = sServerURL
            Else
                Throw New Exception("Server URL cannot be NULL!")
            End If
        End Sub

        ''' <summary>
        ''' Adds POST request field with given data.
        ''' </summary>
        ''' <param name="sFieldName">Name of POST field name.</param>
        ''' <param name="sFieldData">Data.</param>
        Public Sub AddRequestField(ByVal sFieldName As String, ByVal sFieldData As String)
            _RequestFields.Add(New HTTPPostHandlerRequestField(sFieldName, sFieldData))
        End Sub

        ''' <summary>
        ''' Checks whether the computer is connected to internet or not.
        ''' </summary>
        ''' <returns>TRUE if connected.</returns>
        Public Shared Function CheckConnection() As Boolean
            Return My.Computer.Network.IsAvailable
        End Function

        ''' <summary>
        ''' Transfers post request to server, waits for response and returns received data.
        ''' </summary>
        ''' <param name="outReceivedData">Output: received data string.</param>
        ''' <param name="outException">Output: exception instance, if any.</param>
        ''' <returns>TRUE if request was succesfull.</returns>
        Public Function TransferData(ByRef outReceivedData As String, ByRef outException As Exception) As Boolean
            Dim request As HttpWebRequest

            If CheckConnection() Then
                Try
                    request = HttpWebRequest.Create(_Server)

                    Dim data As String = ""
                    For Each m As HTTPPostHandlerRequestField In _RequestFields
                        data += m.First & "=" & Web.HttpUtility.UrlEncode(m.Second) & "&"
                    Next

                    Dim bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(data)
                    request.Method = "POST"
                    request.ContentLength = bytes.Length
                    request.GetRequestStream().Write(bytes, 0, bytes.Length)

                    outReceivedData = New StreamReader(request.GetResponse().GetResponseStream).ReadToEnd()
                    Return True
                Catch e As Exception
                    outException = e
                End Try
            End If

            Return False
        End Function
    End Class

    Public Class HTTPPostHandlerRequestField
        Inherits Pair

        Public Sub New(ByVal sFieldName As String, ByVal sFieldData As String)
            MyBase.New(sFieldName, sFieldData)
        End Sub
    End Class

    Public Class TripletContainer
        Public A As Object = Nothing
        Public B As Object = Nothing
        Public C As Object = Nothing

        Public Sub New(ByRef _A As Object, ByRef _B As Object, ByRef _C As Object)
            A = _A
            B = _B
            C = _C
        End Sub
    End Class

    Public Class Pair
        Private _first As Object = Nothing
        Private _second As Object = Nothing

        Public Sub New(ByRef first As Object, ByRef second As Object)
            _first = first
            _second = second
        End Sub

        Public Overridable Property First() As Object
            Get
                Return _first
            End Get
            Set(ByVal value As Object)
                _first = value
            End Set
        End Property

        Public Overridable Property Second() As Object
            Get
                Return _second
            End Get
            Set(ByVal value As Object)
                _second = value
            End Set
        End Property
    End Class
End Module