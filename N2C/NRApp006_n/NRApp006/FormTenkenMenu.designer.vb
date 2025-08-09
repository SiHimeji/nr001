<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTenkenMenu
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTenkenMenu))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button点検チェック = New System.Windows.Forms.Button()
        Me.Button点検結果表チェック数日計表 = New System.Windows.Forms.Button()
        Me.Button点検結果表チェック3 = New System.Windows.Forms.Button()
        Me.Button点検結果表チェック不備 = New System.Windows.Forms.Button()
        Me.Button点検結果表チェック明細 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(556, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'Button点検チェック
        '
        Me.Button点検チェック.Location = New System.Drawing.Point(12, 27)
        Me.Button点検チェック.Name = "Button点検チェック"
        Me.Button点検チェック.Size = New System.Drawing.Size(175, 96)
        Me.Button点検チェック.TabIndex = 1
        Me.Button点検チェック.Text = "チェック画面"
        Me.Button点検チェック.UseVisualStyleBackColor = True
        '
        'Button点検結果表チェック数日計表
        '
        Me.Button点検結果表チェック数日計表.Location = New System.Drawing.Point(193, 27)
        Me.Button点検結果表チェック数日計表.Name = "Button点検結果表チェック数日計表"
        Me.Button点検結果表チェック数日計表.Size = New System.Drawing.Size(175, 45)
        Me.Button点検結果表チェック数日計表.TabIndex = 3
        Me.Button点検結果表チェック数日計表.Text = "点検結果表チェック数日計表"
        Me.Button点検結果表チェック数日計表.UseVisualStyleBackColor = True
        '
        'Button点検結果表チェック3
        '
        Me.Button点検結果表チェック3.Location = New System.Drawing.Point(374, 27)
        Me.Button点検結果表チェック3.Name = "Button点検結果表チェック3"
        Me.Button点検結果表チェック3.Size = New System.Drawing.Size(175, 45)
        Me.Button点検結果表チェック3.TabIndex = 4
        Me.Button点検結果表チェック3.Text = "点検結果表チェック「3」再訪問依頼リスト"
        Me.Button点検結果表チェック3.UseVisualStyleBackColor = True
        '
        'Button点検結果表チェック不備
        '
        Me.Button点検結果表チェック不備.Location = New System.Drawing.Point(374, 78)
        Me.Button点検結果表チェック不備.Name = "Button点検結果表チェック不備"
        Me.Button点検結果表チェック不備.Size = New System.Drawing.Size(175, 45)
        Me.Button点検結果表チェック不備.TabIndex = 5
        Me.Button点検結果表チェック不備.Text = "点検結果表チェック不備"
        Me.Button点検結果表チェック不備.UseVisualStyleBackColor = True
        '
        'Button点検結果表チェック明細
        '
        Me.Button点検結果表チェック明細.Location = New System.Drawing.Point(193, 78)
        Me.Button点検結果表チェック明細.Name = "Button点検結果表チェック明細"
        Me.Button点検結果表チェック明細.Size = New System.Drawing.Size(175, 45)
        Me.Button点検結果表チェック明細.TabIndex = 6
        Me.Button点検結果表チェック明細.Text = "点検結果表チェック明細"
        Me.Button点検結果表チェック明細.UseVisualStyleBackColor = True
        '
        'FormTenkenMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 140)
        Me.Controls.Add(Me.Button点検結果表チェック明細)
        Me.Controls.Add(Me.Button点検結果表チェック不備)
        Me.Controls.Add(Me.Button点検結果表チェック3)
        Me.Controls.Add(Me.Button点検結果表チェック数日計表)
        Me.Controls.Add(Me.Button点検チェック)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormTenkenMenu"
        Me.Text = "品質チェックメニュー"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button点検チェック As Button
    Friend WithEvents Button点検結果表チェック数日計表 As Button
    Friend WithEvents Button点検結果表チェック3 As Button
    Friend WithEvents Button点検結果表チェック不備 As Button
    Friend WithEvents Button点検結果表チェック明細 As Button
End Class
