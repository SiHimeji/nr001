<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.管理ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ユーザーToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.システムマスタToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem不備内容マスタ = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.更新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.不備ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.技術ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ログ表示ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.Button入力 = New System.Windows.Forms.Button()
        Me.Buttonチェック = New System.Windows.Forms.Button()
        Me.Button売上管理 = New System.Windows.Forms.Button()
        Me.Button請求管理 = New System.Windows.Forms.Button()
        Me.Button出庫管理 = New System.Windows.Forms.Button()
        Me.Button物件管理 = New System.Windows.Forms.Button()
        Me.Button点検チェック = New System.Windows.Forms.Button()
        Me.Button回収管理 = New System.Windows.Forms.Button()
        Me.Button承認 = New System.Windows.Forms.Button()
        Me.ButtonRIreki = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.管理ToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(213, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '管理ToolStripMenuItem
        '
        Me.管理ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.ユーザーToolStripMenuItem, Me.システムマスタToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripMenuItem不備内容マスタ, Me.ToolStripMenuItem3, Me.更新ToolStripMenuItem, Me.ログ表示ToolStripMenuItem, Me.SQLToolStripMenuItem})
        Me.管理ToolStripMenuItem.Name = "管理ToolStripMenuItem"
        Me.管理ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.管理ToolStripMenuItem.Text = "管理"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(189, 22)
        Me.ToolStripTextBox1.Text = "パスワード変更"
        '
        'ユーザーToolStripMenuItem
        '
        Me.ユーザーToolStripMenuItem.Name = "ユーザーToolStripMenuItem"
        Me.ユーザーToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ユーザーToolStripMenuItem.Text = "ユーザー"
        '
        'システムマスタToolStripMenuItem
        '
        Me.システムマスタToolStripMenuItem.Name = "システムマスタToolStripMenuItem"
        Me.システムマスタToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.システムマスタToolStripMenuItem.Text = "システムマスタ"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(189, 22)
        Me.ToolStripMenuItem2.Text = "コメント・検索条件マスタ"
        '
        'ToolStripMenuItem不備内容マスタ
        '
        Me.ToolStripMenuItem不備内容マスタ.Name = "ToolStripMenuItem不備内容マスタ"
        Me.ToolStripMenuItem不備内容マスタ.Size = New System.Drawing.Size(189, 22)
        Me.ToolStripMenuItem不備内容マスタ.Text = "不備内容マスタ(製品）"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(189, 22)
        Me.ToolStripMenuItem3.Text = "不備内容マスタ(結果）"
        '
        '更新ToolStripMenuItem
        '
        Me.更新ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.不備ToolStripMenuItem, Me.技術ToolStripMenuItem})
        Me.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem"
        Me.更新ToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.更新ToolStripMenuItem.Text = "更新"
        '
        '不備ToolStripMenuItem
        '
        Me.不備ToolStripMenuItem.Name = "不備ToolStripMenuItem"
        Me.不備ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.不備ToolStripMenuItem.Text = "不備"
        '
        '技術ToolStripMenuItem
        '
        Me.技術ToolStripMenuItem.Name = "技術ToolStripMenuItem"
        Me.技術ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.技術ToolStripMenuItem.Text = "技術"
        '
        'ログ表示ToolStripMenuItem
        '
        Me.ログ表示ToolStripMenuItem.Name = "ログ表示ToolStripMenuItem"
        Me.ログ表示ToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ログ表示ToolStripMenuItem.Text = "ログ表示"
        '
        'SQLToolStripMenuItem
        '
        Me.SQLToolStripMenuItem.Name = "SQLToolStripMenuItem"
        Me.SQLToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.SQLToolStripMenuItem.Text = "SQL"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 466)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(213, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(80, 16)
        '
        'Button入力
        '
        Me.Button入力.BackColor = System.Drawing.SystemColors.Control
        Me.Button入力.Location = New System.Drawing.Point(12, 27)
        Me.Button入力.Name = "Button入力"
        Me.Button入力.Size = New System.Drawing.Size(192, 36)
        Me.Button入力.TabIndex = 0
        Me.Button入力.Text = "点検集約データ"
        Me.Button入力.UseVisualStyleBackColor = False
        '
        'Buttonチェック
        '
        Me.Buttonチェック.Location = New System.Drawing.Point(12, 68)
        Me.Buttonチェック.Name = "Buttonチェック"
        Me.Buttonチェック.Size = New System.Drawing.Size(192, 36)
        Me.Buttonチェック.TabIndex = 1
        Me.Buttonチェック.Text = "点検チェック"
        Me.Buttonチェック.UseVisualStyleBackColor = True
        '
        'Button売上管理
        '
        Me.Button売上管理.Location = New System.Drawing.Point(12, 147)
        Me.Button売上管理.Name = "Button売上管理"
        Me.Button売上管理.Size = New System.Drawing.Size(192, 36)
        Me.Button売上管理.TabIndex = 3
        Me.Button売上管理.Text = "売上管理"
        Me.Button売上管理.UseVisualStyleBackColor = True
        '
        'Button請求管理
        '
        Me.Button請求管理.Location = New System.Drawing.Point(12, 107)
        Me.Button請求管理.Name = "Button請求管理"
        Me.Button請求管理.Size = New System.Drawing.Size(192, 36)
        Me.Button請求管理.TabIndex = 2
        Me.Button請求管理.Text = "請求管理"
        Me.Button請求管理.UseVisualStyleBackColor = True
        '
        'Button出庫管理
        '
        Me.Button出庫管理.Location = New System.Drawing.Point(12, 189)
        Me.Button出庫管理.Name = "Button出庫管理"
        Me.Button出庫管理.Size = New System.Drawing.Size(192, 36)
        Me.Button出庫管理.TabIndex = 4
        Me.Button出庫管理.Text = "出庫管理"
        Me.Button出庫管理.UseVisualStyleBackColor = True
        '
        'Button物件管理
        '
        Me.Button物件管理.Location = New System.Drawing.Point(12, 231)
        Me.Button物件管理.Name = "Button物件管理"
        Me.Button物件管理.Size = New System.Drawing.Size(192, 36)
        Me.Button物件管理.TabIndex = 7
        Me.Button物件管理.Text = "物件管理"
        Me.Button物件管理.UseVisualStyleBackColor = True
        '
        'Button点検チェック
        '
        Me.Button点検チェック.Location = New System.Drawing.Point(12, 273)
        Me.Button点検チェック.Name = "Button点検チェック"
        Me.Button点検チェック.Size = New System.Drawing.Size(192, 36)
        Me.Button点検チェック.TabIndex = 8
        Me.Button点検チェック.Text = "品質チェック"
        Me.Button点検チェック.UseVisualStyleBackColor = True
        '
        'Button回収管理
        '
        Me.Button回収管理.Location = New System.Drawing.Point(13, 314)
        Me.Button回収管理.Name = "Button回収管理"
        Me.Button回収管理.Size = New System.Drawing.Size(192, 36)
        Me.Button回収管理.TabIndex = 9
        Me.Button回収管理.Text = "回収管理"
        Me.Button回収管理.UseVisualStyleBackColor = True
        '
        'Button承認
        '
        Me.Button承認.Location = New System.Drawing.Point(12, 372)
        Me.Button承認.Name = "Button承認"
        Me.Button承認.Size = New System.Drawing.Size(191, 35)
        Me.Button承認.TabIndex = 10
        Me.Button承認.Text = "承認出力"
        Me.Button承認.UseVisualStyleBackColor = True
        '
        'ButtonRIreki
        '
        Me.ButtonRIreki.Location = New System.Drawing.Point(13, 413)
        Me.ButtonRIreki.Name = "ButtonRIreki"
        Me.ButtonRIreki.Size = New System.Drawing.Size(188, 35)
        Me.ButtonRIreki.TabIndex = 11
        Me.ButtonRIreki.Text = "履歴訂正"
        Me.ButtonRIreki.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(213, 488)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonRIreki)
        Me.Controls.Add(Me.Button承認)
        Me.Controls.Add(Me.Button回収管理)
        Me.Controls.Add(Me.Button点検チェック)
        Me.Controls.Add(Me.Button物件管理)
        Me.Controls.Add(Me.Button出庫管理)
        Me.Controls.Add(Me.Button請求管理)
        Me.Controls.Add(Me.Button売上管理)
        Me.Controls.Add(Me.Buttonチェック)
        Me.Controls.Add(Me.Button入力)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.Text = "点検請求管理"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Button入力 As Button
    Friend WithEvents Buttonチェック As Button
    Friend WithEvents Button売上管理 As Button
    Friend WithEvents Button請求管理 As Button
    Friend WithEvents 管理ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents システムマスタToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SQLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ユーザーToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripMenuItem
    Friend WithEvents Button出庫管理 As Button
    Friend WithEvents 更新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 不備ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 技術ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button物件管理 As Button
    Friend WithEvents Button点検チェック As Button
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem不備内容マスタ As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ログ表示ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents Button回収管理 As Button
    Friend WithEvents Button承認 As Button
    Friend WithEvents ButtonRIreki As Button
End Class
