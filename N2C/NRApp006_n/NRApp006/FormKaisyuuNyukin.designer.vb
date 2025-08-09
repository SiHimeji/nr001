<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKaisyuuNyukin
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.検索ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.取込みToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.更新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MaskedTextBox請求日e = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox請求日s = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MaskedTextBox売上日e = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox売上日s = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox全件対象 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.閉じるToolStripMenuItem, Me.検索ToolStripMenuItem, Me.出力ToolStripMenuItem1, Me.取込みToolStripMenuItem, Me.更新ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1029, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '閉じるToolStripMenuItem
        '
        Me.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem"
        Me.閉じるToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.閉じるToolStripMenuItem.Text = "閉じる"
        '
        '検索ToolStripMenuItem
        '
        Me.検索ToolStripMenuItem.Name = "検索ToolStripMenuItem"
        Me.検索ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.検索ToolStripMenuItem.Text = "検索"
        '
        '出力ToolStripMenuItem1
        '
        Me.出力ToolStripMenuItem1.Name = "出力ToolStripMenuItem1"
        Me.出力ToolStripMenuItem1.Size = New System.Drawing.Size(43, 20)
        Me.出力ToolStripMenuItem1.Text = "出力"
        '
        '取込みToolStripMenuItem
        '
        Me.取込みToolStripMenuItem.Name = "取込みToolStripMenuItem"
        Me.取込みToolStripMenuItem.Size = New System.Drawing.Size(117, 20)
        Me.取込みToolStripMenuItem.Text = "入金処理日 取込み"
        '
        '更新ToolStripMenuItem
        '
        Me.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem"
        Me.更新ToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.更新ToolStripMenuItem.Text = "【更新】"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 437)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1029, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(980, 16)
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1029, 290)
        Me.DataGridView1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(314, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "←実行するまで取込みデータは更新されません"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox請求日e)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox請求日s)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox売上日e)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox売上日s)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox全件対象)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1029, 413)
        Me.SplitContainer1.SplitterDistance = 119
        Me.SplitContainer1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(384, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(280, 12)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "この場合、売上日欄には売上日は一つしか表示されません"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(233, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "～"
        '
        'MaskedTextBox請求日e
        '
        Me.MaskedTextBox請求日e.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBox請求日e.Location = New System.Drawing.Point(263, 37)
        Me.MaskedTextBox請求日e.Mask = "0000/00/00"
        Me.MaskedTextBox請求日e.Name = "MaskedTextBox請求日e"
        Me.MaskedTextBox請求日e.Size = New System.Drawing.Size(100, 23)
        Me.MaskedTextBox請求日e.TabIndex = 2
        Me.MaskedTextBox請求日e.ValidatingType = GetType(Date)
        '
        'MaskedTextBox請求日s
        '
        Me.MaskedTextBox請求日s.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBox請求日s.Location = New System.Drawing.Point(127, 37)
        Me.MaskedTextBox請求日s.Mask = "0000/00/00"
        Me.MaskedTextBox請求日s.Name = "MaskedTextBox請求日s"
        Me.MaskedTextBox請求日s.Size = New System.Drawing.Size(100, 23)
        Me.MaskedTextBox請求日s.TabIndex = 1
        Me.MaskedTextBox請求日s.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(371, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(382, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "※一つの請求書番号に対して複数件の受付番号が含まれている場合があります"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(233, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "～"
        '
        'MaskedTextBox売上日e
        '
        Me.MaskedTextBox売上日e.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBox売上日e.Location = New System.Drawing.Point(263, 73)
        Me.MaskedTextBox売上日e.Mask = "0000/00/00"
        Me.MaskedTextBox売上日e.Name = "MaskedTextBox売上日e"
        Me.MaskedTextBox売上日e.Size = New System.Drawing.Size(100, 23)
        Me.MaskedTextBox売上日e.TabIndex = 4
        Me.MaskedTextBox売上日e.ValidatingType = GetType(Date)
        '
        'MaskedTextBox売上日s
        '
        Me.MaskedTextBox売上日s.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MaskedTextBox売上日s.Location = New System.Drawing.Point(127, 73)
        Me.MaskedTextBox売上日s.Mask = "0000/00/00"
        Me.MaskedTextBox売上日s.Name = "MaskedTextBox売上日s"
        Me.MaskedTextBox売上日s.Size = New System.Drawing.Size(100, 23)
        Me.MaskedTextBox売上日s.TabIndex = 3
        Me.MaskedTextBox売上日s.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(65, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "売上日"
        '
        'CheckBox全件対象
        '
        Me.CheckBox全件対象.AutoSize = True
        Me.CheckBox全件対象.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox全件対象.Location = New System.Drawing.Point(68, 12)
        Me.CheckBox全件対象.Name = "CheckBox全件対象"
        Me.CheckBox全件対象.Size = New System.Drawing.Size(91, 20)
        Me.CheckBox全件対象.TabIndex = 0
        Me.CheckBox全件対象.Text = "全件対象"
        Me.CheckBox全件対象.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(65, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "請求日"
        '
        'FormKaisyuuNyukin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 459)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormKaisyuuNyukin"
        Me.Text = "入金連絡"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 検索ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 取込みToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents 更新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBox全件対象 As CheckBox
    Friend WithEvents 出力ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Label5 As Label
    Friend WithEvents MaskedTextBox売上日e As MaskedTextBox
    Friend WithEvents MaskedTextBox売上日s As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents MaskedTextBox請求日e As MaskedTextBox
    Friend WithEvents MaskedTextBox請求日s As MaskedTextBox
    Friend WithEvents Label3 As Label
End Class
