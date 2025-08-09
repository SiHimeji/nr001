<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMaster))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.期限ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.オーダーToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.在庫ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button製品マスタ = New System.Windows.Forms.Button()
        Me.ButtonLog = New System.Windows.Forms.Button()
        Me.Buttonクーポン = New System.Windows.Forms.Button()
        Me.Button台数割引 = New System.Windows.Forms.Button()
        Me.Button構成マスタ = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.RegToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(508, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'RegToolStripMenuItem
        '
        Me.RegToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DBToolStripMenuItem, Me.期限ToolStripMenuItem, Me.オーダーToolStripMenuItem, Me.在庫ToolStripMenuItem, Me.SQLToolStripMenuItem})
        Me.RegToolStripMenuItem.Name = "RegToolStripMenuItem"
        Me.RegToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.RegToolStripMenuItem.Text = "管理"
        '
        'DBToolStripMenuItem
        '
        Me.DBToolStripMenuItem.Name = "DBToolStripMenuItem"
        Me.DBToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.DBToolStripMenuItem.Text = "接続"
        '
        '期限ToolStripMenuItem
        '
        Me.期限ToolStripMenuItem.Name = "期限ToolStripMenuItem"
        Me.期限ToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.期限ToolStripMenuItem.Text = " DIR"
        '
        'オーダーToolStripMenuItem
        '
        Me.オーダーToolStripMenuItem.Name = "オーダーToolStripMenuItem"
        Me.オーダーToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.オーダーToolStripMenuItem.Text = "オーダー"
        '
        '在庫ToolStripMenuItem
        '
        Me.在庫ToolStripMenuItem.Name = "在庫ToolStripMenuItem"
        Me.在庫ToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.在庫ToolStripMenuItem.Text = "在庫"
        '
        'SQLToolStripMenuItem
        '
        Me.SQLToolStripMenuItem.Name = "SQLToolStripMenuItem"
        Me.SQLToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.SQLToolStripMenuItem.Text = "SQL"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(338, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(157, 44)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "システムマスタ"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(175, 35)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 44)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "ユーザーマスタ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button製品マスタ
        '
        Me.Button製品マスタ.Location = New System.Drawing.Point(12, 35)
        Me.Button製品マスタ.Name = "Button製品マスタ"
        Me.Button製品マスタ.Size = New System.Drawing.Size(157, 44)
        Me.Button製品マスタ.TabIndex = 5
        Me.Button製品マスタ.Text = "製品マスタ"
        Me.Button製品マスタ.UseVisualStyleBackColor = True
        '
        'ButtonLog
        '
        Me.ButtonLog.Location = New System.Drawing.Point(338, 94)
        Me.ButtonLog.Name = "ButtonLog"
        Me.ButtonLog.Size = New System.Drawing.Size(157, 44)
        Me.ButtonLog.TabIndex = 9
        Me.ButtonLog.Text = "Log"
        Me.ButtonLog.UseVisualStyleBackColor = True
        '
        'Buttonクーポン
        '
        Me.Buttonクーポン.Location = New System.Drawing.Point(12, 94)
        Me.Buttonクーポン.Name = "Buttonクーポン"
        Me.Buttonクーポン.Size = New System.Drawing.Size(157, 44)
        Me.Buttonクーポン.TabIndex = 10
        Me.Buttonクーポン.Text = "クーポン"
        Me.Buttonクーポン.UseVisualStyleBackColor = True
        '
        'Button台数割引
        '
        Me.Button台数割引.Location = New System.Drawing.Point(175, 94)
        Me.Button台数割引.Name = "Button台数割引"
        Me.Button台数割引.Size = New System.Drawing.Size(157, 44)
        Me.Button台数割引.TabIndex = 11
        Me.Button台数割引.Text = "台数割引"
        Me.Button台数割引.UseVisualStyleBackColor = True
        '
        'Button構成マスタ
        '
        Me.Button構成マスタ.Location = New System.Drawing.Point(12, 144)
        Me.Button構成マスタ.Name = "Button構成マスタ"
        Me.Button構成マスタ.Size = New System.Drawing.Size(157, 44)
        Me.Button構成マスタ.TabIndex = 12
        Me.Button構成マスタ.Text = "構成マスタ"
        Me.Button構成マスタ.UseVisualStyleBackColor = True
        '
        'FormMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 150)
        Me.Controls.Add(Me.Button構成マスタ)
        Me.Controls.Add(Me.Button台数割引)
        Me.Controls.Add(Me.Buttonクーポン)
        Me.Controls.Add(Me.ButtonLog)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button製品マスタ)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormMaster"
        Me.Text = "マスタ設定"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DBToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 期限ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button製品マスタ As Button
    Friend WithEvents ButtonLog As Button
    Friend WithEvents オーダーToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 在庫ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SQLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Buttonクーポン As Button
    Friend WithEvents Button台数割引 As Button
    Friend WithEvents Button構成マスタ As Button
End Class
