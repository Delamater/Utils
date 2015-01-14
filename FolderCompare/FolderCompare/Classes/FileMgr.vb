Option Explicit On
Option Strict On

Imports System.IO
Imports System.Data
Imports Accounting.Application.CS.myFileInfo
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO.Compression


''' <summary>
''' The file manager contains members not fully implemented at the release
''' of this tool
''' </summary>
''' <remarks></remarks>
Public Class FileMgr

    Dim mEnc As New EncryptionMgr()
    Dim appConfig As New Accounting.Framework.AppConfig()

    Public Enum enumFileType
        LegacyExcel = 1
        Excel = 2
        CSV = 3
        XML = 4
        Xml_ccf = 5
    End Enum


#Region "Methods"

    Public Function GetFiles(ByVal strComparisonFolderPath As String) As myFileInfo.FileInfoDataTable
        Dim dsFileInfo As New myFileInfo.FileInfoDataTable()

        ProcessDirectory(strComparisonFolderPath, _
                         10, _
                         dsFileInfo)

        Return dsFileInfo

    End Function

    Private Sub ProcessDirectory(ByVal sourceDir As String, _
                                  ByVal recursionLevel As Integer, _
                                  ByRef dt As myFileInfo.FileInfoDataTable)

        'Dim fileEntries As String() = Directory.GetFiles(sourceDir)
        Dim di As New DirectoryInfo(sourceDir)

        Try
            'For Each filename As String In fileEntries
            For Each fi As FileInfo In di.GetFiles()
                'Dim f As FileInfo = New FileInfo(filename)
                Dim r As DataRow = dt.NewRow()
                r("FullName") = fi.FullName.ToString()
                r("Extension") = fi.Extension.ToString()
                r("CreationTimeUtc") = fi.CreationTimeUtc.ToShortDateString()
                r("LastAccessTimeUtc") = fi.LastAccessTimeUtc.ToShortDateString()
                r("LastWriteTimeUtc") = fi.LastWriteTimeUtc
                r("Name") = fi.Name.ToString()
                'r("CRCValue") = mEnc.GetMD5HashFromFile(fi)
                r("CRCValue") = mEnc.GetChecksumSha25(fi)
                'r("CRCValue") = "test"
                r("Length") = fi.Length

                dt.Rows.Add(r)
                My.Application.DoEvents()
            Next

            Dim subDirEntries As String() = Directory.GetDirectories(sourceDir)
            For Each subDir As String In subDirEntries

                If (CDbl(File.GetAttributes(subDir) & FileAttributes.ReparsePoint) <> FileAttributes.ReparsePoint) Then
                    ProcessDirectory(subDir, recursionLevel, dt)
                End If

                My.Application.DoEvents()

            Next
        Catch ex As UnauthorizedAccessException

            'Do nothing and allow loop to continue

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Function GetFilePath(ByVal FileType As enumFileType) As String
        Dim ofd As New OpenFileDialog()

        With ofd
            Select Case FileType
                Case enumFileType.CSV
                    .Filter = "CSV Files|*.csv"
                Case enumFileType.LegacyExcel
                    .Filter = "Legacy Excel Files|*.xls"
                Case enumFileType.Excel
                    .Filter = "Excel Files|*.xlsx"
                Case enumFileType.XML
                    .Filter = "Xml Files|*.xml"
                Case enumFileType.Xml_ccf
                    .Filter = _
                        "XML Files(*.xml)|*.xml|Compressed Comparison Files (*" & Constants.kCompressedFileExtension & ")|*" & Constants.kCompressedFileExtension
                Case Else
                    Throw New ApplicationException("This file type is not supported")
            End Select

            .CheckFileExists = False
            .CheckPathExists = True
            .AddExtension = True
            .Multiselect = False

            Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
            .InitialDirectory = di.FullName.ToString()
        End With

        Dim diagResult As DialogResult

        diagResult = ofd.ShowDialog()
        If diagResult = DialogResult.OK Then
            Dim fi As New FileInfo(ofd.FileName)
            Return fi.FullName.ToString()
        Else
            Return String.Empty
        End If

    End Function

    Public Function getSaveDialogFilePath(ByVal fileType As enumFileType, ByVal defaultFileName As String) As String
        Dim sfd As New SaveFileDialog()

        With sfd
            Select Case fileType
                Case enumFileType.CSV
                    .Filter = "CSV Files|*.csv"
                Case enumFileType.LegacyExcel
                    .Filter = "Legacy Excel Files|*.xls"
                Case enumFileType.Excel
                    .Filter = "Excel Files|*.xlsx"
                Case enumFileType.XML
                    .Filter = "Xml Files|*.xml"
                Case enumFileType.Xml_ccf
                    .Filter = _
                        "XML Files(*.xml)|*.xml|Compressed Comparison Files (*" & Constants.kCompressedFileExtension & ")|*" & Constants.kCompressedFileExtension
                Case Else
                    Throw New ApplicationException("This file type is not supported")
            End Select

            .CheckFileExists = False
            .CheckPathExists = True
            .ValidateNames = False
            .OverwritePrompt = True
            .AddExtension = True
            .SupportMultiDottedExtensions = True
            .FileName = defaultFileName

            Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
            .InitialDirectory = di.FullName.ToString()

        End With

        Dim diagResult As DialogResult

        diagResult = sfd.ShowDialog()
        If diagResult = DialogResult.OK Then
            Dim fi As New FileInfo(sfd.FileName)
            Return fi.FullName.ToString()
        Else
            Return String.Empty
        End If

    End Function

    Public Function GetFolderPath() As String
        Dim folderBrowserDialog1 As New FolderBrowserDialog()
        With folderBrowserDialog1
            .RootFolder = Environment.SpecialFolder.MyComputer
            .Description = "Select the folder to build a comparison file"
            .ShowNewFolderButton = False
        End With

        Dim diagResult As DialogResult
        diagResult = folderBrowserDialog1.ShowDialog()
        If diagResult = Windows.Forms.DialogResult.OK Then
            Dim folInfo As New DirectoryInfo(folderBrowserDialog1.SelectedPath)
            Return folInfo.ToString()
        Else
            Return String.Empty
        End If

    End Function

    Public Sub PersistFilesToDisk(ByVal Path As String, ByVal dt As DataTable)

        dt.WriteXml(Path, XmlWriteMode.WriteSchema)

    End Sub

    ''' <summary>
    ''' Exports the contents of a DataGridView to a CSV file 
    ''' </summary>
    ''' <param name="strPath">The location to store the file</param>
    ''' <param name="dgv">A reference to the DataGridView</param>
    ''' <remarks></remarks>
    Public Sub ExportDataTableToCSV(ByVal strPath As String, ByVal dgv As DataGridView)

        Dim sb As New StringBuilder()
        Dim bs As BindingSource
        bs = CType(dgv.DataSource, BindingSource)

        Dim dt As DataTable = CType(bs.DataSource, DataTable)

        'Write out the header column text to the CSV file
        For i = 0 To dgv.Columns.Count - 1
            sb.Append(dgv.Columns(i).HeaderText.ToString())
            If ((i + 1) <> dt.Columns.Count) Then
                sb.Append(",")
            End If
        Next

        sb.Append(Environment.NewLine)

        'Write out each column's value
        For Each dr As DataRowView In dt.DefaultView
            For j As Integer = 0 To dt.Columns.Count - 1
                sb.Append(dr(j).ToString())
                If ((j + 1) <> dt.Columns.Count) Then
                    sb.Append(",")
                End If
            Next
            sb.Append(Environment.NewLine)
        Next

        Dim sw As New StreamWriter(strPath, False)
        sw.Write(sb.ToString())
        sw.Close()

    End Sub

    Public Sub CompressFile(ByVal fi As FileInfo, ByRef strCompressedFileName As String)
        Using inFile As FileStream = fi.OpenRead()

            If (File.GetAttributes(fi.FullName) And FileAttributes.Hidden) <> _
                    FileAttributes.Hidden And fi.Extension <> Constants.kCompressedFileExtension Then

                Using outFile As FileStream = File.Create(fi.FullName + Constants.kCompressedFileExtension)
                    Using Compress As GZipStream = New GZipStream(outFile, CompressionMode.Compress)

                        'Let the caller know the file name
                        strCompressedFileName = outFile.Name

                        'Copy the source file into the compression stream
                        Dim buffer As Byte() = New Byte(4096) {}
                        Dim numRead As Integer
                        numRead = inFile.Read(buffer, 0, buffer.Length)
                        Do While numRead <> 0
                            Compress.Write(buffer, 0, numRead)
                            numRead = inFile.Read(buffer, 0, buffer.Length)
                        Loop
                    End Using

                End Using
            End If

        End Using
    End Sub

    Public Sub Decompress(ByVal fi As FileInfo)
        'Get the stream of the source file
        Using inFile As FileStream = fi.OpenRead()

            'Get original file extension, for example "doc" and from filename.doc.ssi
            Dim curFile As String = fi.FullName
            Dim origName = curFile.Remove(curFile.Length - fi.Extension.Length)

            'Create decompressed file
            Using outfile As FileStream = File.Create(origName)
                Using decompress As GZipStream = New GZipStream(inFile, CompressionMode.Decompress)
                    Dim buffer As Byte() = New Byte(4096) {}
                    Dim numRead As Integer
                    numRead = decompress.Read(buffer, 0, buffer.Length)
                    Do While numRead <> 0
                        outfile.Write(buffer, 0, numRead)
                        numRead = decompress.Read(buffer, 0, buffer.Length)
                    Loop
                End Using

            End Using

        End Using
    End Sub

    Public Function IsDirectoryValid(ByVal strDirectory As String) As Boolean
        'Is the path to store the file valid?
        If Not Directory.Exists(strDirectory) Then
            Return False
        End If

        Return True
    End Function

#End Region


End Class
