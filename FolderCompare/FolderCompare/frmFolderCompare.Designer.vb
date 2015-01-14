<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramCompare
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramCompare))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tavFileSelection = New System.Windows.Forms.TabPage()
        Me.grpFileLocations = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGetComparisonFilesList = New System.Windows.Forms.Button()
        Me.txtDestinationFile = New System.Windows.Forms.TextBox()
        Me.btnGetBaseFileList = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBaseFile = New System.Windows.Forms.TextBox()
        Me.grpComparisonFile = New System.Windows.Forms.GroupBox()
        Me.btnSetComparisonFolder = New System.Windows.Forms.Button()
        Me.txtComparisonFolderPath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCreateSourceFile = New System.Windows.Forms.Button()
        Me.tabInstallCompare = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvComparison = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCaseNumber = New System.Windows.Forms.Label()
        Me.txtCaseNumber = New System.Windows.Forms.TextBox()
        Me.btnEmailComparisonFile = New System.Windows.Forms.Button()
        Me.btnCancelSearchFilterValue = New System.Windows.Forms.Button()
        Me.lblSearchFileName = New System.Windows.Forms.Label()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.txtFileNameToSearch = New System.Windows.Forms.TextBox()
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.cboViewSettings = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.tslblStatusMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslStatusGraphic = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bwThreadEmailComparisonFile = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tavFileSelection.SuspendLayout()
        Me.grpFileLocations.SuspendLayout()
        Me.grpComparisonFile.SuspendLayout()
        Me.tabInstallCompare.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvComparison, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(100, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(56, 20)
        Me.ToolStripMenuItem1.Text = "&Options"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tavFileSelection)
        Me.TabControl1.Controls.Add(Me.tabInstallCompare)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(792, 549)
        Me.TabControl1.TabIndex = 1
        '
        'tavFileSelection
        '
        Me.tavFileSelection.Controls.Add(Me.grpFileLocations)
        Me.tavFileSelection.Controls.Add(Me.grpComparisonFile)
        Me.tavFileSelection.Location = New System.Drawing.Point(4, 22)
        Me.tavFileSelection.Name = "tavFileSelection"
        Me.tavFileSelection.Padding = New System.Windows.Forms.Padding(3)
        Me.tavFileSelection.Size = New System.Drawing.Size(784, 523)
        Me.tavFileSelection.TabIndex = 0
        Me.tavFileSelection.Text = "File Selection"
        Me.tavFileSelection.UseVisualStyleBackColor = True
        '
        'grpFileLocations
        '
        Me.grpFileLocations.Controls.Add(Me.Label1)
        Me.grpFileLocations.Controls.Add(Me.btnGetComparisonFilesList)
        Me.grpFileLocations.Controls.Add(Me.txtDestinationFile)
        Me.grpFileLocations.Controls.Add(Me.btnGetBaseFileList)
        Me.grpFileLocations.Controls.Add(Me.Label2)
        Me.grpFileLocations.Controls.Add(Me.txtBaseFile)
        Me.grpFileLocations.Location = New System.Drawing.Point(15, 118)
        Me.grpFileLocations.Name = "grpFileLocations"
        Me.grpFileLocations.Size = New System.Drawing.Size(761, 178)
        Me.grpFileLocations.TabIndex = 22
        Me.grpFileLocations.TabStop = False
        Me.grpFileLocations.Text = "Set Comparison File Locations"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Comparison File"
        '
        'btnGetComparisonFilesList
        '
        Me.btnGetComparisonFilesList.Location = New System.Drawing.Point(639, 136)
        Me.btnGetComparisonFilesList.Name = "btnGetComparisonFilesList"
        Me.btnGetComparisonFilesList.Size = New System.Drawing.Size(116, 23)
        Me.btnGetComparisonFilesList.TabIndex = 16
        Me.btnGetComparisonFilesList.Text = "Set Comparison File"
        Me.btnGetComparisonFilesList.UseVisualStyleBackColor = True
        '
        'txtDestinationFile
        '
        Me.txtDestinationFile.Location = New System.Drawing.Point(4, 110)
        Me.txtDestinationFile.Name = "txtDestinationFile"
        Me.txtDestinationFile.Size = New System.Drawing.Size(751, 20)
        Me.txtDestinationFile.TabIndex = 18
        '
        'btnGetBaseFileList
        '
        Me.btnGetBaseFileList.Location = New System.Drawing.Point(639, 65)
        Me.btnGetBaseFileList.Name = "btnGetBaseFileList"
        Me.btnGetBaseFileList.Size = New System.Drawing.Size(116, 23)
        Me.btnGetBaseFileList.TabIndex = 17
        Me.btnGetBaseFileList.Text = "Set Base File"
        Me.btnGetBaseFileList.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Base"
        '
        'txtBaseFile
        '
        Me.txtBaseFile.Location = New System.Drawing.Point(4, 39)
        Me.txtBaseFile.Name = "txtBaseFile"
        Me.txtBaseFile.Size = New System.Drawing.Size(751, 20)
        Me.txtBaseFile.TabIndex = 14
        '
        'grpComparisonFile
        '
        Me.grpComparisonFile.Controls.Add(Me.btnSetComparisonFolder)
        Me.grpComparisonFile.Controls.Add(Me.txtComparisonFolderPath)
        Me.grpComparisonFile.Controls.Add(Me.Label3)
        Me.grpComparisonFile.Controls.Add(Me.btnCreateSourceFile)
        Me.grpComparisonFile.Location = New System.Drawing.Point(13, 10)
        Me.grpComparisonFile.Name = "grpComparisonFile"
        Me.grpComparisonFile.Size = New System.Drawing.Size(763, 94)
        Me.grpComparisonFile.TabIndex = 21
        Me.grpComparisonFile.TabStop = False
        Me.grpComparisonFile.Text = "Comparison File"
        '
        'btnSetComparisonFolder
        '
        Me.btnSetComparisonFolder.Location = New System.Drawing.Point(6, 65)
        Me.btnSetComparisonFolder.Name = "btnSetComparisonFolder"
        Me.btnSetComparisonFolder.Size = New System.Drawing.Size(128, 23)
        Me.btnSetComparisonFolder.TabIndex = 24
        Me.btnSetComparisonFolder.Text = "Set Comparison Folder"
        Me.btnSetComparisonFolder.UseVisualStyleBackColor = True
        '
        'txtComparisonFolderPath
        '
        Me.txtComparisonFolderPath.Location = New System.Drawing.Point(17, 32)
        Me.txtComparisonFolderPath.Name = "txtComparisonFolderPath"
        Me.txtComparisonFolderPath.Size = New System.Drawing.Size(751, 20)
        Me.txtComparisonFolderPath.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Set Folder To Create Comparison File"
        '
        'btnCreateSourceFile
        '
        Me.btnCreateSourceFile.Enabled = False
        Me.btnCreateSourceFile.Location = New System.Drawing.Point(140, 65)
        Me.btnCreateSourceFile.Name = "btnCreateSourceFile"
        Me.btnCreateSourceFile.Size = New System.Drawing.Size(135, 23)
        Me.btnCreateSourceFile.TabIndex = 21
        Me.btnCreateSourceFile.Text = "Create Comparison File"
        Me.btnCreateSourceFile.UseVisualStyleBackColor = True
        '
        'tabInstallCompare
        '
        Me.tabInstallCompare.Controls.Add(Me.Panel2)
        Me.tabInstallCompare.Controls.Add(Me.Panel1)
        Me.tabInstallCompare.Location = New System.Drawing.Point(4, 22)
        Me.tabInstallCompare.Name = "tabInstallCompare"
        Me.tabInstallCompare.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInstallCompare.Size = New System.Drawing.Size(784, 523)
        Me.tabInstallCompare.TabIndex = 1
        Me.tabInstallCompare.Text = "Installation Comparison"
        Me.tabInstallCompare.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvComparison)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 72)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(778, 448)
        Me.Panel2.TabIndex = 5
        '
        'dgvComparison
        '
        Me.dgvComparison.AllowUserToAddRows = False
        Me.dgvComparison.AllowUserToDeleteRows = False
        Me.dgvComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComparison.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvComparison.Location = New System.Drawing.Point(0, 0)
        Me.dgvComparison.Name = "dgvComparison"
        Me.dgvComparison.ReadOnly = True
        Me.dgvComparison.Size = New System.Drawing.Size(778, 448)
        Me.dgvComparison.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblCaseNumber)
        Me.Panel1.Controls.Add(Me.txtCaseNumber)
        Me.Panel1.Controls.Add(Me.btnEmailComparisonFile)
        Me.Panel1.Controls.Add(Me.btnCancelSearchFilterValue)
        Me.Panel1.Controls.Add(Me.lblSearchFileName)
        Me.Panel1.Controls.Add(Me.btnExportToExcel)
        Me.Panel1.Controls.Add(Me.txtFileNameToSearch)
        Me.Panel1.Controls.Add(Me.btnCompare)
        Me.Panel1.Controls.Add(Me.cboViewSettings)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(778, 69)
        Me.Panel1.TabIndex = 4
        '
        'lblCaseNumber
        '
        Me.lblCaseNumber.AutoSize = True
        Me.lblCaseNumber.Location = New System.Drawing.Point(435, 11)
        Me.lblCaseNumber.Name = "lblCaseNumber"
        Me.lblCaseNumber.Size = New System.Drawing.Size(71, 13)
        Me.lblCaseNumber.TabIndex = 14
        Me.lblCaseNumber.Text = "Case Number"
        '
        'txtCaseNumber
        '
        Me.txtCaseNumber.Location = New System.Drawing.Point(512, 9)
        Me.txtCaseNumber.MaxLength = 9
        Me.txtCaseNumber.Name = "txtCaseNumber"
        Me.txtCaseNumber.Size = New System.Drawing.Size(128, 20)
        Me.txtCaseNumber.TabIndex = 13
        '
        'btnEmailComparisonFile
        '
        Me.btnEmailComparisonFile.Enabled = False
        Me.btnEmailComparisonFile.Location = New System.Drawing.Point(646, 8)
        Me.btnEmailComparisonFile.Name = "btnEmailComparisonFile"
        Me.btnEmailComparisonFile.Size = New System.Drawing.Size(127, 23)
        Me.btnEmailComparisonFile.TabIndex = 12
        Me.btnEmailComparisonFile.Text = "Email Comparison File"
        Me.btnEmailComparisonFile.UseVisualStyleBackColor = True
        '
        'btnCancelSearchFilterValue
        '
        Me.btnCancelSearchFilterValue.Image = CType(resources.GetObject("btnCancelSearchFilterValue.Image"), System.Drawing.Image)
        Me.btnCancelSearchFilterValue.Location = New System.Drawing.Point(287, 35)
        Me.btnCancelSearchFilterValue.Name = "btnCancelSearchFilterValue"
        Me.btnCancelSearchFilterValue.Size = New System.Drawing.Size(26, 23)
        Me.btnCancelSearchFilterValue.TabIndex = 11
        Me.btnCancelSearchFilterValue.Text = "Cancel"
        Me.btnCancelSearchFilterValue.UseVisualStyleBackColor = True
        '
        'lblSearchFileName
        '
        Me.lblSearchFileName.AutoSize = True
        Me.lblSearchFileName.Location = New System.Drawing.Point(5, 38)
        Me.lblSearchFileName.Name = "lblSearchFileName"
        Me.lblSearchFileName.Size = New System.Drawing.Size(91, 13)
        Me.lblSearchFileName.TabIndex = 10
        Me.lblSearchFileName.Text = "Search File Name"
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Enabled = False
        Me.btnExportToExcel.Location = New System.Drawing.Point(646, 35)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(127, 23)
        Me.btnExportToExcel.TabIndex = 9
        Me.btnExportToExcel.Text = "Export To Excel"
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        Me.btnExportToExcel.Visible = False
        '
        'txtFileNameToSearch
        '
        Me.txtFileNameToSearch.Location = New System.Drawing.Point(102, 35)
        Me.txtFileNameToSearch.Name = "txtFileNameToSearch"
        Me.txtFileNameToSearch.Size = New System.Drawing.Size(176, 20)
        Me.txtFileNameToSearch.TabIndex = 7
        '
        'btnCompare
        '
        Me.btnCompare.Enabled = False
        Me.btnCompare.Location = New System.Drawing.Point(306, 6)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(102, 23)
        Me.btnCompare.TabIndex = 6
        Me.btnCompare.Text = "Compare Files"
        Me.btnCompare.UseVisualStyleBackColor = True
        '
        'cboViewSettings
        '
        Me.cboViewSettings.FormattingEnabled = True
        Me.cboViewSettings.Location = New System.Drawing.Point(102, 8)
        Me.cboViewSettings.Name = "cboViewSettings"
        Me.cboViewSettings.Size = New System.Drawing.Size(198, 21)
        Me.cboViewSettings.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "View Settings"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.tslblStatusMessage, Me.tslStatusGraphic})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 551)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(792, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.CausesValidation = False
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'tslblStatusMessage
        '
        Me.tslblStatusMessage.Enabled = False
        Me.tslblStatusMessage.Name = "tslblStatusMessage"
        Me.tslblStatusMessage.Size = New System.Drawing.Size(83, 17)
        Me.tslblStatusMessage.Text = "Status Message"
        Me.tslblStatusMessage.ToolTipText = "d"
        Me.tslblStatusMessage.Visible = False
        '
        'tslStatusGraphic
        '
        Me.tslStatusGraphic.AutoSize = False
        Me.tslStatusGraphic.Enabled = False
        Me.tslStatusGraphic.Image = Global.Accounting.Application.CS.My.Resources.Resources.status_anim
        Me.tslStatusGraphic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tslStatusGraphic.Name = "tslStatusGraphic"
        Me.tslStatusGraphic.Size = New System.Drawing.Size(90, 17)
        Me.tslStatusGraphic.Text = "Sending Email"
        Me.tslStatusGraphic.ToolTipText = "Sending Email"
        Me.tslStatusGraphic.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Enabled = False
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem, Me.ExportToCSVToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(161, 48)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Enabled = False
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export To Excel"
        '
        'ExportToCSVToolStripMenuItem
        '
        Me.ExportToCSVToolStripMenuItem.Enabled = False
        Me.ExportToCSVToolStripMenuItem.Name = "ExportToCSVToolStripMenuItem"
        Me.ExportToCSVToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExportToCSVToolStripMenuItem.Text = "Export To CSV"
        '
        'bwThreadEmailComparisonFile
        '
        '
        'frmProgramCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmProgramCompare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Folder Compare"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tavFileSelection.ResumeLayout(False)
        Me.grpFileLocations.ResumeLayout(False)
        Me.grpFileLocations.PerformLayout()
        Me.grpComparisonFile.ResumeLayout(False)
        Me.grpComparisonFile.PerformLayout()
        Me.tabInstallCompare.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvComparison, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tavFileSelection As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents grpComparisonFile As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetComparisonFolder As System.Windows.Forms.Button
    Friend WithEvents txtComparisonFolderPath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCreateSourceFile As System.Windows.Forms.Button
    Friend WithEvents grpFileLocations As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGetComparisonFilesList As System.Windows.Forms.Button
    Friend WithEvents txtDestinationFile As System.Windows.Forms.TextBox
    Friend WithEvents btnGetBaseFileList As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBaseFile As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabInstallCompare As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvComparison As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelSearchFilterValue As System.Windows.Forms.Button
    Friend WithEvents lblSearchFileName As System.Windows.Forms.Label
    Friend WithEvents btnExportToExcel As System.Windows.Forms.Button
    Friend WithEvents txtFileNameToSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents cboViewSettings As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEmailComparisonFile As System.Windows.Forms.Button
    Friend WithEvents lblCaseNumber As System.Windows.Forms.Label
    Friend WithEvents txtCaseNumber As System.Windows.Forms.TextBox
    Friend WithEvents tslblStatusMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslStatusGraphic As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents bwThreadEmailComparisonFile As System.ComponentModel.BackgroundWorker

End Class
