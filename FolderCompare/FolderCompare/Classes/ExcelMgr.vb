Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel


''' <summary>
''' Export to Excel capabilities. 
''' This class should be replaced by a better version. 
''' This is a test class, and probably should not be 
''' included in the final version of this tool.
''' </summary>
''' <remarks></remarks>
Public Class ExcelMgr


    ''' <summary>
    ''' Given a DataGridView, and a file path, 
    ''' this routine will export the contents of the grid to an Excel worksheet
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="strFilePath"></param>
    ''' <remarks></remarks>
    Public Sub ExportToExcel(ByVal dgv As DataGridView, ByVal strFilePath As String)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.Application()
        xlWorkBook = CType(xlApp.Workbooks.Add(misValue), Workbook)
        xlWorkSheet = CType(xlWorkBook.Sheets("Sheet1"), Worksheet)

        For i = 0 To dgv.Columns.Count - 1
            xlWorkSheet.Cells(1, i + 1) = dgv.Columns(i).HeaderText.ToString()
        Next


        For i = 1 To dgv.RowCount - 2
            For j = 0 To dgv.ColumnCount - 1
                xlWorkSheet.Cells(i + 1, j + 1) = dgv(j, i).Value.ToString()
            Next
        Next

        xlWorkSheet.SaveAs(strFilePath)
        xlWorkBook.Close()
        xlApp.Quit()

        ReleaseObject(xlApp)
        ReleaseObject(xlWorkBook)
        ReleaseObject(xlWorkSheet)

    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class
