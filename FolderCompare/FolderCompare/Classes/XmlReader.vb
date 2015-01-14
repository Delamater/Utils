'Author:        Bob Delamater
'Date:          05/23/2010
'Description:   
'Dependencies:  This class requires the constants.vb class

Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO


Public Class myXmlReader

    Dim m_ValidationSuccess As Boolean = False

    Public Function GetXmlValue(ByVal strFilePath As String, ByVal strElementName As String) As String
        If System.IO.File.Exists(strFilePath) Then

            Dim xmlDoc As New Xml.XmlDocument
            xmlDoc.Load(strFilePath)

            Return xmlDoc.DocumentElement("LocalPath").FirstChild.Value

        Else
            Throw New System.IO.FileNotFoundException("File not found", constants.kAllUserConfigFileLocation)
        End If
    End Function

    Public Function ValidateXmlSchema(ByVal strFilePath As String) As Boolean

        'Create the XmlSchemaSet class
        Dim sc As XmlSchemaSet = New XmlSchemaSet()
        Dim schemaFileLocation As String = ""

        'schemaFileLocation = _
        '    Directory.GetParent( _
        '        Directory.GetParent( _
        '            Directory.GetParent(System.Windows.Forms.Application.StartupPath).FullName) _
        '        .FullName). _
        '    FullName & "\datasets\myFileInfo.xsd"

        'schemaFileLocation = Directory.GetParent(System.Windows.Forms.Application.StartupPath).FullName) & "\datasets\myFileInfo.xsd"
        schemaFileLocation = _
            Directory.GetParent(System.Windows.Forms.Application.StartupPath).FullName _
            & "\datasets\myFileInfo.xsd"

        sc.Add("http://tempuri.org/myFileInfo.xsd", schemaFileLocation)

        'Set the validation settings
        Dim settings As XmlReaderSettings = New XmlReaderSettings()
        settings.ValidationType = ValidationType.Schema
        settings.Schemas = sc
        AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack

        'Create the xmlReader Object
        Dim reader As XmlReader = XmlReader.Create(strFilePath, settings)

        'Parse the file
        While reader.Read()
        End While


        m_ValidationSuccess = True
        Return m_ValidationSuccess


    End Function

    Private Sub ValidationCallBack(ByVal Sender As Object, ByVal args As ValidationEventArgs)
        'This validation event will only fire if there is an error
        m_ValidationSuccess = False
    End Sub


End Class
