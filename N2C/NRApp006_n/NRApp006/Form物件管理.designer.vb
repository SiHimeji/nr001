<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form物件管理
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form物件管理))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.新規ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLERAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.入力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox更新時間 = New System.Windows.Forms.ToolStripTextBox()
        Me.最終更新日ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.CheckBox完了 = New System.Windows.Forms.CheckBox()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.TextBox条件１ = New System.Windows.Forms.TextBox()
        Me.ComboBoxJy = New System.Windows.Forms.ComboBox()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TextBox完了日 = New System.Windows.Forms.TextBox()
        Me.TextBox入力日 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button請求書納期CLR = New System.Windows.Forms.Button()
        Me.Button請求締日CLR = New System.Windows.Forms.Button()
        Me.Button工期開始日CLR = New System.Windows.Forms.Button()
        Me.Button点検時写真メモCLR = New System.Windows.Forms.Button()
        Me.ButtonメモCLR = New System.Windows.Forms.Button()
        Me.Button請求備考CLR = New System.Windows.Forms.Button()
        Me.Button工期終了日CLR = New System.Windows.Forms.Button()
        Me.Button台数CLR = New System.Windows.Forms.Button()
        Me.ComboBox請求書 = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ComboBox点検結果票変更 = New System.Windows.Forms.ComboBox()
        Me.ComboBox点検時写真 = New System.Windows.Forms.ComboBox()
        Me.ComboBox点検結果表請求書同封 = New System.Windows.Forms.ComboBox()
        Me.TextBox点検時写真メモ = New System.Windows.Forms.TextBox()
        Me.ComboBox請求方法 = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBoxメモ = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox請求備考 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox請求締日 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox請求書納期 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBox工期開始日 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox工期終了日 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox台数 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button請求送付先電話番号CLR = New System.Windows.Forms.Button()
        Me.Button請求送付先郵便番号CLR = New System.Windows.Forms.Button()
        Me.Button請求書宛名CLR = New System.Windows.Forms.Button()
        Me.Button請求書送付先住所CLR = New System.Windows.Forms.Button()
        Me.Button請求書送付先担当者CLR = New System.Windows.Forms.Button()
        Me.Button請求先送付先会社名CLR = New System.Windows.Forms.Button()
        Me.TextBox請求書送付先担当者 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextBox請求送付先電話番号 = New System.Windows.Forms.TextBox()
        Me.TextBox請求送付先郵便番号 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox請求書宛名 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox請求書送付先住所 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox請求先送付先会社名 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button依頼元fax番号CLR = New System.Windows.Forms.Button()
        Me.Button依頼元電話番号CLR = New System.Windows.Forms.Button()
        Me.Button依頼元担当者名CLR = New System.Windows.Forms.Button()
        Me.Button依頼元部署名CLR = New System.Windows.Forms.Button()
        Me.Button依頼元会社名CLR = New System.Windows.Forms.Button()
        Me.TextBox依頼元fax番号 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox依頼元電話番号 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox依頼元担当者名 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox依頼元部署名 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox依頼元会社名 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.TextBox入力者 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxNo = New System.Windows.Forms.TextBox()
        Me.CheckBox完了１ = New System.Windows.Forms.CheckBox()
        Me.Button条件１CLR = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.新規ToolStripMenuItem, Me.CLERAToolStripMenuItem, Me.出力ToolStripMenuItem, Me.入力ToolStripMenuItem, Me.ToolStripTextBox更新時間, Me.最終更新日ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(960, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 23)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '新規ToolStripMenuItem
        '
        Me.新規ToolStripMenuItem.Name = "新規ToolStripMenuItem"
        Me.新規ToolStripMenuItem.Size = New System.Drawing.Size(43, 23)
        Me.新規ToolStripMenuItem.Text = "新規"
        '
        'CLERAToolStripMenuItem
        '
        Me.CLERAToolStripMenuItem.Name = "CLERAToolStripMenuItem"
        Me.CLERAToolStripMenuItem.Size = New System.Drawing.Size(45, 23)
        Me.CLERAToolStripMenuItem.Text = "クリア"
        '
        '出力ToolStripMenuItem
        '
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem1, Me.CSVToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 23)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'EXCELToolStripMenuItem1
        '
        Me.EXCELToolStripMenuItem1.Name = "EXCELToolStripMenuItem1"
        Me.EXCELToolStripMenuItem1.Size = New System.Drawing.Size(106, 22)
        Me.EXCELToolStripMenuItem1.Text = "EXCEL"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.CSVToolStripMenuItem.Text = "CSV"
        '
        '入力ToolStripMenuItem
        '
        Me.入力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem})
        Me.入力ToolStripMenuItem.Name = "入力ToolStripMenuItem"
        Me.入力ToolStripMenuItem.Size = New System.Drawing.Size(43, 23)
        Me.入力ToolStripMenuItem.Text = "入力"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        'ToolStripTextBox更新時間
        '
        Me.ToolStripTextBox更新時間.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripTextBox更新時間.Name = "ToolStripTextBox更新時間"
        Me.ToolStripTextBox更新時間.ReadOnly = True
        Me.ToolStripTextBox更新時間.Size = New System.Drawing.Size(120, 23)
        '
        '最終更新日ToolStripMenuItem
        '
        Me.最終更新日ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.最終更新日ToolStripMenuItem.Name = "最終更新日ToolStripMenuItem"
        Me.最終更新日ToolStripMenuItem.Size = New System.Drawing.Size(79, 23)
        Me.最終更新日ToolStripMenuItem.Text = "最終更新日"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 700)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(960, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel2.Text = "  "
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 27)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox完了日)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox入力日)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button更新)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox入力者)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBoxNo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CheckBox完了１)
        Me.SplitContainer1.Size = New System.Drawing.Size(960, 673)
        Me.SplitContainer1.SplitterDistance = 313
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SplitContainer2.Panel1.Controls.Add(Me.Button条件１CLR)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CheckBox完了)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ComboBoxJy1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TextBox条件１)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ComboBoxJy)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Button検索)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridView2)
        Me.SplitContainer2.Size = New System.Drawing.Size(311, 671)
        Me.SplitContainer2.SplitterDistance = 96
        Me.SplitContainer2.TabIndex = 0
        '
        'CheckBox完了
        '
        Me.CheckBox完了.AutoSize = True
        Me.CheckBox完了.Checked = True
        Me.CheckBox完了.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox完了.Location = New System.Drawing.Point(215, 9)
        Me.CheckBox完了.Name = "CheckBox完了"
        Me.CheckBox完了.Size = New System.Drawing.Size(88, 16)
        Me.CheckBox完了.TabIndex = 5
        Me.CheckBox完了.Text = "完了を含める"
        Me.CheckBox完了.UseVisualStyleBackColor = True
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(257, 36)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(49, 20)
        Me.ComboBoxJy1.TabIndex = 4
        '
        'TextBox条件１
        '
        Me.TextBox条件１.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox条件１.Location = New System.Drawing.Point(6, 36)
        Me.TextBox条件１.MaxLength = 200
        Me.TextBox条件１.Name = "TextBox条件１"
        Me.TextBox条件１.Size = New System.Drawing.Size(224, 19)
        Me.TextBox条件１.TabIndex = 3
        '
        'ComboBoxJy
        '
        Me.ComboBoxJy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy.FormattingEnabled = True
        Me.ComboBoxJy.Location = New System.Drawing.Point(6, 10)
        Me.ComboBoxJy.Name = "ComboBoxJy"
        Me.ComboBoxJy.Size = New System.Drawing.Size(142, 20)
        Me.ComboBoxJy.TabIndex = 2
        '
        'Button検索
        '
        Me.Button検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button検索.Location = New System.Drawing.Point(210, 62)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(93, 23)
        Me.Button検索.TabIndex = 1
        Me.Button検索.Text = "検索"
        Me.Button検索.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(311, 571)
        Me.DataGridView1.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(160, 479)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 21
        Me.DataGridView2.Size = New System.Drawing.Size(151, 18)
        Me.DataGridView2.TabIndex = 48
        Me.DataGridView2.Visible = False
        '
        'TextBox完了日
        '
        Me.TextBox完了日.Location = New System.Drawing.Point(513, 32)
        Me.TextBox完了日.Name = "TextBox完了日"
        Me.TextBox完了日.ReadOnly = True
        Me.TextBox完了日.Size = New System.Drawing.Size(113, 19)
        Me.TextBox完了日.TabIndex = 53
        '
        'TextBox入力日
        '
        Me.TextBox入力日.Location = New System.Drawing.Point(166, 33)
        Me.TextBox入力日.Name = "TextBox入力日"
        Me.TextBox入力日.Size = New System.Drawing.Size(104, 19)
        Me.TextBox入力日.TabIndex = 52
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Button請求書納期CLR)
        Me.GroupBox3.Controls.Add(Me.Button請求締日CLR)
        Me.GroupBox3.Controls.Add(Me.Button工期開始日CLR)
        Me.GroupBox3.Controls.Add(Me.Button点検時写真メモCLR)
        Me.GroupBox3.Controls.Add(Me.ButtonメモCLR)
        Me.GroupBox3.Controls.Add(Me.Button請求備考CLR)
        Me.GroupBox3.Controls.Add(Me.Button工期終了日CLR)
        Me.GroupBox3.Controls.Add(Me.Button台数CLR)
        Me.GroupBox3.Controls.Add(Me.ComboBox請求書)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.ComboBox点検結果票変更)
        Me.GroupBox3.Controls.Add(Me.ComboBox点検時写真)
        Me.GroupBox3.Controls.Add(Me.ComboBox点検結果表請求書同封)
        Me.GroupBox3.Controls.Add(Me.TextBox点検時写真メモ)
        Me.GroupBox3.Controls.Add(Me.ComboBox請求方法)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.TextBoxメモ)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.TextBox請求備考)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.TextBox請求締日)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.TextBox請求書納期)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.TextBox工期開始日)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.TextBox工期終了日)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.TextBox台数)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 379)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(609, 282)
        Me.GroupBox3.TabIndex = 51
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "請求時依頼内容"
        '
        'Button請求書納期CLR
        '
        Me.Button請求書納期CLR.Location = New System.Drawing.Point(569, 56)
        Me.Button請求書納期CLR.Name = "Button請求書納期CLR"
        Me.Button請求書納期CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求書納期CLR.TabIndex = 71
        Me.Button請求書納期CLR.Text = "X"
        Me.Button請求書納期CLR.UseVisualStyleBackColor = True
        '
        'Button請求締日CLR
        '
        Me.Button請求締日CLR.Location = New System.Drawing.Point(393, 78)
        Me.Button請求締日CLR.Name = "Button請求締日CLR"
        Me.Button請求締日CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求締日CLR.TabIndex = 70
        Me.Button請求締日CLR.Text = "X"
        Me.Button請求締日CLR.UseVisualStyleBackColor = True
        '
        'Button工期開始日CLR
        '
        Me.Button工期開始日CLR.Location = New System.Drawing.Point(254, 34)
        Me.Button工期開始日CLR.Name = "Button工期開始日CLR"
        Me.Button工期開始日CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button工期開始日CLR.TabIndex = 69
        Me.Button工期開始日CLR.Text = "X"
        Me.Button工期開始日CLR.UseVisualStyleBackColor = True
        '
        'Button点検時写真メモCLR
        '
        Me.Button点検時写真メモCLR.Location = New System.Drawing.Point(569, 255)
        Me.Button点検時写真メモCLR.Name = "Button点検時写真メモCLR"
        Me.Button点検時写真メモCLR.Size = New System.Drawing.Size(26, 19)
        Me.Button点検時写真メモCLR.TabIndex = 68
        Me.Button点検時写真メモCLR.Text = "X"
        Me.Button点検時写真メモCLR.UseVisualStyleBackColor = True
        '
        'ButtonメモCLR
        '
        Me.ButtonメモCLR.Location = New System.Drawing.Point(569, 158)
        Me.ButtonメモCLR.Name = "ButtonメモCLR"
        Me.ButtonメモCLR.Size = New System.Drawing.Size(26, 19)
        Me.ButtonメモCLR.TabIndex = 67
        Me.ButtonメモCLR.Text = "X"
        Me.ButtonメモCLR.UseVisualStyleBackColor = True
        '
        'Button請求備考CLR
        '
        Me.Button請求備考CLR.Location = New System.Drawing.Point(569, 102)
        Me.Button請求備考CLR.Name = "Button請求備考CLR"
        Me.Button請求備考CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求備考CLR.TabIndex = 66
        Me.Button請求備考CLR.Text = "X"
        Me.Button請求備考CLR.UseVisualStyleBackColor = True
        '
        'Button工期終了日CLR
        '
        Me.Button工期終了日CLR.Location = New System.Drawing.Point(569, 34)
        Me.Button工期終了日CLR.Name = "Button工期終了日CLR"
        Me.Button工期終了日CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button工期終了日CLR.TabIndex = 65
        Me.Button工期終了日CLR.Text = "X"
        Me.Button工期終了日CLR.UseVisualStyleBackColor = True
        '
        'Button台数CLR
        '
        Me.Button台数CLR.Location = New System.Drawing.Point(569, 13)
        Me.Button台数CLR.Name = "Button台数CLR"
        Me.Button台数CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button台数CLR.TabIndex = 64
        Me.Button台数CLR.Text = "X"
        Me.Button台数CLR.UseVisualStyleBackColor = True
        '
        'ComboBox請求書
        '
        Me.ComboBox請求書.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox請求書.FormattingEnabled = True
        Me.ComboBox請求書.Location = New System.Drawing.Point(467, 77)
        Me.ComboBox請求書.Name = "ComboBox請求書"
        Me.ComboBox請求書.Size = New System.Drawing.Size(103, 20)
        Me.ComboBox請求書.TabIndex = 63
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(258, 260)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(82, 12)
        Me.Label27.TabIndex = 62
        Me.Label27.Text = "点検時写真メモ"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(256, 226)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(167, 24)
        Me.Label22.TabIndex = 61
        Me.Label22.Text = "点検結果票氏名を" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "設置先建物名、部屋番号へ変更"
        '
        'ComboBox点検結果票変更
        '
        Me.ComboBox点検結果票変更.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox点検結果票変更.FormattingEnabled = True
        Me.ComboBox点検結果票変更.Location = New System.Drawing.Point(423, 228)
        Me.ComboBox点検結果票変更.Name = "ComboBox点検結果票変更"
        Me.ComboBox点検結果票変更.Size = New System.Drawing.Size(103, 20)
        Me.ComboBox点検結果票変更.TabIndex = 60
        '
        'ComboBox点検時写真
        '
        Me.ComboBox点検時写真.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox点検時写真.FormattingEnabled = True
        Me.ComboBox点検時写真.Location = New System.Drawing.Point(136, 256)
        Me.ComboBox点検時写真.Name = "ComboBox点検時写真"
        Me.ComboBox点検時写真.Size = New System.Drawing.Size(103, 20)
        Me.ComboBox点検時写真.TabIndex = 59
        '
        'ComboBox点検結果表請求書同封
        '
        Me.ComboBox点検結果表請求書同封.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox点検結果表請求書同封.FormattingEnabled = True
        Me.ComboBox点検結果表請求書同封.Location = New System.Drawing.Point(136, 228)
        Me.ComboBox点検結果表請求書同封.Name = "ComboBox点検結果表請求書同封"
        Me.ComboBox点検結果表請求書同封.Size = New System.Drawing.Size(103, 20)
        Me.ComboBox点検結果表請求書同封.TabIndex = 58
        '
        'TextBox点検時写真メモ
        '
        Me.TextBox点検時写真メモ.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox点検時写真メモ.Location = New System.Drawing.Point(346, 255)
        Me.TextBox点検時写真メモ.MaxLength = 200
        Me.TextBox点検時写真メモ.Multiline = True
        Me.TextBox点検時写真メモ.Name = "TextBox点検時写真メモ"
        Me.TextBox点検時写真メモ.Size = New System.Drawing.Size(223, 22)
        Me.TextBox点検時写真メモ.TabIndex = 57
        '
        'ComboBox請求方法
        '
        Me.ComboBox請求方法.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox請求方法.FormattingEnabled = True
        Me.ComboBox請求方法.Location = New System.Drawing.Point(104, 55)
        Me.ComboBox請求方法.Name = "ComboBox請求方法"
        Me.ComboBox請求方法.Size = New System.Drawing.Size(103, 20)
        Me.ComboBox請求方法.TabIndex = 54
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(47, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 12)
        Me.Label19.TabIndex = 53
        Me.Label19.Text = "請求方法"
        '
        'TextBoxメモ
        '
        Me.TextBoxメモ.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBoxメモ.Location = New System.Drawing.Point(104, 158)
        Me.TextBoxメモ.MaxLength = 2048
        Me.TextBoxメモ.Multiline = True
        Me.TextBoxメモ.Name = "TextBoxメモ"
        Me.TextBoxメモ.Size = New System.Drawing.Size(465, 64)
        Me.TextBoxメモ.TabIndex = 51
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(78, 161)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(22, 12)
        Me.Label26.TabIndex = 52
        Me.Label26.Text = "メモ"
        '
        'TextBox請求備考
        '
        Me.TextBox請求備考.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求備考.Location = New System.Drawing.Point(104, 102)
        Me.TextBox請求備考.MaxLength = 2048
        Me.TextBox請求備考.Multiline = True
        Me.TextBox請求備考.Name = "TextBox請求備考"
        Me.TextBox請求備考.Size = New System.Drawing.Size(465, 53)
        Me.TextBox請求備考.TabIndex = 49
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(47, 102)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 12)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "請求備考"
        '
        'TextBox請求締日
        '
        Me.TextBox請求締日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox請求締日.Location = New System.Drawing.Point(104, 78)
        Me.TextBox請求締日.MaxLength = 50
        Me.TextBox請求締日.Name = "TextBox請求締日"
        Me.TextBox請求締日.Size = New System.Drawing.Size(292, 19)
        Me.TextBox請求締日.TabIndex = 47
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(47, 81)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 12)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "請求締日"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(425, 81)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 12)
        Me.Label21.TabIndex = 46
        Me.Label21.Text = "請求書"
        '
        'TextBox請求書納期
        '
        Me.TextBox請求書納期.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox請求書納期.Location = New System.Drawing.Point(400, 56)
        Me.TextBox請求書納期.MaxLength = 50
        Me.TextBox請求書納期.Name = "TextBox請求書納期"
        Me.TextBox請求書納期.Size = New System.Drawing.Size(169, 19)
        Me.TextBox請求書納期.TabIndex = 43
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 232)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(125, 12)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = "点検結果表請求書同封"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(66, 260)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 12)
        Me.Label24.TabIndex = 40
        Me.Label24.Text = "点検時写真"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(323, 59)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 12)
        Me.Label25.TabIndex = 44
        Me.Label25.Text = "請求書納期"
        '
        'TextBox工期開始日
        '
        Me.TextBox工期開始日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox工期開始日.Location = New System.Drawing.Point(104, 34)
        Me.TextBox工期開始日.MaxLength = 50
        Me.TextBox工期開始日.Name = "TextBox工期開始日"
        Me.TextBox工期開始日.Size = New System.Drawing.Size(152, 19)
        Me.TextBox工期開始日.TabIndex = 29
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 12)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "工期(開始日)"
        '
        'TextBox工期終了日
        '
        Me.TextBox工期終了日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox工期終了日.Location = New System.Drawing.Point(400, 34)
        Me.TextBox工期終了日.MaxLength = 50
        Me.TextBox工期終了日.Name = "TextBox工期終了日"
        Me.TextBox工期終了日.Size = New System.Drawing.Size(169, 19)
        Me.TextBox工期終了日.TabIndex = 27
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(323, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 12)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "工期(終了日)"
        '
        'TextBox台数
        '
        Me.TextBox台数.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox台数.Location = New System.Drawing.Point(104, 13)
        Me.TextBox台数.MaxLength = 200
        Me.TextBox台数.Name = "TextBox台数"
        Me.TextBox台数.Size = New System.Drawing.Size(465, 19)
        Me.TextBox台数.TabIndex = 23
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(71, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 12)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "台数"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Button請求送付先電話番号CLR)
        Me.GroupBox2.Controls.Add(Me.Button請求送付先郵便番号CLR)
        Me.GroupBox2.Controls.Add(Me.Button請求書宛名CLR)
        Me.GroupBox2.Controls.Add(Me.Button請求書送付先住所CLR)
        Me.GroupBox2.Controls.Add(Me.Button請求書送付先担当者CLR)
        Me.GroupBox2.Controls.Add(Me.Button請求先送付先会社名CLR)
        Me.GroupBox2.Controls.Add(Me.TextBox請求書送付先担当者)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.TextBox請求送付先電話番号)
        Me.GroupBox2.Controls.Add(Me.TextBox請求送付先郵便番号)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TextBox請求書宛名)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.TextBox請求書送付先住所)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TextBox請求先送付先会社名)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 214)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(609, 160)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "請求先情報"
        '
        'Button請求送付先電話番号CLR
        '
        Me.Button請求送付先電話番号CLR.Location = New System.Drawing.Point(255, 132)
        Me.Button請求送付先電話番号CLR.Name = "Button請求送付先電話番号CLR"
        Me.Button請求送付先電話番号CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求送付先電話番号CLR.TabIndex = 36
        Me.Button請求送付先電話番号CLR.Text = "X"
        Me.Button請求送付先電話番号CLR.UseVisualStyleBackColor = True
        '
        'Button請求送付先郵便番号CLR
        '
        Me.Button請求送付先郵便番号CLR.Location = New System.Drawing.Point(255, 68)
        Me.Button請求送付先郵便番号CLR.Name = "Button請求送付先郵便番号CLR"
        Me.Button請求送付先郵便番号CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求送付先郵便番号CLR.TabIndex = 35
        Me.Button請求送付先郵便番号CLR.Text = "X"
        Me.Button請求送付先郵便番号CLR.UseVisualStyleBackColor = True
        '
        'Button請求書宛名CLR
        '
        Me.Button請求書宛名CLR.Location = New System.Drawing.Point(570, 110)
        Me.Button請求書宛名CLR.Name = "Button請求書宛名CLR"
        Me.Button請求書宛名CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求書宛名CLR.TabIndex = 34
        Me.Button請求書宛名CLR.Text = "X"
        Me.Button請求書宛名CLR.UseVisualStyleBackColor = True
        '
        'Button請求書送付先住所CLR
        '
        Me.Button請求書送付先住所CLR.Location = New System.Drawing.Point(570, 89)
        Me.Button請求書送付先住所CLR.Name = "Button請求書送付先住所CLR"
        Me.Button請求書送付先住所CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求書送付先住所CLR.TabIndex = 33
        Me.Button請求書送付先住所CLR.Text = "X"
        Me.Button請求書送付先住所CLR.UseVisualStyleBackColor = True
        '
        'Button請求書送付先担当者CLR
        '
        Me.Button請求書送付先担当者CLR.Location = New System.Drawing.Point(570, 47)
        Me.Button請求書送付先担当者CLR.Name = "Button請求書送付先担当者CLR"
        Me.Button請求書送付先担当者CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求書送付先担当者CLR.TabIndex = 32
        Me.Button請求書送付先担当者CLR.Text = "X"
        Me.Button請求書送付先担当者CLR.UseVisualStyleBackColor = True
        '
        'Button請求先送付先会社名CLR
        '
        Me.Button請求先送付先会社名CLR.Location = New System.Drawing.Point(570, 9)
        Me.Button請求先送付先会社名CLR.Name = "Button請求先送付先会社名CLR"
        Me.Button請求先送付先会社名CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求先送付先会社名CLR.TabIndex = 31
        Me.Button請求先送付先会社名CLR.Text = "X"
        Me.Button請求先送付先会社名CLR.UseVisualStyleBackColor = True
        '
        'TextBox請求書送付先担当者
        '
        Me.TextBox請求書送付先担当者.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求書送付先担当者.Location = New System.Drawing.Point(108, 47)
        Me.TextBox請求書送付先担当者.MaxLength = 50
        Me.TextBox請求書送付先担当者.Name = "TextBox請求書送付先担当者"
        Me.TextBox請求書送付先担当者.Size = New System.Drawing.Size(463, 19)
        Me.TextBox請求書送付先担当者.TabIndex = 29
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(28, 49)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(77, 12)
        Me.Label28.TabIndex = 30
        Me.Label28.Text = "送付先担当者"
        '
        'TextBox請求送付先電話番号
        '
        Me.TextBox請求送付先電話番号.Location = New System.Drawing.Point(108, 132)
        Me.TextBox請求送付先電話番号.MaxLength = 30
        Me.TextBox請求送付先電話番号.Name = "TextBox請求送付先電話番号"
        Me.TextBox請求送付先電話番号.Size = New System.Drawing.Size(148, 19)
        Me.TextBox請求送付先電話番号.TabIndex = 28
        '
        'TextBox請求送付先郵便番号
        '
        Me.TextBox請求送付先郵便番号.Location = New System.Drawing.Point(108, 68)
        Me.TextBox請求送付先郵便番号.MaxLength = 30
        Me.TextBox請求送付先郵便番号.Name = "TextBox請求送付先郵便番号"
        Me.TextBox請求送付先郵便番号.Size = New System.Drawing.Size(148, 19)
        Me.TextBox請求送付先郵便番号.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 12)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "送付先電話番号"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "送付先郵便番号"
        '
        'TextBox請求書宛名
        '
        Me.TextBox請求書宛名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求書宛名.Location = New System.Drawing.Point(108, 110)
        Me.TextBox請求書宛名.MaxLength = 200
        Me.TextBox請求書宛名.Name = "TextBox請求書宛名"
        Me.TextBox請求書宛名.Size = New System.Drawing.Size(463, 19)
        Me.TextBox請求書宛名.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(76, 114)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 12)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "宛名"
        '
        'TextBox請求書送付先住所
        '
        Me.TextBox請求書送付先住所.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求書送付先住所.Location = New System.Drawing.Point(108, 89)
        Me.TextBox請求書送付先住所.MaxLength = 200
        Me.TextBox請求書送付先住所.Name = "TextBox請求書送付先住所"
        Me.TextBox請求書送付先住所.Size = New System.Drawing.Size(463, 19)
        Me.TextBox請求書送付先住所.TabIndex = 21
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(40, 92)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "送付先住所"
        '
        'TextBox請求先送付先会社名
        '
        Me.TextBox請求先送付先会社名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求先送付先会社名.Location = New System.Drawing.Point(108, 9)
        Me.TextBox請求先送付先会社名.MaxLength = 200
        Me.TextBox請求先送付先会社名.Multiline = True
        Me.TextBox請求先送付先会社名.Name = "TextBox請求先送付先会社名"
        Me.TextBox請求先送付先会社名.Size = New System.Drawing.Size(463, 36)
        Me.TextBox請求先送付先会社名.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(28, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 12)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "送付先会社名"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Button依頼元fax番号CLR)
        Me.GroupBox1.Controls.Add(Me.Button依頼元電話番号CLR)
        Me.GroupBox1.Controls.Add(Me.Button依頼元担当者名CLR)
        Me.GroupBox1.Controls.Add(Me.Button依頼元部署名CLR)
        Me.GroupBox1.Controls.Add(Me.Button依頼元会社名CLR)
        Me.GroupBox1.Controls.Add(Me.TextBox依頼元fax番号)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TextBox依頼元電話番号)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextBox依頼元担当者名)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextBox依頼元部署名)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TextBox依頼元会社名)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(609, 150)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "依頼元情報"
        '
        'Button依頼元fax番号CLR
        '
        Me.Button依頼元fax番号CLR.Location = New System.Drawing.Point(571, 122)
        Me.Button依頼元fax番号CLR.Name = "Button依頼元fax番号CLR"
        Me.Button依頼元fax番号CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button依頼元fax番号CLR.TabIndex = 22
        Me.Button依頼元fax番号CLR.Text = "X"
        Me.Button依頼元fax番号CLR.UseVisualStyleBackColor = True
        '
        'Button依頼元電話番号CLR
        '
        Me.Button依頼元電話番号CLR.Location = New System.Drawing.Point(571, 100)
        Me.Button依頼元電話番号CLR.Name = "Button依頼元電話番号CLR"
        Me.Button依頼元電話番号CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button依頼元電話番号CLR.TabIndex = 21
        Me.Button依頼元電話番号CLR.Text = "X"
        Me.Button依頼元電話番号CLR.UseVisualStyleBackColor = True
        '
        'Button依頼元担当者名CLR
        '
        Me.Button依頼元担当者名CLR.Location = New System.Drawing.Point(571, 78)
        Me.Button依頼元担当者名CLR.Name = "Button依頼元担当者名CLR"
        Me.Button依頼元担当者名CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button依頼元担当者名CLR.TabIndex = 20
        Me.Button依頼元担当者名CLR.Text = "X"
        Me.Button依頼元担当者名CLR.UseVisualStyleBackColor = True
        '
        'Button依頼元部署名CLR
        '
        Me.Button依頼元部署名CLR.Location = New System.Drawing.Point(571, 55)
        Me.Button依頼元部署名CLR.Name = "Button依頼元部署名CLR"
        Me.Button依頼元部署名CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button依頼元部署名CLR.TabIndex = 19
        Me.Button依頼元部署名CLR.Text = "X"
        Me.Button依頼元部署名CLR.UseVisualStyleBackColor = True
        '
        'Button依頼元会社名CLR
        '
        Me.Button依頼元会社名CLR.Location = New System.Drawing.Point(571, 14)
        Me.Button依頼元会社名CLR.Name = "Button依頼元会社名CLR"
        Me.Button依頼元会社名CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button依頼元会社名CLR.TabIndex = 18
        Me.Button依頼元会社名CLR.Text = "X"
        Me.Button依頼元会社名CLR.UseVisualStyleBackColor = True
        '
        'TextBox依頼元fax番号
        '
        Me.TextBox依頼元fax番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox依頼元fax番号.Location = New System.Drawing.Point(109, 122)
        Me.TextBox依頼元fax番号.MaxLength = 50
        Me.TextBox依頼元fax番号.Name = "TextBox依頼元fax番号"
        Me.TextBox依頼元fax番号.Size = New System.Drawing.Size(463, 19)
        Me.TextBox依頼元fax番号.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(54, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 12)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "FAX番号"
        '
        'TextBox依頼元電話番号
        '
        Me.TextBox依頼元電話番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox依頼元電話番号.Location = New System.Drawing.Point(109, 100)
        Me.TextBox依頼元電話番号.MaxLength = 50
        Me.TextBox依頼元電話番号.Name = "TextBox依頼元電話番号"
        Me.TextBox依頼元電話番号.Size = New System.Drawing.Size(463, 19)
        Me.TextBox依頼元電話番号.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(52, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 12)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "電話番号"
        '
        'TextBox依頼元担当者名
        '
        Me.TextBox依頼元担当者名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox依頼元担当者名.Location = New System.Drawing.Point(109, 78)
        Me.TextBox依頼元担当者名.MaxLength = 50
        Me.TextBox依頼元担当者名.Name = "TextBox依頼元担当者名"
        Me.TextBox依頼元担当者名.Size = New System.Drawing.Size(463, 19)
        Me.TextBox依頼元担当者名.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "担当者名"
        '
        'TextBox依頼元部署名
        '
        Me.TextBox依頼元部署名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox依頼元部署名.Location = New System.Drawing.Point(109, 55)
        Me.TextBox依頼元部署名.MaxLength = 50
        Me.TextBox依頼元部署名.Name = "TextBox依頼元部署名"
        Me.TextBox依頼元部署名.Size = New System.Drawing.Size(463, 19)
        Me.TextBox依頼元部署名.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(64, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "部署名"
        '
        'TextBox依頼元会社名
        '
        Me.TextBox依頼元会社名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox依頼元会社名.Location = New System.Drawing.Point(109, 14)
        Me.TextBox依頼元会社名.MaxLength = 200
        Me.TextBox依頼元会社名.Multiline = True
        Me.TextBox依頼元会社名.Name = "TextBox依頼元会社名"
        Me.TextBox依頼元会社名.Size = New System.Drawing.Size(463, 38)
        Me.TextBox依頼元会社名.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(64, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "会社名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 12)
        Me.Label2.TabIndex = 7
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.Lime
        Me.Button更新.Location = New System.Drawing.Point(513, 5)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(114, 26)
        Me.Button更新.TabIndex = 22
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'TextBox入力者
        '
        Me.TextBox入力者.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox入力者.Location = New System.Drawing.Point(320, 32)
        Me.TextBox入力者.Name = "TextBox入力者"
        Me.TextBox入力者.Size = New System.Drawing.Size(123, 19)
        Me.TextBox入力者.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(277, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "入力者"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(123, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "入力日"
        '
        'TextBoxNo
        '
        Me.TextBoxNo.Location = New System.Drawing.Point(41, 32)
        Me.TextBoxNo.Name = "TextBoxNo"
        Me.TextBoxNo.ReadOnly = True
        Me.TextBoxNo.Size = New System.Drawing.Size(76, 19)
        Me.TextBoxNo.TabIndex = 1
        '
        'CheckBox完了１
        '
        Me.CheckBox完了１.AutoSize = True
        Me.CheckBox完了１.Location = New System.Drawing.Point(461, 34)
        Me.CheckBox完了１.Name = "CheckBox完了１"
        Me.CheckBox完了１.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox完了１.TabIndex = 47
        Me.CheckBox完了１.Text = "完了"
        Me.CheckBox完了１.UseVisualStyleBackColor = True
        '
        'Button条件１CLR
        '
        Me.Button条件１CLR.Location = New System.Drawing.Point(229, 36)
        Me.Button条件１CLR.Name = "Button条件１CLR"
        Me.Button条件１CLR.Size = New System.Drawing.Size(26, 19)
        Me.Button条件１CLR.TabIndex = 19
        Me.Button条件１CLR.Text = "X"
        Me.Button条件１CLR.UseVisualStyleBackColor = True
        '
        'Form物件管理
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 722)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form物件管理"
        Me.Text = "物件管理"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 入力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button検索 As Button
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents TextBox条件１ As TextBox
    Friend WithEvents ComboBoxJy As ComboBox
    Friend WithEvents 新規ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox入力者 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxNo As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckBox完了 As CheckBox
    Friend WithEvents CheckBox完了１ As CheckBox
    Friend WithEvents Button更新 As Button
    Friend WithEvents ToolStripTextBox更新時間 As ToolStripTextBox
    Friend WithEvents CLERAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBox請求備考 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox請求締日 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox請求書納期 As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TextBox工期開始日 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox工期終了日 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox台数 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox請求書宛名 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox請求書送付先住所 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox請求先送付先会社名 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox依頼元fax番号 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox依頼元電話番号 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox依頼元担当者名 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox依頼元部署名 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox依頼元会社名 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxメモ As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents ComboBox請求方法 As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBox点検時写真メモ As TextBox
    Friend WithEvents ComboBox点検時写真 As ComboBox
    Friend WithEvents ComboBox点検結果表請求書同封 As ComboBox
    Friend WithEvents TextBox請求送付先電話番号 As TextBox
    Friend WithEvents TextBox請求送付先郵便番号 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents ComboBox点検結果票変更 As ComboBox
    Friend WithEvents TextBox入力日 As DateTimePicker
    Friend WithEvents Label27 As Label
    Friend WithEvents ComboBox請求書 As ComboBox
    Friend WithEvents TextBox請求書送付先担当者 As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents TextBox完了日 As TextBox
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents 最終更新日ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button請求締日CLR As Button
    Friend WithEvents Button工期開始日CLR As Button
    Friend WithEvents Button点検時写真メモCLR As Button
    Friend WithEvents ButtonメモCLR As Button
    Friend WithEvents Button請求備考CLR As Button
    Friend WithEvents Button工期終了日CLR As Button
    Friend WithEvents Button台数CLR As Button
    Friend WithEvents Button請求送付先電話番号CLR As Button
    Friend WithEvents Button請求送付先郵便番号CLR As Button
    Friend WithEvents Button請求書宛名CLR As Button
    Friend WithEvents Button請求書送付先住所CLR As Button
    Friend WithEvents Button請求書送付先担当者CLR As Button
    Friend WithEvents Button請求先送付先会社名CLR As Button
    Friend WithEvents Button依頼元fax番号CLR As Button
    Friend WithEvents Button依頼元電話番号CLR As Button
    Friend WithEvents Button依頼元担当者名CLR As Button
    Friend WithEvents Button依頼元部署名CLR As Button
    Friend WithEvents Button依頼元会社名CLR As Button
    Friend WithEvents Button請求書納期CLR As Button
    Friend WithEvents Button条件１CLR As Button
End Class
