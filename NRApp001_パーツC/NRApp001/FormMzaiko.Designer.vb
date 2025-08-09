<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMzaiko
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMzaiko))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.MaskedTextBox発注日 = New System.Windows.Forms.MaskedTextBox()
        Me.TextBox移動伝票No = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxエビスオーダーNo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ButtonIy検索3 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox出庫不要 = New System.Windows.Forms.ComboBox()
        Me.TextBox佐川番号 = New System.Windows.Forms.TextBox()
        Me.TextBox事務処理事項 = New System.Windows.Forms.TextBox()
        Me.TextBox連絡事項 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker発注日 = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox処理 = New System.Windows.Forms.ComboBox()
        Me.TextBoxSEQ = New System.Windows.Forms.TextBox()
        Me.TextBox合計 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox手数料 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox送料 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox単価 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxオーダーNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button品コード検索 = New System.Windows.Forms.Button()
        Me.ComboBoxjy2 = New System.Windows.Forms.ComboBox()
        Me.Button検索2 = New System.Windows.Forms.Button()
        Me.Button削除 = New System.Windows.Forms.Button()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.TextBox数量 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox品名 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.Button検索1 = New System.Windows.Forms.Button()
        Me.TextBox品コード = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox更新日 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.出力ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1166, 24)
        Me.MenuStrip1.TabIndex = 0
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox発注日)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox移動伝票No)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxエビスオーダーNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonIy検索3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox出庫不要)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox佐川番号)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox事務処理事項)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox連絡事項)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker発注日)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox処理)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxSEQ)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox合計)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox手数料)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox送料)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox単価)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxオーダーNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button品コード検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxjy2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button削除)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button更新)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox数量)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox品名)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox品コード)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1166, 510)
        Me.SplitContainer1.SplitterDistance = 167
        Me.SplitContainer1.TabIndex = 1
        '
        'MaskedTextBox発注日
        '
        Me.MaskedTextBox発注日.BackColor = System.Drawing.SystemColors.Window
        Me.MaskedTextBox発注日.Location = New System.Drawing.Point(67, 129)
        Me.MaskedTextBox発注日.Mask = "0000/00/00"
        Me.MaskedTextBox発注日.Name = "MaskedTextBox発注日"
        Me.MaskedTextBox発注日.Size = New System.Drawing.Size(83, 19)
        Me.MaskedTextBox発注日.TabIndex = 10
        Me.MaskedTextBox発注日.ValidatingType = GetType(Date)
        '
        'TextBox移動伝票No
        '
        Me.TextBox移動伝票No.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox移動伝票No.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox移動伝票No.Location = New System.Drawing.Point(504, 91)
        Me.TextBox移動伝票No.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox移動伝票No.MaxLength = 10
        Me.TextBox移動伝票No.Name = "TextBox移動伝票No"
        Me.TextBox移動伝票No.Size = New System.Drawing.Size(116, 19)
        Me.TextBox移動伝票No.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(434, 94)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 12)
        Me.Label16.TabIndex = 156
        Me.Label16.Text = "出庫伝票No"
        '
        'TextBoxエビスオーダーNo
        '
        Me.TextBoxエビスオーダーNo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxエビスオーダーNo.Location = New System.Drawing.Point(504, 65)
        Me.TextBoxエビスオーダーNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxエビスオーダーNo.MaxLength = 10
        Me.TextBoxエビスオーダーNo.Name = "TextBoxエビスオーダーNo"
        Me.TextBoxエビスオーダーNo.Size = New System.Drawing.Size(116, 19)
        Me.TextBoxエビスオーダーNo.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(418, 68)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 12)
        Me.Label15.TabIndex = 154
        Me.Label15.Text = "エビスオーダーNo"
        '
        'ButtonIy検索3
        '
        Me.ButtonIy検索3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonIy検索3.Location = New System.Drawing.Point(320, 67)
        Me.ButtonIy検索3.Name = "ButtonIy検索3"
        Me.ButtonIy検索3.Size = New System.Drawing.Size(75, 23)
        Me.ButtonIy検索3.TabIndex = 7
        Me.ButtonIy検索3.Text = "検索"
        Me.ButtonIy検索3.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(987, 65)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 12)
        Me.Label14.TabIndex = 152
        Me.Label14.Text = "出庫"
        '
        'ComboBox出庫不要
        '
        Me.ComboBox出庫不要.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox出庫不要.FormattingEnabled = True
        Me.ComboBox出庫不要.Location = New System.Drawing.Point(1021, 60)
        Me.ComboBox出庫不要.Name = "ComboBox出庫不要"
        Me.ComboBox出庫不要.Size = New System.Drawing.Size(117, 20)
        Me.ComboBox出庫不要.TabIndex = 19
        '
        'TextBox佐川番号
        '
        Me.TextBox佐川番号.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox佐川番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox佐川番号.Location = New System.Drawing.Point(866, 129)
        Me.TextBox佐川番号.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox佐川番号.MaxLength = 20
        Me.TextBox佐川番号.Name = "TextBox佐川番号"
        Me.TextBox佐川番号.Size = New System.Drawing.Size(153, 19)
        Me.TextBox佐川番号.TabIndex = 13
        '
        'TextBox事務処理事項
        '
        Me.TextBox事務処理事項.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox事務処理事項.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox事務処理事項.Location = New System.Drawing.Point(563, 129)
        Me.TextBox事務処理事項.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox事務処理事項.MaxLength = 50
        Me.TextBox事務処理事項.Multiline = True
        Me.TextBox事務処理事項.Name = "TextBox事務処理事項"
        Me.TextBox事務処理事項.Size = New System.Drawing.Size(242, 28)
        Me.TextBox事務処理事項.TabIndex = 12
        '
        'TextBox連絡事項
        '
        Me.TextBox連絡事項.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox連絡事項.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox連絡事項.Location = New System.Drawing.Point(261, 129)
        Me.TextBox連絡事項.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox連絡事項.MaxLength = 50
        Me.TextBox連絡事項.Multiline = True
        Me.TextBox連絡事項.Name = "TextBox連絡事項"
        Me.TextBox連絡事項.Size = New System.Drawing.Size(241, 28)
        Me.TextBox連絡事項.TabIndex = 11
        '
        'DateTimePicker発注日
        '
        Me.DateTimePicker発注日.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker発注日.Location = New System.Drawing.Point(67, 129)
        Me.DateTimePicker発注日.Name = "DateTimePicker発注日"
        Me.DateTimePicker発注日.Size = New System.Drawing.Size(117, 19)
        Me.DateTimePicker発注日.TabIndex = 147
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(205, 132)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 146
        Me.Label13.Text = "連絡事項"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(519, 132)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 145
        Me.Label12.Text = "引当先"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 132)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 144
        Me.Label11.Text = "発注日"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(810, 132)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "佐川番号"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 70)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 142
        Me.Label10.Text = "処理"
        '
        'ComboBox処理
        '
        Me.ComboBox処理.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox処理.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox処理.ForeColor = System.Drawing.SystemColors.InfoText
        Me.ComboBox処理.FormattingEnabled = True
        Me.ComboBox処理.Items.AddRange(New Object() {"引当待", "引当済"})
        Me.ComboBox処理.Location = New System.Drawing.Point(66, 66)
        Me.ComboBox処理.Name = "ComboBox処理"
        Me.ComboBox処理.Size = New System.Drawing.Size(167, 20)
        Me.ComboBox処理.TabIndex = 6
        '
        'TextBoxSEQ
        '
        Me.TextBoxSEQ.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxSEQ.Location = New System.Drawing.Point(865, 9)
        Me.TextBoxSEQ.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxSEQ.MaxLength = 10
        Me.TextBoxSEQ.Name = "TextBoxSEQ"
        Me.TextBoxSEQ.ReadOnly = True
        Me.TextBoxSEQ.Size = New System.Drawing.Size(116, 19)
        Me.TextBoxSEQ.TabIndex = 140
        '
        'TextBox合計
        '
        Me.TextBox合計.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox合計.Location = New System.Drawing.Point(1021, 91)
        Me.TextBox合計.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox合計.MaxLength = 10
        Me.TextBox合計.Name = "TextBox合計"
        Me.TextBox合計.Size = New System.Drawing.Size(116, 19)
        Me.TextBox合計.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(990, 94)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 138
        Me.Label9.Text = "合計"
        '
        'TextBox手数料
        '
        Me.TextBox手数料.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox手数料.Location = New System.Drawing.Point(866, 91)
        Me.TextBox手数料.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox手数料.MaxLength = 10
        Me.TextBox手数料.Name = "TextBox手数料"
        Me.TextBox手数料.Size = New System.Drawing.Size(116, 19)
        Me.TextBox手数料.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(822, 94)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 136
        Me.Label8.Text = "手数料"
        '
        'TextBox送料
        '
        Me.TextBox送料.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox送料.Location = New System.Drawing.Point(689, 91)
        Me.TextBox送料.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox送料.MaxLength = 10
        Me.TextBox送料.Name = "TextBox送料"
        Me.TextBox送料.Size = New System.Drawing.Size(116, 19)
        Me.TextBox送料.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(657, 94)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 134
        Me.Label7.Text = "送料"
        '
        'TextBox単価
        '
        Me.TextBox単価.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox単価.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox単価.Location = New System.Drawing.Point(261, 97)
        Me.TextBox単価.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox単価.MaxLength = 10
        Me.TextBox単価.Name = "TextBox単価"
        Me.TextBox単価.Size = New System.Drawing.Size(116, 19)
        Me.TextBox単価.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(201, 100)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 12)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "単価(税抜)"
        '
        'TextBoxオーダーNo
        '
        Me.TextBoxオーダーNo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxオーダーNo.Location = New System.Drawing.Point(689, 66)
        Me.TextBoxオーダーNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxオーダーNo.MaxLength = 10
        Me.TextBoxオーダーNo.Name = "TextBoxオーダーNo"
        Me.TextBoxオーダーNo.Size = New System.Drawing.Size(116, 19)
        Me.TextBoxオーダーNo.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(629, 69)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 12)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "オーダーNo"
        '
        'Button品コード検索
        '
        Me.Button品コード検索.Location = New System.Drawing.Point(201, 13)
        Me.Button品コード検索.Name = "Button品コード検索"
        Me.Button品コード検索.Size = New System.Drawing.Size(33, 23)
        Me.Button品コード検索.TabIndex = 127
        Me.Button品コード検索.UseVisualStyleBackColor = True
        '
        'ComboBoxjy2
        '
        Me.ComboBoxjy2.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxjy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxjy2.FormattingEnabled = True
        Me.ComboBoxjy2.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxjy2.Location = New System.Drawing.Point(239, 42)
        Me.ComboBoxjy2.Name = "ComboBoxjy2"
        Me.ComboBoxjy2.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxjy2.TabIndex = 4
        '
        'Button検索2
        '
        Me.Button検索2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索2.Location = New System.Drawing.Point(320, 41)
        Me.Button検索2.Name = "Button検索2"
        Me.Button検索2.Size = New System.Drawing.Size(75, 23)
        Me.Button検索2.TabIndex = 5
        Me.Button検索2.Text = "検索"
        Me.Button検索2.UseVisualStyleBackColor = False
        '
        'Button削除
        '
        Me.Button削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button削除.Location = New System.Drawing.Point(1068, 7)
        Me.Button削除.Name = "Button削除"
        Me.Button削除.Size = New System.Drawing.Size(75, 23)
        Me.Button削除.TabIndex = 22
        Me.Button削除.Text = "削除"
        Me.Button削除.UseVisualStyleBackColor = False
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(986, 7)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(75, 23)
        Me.Button更新.TabIndex = 21
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'TextBox数量
        '
        Me.TextBox数量.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox数量.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox数量.Location = New System.Drawing.Point(64, 94)
        Me.TextBox数量.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox数量.MaxLength = 10
        Me.TextBox数量.Name = "TextBox数量"
        Me.TextBox数量.Size = New System.Drawing.Size(116, 19)
        Me.TextBox数量.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 97)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "数量"
        '
        'TextBox品名
        '
        Me.TextBox品名.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox品名.Location = New System.Drawing.Point(67, 42)
        Me.TextBox品名.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox品名.MaxLength = 10
        Me.TextBox品名.Name = "TextBox品名"
        Me.TextBox品名.Size = New System.Drawing.Size(166, 19)
        Me.TextBox品名.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "品名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 12)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "品コード"
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(239, 15)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy1.TabIndex = 1
        '
        'Button検索1
        '
        Me.Button検索1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索1.Location = New System.Drawing.Point(320, 14)
        Me.Button検索1.Name = "Button検索1"
        Me.Button検索1.Size = New System.Drawing.Size(75, 23)
        Me.Button検索1.TabIndex = 2
        Me.Button検索1.Text = "検索"
        Me.Button検索1.UseVisualStyleBackColor = False
        '
        'TextBox品コード
        '
        Me.TextBox品コード.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox品コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox品コード.Location = New System.Drawing.Point(67, 15)
        Me.TextBox品コード.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox品コード.MaxLength = 10
        Me.TextBox品コード.Name = "TextBox品コード"
        Me.TextBox品コード.Size = New System.Drawing.Size(116, 19)
        Me.TextBox品コード.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column1, Me.Column2, Me.Column3, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column9, Me.Column20, Me.Column21, Me.Column14})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1166, 339)
        Me.DataGridView1.TabIndex = 0
        '
        'Column8
        '
        Me.Column8.HeaderText = "オーダーNO"
        Me.Column8.Name = "Column8"
        '
        'Column1
        '
        Me.Column1.HeaderText = "品コード"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "品名"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "在庫数"
        Me.Column3.Name = "Column3"
        '
        'Column10
        '
        Me.Column10.HeaderText = "単価"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.HeaderText = "送料"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "手数料"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "合計"
        Me.Column13.Name = "Column13"
        '
        'Column15
        '
        Me.Column15.HeaderText = "発注日"
        Me.Column15.Name = "Column15"
        '
        'Column16
        '
        Me.Column16.HeaderText = "連絡事項"
        Me.Column16.Name = "Column16"
        '
        'Column17
        '
        Me.Column17.HeaderText = "事務処理事項"
        Me.Column17.Name = "Column17"
        '
        'Column18
        '
        Me.Column18.HeaderText = "佐川番号"
        Me.Column18.Name = "Column18"
        '
        'Column19
        '
        Me.Column19.HeaderText = "出庫"
        Me.Column19.Name = "Column19"
        '
        'Column4
        '
        Me.Column4.HeaderText = "登録日"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "登録者"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "更新日"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "更新者"
        Me.Column7.Name = "Column7"
        '
        'Column9
        '
        Me.Column9.HeaderText = "処理フラグ"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column20
        '
        Me.Column20.HeaderText = "エビスオーダーNO"
        Me.Column20.Name = "Column20"
        '
        'Column21
        '
        Me.Column21.HeaderText = "移動伝票No"
        Me.Column21.Name = "Column21"
        '
        'Column14
        '
        Me.Column14.HeaderText = "SEQ"
        Me.Column14.Name = "Column14"
        '
        'TextBox更新日
        '
        Me.TextBox更新日.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox更新日.Location = New System.Drawing.Point(986, 7)
        Me.TextBox更新日.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox更新日.Name = "TextBox更新日"
        Me.TextBox更新日.ReadOnly = True
        Me.TextBox更新日.Size = New System.Drawing.Size(155, 12)
        Me.TextBox更新日.TabIndex = 124
        '
        'FormMzaiko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1166, 534)
        Me.Controls.Add(Me.TextBox更新日)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FormMzaiko"
        Me.Text = "キャンセル引き当て待ち品"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents Button検索1 As Button
    Friend WithEvents TextBox品コード As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox数量 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox品名 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxjy2 As ComboBox
    Friend WithEvents Button検索2 As Button
    Friend WithEvents TextBox更新日 As TextBox
    Friend WithEvents Button削除 As Button
    Friend WithEvents Button更新 As Button
    Friend WithEvents Button品コード検索 As Button
    Friend WithEvents TextBoxオーダーNo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBox合計 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox手数料 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox送料 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox単価 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxSEQ As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBox処理 As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox佐川番号 As TextBox
    Friend WithEvents TextBox事務処理事項 As TextBox
    Friend WithEvents TextBox連絡事項 As TextBox
    Friend WithEvents DateTimePicker発注日 As DateTimePicker
    Friend WithEvents ComboBox出庫不要 As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ButtonIy検索3 As Button
    Friend WithEvents MaskedTextBox発注日 As MaskedTextBox
    Friend WithEvents TextBox移動伝票No As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBoxエビスオーダーNo As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column20 As DataGridViewTextBoxColumn
    Friend WithEvents Column21 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
End Class
