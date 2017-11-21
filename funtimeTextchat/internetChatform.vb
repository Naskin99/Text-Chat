﻿Imports System.IO
Public Class internetChatform
    Friend nickname As String
    'nickname passes successfully
    Private Sub internetChatform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        send.Enabled = False
        leave.Enabled = False
        RichTextBox1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles join.Click 'JOIN
        If (ftpModule.download(Application.StartupPath + "/InternetRooms/", "ftp://" + internetValidation.IP_Address, TextBox1.Text + ".txt", internetValidation.username, internetValidation.password)) Then
            MainFunctions_NoReturns.joinInternet()
            'MsgBox("Exists") 'DEBUGGING
            File.Delete(Application.StartupPath + "/InternetRooms/" + TextBox1.Text + ".txt")
            send.Enabled = True
            leave.Enabled = True
            RichTextBox1.Enabled = True
        Else 'doesn't exist
            ftpModule.create(Application.StartupPath + "/InternetRooms", internetValidation.IP_Address, TextBox1.Text, internetValidation.username, internetValidation.password)
            MsgBox("Room Created") 'DEBUGGING
            MainFunctions_NoReturns.joinInternet()
            send.Enabled = True
            leave.Enabled = True
            RichTextBox1.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles leave.Click 'LEAVE
        Me.Updater.Enabled = False
    End Sub

    Private Sub Updater_Tick(sender As Object, e As EventArgs) Handles Updater.Tick

        If (ftpModule.checkForUpdate(Application.StartupPath + "/InternetRooms/", "ftp://" + internetValidation.IP_Address, TextBox1.Text + ".txt", internetValidation.username, internetValidation.password) = True) Then
            ftpModule.refresh()
            MsgBox("Difference!")
        End If

    End Sub

    Private Sub send_Click(sender As Object, e As EventArgs) Handles send.Click

    End Sub
End Class