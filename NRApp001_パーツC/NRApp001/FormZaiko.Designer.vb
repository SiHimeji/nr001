<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormZaiko
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormZaiko))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ストック残ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonNextB = New System.Windows.Forms.Button()
        Me.Button未着取り込み = New System.Windows.Forms.Button()
        Me.ebisumart在庫取込 = New System.Windows.Forms.Button()
        Me.Button在庫管理 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.ストック残ToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(587, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'ストック残ToolStripMenuItem
        '
        Me.ストック残ToolStripMenuItem.Name = "ストック残ToolStripMenuItem"
        Me.ストック残ToolStripMenuItem.Size = New System.Drawing.Size(31, 20)
        Me.ストック残ToolStripMenuItem.Text = "　"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(31, 20)
        Me.ToolStripMenuItem1.Text = "　"
        '
        'ButtonNextB
        '
        Me.ButtonNextB.Location = New System.Drawing.Point(445, 37)
        Me.ButtonNextB.Name = "ButtonNextB"
        Me.ButtonNextB.Size = New System.Drawing.Size(129, 45)
        Me.ButtonNextB.TabIndex = 3
        Me.ButtonNextB.Text = "NEXT-B出力"
        Me.ButtonNextB.UseVisualStyleBackColor = True
        '
        'Button未着取り込み
        '
        Me.Button未着取り込み.Location = New System.Drawing.Point(154, 37)
        Me.Button未着取り込み.Name = "Button未着取り込み"
        Me.Button未着取り込み.Size = New System.Drawing.Size(129, 45)
        Me.Button未着取り込み.TabIndex = 1
        Me.Button未着取り込み.Text = "未着取り込み"
        Me.Button未着取り込み.UseVisualStyleBackColor = True
        '
        'ebisumart在庫取込
        '
        Me.ebisumart在庫取込.Location = New System.Drawing.Point(7, 37)
        Me.ebisumart在庫取込.Name = "ebisumart在庫取込"
        Me.ebisumart在庫取込.Size = New System.Drawing.Size(129, 45)
        Me.ebisumart在庫取込.TabIndex = 0
        Me.ebisumart在庫取込.Text = "ebisumart在庫取込"
        Me.ebisumart在庫取込.UseVisualStyleBackColor = True
        '
        'Button在庫管理
        '
        Me.Button在庫管理.Location = New System.Drawing.Point(299, 37)
        Me.Button在庫管理.Name = "Button在庫管理"
        Me.Button在庫管理.Size = New System.Drawing.Size(129, 45)
        Me.Button在庫管理.TabIndex = 2
        Me.Button在庫管理.Text = "在庫管理"
        Me.Button在庫管理.UseVisualStyleBackColor = True
        '
        'FormZaiko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 101)
        Me.Controls.Add(Me.Button在庫管理)
        Me.Controls.Add(Me.ButtonNextB)
        Me.Controls.Add(Me.Button未着取り込み)
        Me.Controls.Add(Me.ebisumart在庫取込)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormZaiko"
        Me.Text = "在庫管理"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonNextB As Button
    Friend WithEvents Button未着取り込み As Button
    Friend WithEvents ebisumart在庫取込 As Button
    Friend WithEvents Button在庫管理 As Button
    Friend WithEvents ストック残ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
End Class
