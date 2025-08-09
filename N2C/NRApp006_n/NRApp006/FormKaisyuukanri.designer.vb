<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKaisyuukanri
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKaisyuukanri))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.検索ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.入金予定日登録ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.取込みToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.更新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.CheckBox債権放棄 = New System.Windows.Forms.CheckBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.CheckBox債権放棄非表示 = New System.Windows.Forms.CheckBox()
        Me.CheckBox督促状発行未入金 = New System.Windows.Forms.CheckBox()
        Me.ListBox得意先コード = New System.Windows.Forms.ListBox()
        Me.CheckBoxSS未請求 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.TextBox点検受付番号 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CheckBox督促状発行済 = New System.Windows.Forms.CheckBox()
        Me.CheckBox未入金 = New System.Windows.Forms.CheckBox()
        Me.CheckBox請求書再発行超過 = New System.Windows.Forms.CheckBox()
        Me.CheckBox請求書再発行済 = New System.Windows.Forms.CheckBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBox備考 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox確認者 = New System.Windows.Forms.TextBox()
        Me.TextBox入金内容確認 = New System.Windows.Forms.TextBox()
        Me.TextBox備考_漢字 = New System.Windows.Forms.TextBox()
        Me.MaskedTextBox入金予定日e = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox入金予定日s = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox入金日e = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox入金日s = New System.Windows.Forms.MaskedTextBox()
        Me.TextBox請求金額e = New System.Windows.Forms.TextBox()
        Me.TextBox請求金額s = New System.Windows.Forms.TextBox()
        Me.TextBox回収金額e = New System.Windows.Forms.TextBox()
        Me.TextBox回収金額s = New System.Windows.Forms.TextBox()
        Me.TextBox発注担当者 = New System.Windows.Forms.TextBox()
        Me.TextBox請求先宛名 = New System.Windows.Forms.TextBox()
        Me.TextBox請求書番号 = New System.Windows.Forms.TextBox()
        Me.TextBox品コード = New System.Windows.Forms.TextBox()
        Me.MaskedTextBox売上日e = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox売上日s = New System.Windows.Forms.MaskedTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxss請求 = New System.Windows.Forms.TextBox()
        Me.Buttonクリア = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox回収区分 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.ButtonTEST = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.検索ToolStripMenuItem, Me.出力ToolStripMenuItem, Me.入金予定日登録ToolStripMenuItem, Me.取込みToolStripMenuItem, Me.更新ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1237, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '検索ToolStripMenuItem
        '
        Me.検索ToolStripMenuItem.Name = "検索ToolStripMenuItem"
        Me.検索ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.検索ToolStripMenuItem.Text = "検索"
        '
        '出力ToolStripMenuItem
        '
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCLToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'EXCLToolStripMenuItem
        '
        Me.EXCLToolStripMenuItem.Name = "EXCLToolStripMenuItem"
        Me.EXCLToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EXCLToolStripMenuItem.Text = "EXCEL"
        '
        '入金予定日登録ToolStripMenuItem
        '
        Me.入金予定日登録ToolStripMenuItem.Name = "入金予定日登録ToolStripMenuItem"
        Me.入金予定日登録ToolStripMenuItem.Size = New System.Drawing.Size(238, 20)
        Me.入金予定日登録ToolStripMenuItem.Text = "【入金予定日一括更新（特別サイト顧客）】"
        '
        '取込みToolStripMenuItem
        '
        Me.取込みToolStripMenuItem.Name = "取込みToolStripMenuItem"
        Me.取込みToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.取込みToolStripMenuItem.Text = "　　取込み"
        '
        '更新ToolStripMenuItem
        '
        Me.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem"
        Me.更新ToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.更新ToolStripMenuItem.Text = "【更新】"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 533)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1237, 23)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(800, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 18)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(119, 18)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(119, 18)
        Me.ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonTEST)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label30)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox債権放棄)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label29)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label28)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label27)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label26)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox債権放棄非表示)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox督促状発行未入金)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListBox得意先コード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxSS未請求)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox督促状発行済)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox未入金)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox請求書再発行超過)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox請求書再発行済)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label25)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox備考)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label24)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label23)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label22)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label21)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label20)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox確認者)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox入金内容確認)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox備考_漢字)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox入金予定日e)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox入金予定日s)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox入金日e)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox入金日s)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox請求金額e)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox請求金額s)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox回収金額e)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox回収金額s)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox発注担当者)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox請求先宛名)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox請求書番号)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox品コード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox売上日e)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MaskedTextBox売上日s)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label19)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label18)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxss請求)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Buttonクリア)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox回収区分)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1237, 509)
        Me.SplitContainer1.SplitterDistance = 244
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 2
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(1085, 114)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(27, 12)
        Me.Label30.TabIndex = 388
        Me.Label30.Text = "含む"
        '
        'CheckBox債権放棄
        '
        Me.CheckBox債権放棄.AutoSize = True
        Me.CheckBox債権放棄.Location = New System.Drawing.Point(976, 202)
        Me.CheckBox債権放棄.Name = "CheckBox債権放棄"
        Me.CheckBox債権放棄.Size = New System.Drawing.Size(91, 20)
        Me.CheckBox債権放棄.TabIndex = 32
        Me.CheckBox債権放棄.Text = "債権放棄"
        Me.CheckBox債権放棄.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(1106, 64)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(27, 12)
        Me.Label29.TabIndex = 71
        Me.Label29.Text = "含む"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(448, 114)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(27, 12)
        Me.Label28.TabIndex = 70
        Me.Label28.Text = "含む"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.Location = New System.Drawing.Point(484, 164)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(27, 12)
        Me.Label27.TabIndex = 69
        Me.Label27.Text = "含む"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.Location = New System.Drawing.Point(484, 139)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(27, 12)
        Me.Label26.TabIndex = 68
        Me.Label26.Text = "含む"
        '
        'CheckBox債権放棄非表示
        '
        Me.CheckBox債権放棄非表示.AutoSize = True
        Me.CheckBox債権放棄非表示.Location = New System.Drawing.Point(1073, 202)
        Me.CheckBox債権放棄非表示.Name = "CheckBox債権放棄非表示"
        Me.CheckBox債権放棄非表示.Size = New System.Drawing.Size(139, 20)
        Me.CheckBox債権放棄非表示.TabIndex = 33
        Me.CheckBox債権放棄非表示.Text = "債権放棄非表示"
        Me.CheckBox債権放棄非表示.UseVisualStyleBackColor = True
        '
        'CheckBox督促状発行未入金
        '
        Me.CheckBox督促状発行未入金.AutoSize = True
        Me.CheckBox督促状発行未入金.Location = New System.Drawing.Point(641, 202)
        Me.CheckBox督促状発行未入金.Name = "CheckBox督促状発行未入金"
        Me.CheckBox督促状発行未入金.Size = New System.Drawing.Size(184, 20)
        Me.CheckBox督促状発行未入金.TabIndex = 30
        Me.CheckBox督促状発行未入金.Text = "督促状発行後の未入金"
        Me.CheckBox督促状発行未入金.UseVisualStyleBackColor = True
        '
        'ListBox得意先コード
        '
        Me.ListBox得意先コード.FormattingEnabled = True
        Me.ListBox得意先コード.ItemHeight = 16
        Me.ListBox得意先コード.Location = New System.Drawing.Point(99, 60)
        Me.ListBox得意先コード.Name = "ListBox得意先コード"
        Me.ListBox得意先コード.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBox得意先コード.Size = New System.Drawing.Size(120, 84)
        Me.ListBox得意先コード.TabIndex = 5
        '
        'CheckBoxSS未請求
        '
        Me.CheckBoxSS未請求.AutoSize = True
        Me.CheckBoxSS未請求.Location = New System.Drawing.Point(832, 202)
        Me.CheckBoxSS未請求.Name = "CheckBoxSS未請求"
        Me.CheckBoxSS未請求.Size = New System.Drawing.Size(137, 20)
        Me.CheckBoxSS未請求.TabIndex = 31
        Me.CheckBoxSS未請求.Text = "ss請求（未請求）"
        Me.CheckBoxSS未請求.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button検索)
        Me.GroupBox2.Controls.Add(Me.TextBox点検受付番号)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(389, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(344, 45)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Button検索
        '
        Me.Button検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button検索.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button検索.Location = New System.Drawing.Point(230, 16)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(93, 23)
        Me.Button検索.TabIndex = 4
        Me.Button検索.Text = "受付番号検索"
        Me.Button検索.UseVisualStyleBackColor = False
        '
        'TextBox点検受付番号
        '
        Me.TextBox点検受付番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox点検受付番号.Location = New System.Drawing.Point(123, 16)
        Me.TextBox点検受付番号.Name = "TextBox点検受付番号"
        Me.TextBox点検受付番号.Size = New System.Drawing.Size(101, 23)
        Me.TextBox点検受付番号.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 20)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 16)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "点検受付番号"
        '
        'CheckBox督促状発行済
        '
        Me.CheckBox督促状発行済.AutoSize = True
        Me.CheckBox督促状発行済.Location = New System.Drawing.Point(495, 202)
        Me.CheckBox督促状発行済.Name = "CheckBox督促状発行済"
        Me.CheckBox督促状発行済.Size = New System.Drawing.Size(139, 20)
        Me.CheckBox督促状発行済.TabIndex = 29
        Me.CheckBox督促状発行済.Text = "督促状発行（済）"
        Me.CheckBox督促状発行済.UseVisualStyleBackColor = True
        '
        'CheckBox未入金
        '
        Me.CheckBox未入金.AutoSize = True
        Me.CheckBox未入金.Location = New System.Drawing.Point(17, 202)
        Me.CheckBox未入金.Name = "CheckBox未入金"
        Me.CheckBox未入金.Size = New System.Drawing.Size(75, 20)
        Me.CheckBox未入金.TabIndex = 26
        Me.CheckBox未入金.Text = "未入金"
        Me.CheckBox未入金.UseVisualStyleBackColor = True
        '
        'CheckBox請求書再発行超過
        '
        Me.CheckBox請求書再発行超過.AutoSize = True
        Me.CheckBox請求書再発行超過.Location = New System.Drawing.Point(261, 202)
        Me.CheckBox請求書再発行超過.Name = "CheckBox請求書再発行超過"
        Me.CheckBox請求書再発行超過.Size = New System.Drawing.Size(227, 20)
        Me.CheckBox請求書再発行超過.TabIndex = 28
        Me.CheckBox請求書再発行超過.Text = "請求書再発行から基準日超過"
        Me.CheckBox請求書再発行超過.UseVisualStyleBackColor = True
        '
        'CheckBox請求書再発行済
        '
        Me.CheckBox請求書再発行済.AutoSize = True
        Me.CheckBox請求書再発行済.Location = New System.Drawing.Point(100, 202)
        Me.CheckBox請求書再発行済.Name = "CheckBox請求書再発行済"
        Me.CheckBox請求書再発行済.Size = New System.Drawing.Size(155, 20)
        Me.CheckBox請求書再発行済.TabIndex = 27
        Me.CheckBox請求書再発行済.Text = "請求書再発行（済）"
        Me.CheckBox請求書再発行済.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(915, 111)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 16)
        Me.Label25.TabIndex = 62
        Me.Label25.Text = "備考"
        '
        'TextBox備考
        '
        Me.TextBox備考.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox備考.Location = New System.Drawing.Point(957, 106)
        Me.TextBox備考.Name = "TextBox備考"
        Me.TextBox備考.Size = New System.Drawing.Size(122, 23)
        Me.TextBox備考.TabIndex = 24
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(714, 109)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(24, 16)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "～"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(713, 84)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(24, 16)
        Me.Label23.TabIndex = 59
        Me.Label23.Text = "～"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(713, 161)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 16)
        Me.Label22.TabIndex = 58
        Me.Label22.Text = "～"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(713, 135)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 16)
        Me.Label21.TabIndex = 57
        Me.Label21.Text = "～"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(713, 59)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(24, 16)
        Me.Label20.TabIndex = 56
        Me.Label20.Text = "～"
        '
        'TextBox確認者
        '
        Me.TextBox確認者.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox確認者.Location = New System.Drawing.Point(957, 81)
        Me.TextBox確認者.Name = "TextBox確認者"
        Me.TextBox確認者.Size = New System.Drawing.Size(122, 23)
        Me.TextBox確認者.TabIndex = 23
        '
        'TextBox入金内容確認
        '
        Me.TextBox入金内容確認.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox入金内容確認.Location = New System.Drawing.Point(957, 56)
        Me.TextBox入金内容確認.Name = "TextBox入金内容確認"
        Me.TextBox入金内容確認.Size = New System.Drawing.Size(147, 23)
        Me.TextBox入金内容確認.TabIndex = 22
        '
        'TextBox備考_漢字
        '
        Me.TextBox備考_漢字.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox備考_漢字.Location = New System.Drawing.Point(336, 156)
        Me.TextBox備考_漢字.Name = "TextBox備考_漢字"
        Me.TextBox備考_漢字.Size = New System.Drawing.Size(146, 23)
        Me.TextBox備考_漢字.TabIndex = 11
        '
        'MaskedTextBox入金予定日e
        '
        Me.MaskedTextBox入金予定日e.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaskedTextBox入金予定日e.Location = New System.Drawing.Point(739, 156)
        Me.MaskedTextBox入金予定日e.Mask = "0000/00/00"
        Me.MaskedTextBox入金予定日e.Name = "MaskedTextBox入金予定日e"
        Me.MaskedTextBox入金予定日e.Size = New System.Drawing.Size(92, 23)
        Me.MaskedTextBox入金予定日e.TabIndex = 21
        Me.MaskedTextBox入金予定日e.ValidatingType = GetType(Date)
        '
        'MaskedTextBox入金予定日s
        '
        Me.MaskedTextBox入金予定日s.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaskedTextBox入金予定日s.Location = New System.Drawing.Point(620, 156)
        Me.MaskedTextBox入金予定日s.Mask = "0000/00/00"
        Me.MaskedTextBox入金予定日s.Name = "MaskedTextBox入金予定日s"
        Me.MaskedTextBox入金予定日s.Size = New System.Drawing.Size(92, 23)
        Me.MaskedTextBox入金予定日s.TabIndex = 20
        Me.MaskedTextBox入金予定日s.ValidatingType = GetType(Date)
        '
        'MaskedTextBox入金日e
        '
        Me.MaskedTextBox入金日e.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaskedTextBox入金日e.Location = New System.Drawing.Point(739, 130)
        Me.MaskedTextBox入金日e.Mask = "0000/00/00"
        Me.MaskedTextBox入金日e.Name = "MaskedTextBox入金日e"
        Me.MaskedTextBox入金日e.Size = New System.Drawing.Size(92, 23)
        Me.MaskedTextBox入金日e.TabIndex = 19
        Me.MaskedTextBox入金日e.ValidatingType = GetType(Date)
        '
        'MaskedTextBox入金日s
        '
        Me.MaskedTextBox入金日s.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaskedTextBox入金日s.Location = New System.Drawing.Point(620, 130)
        Me.MaskedTextBox入金日s.Mask = "0000/00/00"
        Me.MaskedTextBox入金日s.Name = "MaskedTextBox入金日s"
        Me.MaskedTextBox入金日s.Size = New System.Drawing.Size(92, 23)
        Me.MaskedTextBox入金日s.TabIndex = 18
        Me.MaskedTextBox入金日s.ValidatingType = GetType(Date)
        '
        'TextBox請求金額e
        '
        Me.TextBox請求金額e.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox請求金額e.Location = New System.Drawing.Point(739, 105)
        Me.TextBox請求金額e.Name = "TextBox請求金額e"
        Me.TextBox請求金額e.Size = New System.Drawing.Size(92, 23)
        Me.TextBox請求金額e.TabIndex = 17
        '
        'TextBox請求金額s
        '
        Me.TextBox請求金額s.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox請求金額s.Location = New System.Drawing.Point(620, 105)
        Me.TextBox請求金額s.Name = "TextBox請求金額s"
        Me.TextBox請求金額s.Size = New System.Drawing.Size(92, 23)
        Me.TextBox請求金額s.TabIndex = 16
        '
        'TextBox回収金額e
        '
        Me.TextBox回収金額e.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox回収金額e.Location = New System.Drawing.Point(739, 80)
        Me.TextBox回収金額e.Name = "TextBox回収金額e"
        Me.TextBox回収金額e.Size = New System.Drawing.Size(92, 23)
        Me.TextBox回収金額e.TabIndex = 15
        '
        'TextBox回収金額s
        '
        Me.TextBox回収金額s.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox回収金額s.Location = New System.Drawing.Point(620, 80)
        Me.TextBox回収金額s.Name = "TextBox回収金額s"
        Me.TextBox回収金額s.Size = New System.Drawing.Size(92, 23)
        Me.TextBox回収金額s.TabIndex = 14
        '
        'TextBox発注担当者
        '
        Me.TextBox発注担当者.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox発注担当者.Location = New System.Drawing.Point(336, 106)
        Me.TextBox発注担当者.Name = "TextBox発注担当者"
        Me.TextBox発注担当者.Size = New System.Drawing.Size(110, 23)
        Me.TextBox発注担当者.TabIndex = 9
        '
        'TextBox請求先宛名
        '
        Me.TextBox請求先宛名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求先宛名.Location = New System.Drawing.Point(336, 131)
        Me.TextBox請求先宛名.Name = "TextBox請求先宛名"
        Me.TextBox請求先宛名.Size = New System.Drawing.Size(146, 23)
        Me.TextBox請求先宛名.TabIndex = 10
        '
        'TextBox請求書番号
        '
        Me.TextBox請求書番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox請求書番号.Location = New System.Drawing.Point(336, 57)
        Me.TextBox請求書番号.Name = "TextBox請求書番号"
        Me.TextBox請求書番号.Size = New System.Drawing.Size(92, 23)
        Me.TextBox請求書番号.TabIndex = 7
        '
        'TextBox品コード
        '
        Me.TextBox品コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox品コード.Location = New System.Drawing.Point(336, 81)
        Me.TextBox品コード.Name = "TextBox品コード"
        Me.TextBox品コード.Size = New System.Drawing.Size(92, 23)
        Me.TextBox品コード.TabIndex = 8
        '
        'MaskedTextBox売上日e
        '
        Me.MaskedTextBox売上日e.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaskedTextBox売上日e.Location = New System.Drawing.Point(739, 55)
        Me.MaskedTextBox売上日e.Mask = "0000/00/00"
        Me.MaskedTextBox売上日e.Name = "MaskedTextBox売上日e"
        Me.MaskedTextBox売上日e.Size = New System.Drawing.Size(92, 23)
        Me.MaskedTextBox売上日e.TabIndex = 13
        Me.MaskedTextBox売上日e.ValidatingType = GetType(Date)
        '
        'MaskedTextBox売上日s
        '
        Me.MaskedTextBox売上日s.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaskedTextBox売上日s.Location = New System.Drawing.Point(620, 55)
        Me.MaskedTextBox売上日s.Mask = "0000/00/00"
        Me.MaskedTextBox売上日s.Name = "MaskedTextBox売上日s"
        Me.MaskedTextBox売上日s.Size = New System.Drawing.Size(92, 23)
        Me.MaskedTextBox売上日s.TabIndex = 12
        Me.MaskedTextBox売上日s.ValidatingType = GetType(Date)
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(899, 85)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 16)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "確認者"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(246, 135)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 16)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "請求先宛名"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(851, 60)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 16)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "入金内容確認"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(530, 160)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "入金予定日"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(562, 134)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "入金日"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(546, 109)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "請求金額"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(546, 85)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "回収金額"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(246, 109)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "発注担当者"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(246, 160)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "備考（漢字）"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(246, 60)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "請求書番号"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(274, 86)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 16)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "品コード"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(562, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "売上日"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(1028, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "(YYYYMM)"
        '
        'TextBoxss請求
        '
        Me.TextBoxss請求.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxss請求.Location = New System.Drawing.Point(957, 132)
        Me.TextBoxss請求.MaxLength = 6
        Me.TextBoxss請求.Name = "TextBoxss請求"
        Me.TextBoxss請求.Size = New System.Drawing.Size(65, 23)
        Me.TextBoxss請求.TabIndex = 25
        '
        'Buttonクリア
        '
        Me.Buttonクリア.Location = New System.Drawing.Point(1121, 18)
        Me.Buttonクリア.Name = "Buttonクリア"
        Me.Buttonクリア.Size = New System.Drawing.Size(90, 23)
        Me.Buttonクリア.TabIndex = 33
        Me.Buttonクリア.Text = "条件クリア"
        Me.Buttonクリア.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(899, 135)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "ss請求"
        '
        'ComboBox回収区分
        '
        Me.ComboBox回収区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox回収区分.FormattingEnabled = True
        Me.ComboBox回収区分.Location = New System.Drawing.Point(99, 150)
        Me.ComboBox回収区分.Name = "ComboBox回収区分"
        Me.ComboBox回収区分.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox回収区分.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 61)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "得意先コード"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 155)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "回収区分"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 30)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "～"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "yyyy年MM月"
        Me.DateTimePicker2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(249, 25)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(127, 23)
        Me.DateTimePicker2.TabIndex = 1
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "yyyy年MM月"
        Me.DateTimePicker1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(94, 25)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(127, 23)
        Me.DateTimePicker1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 30)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "売上月"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1237, 260)
        Me.DataGridView1.TabIndex = 34
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Red
        Me.Label31.Location = New System.Drawing.Point(509, 6)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(224, 12)
        Me.Label31.TabIndex = 389
        Me.Label31.Text = "←実行するまで取込みデータは更新されません"
        '
        'ButtonTEST
        '
        Me.ButtonTEST.Location = New System.Drawing.Point(992, 18)
        Me.ButtonTEST.Name = "ButtonTEST"
        Me.ButtonTEST.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTEST.TabIndex = 389
        Me.ButtonTEST.Text = "TEST"
        Me.ButtonTEST.UseVisualStyleBackColor = True
        '
        'FormKaisyuukanri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 556)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormKaisyuukanri"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "回収管理"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents 検索ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox回収区分 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckBoxSS未請求 As CheckBox
    Friend WithEvents Buttonクリア As Button
    Friend WithEvents TextBoxss請求 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents MaskedTextBox入金予定日e As MaskedTextBox
    Friend WithEvents MaskedTextBox入金予定日s As MaskedTextBox
    Friend WithEvents MaskedTextBox入金日e As MaskedTextBox
    Friend WithEvents MaskedTextBox入金日s As MaskedTextBox
    Friend WithEvents TextBox請求金額e As TextBox
    Friend WithEvents TextBox請求金額s As TextBox
    Friend WithEvents TextBox回収金額e As TextBox
    Friend WithEvents TextBox回収金額s As TextBox
    Friend WithEvents TextBox発注担当者 As TextBox
    Friend WithEvents TextBox請求先宛名 As TextBox
    Friend WithEvents TextBox請求書番号 As TextBox
    Friend WithEvents TextBox品コード As TextBox
    Friend WithEvents MaskedTextBox売上日e As MaskedTextBox
    Friend WithEvents MaskedTextBox売上日s As MaskedTextBox
    Friend WithEvents TextBox点検受付番号 As TextBox
    Friend WithEvents CheckBox督促状発行済 As CheckBox
    Friend WithEvents CheckBox未入金 As CheckBox
    Friend WithEvents CheckBox請求書再発行超過 As CheckBox
    Friend WithEvents CheckBox請求書再発行済 As CheckBox
    Friend WithEvents CheckBox債権放棄非表示 As CheckBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TextBox備考 As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox確認者 As TextBox
    Friend WithEvents TextBox入金内容確認 As TextBox
    Friend WithEvents TextBox備考_漢字 As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBox督促状発行未入金 As CheckBox
    Friend WithEvents ListBox得意先コード As ListBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents CheckBox債権放棄 As CheckBox
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents Label30 As Label
    Friend WithEvents 入金予定日登録ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 取込みToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 更新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label31 As Label
    Friend WithEvents Button検索 As Button
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ButtonTEST As Button
End Class
