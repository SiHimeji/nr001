<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMstSeihin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMstSeihin))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.入力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ブランドからマージToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.在庫ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.更新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.NumericUpDown単位 = New System.Windows.Forms.NumericUpDown()
        Me.CheckBox個別 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox部品スペック = New System.Windows.Forms.CheckBox()
        Me.CheckBoxショップ登録用部品 = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ComboBoxガス種 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox相手先品番 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ComboBox在庫種類 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxカテゴリ = New System.Windows.Forms.ComboBox()
        Me.MaskedTextBox廃止予定日 = New System.Windows.Forms.MaskedTextBox()
        Me.DateTimePicker廃止予定日 = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.MaskedTextBoxAS供給停止日 = New System.Windows.Forms.MaskedTextBox()
        Me.DateTimePickerAS供給停止日 = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox保有年 = New System.Windows.Forms.TextBox()
        Me.TextBox原価 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox納入数 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox製品 = New System.Windows.Forms.ComboBox()
        Me.TextBox販売価格 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox注文残 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox現在庫 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.MaskedTextBox廃止日 = New System.Windows.Forms.MaskedTextBox()
        Me.DateTimePicker廃止日 = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxk基準在庫 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox得意先コード = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox入力振分 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxメーカー = New System.Windows.Forms.ComboBox()
        Me.ComboBox倉庫 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button検索３ = New System.Windows.Forms.Button()
        Me.Button検索２ = New System.Windows.Forms.Button()
        Me.ComboBoxJy3 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy2 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.Button削除 = New System.Windows.Forms.Button()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.Button検索１ = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox商品名 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox品コード = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox更新日 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericUpDown単位, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.出力ToolStripMenuItem, Me.入力ToolStripMenuItem, Me.在庫ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1046, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '出力ToolStripMenuItem
        '
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem, Me.CSVToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.CSVToolStripMenuItem.Text = "CSV"
        '
        '入力ToolStripMenuItem
        '
        Me.入力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CSVToolStripMenuItem1, Me.ブランドからマージToolStripMenuItem})
        Me.入力ToolStripMenuItem.Name = "入力ToolStripMenuItem"
        Me.入力ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.入力ToolStripMenuItem.Text = "入力"
        '
        'CSVToolStripMenuItem1
        '
        Me.CSVToolStripMenuItem1.Name = "CSVToolStripMenuItem1"
        Me.CSVToolStripMenuItem1.Size = New System.Drawing.Size(154, 22)
        Me.CSVToolStripMenuItem1.Text = "CSV"
        '
        'ブランドからマージToolStripMenuItem
        '
        Me.ブランドからマージToolStripMenuItem.Name = "ブランドからマージToolStripMenuItem"
        Me.ブランドからマージToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ブランドからマージToolStripMenuItem.Text = "ブランドからマージ"
        '
        '在庫ToolStripMenuItem1
        '
        Me.在庫ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.更新ToolStripMenuItem})
        Me.在庫ToolStripMenuItem1.Name = "在庫ToolStripMenuItem1"
        Me.在庫ToolStripMenuItem1.Size = New System.Drawing.Size(43, 20)
        Me.在庫ToolStripMenuItem1.Text = "在庫"
        '
        '更新ToolStripMenuItem
        '
        Me.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem"
        Me.更新ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.更新ToolStripMenuItem.Text = "更新"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label21)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxガス種)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox相手先品番)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label20)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox在庫種類)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxカテゴリ)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox廃止予定日)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker廃止予定日)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label19)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBoxAS供給停止日)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePickerAS供給停止日)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label18)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox保有年)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox原価)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox納入数)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox製品)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox販売価格)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox注文残)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox現在庫)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox廃止日)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker廃止日)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxk基準在庫)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox得意先コード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox入力振分)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxメーカー)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox倉庫)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索３)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索２)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button削除)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button更新)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索１)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox商品名)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox品コード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1046, 526)
        Me.SplitContainer1.SplitterDistance = 177
        Me.SplitContainer1.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown単位)
        Me.GroupBox2.Controls.Add(Me.CheckBox個別)
        Me.GroupBox2.Location = New System.Drawing.Point(756, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(161, 42)
        Me.GroupBox2.TabIndex = 134
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "移動ルール"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(61, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 12)
        Me.Label22.TabIndex = 136
        Me.Label22.Text = "単位"
        '
        'NumericUpDown単位
        '
        Me.NumericUpDown単位.Location = New System.Drawing.Point(98, 16)
        Me.NumericUpDown単位.Name = "NumericUpDown単位"
        Me.NumericUpDown単位.Size = New System.Drawing.Size(52, 19)
        Me.NumericUpDown単位.TabIndex = 135
        '
        'CheckBox個別
        '
        Me.CheckBox個別.AutoSize = True
        Me.CheckBox個別.Location = New System.Drawing.Point(7, 17)
        Me.CheckBox個別.Name = "CheckBox個別"
        Me.CheckBox個別.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox個別.TabIndex = 134
        Me.CheckBox個別.Text = "個別"
        Me.CheckBox個別.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.CheckBox部品スペック)
        Me.GroupBox1.Controls.Add(Me.CheckBoxショップ登録用部品)
        Me.GroupBox1.Location = New System.Drawing.Point(706, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(132, 56)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "データ連携"
        '
        'CheckBox部品スペック
        '
        Me.CheckBox部品スペック.AutoSize = True
        Me.CheckBox部品スペック.Checked = True
        Me.CheckBox部品スペック.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox部品スペック.Location = New System.Drawing.Point(10, 35)
        Me.CheckBox部品スペック.Name = "CheckBox部品スペック"
        Me.CheckBox部品スペック.Size = New System.Drawing.Size(82, 16)
        Me.CheckBox部品スペック.TabIndex = 129
        Me.CheckBox部品スペック.Text = "部品スペック"
        Me.CheckBox部品スペック.UseVisualStyleBackColor = True
        '
        'CheckBoxショップ登録用部品
        '
        Me.CheckBoxショップ登録用部品.AutoSize = True
        Me.CheckBoxショップ登録用部品.Checked = True
        Me.CheckBoxショップ登録用部品.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxショップ登録用部品.Location = New System.Drawing.Point(10, 15)
        Me.CheckBoxショップ登録用部品.Name = "CheckBoxショップ登録用部品"
        Me.CheckBoxショップ登録用部品.Size = New System.Drawing.Size(116, 16)
        Me.CheckBoxショップ登録用部品.TabIndex = 128
        Me.CheckBoxショップ登録用部品.Text = "ショップ登録用部品"
        Me.CheckBoxショップ登録用部品.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(40, 124)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(36, 12)
        Me.Label21.TabIndex = 126
        Me.Label21.Text = "ガス種"
        '
        'ComboBoxガス種
        '
        Me.ComboBoxガス種.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxガス種.FormattingEnabled = True
        Me.ComboBoxガス種.Location = New System.Drawing.Point(79, 121)
        Me.ComboBoxガス種.Name = "ComboBoxガス種"
        Me.ComboBoxガス種.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxガス種.TabIndex = 125
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(557, 60)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 124
        Me.Label15.Text = "納入数"
        '
        'TextBox相手先品番
        '
        Me.TextBox相手先品番.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox相手先品番.Location = New System.Drawing.Point(79, 144)
        Me.TextBox相手先品番.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox相手先品番.MaxLength = 50
        Me.TextBox相手先品番.Name = "TextBox相手先品番"
        Me.TextBox相手先品番.Size = New System.Drawing.Size(252, 19)
        Me.TextBox相手先品番.TabIndex = 123
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 147)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 12)
        Me.Label20.TabIndex = 122
        Me.Label20.Text = "相手先品番"
        '
        'ComboBox在庫種類
        '
        Me.ComboBox在庫種類.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox在庫種類.FormattingEnabled = True
        Me.ComboBox在庫種類.Items.AddRange(New Object() {"", "0", "1", "2", "3", "4", "5"})
        Me.ComboBox在庫種類.Location = New System.Drawing.Point(601, 96)
        Me.ComboBox在庫種類.Name = "ComboBox在庫種類"
        Me.ComboBox在庫種類.Size = New System.Drawing.Size(95, 20)
        Me.ComboBox在庫種類.TabIndex = 95
        '
        'ComboBoxカテゴリ
        '
        Me.ComboBoxカテゴリ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxカテゴリ.FormattingEnabled = True
        Me.ComboBoxカテゴリ.Items.AddRange(New Object() {"", "NEXT", "NETS", "SYSTF"})
        Me.ComboBoxカテゴリ.Location = New System.Drawing.Point(79, 64)
        Me.ComboBoxカテゴリ.Name = "ComboBoxカテゴリ"
        Me.ComboBoxカテゴリ.Size = New System.Drawing.Size(171, 20)
        Me.ComboBoxカテゴリ.TabIndex = 94
        '
        'MaskedTextBox廃止予定日
        '
        Me.MaskedTextBox廃止予定日.Location = New System.Drawing.Point(786, 108)
        Me.MaskedTextBox廃止予定日.Mask = "0000/00/00"
        Me.MaskedTextBox廃止予定日.Name = "MaskedTextBox廃止予定日"
        Me.MaskedTextBox廃止予定日.Size = New System.Drawing.Size(100, 19)
        Me.MaskedTextBox廃止予定日.TabIndex = 91
        Me.MaskedTextBox廃止予定日.ValidatingType = GetType(Date)
        '
        'DateTimePicker廃止予定日
        '
        Me.DateTimePicker廃止予定日.Location = New System.Drawing.Point(787, 108)
        Me.DateTimePicker廃止予定日.Name = "DateTimePicker廃止予定日"
        Me.DateTimePicker廃止予定日.Size = New System.Drawing.Size(130, 19)
        Me.DateTimePicker廃止予定日.TabIndex = 93
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(711, 111)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 12)
        Me.Label19.TabIndex = 92
        Me.Label19.Text = "アラート日"
        '
        'MaskedTextBoxAS供給停止日
        '
        Me.MaskedTextBoxAS供給停止日.Location = New System.Drawing.Point(786, 85)
        Me.MaskedTextBoxAS供給停止日.Mask = "0000/00/00"
        Me.MaskedTextBoxAS供給停止日.Name = "MaskedTextBoxAS供給停止日"
        Me.MaskedTextBoxAS供給停止日.Size = New System.Drawing.Size(100, 19)
        Me.MaskedTextBoxAS供給停止日.TabIndex = 88
        Me.MaskedTextBoxAS供給停止日.ValidatingType = GetType(Date)
        Me.MaskedTextBoxAS供給停止日.Visible = False
        '
        'DateTimePickerAS供給停止日
        '
        Me.DateTimePickerAS供給停止日.Location = New System.Drawing.Point(787, 85)
        Me.DateTimePickerAS供給停止日.Name = "DateTimePickerAS供給停止日"
        Me.DateTimePickerAS供給停止日.Size = New System.Drawing.Size(130, 19)
        Me.DateTimePickerAS供給停止日.TabIndex = 90
        Me.DateTimePickerAS供給停止日.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(704, 88)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 12)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "AS供給停止日"
        Me.Label18.Visible = False
        '
        'TextBox保有年
        '
        Me.TextBox保有年.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox保有年.Location = New System.Drawing.Point(428, 144)
        Me.TextBox保有年.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox保有年.MaxLength = 10
        Me.TextBox保有年.Name = "TextBox保有年"
        Me.TextBox保有年.Size = New System.Drawing.Size(76, 19)
        Me.TextBox保有年.TabIndex = 87
        '
        'TextBox原価
        '
        Me.TextBox原価.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox原価.Location = New System.Drawing.Point(428, 120)
        Me.TextBox原価.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox原価.MaxLength = 10
        Me.TextBox原価.Name = "TextBox原価"
        Me.TextBox原価.Size = New System.Drawing.Size(76, 19)
        Me.TextBox原価.TabIndex = 86
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.Label17.Location = New System.Drawing.Point(397, 123)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 12)
        Me.Label17.TabIndex = 85
        Me.Label17.Text = "原価"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.Label16.Location = New System.Drawing.Point(385, 147)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 12)
        Me.Label16.TabIndex = 84
        Me.Label16.Text = "保有年"
        '
        'TextBox納入数
        '
        Me.TextBox納入数.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox納入数.Location = New System.Drawing.Point(601, 57)
        Me.TextBox納入数.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox納入数.MaxLength = 10
        Me.TextBox納入数.Name = "TextBox納入数"
        Me.TextBox納入数.Size = New System.Drawing.Size(94, 19)
        Me.TextBox納入数.TabIndex = 82
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.Label14.Location = New System.Drawing.Point(367, 100)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 12)
        Me.Label14.TabIndex = 81
        Me.Label14.Text = "製品/部品"
        '
        'ComboBox製品
        '
        Me.ComboBox製品.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox製品.FormattingEnabled = True
        Me.ComboBox製品.Items.AddRange(New Object() {"", "0", "1", "2", "3", "4", "5"})
        Me.ComboBox製品.Location = New System.Drawing.Point(428, 96)
        Me.ComboBox製品.Name = "ComboBox製品"
        Me.ComboBox製品.Size = New System.Drawing.Size(76, 20)
        Me.ComboBox製品.TabIndex = 80
        '
        'TextBox販売価格
        '
        Me.TextBox販売価格.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox販売価格.Location = New System.Drawing.Point(601, 144)
        Me.TextBox販売価格.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox販売価格.MaxLength = 10
        Me.TextBox販売価格.Name = "TextBox販売価格"
        Me.TextBox販売価格.Size = New System.Drawing.Size(95, 19)
        Me.TextBox販売価格.TabIndex = 78
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(545, 147)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 79
        Me.Label13.Text = "標準単価"
        '
        'TextBox注文残
        '
        Me.TextBox注文残.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox注文残.Location = New System.Drawing.Point(601, 34)
        Me.TextBox注文残.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox注文残.MaxLength = 10
        Me.TextBox注文残.Name = "TextBox注文残"
        Me.TextBox注文残.Size = New System.Drawing.Size(95, 19)
        Me.TextBox注文残.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(557, 37)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "注文残"
        '
        'TextBox現在庫
        '
        Me.TextBox現在庫.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox現在庫.Location = New System.Drawing.Point(601, 13)
        Me.TextBox現在庫.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox現在庫.MaxLength = 10
        Me.TextBox現在庫.Name = "TextBox現在庫"
        Me.TextBox現在庫.Size = New System.Drawing.Size(95, 19)
        Me.TextBox現在庫.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(545, 100)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 74
        Me.Label12.Text = "在庫種類"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(557, 16)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "現在庫"
        '
        'MaskedTextBox廃止日
        '
        Me.MaskedTextBox廃止日.Location = New System.Drawing.Point(891, 36)
        Me.MaskedTextBox廃止日.Mask = "0000/00/00"
        Me.MaskedTextBox廃止日.Name = "MaskedTextBox廃止日"
        Me.MaskedTextBox廃止日.Size = New System.Drawing.Size(100, 19)
        Me.MaskedTextBox廃止日.TabIndex = 15
        Me.MaskedTextBox廃止日.ValidatingType = GetType(Date)
        Me.MaskedTextBox廃止日.Visible = False
        '
        'DateTimePicker廃止日
        '
        Me.DateTimePicker廃止日.Location = New System.Drawing.Point(892, 36)
        Me.DateTimePicker廃止日.Name = "DateTimePicker廃止日"
        Me.DateTimePicker廃止日.Size = New System.Drawing.Size(130, 19)
        Me.DateTimePicker廃止日.TabIndex = 70
        Me.DateTimePicker廃止日.Visible = False
        '
        'TextBoxk基準在庫
        '
        Me.TextBoxk基準在庫.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxk基準在庫.Location = New System.Drawing.Point(601, 120)
        Me.TextBoxk基準在庫.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxk基準在庫.MaxLength = 10
        Me.TextBoxk基準在庫.Name = "TextBoxk基準在庫"
        Me.TextBoxk基準在庫.Size = New System.Drawing.Size(95, 19)
        Me.TextBoxk基準在庫.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(545, 123)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "基準在庫"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(849, 39)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "廃止日"
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(183, 124)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 12)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "得意先コード"
        '
        'ComboBox得意先コード
        '
        Me.ComboBox得意先コード.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox得意先コード.FormattingEnabled = True
        Me.ComboBox得意先コード.Location = New System.Drawing.Point(255, 120)
        Me.ComboBox得意先コード.Name = "ComboBox得意先コード"
        Me.ComboBox得意先コード.Size = New System.Drawing.Size(76, 20)
        Me.ComboBox得意先コード.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(723, 66)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "入力振分"
        Me.Label6.Visible = False
        '
        'ComboBox入力振分
        '
        Me.ComboBox入力振分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox入力振分.FormattingEnabled = True
        Me.ComboBox入力振分.Items.AddRange(New Object() {"", "0", "1", "2", "3", "4", "5"})
        Me.ComboBox入力振分.Location = New System.Drawing.Point(786, 63)
        Me.ComboBox入力振分.Name = "ComboBox入力振分"
        Me.ComboBox入力振分.Size = New System.Drawing.Size(72, 20)
        Me.ComboBox入力振分.TabIndex = 11
        Me.ComboBox入力振分.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(209, 100)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 12)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "ショップ"
        '
        'ComboBoxメーカー
        '
        Me.ComboBoxメーカー.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxメーカー.FormattingEnabled = True
        Me.ComboBoxメーカー.Items.AddRange(New Object() {"", "0", "2"})
        Me.ComboBoxメーカー.Location = New System.Drawing.Point(255, 96)
        Me.ComboBoxメーカー.Name = "ComboBoxメーカー"
        Me.ComboBoxメーカー.Size = New System.Drawing.Size(76, 20)
        Me.ComboBoxメーカー.TabIndex = 10
        '
        'ComboBox倉庫
        '
        Me.ComboBox倉庫.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox倉庫.FormattingEnabled = True
        Me.ComboBox倉庫.Items.AddRange(New Object() {"", "NEXT", "NETS", "SYSTF"})
        Me.ComboBox倉庫.Location = New System.Drawing.Point(79, 96)
        Me.ComboBox倉庫.Name = "ComboBox倉庫"
        Me.ComboBox倉庫.Size = New System.Drawing.Size(74, 20)
        Me.ComboBox倉庫.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 101)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "倉庫"
        '
        'Button検索３
        '
        Me.Button検索３.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索３.Location = New System.Drawing.Point(428, 66)
        Me.Button検索３.Name = "Button検索３"
        Me.Button検索３.Size = New System.Drawing.Size(75, 25)
        Me.Button検索３.TabIndex = 8
        Me.Button検索３.Text = "検索"
        Me.Button検索３.UseVisualStyleBackColor = False
        '
        'Button検索２
        '
        Me.Button検索２.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索２.Location = New System.Drawing.Point(428, 38)
        Me.Button検索２.Name = "Button検索２"
        Me.Button検索２.Size = New System.Drawing.Size(75, 25)
        Me.Button検索２.TabIndex = 5
        Me.Button検索２.Text = "検索"
        Me.Button検索２.UseVisualStyleBackColor = False
        '
        'ComboBoxJy3
        '
        Me.ComboBoxJy3.AutoCompleteCustomSource.AddRange(New String() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy3.FormattingEnabled = True
        Me.ComboBoxJy3.Items.AddRange(New Object() {"一致"})
        Me.ComboBoxJy3.Location = New System.Drawing.Point(348, 66)
        Me.ComboBoxJy3.Name = "ComboBoxJy3"
        Me.ComboBoxJy3.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy3.TabIndex = 7
        '
        'ComboBoxJy2
        '
        Me.ComboBoxJy2.AutoCompleteCustomSource.AddRange(New String() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy2.FormattingEnabled = True
        Me.ComboBoxJy2.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy2.Location = New System.Drawing.Point(348, 39)
        Me.ComboBoxJy2.Name = "ComboBoxJy2"
        Me.ComboBoxJy2.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy2.TabIndex = 4
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(348, 13)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy1.TabIndex = 1
        '
        'Button削除
        '
        Me.Button削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button削除.Location = New System.Drawing.Point(925, 3)
        Me.Button削除.Name = "Button削除"
        Me.Button削除.Size = New System.Drawing.Size(75, 23)
        Me.Button削除.TabIndex = 19
        Me.Button削除.Text = "削除"
        Me.Button削除.UseVisualStyleBackColor = False
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(844, 4)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(75, 23)
        Me.Button更新.TabIndex = 18
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'Button検索１
        '
        Me.Button検索１.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索１.Location = New System.Drawing.Point(428, 12)
        Me.Button検索１.Name = "Button検索１"
        Me.Button検索１.Size = New System.Drawing.Size(75, 25)
        Me.Button検索１.TabIndex = 2
        Me.Button検索１.Text = "検索"
        Me.Button検索１.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 70)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 12)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "カテゴリ"
        '
        'TextBox商品名
        '
        Me.TextBox商品名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox商品名.Location = New System.Drawing.Point(79, 40)
        Me.TextBox商品名.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox商品名.MaxLength = 200
        Me.TextBox商品名.Name = "TextBox商品名"
        Me.TextBox商品名.Size = New System.Drawing.Size(252, 19)
        Me.TextBox商品名.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 43)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "商品名"
        '
        'TextBox品コード
        '
        Me.TextBox品コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox品コード.Location = New System.Drawing.Point(79, 14)
        Me.TextBox品コード.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox品コード.MaxLength = 50
        Me.TextBox品コード.Name = "TextBox品コード"
        Me.TextBox品コード.Size = New System.Drawing.Size(116, 19)
        Me.TextBox品コード.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 12)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "品コード"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column17, Me.Column7, Me.Column10, Me.Column18, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column6, Me.SHOP, Me.Column19, Me.Column8, Me.Column9, Me.Column20, Me.Column21})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1046, 345)
        Me.DataGridView1.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "品コード"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.HeaderText = "商品名"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 125
        '
        'Column3
        '
        Me.Column3.HeaderText = "カテゴリ"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "倉庫"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 125
        '
        'Column5
        '
        Me.Column5.HeaderText = "ショップ"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 125
        '
        'Column17
        '
        Me.Column17.HeaderText = "ガス種"
        Me.Column17.Name = "Column17"
        '
        'Column7
        '
        Me.Column7.HeaderText = "得意先コード"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 125
        '
        'Column10
        '
        Me.Column10.HeaderText = "基準在庫"
        Me.Column10.Name = "Column10"
        '
        'Column18
        '
        Me.Column18.HeaderText = "廃止予定日"
        Me.Column18.Name = "Column18"
        '
        'Column11
        '
        Me.Column11.HeaderText = "廃止日"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "在庫種類"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "販売価格"
        Me.Column13.Name = "Column13"
        '
        'Column14
        '
        Me.Column14.HeaderText = "製品フラグ"
        Me.Column14.Name = "Column14"
        '
        'Column15
        '
        Me.Column15.HeaderText = "原価"
        Me.Column15.Name = "Column15"
        '
        'Column16
        '
        Me.Column16.HeaderText = "保有年"
        Me.Column16.Name = "Column16"
        '
        'Column6
        '
        Me.Column6.HeaderText = "相手先品番"
        Me.Column6.Name = "Column6"
        '
        'SHOP
        '
        Me.SHOP.HeaderText = "SHOP"
        Me.SHOP.Name = "SHOP"
        '
        'Column19
        '
        Me.Column19.HeaderText = "BUHIN"
        Me.Column19.Name = "Column19"
        '
        'Column8
        '
        Me.Column8.HeaderText = "更新日"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 125
        '
        'Column9
        '
        Me.Column9.HeaderText = "更新者"
        Me.Column9.MinimumWidth = 6
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 125
        '
        'Column20
        '
        Me.Column20.HeaderText = "ルール"
        Me.Column20.Name = "Column20"
        '
        'Column21
        '
        Me.Column21.HeaderText = "個別"
        Me.Column21.Name = "Column21"
        '
        'TextBox更新日
        '
        Me.TextBox更新日.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox更新日.Location = New System.Drawing.Point(844, 10)
        Me.TextBox更新日.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox更新日.Name = "TextBox更新日"
        Me.TextBox更新日.ReadOnly = True
        Me.TextBox更新日.Size = New System.Drawing.Size(156, 12)
        Me.TextBox更新日.TabIndex = 121
        '
        'FormMstSeihin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 550)
        Me.Controls.Add(Me.TextBox更新日)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormMstSeihin"
        Me.Text = "製品マスタ(品コード)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericUpDown単位, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MaskedTextBox廃止日 As MaskedTextBox
    Friend WithEvents DateTimePicker廃止日 As DateTimePicker
    Friend WithEvents TextBoxk基準在庫 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox得意先コード As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox入力振分 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBoxメーカー As ComboBox
    Friend WithEvents ComboBox倉庫 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button検索３ As Button
    Friend WithEvents Button検索２ As Button
    Friend WithEvents ComboBoxJy3 As ComboBox
    Friend WithEvents ComboBoxJy2 As ComboBox
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents Button削除 As Button
    Friend WithEvents Button更新 As Button
    Friend WithEvents Button検索１ As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox商品名 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox品コード As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox現在庫 As TextBox
    Friend WithEvents TextBox注文残 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboBox製品 As ComboBox
    Friend WithEvents TextBox販売価格 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox納入数 As TextBox
    Friend WithEvents TextBox保有年 As TextBox
    Friend WithEvents TextBox原価 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents MaskedTextBox廃止予定日 As MaskedTextBox
    Friend WithEvents DateTimePicker廃止予定日 As DateTimePicker
    Friend WithEvents Label19 As Label
    Friend WithEvents MaskedTextBoxAS供給停止日 As MaskedTextBox
    Friend WithEvents DateTimePickerAS供給停止日 As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents ComboBoxカテゴリ As ComboBox
    Friend WithEvents ComboBox在庫種類 As ComboBox
    Friend WithEvents TextBox更新日 As TextBox
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 入力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TextBox相手先品番 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents 在庫ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 更新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label15 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents ComboBoxガス種 As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox部品スペック As CheckBox
    Friend WithEvents CheckBoxショップ登録用部品 As CheckBox
    Friend WithEvents ブランドからマージToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents SHOP As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column20 As DataGridViewTextBoxColumn
    Friend WithEvents Column21 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label22 As Label
    Friend WithEvents NumericUpDown単位 As NumericUpDown
    Friend WithEvents CheckBox個別 As CheckBox
End Class
