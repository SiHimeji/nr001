<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKaisyuMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKaisyuMenu))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button回収管理 = New System.Windows.Forms.Button()
        Me.Button残明細出力 = New System.Windows.Forms.Button()
        Me.Button入金連絡票 = New System.Windows.Forms.Button()
        Me.Buttonss請求取込み = New System.Windows.Forms.Button()
        Me.Button安心プラン消費税 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(518, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'Button回収管理
        '
        Me.Button回収管理.Location = New System.Drawing.Point(12, 27)
        Me.Button回収管理.Name = "Button回収管理"
        Me.Button回収管理.Size = New System.Drawing.Size(146, 82)
        Me.Button回収管理.TabIndex = 1
        Me.Button回収管理.Text = "回収チェック"
        Me.Button回収管理.UseVisualStyleBackColor = True
        '
        'Button残明細出力
        '
        Me.Button残明細出力.Location = New System.Drawing.Point(345, 71)
        Me.Button残明細出力.Name = "Button残明細出力"
        Me.Button残明細出力.Size = New System.Drawing.Size(146, 38)
        Me.Button残明細出力.TabIndex = 5
        Me.Button残明細出力.Text = "残明細"
        Me.Button残明細出力.UseVisualStyleBackColor = True
        '
        'Button入金連絡票
        '
        Me.Button入金連絡票.Location = New System.Drawing.Point(176, 27)
        Me.Button入金連絡票.Name = "Button入金連絡票"
        Me.Button入金連絡票.Size = New System.Drawing.Size(146, 38)
        Me.Button入金連絡票.TabIndex = 2
        Me.Button入金連絡票.Text = "入金連絡票"
        Me.Button入金連絡票.UseVisualStyleBackColor = True
        '
        'Buttonss請求取込み
        '
        Me.Buttonss請求取込み.Location = New System.Drawing.Point(176, 71)
        Me.Buttonss請求取込み.Name = "Buttonss請求取込み"
        Me.Buttonss請求取込み.Size = New System.Drawing.Size(146, 38)
        Me.Buttonss請求取込み.TabIndex = 3
        Me.Buttonss請求取込み.Text = "ss請求取込み"
        Me.Buttonss請求取込み.UseVisualStyleBackColor = True
        '
        'Button安心プラン消費税
        '
        Me.Button安心プラン消費税.Location = New System.Drawing.Point(345, 27)
        Me.Button安心プラン消費税.Name = "Button安心プラン消費税"
        Me.Button安心プラン消費税.Size = New System.Drawing.Size(146, 38)
        Me.Button安心プラン消費税.TabIndex = 4
        Me.Button安心プラン消費税.Text = "安心プラン消費税"
        Me.Button安心プラン消費税.UseVisualStyleBackColor = True
        '
        'FormKaisyuMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 128)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button安心プラン消費税)
        Me.Controls.Add(Me.Buttonss請求取込み)
        Me.Controls.Add(Me.Button入金連絡票)
        Me.Controls.Add(Me.Button残明細出力)
        Me.Controls.Add(Me.Button回収管理)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormKaisyuMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "回収管理メニュー"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button回収管理 As Button
    Friend WithEvents Button残明細出力 As Button
    Friend WithEvents Button入金連絡票 As Button
    Friend WithEvents Buttonss請求取込み As Button
    Friend WithEvents Button安心プラン消費税 As Button
End Class
