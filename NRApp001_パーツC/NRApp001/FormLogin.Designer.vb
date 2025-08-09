<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.Buttonlogin = New System.Windows.Forms.Button()
        Me.TextBoxパスワード = New System.Windows.Forms.TextBox()
        Me.TextBoxログイン = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonCancel.Location = New System.Drawing.Point(152, 74)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(98, 31)
        Me.ButtonCancel.TabIndex = 9
        Me.ButtonCancel.Text = "キャンセル"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'Buttonlogin
        '
        Me.Buttonlogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Buttonlogin.Location = New System.Drawing.Point(40, 74)
        Me.Buttonlogin.Name = "Buttonlogin"
        Me.Buttonlogin.Size = New System.Drawing.Size(98, 31)
        Me.Buttonlogin.TabIndex = 8
        Me.Buttonlogin.Text = "ログイン"
        Me.Buttonlogin.UseVisualStyleBackColor = False
        '
        'TextBoxパスワード
        '
        Me.TextBoxパスワード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxパスワード.Location = New System.Drawing.Point(98, 45)
        Me.TextBoxパスワード.Name = "TextBoxパスワード"
        Me.TextBoxパスワード.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxパスワード.Size = New System.Drawing.Size(151, 19)
        Me.TextBoxパスワード.TabIndex = 6
        '
        'TextBoxログイン
        '
        Me.TextBoxログイン.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxログイン.Location = New System.Drawing.Point(98, 15)
        Me.TextBoxログイン.Name = "TextBoxログイン"
        Me.TextBoxログイン.Size = New System.Drawing.Size(151, 19)
        Me.TextBoxログイン.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "パスワード"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "ログイン"
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 118)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.Buttonlogin)
        Me.Controls.Add(Me.TextBoxパスワード)
        Me.Controls.Add(Me.TextBoxログイン)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormLogin"
        Me.Text = "パーツセンターシステム　ログイン"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonCancel As Button
    Friend WithEvents Buttonlogin As Button
    Friend WithEvents TextBoxパスワード As TextBox
    Friend WithEvents TextBoxログイン As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
