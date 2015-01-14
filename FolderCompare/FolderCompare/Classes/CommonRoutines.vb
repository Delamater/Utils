Option Explicit On
Option Strict On

Imports System.Text
Imports System.Text.RegularExpressions

Public Class CommonRoutines

    ''' <summary>
    ''' Displays a common messagesbox. If the message box icon is a type of 
    ''' error, then a stack trace will be included in the message box. 
    ''' </summary>
    ''' <param name="ex">Provide a reference to the exception object</param>
    ''' <param name="icon">Set the MessageBoxIcon type</param>
    ''' <param name="buttons">Set the MessageBoxButton</param>
    ''' <remarks></remarks>
    Public Sub ShowMessageBox(ByVal ex As Exception, _
                              ByVal icon As MessageBoxIcon, _
                              ByVal buttons As MessageBoxButtons)

        Dim strErrMsg As New StringBuilder()

        Select Case icon
            Case MessageBoxIcon.Error, MessageBoxIcon.Exclamation, _
                MessageBoxIcon.Stop, MessageBoxIcon.Hand

                'strErrMsg.AppendLine(ex.GetType().UnderlyingSystemType.FullName.ToString())
                'strErrMsg.AppendLine()


                'strErrMsg.AppendLine()
                'strErrMsg.AppendLine(ex.StackTrace)

         
        End Select

        strErrMsg.AppendLine(ex.Message)

        MessageBox.Show(strErrMsg.ToString(), _
                        My.Application.Info.ProductName, _
                        MessageBoxButtons.OK, _
                        icon)


    End Sub

    ''' <summary>
    ''' Displays a common messagesbox. If the message box icon is a type of 
    ''' error, then a stack trace will be included in the message box. 
    ''' </summary>
    ''' <param name="strMessage">Provide a string message</param>
    ''' <param name="icon">Set the MessageBoxIcon type</param>
    ''' <param name="buttons">Set the MessageBoxButton</param>
    ''' <remarks></remarks>
    Public Sub ShowMessageBox(ByVal strMessage As String, _
                              ByVal icon As MessageBoxIcon, _
                              ByVal buttons As MessageBoxButtons)

        Dim strErrMsg As New StringBuilder()
        strErrMsg.AppendLine(strMessage)

        Select Case icon
            Case MessageBoxIcon.Error, MessageBoxIcon.Exclamation, _
                MessageBoxIcon.Stop, MessageBoxIcon.Hand

                'strErrMsg.AppendLine(ex.GetType().UnderlyingSystemType.FullName.ToString())
                'strErrMsg.AppendLine()


                'strErrMsg.AppendLine()
                'strErrMsg.AppendLine(ex.StackTrace)
        End Select

        MessageBox.Show(strErrMsg.ToString(), _
                        My.Application.Info.ProductName, _
                        MessageBoxButtons.OK, _
                        icon)

    End Sub

    Public Sub LogError(ByVal strMessage As String, ByVal icon As MessageBoxIcon, Optional ByVal ex As Exception = Nothing)

        Dim evt As EventLog = New EventLog("Application", My.Computer.Name, "Application")

        Select Case icon
            Case MessageBoxIcon.Error
                evt.WriteEntry(strMessage, EventLogEntryType.Error)

                evt.WriteEntry(ex.Message _
                   & Environment.NewLine _
                   & Environment.NewLine _
                   & ex.StackTrace, EventLogEntryType.Error)

            Case MessageBoxIcon.Information
                evt.WriteEntry(strMessage, EventLogEntryType.Information)
            Case Else
                evt.WriteEntry(strMessage, EventLogEntryType.Information)
        End Select
    End Sub

    Public Class ValidationManager
        Public Function ValidateEmailAddress(ByVal strEmail As String) As Boolean
            Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]" & _
                "*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

            Dim emailAddressMatch As Match = Regex.Match(strEmail, pattern)


            If emailAddressMatch.Success Then
                Return True

            Else
                Return False
            End If

        End Function

        Public Function ValidateEmailOkToSend(ByVal strFromEmail As String, ByVal strToEmail As String) As Constants.EmailValidation

            'Only validating the from and to email address. 
            'First and last name defined in the settings are not validated 
            Dim blnEmailOkToSend As Boolean = False

            'Invalid From Email Address
            If ValidateEmailAddress(strFromEmail) = False Then

                Return Constants.EmailValidation.InvalidFromAddress
            End If

            'Invalid To Email Address
            If ValidateEmailAddress(strToEmail) = False Then

                Return Constants.EmailValidation.InvalidToAddress
            End If


            'We've reached this far, so ok to attemp sending the email
            blnEmailOkToSend = True
            Return Constants.EmailValidation.EmailIsValid

        End Function
    End Class
End Class
