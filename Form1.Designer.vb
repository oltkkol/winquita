<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DockPanelSkin1 As WeifenLuo.WinFormsUI.Docking.DockPanelSkin = New WeifenLuo.WinFormsUI.Docking.DockPanelSkin
        Dim AutoHideStripSkin1 As WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin = New WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin
        Dim DockPanelGradient1 As WeifenLuo.WinFormsUI.Docking.DockPanelGradient = New WeifenLuo.WinFormsUI.Docking.DockPanelGradient
        Dim TabGradient1 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient
        Dim DockPaneStripSkin1 As WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin = New WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin
        Dim DockPaneStripGradient1 As WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient = New WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient
        Dim TabGradient2 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient
        Dim DockPanelGradient2 As WeifenLuo.WinFormsUI.Docking.DockPanelGradient = New WeifenLuo.WinFormsUI.Docking.DockPanelGradient
        Dim TabGradient3 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient
        Dim DockPaneStripToolWindowGradient1 As WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient = New WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient
        Dim TabGradient4 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient
        Dim TabGradient5 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient
        Dim DockPanelGradient3 As WeifenLuo.WinFormsUI.Docking.DockPanelGradient = New WeifenLuo.WinFormsUI.Docking.DockPanelGradient
        Dim TabGradient6 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient
        Dim TabGradient7 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsNewMultiTextProject = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me._DockManager = New WeifenLuo.WinFormsUI.Docking.DockPanel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsToolsStandardDeviationCalc = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.RandomTextCratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BinaryFileToAlphabeteTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Settings_TreatNumbersAsWords = New System.Windows.Forms.ToolStripMenuItem
        Me.Settings_TreatNonAlphasAsWords = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
        Me.ResetNGramsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResetWindowMakerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator
        Me.RecalculateAllProjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "cog.gif")
        Me.ImageList1.Images.SetKeyName(1, "zoom.png")
        Me.ImageList1.Images.SetKeyName(2, "zoom_in.png")
        Me.ImageList1.Images.SetKeyName(3, "zoom_out.png")
        Me.ImageList1.Images.SetKeyName(4, "report.png")
        Me.ImageList1.Images.SetKeyName(5, "chart_line.png")
        Me.ImageList1.Images.SetKeyName(6, "folder.png")
        '
        'ProjectToolStripMenuItem
        '
        Me.ProjectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNewMultiTextProject, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem"
        Me.ProjectToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ProjectToolStripMenuItem.Text = "Project"
        '
        'tsNewMultiTextProject
        '
        Me.tsNewMultiTextProject.Image = CType(resources.GetObject("tsNewMultiTextProject.Image"), System.Drawing.Image)
        Me.tsNewMultiTextProject.Name = "tsNewMultiTextProject"
        Me.tsNewMultiTextProject.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.tsNewMultiTextProject.Size = New System.Drawing.Size(171, 22)
        Me.tsNewMultiTextProject.Text = "New Project"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(168, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        '_DockManager
        '
        Me._DockManager.Dock = System.Windows.Forms.DockStyle.Fill
        Me._DockManager.DockBackColor = System.Drawing.SystemColors.AppWorkspace
        Me._DockManager.Location = New System.Drawing.Point(0, 24)
        Me._DockManager.Name = "_DockManager"
        Me._DockManager.ShowDocumentIcon = True
        Me._DockManager.Size = New System.Drawing.Size(759, 475)
        DockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight
        DockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight
        AutoHideStripSkin1.DockStripGradient = DockPanelGradient1
        TabGradient1.EndColor = System.Drawing.SystemColors.Control
        TabGradient1.StartColor = System.Drawing.SystemColors.Control
        TabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark
        AutoHideStripSkin1.TabGradient = TabGradient1
        AutoHideStripSkin1.TextFont = New System.Drawing.Font("Tahoma", 8.25!)
        DockPanelSkin1.AutoHideStripSkin = AutoHideStripSkin1
        TabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight
        TabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight
        TabGradient2.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripGradient1.ActiveTabGradient = TabGradient2
        DockPanelGradient2.EndColor = System.Drawing.SystemColors.Control
        DockPanelGradient2.StartColor = System.Drawing.SystemColors.Control
        DockPaneStripGradient1.DockStripGradient = DockPanelGradient2
        TabGradient3.EndColor = System.Drawing.SystemColors.ControlLight
        TabGradient3.StartColor = System.Drawing.SystemColors.ControlLight
        TabGradient3.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripGradient1.InactiveTabGradient = TabGradient3
        DockPaneStripSkin1.DocumentGradient = DockPaneStripGradient1
        DockPaneStripSkin1.TextFont = New System.Drawing.Font("Tahoma", 8.25!)
        TabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption
        TabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        TabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption
        TabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        DockPaneStripToolWindowGradient1.ActiveCaptionGradient = TabGradient4
        TabGradient5.EndColor = System.Drawing.SystemColors.Control
        TabGradient5.StartColor = System.Drawing.SystemColors.Control
        TabGradient5.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripToolWindowGradient1.ActiveTabGradient = TabGradient5
        DockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight
        DockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight
        DockPaneStripToolWindowGradient1.DockStripGradient = DockPanelGradient3
        TabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption
        TabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        TabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption
        TabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText
        DockPaneStripToolWindowGradient1.InactiveCaptionGradient = TabGradient6
        TabGradient7.EndColor = System.Drawing.Color.Transparent
        TabGradient7.StartColor = System.Drawing.Color.Transparent
        TabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark
        DockPaneStripToolWindowGradient1.InactiveTabGradient = TabGradient7
        DockPaneStripSkin1.ToolWindowGradient = DockPaneStripToolWindowGradient1
        DockPanelSkin1.DockPaneStripSkin = DockPaneStripSkin1
        Me._DockManager.Skin = DockPanelSkin1
        Me._DockManager.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProjectToolStripMenuItem, Me.HelpToolStripMenuItem, Me.ToolStripMenuItem2, Me.SettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(759, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(103, 22)
        Me.mnuAbout.Text = "About"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsToolsStandardDeviationCalc, Me.ToolStripMenuItem3, Me.RandomTextCratorToolStripMenuItem, Me.BinaryFileToAlphabeteTextToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(44, 20)
        Me.ToolStripMenuItem2.Text = "Tools"
        '
        'tsToolsStandardDeviationCalc
        '
        Me.tsToolsStandardDeviationCalc.Image = CType(resources.GetObject("tsToolsStandardDeviationCalc.Image"), System.Drawing.Image)
        Me.tsToolsStandardDeviationCalc.Name = "tsToolsStandardDeviationCalc"
        Me.tsToolsStandardDeviationCalc.Size = New System.Drawing.Size(217, 22)
        Me.tsToolsStandardDeviationCalc.Text = "Standard Deviation Calculator"
        Me.tsToolsStandardDeviationCalc.Visible = False
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(214, 6)
        Me.ToolStripMenuItem3.Visible = False
        '
        'RandomTextCratorToolStripMenuItem
        '
        Me.RandomTextCratorToolStripMenuItem.Name = "RandomTextCratorToolStripMenuItem"
        Me.RandomTextCratorToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.RandomTextCratorToolStripMenuItem.Text = "Random text crator"
        '
        'BinaryFileToAlphabeteTextToolStripMenuItem
        '
        Me.BinaryFileToAlphabeteTextToolStripMenuItem.Name = "BinaryFileToAlphabeteTextToolStripMenuItem"
        Me.BinaryFileToAlphabeteTextToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.BinaryFileToAlphabeteTextToolStripMenuItem.Text = "Binary file to alphabete text"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Settings_TreatNumbersAsWords, Me.Settings_TreatNonAlphasAsWords, Me.ToolStripMenuItem4, Me.ResetNGramsToolStripMenuItem, Me.ResetWindowMakerToolStripMenuItem, Me.ToolStripMenuItem5, Me.RecalculateAllProjectsToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'Settings_TreatNumbersAsWords
        '
        Me.Settings_TreatNumbersAsWords.Checked = Global.QITA_OLTK.My.MySettings.Default.Settings_TreatNumbersAsWords
        Me.Settings_TreatNumbersAsWords.CheckOnClick = True
        Me.Settings_TreatNumbersAsWords.Name = "Settings_TreatNumbersAsWords"
        Me.Settings_TreatNumbersAsWords.Size = New System.Drawing.Size(288, 22)
        Me.Settings_TreatNumbersAsWords.Text = "Treat Numbers as words"
        '
        'Settings_TreatNonAlphasAsWords
        '
        Me.Settings_TreatNonAlphasAsWords.Checked = Global.QITA_OLTK.My.MySettings.Default.Settings_TreatNonAlphaNumericsAsTokens
        Me.Settings_TreatNonAlphasAsWords.CheckOnClick = True
        Me.Settings_TreatNonAlphasAsWords.Name = "Settings_TreatNonAlphasAsWords"
        Me.Settings_TreatNonAlphasAsWords.Size = New System.Drawing.Size(288, 22)
        Me.Settings_TreatNonAlphasAsWords.Text = "Treat non-alphanumeric characters as words"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(285, 6)
        '
        'ResetNGramsToolStripMenuItem
        '
        Me.ResetNGramsToolStripMenuItem.Name = "ResetNGramsToolStripMenuItem"
        Me.ResetNGramsToolStripMenuItem.Size = New System.Drawing.Size(288, 22)
        Me.ResetNGramsToolStripMenuItem.Text = "Reset N-Grams"
        '
        'ResetWindowMakerToolStripMenuItem
        '
        Me.ResetWindowMakerToolStripMenuItem.Name = "ResetWindowMakerToolStripMenuItem"
        Me.ResetWindowMakerToolStripMenuItem.Size = New System.Drawing.Size(288, 22)
        Me.ResetWindowMakerToolStripMenuItem.Text = "Reset Window-Maker"
        Me.ResetWindowMakerToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(285, 6)
        '
        'RecalculateAllProjectsToolStripMenuItem
        '
        Me.RecalculateAllProjectsToolStripMenuItem.Name = "RecalculateAllProjectsToolStripMenuItem"
        Me.RecalculateAllProjectsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.RecalculateAllProjectsToolStripMenuItem.Size = New System.Drawing.Size(288, 22)
        Me.RecalculateAllProjectsToolStripMenuItem.Text = "Reset and Recalculate All Projects"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 499)
        Me.Controls.Add(Me._DockManager)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "QUITA - Quantitative Text Analyzer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsNewMultiTextProject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsToolsStandardDeviationCalc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RandomTextCratorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BinaryFileToAlphabeteTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Settings_TreatNumbersAsWords As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Settings_TreatNonAlphasAsWords As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetNGramsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ResetWindowMakerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RecalculateAllProjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
