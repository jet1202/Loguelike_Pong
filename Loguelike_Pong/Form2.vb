Imports System.Reflection
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Experiment.TcpSocket

Public Class Form2
    Const port As Integer = 20000 ' ポート番号
    Dim enc As System.Text.Encoding = System.Text.Encoding.Default ' 文字コードに「Shift-JIS」を指定

    Dim PanelWidth As Integer = 1000
    Dim PanelHeight As Integer = 600

    Dim SCtype As Integer = 0 ' 0:サーバー, 1:クライアント, Form1から受け取る
    Dim PlayerNum As Integer = 0 ' プレイヤー番号(クライアントのみ), Form1から受け取る
    Dim SCtype_str As String = ""

    ' ゲーム内パラメータ
    Structure GameParams
        Dim BallPosX As Double
        Dim BallPosY As Double
        Dim BallVelX As Double ' 速度の単位ベクトル
        Dim BallVelY As Integer
        Dim BallSpeed As Integer
        Dim BallLen As Integer
    End Structure

    Structure PlayerParams
        Dim PaddlePos As Integer
        Dim PaddleSpeed As Integer
        Dim PaddleSize As Integer
    End Structure

    ' 各ラウンド開始時のパラメータ
    Dim roundGameParams As GameParams = New GameParams With {
        .BallPosX = PanelWidth / 2,
        .BallPosY = PanelHeight / 2,
        .BallSpeed = 10,
        .BallLen = 5
    }
    Dim roundPlayer1Params As PlayerParams = New PlayerParams With {
        .PaddlePos = 0,
        .PaddleSpeed = 5,
        .PaddleSize = 50
    }
    Dim roundPlayer2Params As PlayerParams = New PlayerParams With {
        .PaddlePos = 0,
        .PaddleSpeed = 5,
        .PaddleSize = 50
    }

    Dim nowGameParams As GameParams = roundGameParams
    Dim nowPlayer1Params As PlayerParams = roundPlayer1Params
    Dim nowPlayer2Params As PlayerParams = roundPlayer2Params

    ' ゲーム状態
    Enum GameState
        Ready     ' ラウンド開始前、スキル選択
        Playing   ' ラウンド中
        RoundEnd  ' ラウンド終了、得点更新
    End Enum

    ' ゲームの現在の状態
    Private WithEvents gameTimer As New Timer()
    Dim currentState As GameState = GameState.Playing
    Dim player1Score As Integer = 0
    Dim player2Score As Integer = 0

    ' キー入力
    Dim up1Pressed As Boolean = False
    Dim down1Pressed As Boolean = False
    Dim up2Pressed As Boolean = False
    Dim down2Pressed As Boolean = False
    Dim spacePressed As Boolean = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' test用
        TypeCombo_Test.SelectedIndex = 0

        SCtype_str = If(SCtype = 0, "Server", "Client")
        TypeLabel.Text = "Type: " & SCtype_str

        EnableDoubleBuffering(CanvasPanel)
        gameTimer.Interval = 16 ' 約60FPS
        gameTimer.Start()
    End Sub

    ' ゲームループ
    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles gameTimer.Tick
        Select Case currentState
            Case GameState.Ready
                ' ラウンド開始前の処理（スキル選択など）
                UpdateReady()
            Case GameState.Playing
                ' ラウンド中の処理
                UpdatePlaying()
            Case GameState.RoundEnd
                ' ラウンド終了後の処理（得点更新など）
                UpdateRoundEnd()
        End Select

        ' 左パドル
        If up1Pressed Then
            nowPlayer1Params.PaddlePos += nowPlayer1Params.PaddleSpeed
        End If
        ' 左パドル
        If down1Pressed Then
            nowPlayer1Params.PaddlePos -= nowPlayer1Params.PaddleSpeed
        End If
        ' 右パドル
        If up2Pressed Then
            nowPlayer2Params.PaddlePos += nowPlayer2Params.PaddleSpeed
        End If
        ' 右パドル
        If down2Pressed Then
            nowPlayer2Params.PaddlePos -= nowPlayer2Params.PaddleSpeed
        End If

        Clamp(nowPlayer1Params.PaddlePos, nowPlayer1Params.PaddleSize, -PanelHeight / 2, PanelHeight / 2)
        Clamp(nowPlayer2Params.PaddlePos, nowPlayer2Params.PaddleSize, -PanelHeight / 2, PanelHeight / 2)

        ' 再描画要求
        CanvasPanel.Invalidate()
    End Sub

    ' READY
    Private Sub UpdateReady()
        ' ラウンド開始前の処理（スキル選択など）

        ' スペースキーで開始
        If spacePressed Then
            ResetBall()

            currentState = GameState.Playing
        End If
    End Sub

    ' PLAYING
    Private Sub UpdatePlaying()
        ' ラウンド中の処理

    End Sub

    ' ROUND END
    Private Sub UpdateRoundEnd()
        ' ラウンド終了後の処理（得点更新など）
    End Sub

    Private Sub ResetBall()
        nowGameParams.BallPosX = PanelWidth / 2
        nowGameParams.BallPosY = PanelHeight / 2
        ' ボールの方向はランダムに設定するなど、必要に応じて調整
        nowGameParams.BallVelX = 1
        nowGameParams.BallVelY = 0
    End Sub

    Private Shared Sub Clamp(ByRef pos As Integer, size As Integer, min As Integer, max As Integer)
        If pos - size / 2 < min Then
            pos = min + size / 2
        End If
        If pos + size / 2 > max Then
            pos = max - size / 2
        End If
    End Sub

    Private Sub CanvasPanel_Paint(sender As Object, e As PaintEventArgs) Handles CanvasPanel.Paint
        Dim g As Graphics = e.Graphics
        Dim xCenter As Integer = PanelWidth / 2
        Dim yCenter As Integer = PanelHeight / 2

        ' 背景
        g.Clear(Color.Black)
        ' 点線
        For i As Integer = 0 To PanelHeight Step 100
            g.FillRectangle(Brushes.White, xCenter - 5, i, 10, 50)
        Next i
        ' Player1 パドル
        g.FillRectangle(Brushes.White, 45, CInt(yCenter - nowPlayer1Params.PaddlePos - nowPlayer1Params.PaddleSize / 2),
                        10, nowPlayer1Params.PaddleSize)
        ' Player2 パドル
        g.FillRectangle(Brushes.White, PanelWidth - 55, CInt(yCenter - nowPlayer2Params.PaddlePos - nowPlayer2Params.PaddleSize / 2),
                        10, nowPlayer2Params.PaddleSize)
        ' ボール
        g.FillRectangle(Brushes.White, CInt(nowGameParams.BallPosX - nowGameParams.BallLen / 2), CInt(nowGameParams.BallPosY - nowGameParams.BallLen / 2),
                        nowGameParams.BallLen, nowGameParams.BallLen)
    End Sub

    Private Sub Form2_Keydown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' キー入力処理
        If e.KeyCode = Keys.Space Then
            spacePressed = True
        End If

        ' test用
        If (e.KeyCode = Keys.W) Then
            ' Player 1 上
            up1Pressed = True
        ElseIf (e.KeyCode = Keys.S) Then
            ' Player 1 下
            down1Pressed = True
        ElseIf (e.KeyCode = Keys.Up) Then
            ' Player 2 上
            up2Pressed = True
        ElseIf (e.KeyCode = Keys.Down) Then
            ' Player 2 下
            down2Pressed = True
        End If
    End Sub

    Private Sub Form2_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        ' キー入力処理
        If e.KeyCode = Keys.Space Then
            spacePressed = False
        End If

        ' test用
        If (e.KeyCode = Keys.W) Then
            ' Player 1 上
            up1Pressed = False
        ElseIf (e.KeyCode = Keys.S) Then
            ' Player 1 下
            down1Pressed = False
        ElseIf (e.KeyCode = Keys.Up) Then
            ' Player 2 上
            up2Pressed = False
        ElseIf (e.KeyCode = Keys.Down) Then
            ' Player 2 下
            down2Pressed = False
        End If
    End Sub

    Private Sub TcpSockets1_Accept(ByVal sender As System.Object, ByVal e As Experiment.TcpSocket.AcceptEventArgs) Handles TcpSockets1.Accept

    End Sub

    Private Sub TcpSockets1_Connect(ByVal sender As System.Object, ByVal e As Experiment.TcpSocket.ConnectEventArgs) Handles TcpSockets1.Connect

    End Sub

    Private Sub TcpSockets1_Disconnect(ByVal sender As System.Object, ByVal e As Experiment.TcpSocket.DisconnectEventArgs) Handles TcpSockets1.Disconnect

    End Sub

    Private Sub TcpSockets1_DataReceive(sender As Object, e As DataReceiveEventArgs) Handles TcpSockets1.DataReceive

    End Sub

    ' test用
    Private Sub TypeCombo_Test_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeCombo_Test.SelectedIndexChanged
        SCtype = TypeCombo_Test.SelectedIndex
        SCtype_str = If(SCtype = 0, "Server", "Client")
        TypeLabel.Text = "Type: " & SCtype_str
    End Sub

    ' ダブルバッファリング設定
    Private Sub EnableDoubleBuffering(ctrl As Control)
        Dim prop As PropertyInfo =
            GetType(Control).GetProperty(
                "DoubleBuffered",
                BindingFlags.NonPublic Or BindingFlags.Instance)
        prop.SetValue(ctrl, True, Nothing)
    End Sub
End Class
