<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSelectSeihin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSelectSeihin))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.キャンセルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton全部 = New System.Windows.Forms.RadioButton()
        Me.RadioButton機種 = New System.Windows.Forms.RadioButton()
        Me.RadioButton部品 = New System.Windows.Forms.RadioButton()
        Me.Button決定 = New System.Windows.Forms.Button()
        Me.Button検索２ = New System.Windows.Forms.Button()
        Me.ComboBoxJy2 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.Button検索１ = New System.Windows.Forms.Button()
        Me.TextBox商品名 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox品コード = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.キャンセルToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(509, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'キャンセルToolStripMenuItem
        '
        Me.キャンセルToolStripMenuItem.Name = "キャンセルToolStripMenuItem"
        Me.キャンセルToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.キャンセルToolStripMenuItem.Text = "キャンセル"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button決定)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索２)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索１)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox商品名)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox品コード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(509, 176)
        Me.SplitContainer1.SplitterDistance = 87
        Me.SplitContainer1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton全部)
        Me.GroupBox1.Controls.Add(Me.RadioButton機種)
        Me.GroupBox1.Controls.Add(Me.RadioButton部品)
        Me.GroupBox1.Location = New System.Drawing.Point(186, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 24)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        '
        'RadioButton全部
        '
        Me.RadioButton全部.AutoSize = True
        Me.RadioButton全部.Checked = True
        Me.RadioButton全部.Location = New System.Drawing.Point(5, 7)
        Me.RadioButton全部.Name = "RadioButton全部"
        Me.RadioButton全部.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton全部.TabIndex = 2
        Me.RadioButton全部.TabStop = True
        Me.RadioButton全部.Text = "全部"
        Me.RadioButton全部.UseVisualStyleBackColor = True
        '
        'RadioButton機種
        '
        Me.RadioButton機種.AutoSize = True
        Me.RadioButton機種.Location = New System.Drawing.Point(120, 7)
        Me.RadioButton機種.Name = "RadioButton機種"
        Me.RadioButton機種.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton機種.TabIndex = 1
        Me.RadioButton機種.Text = "機種"
        Me.RadioButton機種.UseVisualStyleBackColor = True
        '
        'RadioButton部品
        '
        Me.RadioButton部品.AutoSize = True
        Me.RadioButton部品.Location = New System.Drawing.Point(62, 7)
        Me.RadioButton部品.Name = "RadioButton部品"
        Me.RadioButton部品.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton部品.TabIndex = 0
        Me.RadioButton部品.Text = "部品"
        Me.RadioButton部品.UseVisualStyleBackColor = True
        '
        'Button決定
        '
        Me.Button決定.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button決定.Location = New System.Drawing.Point(82, 60)
        Me.Button決定.Name = "Button決定"
        Me.Button決定.Size = New System.Drawing.Size(75, 25)
        Me.Button決定.TabIndex = 37
        Me.Button決定.Text = "決定"
        Me.Button決定.UseCompatibleTextRendering = True
        Me.Button決定.UseVisualStyleBackColor = False
        '
        'Button検索２
        '
        Me.Button検索２.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索２.Location = New System.Drawing.Point(421, 34)
        Me.Button検索２.Name = "Button検索２"
        Me.Button検索２.Size = New System.Drawing.Size(75, 25)
        Me.Button検索２.TabIndex = 36
        Me.Button検索２.Text = "検索"
        Me.Button検索２.UseVisualStyleBackColor = False
        '
        'ComboBoxJy2
        '
        Me.ComboBoxJy2.AutoCompleteCustomSource.AddRange(New String() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy2.FormattingEnabled = True
        Me.ComboBoxJy2.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy2.Location = New System.Drawing.Point(341, 35)
        Me.ComboBoxJy2.Name = "ComboBoxJy2"
        Me.ComboBoxJy2.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy2.TabIndex = 34
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(342, 9)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy1.TabIndex = 31
        '
        'Button検索１
        '
        Me.Button検索１.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索１.Location = New System.Drawing.Point(421, 8)
        Me.Button検索１.Name = "Button検索１"
        Me.Button検索１.Size = New System.Drawing.Size(75, 25)
        Me.Button検索１.TabIndex = 32
        Me.Button検索１.Text = "検索"
        Me.Button検索１.UseVisualStyleBackColor = False
        '
        'TextBox商品名
        '
        Me.TextBox商品名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox商品名.Location = New System.Drawing.Point(82, 37)
        Me.TextBox商品名.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox商品名.Name = "TextBox商品名"
        Me.TextBox商品名.Size = New System.Drawing.Size(252, 19)
        Me.TextBox商品名.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "商品名"
        '
        'TextBox品コード
        '
        Me.TextBox品コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox品コード.Location = New System.Drawing.Point(82, 11)
        Me.TextBox品コード.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox品コード.MaxLength = 10
        Me.TextBox品コード.Name = "TextBox品コード"
        Me.TextBox品コード.Size = New System.Drawing.Size(116, 19)
        Me.TextBox品コード.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "商品番号"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(509, 85)
        Me.DataGridView1.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "品コード"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "製品名"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "カテゴリ"
        Me.Column3.Name = "Column3"
        '
        'FormSelectSeihin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 200)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSelectSeihin"
        Me.Text = "品コード選択"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents キャンセルToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Button検索２ As Button
    Friend WithEvents ComboBoxJy2 As ComboBox
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents Button検索１ As Button
    Friend WithEvents TextBox商品名 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox品コード As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button決定 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton機種 As RadioButton
    Friend WithEvents RadioButton部品 As RadioButton
    Friend WithEvents RadioButton全部 As RadioButton
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
