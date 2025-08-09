<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInput
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInput))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox訂正依頼内容 = New System.Windows.Forms.TextBox()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.TextBox点検受付番号 = New System.Windows.Forms.TextBox()
        Me.ComboBoxステータス = New System.Windows.Forms.ComboBox()
        Me.TextBoxDM番号 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Buttonキャンセル = New System.Windows.Forms.Button()
        Me.Label更新時間 = New System.Windows.Forms.Label()
        Me.Button済 = New System.Windows.Forms.Button()
        Me.CheckBox出庫停止 = New System.Windows.Forms.CheckBox()
        Me.Button削除 = New System.Windows.Forms.Button()
        Me.Label完了日 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox出庫 = New System.Windows.Forms.TextBox()
        Me.Button出庫 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox技術チェック = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.MaskedTextBox技術確認完了日 = New System.Windows.Forms.MaskedTextBox()
        Me.Button削除CHECK = New System.Windows.Forms.Button()
        Me.TextBoxメモ = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxチェック日 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox得意先コード = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "点検受付番号"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(211, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "更新日"
        '
        'TextBox訂正依頼内容
        '
        Me.TextBox訂正依頼内容.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox訂正依頼内容.Location = New System.Drawing.Point(11, 80)
        Me.TextBox訂正依頼内容.MaxLength = 2048
        Me.TextBox訂正依頼内容.Multiline = True
        Me.TextBox訂正依頼内容.Name = "TextBox訂正依頼内容"
        Me.TextBox訂正依頼内容.Size = New System.Drawing.Size(375, 152)
        Me.TextBox訂正依頼内容.TabIndex = 2
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(12, 410)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(75, 23)
        Me.Button更新.TabIndex = 3
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'TextBox点検受付番号
        '
        Me.TextBox点検受付番号.Location = New System.Drawing.Point(88, 7)
        Me.TextBox点検受付番号.Name = "TextBox点検受付番号"
        Me.TextBox点検受付番号.ReadOnly = True
        Me.TextBox点検受付番号.Size = New System.Drawing.Size(120, 19)
        Me.TextBox点検受付番号.TabIndex = 5
        '
        'ComboBoxステータス
        '
        Me.ComboBoxステータス.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxステータス.FormattingEnabled = True
        Me.ComboBoxステータス.Location = New System.Drawing.Point(88, 53)
        Me.ComboBoxステータス.Name = "ComboBoxステータス"
        Me.ComboBoxステータス.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxステータス.TabIndex = 0
        '
        'TextBoxDM番号
        '
        Me.TextBoxDM番号.Location = New System.Drawing.Point(88, 29)
        Me.TextBoxDM番号.Name = "TextBoxDM番号"
        Me.TextBoxDM番号.ReadOnly = True
        Me.TextBoxDM番号.Size = New System.Drawing.Size(187, 19)
        Me.TextBoxDM番号.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "DM番号"
        '
        'Buttonキャンセル
        '
        Me.Buttonキャンセル.BackColor = System.Drawing.Color.Yellow
        Me.Buttonキャンセル.Location = New System.Drawing.Point(93, 410)
        Me.Buttonキャンセル.Name = "Buttonキャンセル"
        Me.Buttonキャンセル.Size = New System.Drawing.Size(75, 23)
        Me.Buttonキャンセル.TabIndex = 4
        Me.Buttonキャンセル.Text = "キャンセル"
        Me.Buttonキャンセル.UseVisualStyleBackColor = False
        '
        'Label更新時間
        '
        Me.Label更新時間.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label更新時間.Location = New System.Drawing.Point(250, 54)
        Me.Label更新時間.Name = "Label更新時間"
        Me.Label更新時間.Size = New System.Drawing.Size(136, 18)
        Me.Label更新時間.TabIndex = 11
        Me.Label更新時間.Text = "Label5"
        '
        'Button済
        '
        Me.Button済.BackColor = System.Drawing.Color.Fuchsia
        Me.Button済.Location = New System.Drawing.Point(315, 410)
        Me.Button済.Name = "Button済"
        Me.Button済.Size = New System.Drawing.Size(75, 23)
        Me.Button済.TabIndex = 6
        Me.Button済.Text = "完了"
        Me.Button済.UseVisualStyleBackColor = False
        '
        'CheckBox出庫停止
        '
        Me.CheckBox出庫停止.AutoSize = True
        Me.CheckBox出庫停止.Location = New System.Drawing.Point(25, 385)
        Me.CheckBox出庫停止.Name = "CheckBox出庫停止"
        Me.CheckBox出庫停止.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox出庫停止.TabIndex = 1
        Me.CheckBox出庫停止.Text = "出庫停止"
        Me.CheckBox出庫停止.UseVisualStyleBackColor = True
        '
        'Button削除
        '
        Me.Button削除.BackColor = System.Drawing.Color.Red
        Me.Button削除.Location = New System.Drawing.Point(239, 410)
        Me.Button削除.Name = "Button削除"
        Me.Button削除.Size = New System.Drawing.Size(75, 23)
        Me.Button削除.TabIndex = 5
        Me.Button削除.Text = "削除"
        Me.Button削除.UseVisualStyleBackColor = False
        '
        'Label完了日
        '
        Me.Label完了日.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label完了日.Location = New System.Drawing.Point(250, 7)
        Me.Label完了日.Name = "Label完了日"
        Me.Label完了日.Size = New System.Drawing.Size(136, 18)
        Me.Label完了日.TabIndex = 13
        Me.Label完了日.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(211, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "完了日"
        '
        'TextBox出庫
        '
        Me.TextBox出庫.Location = New System.Drawing.Point(99, 383)
        Me.TextBox出庫.Name = "TextBox出庫"
        Me.TextBox出庫.ReadOnly = True
        Me.TextBox出庫.Size = New System.Drawing.Size(205, 19)
        Me.TextBox出庫.TabIndex = 14
        '
        'Button出庫
        '
        Me.Button出庫.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button出庫.Location = New System.Drawing.Point(310, 382)
        Me.Button出庫.Name = "Button出庫"
        Me.Button出庫.Size = New System.Drawing.Size(75, 23)
        Me.Button出庫.TabIndex = 15
        Me.Button出庫.Text = "未へ"
        Me.Button出庫.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 316)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 12)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "チェック"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(136, 318)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "確認完了日"
        '
        'TextBox技術チェック
        '
        Me.TextBox技術チェック.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox技術チェック.Location = New System.Drawing.Point(55, 315)
        Me.TextBox技術チェック.MaxLength = 30
        Me.TextBox技術チェック.Name = "TextBox技術チェック"
        Me.TextBox技術チェック.Size = New System.Drawing.Size(78, 19)
        Me.TextBox技術チェック.TabIndex = 18
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(203, 315)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 19)
        Me.DateTimePicker1.TabIndex = 19
        '
        'MaskedTextBox技術確認完了日
        '
        Me.MaskedTextBox技術確認完了日.Location = New System.Drawing.Point(203, 315)
        Me.MaskedTextBox技術確認完了日.Mask = "0000/00/00"
        Me.MaskedTextBox技術確認完了日.Name = "MaskedTextBox技術確認完了日"
        Me.MaskedTextBox技術確認完了日.Size = New System.Drawing.Size(85, 19)
        Me.MaskedTextBox技術確認完了日.TabIndex = 20
        Me.MaskedTextBox技術確認完了日.ValidatingType = GetType(Date)
        '
        'Button削除CHECK
        '
        Me.Button削除CHECK.BackColor = System.Drawing.Color.Red
        Me.Button削除CHECK.Location = New System.Drawing.Point(330, 313)
        Me.Button削除CHECK.Name = "Button削除CHECK"
        Me.Button削除CHECK.Size = New System.Drawing.Size(56, 23)
        Me.Button削除CHECK.TabIndex = 21
        Me.Button削除CHECK.Text = "削除"
        Me.Button削除CHECK.UseVisualStyleBackColor = False
        '
        'TextBoxメモ
        '
        Me.TextBoxメモ.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBoxメモ.Location = New System.Drawing.Point(10, 253)
        Me.TextBoxメモ.MaxLength = 2048
        Me.TextBoxメモ.Multiline = True
        Me.TextBoxメモ.Name = "TextBoxメモ"
        Me.TextBoxメモ.Size = New System.Drawing.Size(375, 53)
        Me.TextBoxメモ.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "メモ"
        '
        'TextBoxチェック日
        '
        Me.TextBoxチェック日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxチェック日.Location = New System.Drawing.Point(67, 338)
        Me.TextBoxチェック日.MaxLength = 30
        Me.TextBoxチェック日.Name = "TextBoxチェック日"
        Me.TextBoxチェック日.Size = New System.Drawing.Size(78, 19)
        Me.TextBoxチェック日.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 341)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 12)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "チェック日"
        '
        'TextBox得意先コード
        '
        Me.TextBox得意先コード.Location = New System.Drawing.Point(103, 360)
        Me.TextBox得意先コード.Name = "TextBox得意先コード"
        Me.TextBox得意先コード.ReadOnly = True
        Me.TextBox得意先コード.Size = New System.Drawing.Size(120, 19)
        Me.TextBox得意先コード.TabIndex = 26
        '
        'FormInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 440)
        Me.Controls.Add(Me.TextBox得意先コード)
        Me.Controls.Add(Me.TextBoxチェック日)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxメモ)
        Me.Controls.Add(Me.Button削除CHECK)
        Me.Controls.Add(Me.MaskedTextBox技術確認完了日)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TextBox技術チェック)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button出庫)
        Me.Controls.Add(Me.TextBox出庫)
        Me.Controls.Add(Me.Label完了日)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button削除)
        Me.Controls.Add(Me.CheckBox出庫停止)
        Me.Controls.Add(Me.Button済)
        Me.Controls.Add(Me.Label更新時間)
        Me.Controls.Add(Me.Buttonキャンセル)
        Me.Controls.Add(Me.TextBoxDM番号)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBoxステータス)
        Me.Controls.Add(Me.TextBox点検受付番号)
        Me.Controls.Add(Me.Button更新)
        Me.Controls.Add(Me.TextBox訂正依頼内容)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormInput"
        Me.Text = "訂正入力"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox訂正依頼内容 As TextBox
    Friend WithEvents Button更新 As Button
    Friend WithEvents TextBox点検受付番号 As TextBox
    Friend WithEvents ComboBoxステータス As ComboBox
    Friend WithEvents TextBoxDM番号 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Buttonキャンセル As Button
    Friend WithEvents Label更新時間 As Label
    Friend WithEvents Button済 As Button
    Friend WithEvents CheckBox出庫停止 As CheckBox
    Friend WithEvents Button削除 As Button
    Friend WithEvents Label完了日 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox出庫 As TextBox
    Friend WithEvents Button出庫 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox技術チェック As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents MaskedTextBox技術確認完了日 As MaskedTextBox
    Friend WithEvents Button削除CHECK As Button
    Friend WithEvents TextBoxメモ As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxチェック日 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox得意先コード As TextBox
End Class
