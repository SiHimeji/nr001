<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChkVerUp
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
        Me.LabelMsg = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelMsg
        '
        Me.LabelMsg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMsg.Location = New System.Drawing.Point(0, 0)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(63, 15)
        Me.LabelMsg.TabIndex = 0
        Me.LabelMsg.Text = "LabelMsg"
        '
        'ChkVerUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(63, 15)
        Me.Controls.Add(Me.LabelMsg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChkVerUp"
        Me.Text = "VerUp"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelMsg As Label
End Class
