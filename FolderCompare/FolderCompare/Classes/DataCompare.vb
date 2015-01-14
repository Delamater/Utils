'Author:        Bob Delamater
'Date:          05/23/2010

Option Explicit On
Option Strict On


''' <summary>
''' The DataCOmpre class is responsible for taking two data tables 
''' and comparing them against one another. The approach taken 
''' is to loop twice, once through the DataTableToCompare and the 
''' next loop is through the BaseDataTable
''' </summary>
''' <remarks></remarks>
Public Class DataCompare

    ''' <summary>
    ''' Compare two data tables, returning a comparison output. Each row will
    ''' eventually be provided a designation of added, modified, unchanged or deleted
    ''' </summary>
    ''' <param name="baseDataTable">The base map, or otherwise known as the defacto standard to compare to</param>
    ''' <param name="DataTableToCompare">The destination map to compare against the base map</param>
    ''' <returns>myFileInfo table</returns>
    ''' <remarks></remarks>
    Public Function CompareDataSet(ByVal baseDataTable As myFileInfo.FileInfoDataTable, _
                                   ByVal DataTableToCompare As myFileInfo.FileInfoDataTable) _
                                   As myFileInfo.FileInfoDataTable

        'Output table to store records in
        Dim dtComparisonOutput As New myFileInfo.FileInfoDataTable()

        'Loop through the destination data table
        'If the CRCValue is different, mark it as modified
        'If the CRCValue is the same, mark it as unchanged

        'If the base data table, when searched by the key (FullName), does not find a value
        ' then mark the row as added. This represents any file added that the base data table
        ' does not have a record for, and there for is new to the 
        'destination (or DataTableToCompareTo) table
        For Each dr As DataRow In DataTableToCompare.Rows
            'Dim strFullName As String = dr("FullName").ToString()
            'Dim strCRCValueOfDestination As String = dr("CRCValue").ToString()

            Dim baseDr As myFileInfo.FileInfoRow
            baseDr = baseDataTable.FindByFullName(dr("FullName").ToString())

            If baseDr Is Nothing Then
                dr("myRowState") = DataRowState.Added.ToString()

                'Add the row to the output
                dtComparisonOutput.ImportRow(dr)

                'Terminate the for loop and move on, 
                'we have reached an assesment for this file
            Else

                'If the file was found, the compare the checksum values
                Select Case dr("CRCValue").ToString().ToUpper() <> baseDr("CRCValue").ToString().ToUpper()
                    Case True
                        dr("myRowState") = DataRowState.Modified.ToString()
                    Case False
                        dr("myRowState") = DataRowState.Unchanged.ToString()
                End Select

                'Add the row to the output
                dtComparisonOutput.ImportRow(dr)

            End If


        Next


        'Finally, loop through each row in the base data table.
        ' Search the destination data table by key (FullName) for a reference.
        ' If there is no reference, then mark the output data table row as deleted
        For Each dr As DataRow In baseDataTable
            Dim destDR As myFileInfo.FileInfoRow
            destDR = DataTableToCompare.FindByFullName(dr("FullName").ToString())

            If destDR Is Nothing Then
                dr("myRowState") = DataRowState.Deleted.ToString()
                dtComparisonOutput.ImportRow(dr)
            End If
        Next


        Return dtComparisonOutput


    End Function

End Class
