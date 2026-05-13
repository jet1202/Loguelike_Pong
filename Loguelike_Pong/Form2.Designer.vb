<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.TypeLabel = New System.Windows.Forms.Label()
        Me.TypeCombo_Test = New System.Windows.Forms.ComboBox()
        Me.CanvasPanel = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'TcpSockets1
        '
        Me.TcpSockets1.SynchronizingObject = Nothing
        '
        'TypeLabel
        '
        Me.TypeLabel.AutoSize = True
        Me.TypeLabel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TypeLabel.Location = New System.Drawing.Point(8, 14)
        Me.TypeLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TypeLabel.Name = "TypeLabel"
        Me.TypeLabel.Size = New System.Drawing.Size(95, 12)
        Me.TypeLabel.TabIndex = 0
        Me.TypeLabel.Text = "Type: Unknown"
        '
        'TypeCombo_Test
        '
        Me.TypeCombo_Test.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeCombo_Test.FormattingEnabled = True
        Me.TypeCombo_Test.Items.AddRange(New Object() {"Server", "Client"})
        Me.TypeCombo_Test.Location = New System.Drawing.Point(107, 9)
        Me.TypeCombo_Test.Margin = New System.Windows.Forms.Padding(2)
        Me.TypeCombo_Test.Name = "TypeCombo_Test"
        Me.TypeCombo_Test.Size = New System.Drawing.Size(74, 20)
        Me.TypeCombo_Test.TabIndex = 1
        '
        'CanvasPanel
        '
        Me.CanvasPanel.BackColor = System.Drawing.Color.Black
        Me.CanvasPanel.Location = New System.Drawing.Point(28, 60)
        Me.CanvasPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.CanvasPanel.Name = "CanvasPanel"
        Me.CanvasPanel.Size = New System.Drawing.Size(1000, 600)
        Me.CanvasPanel.TabIndex = 2
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 681)
        Me.Controls.Add(Me.CanvasPanel)
        Me.Controls.Add(Me.TypeCombo_Test)
        Me.Controls.Add(Me.TypeLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TcpSockets1 As Experiment.TcpSocket.TcpSockets
    Friend WithEvents TypeLabel As Label
    Friend WithEvents TypeCombo_Test As ComboBox
    Friend WithEvents CanvasPanel As Panel
End Class
