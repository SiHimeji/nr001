<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockImp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockImp))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button取り込み = New System.Windows.Forms.Button()
        Me.TextBoxFileName = New System.Windows.Forms.TextBox()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelMSG = New System.Windows.Forms.Label()
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
        Me.MenuStrip1.Size = New System.Drawing.Size(611, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'Button取り込み
        '
        Me.Button取り込み.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button取り込み.Location = New System.Drawing.Point(403, 89)
        Me.Button取り込み.Margin = New System.Windows.Forms.Padding(2)
        Me.Button取り込み.Name = "Button取り込み"
        Me.Button取り込み.Size = New System.Drawing.Size(190, 37)
        Me.Button取り込み.TabIndex = 1
        Me.Button取り込み.Text = "取り込み"
        Me.Button取り込み.UseVisualStyleBackColor = False
        '
        'TextBoxFileName
        '
        Me.TextBoxFileName.Location = New System.Drawing.Point(57, 43)
        Me.TextBoxFileName.Name = "TextBoxFileName"
        Me.TextBoxFileName.Size = New System.Drawing.Size(455, 19)
        Me.TextBoxFileName.TabIndex = 20
        '
        'Button検索
        '
        Me.Button検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索.Location = New System.Drawing.Point(518, 31)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(75, 46)
        Me.Button検索.TabIndex = 0
        Me.Button検索.Text = "検索"
        Me.Button検索.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 12)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "ファイル"
        '
        'LabelMSG
        '
        Me.LabelMSG.Location = New System.Drawing.Point(55, 89)
        Me.LabelMSG.Name = "LabelMSG"
        Me.LabelMSG.Size = New System.Drawing.Size(305, 37)
        Me.LabelMSG.TabIndex = 22
        '
        'FormStockImp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 148)
        Me.Controls.Add(Me.LabelMSG)
        Me.Controls.Add(Me.Button取り込み)
        Me.Controls.Add(Me.TextBoxFileName)
        Me.Controls.Add(Me.Button検索)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormStockImp"
        Me.Text = "エビス在庫取り込み"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button取り込み As Button
    Friend WithEvents TextBoxFileName As TextBox
    Friend WithEvents Button検索 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelMSG As Label
End Class
