'Author:        Bob Delamater
'Date:          05/23/2010
'Description:   This class is not implemented yet. Ultimately, 
'               class will detect the MAS 500 installation folder.
'Dependencies:  This class requires the XmlReader.vb class


Option Explicit On
Option Strict On


Imports System.IO
Imports System.Text

Public Class Mas500InstallationMgr

#Region "Properties"
    Public ReadOnly Property Mas500InstalledDirectory() As DirectoryInfo
        Get

            Dim di As New DirectoryInfo(GetMas500InstallationFolder())
            Return di
        End Get
    End Property

#End Region

    Private Function GetMas500InstallationFolder() As String

        Dim xmlRdr As New myXmlReader()
        Return xmlRdr.GetXmlValue(constants.kAllUserConfigFileLocation, "LocalPath")


    End Function

End Class
