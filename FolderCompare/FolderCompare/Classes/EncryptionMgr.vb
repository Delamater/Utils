'Author:        Bob Delamater
'Date:          05/23/2010
'Description:   The EncryptionMgr is responsible for building a unique 
'               checksum value for each file provided. The checksum
'               value is returned as a string. You may provide either 
'               a single file or an array of files within a 
'               HybridDictionary

Option Strict On
Option Explicit On

Imports System.Security
Imports System.Security.Cryptography
Imports System.Collections.Specialized
Imports System.Text
Imports System.IO


Public Class EncryptionMgr

    ''' <summary>
    ''' Provided a file, this routine will return a checksum string
    ''' </summary>
    ''' <param name="myFile"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Function GetChecksumSha25(ByVal myFile As FileInfo) As String

        'If FileAcess.Read is not used, then files locked by the operating system will
        'generate an error
        Dim file As FileStream = New FileStream(myFile.FullName, FileMode.Open, FileAccess.Read)
        Dim sha As New SHA256Managed()
        Dim checksum As Byte() = sha.ComputeHash(file)
        file.Close()
        Return BitConverter.ToString(checksum).Replace("-", String.Empty)

    End Function

    Public Function GetMD5HashFromFile(ByVal myFile As FileInfo) As String

        'If fileAccess.Read is not used, then files locked 
        'by the operating system will generate an error
        Dim file As FileStream = New FileStream(myFile.FullName, FileMode.Open, FileAccess.Read)
        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim checksum As Byte() = md5.ComputeHash(file)
        file.Close()
        Return BitConverter.ToString(checksum).Replace("-", String.Empty)

        'Dim enc As New ASCIIEncoding()
        'Return enc.GetString(retVal).ToString()

    End Function

    ''' <summary>
    ''' Provided an array of files within a HybridDictionary, this 
    ''' routine will return one string for all the files combined
    ''' </summary>
    ''' <param name="myArray"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Function GetChecksumSha25(ByVal myArray As HybridDictionary) As String
        Dim sb As New StringBuilder
        Dim sha As New SHA256Managed()
        Dim bytes As Byte()
        Dim uniCoding As New UnicodeEncoding()


        For Each item In myArray.Values
            sb.AppendLine(item.ToString())
        Next

        bytes = uniCoding.GetBytes(sb.ToString())
        Dim ms As New MemoryStream()

        ms.Write(bytes, 0, bytes.Length)
        Dim checksum As Byte() = sha.ComputeHash(ms)

        Return BitConverter.ToString(checksum).Replace("-", String.Empty)

    End Function

    ''' <summary>
    ''' Provided some string, this routine will return back an encrypted version
    ''' of that string
    ''' </summary>
    ''' <param name="strToEncrypt"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Function GetChecksumSha25(ByVal strToEncrypt As String) As String
        Dim sha As New SHA256Managed()
        Dim bytes As Byte()
        Dim uniCoding As New UnicodeEncoding()

        bytes = uniCoding.GetBytes(strToEncrypt)
        Return BitConverter.ToString(bytes, 0, bytes.Length).Replace("-", String.Empty)

    End Function

End Class
