<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSub002
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
        Me.ComboBox得意先 = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown金額 = New System.Windows.Forms.NumericUpDown()
        Me.Buttonキャンセル = New System.Windows.Forms.Button()
        Me.Button決定 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label得意先コード = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label発注No = New System.Windows.Forms.Label()
        Me.Label赤黒 = New System.Windows.Forms.Label()
        Me.DateTimePicker伝票発行日 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown金額, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox得意先
        '
        Me.ComboBox得意先.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox得意先.FormattingEnabled = True
        Me.ComboBox得意先.Location = New System.Drawing.Point(13, 69)
        Me.ComboBox得意先.Name = "ComboBox得意先"
        Me.ComboBox得意先.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox得意先.TabIndex = 0
        '
        'NumericUpDown金額
        '
        Me.NumericUpDown金額.Location = New System.Drawing.Point(140, 69)
        Me.NumericUpDown金額.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericUpDown金額.Name = "NumericUpDown金額"
        Me.NumericUpDown金額.Size = New System.Drawing.Size(120, 19)
        Me.NumericUpDown金額.TabIndex = 1
        '
        'Buttonキャンセル
        '
        Me.Buttonキャンセル.Location = New System.Drawing.Point(14, 116)
        Me.Buttonキャンセル.Name = "Buttonキャンセル"
        Me.Buttonキャンセル.Size = New System.Drawing.Size(120, 23)
        Me.Buttonキャンセル.TabIndex = 2
        Me.Buttonキャンセル.Text = "キャンセル"
        Me.Buttonキャンセル.UseVisualStyleBackColor = True
        '
        'Button決定
        '
        Me.Button決定.Location = New System.Drawing.Point(140, 117)
        Me.Button決定.Name = "Button決定"
        Me.Button決定.Size = New System.Drawing.Size(120, 23)
        Me.Button決定.TabIndex = 3
        Me.Button決定.Text = "決定"
        Me.Button決定.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(140, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "単価"
        '
        'Label得意先コード
        '
        Me.Label得意先コード.AutoSize = True
        Me.Label得意先コード.Location = New System.Drawing.Point(13, 53)
        Me.Label得意先コード.Name = "Label得意先コード"
        Me.Label得意先コード.Size = New System.Drawing.Size(68, 12)
        Me.Label得意先コード.TabIndex = 5
        Me.Label得意先コード.Text = "得意先コード"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "発注No"
        '
        'Label発注No
        '
        Me.Label発注No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label発注No.Location = New System.Drawing.Point(69, 31)
        Me.Label発注No.Name = "Label発注No"
        Me.Label発注No.Size = New System.Drawing.Size(130, 19)
        Me.Label発注No.TabIndex = 7
        Me.Label発注No.Text = "発注No"
        '
        'Label赤黒
        '
        Me.Label赤黒.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label赤黒.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label赤黒.Location = New System.Drawing.Point(12, 8)
        Me.Label赤黒.Name = "Label赤黒"
        Me.Label赤黒.Size = New System.Drawing.Size(238, 19)
        Me.Label赤黒.TabIndex = 8
        Me.Label赤黒.Text = "赤伝票"
        '
        'DateTimePicker伝票発行日
        '
        Me.DateTimePicker伝票発行日.Location = New System.Drawing.Point(140, 94)
        Me.DateTimePicker伝票発行日.Name = "DateTimePicker伝票発行日"
        Me.DateTimePicker伝票発行日.Size = New System.Drawing.Size(120, 19)
        Me.DateTimePicker伝票発行日.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "伝票発行日"
        '
        'FormSub002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 149)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker伝票発行日)
        Me.Controls.Add(Me.Label赤黒)
        Me.Controls.Add(Me.Label発注No)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label得意先コード)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button決定)
        Me.Controls.Add(Me.Buttonキャンセル)
        Me.Controls.Add(Me.NumericUpDown金額)
        Me.Controls.Add(Me.ComboBox得意先)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormSub002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormSub002"
        CType(Me.NumericUpDown金額, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox得意先 As ComboBox
    Friend WithEvents NumericUpDown金額 As NumericUpDown
    Friend WithEvents Buttonキャンセル As Button
    Friend WithEvents Button決定 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label得意先コード As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label発注No As Label
    Friend WithEvents Label赤黒 As Label
    Friend WithEvents DateTimePicker伝票発行日 As DateTimePicker
    Friend WithEvents Label2 As Label
End Class
