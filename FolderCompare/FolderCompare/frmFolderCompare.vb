'Author:        Bob Delamater
'Date:          05/23/2010
'Description:   GUI for the Folder Compare application. This folder compare tool is designed to 
'               help anyone quickly scan two folders and compare the differences. 

Option Strict On
Option Explicit On

Imports System.IO
Imports System.Random

Public Class frmProgramCompare

    Private comRoutines As New CommonRoutines()
    Private myBindingSource As New BindingSource()
    Private grdMgr As New GridManager()
    Private fmgr As New FileMgr()
    Private appConfig As New Accounting.Framework.AppConfig()

    Private m_ComparisonFile As String


#Region "Properties"
    Public Property ComparisonFileLocation As String

        Get
            Return m_ComparisonFile
        End Get
        Set(ByVal value As String)
            m_ComparisonFile = value
        End Set
    End Property

#End Region

#Region "Menu Item Methods"

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim frmAppSettings As New frmAppSettings()
        frmAppSettings.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        CloseApplication()
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click

        ExportToExcel()

    End Sub

    Private Sub ExportToCSVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToCSVToolStripMenuItem.Click

        ExportToCSV()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim About As New frmAbout
            About.ShowDialog()
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, _
                                       MessageBoxIcon.Error, _
                                       MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub MyCompareHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            System.Diagnostics.Process.Start("..\..\Help\MASSupportTools.chm")
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, _
                                       MessageBoxIcon.Error, _
                                       MessageBoxButtons.OK)
        End Try
    End Sub
#End Region

#Region "Methods"

    Private Sub CloseApplication()

        Me.Close()

    End Sub

    ''' <summary>
    ''' Populates all combo boxes with default values
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateComboBoxes()
        Dim ComboBoxChoices() As String = _
            New String() {"All", _
                DataRowState.Added.ToString(), _
                DataRowState.Deleted.ToString(), _
                DataRowState.Modified.ToString(), _
                DataRowState.Unchanged.ToString()}

        cboViewSettings.Items.AddRange(ComboBoxChoices)
        cboViewSettings.SelectedIndex = 0
    End Sub


    ''' <summary>
    ''' Creates a source file in a specified location, as defined by the file manager class, 
    ''' if there is a location set in the txtComparisonFolderPath textbox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateSourceFile()
        'Choose the location from where to build the file

        Dim strFilePathToCompare As String = ""
        strFilePathToCompare = txtComparisonFolderPath.Text.ToString()

        'Sanity Check: Does folder path exist?
        If fmgr.IsDirectoryValid(strFilePathToCompare) = False Then
            Throw New ApplicationException( _
                String.Format(Constants.kDirectoryInvalid, _
                  Path.GetDirectoryName(strFilePathToCompare)))
        End If

        'Disable UI
        HandleControlsForCreateSourceFile(False)

        'Dim strPathToStoreFile As String = fmgr.GetFilePath(FileMgr.enumFileType.XML)+

        Dim intRandom As Integer = 0
        Dim rnd As New Random(DateTime.UtcNow.Millisecond)
        intRandom = rnd.Next()

        Dim strPathToStoreFile As String = _
                fmgr.getSaveDialogFilePath(FileMgr.enumFileType.XML, _
                    String.Format(Constants.kDefaultFileComparisonFileName, _
                                  intRandom.ToString(), _
                                  String.Empty))

        Try

            If Not (String.IsNullOrEmpty(strFilePathToCompare)) Then
                If Not (String.IsNullOrEmpty(strPathToStoreFile)) Then

                    'Turn on the progress bar
                    HandleProgressBar(True, Constants.kScanningSelectedFolder)

                    My.Application.DoEvents()

                    'Get the file list for comparison
                    Dim fmgr As New FileMgr()
                    Dim dt As New myFileInfo.FileInfoDataTable()
                    dt = fmgr.GetFiles(strFilePathToCompare)
                    txtDestinationFile.Text = (strPathToStoreFile)
                    fmgr.PersistFilesToDisk(strPathToStoreFile, dt)

                    Me.ComparisonFileLocation = strPathToStoreFile

                    'Create a compressed version of this file, in case 
                    'the user will want to later email
                    Dim fi As New FileInfo(Me.ComparisonFileLocation)
                    fmgr.CompressFile(fi, Me.ComparisonFileLocation)
                    HandleProgressBar(False, "")
                Else
                    ' Do nothing
                    'Throw New ApplicationException _
                    '    ("Please choose a path to store your folder comparison file")
                End If
            Else
                HandleProgressBar(False, "")
                Throw New ApplicationException("Please choose a path from which to compare")

            End If
        Catch ex As ApplicationException
            HandleProgressBar(False, "")
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Information, MessageBoxButtons.OK)
        Catch ex As Exception
            HandleProgressBar(False, "")
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try

        'Shutdown progress bar
        HandleProgressBar(False, "")

        'Enable UI
        HandleControlsForCreateSourceFile(True)

    End Sub

    ''' <summary>
    ''' If there are two files set for comparison, this routine will compare 
    ''' the output and store it within the datagridview
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CompareSourceFiles()

        Dim dtBase As New myFileInfo.FileInfoDataTable()
        Dim dtDestination As New myFileInfo.FileInfoDataTable()
        Dim dtOutput As New myFileInfo.FileInfoDataTable()

        Dim strBaseFile As String = ""
        Dim strDestinationFile As String = ""


        Try

            Dim fiBase As New FileInfo(txtBaseFile.Text)
            Dim fiDestination As New FileInfo(txtDestinationFile.Text)

            'Sanity Check: Do the files exist?
            If Not File.Exists(fiBase.FullName) Then
                comRoutines.ShowMessageBox(Constants.kBaseFileLocationIncorrect, _
                                           MessageBoxIcon.Information, _
                                           MessageBoxButtons.OK)

                Exit Sub
            End If

            If Not File.Exists(fiDestination.FullName) Then
                comRoutines.ShowMessageBox(Constants.kDestinationFileLocationIncorrect, _
                                           MessageBoxIcon.Information, _
                                           MessageBoxButtons.OK)
                Exit Sub
            End If

            strBaseFile = DecompressFilesIfNeeded(fiBase)
            strDestinationFile = DecompressFilesIfNeeded(fiDestination)

            'Sanity Check: Are there two files to compare?
            If String.IsNullOrEmpty(strBaseFile) Or _
                String.IsNullOrEmpty(strDestinationFile) Then

                comRoutines.ShowMessageBox(Constants.kRequiredFiles, _
                                           MessageBoxIcon.Information, _
                                           MessageBoxButtons.OK)
                Exit Sub
            End If

            'Sanity Check: Are the schemas on the files correct?
            If (CheckSchemaFiles(strBaseFile, strDestinationFile) = False) Then

                comRoutines.ShowMessageBox( _
                        Constants.kSchemaIsNotCorrect, _
                        MessageBoxIcon.Error, _
                        MessageBoxButtons.OK)

                Exit Sub
            End If

            dtBase.ReadXml(strBaseFile)
            dtDestination.ReadXml(strDestinationFile)


            Dim dc As New DataCompare()
            HandleProgressBar(True, Constants.kComparingFilesNow)
            dtOutput = dc.CompareDataSet(dtBase, dtDestination)

            BindGrid(dtOutput)


        Catch ex As Exception
            HandleProgressBar(False, "")
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try

        HandleProgressBar(False, "")
        grdMgr.FormatGrid(dgvComparison)

    End Sub


    ''' <summary>
    ''' Decrompresses the file, and returns the file name of the new file
    ''' </summary>
    ''' <param name="fi"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DecompressFilesIfNeeded(ByVal fi As FileInfo) As String
        Dim curFile As String = fi.FullName
        Dim origName = curFile.Remove(curFile.Length - fi.Extension.Length)

        If Path.GetExtension(curFile) = Constants.kCompressedFileExtension Then
            fmgr.Decompress(fi)
            Return curFile.Remove(curFile.Length - fi.Extension.Length)
        Else
            'This file is already decompressed, return the same name passed in
            Return fi.FullName
        End If

    End Function

    Private Sub HandleProgressBar(ByVal blnIsVisible As Boolean, ByVal strProgressBarMsg As String)

        With tslblStatusMessage
            .Text = strProgressBarMsg
            .Enabled = blnIsVisible
            .Visible = blnIsVisible
        End With

        With tslStatusGraphic
            .Text = ""
            .Enabled = blnIsVisible
            .Visible = blnIsVisible
        End With

    End Sub

    Private Sub HandleControlsForCreateSourceFile(ByVal blnIsEnabled As Boolean)

        'Tab: tabFileSelection
        For Each ctlinComparisonFile As Control In grpComparisonFile.Controls
            ctlinComparisonFile.Enabled = blnIsEnabled
        Next

        For Each ctlinFileLocations As Control In grpFileLocations.Controls
            ctlinFileLocations.Enabled = blnIsEnabled
        Next

        'Tab: tabInstallCompare
        For Each ctlInPanel1 As Control In Panel1.Controls
            ctlInPanel1.Enabled = blnIsEnabled
        Next

    End Sub


    ''' <summary>
    ''' The files to compare must have the correct XML schema, or the 
    ''' comparison will not work properly. This routing checks those 
    ''' comparison files to ensure they have a valid schema.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSchemaFiles(ByVal strBaseFile As String, ByVal strDestinationFile As String) As Boolean
        Dim xmlRdr As New myXmlReader()
        Dim bAreSchemasCorrect As Boolean = False
        'Dim strSourceFilePath As String = txtBaseFile.Text
        'Dim strDestinationFilePath As String = txtDestinationFile.Text

        If (xmlRdr.ValidateXmlSchema(strBaseFile) = True _
            And xmlRdr.ValidateXmlSchema(strDestinationFile) = True) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Bind the datasource to the grid. This is necessary to allow viewing of the data
    ''' within the grid, as well as filtering of the grid. 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub BindGrid(ByVal dt As myFileInfo.FileInfoDataTable)

        Dim dv As New DataView

        myBindingSource.DataSource = dt
        dgvComparison.DataSource = myBindingSource

    End Sub

    ''' <summary>
    ''' A rudemintary implementation of search capabilities on the grid. 
    ''' This can be enhanced for later versions of this product.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FilterDataGridView()

        Select Case String.IsNullOrEmpty(txtFileNameToSearch.Text.ToString().Trim())
            Case True
                myBindingSource.Filter = ""
            Case False

                If cboViewSettings.Text.ToString().ToUpper() = "All".ToUpper() Then
                    myBindingSource.Filter = "Name LIKE '%" & txtFileNameToSearch.Text.ToString().Trim() & "%'"
                Else
                    myBindingSource.Filter = "Name LIKE '%" & txtFileNameToSearch.Text.ToString().Trim() & "%'" _
                     & " AND myRowState = '" & cboViewSettings.Text & "'"
                End If
        End Select

        dgvComparison.DataSource = myBindingSource
        dgvComparison.Refresh()

    End Sub

    ''' <summary>
    ''' Export the grid, in it's presently filtered state, to an Excel file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExportToExcel()
        Dim oExcel As New ExcelMgr()

        Try
            Dim strFilePath As String = ""
            strFilePath = fmgr.GetFilePath(FileMgr.enumFileType.Excel)

            If Not String.IsNullOrEmpty(strFilePath) Then
                oExcel.ExportToExcel(dgvComparison, strFilePath)

                comRoutines.ShowMessageBox _
                    ("Export to Excel complete", _
                     MessageBoxIcon.Information, _
                     MessageBoxButtons.OK)
            Else
                'Do nothing, and do not export
            End If



        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, _
                                       MessageBoxIcon.Error, _
                                       MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ExportToCSV()
        Try
            fmgr.ExportDataTableToCSV( _
                fmgr.GetFilePath(FileMgr.enumFileType.CSV), _
                dgvComparison)

            comRoutines.ShowMessageBox("Export to CSV complete", _
                                       MessageBoxIcon.Information, _
                                       MessageBoxButtons.OK)
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, _
                                       MessageBoxIcon.Error, _
                                       MessageBoxButtons.OK)
        End Try

    End Sub

    Private Sub HandleUI()
        Dim blnOkToEmail As Boolean = False

        Try
            If Not String.IsNullOrEmpty(Me.ComparisonFileLocation) Then
                If txtCaseNumber.Text.Length > 0 Then

                    Dim intNumResult As Integer
                    Dim parseResult As Boolean = Int32.TryParse(txtCaseNumber.Text, intNumResult)
                    If parseResult = True Then
                        blnOkToEmail = True
                    End If

                End If
            End If

            btnEmailComparisonFile.Enabled = blnOkToEmail

        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try
    End Sub


#End Region

#Region "Events"

    Private Sub frmMas500SupportTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With ToolStripProgressBar1
            .MarqueeAnimationSpeed = 0
            .Visible = CBool(0)
            .Enabled = False
        End With

        PopulateComboBoxes()
        grdMgr.FormatGrid(dgvComparison)


        'Set the default folder if there is one to set
        If Not String.IsNullOrEmpty(My.Settings.DefaultFolderToCompare) Then
            If Directory.Exists(My.Settings.DefaultFolderToCompare) Then
                txtComparisonFolderPath.Text = My.Settings.DefaultFolderToCompare
            End If
        End If

        PopulateDefaults()

    End Sub

    ''' <summary>
    ''' Command to generate the source file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCreateSourceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateSourceFile.Click

        Try
            'Debug.Print("Start time: " & DateTime.Now.ToLocalTime.ToString())
            CreateSourceFile()
            'Debug.Print("End time: " & DateTime.Now.ToLocalTime.ToString())
        Catch ex As ApplicationException
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Information, MessageBoxButtons.OK)
        Catch ex As UnauthorizedAccessException
            comRoutines.LogError(ex.Message, MessageBoxIcon.Error, ex)
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Information, MessageBoxButtons.OK)
        Catch ex As Exception
            comRoutines.LogError(ex.Message, MessageBoxIcon.Error, ex)
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try

    End Sub

    ''' <summary>
    ''' Command to compare the source files
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click

        CompareSourceFiles()

    End Sub


    ''' <summary>
    ''' The user may instruct the program to only view certain types of rows. This filter provides 
    ''' the user basic functionality to show which rows are different, the same, modified, or missing. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboViewSettings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboViewSettings.SelectedIndexChanged

        Select Case cboViewSettings.Text
            Case "All"
                myBindingSource.Filter = ""
            Case DataRowState.Added.ToString()
                myBindingSource.Filter = "myRowState = '" & DataRowState.Added.ToString() & "'"
            Case DataRowState.Deleted.ToString()
                myBindingSource.Filter = "myRowState = '" & DataRowState.Deleted.ToString() & "'"
            Case DataRowState.Modified.ToString()
                myBindingSource.Filter = "myRowState = '" & DataRowState.Modified.ToString() & "'"
            Case DataRowState.Unchanged.ToString()
                myBindingSource.Filter = "myRowState ='" & DataRowState.Unchanged.ToString() & "'"
            Case Else
                myBindingSource.Filter = ""
        End Select

        If Not String.IsNullOrEmpty(txtFileNameToSearch.Text) Then
            If cboViewSettings.Text.ToUpper() <> "All".ToUpper() Then
                myBindingSource.Filter = _
                    myBindingSource.Filter & " AND Name LIKE '%" & txtFileNameToSearch.Text.ToString() & "%'"
            End If

            If cboViewSettings.Text.ToUpper() = "All".ToUpper() Then
                myBindingSource.Filter = _
                    myBindingSource.Filter & " Name LIKE '%" & txtFileNameToSearch.Text.ToString() & "%'"
            End If
        End If

        With dgvComparison
            .DataSource = myBindingSource
            .Refresh()
        End With

        grdMgr.FormatGrid(dgvComparison)
    End Sub

    ''' <summary>
    ''' Retrieves the file to compare to (not intended to be the base file)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGetComparisonFilesList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetComparisonFilesList.Click
        txtDestinationFile.Text = fmgr.GetFilePath(FileMgr.enumFileType.Xml_ccf)
        Me.ComparisonFileLocation = txtDestinationFile.Text
        HandleUI()
        HandleComparisonFileButton()
    End Sub


    ''' <summary>
    ''' Retrieves the file to comapre agains (intended to be the base folder file listing)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGetBaseFileList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBaseFileList.Click
        txtBaseFile.Text = fmgr.GetFilePath(FileMgr.enumFileType.Xml_ccf)
        HandleComparisonFileButton()
    End Sub

    ''' <summary>
    ''' Sets the text value of the destination folder (not the base folder)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSetComparisonFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetComparisonFolder.Click

        Dim strFolderPath As String = ""
        strFolderPath = fmgr.GetFolderPath()
        If Not String.IsNullOrEmpty(strFolderPath) Then
            txtComparisonFolderPath.Text = strFolderPath
        End If

    End Sub

    ''' <summary>
    ''' If the comparison/destination folder has a value witin it, then enable the button to create a source file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtComparisonFolderPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComparisonFolderPath.TextChanged
        If String.IsNullOrEmpty(txtComparisonFolderPath.Text) Then
            btnCreateSourceFile.Enabled = False
        Else
            btnCreateSourceFile.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Instructions to export the contents of the DataGridView to an Excel file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click

        If dgvComparison.RowCount > 0 Then
            ExportToExcel()
        End If

    End Sub


    ''' <summary>
    ''' Show a context menu to export the contents of the DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvComparison_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then

            'Dim hti As DataGridView.HitTestInfo = dgvComparison.HitTest(e.X, e.Y)

            'If hti.Type = DataGridViewHitTestType.Cell Then
            'End If

            ContextMenuStrip1.Show(dgvComparison, New Point(Control.MousePosition.X - 115, Control.MousePosition.Y - 155))

            'ContextMenuStrip1.Location = dgvComparison.PointToScreen(e.Location)
            'ContextMenuStrip1.Location = Control.MousePosition

            'dgvContextMenu.Location = Control.MousePosition
            ContextMenuStrip1.Show()

        End If

    End Sub

    ''' <summary>
    ''' Instructions to filter the grid based on the contents of the search textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtFileNameToSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileNameToSearch.TextChanged

        Try
            FilterDataGridView()
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try
        grdMgr.FormatGrid(dgvComparison)

    End Sub

    Private Sub dgvComparison_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)

        grdMgr.FormatGrid(dgvComparison)

    End Sub


    Private Sub btnEmailComparisonFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmailComparisonFile.Click
        Try

            Dim valMgr As New CommonRoutines.ValidationManager()
            Dim strFromEmail As String = ""
            Dim strToEmail As String = ""

            strFromEmail = My.Settings.DefaultFromEmail
            strToEmail = My.Settings.DefaultToEmail

            Dim intValResponse As Integer = -1
            intValResponse = valMgr.ValidateEmailOkToSend(strFromEmail, strToEmail)

            If intValResponse = Constants.EmailValidation.EmailIsValid Then

                With Me.bwThreadEmailComparisonFile
                    .WorkerReportsProgress = True
                    .RunWorkerAsync()
                End With

            Else
                Select Case intValResponse
                    Case Constants.EmailValidation.InvalidFromAddress
                        comRoutines.ShowMessageBox(Constants.kFromEmailRequired, _
                           MessageBoxIcon.Information, _
                           MessageBoxButtons.OK)

                    Case Constants.EmailValidation.InvalidToAddress
                        comRoutines.ShowMessageBox(Constants.kToEmailRequired, _
                           MessageBoxIcon.Information, _
                           MessageBoxButtons.OK)

                    Case Else
                        comRoutines.ShowMessageBox(Constants.kFromToEmailRequired, _
                           MessageBoxIcon.Information, _
                           MessageBoxButtons.OK)

                End Select
            End If


        Catch ex As UnauthorizedAccessException
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Information, MessageBoxButtons.OK)
        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)

        End Try

    End Sub

    Private Sub EmailComparisonFile()
        Dim smtpMgr As New smtpMgr()

        Dim strTempUncompressedFile() As String = New String(0) {}
        strTempUncompressedFile(0) = Me.ComparisonFileLocation

        'If the file is not compressed, be sure to compress before emailing
        If Path.GetExtension(Me.ComparisonFileLocation) <> Constants.kCompressedFileExtension Then

            Dim strCompressedVersionOfFileMap As String = _
                strTempUncompressedFile(0) & Constants.kCompressedFileExtension

            'Does a compressed version of this file already exist? If so, send it
            If File.Exists(strCompressedVersionOfFileMap) Then
                strTempUncompressedFile(0) = strCompressedVersionOfFileMap
            Else
                'Compress it, then set the file to email as the compressed version
                Dim fi As New FileInfo(Me.ComparisonFileLocation)
                fmgr.CompressFile(fi, Me.ComparisonFileLocation)
                strTempUncompressedFile(0) = strCompressedVersionOfFileMap
            End If
        End If

        If Not String.IsNullOrEmpty(strTempUncompressedFile(0).ToString()) Then
            smtpMgr.SendMail(My.Settings.DefaultFromEmail, _
                             My.Settings.DefaultToEmail, _
                             smtpMgr.EmailSubjectDefault(CInt(txtCaseNumber.Text)), _
                             smtpMgr.EmailBodyDefault( _
                                 CInt(txtCaseNumber.Text), _
                                 My.Settings.FirstName, _
                                 My.Settings.LastName, _
                                 My.Settings.DefaultFromEmail), _
                             smtpMgr.SMTPServerName, _
                             False, _
                             smtpMgr.SMTPServerPort, _
                             strTempUncompressedFile, _
                             smtpMgr.SMTPUserName,
                             smtpMgr.SMTPUserPassword)


            If bwThreadEmailComparisonFile.IsBusy <> True Then
                bwThreadEmailComparisonFile.RunWorkerAsync()
            End If

            comRoutines.ShowMessageBox(Constants.kEmailSuccessfullySent, _
                                       MessageBoxIcon.Information, _
                                       MessageBoxButtons.OK)

        Else

            If bwThreadEmailComparisonFile.IsBusy <> True Then
                bwThreadEmailComparisonFile.RunWorkerAsync()
            End If

            comRoutines.ShowMessageBox(Constants.kFileDoesNotExist, _
                                       MessageBoxIcon.Information, _
                                       MessageBoxButtons.OK)
            Exit Sub

        End If

    End Sub
#End Region

    ''' <summary>
    ''' Cancel the File Name To Search filter criteria
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancelSearchFilterValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelSearchFilterValue.Click
        txtFileNameToSearch.Text = ""
    End Sub

    Private Sub dgvComparison_Sorted(ByVal sender As Object, ByVal e As System.EventArgs)
        grdMgr.FormatGrid(dgvComparison)
    End Sub


    Private Sub txtCaseNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCaseNumber.KeyPress

        'Disallow any non-numeric values from being typed
        Try
            Dim tb As TextBox = DirectCast(sender, TextBox)
            If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then

                e.Handled = True

            End If

        Catch ex As Exception
            comRoutines.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try
    End Sub


    Private Sub txtCaseNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCaseNumber.TextChanged
        HandleUI()
    End Sub


    Private Sub bwThreadEmailComparisonFile_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwThreadEmailComparisonFile.DoWork
        btnEmailComparisonFile.Enabled = False

        HandleProgressBar(True, Constants.kEmailingSupport)
        EmailComparisonFile()
        HandleProgressBar(False, "")

        btnEmailComparisonFile.Enabled = True

    End Sub


    Private Sub HandleComparisonFileButton()
        btnCompare.Enabled = False

        If Not String.IsNullOrEmpty(txtDestinationFile.Text) Then
            If Not String.IsNullOrEmpty(txtBaseFile.Text) Then

                btnCompare.Enabled = True
            Else
                btnCompare.Enabled = False
            End If
        Else
            btnCompare.Enabled = False
        End If

    End Sub

    Private Sub PopulateDefaults()
        If Not String.IsNullOrEmpty(My.Settings.DefaultFolderToCompare) Then
            'We already have a default value
            txtComparisonFolderPath.Text = My.Settings.DefaultFolderToCompare
        Else
            'String is empty, so set a default value where MAS 500 is installed
            My.Settings.DefaultFolderToCompare = appConfig.LocalPath()
            txtComparisonFolderPath.Text = My.Settings.DefaultFolderToCompare
            My.Settings.Save()
        End If
    End Sub

End Class