<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNext_B
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNext_B))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonオーダーNo取り込み = New System.Windows.Forms.Button()
        Me.Button出庫出力 = New System.Windows.Forms.Button()
        Me.TextBoxFileName2 = New System.Windows.Forms.TextBox()
        Me.Button検索２ = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxFileName1 = New System.Windows.Forms.TextBox()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label出荷出力 = New System.Windows.Forms.Label()
        Me.Labelオーダー取り込み = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(618, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'ButtonオーダーNo取り込み
        '
        Me.ButtonオーダーNo取り込み.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonオーダーNo取り込み.Location = New System.Drawing.Point(326, 138)
        Me.ButtonオーダーNo取り込み.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonオーダーNo取り込み.Name = "ButtonオーダーNo取り込み"
        Me.ButtonオーダーNo取り込み.Size = New System.Drawing.Size(190, 37)
        Me.ButtonオーダーNo取り込み.TabIndex = 22
        Me.ButtonオーダーNo取り込み.Text = "オーダーNo取り込み"
        Me.ButtonオーダーNo取り込み.UseVisualStyleBackColor = False
        '
        'Button出庫出力
        '
        Me.Button出庫出力.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button出庫出力.Location = New System.Drawing.Point(326, 64)
        Me.Button出庫出力.Margin = New System.Windows.Forms.Padding(2)
        Me.Button出庫出力.Name = "Button出庫出力"
        Me.Button出庫出力.Size = New System.Drawing.Size(190, 37)
        Me.Button出庫出力.TabIndex = 21
        Me.Button出庫出力.Text = "出庫出力"
        Me.Button出庫出力.UseVisualStyleBackColor = False
        '
        'TextBoxFileName2
        '
        Me.TextBoxFileName2.Location = New System.Drawing.Point(71, 115)
        Me.TextBoxFileName2.Name = "TextBoxFileName2"
        Me.TextBoxFileName2.Size = New System.Drawing.Size(445, 19)
        Me.TextBoxFileName2.TabIndex = 20
        '
        'Button検索２
        '
        Me.Button検索２.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索２.Location = New System.Drawing.Point(522, 115)
        Me.Button検索２.Name = "Button検索２"
        Me.Button検索２.Size = New System.Drawing.Size(75, 37)
        Me.Button検索２.TabIndex = 19
        Me.Button検索２.Text = "検索"
        Me.Button検索２.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 12)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "ファイル"
        '
        'TextBoxFileName1
        '
        Me.TextBoxFileName1.Location = New System.Drawing.Point(71, 40)
        Me.TextBoxFileName1.Name = "TextBoxFileName1"
        Me.TextBoxFileName1.Size = New System.Drawing.Size(445, 19)
        Me.TextBoxFileName1.TabIndex = 17
        '
        'Button検索
        '
        Me.Button検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索.Location = New System.Drawing.Point(522, 40)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(75, 37)
        Me.Button検索.TabIndex = 16
        Me.Button検索.Text = "検索"
        Me.Button検索.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 12)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "ファイル"
        '
        'Label出荷出力
        '
        Me.Label出荷出力.Location = New System.Drawing.Point(69, 76)
        Me.Label出荷出力.Name = "Label出荷出力"
        Me.Label出荷出力.Size = New System.Drawing.Size(205, 23)
        Me.Label出荷出力.TabIndex = 23
        '
        'Labelオーダー取り込み
        '
        Me.Labelオーダー取り込み.Location = New System.Drawing.Point(79, 150)
        Me.Labelオーダー取り込み.Name = "Labelオーダー取り込み"
        Me.Labelオーダー取り込み.Size = New System.Drawing.Size(205, 23)
        Me.Labelオーダー取り込み.TabIndex = 24
        '
        'FormNext_B
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 197)
        Me.Controls.Add(Me.Labelオーダー取り込み)
        Me.Controls.Add(Me.Label出荷出力)
        Me.Controls.Add(Me.ButtonオーダーNo取り込み)
        Me.Controls.Add(Me.Button出庫出力)
        Me.Controls.Add(Me.TextBoxFileName2)
        Me.Controls.Add(Me.Button検索２)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxFileName1)
        Me.Controls.Add(Me.Button検索)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormNext_B"
        Me.Text = "NEXTーB出庫処理"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonオーダーNo取り込み As Button
    Friend WithEvents Button出庫出力 As Button
    Friend WithEvents TextBoxFileName2 As TextBox
    Friend WithEvents Button検索２ As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxFileName1 As TextBox
    Friend WithEvents Button検索 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label出荷出力 As Label
    Friend WithEvents Labelオーダー取り込み As Label
End Class
