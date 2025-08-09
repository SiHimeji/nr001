<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPass))
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.Buttonキャンセル = New System.Windows.Forms.Button()
        Me.TextBox現パスワード = New System.Windows.Forms.TextBox()
        Me.TextBoxログイン = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox新パスワード１ = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox新パスワード２ = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox氏名 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(39, 136)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(94, 33)
        Me.Button更新.TabIndex = 4
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'Buttonキャンセル
        '
        Me.Buttonキャンセル.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Buttonキャンセル.Location = New System.Drawing.Point(155, 136)
        Me.Buttonキャンセル.Name = "Buttonキャンセル"
        Me.Buttonキャンセル.Size = New System.Drawing.Size(93, 33)
        Me.Buttonキャンセル.TabIndex = 5
        Me.Buttonキャンセル.Text = "キャンセル"
        Me.Buttonキャンセル.UseVisualStyleBackColor = False
        '
        'TextBox現パスワード
        '
        Me.TextBox現パスワード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox現パスワード.Location = New System.Drawing.Point(127, 56)
        Me.TextBox現パスワード.MaxLength = 10
        Me.TextBox現パスワード.Name = "TextBox現パスワード"
        Me.TextBox現パスワード.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox現パスワード.Size = New System.Drawing.Size(121, 19)
        Me.TextBox現パスワード.TabIndex = 1
        '
        'TextBoxログイン
        '
        Me.TextBoxログイン.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxログイン.Location = New System.Drawing.Point(127, 33)
        Me.TextBoxログイン.MaxLength = 10
        Me.TextBoxログイン.Name = "TextBoxログイン"
        Me.TextBoxログイン.ReadOnly = True
        Me.TextBoxログイン.Size = New System.Drawing.Size(121, 19)
        Me.TextBoxログイン.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 12)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "現パスワード"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "ログイン"
        '
        'TextBox新パスワード１
        '
        Me.TextBox新パスワード１.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox新パスワード１.Location = New System.Drawing.Point(127, 81)
        Me.TextBox新パスワード１.MaxLength = 10
        Me.TextBox新パスワード１.Name = "TextBox新パスワード１"
        Me.TextBox新パスワード１.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox新パスワード１.Size = New System.Drawing.Size(121, 19)
        Me.TextBox新パスワード１.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 12)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "新パスワード"
        '
        'TextBox新パスワード２
        '
        Me.TextBox新パスワード２.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox新パスワード２.Location = New System.Drawing.Point(127, 106)
        Me.TextBox新パスワード２.MaxLength = 10
        Me.TextBox新パスワード２.Name = "TextBox新パスワード２"
        Me.TextBox新パスワード２.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox新パスワード２.Size = New System.Drawing.Size(121, 19)
        Me.TextBox新パスワード２.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 12)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "新パスワード（再）"
        '
        'TextBox氏名
        '
        Me.TextBox氏名.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox氏名.Location = New System.Drawing.Point(127, 8)
        Me.TextBox氏名.MaxLength = 10
        Me.TextBox氏名.Name = "TextBox氏名"
        Me.TextBox氏名.ReadOnly = True
        Me.TextBox氏名.Size = New System.Drawing.Size(121, 19)
        Me.TextBox氏名.TabIndex = 53
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "氏名"
        '
        'FormPass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 178)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox氏名)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox新パスワード２)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox新パスワード１)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox現パスワード)
        Me.Controls.Add(Me.TextBoxログイン)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Buttonキャンセル)
        Me.Controls.Add(Me.Button更新)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormPass"
        Me.Text = "パスワード変更"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button更新 As Button
    Friend WithEvents Buttonキャンセル As Button
    Friend WithEvents TextBox現パスワード As TextBox
    Friend WithEvents TextBoxログイン As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox新パスワード１ As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox新パスワード２ As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox氏名 As TextBox
    Friend WithEvents Label5 As Label
End Class
