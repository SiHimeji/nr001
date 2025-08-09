<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMenu))
        Me.ButtonMaster = New System.Windows.Forms.Button()
        Me.ButtonTyouhyou = New System.Windows.Forms.Button()
        Me.ButtonTOrikomi = New System.Windows.Forms.Button()
        Me.buttonEND = New System.Windows.Forms.Button()
        Me.buttonZaiko = New System.Windows.Forms.Button()
        Me.buttonBuhinSpec = New System.Windows.Forms.Button()
        Me.buttonBuhinTekigou = New System.Windows.Forms.Button()
        Me.buttonShopBuhin = New System.Windows.Forms.Button()
        Me.設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.パスワード変更ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LOGINToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.LabelVer = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonMaster
        '
        Me.ButtonMaster.Location = New System.Drawing.Point(11, 284)
        Me.ButtonMaster.Name = "ButtonMaster"
        Me.ButtonMaster.Size = New System.Drawing.Size(194, 24)
        Me.ButtonMaster.TabIndex = 15
        Me.ButtonMaster.Text = "マスタ"
        Me.ButtonMaster.UseVisualStyleBackColor = True
        '
        'ButtonTyouhyou
        '
        Me.ButtonTyouhyou.Location = New System.Drawing.Point(11, 253)
        Me.ButtonTyouhyou.Name = "ButtonTyouhyou"
        Me.ButtonTyouhyou.Size = New System.Drawing.Size(194, 25)
        Me.ButtonTyouhyou.TabIndex = 14
        Me.ButtonTyouhyou.Text = "帳票出力"
        Me.ButtonTyouhyou.UseVisualStyleBackColor = True
        '
        'ButtonTOrikomi
        '
        Me.ButtonTOrikomi.Location = New System.Drawing.Point(11, 211)
        Me.ButtonTOrikomi.Name = "ButtonTOrikomi"
        Me.ButtonTOrikomi.Size = New System.Drawing.Size(194, 37)
        Me.ButtonTOrikomi.TabIndex = 13
        Me.ButtonTOrikomi.Text = "売上処理"
        Me.ButtonTOrikomi.UseVisualStyleBackColor = True
        '
        'buttonEND
        '
        Me.buttonEND.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.buttonEND.Location = New System.Drawing.Point(11, 314)
        Me.buttonEND.Name = "buttonEND"
        Me.buttonEND.Size = New System.Drawing.Size(194, 37)
        Me.buttonEND.TabIndex = 16
        Me.buttonEND.Text = "終了"
        Me.buttonEND.UseVisualStyleBackColor = False
        '
        'buttonZaiko
        '
        Me.buttonZaiko.Location = New System.Drawing.Point(11, 167)
        Me.buttonZaiko.Name = "buttonZaiko"
        Me.buttonZaiko.Size = New System.Drawing.Size(194, 37)
        Me.buttonZaiko.TabIndex = 12
        Me.buttonZaiko.Text = "在庫管理"
        Me.buttonZaiko.UseVisualStyleBackColor = True
        '
        'buttonBuhinSpec
        '
        Me.buttonBuhinSpec.Location = New System.Drawing.Point(11, 123)
        Me.buttonBuhinSpec.Name = "buttonBuhinSpec"
        Me.buttonBuhinSpec.Size = New System.Drawing.Size(194, 37)
        Me.buttonBuhinSpec.TabIndex = 11
        Me.buttonBuhinSpec.Text = "部品スペック"
        Me.buttonBuhinSpec.UseVisualStyleBackColor = True
        '
        'buttonBuhinTekigou
        '
        Me.buttonBuhinTekigou.Location = New System.Drawing.Point(11, 80)
        Me.buttonBuhinTekigou.Name = "buttonBuhinTekigou"
        Me.buttonBuhinTekigou.Size = New System.Drawing.Size(194, 37)
        Me.buttonBuhinTekigou.TabIndex = 10
        Me.buttonBuhinTekigou.Text = "部品適合機種"
        Me.buttonBuhinTekigou.UseVisualStyleBackColor = True
        '
        'buttonShopBuhin
        '
        Me.buttonShopBuhin.Location = New System.Drawing.Point(11, 35)
        Me.buttonShopBuhin.Name = "buttonShopBuhin"
        Me.buttonShopBuhin.Size = New System.Drawing.Size(194, 40)
        Me.buttonShopBuhin.TabIndex = 9
        Me.buttonShopBuhin.Text = "ショップ登録用部品"
        Me.buttonShopBuhin.UseVisualStyleBackColor = True
        '
        '設定ToolStripMenuItem
        '
        Me.設定ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.パスワード変更ToolStripMenuItem, Me.LOGINToolStripMenuItem})
        Me.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem"
        Me.設定ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.設定ToolStripMenuItem.Text = "設定"
        '
        'パスワード変更ToolStripMenuItem
        '
        Me.パスワード変更ToolStripMenuItem.Name = "パスワード変更ToolStripMenuItem"
        Me.パスワード変更ToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.パスワード変更ToolStripMenuItem.Text = "パスワード変更"
        '
        'LOGINToolStripMenuItem
        '
        Me.LOGINToolStripMenuItem.Name = "LOGINToolStripMenuItem"
        Me.LOGINToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.LOGINToolStripMenuItem.Text = "ログイン"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.設定ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(215, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LabelVer
        '
        Me.LabelVer.Location = New System.Drawing.Point(52, 4)
        Me.LabelVer.Name = "LabelVer"
        Me.LabelVer.Size = New System.Drawing.Size(154, 20)
        Me.LabelVer.TabIndex = 18
        Me.LabelVer.Text = "Version"
        '
        'FormMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(215, 356)
        Me.Controls.Add(Me.LabelVer)
        Me.Controls.Add(Me.ButtonMaster)
        Me.Controls.Add(Me.ButtonTyouhyou)
        Me.Controls.Add(Me.ButtonTOrikomi)
        Me.Controls.Add(Me.buttonEND)
        Me.Controls.Add(Me.buttonZaiko)
        Me.Controls.Add(Me.buttonBuhinSpec)
        Me.Controls.Add(Me.buttonBuhinTekigou)
        Me.Controls.Add(Me.buttonShopBuhin)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FormMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "パーツC"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents ButtonMaster As Button
    Private WithEvents ButtonTyouhyou As Button
    Private WithEvents ButtonTOrikomi As Button
    Private WithEvents buttonEND As Button
    Private WithEvents buttonZaiko As Button
    Private WithEvents buttonBuhinSpec As Button
    Private WithEvents buttonBuhinTekigou As Button
    Private WithEvents buttonShopBuhin As Button
    Friend WithEvents 設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents パスワード変更ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LOGINToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LabelVer As Label
End Class
