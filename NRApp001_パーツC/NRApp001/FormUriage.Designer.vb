<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUriage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUriage))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button伝票画面 = New System.Windows.Forms.Button()
        Me.ButtonNEXTB伝票番号 = New System.Windows.Forms.Button()
        Me.Button販売実績 = New System.Windows.Forms.Button()
        Me.Buttonキャンセル引当待品 = New System.Windows.Forms.Button()
        Me.Button残明細 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(530, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'Button伝票画面
        '
        Me.Button伝票画面.Location = New System.Drawing.Point(357, 24)
        Me.Button伝票画面.Name = "Button伝票画面"
        Me.Button伝票画面.Size = New System.Drawing.Size(162, 40)
        Me.Button伝票画面.TabIndex = 2
        Me.Button伝票画面.Text = "伝票画面"
        Me.Button伝票画面.UseVisualStyleBackColor = True
        '
        'ButtonNEXTB伝票番号
        '
        Me.ButtonNEXTB伝票番号.Location = New System.Drawing.Point(183, 24)
        Me.ButtonNEXTB伝票番号.Name = "ButtonNEXTB伝票番号"
        Me.ButtonNEXTB伝票番号.Size = New System.Drawing.Size(162, 40)
        Me.ButtonNEXTB伝票番号.TabIndex = 1
        Me.ButtonNEXTB伝票番号.Text = "NEXT-B伝票出力"
        Me.ButtonNEXTB伝票番号.UseVisualStyleBackColor = True
        '
        'Button販売実績
        '
        Me.Button販売実績.Location = New System.Drawing.Point(12, 24)
        Me.Button販売実績.Name = "Button販売実績"
        Me.Button販売実績.Size = New System.Drawing.Size(162, 40)
        Me.Button販売実績.TabIndex = 0
        Me.Button販売実績.Text = "販売実績　取込み"
        Me.Button販売実績.UseVisualStyleBackColor = True
        '
        'Buttonキャンセル引当待品
        '
        Me.Buttonキャンセル引当待品.Location = New System.Drawing.Point(12, 82)
        Me.Buttonキャンセル引当待品.Name = "Buttonキャンセル引当待品"
        Me.Buttonキャンセル引当待品.Size = New System.Drawing.Size(162, 40)
        Me.Buttonキャンセル引当待品.TabIndex = 4
        Me.Buttonキャンセル引当待品.Text = "キャンセル引当待品"
        Me.Buttonキャンセル引当待品.UseVisualStyleBackColor = True
        '
        'Button残明細
        '
        Me.Button残明細.Location = New System.Drawing.Point(357, 82)
        Me.Button残明細.Name = "Button残明細"
        Me.Button残明細.Size = New System.Drawing.Size(162, 40)
        Me.Button残明細.TabIndex = 5
        Me.Button残明細.Text = "残明細"
        Me.Button残明細.UseVisualStyleBackColor = True
        '
        'FormUriage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 138)
        Me.Controls.Add(Me.Button残明細)
        Me.Controls.Add(Me.Buttonキャンセル引当待品)
        Me.Controls.Add(Me.Button伝票画面)
        Me.Controls.Add(Me.ButtonNEXTB伝票番号)
        Me.Controls.Add(Me.Button販売実績)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormUriage"
        Me.Text = "売上処理"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button伝票画面 As Button
    Friend WithEvents ButtonNEXTB伝票番号 As Button
    Friend WithEvents Button販売実績 As Button
    Friend WithEvents Buttonキャンセル引当待品 As Button
    Friend WithEvents Button残明細 As Button
End Class
