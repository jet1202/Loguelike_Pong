Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Experiment.TcpSocket

Public Class Form1
    Const port As Integer = 20000 ' ポート番号
    Dim enc As System.Text.Encoding = System.Text.Encoding.Default ' 文字コードに「Shift-JIS」を指定

    Private Sub TcpSockets1_Accept(ByVal sender As System.Object, ByVal e As Experiment.TcpSocket.AcceptEventArgs) Handles TcpSockets1.Accept

    End Sub

    Private Sub TcpSockets1_Connect(ByVal sender As System.Object, ByVal e As Experiment.TcpSocket.ConnectEventArgs) Handles TcpSockets1.Connect

    End Sub

    Private Sub TcpSockets1_Disconnect(ByVal sender As System.Object, ByVal e As Experiment.TcpSocket.DisconnectEventArgs) Handles TcpSockets1.Disconnect

    End Sub

    Private Sub TcpSockets1_DataReceive(sender As Object, e As DataReceiveEventArgs) Handles TcpSockets1.DataReceive

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
