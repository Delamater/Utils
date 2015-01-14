<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAppSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAppSettings))
        Me.grpContactInfo = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFromEmailAddr = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDefaults = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDefaultFolderToCompare = New System.Windows.Forms.TextBox()
        Me.txtDfltToEmailAddr = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.miSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSaveAndClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpContactInfo.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDefaults.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpContactInfo
        '
        Me.grpContactInfo.Controls.Add(Me.Label3)
        Me.grpContactInfo.Controls.Add(Me.txtFromEmailAddr)
        Me.grpContactInfo.Controls.Add(Me.txtLastName)
        Me.grpContactInfo.Controls.Add(Me.Label2)
        Me.grpContactInfo.Controls.Add(Me.Label1)
        Me.grpContactInfo.Controls.Add(Me.txtFirstName)
        Me.grpContactInfo.Location = New System.Drawing.Point(12, 27)
        Me.grpContactInfo.Name = "grpContactInfo"
        Me.grpContactInfo.Size = New System.Drawing.Size(460, 115)
        Me.grpContactInfo.TabIndex = 1
        Me.grpContactInfo.TabStop = False
        Me.grpContactInfo.Text = "Contact Information"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Email"
        '
        'txtFromEmailAddr
        '
        Me.txtFromEmailAddr.Location = New System.Drawing.Point(88, 81)
        Me.txtFromEmailAddr.MaxLength = 100
        Me.txtFromEmailAddr.Name = "txtFromEmailAddr"
        Me.txtFromEmailAddr.Size = New System.Drawing.Size(329, 20)
        Me.txtFromEmailAddr.TabIndex = 5
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(88, 54)
        Me.txtLastName.MaxLength = 100
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(329, 20)
        Me.txtLastName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Last Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "First Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(88, 19)
        Me.txtFirstName.MaxLength = 100
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(329, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'grpDefaults
        '
        Me.grpDefaults.Controls.Add(Me.Label5)
        Me.grpDefaults.Controls.Add(Me.txtDefaultFolderToCompare)
        Me.grpDefaults.Controls.Add(Me.txtDfltToEmailAddr)
        Me.grpDefaults.Controls.Add(Me.Label4)
        Me.grpDefaults.Location = New System.Drawing.Point(12, 148)
        Me.grpDefaults.Name = "grpDefaults"
        Me.grpDefaults.Size = New System.Drawing.Size(460, 103)
        Me.grpDefaults.TabIndex = 2
        Me.grpDefaults.TabStop = False
        Me.grpDefaults.Text = "Defaults"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Default Scripts Folder"
        '
        'txtDefaultFolderToCompare
        '
        Me.txtDefaultFolderToCompare.Location = New System.Drawing.Point(127, 46)
        Me.txtDefaultFolderToCompare.Name = "txtDefaultFolderToCompare"
        Me.txtDefaultFolderToCompare.ReadOnly = True
        Me.txtDefaultFolderToCompare.Size = New System.Drawing.Size(290, 20)
        Me.txtDefaultFolderToCompare.TabIndex = 2
        '
        'txtDfltToEmailAddr
        '
        Me.txtDfltToEmailAddr.Location = New System.Drawing.Point(127, 20)
        Me.txtDfltToEmailAddr.MaxLength = 100
        Me.txtDfltToEmailAddr.Name = "txtDfltToEmailAddr"
        Me.txtDfltToEmailAddr.Size = New System.Drawing.Size(290, 20)
        Me.txtDfltToEmailAddr.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Default Send To Email"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSave, Me.miSaveAndClose})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(485, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'miSave
        '
        Me.miSave.Image = CType(resources.GetObject("miSave.Image"), System.Drawing.Image)
        Me.miSave.Name = "miSave"
        Me.miSave.Size = New System.Drawing.Size(59, 20)
        Me.miSave.Text = "&Save"
        '
        'miSaveAndClose
        '
        Me.miSaveAndClose.Image = CType(resources.GetObject("miSaveAndClose.Image"), System.Drawing.Image)
        Me.miSaveAndClose.Name = "miSaveAndClose"
        Me.miSaveAndClose.Size = New System.Drawing.Size(110, 20)
        Me.miSaveAndClose.Text = "Save And &Close"
        '
        'frmAppSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 263)
        Me.Controls.Add(Me.grpDefaults)
        Me.Controls.Add(Me.grpContactInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAppSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Application Settings"
        Me.grpContactInfo.ResumeLayout(False)
        Me.grpContactInfo.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDefaults.ResumeLayout(False)
        Me.grpDefaults.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpContactInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFromEmailAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpDefaults As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDfltToEmailAddr As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents miSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSaveAndClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDefaultFolderToCompare As System.Windows.Forms.TextBox
End Class
