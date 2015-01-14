'Author:        Bob Delamater
'Date:          05/23/2010
'Description:   This class returns back a StringBuilder object given 
'               the path to a specific file

Option Explicit On
Option Strict On

Imports System.Text
Imports System.IO

Public Class FileReader

    Public Function GetFlatFileContents(ByVal strFilePath As String) As StringBuilder

        Dim sr As New StreamReader(strFilePath)
        Dim sb As New StringBuilder()

        sb.Append(sr.ReadToEnd())

        Return sb

    End Function

End Class
