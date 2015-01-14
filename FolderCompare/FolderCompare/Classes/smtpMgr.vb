Option Explicit On
Option Strict On

Imports System.Net.Mail
Imports System.IO
Imports System.IO.Compression

Public Class smtpMgr

    Public ReadOnly Property SMTPServerName() As String
        Get
            Return "smtp.gmail.com"
        End Get
    End Property

    Public ReadOnly Property SMTPUserName() As String
        Get
            Return "mas500.engineer"
        End Get
    End Property

    Public ReadOnly Property SMTPUserPassword() As String
        Get
            Return "m1ssupport$"
        End Get
    End Property

    Public ReadOnly Property SMTPServerPort() As Integer
        Get
            Return 587
        End Get
    End Property

    Public ReadOnly Property EmailBodyDefault(ByVal intCaseNumber As Long, ByVal strFromFirstName As String, ByVal strFromLastName As String, ByVal strFromEmail As String) As String
        Get
            Dim sbReturn As New System.Text.StringBuilder()

            Dim strBody As String = _
                String.Format("Please find attached a folder compare file for case #{0}" _
                                 & Environment.NewLine & Environment.NewLine _
                                 & "From: {1} {2}" _
                                 & Environment.NewLine & "Email: {3}", _
                                    intCaseNumber.ToString(), _
                                    strFromFirstName, _
                                    strFromLastName, _
                                    strFromEmail)

            sbReturn.Append(strBody)
            sbReturn.Append(Environment.NewLine & Environment.NewLine)
            sbReturn.Append("Windows User: " & My.User.Name & Environment.NewLine)
            sbReturn.Append("Windows Machine: " & My.Computer.Name & Environment.NewLine)

            Return sbReturn.ToString()

        End Get
    End Property

    Public ReadOnly Property EmailSubjectDefault(ByVal intCaseNumber As Long) As String
        Get
            Return String.Format("Folder Scan / Case #{0}", _
                                 intCaseNumber.ToString())
        End Get
    End Property

    Public Sub SendMail(ByVal [From] As String, ByVal [To] As String, _
                            ByVal Subject As String, ByVal Body As String, ByVal MailServer _
                            As String, Optional ByVal IsBodyHtml As Boolean = True, _
                            Optional ByVal MailPort As Integer = 587, _
                            Optional ByVal Attachments() As String = Nothing, Optional _
                            ByVal AuthUsername As String = Nothing, Optional ByVal _
                            AuthPassword As String = Nothing)

        Try
            Dim MailClient As System.Net.Mail.SmtpClient = _
                New System.Net.Mail.SmtpClient(MailServer, MailPort)
            MailClient.EnableSsl = True

            'create a MailMessage object to represent an e-mail message
            Dim MailMessage = New System.Net.Mail.MailMessage( _
                [From], [To], Subject, Body)

            'set a value indicating whether the mail message body is in Html.
            MailMessage.IsBodyHtml = IsBodyHtml
            ''sets the credentials used to authenticate the sender

            If (AuthUsername IsNot Nothing) AndAlso (AuthPassword _
                                                     IsNot Nothing) Then
                MailClient.Credentials = New  _
                System.Net.NetworkCredential(AuthUsername, AuthPassword)
            End If

            'add the files as the attachments for the mailmessage object
            If (Attachments IsNot Nothing) Then
                For Each FileName In Attachments
                    MailMessage.Attachments.Add( _
                    New System.Net.Mail.Attachment(FileName))
                Next
            End If
            My.Application.DoEvents()
            MailClient.Send(MailMessage)
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Public Sub SendQueryResults(ByVal ds As DataSet, ByVal intCaseNumber As Long)
        Try
            Dim fileMgr As New FileMgr()

            'Write temporary file to email
            Dim strTempUncompressedFile() As String = New String(0) {}
            Dim strTempCompressedFile() As String = New String(0) {}
            strTempUncompressedFile(0) = Path.GetTempFileName()
            strTempUncompressedFile(0) = Path.ChangeExtension(strTempUncompressedFile(0), "xml")

            'Write the xml out, just in case. 
            'Support can use this in the event that the compression fails
            ds.WriteXml(strTempUncompressedFile(0), XmlWriteMode.WriteSchema)

            Dim fi As New FileInfo(strTempUncompressedFile(0))
            Dim strCompressedFileName As String = ""
            fileMgr.CompressFile(fi, strTempCompressedFile(0))

            SendMail( _
                My.Settings.DefaultFromEmail.Trim(), _
                My.Settings.DefaultToEmail.Trim(), _
                Me.EmailSubjectDefault(intCaseNumber), _
                Me.EmailBodyDefault(intCaseNumber, _
                                    My.Settings.FirstName.Trim(), _
                                    My.Settings.LastName.Trim(), _
                                    My.Settings.DefaultFromEmail.Trim()), _
                Me.SMTPServerName, _
                False, _
                Me.SMTPServerPort, _
                strTempCompressedFile, _
                Me.SMTPUserName, _
                Me.SMTPUserPassword)
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

End Class
