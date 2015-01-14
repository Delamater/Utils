'Author:        Bob Delamater
'Date:          05/23/2010
'Description:   This class is designed to format any DataGridView
'               to a standard look.
'Dependencies:  This class requires the constants.vb class


Option Explicit On
Option Strict On

Public Class GridManager

    Private constants As New constants()


    ''' <summary>
    ''' Provided a DataGridView, this method will format that grid 
    ''' to the standard look
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Public Sub FormatGrid(ByVal dgv As DataGridView)

        'Color code all the rows in the grid
        For Each dgvr As DataGridViewRow In dgv.Rows
            'Set the row state to the appropriate color
            Select Case dgv.Rows(dgvr.Index).Cells("myRowState").Value.ToString()
                Case DataRowState.Added.ToString()
                    dgv.Rows(dgvr.Index).Cells("myRowState").Style.BackColor = _
                        constants.rowstateAdded
                Case DataRowState.Deleted.ToString()
                    dgv.Rows(dgvr.Index).Cells("myRowState").Style.BackColor = _
                        constants.rowStateDeleted

                Case DataRowState.Modified.ToString()
                    dgv.Rows(dgvr.Index).Cells("myRowState").Style.BackColor = _
                        constants.rowStateModified

                Case DataRowState.Unchanged.ToString()
                    'Do nothing
                    'dgv.Rows(dgvr.Index).Cells("myRowState").Style.BackColor = _
                    '    constants.rowStateUnchanged
                Case Else
                    'Do nothing

            End Select

        Next

        'Lock grid
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AlternatingRowsDefaultCellStyle.BackColor = constants.AlternatingRowBackColor


        'Set style for column headers
        dgv.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        dgv.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.EnableResizing


        'Set header text
        If dgv.RowCount > 0 Then
            dgv.Columns("CreationTimeUtc").HeaderText = "Creation Time UTC"
            dgv.Columns("FullName").HeaderText = "Full Name"
            dgv.Columns("LastAccessTimeUtc").HeaderText = "Last Access Time UTC"
            dgv.Columns("myRowState").HeaderText = "Row State"
            dgv.Columns("Name").HeaderText = "File Name"
            dgv.Columns("CRCValue").HeaderText = "Checksum Value"
        End If


        For Each col As DataGridViewColumn In dgv.Columns
            'If col.HeaderText = "Full Name" Then
            '    col.Width = 300
            'ElseIf col.HeaderText = "File Name" Then
            '    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'Else
            '    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            'End If
            col.Resizable = DataGridViewTriState.True
        Next

        'Allow grid columns to be resized
        dgv.AllowUserToResizeColumns = True

    End Sub

End Class
