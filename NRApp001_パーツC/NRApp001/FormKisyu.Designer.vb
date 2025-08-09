<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKisyu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKisyu))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.入力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.CSVToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.名称更新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button検索機種 = New System.Windows.Forms.Button()
        Me.Button追加 = New System.Windows.Forms.Button()
        Me.Button品削除 = New System.Windows.Forms.Button()
        Me.Button機種検索 = New System.Windows.Forms.Button()
        Me.ComboBoxJy3 = New System.Windows.Forms.ComboBox()
        Me.Button検索３ = New System.Windows.Forms.Button()
        Me.TextBox機種コード = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button製品検索 = New System.Windows.Forms.Button()
        Me.TextBox適合機種廃止日 = New System.Windows.Forms.MaskedTextBox()
        Me.TextBox適合機種廃止日1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxjy4 = New System.Windows.Forms.ComboBox()
        Me.Button検索４ = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox適合機種 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxjy2 = New System.Windows.Forms.ComboBox()
        Me.Button検索２ = New System.Windows.Forms.Button()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.Button削除 = New System.Windows.Forms.Button()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.Button検索１ = New System.Windows.Forms.Button()
        Me.TextBox品コード = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox漢字名称 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox更新日 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button消す2 = New System.Windows.Forms.Button()
        Me.Button消す1 = New System.Windows.Forms.Button()
        Me.TextBox品コード2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox品コード1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.出力ToolStripMenuItem, Me.入力ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(976, 24)
        Me.MenuStrip1.TabIndex = 1
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
        Me.入力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1, Me.CSVToolStripMenuItem1, Me.名称更新ToolStripMenuItem})
        Me.入力ToolStripMenuItem.Name = "入力ToolStripMenuItem"
        Me.入力ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.入力ToolStripMenuItem.Text = "入力"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"削除して追加", "追加する"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 23)
        '
        'CSVToolStripMenuItem1
        '
        Me.CSVToolStripMenuItem1.Name = "CSVToolStripMenuItem1"
        Me.CSVToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.CSVToolStripMenuItem1.Text = "CSV"
        '
        '名称更新ToolStripMenuItem
        '
        Me.名称更新ToolStripMenuItem.Name = "名称更新ToolStripMenuItem"
        Me.名称更新ToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.名称更新ToolStripMenuItem.Text = "名称更新"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索機種)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button追加)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button品削除)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button機種検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索３)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox機種コード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button製品検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox適合機種廃止日)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox適合機種廃止日1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxjy4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索４)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox適合機種)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxjy2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索２)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button削除)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button更新)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索１)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox品コード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox漢字名称)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(976, 383)
        Me.SplitContainer1.SplitterDistance = 128
        Me.SplitContainer1.TabIndex = 2
        '
        'Button検索機種
        '
        Me.Button検索機種.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索機種.Location = New System.Drawing.Point(423, 13)
        Me.Button検索機種.Name = "Button検索機種"
        Me.Button検索機種.Size = New System.Drawing.Size(80, 23)
        Me.Button検索機種.TabIndex = 56
        Me.Button検索機種.Text = "検索"
        Me.Button検索機種.UseVisualStyleBackColor = False
        '
        'Button追加
        '
        Me.Button追加.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button追加.Location = New System.Drawing.Point(216, 15)
        Me.Button追加.Name = "Button追加"
        Me.Button追加.Size = New System.Drawing.Size(35, 23)
        Me.Button追加.TabIndex = 53
        Me.Button追加.Text = "追加"
        Me.Button追加.UseVisualStyleBackColor = True
        '
        'Button品削除
        '
        Me.Button品削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button品削除.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button品削除.Location = New System.Drawing.Point(668, 7)
        Me.Button品削除.Name = "Button品削除"
        Me.Button品削除.Size = New System.Drawing.Size(117, 23)
        Me.Button品削除.TabIndex = 46
        Me.Button品削除.Text = "品コードで全削除"
        Me.Button品削除.UseVisualStyleBackColor = False
        '
        'Button機種検索
        '
        Me.Button機種検索.Location = New System.Drawing.Point(189, 71)
        Me.Button機種検索.Name = "Button機種検索"
        Me.Button機種検索.Size = New System.Drawing.Size(24, 23)
        Me.Button機種検索.TabIndex = 8
        Me.Button機種検索.UseVisualStyleBackColor = True
        '
        'ComboBoxJy3
        '
        Me.ComboBoxJy3.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy3.FormattingEnabled = True
        Me.ComboBoxJy3.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy3.Location = New System.Drawing.Point(257, 73)
        Me.ComboBoxJy3.Name = "ComboBoxJy3"
        Me.ComboBoxJy3.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy3.TabIndex = 9
        '
        'Button検索３
        '
        Me.Button検索３.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索３.Location = New System.Drawing.Point(334, 72)
        Me.Button検索３.Name = "Button検索３"
        Me.Button検索３.Size = New System.Drawing.Size(80, 23)
        Me.Button検索３.TabIndex = 10
        Me.Button検索３.Text = "検索"
        Me.Button検索３.UseVisualStyleBackColor = False
        '
        'TextBox機種コード
        '
        Me.TextBox機種コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox機種コード.Location = New System.Drawing.Point(68, 72)
        Me.TextBox機種コード.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox機種コード.MaxLength = 10
        Me.TextBox機種コード.Name = "TextBox機種コード"
        Me.TextBox機種コード.Size = New System.Drawing.Size(116, 19)
        Me.TextBox機種コード.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 75)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 12)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "機種コード"
        '
        'Button製品検索
        '
        Me.Button製品検索.Location = New System.Drawing.Point(189, 13)
        Me.Button製品検索.Name = "Button製品検索"
        Me.Button製品検索.Size = New System.Drawing.Size(24, 23)
        Me.Button製品検索.TabIndex = 1
        Me.Button製品検索.UseVisualStyleBackColor = True
        '
        'TextBox適合機種廃止日
        '
        Me.TextBox適合機種廃止日.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox適合機種廃止日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox適合機種廃止日.Location = New System.Drawing.Point(799, 96)
        Me.TextBox適合機種廃止日.Mask = "0000/00/00"
        Me.TextBox適合機種廃止日.Name = "TextBox適合機種廃止日"
        Me.TextBox適合機種廃止日.Size = New System.Drawing.Size(100, 19)
        Me.TextBox適合機種廃止日.TabIndex = 14
        Me.TextBox適合機種廃止日.ValidatingType = GetType(Date)
        '
        'TextBox適合機種廃止日1
        '
        Me.TextBox適合機種廃止日1.Location = New System.Drawing.Point(799, 96)
        Me.TextBox適合機種廃止日1.Name = "TextBox適合機種廃止日1"
        Me.TextBox適合機種廃止日1.Size = New System.Drawing.Size(138, 19)
        Me.TextBox適合機種廃止日1.TabIndex = 39
        '
        'ComboBoxjy4
        '
        Me.ComboBoxjy4.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxjy4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxjy4.FormattingEnabled = True
        Me.ComboBoxjy4.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxjy4.Location = New System.Drawing.Point(257, 97)
        Me.ComboBoxjy4.Name = "ComboBoxjy4"
        Me.ComboBoxjy4.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxjy4.TabIndex = 12
        '
        'Button検索４
        '
        Me.Button検索４.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索４.Location = New System.Drawing.Point(334, 96)
        Me.Button検索４.Name = "Button検索４"
        Me.Button検索４.Size = New System.Drawing.Size(80, 23)
        Me.Button検索４.TabIndex = 13
        Me.Button検索４.Text = "検索"
        Me.Button検索４.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(710, 99)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "適合機種廃止日"
        '
        'TextBox適合機種
        '
        Me.TextBox適合機種.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox適合機種.Location = New System.Drawing.Point(67, 96)
        Me.TextBox適合機種.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox適合機種.MaxLength = 50
        Me.TextBox適合機種.Name = "TextBox適合機種"
        Me.TextBox適合機種.Size = New System.Drawing.Size(181, 19)
        Me.TextBox適合機種.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 99)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "適合機種"
        '
        'ComboBoxjy2
        '
        Me.ComboBoxjy2.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxjy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxjy2.FormattingEnabled = True
        Me.ComboBoxjy2.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxjy2.Location = New System.Drawing.Point(257, 38)
        Me.ComboBoxjy2.Name = "ComboBoxjy2"
        Me.ComboBoxjy2.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxjy2.TabIndex = 5
        '
        'Button検索２
        '
        Me.Button検索２.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索２.Location = New System.Drawing.Point(337, 40)
        Me.Button検索２.Name = "Button検索２"
        Me.Button検索２.Size = New System.Drawing.Size(80, 23)
        Me.Button検索２.TabIndex = 6
        Me.Button検索２.Text = "検索"
        Me.Button検索２.UseVisualStyleBackColor = False
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(257, 14)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy1.TabIndex = 2
        '
        'Button削除
        '
        Me.Button削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button削除.Location = New System.Drawing.Point(880, 7)
        Me.Button削除.Name = "Button削除"
        Me.Button削除.Size = New System.Drawing.Size(75, 23)
        Me.Button削除.TabIndex = 16
        Me.Button削除.Text = "削除"
        Me.Button削除.UseVisualStyleBackColor = False
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(799, 7)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(75, 23)
        Me.Button更新.TabIndex = 15
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'Button検索１
        '
        Me.Button検索１.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索１.Location = New System.Drawing.Point(334, 13)
        Me.Button検索１.Name = "Button検索１"
        Me.Button検索１.Size = New System.Drawing.Size(80, 23)
        Me.Button検索１.TabIndex = 3
        Me.Button検索１.Text = "検索"
        Me.Button検索１.UseVisualStyleBackColor = False
        '
        'TextBox品コード
        '
        Me.TextBox品コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox品コード.Location = New System.Drawing.Point(68, 15)
        Me.TextBox品コード.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox品コード.MaxLength = 10
        Me.TextBox品コード.Name = "TextBox品コード"
        Me.TextBox品コード.Size = New System.Drawing.Size(116, 19)
        Me.TextBox品コード.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 12)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "品コード"
        '
        'TextBox漢字名称
        '
        Me.TextBox漢字名称.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox漢字名称.Location = New System.Drawing.Point(68, 39)
        Me.TextBox漢字名称.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox漢字名称.MaxLength = 50
        Me.TextBox漢字名称.Name = "TextBox漢字名称"
        Me.TextBox漢字名称.Size = New System.Drawing.Size(181, 19)
        Me.TextBox漢字名称.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "漢字名称"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(976, 251)
        Me.DataGridView1.TabIndex = 0
        '
        'TextBox更新日
        '
        Me.TextBox更新日.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox更新日.Location = New System.Drawing.Point(668, 10)
        Me.TextBox更新日.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox更新日.Name = "TextBox更新日"
        Me.TextBox更新日.ReadOnly = True
        Me.TextBox更新日.Size = New System.Drawing.Size(155, 12)
        Me.TextBox更新日.TabIndex = 41
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button消す2)
        Me.GroupBox1.Controls.Add(Me.Button消す1)
        Me.GroupBox1.Controls.Add(Me.TextBox品コード2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TextBox品コード1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(423, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 66)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        '
        'Button消す2
        '
        Me.Button消す2.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button消す2.Location = New System.Drawing.Point(178, 35)
        Me.Button消す2.Name = "Button消す2"
        Me.Button消す2.Size = New System.Drawing.Size(35, 19)
        Me.Button消す2.TabIndex = 61
        Me.Button消す2.Text = "消す"
        Me.Button消す2.UseVisualStyleBackColor = True
        '
        'Button消す1
        '
        Me.Button消す1.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button消す1.Location = New System.Drawing.Point(178, 14)
        Me.Button消す1.Name = "Button消す1"
        Me.Button消す1.Size = New System.Drawing.Size(35, 19)
        Me.Button消す1.TabIndex = 60
        Me.Button消す1.Text = "消す"
        Me.Button消す1.UseVisualStyleBackColor = True
        '
        'TextBox品コード2
        '
        Me.TextBox品コード2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox品コード2.Location = New System.Drawing.Point(57, 37)
        Me.TextBox品コード2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox品コード2.MaxLength = 10
        Me.TextBox品コード2.Name = "TextBox品コード2"
        Me.TextBox品コード2.Size = New System.Drawing.Size(116, 19)
        Me.TextBox品コード2.TabIndex = 58
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 40)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 12)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "品コード"
        '
        'TextBox品コード1
        '
        Me.TextBox品コード1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox品コード1.Location = New System.Drawing.Point(57, 16)
        Me.TextBox品コード1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox品コード1.MaxLength = 10
        Me.TextBox品コード1.Name = "TextBox品コード1"
        Me.TextBox品コード1.Size = New System.Drawing.Size(116, 19)
        Me.TextBox品コード1.TabIndex = 56
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 19)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 12)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "品コード"
        '
        'FormKisyu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 407)
        Me.Controls.Add(Me.TextBox更新日)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormKisyu"
        Me.Text = "部品適合機種項目"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Button製品検索 As Button
    Friend WithEvents TextBox適合機種廃止日 As MaskedTextBox
    Friend WithEvents TextBox適合機種廃止日1 As DateTimePicker
    Friend WithEvents ComboBoxjy4 As ComboBox
    Friend WithEvents Button検索４ As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox適合機種 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxjy2 As ComboBox
    Friend WithEvents Button検索２ As Button
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents Button削除 As Button
    Friend WithEvents Button更新 As Button
    Friend WithEvents Button検索１ As Button
    Friend WithEvents TextBox品コード As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox漢字名称 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox更新日 As TextBox
    Friend WithEvents ComboBoxJy3 As ComboBox
    Friend WithEvents Button検索３ As Button
    Friend WithEvents TextBox機種コード As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button機種検索 As Button
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 入力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 名称更新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents Button品削除 As Button
    Friend WithEvents Button追加 As Button
    Friend WithEvents TextBox品コード3 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button消す3 As Button
    Friend WithEvents Button検索機種 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button消す2 As Button
    Friend WithEvents Button消す1 As Button
    Friend WithEvents TextBox品コード2 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox品コード1 As TextBox
    Friend WithEvents Label6 As Label
End Class
