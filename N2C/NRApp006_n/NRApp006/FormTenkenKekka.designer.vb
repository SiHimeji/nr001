<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTenkenKekka
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTenkenKekka))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.チェックToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全ONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全OFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.反転ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.表示ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox条件 = New System.Windows.Forms.ToolStripComboBox()
        Me.取り消しToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.本日分取り消しToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel件 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel条件 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel点検項目名 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox過去を含む = New System.Windows.Forms.CheckBox()
        Me.ComboBox注意事項コメント = New System.Windows.Forms.ComboBox()
        Me.CheckBox本日作業分を含む = New System.Windows.Forms.CheckBox()
        Me.Button更新1 = New System.Windows.Forms.Button()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.ButtonCLEAR = New System.Windows.Forms.Button()
        Me.ComboBox含む = New System.Windows.Forms.ComboBox()
        Me.ListBox点検製品区分詳細名 = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ListBox点検結果 = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ListBox点検項目名 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox機器分類名 = New System.Windows.Forms.ListBox()
        Me.Labelから = New System.Windows.Forms.Label()
        Me.DateTimePicker期間2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker期間1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox期間 = New System.Windows.Forms.ComboBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button本日分結果決定 = New System.Windows.Forms.Button()
        Me.Button本日作業分呼出 = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox確認完了日 = New System.Windows.Forms.MaskedTextBox()
        Me.DateTimePicker確認完了日 = New System.Windows.Forms.DateTimePicker()
        Me.Label確認完了日 = New System.Windows.Forms.Label()
        Me.TextBox再訪問指示日 = New System.Windows.Forms.MaskedTextBox()
        Me.TextBoxRow = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxMSG = New System.Windows.Forms.TextBox()
        Me.TextBox点検製品区分詳細名 = New System.Windows.Forms.TextBox()
        Me.Button反映 = New System.Windows.Forms.Button()
        Me.TextBox再訪問指示内容 = New System.Windows.Forms.TextBox()
        Me.TextBox不備内容 = New System.Windows.Forms.TextBox()
        Me.TextBox注意事項コメント1 = New System.Windows.Forms.TextBox()
        Me.TextBox機器分類 = New System.Windows.Forms.TextBox()
        Me.TextBox製品名 = New System.Windows.Forms.TextBox()
        Me.TextBox受付番号 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.出力ToolStripMenuItem, Me.チェックToolStripMenuItem, Me.表示ToolStripMenuItem, Me.取り消しToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1370, 24)
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
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem})
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
        'チェックToolStripMenuItem
        '
        Me.チェックToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.全ONToolStripMenuItem, Me.全OFFToolStripMenuItem, Me.反転ToolStripMenuItem})
        Me.チェックToolStripMenuItem.Name = "チェックToolStripMenuItem"
        Me.チェックToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.チェックToolStripMenuItem.Text = "チェック"
        '
        '全ONToolStripMenuItem
        '
        Me.全ONToolStripMenuItem.Name = "全ONToolStripMenuItem"
        Me.全ONToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.全ONToolStripMenuItem.Text = "全ON"
        '
        '全OFFToolStripMenuItem
        '
        Me.全OFFToolStripMenuItem.Name = "全OFFToolStripMenuItem"
        Me.全OFFToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.全OFFToolStripMenuItem.Text = "全OFF"
        '
        '反転ToolStripMenuItem
        '
        Me.反転ToolStripMenuItem.Name = "反転ToolStripMenuItem"
        Me.反転ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.反転ToolStripMenuItem.Text = "反転"
        '
        '表示ToolStripMenuItem
        '
        Me.表示ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox条件})
        Me.表示ToolStripMenuItem.Name = "表示ToolStripMenuItem"
        Me.表示ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.表示ToolStripMenuItem.Text = "表示"
        '
        'ToolStripComboBox条件
        '
        Me.ToolStripComboBox条件.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox条件.Name = "ToolStripComboBox条件"
        Me.ToolStripComboBox条件.Size = New System.Drawing.Size(121, 23)
        '
        '取り消しToolStripMenuItem
        '
        Me.取り消しToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.本日分取り消しToolStripMenuItem})
        Me.取り消しToolStripMenuItem.Name = "取り消しToolStripMenuItem"
        Me.取り消しToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.取り消しToolStripMenuItem.Text = "取り消し"
        '
        '本日分取り消しToolStripMenuItem
        '
        Me.本日分取り消しToolStripMenuItem.Name = "本日分取り消しToolStripMenuItem"
        Me.本日分取り消しToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.本日分取り消しToolStripMenuItem.Text = "本日分取り消し"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel件, Me.ToolStripProgressBar1, Me.ToolStripStatusLabel条件, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel点検項目名})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 650)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1370, 26)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(200, 21)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel件
        '
        Me.ToolStripStatusLabel件.Name = "ToolStripStatusLabel件"
        Me.ToolStripStatusLabel件.Size = New System.Drawing.Size(0, 21)
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 20)
        '
        'ToolStripStatusLabel条件
        '
        Me.ToolStripStatusLabel条件.Name = "ToolStripStatusLabel条件"
        Me.ToolStripStatusLabel条件.Size = New System.Drawing.Size(124, 21)
        Me.ToolStripStatusLabel条件.Text = "本日作業分含まない ->"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 21)
        Me.ToolStripStatusLabel2.Text = " "
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(0, 21)
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(0, 21)
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(119, 21)
        Me.ToolStripStatusLabel5.Text = "ToolStripStatusLabel5"
        '
        'ToolStripStatusLabel点検項目名
        '
        Me.ToolStripStatusLabel点検項目名.AutoSize = False
        Me.ToolStripStatusLabel点検項目名.Name = "ToolStripStatusLabel点検項目名"
        Me.ToolStripStatusLabel点検項目名.Size = New System.Drawing.Size(500, 21)
        Me.ToolStripStatusLabel点検項目名.Text = "ToolStripStatusLabel7"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox過去を含む)
        Me.GroupBox1.Controls.Add(Me.ComboBox注意事項コメント)
        Me.GroupBox1.Controls.Add(Me.CheckBox本日作業分を含む)
        Me.GroupBox1.Controls.Add(Me.Button更新1)
        Me.GroupBox1.Controls.Add(Me.Button検索)
        Me.GroupBox1.Controls.Add(Me.ButtonCLEAR)
        Me.GroupBox1.Controls.Add(Me.ComboBox含む)
        Me.GroupBox1.Controls.Add(Me.ListBox点検製品区分詳細名)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ListBox点検結果)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ListBox点検項目名)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ListBox機器分類名)
        Me.GroupBox1.Controls.Add(Me.Labelから)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker期間2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker期間1)
        Me.GroupBox1.Controls.Add(Me.ComboBox期間)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(907, 135)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "未チェック作業"
        '
        'CheckBox過去を含む
        '
        Me.CheckBox過去を含む.AutoSize = True
        Me.CheckBox過去を含む.Location = New System.Drawing.Point(649, 47)
        Me.CheckBox過去を含む.Name = "CheckBox過去を含む"
        Me.CheckBox過去を含む.Size = New System.Drawing.Size(122, 16)
        Me.CheckBox過去を含む.TabIndex = 30
        Me.CheckBox過去を含む.Text = "過去未チェックを含む"
        Me.CheckBox過去を含む.UseVisualStyleBackColor = True
        '
        'ComboBox注意事項コメント
        '
        Me.ComboBox注意事項コメント.FormattingEnabled = True
        Me.ComboBox注意事項コメント.Location = New System.Drawing.Point(420, 100)
        Me.ComboBox注意事項コメント.Name = "ComboBox注意事項コメント"
        Me.ComboBox注意事項コメント.Size = New System.Drawing.Size(209, 20)
        Me.ComboBox注意事項コメント.TabIndex = 29
        '
        'CheckBox本日作業分を含む
        '
        Me.CheckBox本日作業分を含む.AutoSize = True
        Me.CheckBox本日作業分を含む.Location = New System.Drawing.Point(649, 21)
        Me.CheckBox本日作業分を含む.Name = "CheckBox本日作業分を含む"
        Me.CheckBox本日作業分を含む.Size = New System.Drawing.Size(115, 16)
        Me.CheckBox本日作業分を含む.TabIndex = 27
        Me.CheckBox本日作業分を含む.Text = "本日作業分を含む"
        Me.CheckBox本日作業分を含む.UseVisualStyleBackColor = True
        '
        'Button更新1
        '
        Me.Button更新1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button更新1.Location = New System.Drawing.Point(770, 79)
        Me.Button更新1.Name = "Button更新1"
        Me.Button更新1.Size = New System.Drawing.Size(131, 35)
        Me.Button更新1.TabIndex = 11
        Me.Button更新1.Text = "更新"
        Me.Button更新1.UseVisualStyleBackColor = False
        '
        'Button検索
        '
        Me.Button検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索.Location = New System.Drawing.Point(770, 12)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(131, 65)
        Me.Button検索.TabIndex = 9
        Me.Button検索.Text = "検索"
        Me.Button検索.UseVisualStyleBackColor = False
        '
        'ButtonCLEAR
        '
        Me.ButtonCLEAR.Font = New System.Drawing.Font("MS UI Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ButtonCLEAR.Location = New System.Drawing.Point(554, 15)
        Me.ButtonCLEAR.Name = "ButtonCLEAR"
        Me.ButtonCLEAR.Size = New System.Drawing.Size(75, 15)
        Me.ButtonCLEAR.TabIndex = 26
        Me.ButtonCLEAR.Text = "CLEAR"
        Me.ButtonCLEAR.UseVisualStyleBackColor = True
        '
        'ComboBox含む
        '
        Me.ComboBox含む.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox含む.FormattingEnabled = True
        Me.ComboBox含む.Items.AddRange(New Object() {" "})
        Me.ComboBox含む.Location = New System.Drawing.Point(525, 79)
        Me.ComboBox含む.Name = "ComboBox含む"
        Me.ComboBox含む.Size = New System.Drawing.Size(104, 20)
        Me.ComboBox含む.TabIndex = 8
        '
        'ListBox点検製品区分詳細名
        '
        Me.ListBox点検製品区分詳細名.FormattingEnabled = True
        Me.ListBox点検製品区分詳細名.ItemHeight = 12
        Me.ListBox点検製品区分詳細名.Location = New System.Drawing.Point(418, 33)
        Me.ListBox点検製品区分詳細名.Name = "ListBox点検製品区分詳細名"
        Me.ListBox点検製品区分詳細名.Size = New System.Drawing.Size(211, 40)
        Me.ListBox点検製品区分詳細名.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(418, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 12)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "注意事項・コメント"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(418, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 12)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "点検製品区分詳細名"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(270, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "点検結果"
        '
        'ListBox点検結果
        '
        Me.ListBox点検結果.FormattingEnabled = True
        Me.ListBox点検結果.ItemHeight = 12
        Me.ListBox点検結果.Location = New System.Drawing.Point(272, 55)
        Me.ListBox点検結果.Name = "ListBox点検結果"
        Me.ListBox点検結果.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBox点検結果.Size = New System.Drawing.Size(111, 76)
        Me.ListBox点検結果.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(149, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "点検項目名"
        '
        'ListBox点検項目名
        '
        Me.ListBox点検項目名.FormattingEnabled = True
        Me.ListBox点検項目名.ItemHeight = 12
        Me.ListBox点検項目名.Location = New System.Drawing.Point(144, 55)
        Me.ListBox点検項目名.Name = "ListBox点検項目名"
        Me.ListBox点検項目名.Size = New System.Drawing.Size(120, 76)
        Me.ListBox点検項目名.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "機器分類名"
        '
        'ListBox機器分類名
        '
        Me.ListBox機器分類名.FormattingEnabled = True
        Me.ListBox機器分類名.ItemHeight = 12
        Me.ListBox機器分類名.Location = New System.Drawing.Point(12, 55)
        Me.ListBox機器分類名.Name = "ListBox機器分類名"
        Me.ListBox機器分類名.Size = New System.Drawing.Size(120, 76)
        Me.ListBox機器分類名.TabIndex = 3
        '
        'Labelから
        '
        Me.Labelから.AutoSize = True
        Me.Labelから.Location = New System.Drawing.Point(270, 21)
        Me.Labelから.Name = "Labelから"
        Me.Labelから.Size = New System.Drawing.Size(23, 12)
        Me.Labelから.TabIndex = 9
        Me.Labelから.Text = "から"
        '
        'DateTimePicker期間2
        '
        Me.DateTimePicker期間2.Location = New System.Drawing.Point(299, 18)
        Me.DateTimePicker期間2.Name = "DateTimePicker期間2"
        Me.DateTimePicker期間2.Size = New System.Drawing.Size(113, 19)
        Me.DateTimePicker期間2.TabIndex = 2
        '
        'DateTimePicker期間1
        '
        Me.DateTimePicker期間1.Location = New System.Drawing.Point(151, 18)
        Me.DateTimePicker期間1.Name = "DateTimePicker期間1"
        Me.DateTimePicker期間1.Size = New System.Drawing.Size(113, 19)
        Me.DateTimePicker期間1.TabIndex = 1
        '
        'ComboBox期間
        '
        Me.ComboBox期間.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox期間.FormattingEnabled = True
        Me.ComboBox期間.Location = New System.Drawing.Point(14, 17)
        Me.ComboBox期間.Name = "ComboBox期間"
        Me.ComboBox期間.Size = New System.Drawing.Size(131, 20)
        Me.ComboBox期間.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1370, 626)
        Me.SplitContainer2.SplitterDistance = 141
        Me.SplitContainer2.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button本日分結果決定)
        Me.GroupBox2.Controls.Add(Me.Button本日作業分呼出)
        Me.GroupBox2.Location = New System.Drawing.Point(925, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 123)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "本日作業"
        '
        'Button本日分結果決定
        '
        Me.Button本日分結果決定.BackColor = System.Drawing.Color.Fuchsia
        Me.Button本日分結果決定.Location = New System.Drawing.Point(35, 75)
        Me.Button本日分結果決定.Name = "Button本日分結果決定"
        Me.Button本日分結果決定.Size = New System.Drawing.Size(131, 37)
        Me.Button本日分結果決定.TabIndex = 1
        Me.Button本日分結果決定.Text = "本日分結果決定"
        Me.Button本日分結果決定.UseVisualStyleBackColor = False
        '
        'Button本日作業分呼出
        '
        Me.Button本日作業分呼出.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button本日作業分呼出.Location = New System.Drawing.Point(35, 24)
        Me.Button本日作業分呼出.Name = "Button本日作業分呼出"
        Me.Button本日作業分呼出.Size = New System.Drawing.Size(131, 45)
        Me.Button本日作業分呼出.TabIndex = 0
        Me.Button本日作業分呼出.Text = "本日作業分呼出"
        Me.Button本日作業分呼出.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox確認完了日)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DateTimePicker確認完了日)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label確認完了日)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox再訪問指示日)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBoxRow)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBoxMSG)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox点検製品区分詳細名)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button反映)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox再訪問指示内容)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox不備内容)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox注意事項コメント1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox機器分類)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox製品名)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox受付番号)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.SplitContainer1.Panel2.ForeColor = System.Drawing.Color.Black
        Me.SplitContainer1.Size = New System.Drawing.Size(1370, 481)
        Me.SplitContainer1.SplitterDistance = 868
        Me.SplitContainer1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(868, 481)
        Me.DataGridView1.TabIndex = 0
        '
        'TextBox確認完了日
        '
        Me.TextBox確認完了日.Location = New System.Drawing.Point(124, 330)
        Me.TextBox確認完了日.Mask = "0000/00/00"
        Me.TextBox確認完了日.Name = "TextBox確認完了日"
        Me.TextBox確認完了日.Size = New System.Drawing.Size(109, 19)
        Me.TextBox確認完了日.TabIndex = 3
        Me.TextBox確認完了日.ValidatingType = GetType(Date)
        '
        'DateTimePicker確認完了日
        '
        Me.DateTimePicker確認完了日.Location = New System.Drawing.Point(129, 330)
        Me.DateTimePicker確認完了日.Name = "DateTimePicker確認完了日"
        Me.DateTimePicker確認完了日.Size = New System.Drawing.Size(147, 19)
        Me.DateTimePicker確認完了日.TabIndex = 29
        '
        'Label確認完了日
        '
        Me.Label確認完了日.AutoSize = True
        Me.Label確認完了日.Location = New System.Drawing.Point(32, 333)
        Me.Label確認完了日.Name = "Label確認完了日"
        Me.Label確認完了日.Size = New System.Drawing.Size(65, 12)
        Me.Label確認完了日.TabIndex = 28
        Me.Label確認完了日.Text = "確認完了日"
        '
        'TextBox再訪問指示日
        '
        Me.TextBox再訪問指示日.Location = New System.Drawing.Point(124, 305)
        Me.TextBox再訪問指示日.Mask = "0000/00/00"
        Me.TextBox再訪問指示日.Name = "TextBox再訪問指示日"
        Me.TextBox再訪問指示日.Size = New System.Drawing.Size(109, 19)
        Me.TextBox再訪問指示日.TabIndex = 2
        Me.TextBox再訪問指示日.ValidatingType = GetType(Date)
        '
        'TextBoxRow
        '
        Me.TextBoxRow.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxRow.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxRow.ForeColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBoxRow.Location = New System.Drawing.Point(198, 10)
        Me.TextBoxRow.Name = "TextBoxRow"
        Me.TextBoxRow.ReadOnly = True
        Me.TextBoxRow.Size = New System.Drawing.Size(75, 12)
        Me.TextBoxRow.TabIndex = 25
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(32, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 12)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "点検製品区分詳細名"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(32, 305)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 12)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "再訪問指示日"
        '
        'TextBoxMSG
        '
        Me.TextBoxMSG.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBoxMSG.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxMSG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBoxMSG.Location = New System.Drawing.Point(16, 365)
        Me.TextBoxMSG.Multiline = True
        Me.TextBoxMSG.Name = "TextBoxMSG"
        Me.TextBoxMSG.Size = New System.Drawing.Size(419, 186)
        Me.TextBoxMSG.TabIndex = 20
        Me.TextBoxMSG.Text = resources.GetString("TextBoxMSG.Text")
        '
        'TextBox点検製品区分詳細名
        '
        Me.TextBox点検製品区分詳細名.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox点検製品区分詳細名.Location = New System.Drawing.Point(151, 87)
        Me.TextBox点検製品区分詳細名.Name = "TextBox点検製品区分詳細名"
        Me.TextBox点検製品区分詳細名.ReadOnly = True
        Me.TextBox点検製品区分詳細名.Size = New System.Drawing.Size(255, 19)
        Me.TextBox点検製品区分詳細名.TabIndex = 16
        '
        'Button反映
        '
        Me.Button反映.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button反映.Location = New System.Drawing.Point(279, 5)
        Me.Button反映.Name = "Button反映"
        Me.Button反映.Size = New System.Drawing.Size(75, 23)
        Me.Button反映.TabIndex = 4
        Me.Button反映.Text = "反映"
        Me.Button反映.UseVisualStyleBackColor = False
        '
        'TextBox再訪問指示内容
        '
        Me.TextBox再訪問指示内容.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox再訪問指示内容.Location = New System.Drawing.Point(124, 249)
        Me.TextBox再訪問指示内容.Multiline = True
        Me.TextBox再訪問指示内容.Name = "TextBox再訪問指示内容"
        Me.TextBox再訪問指示内容.Size = New System.Drawing.Size(279, 47)
        Me.TextBox再訪問指示内容.TabIndex = 1
        '
        'TextBox不備内容
        '
        Me.TextBox不備内容.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox不備内容.Location = New System.Drawing.Point(124, 189)
        Me.TextBox不備内容.Multiline = True
        Me.TextBox不備内容.Name = "TextBox不備内容"
        Me.TextBox不備内容.Size = New System.Drawing.Size(282, 54)
        Me.TextBox不備内容.TabIndex = 0
        '
        'TextBox注意事項コメント1
        '
        Me.TextBox注意事項コメント1.Location = New System.Drawing.Point(124, 112)
        Me.TextBox注意事項コメント1.Multiline = True
        Me.TextBox注意事項コメント1.Name = "TextBox注意事項コメント1"
        Me.TextBox注意事項コメント1.ReadOnly = True
        Me.TextBox注意事項コメント1.Size = New System.Drawing.Size(282, 71)
        Me.TextBox注意事項コメント1.TabIndex = 9
        '
        'TextBox機器分類
        '
        Me.TextBox機器分類.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox機器分類.Location = New System.Drawing.Point(317, 37)
        Me.TextBox機器分類.Name = "TextBox機器分類"
        Me.TextBox機器分類.ReadOnly = True
        Me.TextBox機器分類.Size = New System.Drawing.Size(118, 19)
        Me.TextBox機器分類.TabIndex = 8
        '
        'TextBox製品名
        '
        Me.TextBox製品名.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox製品名.Location = New System.Drawing.Point(91, 62)
        Me.TextBox製品名.Name = "TextBox製品名"
        Me.TextBox製品名.ReadOnly = True
        Me.TextBox製品名.Size = New System.Drawing.Size(248, 19)
        Me.TextBox製品名.TabIndex = 7
        '
        'TextBox受付番号
        '
        Me.TextBox受付番号.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox受付番号.Location = New System.Drawing.Point(91, 34)
        Me.TextBox受付番号.Name = "TextBox受付番号"
        Me.TextBox受付番号.ReadOnly = True
        Me.TextBox受付番号.Size = New System.Drawing.Size(143, 19)
        Me.TextBox受付番号.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(32, 249)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 12)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "再訪問指示内容"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(32, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 12)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "不備内容"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 12)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "注意事項コメント"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(258, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "機器分類"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "製品名"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "受付番号"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(127, 305)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(147, 19)
        Me.DateTimePicker1.TabIndex = 26
        '
        'FormTenkenKekka
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 676)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormTenkenKekka"
        Me.Text = "チェック画面"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel件 As ToolStripStatusLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Labelから As Label
    Friend WithEvents DateTimePicker期間2 As DateTimePicker
    Friend WithEvents DateTimePicker期間1 As DateTimePicker
    Friend WithEvents ComboBox期間 As ComboBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox再訪問指示内容 As TextBox
    Friend WithEvents TextBox不備内容 As TextBox
    Friend WithEvents TextBox注意事項コメント1 As TextBox
    Friend WithEvents TextBox機器分類 As TextBox
    Friend WithEvents TextBox製品名 As TextBox
    Friend WithEvents TextBox受付番号 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBoxMSG As TextBox
    Friend WithEvents TextBox点検製品区分詳細名 As TextBox
    Friend WithEvents Button反映 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents チェックToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button本日分結果決定 As Button
    Friend WithEvents Button本日作業分呼出 As Button
    Friend WithEvents Button検索 As Button
    Friend WithEvents ButtonCLEAR As Button
    Friend WithEvents ComboBox含む As ComboBox
    Friend WithEvents ListBox点検製品区分詳細名 As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ListBox点検結果 As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ListBox点検項目名 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox機器分類名 As ListBox
    Friend WithEvents Button更新1 As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents 全ONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 全OFFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 反転ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBoxRow As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox再訪問指示日 As MaskedTextBox
    Friend WithEvents TextBox確認完了日 As MaskedTextBox
    Friend WithEvents DateTimePicker確認完了日 As DateTimePicker
    Friend WithEvents Label確認完了日 As Label
    Friend WithEvents ToolStripStatusLabel点検項目名 As ToolStripStatusLabel
    Friend WithEvents CheckBox本日作業分を含む As CheckBox
    Friend WithEvents ToolStripStatusLabel条件 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents 表示ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox条件 As ToolStripComboBox
    Friend WithEvents ComboBox注意事項コメント As ComboBox
    Friend WithEvents 取り消しToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 本日分取り消しToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBox過去を含む As CheckBox
End Class
