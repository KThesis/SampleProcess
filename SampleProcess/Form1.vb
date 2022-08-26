Imports System.Runtime.InteropServices

Public Class Form1

    Dim recording As Boolean = False
    Dim ply As Boolean = False
    Dim Filez As String = "D:\\Recording.wav"

    <DllImport("winmm.dll")>
    Private Shared Function mciSendString(ByVal command As String, ByVal buffer As String, ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'For recording voice'
        If recording = False Then
            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
            mciSendString("record recsound", "", 0, 0)
            recording = True
            Button1.Text = "Stop"
        Else
            mciSendString("save recsound " & Filez, "", 0, 0)
            mciSendString("close recsound ", "", 0, 0)
            Button2.Enabled = True
            recording = False
            Button1.Text = "Record"
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'for playing the recorded voice'
        My.Computer.Audio.Play(Filez)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'tried to import music'
        If ply = False Then
            My.Computer.Audio.Play(My.Resources.oh, AudioPlayMode.Background)
            ply = True
            Button2.Text = "Stop"
        Else
            My.Computer.Audio.Stop()
            Button2.Text = "Play"
        End If
    End Sub
End Class
