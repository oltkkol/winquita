'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.5477
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LastViewedDirectoryPath() As String
            Get
                Return CType(Me("LastViewedDirectoryPath"),String)
            End Get
            Set
                Me("LastViewedDirectoryPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property ChartForAllProjects() As Boolean
            Get
                Return CType(Me("ChartForAllProjects"),Boolean)
            End Get
            Set
                Me("ChartForAllProjects") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Setting() As String
            Get
                Return CType(Me("Setting"),String)
            End Get
            Set
                Me("Setting") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("5")>  _
        Public Property LastChartMarkersSize() As Integer
            Get
                Return CType(Me("LastChartMarkersSize"),Integer)
            End Get
            Set
                Me("LastChartMarkersSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("abcdefghijklmnopqrstuvwxyz")>  _
        Public Property DefaultAlphabete() As String
            Get
                Return CType(Me("DefaultAlphabete"),String)
            End Get
            Set
                Me("DefaultAlphabete") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property ExtractTextFromHTMLFiles() As Boolean
            Get
                Return CType(Me("ExtractTextFromHTMLFiles"),Boolean)
            End Get
            Set
                Me("ExtractTextFromHTMLFiles") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Files_PrependDirectoryName() As Boolean
            Get
                Return CType(Me("Files_PrependDirectoryName"),Boolean)
            End Get
            Set
                Me("Files_PrependDirectoryName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Files_RandomizeDictionaryFileList() As Boolean
            Get
                Return CType(Me("Files_RandomizeDictionaryFileList"),Boolean)
            End Get
            Set
                Me("Files_RandomizeDictionaryFileList") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Files_IgnoreBinaryFiles() As Boolean
            Get
                Return CType(Me("Files_IgnoreBinaryFiles"),Boolean)
            End Get
            Set
                Me("Files_IgnoreBinaryFiles") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("MAXimum file size: [500 000] Bytes")>  _
        Public Property Files_MaxFileSize() As String
            Get
                Return CType(Me("Files_MaxFileSize"),String)
            End Get
            Set
                Me("Files_MaxFileSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("MINimum file size: [All]")>  _
        Public Property Files_MinimumFileSize() As String
            Get
                Return CType(Me("Files_MinimumFileSize"),String)
            End Get
            Set
                Me("Files_MinimumFileSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Use only ONE file with similar size of: [2 000] Bytes")>  _
        Public Property Files_ClusterFilesSizeMod() As String
            Get
                Return CType(Me("Files_ClusterFilesSizeMod"),String)
            End Get
            Set
                Me("Files_ClusterFilesSizeMod") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Maximum files count: [1 000]")>  _
        Public Property Files_MaxFilesCount() As String
            Get
                Return CType(Me("Files_MaxFilesCount"),String)
            End Get
            Set
                Me("Files_MaxFilesCount") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Files containing in name: [*]")>  _
        Public Property File_ContainingStringFilter() As String
            Get
                Return CType(Me("File_ContainingStringFilter"),String)
            End Get
            Set
                Me("File_ContainingStringFilter") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property NewChartWizard_OnlySelectedRows() As Boolean
            Get
                Return CType(Me("NewChartWizard_OnlySelectedRows"),Boolean)
            End Get
            Set
                Me("NewChartWizard_OnlySelectedRows") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property NewChartWizard_DoForAllProjects() As Boolean
            Get
                Return CType(Me("NewChartWizard_DoForAllProjects"),Boolean)
            End Get
            Set
                Me("NewChartWizard_DoForAllProjects") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property NewChartWizard_LastXIndex() As String
            Get
                Return CType(Me("NewChartWizard_LastXIndex"),String)
            End Get
            Set
                Me("NewChartWizard_LastXIndex") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property NewChartWizard_LastYIndex() As String
            Get
                Return CType(Me("NewChartWizard_LastYIndex"),String)
            End Get
            Set
                Me("NewChartWizard_LastYIndex") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Point")>  _
        Public Property Chart_ChartType() As String
            Get
                Return CType(Me("Chart_ChartType"),String)
            End Get
            Set
                Me("Chart_ChartType") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property NewChartWizard_LastZIndex() As String
            Get
                Return CType(Me("NewChartWizard_LastZIndex"),String)
            End Get
            Set
                Me("NewChartWizard_LastZIndex") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Chart_ShowMargin() As Boolean
            Get
                Return CType(Me("Chart_ShowMargin"),Boolean)
            End Get
            Set
                Me("Chart_ShowMargin") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Settings_TreatNumbersAsWords() As Boolean
            Get
                Return CType(Me("Settings_TreatNumbersAsWords"),Boolean)
            End Get
            Set
                Me("Settings_TreatNumbersAsWords") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LastUsedTokenizer() As String
            Get
                Return CType(Me("LastUsedTokenizer"),String)
            End Get
            Set
                Me("LastUsedTokenizer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LastUsedLemmatizer() As String
            Get
                Return CType(Me("LastUsedLemmatizer"),String)
            End Get
            Set
                Me("LastUsedLemmatizer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LastUsedPOSTagger() As String
            Get
                Return CType(Me("LastUsedPOSTagger"),String)
            End Get
            Set
                Me("LastUsedPOSTagger") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LastUsedPostProcessor() As String
            Get
                Return CType(Me("LastUsedPostProcessor"),String)
            End Get
            Set
                Me("LastUsedPostProcessor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Settings_TreatNonAlphaNumericsAsTokens() As Boolean
            Get
                Return CType(Me("Settings_TreatNonAlphaNumericsAsTokens"),Boolean)
            End Get
            Set
                Me("Settings_TreatNonAlphaNumericsAsTokens") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property CacheSettings_CacheTokens() As Boolean
            Get
                Return CType(Me("CacheSettings_CacheTokens"),Boolean)
            End Get
            Set
                Me("CacheSettings_CacheTokens") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property CacheSettings_CacheTypes() As Boolean
            Get
                Return CType(Me("CacheSettings_CacheTypes"),Boolean)
            End Get
            Set
                Me("CacheSettings_CacheTypes") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property CacheSettings_CacheFreqTable() As Boolean
            Get
                Return CType(Me("CacheSettings_CacheFreqTable"),Boolean)
            End Get
            Set
                Me("CacheSettings_CacheFreqTable") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property CacheSettings_EnableCaching() As Boolean
            Get
                Return CType(Me("CacheSettings_EnableCaching"),Boolean)
            End Get
            Set
                Me("CacheSettings_EnableCaching") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Files_RecentFiles() As String
            Get
                Return CType(Me("Files_RecentFiles"),String)
            End Get
            Set
                Me("Files_RecentFiles") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-1")>  _
        Public Property Last_NGramSize() As Integer
            Get
                Return CType(Me("Last_NGramSize"),Integer)
            End Get
            Set
                Me("Last_NGramSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-1")>  _
        Public Property Last_TextReduceSize() As Integer
            Get
                Return CType(Me("Last_TextReduceSize"),Integer)
            End Get
            Set
                Me("Last_TextReduceSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-1")>  _
        Public Property Last_WindowMakerLength() As Integer
            Get
                Return CType(Me("Last_WindowMakerLength"),Integer)
            End Get
            Set
                Me("Last_WindowMakerLength") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Chart_DisplayLegend() As Boolean
            Get
                Return CType(Me("Chart_DisplayLegend"),Boolean)
            End Get
            Set
                Me("Chart_DisplayLegend") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Chart_DisplayMinorGrid() As Boolean
            Get
                Return CType(Me("Chart_DisplayMinorGrid"),Boolean)
            End Get
            Set
                Me("Chart_DisplayMinorGrid") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("25")>  _
        Public Property Chart_MaxMarkSize() As Integer
            Get
                Return CType(Me("Chart_MaxMarkSize"),Integer)
            End Get
            Set
                Me("Chart_MaxMarkSize") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.QITA_OLTK.My.MySettings
            Get
                Return Global.QITA_OLTK.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
