<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UFProjectTexts
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UFProjectTexts))
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.tabProject = New QITA_OLTK.TabControlEx
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdStopCompute = New System.Windows.Forms.Button
        Me.cmdCompute = New System.Windows.Forms.Button
        Me.lblComputeStatus = New System.Windows.Forms.Label
        Me.pgComputeStatus = New System.Windows.Forms.ProgressBar
        Me.tabControlProjectSettings = New System.Windows.Forms.TabControl
        Me.tabProjectSettingsPageProject = New System.Windows.Forms.TabPage
        Me.tabProjectSettingsPageProjectTextsGroup = New System.Windows.Forms.GroupBox
        Me.UcFiles1 = New QITA_OLTK.UCFiles
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmbPostProcessor = New QITA_OLTK.UCPostProcessorBrowser
        Me.cmbLemmatizer = New QITA_OLTK.ComboBoxEx
        Me.cmbTokenizer = New QITA_OLTK.ComboBoxEx
        Me.cmbPOSTagger = New QITA_OLTK.ComboBoxEx
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tabProjectSettingsPageProjectTextsProject = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSettingsProjectName = New System.Windows.Forms.TextBox
        Me.tabProjectSettingsPageTexts = New System.Windows.Forms.TabPage
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.UcIndexBrowser1 = New QITA_OLTK.UCAssemblyBrowser
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.ucTokenizerBrowser = New QITA_OLTK.UCAssemblyBrowser
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.ucLemmatizerBrowser = New QITA_OLTK.UCAssemblyBrowser
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ucPOSTaggerBrowser = New QITA_OLTK.UCAssemblyBrowser
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CacheSettings_CacheGroup = New System.Windows.Forms.GroupBox
        Me.CacheSettings_ChkCacheFreqTable = New System.Windows.Forms.CheckBox
        Me.CacheSettings_ChkCacheTypes = New System.Windows.Forms.CheckBox
        Me.CacheSettings_ChkCacheTokens = New System.Windows.Forms.CheckBox
        Me.CacheSettings_rtbEnableCache = New System.Windows.Forms.RadioButton
        Me.CacheSettings_rtbDisableCacheAtAll = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.tabResultsOverview = New System.Windows.Forms.TabPage
        Me.UcResults1 = New QITA_OLTK.UCResults
        Me.tabProject.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabControlProjectSettings.SuspendLayout()
        Me.tabProjectSettingsPageProject.SuspendLayout()
        Me.tabProjectSettingsPageProjectTextsGroup.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tabProjectSettingsPageProjectTextsProject.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.CacheSettings_CacheGroup.SuspendLayout()
        Me.tabResultsOverview.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "newFile")
        Me.imgList.Images.SetKeyName(1, "sum")
        Me.imgList.Images.SetKeyName(2, "text")
        Me.imgList.Images.SetKeyName(3, "newPage")
        Me.imgList.Images.SetKeyName(4, "pencil_add.png")
        Me.imgList.Images.SetKeyName(5, "working")
        Me.imgList.Images.SetKeyName(6, "table_go.png")
        Me.imgList.Images.SetKeyName(7, "waiting")
        Me.imgList.Images.SetKeyName(8, "ready")
        Me.imgList.Images.SetKeyName(9, "inqueue")
        Me.imgList.Images.SetKeyName(10, "calc")
        Me.imgList.Images.SetKeyName(11, "text_uppercase.png")
        Me.imgList.Images.SetKeyName(12, "text_signature.png")
        Me.imgList.Images.SetKeyName(13, "cog_go.png")
        Me.imgList.Images.SetKeyName(14, "text_letterspacing.png")
        Me.imgList.Images.SetKeyName(15, "cog.png")
        Me.imgList.Images.SetKeyName(16, "text_horizontalrule.png")
        Me.imgList.Images.SetKeyName(17, "pencil.png")
        Me.imgList.Images.SetKeyName(18, "table")
        Me.imgList.Images.SetKeyName(19, "icons_trigram.png")
        Me.imgList.Images.SetKeyName(20, "icons_bigram.png")
        Me.imgList.Images.SetKeyName(21, "cache")
        '
        'tabProject
        '
        Me.tabProject.Controls.Add(Me.TabPage1)
        Me.tabProject.Controls.Add(Me.tabResultsOverview)
        Me.tabProject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tabProject.ImageList = Me.imgList
        Me.tabProject.Location = New System.Drawing.Point(0, 0)
        Me.tabProject.Name = "tabProject"
        Me.tabProject.SelectedIndex = 0
        Me.tabProject.Size = New System.Drawing.Size(844, 584)
        Me.tabProject.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.tabControlProjectSettings)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TabPage1.ImageKey = "pencil_add.png"
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(836, 555)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = "noClose"
        Me.TabPage1.Text = "Project Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdStopCompute)
        Me.GroupBox1.Controls.Add(Me.cmdCompute)
        Me.GroupBox1.Controls.Add(Me.lblComputeStatus)
        Me.GroupBox1.Controls.Add(Me.pgComputeStatus)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, 489)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(830, 63)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'cmdStopCompute
        '
        Me.cmdStopCompute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdStopCompute.Enabled = False
        Me.cmdStopCompute.Image = CType(resources.GetObject("cmdStopCompute.Image"), System.Drawing.Image)
        Me.cmdStopCompute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdStopCompute.Location = New System.Drawing.Point(543, 16)
        Me.cmdStopCompute.Name = "cmdStopCompute"
        Me.cmdStopCompute.Size = New System.Drawing.Size(135, 36)
        Me.cmdStopCompute.TabIndex = 3
        Me.cmdStopCompute.Text = "Stop"
        Me.cmdStopCompute.UseVisualStyleBackColor = True
        '
        'cmdCompute
        '
        Me.cmdCompute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCompute.Image = CType(resources.GetObject("cmdCompute.Image"), System.Drawing.Image)
        Me.cmdCompute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCompute.Location = New System.Drawing.Point(684, 16)
        Me.cmdCompute.Name = "cmdCompute"
        Me.cmdCompute.Size = New System.Drawing.Size(135, 36)
        Me.cmdCompute.TabIndex = 2
        Me.cmdCompute.Text = "&Start!"
        Me.cmdCompute.UseVisualStyleBackColor = True
        '
        'lblComputeStatus
        '
        Me.lblComputeStatus.AutoSize = True
        Me.lblComputeStatus.Location = New System.Drawing.Point(12, 14)
        Me.lblComputeStatus.Name = "lblComputeStatus"
        Me.lblComputeStatus.Size = New System.Drawing.Size(77, 13)
        Me.lblComputeStatus.TabIndex = 1
        Me.lblComputeStatus.Text = "Status: Ready."
        '
        'pgComputeStatus
        '
        Me.pgComputeStatus.Location = New System.Drawing.Point(12, 30)
        Me.pgComputeStatus.Name = "pgComputeStatus"
        Me.pgComputeStatus.Size = New System.Drawing.Size(153, 22)
        Me.pgComputeStatus.TabIndex = 0
        '
        'tabControlProjectSettings
        '
        Me.tabControlProjectSettings.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tabControlProjectSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControlProjectSettings.Controls.Add(Me.tabProjectSettingsPageProject)
        Me.tabControlProjectSettings.Controls.Add(Me.tabProjectSettingsPageTexts)
        Me.tabControlProjectSettings.Controls.Add(Me.TabPage5)
        Me.tabControlProjectSettings.Controls.Add(Me.TabPage7)
        Me.tabControlProjectSettings.Controls.Add(Me.TabPage6)
        Me.tabControlProjectSettings.Controls.Add(Me.TabPage2)
        Me.tabControlProjectSettings.Controls.Add(Me.TabPage3)
        Me.tabControlProjectSettings.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabControlProjectSettings.ImageList = Me.imgList
        Me.tabControlProjectSettings.ItemSize = New System.Drawing.Size(30, 130)
        Me.tabControlProjectSettings.Location = New System.Drawing.Point(3, 0)
        Me.tabControlProjectSettings.Multiline = True
        Me.tabControlProjectSettings.Name = "tabControlProjectSettings"
        Me.tabControlProjectSettings.SelectedIndex = 0
        Me.tabControlProjectSettings.Size = New System.Drawing.Size(830, 483)
        Me.tabControlProjectSettings.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabControlProjectSettings.TabIndex = 6
        '
        'tabProjectSettingsPageProject
        '
        Me.tabProjectSettingsPageProject.Controls.Add(Me.tabProjectSettingsPageProjectTextsGroup)
        Me.tabProjectSettingsPageProject.Controls.Add(Me.GroupBox5)
        Me.tabProjectSettingsPageProject.Controls.Add(Me.tabProjectSettingsPageProjectTextsProject)
        Me.tabProjectSettingsPageProject.ImageKey = "pencil.png"
        Me.tabProjectSettingsPageProject.Location = New System.Drawing.Point(134, 4)
        Me.tabProjectSettingsPageProject.Name = "tabProjectSettingsPageProject"
        Me.tabProjectSettingsPageProject.Size = New System.Drawing.Size(692, 475)
        Me.tabProjectSettingsPageProject.TabIndex = 6
        Me.tabProjectSettingsPageProject.Text = "All"
        Me.tabProjectSettingsPageProject.UseVisualStyleBackColor = True
        '
        'tabProjectSettingsPageProjectTextsGroup
        '
        Me.tabProjectSettingsPageProjectTextsGroup.Controls.Add(Me.UcFiles1)
        Me.tabProjectSettingsPageProjectTextsGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabProjectSettingsPageProjectTextsGroup.Location = New System.Drawing.Point(0, 208)
        Me.tabProjectSettingsPageProjectTextsGroup.Name = "tabProjectSettingsPageProjectTextsGroup"
        Me.tabProjectSettingsPageProjectTextsGroup.Size = New System.Drawing.Size(692, 267)
        Me.tabProjectSettingsPageProjectTextsGroup.TabIndex = 2
        Me.tabProjectSettingsPageProjectTextsGroup.TabStop = False
        Me.tabProjectSettingsPageProjectTextsGroup.Text = "Texts"
        '
        'UcFiles1
        '
        Me.UcFiles1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcFiles1.Location = New System.Drawing.Point(3, 16)
        Me.UcFiles1.Name = "UcFiles1"
        Me.UcFiles1.Size = New System.Drawing.Size(686, 248)
        Me.UcFiles1.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbPostProcessor)
        Me.GroupBox5.Controls.Add(Me.cmbLemmatizer)
        Me.GroupBox5.Controls.Add(Me.cmbTokenizer)
        Me.GroupBox5.Controls.Add(Me.cmbPOSTagger)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(0, 76)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(692, 132)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "&Morpho Analyzers"
        '
        'cmbPostProcessor
        '
        Me.cmbPostProcessor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPostProcessor.DisplayDescriptions = True
        Me.cmbPostProcessor.DisplayEmptyGroups = False
        Me.cmbPostProcessor.DisplayGroupHeadersImage = True
        Me.cmbPostProcessor.DisplayGroupsHeaders = True
        Me.cmbPostProcessor.DisplayImagesForAllItems = False
        Me.cmbPostProcessor.DisplayPrependedSpace = True
        Me.cmbPostProcessor.DisplaySelectedItemImage = True
        Me.cmbPostProcessor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPostProcessor.ForeColorDescription = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cmbPostProcessor.ForeColorDescriptionInGroupHeaders = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cmbPostProcessor.FormattingEnabled = True
        Me.cmbPostProcessor.GroupHeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.cmbPostProcessor.HideSelectedItemWhenControlDisabled = False
        Me.cmbPostProcessor.ImageList = Nothing
        Me.cmbPostProcessor.Location = New System.Drawing.Point(115, 104)
        Me.cmbPostProcessor.Name = "cmbPostProcessor"
        Me.cmbPostProcessor.SelectedItem = Nothing
        Me.cmbPostProcessor.Size = New System.Drawing.Size(570, 21)
        Me.cmbPostProcessor.TabIndex = 3
        '
        'cmbLemmatizer
        '
        Me.cmbLemmatizer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLemmatizer.DisplayDescriptions = True
        Me.cmbLemmatizer.DisplayEmptyGroups = False
        Me.cmbLemmatizer.DisplayGroupHeadersImage = True
        Me.cmbLemmatizer.DisplayGroupsHeaders = True
        Me.cmbLemmatizer.DisplayImagesForAllItems = False
        Me.cmbLemmatizer.DisplayPrependedSpace = True
        Me.cmbLemmatizer.DisplaySelectedItemImage = True
        Me.cmbLemmatizer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbLemmatizer.ForeColorDescription = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cmbLemmatizer.ForeColorDescriptionInGroupHeaders = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cmbLemmatizer.FormattingEnabled = True
        Me.cmbLemmatizer.GroupHeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.cmbLemmatizer.HideSelectedItemWhenControlDisabled = False
        Me.cmbLemmatizer.ImageList = Nothing
        Me.cmbLemmatizer.Location = New System.Drawing.Point(115, 46)
        Me.cmbLemmatizer.Name = "cmbLemmatizer"
        Me.cmbLemmatizer.SelectedItem = Nothing
        Me.cmbLemmatizer.Size = New System.Drawing.Size(570, 21)
        Me.cmbLemmatizer.TabIndex = 1
        '
        'cmbTokenizer
        '
        Me.cmbTokenizer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTokenizer.DisplayDescriptions = True
        Me.cmbTokenizer.DisplayEmptyGroups = False
        Me.cmbTokenizer.DisplayGroupHeadersImage = True
        Me.cmbTokenizer.DisplayGroupsHeaders = True
        Me.cmbTokenizer.DisplayImagesForAllItems = False
        Me.cmbTokenizer.DisplayPrependedSpace = True
        Me.cmbTokenizer.DisplaySelectedItemImage = True
        Me.cmbTokenizer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTokenizer.ForeColorDescription = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cmbTokenizer.ForeColorDescriptionInGroupHeaders = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cmbTokenizer.FormattingEnabled = True
        Me.cmbTokenizer.GroupHeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.cmbTokenizer.HideSelectedItemWhenControlDisabled = False
        Me.cmbTokenizer.ImageList = Nothing
        Me.cmbTokenizer.Location = New System.Drawing.Point(115, 19)
        Me.cmbTokenizer.Name = "cmbTokenizer"
        Me.cmbTokenizer.SelectedItem = Nothing
        Me.cmbTokenizer.Size = New System.Drawing.Size(570, 21)
        Me.cmbTokenizer.TabIndex = 0
        '
        'cmbPOSTagger
        '
        Me.cmbPOSTagger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPOSTagger.DisplayDescriptions = True
        Me.cmbPOSTagger.DisplayEmptyGroups = False
        Me.cmbPOSTagger.DisplayGroupHeadersImage = True
        Me.cmbPOSTagger.DisplayGroupsHeaders = True
        Me.cmbPOSTagger.DisplayImagesForAllItems = False
        Me.cmbPOSTagger.DisplayPrependedSpace = True
        Me.cmbPOSTagger.DisplaySelectedItemImage = True
        Me.cmbPOSTagger.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPOSTagger.ForeColorDescription = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cmbPOSTagger.ForeColorDescriptionInGroupHeaders = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cmbPOSTagger.FormattingEnabled = True
        Me.cmbPOSTagger.GroupHeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.cmbPOSTagger.HideSelectedItemWhenControlDisabled = False
        Me.cmbPOSTagger.ImageList = Nothing
        Me.cmbPOSTagger.Location = New System.Drawing.Point(115, 75)
        Me.cmbPOSTagger.Name = "cmbPOSTagger"
        Me.cmbPOSTagger.SelectedItem = Nothing
        Me.cmbPOSTagger.Size = New System.Drawing.Size(570, 21)
        Me.cmbPOSTagger.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Post Processor:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "POS Tagger:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Lemmatizer:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tokenizer:"
        '
        'tabProjectSettingsPageProjectTextsProject
        '
        Me.tabProjectSettingsPageProjectTextsProject.Controls.Add(Me.Label1)
        Me.tabProjectSettingsPageProjectTextsProject.Controls.Add(Me.txtSettingsProjectName)
        Me.tabProjectSettingsPageProjectTextsProject.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabProjectSettingsPageProjectTextsProject.Location = New System.Drawing.Point(0, 0)
        Me.tabProjectSettingsPageProjectTextsProject.Name = "tabProjectSettingsPageProjectTextsProject"
        Me.tabProjectSettingsPageProjectTextsProject.Size = New System.Drawing.Size(692, 76)
        Me.tabProjectSettingsPageProjectTextsProject.TabIndex = 0
        Me.tabProjectSettingsPageProjectTextsProject.TabStop = False
        Me.tabProjectSettingsPageProjectTextsProject.Text = "&Project"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Project name:"
        '
        'txtSettingsProjectName
        '
        Me.txtSettingsProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSettingsProjectName.Location = New System.Drawing.Point(115, 28)
        Me.txtSettingsProjectName.Name = "txtSettingsProjectName"
        Me.txtSettingsProjectName.Size = New System.Drawing.Size(571, 20)
        Me.txtSettingsProjectName.TabIndex = 0
        '
        'tabProjectSettingsPageTexts
        '
        Me.tabProjectSettingsPageTexts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tabProjectSettingsPageTexts.ImageKey = "text_signature.png"
        Me.tabProjectSettingsPageTexts.Location = New System.Drawing.Point(134, 4)
        Me.tabProjectSettingsPageTexts.Name = "tabProjectSettingsPageTexts"
        Me.tabProjectSettingsPageTexts.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProjectSettingsPageTexts.Size = New System.Drawing.Size(692, 475)
        Me.tabProjectSettingsPageTexts.TabIndex = 0
        Me.tabProjectSettingsPageTexts.Text = "Texts"
        Me.tabProjectSettingsPageTexts.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.UcIndexBrowser1)
        Me.TabPage5.ImageKey = "calc"
        Me.TabPage5.Location = New System.Drawing.Point(134, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(692, 475)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Indexes to compute"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'UcIndexBrowser1
        '
        Me.UcIndexBrowser1.CheckAllByDefault = True
        Me.UcIndexBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcIndexBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.UcIndexBrowser1.Name = "UcIndexBrowser1"
        Me.UcIndexBrowser1.ShowAssemblies = QITA_OLTK.UCAssemblyBrowser.ShowType.ShowIndexes
        Me.UcIndexBrowser1.ShowCheckBoxes = True
        Me.UcIndexBrowser1.SingleSelection = False
        Me.UcIndexBrowser1.Size = New System.Drawing.Size(686, 469)
        Me.UcIndexBrowser1.TabIndex = 2
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.ucTokenizerBrowser)
        Me.TabPage7.ImageKey = "text_horizontalrule.png"
        Me.TabPage7.Location = New System.Drawing.Point(134, 4)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(692, 475)
        Me.TabPage7.TabIndex = 5
        Me.TabPage7.Text = "Tokenizer"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'ucTokenizerBrowser
        '
        Me.ucTokenizerBrowser.CheckAllByDefault = False
        Me.ucTokenizerBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucTokenizerBrowser.Location = New System.Drawing.Point(3, 3)
        Me.ucTokenizerBrowser.Name = "ucTokenizerBrowser"
        Me.ucTokenizerBrowser.ShowAssemblies = QITA_OLTK.UCAssemblyBrowser.ShowType.ShowTokenizers
        Me.ucTokenizerBrowser.ShowCheckBoxes = True
        Me.ucTokenizerBrowser.SingleSelection = True
        Me.ucTokenizerBrowser.Size = New System.Drawing.Size(686, 469)
        Me.ucTokenizerBrowser.TabIndex = 2
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.ucLemmatizerBrowser)
        Me.TabPage6.ImageKey = "text_uppercase.png"
        Me.TabPage6.Location = New System.Drawing.Point(134, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(692, 475)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "Lemmatizer"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'ucLemmatizerBrowser
        '
        Me.ucLemmatizerBrowser.CheckAllByDefault = False
        Me.ucLemmatizerBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucLemmatizerBrowser.Location = New System.Drawing.Point(3, 3)
        Me.ucLemmatizerBrowser.Name = "ucLemmatizerBrowser"
        Me.ucLemmatizerBrowser.ShowAssemblies = QITA_OLTK.UCAssemblyBrowser.ShowType.ShowLemmatizers
        Me.ucLemmatizerBrowser.ShowCheckBoxes = True
        Me.ucLemmatizerBrowser.SingleSelection = True
        Me.ucLemmatizerBrowser.Size = New System.Drawing.Size(686, 469)
        Me.ucLemmatizerBrowser.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ucPOSTaggerBrowser)
        Me.TabPage2.ImageKey = "text_letterspacing.png"
        Me.TabPage2.Location = New System.Drawing.Point(134, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(692, 475)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "POS Tagger"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ucPOSTaggerBrowser
        '
        Me.ucPOSTaggerBrowser.CheckAllByDefault = False
        Me.ucPOSTaggerBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucPOSTaggerBrowser.Location = New System.Drawing.Point(0, 0)
        Me.ucPOSTaggerBrowser.Name = "ucPOSTaggerBrowser"
        Me.ucPOSTaggerBrowser.ShowAssemblies = QITA_OLTK.UCAssemblyBrowser.ShowType.ShowPOSTaggers
        Me.ucPOSTaggerBrowser.ShowCheckBoxes = True
        Me.ucPOSTaggerBrowser.SingleSelection = True
        Me.ucPOSTaggerBrowser.Size = New System.Drawing.Size(692, 475)
        Me.ucPOSTaggerBrowser.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.ImageKey = "cache"
        Me.TabPage3.Location = New System.Drawing.Point(134, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(692, 475)
        Me.TabPage3.TabIndex = 7
        Me.TabPage3.Text = "Cache"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CacheSettings_CacheGroup)
        Me.GroupBox2.Controls.Add(Me.CacheSettings_rtbDisableCacheAtAll)
        Me.GroupBox2.Controls.Add(Me.CacheSettings_rtbEnableCache)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(669, 415)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cache Settings"
        '
        'CacheSettings_CacheGroup
        '
        Me.CacheSettings_CacheGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CacheSettings_CacheGroup.Controls.Add(Me.CacheSettings_ChkCacheFreqTable)
        Me.CacheSettings_CacheGroup.Controls.Add(Me.CacheSettings_ChkCacheTypes)
        Me.CacheSettings_CacheGroup.Controls.Add(Me.CacheSettings_ChkCacheTokens)
        Me.CacheSettings_CacheGroup.Location = New System.Drawing.Point(6, 59)
        Me.CacheSettings_CacheGroup.Name = "CacheSettings_CacheGroup"
        Me.CacheSettings_CacheGroup.Size = New System.Drawing.Size(657, 94)
        Me.CacheSettings_CacheGroup.TabIndex = 2
        Me.CacheSettings_CacheGroup.TabStop = False
        '
        'CacheSettings_ChkCacheFreqTable
        '
        Me.CacheSettings_ChkCacheFreqTable.AutoSize = True
        Me.CacheSettings_ChkCacheFreqTable.Checked = Global.QITA_OLTK.My.MySettings.Default.CacheSettings_CacheFreqTable
        Me.CacheSettings_ChkCacheFreqTable.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.QITA_OLTK.My.MySettings.Default, "CacheSettings_CacheFreqTable", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CacheSettings_ChkCacheFreqTable.Location = New System.Drawing.Point(19, 68)
        Me.CacheSettings_ChkCacheFreqTable.Name = "CacheSettings_ChkCacheFreqTable"
        Me.CacheSettings_ChkCacheFreqTable.Size = New System.Drawing.Size(395, 17)
        Me.CacheSettings_ChkCacheFreqTable.TabIndex = 4
        Me.CacheSettings_ChkCacheFreqTable.Text = "Cache Frequency Table (prevents from repeating time consuming calculations)"
        Me.CacheSettings_ChkCacheFreqTable.UseVisualStyleBackColor = True
        '
        'CacheSettings_ChkCacheTypes
        '
        Me.CacheSettings_ChkCacheTypes.AutoSize = True
        Me.CacheSettings_ChkCacheTypes.Checked = Global.QITA_OLTK.My.MySettings.Default.CacheSettings_CacheTypes
        Me.CacheSettings_ChkCacheTypes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CacheSettings_ChkCacheTypes.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.QITA_OLTK.My.MySettings.Default, "CacheSettings_CacheTypes", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CacheSettings_ChkCacheTypes.Location = New System.Drawing.Point(19, 45)
        Me.CacheSettings_ChkCacheTypes.Name = "CacheSettings_ChkCacheTypes"
        Me.CacheSettings_ChkCacheTypes.Size = New System.Drawing.Size(275, 17)
        Me.CacheSettings_ChkCacheTypes.TabIndex = 3
        Me.CacheSettings_ChkCacheTypes.Text = "Cache Types (prevents from repeating lemmatization)"
        Me.CacheSettings_ChkCacheTypes.UseVisualStyleBackColor = True
        '
        'CacheSettings_ChkCacheTokens
        '
        Me.CacheSettings_ChkCacheTokens.AutoSize = True
        Me.CacheSettings_ChkCacheTokens.Checked = Global.QITA_OLTK.My.MySettings.Default.CacheSettings_CacheTokens
        Me.CacheSettings_ChkCacheTokens.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CacheSettings_ChkCacheTokens.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.QITA_OLTK.My.MySettings.Default, "CacheSettings_CacheTokens", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CacheSettings_ChkCacheTokens.Location = New System.Drawing.Point(19, 22)
        Me.CacheSettings_ChkCacheTokens.Name = "CacheSettings_ChkCacheTokens"
        Me.CacheSettings_ChkCacheTokens.Size = New System.Drawing.Size(276, 17)
        Me.CacheSettings_ChkCacheTokens.TabIndex = 2
        Me.CacheSettings_ChkCacheTokens.Text = "Cache Tokens (prevents from repeating tokenization)"
        Me.CacheSettings_ChkCacheTokens.UseVisualStyleBackColor = True
        '
        'CacheSettings_rtbEnableCache
        '
        Me.CacheSettings_rtbEnableCache.AutoSize = True
        Me.CacheSettings_rtbEnableCache.Checked = Global.QITA_OLTK.My.MySettings.Default.CacheSettings_EnableCaching
        Me.CacheSettings_rtbEnableCache.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.QITA_OLTK.My.MySettings.Default, "CacheSettings_EnableCaching", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CacheSettings_rtbEnableCache.Location = New System.Drawing.Point(12, 42)
        Me.CacheSettings_rtbEnableCache.Name = "CacheSettings_rtbEnableCache"
        Me.CacheSettings_rtbEnableCache.Size = New System.Drawing.Size(479, 17)
        Me.CacheSettings_rtbEnableCache.TabIndex = 1
        Me.CacheSettings_rtbEnableCache.TabStop = True
        Me.CacheSettings_rtbEnableCache.Text = "Enable Cache (I want to display Tokens, Types, Frequencies or I can not wait/use " & _
            "reprocessing)"
        Me.CacheSettings_rtbEnableCache.UseVisualStyleBackColor = True
        '
        'CacheSettings_rtbDisableCacheAtAll
        '
        Me.CacheSettings_rtbDisableCacheAtAll.AutoSize = True
        Me.CacheSettings_rtbDisableCacheAtAll.Location = New System.Drawing.Point(12, 19)
        Me.CacheSettings_rtbDisableCacheAtAll.Name = "CacheSettings_rtbDisableCacheAtAll"
        Me.CacheSettings_rtbDisableCacheAtAll.Size = New System.Drawing.Size(554, 17)
        Me.CacheSettings_rtbDisableCacheAtAll.TabIndex = 0
        Me.CacheSettings_rtbDisableCacheAtAll.Text = "Disable Cache at All (I do not need to display Tokens, Types, Frequencies at all " & _
            "or I can wait for its reprocessing)"
        Me.CacheSettings_rtbDisableCacheAtAll.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(13, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(672, 72)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = resources.GetString("Label6.Text")
        '
        'tabResultsOverview
        '
        Me.tabResultsOverview.Controls.Add(Me.UcResults1)
        Me.tabResultsOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tabResultsOverview.ImageKey = "sum"
        Me.tabResultsOverview.Location = New System.Drawing.Point(4, 25)
        Me.tabResultsOverview.Name = "tabResultsOverview"
        Me.tabResultsOverview.Padding = New System.Windows.Forms.Padding(3)
        Me.tabResultsOverview.Size = New System.Drawing.Size(836, 555)
        Me.tabResultsOverview.TabIndex = 1
        Me.tabResultsOverview.Tag = "noClose"
        Me.tabResultsOverview.Text = "Results"
        Me.tabResultsOverview.UseVisualStyleBackColor = True
        '
        'UcResults1
        '
        Me.UcResults1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcResults1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.UcResults1.Location = New System.Drawing.Point(3, 3)
        Me.UcResults1.Margin = New System.Windows.Forms.Padding(4)
        Me.UcResults1.Name = "UcResults1"
        Me.UcResults1.Project = Nothing
        Me.UcResults1.Size = New System.Drawing.Size(830, 549)
        Me.UcResults1.TabIndex = 0
        '
        'UFProjectTexts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(844, 584)
        Me.Controls.Add(Me.tabProject)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.KeyPreview = True
        Me.Name = "UFProjectTexts"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.tabProject.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabControlProjectSettings.ResumeLayout(False)
        Me.tabProjectSettingsPageProject.ResumeLayout(False)
        Me.tabProjectSettingsPageProjectTextsGroup.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tabProjectSettingsPageProjectTextsProject.ResumeLayout(False)
        Me.tabProjectSettingsPageProjectTextsProject.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.CacheSettings_CacheGroup.ResumeLayout(False)
        Me.CacheSettings_CacheGroup.PerformLayout()
        Me.tabResultsOverview.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents UcResults1 As QITA_OLTK.UCResults
    Friend WithEvents UcIndexBrowser1 As QITA_OLTK.UCAssemblyBrowser
    Friend WithEvents ucLemmatizerBrowser As QITA_OLTK.UCAssemblyBrowser
    Friend WithEvents tabControlProjectSettings As System.Windows.Forms.TabControl
    Friend WithEvents tabProjectSettingsPageTexts As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ucPOSTaggerBrowser As QITA_OLTK.UCAssemblyBrowser
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSettingsProjectName As System.Windows.Forms.TextBox
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents ucTokenizerBrowser As QITA_OLTK.UCAssemblyBrowser
    Friend WithEvents tabProjectSettingsPageProject As System.Windows.Forms.TabPage
    Friend WithEvents tabProjectSettingsPageProjectTextsProject As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents tabProjectSettingsPageProjectTextsGroup As System.Windows.Forms.GroupBox
    Friend WithEvents UcFiles1 As QITA_OLTK.UCFiles
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabProject As QITA_OLTK.TabControlEx
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tabResultsOverview As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCompute As System.Windows.Forms.Button
    Friend WithEvents lblComputeStatus As System.Windows.Forms.Label
    Friend WithEvents pgComputeStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdStopCompute As System.Windows.Forms.Button
    Friend WithEvents cmbPOSTagger As QITA_OLTK.ComboBoxEx
    Friend WithEvents cmbLemmatizer As QITA_OLTK.ComboBoxEx
    Friend WithEvents cmbTokenizer As QITA_OLTK.ComboBoxEx
    Friend WithEvents cmbPostProcessor As QITA_OLTK.UCPostProcessorBrowser
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CacheSettings_rtbEnableCache As System.Windows.Forms.RadioButton
    Friend WithEvents CacheSettings_rtbDisableCacheAtAll As System.Windows.Forms.RadioButton
    Friend WithEvents CacheSettings_CacheGroup As System.Windows.Forms.GroupBox
    Friend WithEvents CacheSettings_ChkCacheFreqTable As System.Windows.Forms.CheckBox
    Friend WithEvents CacheSettings_ChkCacheTypes As System.Windows.Forms.CheckBox
    Friend WithEvents CacheSettings_ChkCacheTokens As System.Windows.Forms.CheckBox
End Class
