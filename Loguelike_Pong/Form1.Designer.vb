<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TcpSockets1 = New Experiment.TcpSocket.TcpSockets(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TcpSockets1
        '
        Me.TcpSockets1.SynchronizingObject = Me
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(135, 387)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(117, 22)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "127.0.0.1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = Global.Loguelike_Pong.My.Resources.Resources.LoguelikePongLogo
        Me.PictureBox1.Location = New System.Drawing.Point(200, 50)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(400, 300)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(78, 390)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "アドレス"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(782, 553)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TcpSockets1 As Experiment.TcpSocket.TcpSockets
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
End Class
