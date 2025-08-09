<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMstcouponSub1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMstcouponSub1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxクーポン番号 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DateTimePicker期間2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker期間1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button一括更新 = New System.Windows.Forms.Button()
        Me.Button中止 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "クーポン番号"
        '
        'TextBoxクーポン番号
        '
        Me.TextBoxクーポン番号.Location = New System.Drawing.Point(84, 15)
        Me.TextBoxクーポン番号.Name = "TextBoxクーポン番号"
        Me.TextBoxクーポン番号.Size = New System.Drawing.Size(144, 19)
        Me.TextBoxクーポン番号.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(246, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 142
        Me.Label8.Text = "～"
        '
        'DateTimePicker期間2
        '
        Me.DateTimePicker期間2.Location = New System.Drawing.Point(276, 45)
        Me.DateTimePicker期間2.Name = "DateTimePicker期間2"
        Me.DateTimePicker期間2.Size = New System.Drawing.Size(144, 19)
        Me.DateTimePicker期間2.TabIndex = 141
        '
        'DateTimePicker期間1
        '
        Me.DateTimePicker期間1.Location = New System.Drawing.Point(82, 45)
        Me.DateTimePicker期間1.Name = "DateTimePicker期間1"
        Me.DateTimePicker期間1.Size = New System.Drawing.Size(144, 19)
        Me.DateTimePicker期間1.TabIndex = 140
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 139
        Me.Label7.Text = "割引期間"
        '
        'Button一括更新
        '
        Me.Button一括更新.Location = New System.Drawing.Point(276, 77)
        Me.Button一括更新.Name = "Button一括更新"
        Me.Button一括更新.Size = New System.Drawing.Size(144, 23)
        Me.Button一括更新.TabIndex = 143
        Me.Button一括更新.Text = "一括更新"
        Me.Button一括更新.UseVisualStyleBackColor = True
        '
        'Button中止
        '
        Me.Button中止.Location = New System.Drawing.Point(82, 77)
        Me.Button中止.Name = "Button中止"
        Me.Button中止.Size = New System.Drawing.Size(144, 23)
        Me.Button中止.TabIndex = 144
        Me.Button中止.Text = "中止"
        Me.Button中止.UseVisualStyleBackColor = True
        '
        'FormMstcouponSub1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 112)
        Me.Controls.Add(Me.Button中止)
        Me.Controls.Add(Me.Button一括更新)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DateTimePicker期間2)
        Me.Controls.Add(Me.DateTimePicker期間1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBoxクーポン番号)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMstcouponSub1"
        Me.Text = "クーポン一括変更"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxクーポン番号 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DateTimePicker期間2 As DateTimePicker
    Friend WithEvents DateTimePicker期間1 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Button一括更新 As Button
    Friend WithEvents Button中止 As Button
End Class
