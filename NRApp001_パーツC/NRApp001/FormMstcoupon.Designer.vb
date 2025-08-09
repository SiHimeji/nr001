<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMstcoupon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMstcoupon))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.S終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.入力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.CSVToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.削除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.クーポン番号で削除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label割引 = New System.Windows.Forms.Label()
        Me.TextBox割引 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DateTimePicker期間2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker期間1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button品コード検索 = New System.Windows.Forms.Button()
        Me.TextBox品コード = New System.Windows.Forms.TextBox()
        Me.ComboBoxJy2 = New System.Windows.Forms.ComboBox()
        Me.Button検索2 = New System.Windows.Forms.Button()
        Me.TextBoxクーポン番号 = New System.Windows.Forms.TextBox()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.Button削除 = New System.Windows.Forms.Button()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.Button検索１ = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox更新日 = New System.Windows.Forms.TextBox()
        Me.修正ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.期間一括修正ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.S終了ToolStripMenuItem, Me.出力ToolStripMenuItem, Me.入力ToolStripMenuItem, Me.件ToolStripMenuItem, Me.ToolStripMenuItem1, Me.削除ToolStripMenuItem, Me.修正ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(703, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'S終了ToolStripMenuItem
        '
        Me.S終了ToolStripMenuItem.Name = "S終了ToolStripMenuItem"
        Me.S終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.S終了ToolStripMenuItem.Text = "終了"
        '
        '出力ToolStripMenuItem
        '
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CSVToolStripMenuItem, Me.EXCELToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.CSVToolStripMenuItem.Text = "CSV"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        '入力ToolStripMenuItem
        '
        Me.入力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1, Me.CSVToolStripMenuItem1, Me.EXCELToolStripMenuItem1})
        Me.入力ToolStripMenuItem.Name = "入力ToolStripMenuItem"
        Me.入力ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.入力ToolStripMenuItem.Text = "入力"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"入れ替え", "追加"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 23)
        '
        'CSVToolStripMenuItem1
        '
        Me.CSVToolStripMenuItem1.Name = "CSVToolStripMenuItem1"
        Me.CSVToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.CSVToolStripMenuItem1.Text = "CSV"
        '
        'EXCELToolStripMenuItem1
        '
        Me.EXCELToolStripMenuItem1.Name = "EXCELToolStripMenuItem1"
        Me.EXCELToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.EXCELToolStripMenuItem1.Text = "EXCEL"
        '
        '件ToolStripMenuItem
        '
        Me.件ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.件ToolStripMenuItem.Name = "件ToolStripMenuItem"
        Me.件ToolStripMenuItem.Size = New System.Drawing.Size(31, 20)
        Me.件ToolStripMenuItem.Text = "件"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(31, 20)
        Me.ToolStripMenuItem1.Text = "    "
        '
        '削除ToolStripMenuItem
        '
        Me.削除ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.クーポン番号で削除ToolStripMenuItem})
        Me.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem"
        Me.削除ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.削除ToolStripMenuItem.Text = "削除"
        '
        'クーポン番号で削除ToolStripMenuItem
        '
        Me.クーポン番号で削除ToolStripMenuItem.Name = "クーポン番号で削除ToolStripMenuItem"
        Me.クーポン番号で削除ToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.クーポン番号で削除ToolStripMenuItem.Text = "クーポン番号で削除"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker期間2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker期間1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button品コード検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox品コード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxクーポン番号)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button削除)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button更新)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索１)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(703, 453)
        Me.SplitContainer1.SplitterDistance = 191
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Label割引)
        Me.GroupBox1.Controls.Add(Me.TextBox割引)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 75)
        Me.GroupBox1.TabIndex = 139
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "割引"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(127, 12)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton2.TabIndex = 134
        Me.RadioButton2.Text = "金額"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(52, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(49, 16)
        Me.RadioButton1.TabIndex = 133
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "率(%)"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label割引
        '
        Me.Label割引.AutoSize = True
        Me.Label割引.Location = New System.Drawing.Point(6, 43)
        Me.Label割引.Name = "Label割引"
        Me.Label割引.Size = New System.Drawing.Size(55, 12)
        Me.Label割引.TabIndex = 131
        Me.Label割引.Text = "割引率(%)"
        '
        'TextBox割引
        '
        Me.TextBox割引.Location = New System.Drawing.Point(67, 40)
        Me.TextBox割引.MaxLength = 20
        Me.TextBox割引.Name = "TextBox割引"
        Me.TextBox割引.Size = New System.Drawing.Size(146, 19)
        Me.TextBox割引.TabIndex = 132
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(244, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 138
        Me.Label8.Text = "～"
        '
        'DateTimePicker期間2
        '
        Me.DateTimePicker期間2.Location = New System.Drawing.Point(274, 154)
        Me.DateTimePicker期間2.Name = "DateTimePicker期間2"
        Me.DateTimePicker期間2.Size = New System.Drawing.Size(144, 19)
        Me.DateTimePicker期間2.TabIndex = 137
        '
        'DateTimePicker期間1
        '
        Me.DateTimePicker期間1.Location = New System.Drawing.Point(80, 154)
        Me.DateTimePicker期間1.Name = "DateTimePicker期間1"
        Me.DateTimePicker期間1.Size = New System.Drawing.Size(144, 19)
        Me.DateTimePicker期間1.TabIndex = 136
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 135
        Me.Label7.Text = "割引期間"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 12)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "品コード"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 12)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "クーポン番号"
        '
        'Button品コード検索
        '
        Me.Button品コード検索.Location = New System.Drawing.Point(235, 40)
        Me.Button品コード検索.Name = "Button品コード検索"
        Me.Button品コード検索.Size = New System.Drawing.Size(33, 23)
        Me.Button品コード検索.TabIndex = 128
        Me.Button品コード検索.UseVisualStyleBackColor = True
        '
        'TextBox品コード
        '
        Me.TextBox品コード.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox品コード.Location = New System.Drawing.Point(86, 42)
        Me.TextBox品コード.MaxLength = 10
        Me.TextBox品コード.Name = "TextBox品コード"
        Me.TextBox品コード.Size = New System.Drawing.Size(146, 19)
        Me.TextBox品コード.TabIndex = 51
        '
        'ComboBoxJy2
        '
        Me.ComboBoxJy2.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy2.FormattingEnabled = True
        Me.ComboBoxJy2.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy2.Location = New System.Drawing.Point(276, 41)
        Me.ComboBoxJy2.Name = "ComboBoxJy2"
        Me.ComboBoxJy2.Size = New System.Drawing.Size(58, 20)
        Me.ComboBoxJy2.TabIndex = 49
        '
        'Button検索2
        '
        Me.Button検索2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索2.Location = New System.Drawing.Point(340, 39)
        Me.Button検索2.Name = "Button検索2"
        Me.Button検索2.Size = New System.Drawing.Size(75, 25)
        Me.Button検索2.TabIndex = 50
        Me.Button検索2.Text = "検索"
        Me.Button検索2.UseVisualStyleBackColor = False
        '
        'TextBoxクーポン番号
        '
        Me.TextBoxクーポン番号.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxクーポン番号.Location = New System.Drawing.Point(86, 14)
        Me.TextBoxクーポン番号.MaxLength = 30
        Me.TextBoxクーポン番号.Name = "TextBoxクーポン番号"
        Me.TextBoxクーポン番号.Size = New System.Drawing.Size(185, 19)
        Me.TextBoxクーポン番号.TabIndex = 48
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(276, 13)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(58, 20)
        Me.ComboBoxJy1.TabIndex = 42
        '
        'Button削除
        '
        Me.Button削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button削除.Location = New System.Drawing.Point(589, 5)
        Me.Button削除.Name = "Button削除"
        Me.Button削除.Size = New System.Drawing.Size(75, 23)
        Me.Button削除.TabIndex = 45
        Me.Button削除.Text = "削除"
        Me.Button削除.UseVisualStyleBackColor = False
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(508, 5)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(75, 23)
        Me.Button更新.TabIndex = 44
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'Button検索１
        '
        Me.Button検索１.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索１.Location = New System.Drawing.Point(340, 11)
        Me.Button検索１.Name = "Button検索１"
        Me.Button検索１.Size = New System.Drawing.Size(75, 25)
        Me.Button検索１.TabIndex = 43
        Me.Button検索１.Text = "検索"
        Me.Button検索１.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-56, 120)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 12)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "SEQ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-58, 95)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "区分"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column7, Me.Column8, Me.Column9, Me.Column4, Me.Column5, Me.Column6})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(703, 258)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "クーポン番号"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 120
        '
        'Column2
        '
        Me.Column2.HeaderText = "品コード"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "割引率"
        Me.Column3.Name = "Column3"
        '
        'Column7
        '
        Me.Column7.HeaderText = "割引金額"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "割引期間から"
        Me.Column8.Name = "Column8"
        '
        'Column9
        '
        Me.Column9.HeaderText = "割引期間まで"
        Me.Column9.Name = "Column9"
        '
        'Column4
        '
        Me.Column4.HeaderText = "登録時間"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "更新時間"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "更新者"
        Me.Column6.Name = "Column6"
        '
        'TextBox更新日
        '
        Me.TextBox更新日.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox更新日.Location = New System.Drawing.Point(514, 3)
        Me.TextBox更新日.Name = "TextBox更新日"
        Me.TextBox更新日.ReadOnly = True
        Me.TextBox更新日.Size = New System.Drawing.Size(150, 12)
        Me.TextBox更新日.TabIndex = 133
        '
        '修正ToolStripMenuItem
        '
        Me.修正ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.期間一括修正ToolStripMenuItem})
        Me.修正ToolStripMenuItem.Name = "修正ToolStripMenuItem"
        Me.修正ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.修正ToolStripMenuItem.Text = "修正"
        '
        '期間一括修正ToolStripMenuItem
        '
        Me.期間一括修正ToolStripMenuItem.Name = "期間一括修正ToolStripMenuItem"
        Me.期間一括修正ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.期間一括修正ToolStripMenuItem.Text = "期間一括修正"
        '
        'FormMstcoupon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 477)
        Me.Controls.Add(Me.TextBox更新日)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMstcoupon"
        Me.Text = "クーポンマスタ"
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
    Friend WithEvents S終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox品コード As TextBox
    Friend WithEvents ComboBoxJy2 As ComboBox
    Friend WithEvents Button検索2 As Button
    Friend WithEvents TextBoxクーポン番号 As TextBox
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents Button削除 As Button
    Friend WithEvents Button更新 As Button
    Friend WithEvents Button検索１ As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox更新日 As TextBox
    Friend WithEvents TextBox割引 As TextBox
    Friend WithEvents Label割引 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button品コード検索 As Button
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label8 As Label
    Friend WithEvents DateTimePicker期間2 As DateTimePicker
    Friend WithEvents DateTimePicker期間1 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents 入力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 削除ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents クーポン番号で削除ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 修正ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 期間一括修正ToolStripMenuItem As ToolStripMenuItem
End Class
