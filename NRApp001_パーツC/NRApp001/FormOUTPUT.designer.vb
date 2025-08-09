<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOUTPUT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOUTPUT))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button抽出 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonEXCEL = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCSV = New System.Windows.Forms.RadioButton()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxFileName = New System.Windows.Forms.TextBox()
        Me.Button実行 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.RadioButton商品登録 = New System.Windows.Forms.RadioButton()
        Me.DataGridView0 = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Button条件クリア = New System.Windows.Forms.Button()
        Me.ComboBoxJy04 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy03 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy01 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy00 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy4 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy3 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy2 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MaskedTextBox取り込み日1 = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox取り込み日 = New System.Windows.Forms.MaskedTextBox()
        Me.TextBox備考カナ = New System.Windows.Forms.TextBox()
        Me.TextBox得意先コード = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxオーダーNO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox品コード = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton適応機種 = New System.Windows.Forms.RadioButton()
        Me.RadioButton全部 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonLPG = New System.Windows.Forms.RadioButton()
        Me.RadioButton12A13A = New System.Windows.Forms.RadioButton()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataGridView0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(973, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button抽出)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxFileName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button実行)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(973, 571)
        Me.SplitContainer1.SplitterDistance = 68
        Me.SplitContainer1.TabIndex = 7
        '
        'Button抽出
        '
        Me.Button抽出.BackColor = System.Drawing.Color.Lime
        Me.Button抽出.Location = New System.Drawing.Point(788, 10)
        Me.Button抽出.Name = "Button抽出"
        Me.Button抽出.Size = New System.Drawing.Size(90, 27)
        Me.Button抽出.TabIndex = 12
        Me.Button抽出.Text = "抽出"
        Me.Button抽出.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButtonEXCEL)
        Me.GroupBox1.Controls.Add(Me.RadioButtonCSV)
        Me.GroupBox1.Location = New System.Drawing.Point(549, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(131, 37)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "出力"
        '
        'RadioButtonEXCEL
        '
        Me.RadioButtonEXCEL.AutoSize = True
        Me.RadioButtonEXCEL.Checked = True
        Me.RadioButtonEXCEL.Location = New System.Drawing.Point(66, 14)
        Me.RadioButtonEXCEL.Name = "RadioButtonEXCEL"
        Me.RadioButtonEXCEL.Size = New System.Drawing.Size(58, 16)
        Me.RadioButtonEXCEL.TabIndex = 1
        Me.RadioButtonEXCEL.TabStop = True
        Me.RadioButtonEXCEL.Text = "EXCEL"
        Me.RadioButtonEXCEL.UseVisualStyleBackColor = True
        '
        'RadioButtonCSV
        '
        Me.RadioButtonCSV.AutoSize = True
        Me.RadioButtonCSV.Location = New System.Drawing.Point(11, 14)
        Me.RadioButtonCSV.Name = "RadioButtonCSV"
        Me.RadioButtonCSV.Size = New System.Drawing.Size(46, 16)
        Me.RadioButtonCSV.TabIndex = 0
        Me.RadioButtonCSV.Text = "CSV"
        Me.RadioButtonCSV.UseVisualStyleBackColor = True
        '
        'Button検索
        '
        Me.Button検索.Location = New System.Drawing.Point(468, 8)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(75, 23)
        Me.Button検索.TabIndex = 10
        Me.Button検索.Text = "検索"
        Me.Button検索.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "出力先"
        '
        'TextBoxFileName
        '
        Me.TextBoxFileName.Location = New System.Drawing.Point(57, 10)
        Me.TextBoxFileName.Name = "TextBoxFileName"
        Me.TextBoxFileName.Size = New System.Drawing.Size(404, 19)
        Me.TextBoxFileName.TabIndex = 8
        '
        'Button実行
        '
        Me.Button実行.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button実行.Location = New System.Drawing.Point(692, 10)
        Me.Button実行.Name = "Button実行"
        Me.Button実行.Size = New System.Drawing.Size(90, 27)
        Me.Button実行.TabIndex = 7
        Me.Button実行.Text = "出力"
        Me.Button実行.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(973, 499)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.SplitContainer2)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(965, 473)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "商品登録(コンロ)"
        Me.TabPage5.UseVisualStyleBackColor = True
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.RadioButton適応機種)
        Me.SplitContainer2.Panel1.Controls.Add(Me.RadioButton商品登録)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridView0)
        Me.SplitContainer2.Size = New System.Drawing.Size(965, 473)
        Me.SplitContainer2.SplitterDistance = 101
        Me.SplitContainer2.TabIndex = 0
        '
        'RadioButton商品登録
        '
        Me.RadioButton商品登録.AutoSize = True
        Me.RadioButton商品登録.Checked = True
        Me.RadioButton商品登録.Location = New System.Drawing.Point(88, 16)
        Me.RadioButton商品登録.Name = "RadioButton商品登録"
        Me.RadioButton商品登録.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton商品登録.TabIndex = 0
        Me.RadioButton商品登録.TabStop = True
        Me.RadioButton商品登録.Text = "商品登録"
        Me.RadioButton商品登録.UseVisualStyleBackColor = True
        '
        'DataGridView0
        '
        Me.DataGridView0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView0.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView0.Name = "DataGridView0"
        Me.DataGridView0.RowTemplate.Height = 21
        Me.DataGridView0.Size = New System.Drawing.Size(965, 368)
        Me.DataGridView0.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(965, 473)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "ショップ"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer4.Size = New System.Drawing.Size(959, 467)
        Me.SplitContainer4.SplitterDistance = 136
        Me.SplitContainer4.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(959, 327)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.SplitContainer3)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(965, 473)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "売上伝票"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Button条件クリア)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ComboBoxJy04)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ComboBoxJy03)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ComboBoxJy01)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ComboBoxJy00)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ComboBoxJy4)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ComboBoxJy3)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ComboBoxJy1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ComboBoxJy2)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer3.Panel1.Controls.Add(Me.MaskedTextBox取り込み日1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.MaskedTextBox取り込み日)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TextBox備考カナ)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TextBox得意先コード)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TextBoxオーダーNO)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TextBox品コード)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer3.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.DateTimePicker2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.DataGridView4)
        Me.SplitContainer3.Size = New System.Drawing.Size(965, 473)
        Me.SplitContainer3.SplitterDistance = 173
        Me.SplitContainer3.TabIndex = 0
        '
        'Button条件クリア
        '
        Me.Button条件クリア.Location = New System.Drawing.Point(611, 18)
        Me.Button条件クリア.Name = "Button条件クリア"
        Me.Button条件クリア.Size = New System.Drawing.Size(93, 23)
        Me.Button条件クリア.TabIndex = 133
        Me.Button条件クリア.Text = "条件クリア"
        Me.Button条件クリア.UseVisualStyleBackColor = True
        '
        'ComboBoxJy04
        '
        Me.ComboBoxJy04.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy04.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy04.FormattingEnabled = True
        Me.ComboBoxJy04.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy04.Location = New System.Drawing.Point(327, 124)
        Me.ComboBoxJy04.Name = "ComboBoxJy04"
        Me.ComboBoxJy04.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy04.TabIndex = 124
        '
        'ComboBoxJy03
        '
        Me.ComboBoxJy03.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy03.FormattingEnabled = True
        Me.ComboBoxJy03.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy03.Location = New System.Drawing.Point(327, 94)
        Me.ComboBoxJy03.Name = "ComboBoxJy03"
        Me.ComboBoxJy03.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy03.TabIndex = 121
        '
        'ComboBoxJy01
        '
        Me.ComboBoxJy01.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy01.FormattingEnabled = True
        Me.ComboBoxJy01.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy01.Location = New System.Drawing.Point(327, 41)
        Me.ComboBoxJy01.Name = "ComboBoxJy01"
        Me.ComboBoxJy01.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy01.TabIndex = 115
        '
        'ComboBoxJy00
        '
        Me.ComboBoxJy00.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy00.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy00.FormattingEnabled = True
        Me.ComboBoxJy00.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy00.Location = New System.Drawing.Point(327, 15)
        Me.ComboBoxJy00.Name = "ComboBoxJy00"
        Me.ComboBoxJy00.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy00.TabIndex = 112
        '
        'ComboBoxJy4
        '
        Me.ComboBoxJy4.AutoCompleteCustomSource.AddRange(New String() {"かつ", "また"})
        Me.ComboBoxJy4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy4.FormattingEnabled = True
        Me.ComboBoxJy4.Items.AddRange(New Object() {"かつ", "または"})
        Me.ComboBoxJy4.Location = New System.Drawing.Point(37, 122)
        Me.ComboBoxJy4.Name = "ComboBoxJy4"
        Me.ComboBoxJy4.Size = New System.Drawing.Size(81, 20)
        Me.ComboBoxJy4.TabIndex = 122
        '
        'ComboBoxJy3
        '
        Me.ComboBoxJy3.AutoCompleteCustomSource.AddRange(New String() {"かつ", "また"})
        Me.ComboBoxJy3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy3.FormattingEnabled = True
        Me.ComboBoxJy3.Items.AddRange(New Object() {"かつ", "または"})
        Me.ComboBoxJy3.Location = New System.Drawing.Point(36, 95)
        Me.ComboBoxJy3.Name = "ComboBoxJy3"
        Me.ComboBoxJy3.Size = New System.Drawing.Size(81, 20)
        Me.ComboBoxJy3.TabIndex = 119
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.AutoCompleteCustomSource.AddRange(New String() {"かつ", "また"})
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"かつ", "または"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(37, 41)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(81, 20)
        Me.ComboBoxJy1.TabIndex = 113
        '
        'ComboBoxJy2
        '
        Me.ComboBoxJy2.AutoCompleteCustomSource.AddRange(New String() {"かつ", "また"})
        Me.ComboBoxJy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy2.FormattingEnabled = True
        Me.ComboBoxJy2.Items.AddRange(New Object() {"かつ", "または"})
        Me.ComboBoxJy2.Location = New System.Drawing.Point(36, 68)
        Me.ComboBoxJy2.Name = "ComboBoxJy2"
        Me.ComboBoxJy2.Size = New System.Drawing.Size(81, 20)
        Me.ComboBoxJy2.TabIndex = 116
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(354, 72)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 130
        Me.Label7.Text = "～"
        '
        'MaskedTextBox取り込み日1
        '
        Me.MaskedTextBox取り込み日1.Location = New System.Drawing.Point(380, 69)
        Me.MaskedTextBox取り込み日1.Mask = "0000/00/00"
        Me.MaskedTextBox取り込み日1.Name = "MaskedTextBox取り込み日1"
        Me.MaskedTextBox取り込み日1.Size = New System.Drawing.Size(116, 19)
        Me.MaskedTextBox取り込み日1.TabIndex = 118
        Me.MaskedTextBox取り込み日1.ValidatingType = GetType(Date)
        '
        'MaskedTextBox取り込み日
        '
        Me.MaskedTextBox取り込み日.Location = New System.Drawing.Point(196, 68)
        Me.MaskedTextBox取り込み日.Mask = "0000/00/00"
        Me.MaskedTextBox取り込み日.Name = "MaskedTextBox取り込み日"
        Me.MaskedTextBox取り込み日.Size = New System.Drawing.Size(116, 19)
        Me.MaskedTextBox取り込み日.TabIndex = 117
        Me.MaskedTextBox取り込み日.ValidatingType = GetType(Date)
        '
        'TextBox備考カナ
        '
        Me.TextBox備考カナ.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox備考カナ.Location = New System.Drawing.Point(196, 123)
        Me.TextBox備考カナ.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox備考カナ.MaxLength = 10
        Me.TextBox備考カナ.Name = "TextBox備考カナ"
        Me.TextBox備考カナ.Size = New System.Drawing.Size(116, 19)
        Me.TextBox備考カナ.TabIndex = 123
        '
        'TextBox得意先コード
        '
        Me.TextBox得意先コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox得意先コード.Location = New System.Drawing.Point(196, 95)
        Me.TextBox得意先コード.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox得意先コード.MaxLength = 10
        Me.TextBox得意先コード.Name = "TextBox得意先コード"
        Me.TextBox得意先コード.Size = New System.Drawing.Size(116, 19)
        Me.TextBox得意先コード.TabIndex = 120
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(144, 124)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 12)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "備考カナ"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(130, 72)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 12)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "取り込み日"
        '
        'TextBoxオーダーNO
        '
        Me.TextBoxオーダーNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxオーダーNO.Location = New System.Drawing.Point(196, 42)
        Me.TextBoxオーダーNO.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxオーダーNO.MaxLength = 10
        Me.TextBoxオーダーNO.Name = "TextBoxオーダーNO"
        Me.TextBoxオーダーNO.Size = New System.Drawing.Size(116, 19)
        Me.TextBoxオーダーNO.TabIndex = 114
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(122, 98)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 12)
        Me.Label10.TabIndex = 127
        Me.Label10.Text = "得意先コード"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(133, 44)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 12)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "オーダーNo"
        '
        'TextBox品コード
        '
        Me.TextBox品コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox品コード.Location = New System.Drawing.Point(196, 15)
        Me.TextBox品コード.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox品コード.MaxLength = 10
        Me.TextBox品コード.Name = "TextBox品コード"
        Me.TextBox品コード.Size = New System.Drawing.Size(116, 19)
        Me.TextBox品コード.TabIndex = 111
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(146, 18)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 12)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "品コード"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(196, 68)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(147, 19)
        Me.DateTimePicker1.TabIndex = 131
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(382, 69)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(146, 19)
        Me.DateTimePicker2.TabIndex = 132
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView4.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.RowTemplate.Height = 21
        Me.DataGridView4.Size = New System.Drawing.Size(965, 296)
        Me.DataGridView4.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton12A13A)
        Me.GroupBox2.Controls.Add(Me.RadioButtonLPG)
        Me.GroupBox2.Controls.Add(Me.RadioButton全部)
        Me.GroupBox2.Location = New System.Drawing.Point(180, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 50)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'RadioButton適応機種
        '
        Me.RadioButton適応機種.AutoSize = True
        Me.RadioButton適応機種.Location = New System.Drawing.Point(180, 16)
        Me.RadioButton適応機種.Name = "RadioButton適応機種"
        Me.RadioButton適応機種.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton適応機種.TabIndex = 1
        Me.RadioButton適応機種.Text = "適応機種"
        Me.RadioButton適応機種.UseVisualStyleBackColor = True
        '
        'RadioButton全部
        '
        Me.RadioButton全部.AutoSize = True
        Me.RadioButton全部.Checked = True
        Me.RadioButton全部.Location = New System.Drawing.Point(24, 18)
        Me.RadioButton全部.Name = "RadioButton全部"
        Me.RadioButton全部.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton全部.TabIndex = 2
        Me.RadioButton全部.TabStop = True
        Me.RadioButton全部.Text = "全部"
        Me.RadioButton全部.UseVisualStyleBackColor = True
        '
        'RadioButtonLPG
        '
        Me.RadioButtonLPG.AutoSize = True
        Me.RadioButtonLPG.Location = New System.Drawing.Point(87, 18)
        Me.RadioButtonLPG.Name = "RadioButtonLPG"
        Me.RadioButtonLPG.Size = New System.Drawing.Size(44, 16)
        Me.RadioButtonLPG.TabIndex = 3
        Me.RadioButtonLPG.Text = "LPG"
        Me.RadioButtonLPG.UseVisualStyleBackColor = True
        '
        'RadioButton12A13A
        '
        Me.RadioButton12A13A.AutoSize = True
        Me.RadioButton12A13A.Location = New System.Drawing.Point(150, 18)
        Me.RadioButton12A13A.Name = "RadioButton12A13A"
        Me.RadioButton12A13A.Size = New System.Drawing.Size(63, 16)
        Me.RadioButton12A13A.TabIndex = 4
        Me.RadioButton12A13A.Text = "12A13A"
        Me.RadioButton12A13A.UseVisualStyleBackColor = True
        '
        'FormOUTPUT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 595)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormOUTPUT"
        Me.Text = "帳票・出力"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DataGridView0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButtonEXCEL As RadioButton
    Friend WithEvents RadioButtonCSV As RadioButton
    Friend WithEvents Button検索 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxFileName As TextBox
    Friend WithEvents Button実行 As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Button抽出 As Button
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents DataGridView0 As DataGridView
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents ComboBoxJy04 As ComboBox
    Friend WithEvents ComboBoxJy03 As ComboBox
    Friend WithEvents ComboBoxJy01 As ComboBox
    Friend WithEvents ComboBoxJy00 As ComboBox
    Friend WithEvents ComboBoxJy4 As ComboBox
    Friend WithEvents ComboBoxJy3 As ComboBox
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents ComboBoxJy2 As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents MaskedTextBox取り込み日1 As MaskedTextBox
    Friend WithEvents MaskedTextBox取り込み日 As MaskedTextBox
    Friend WithEvents TextBox備考カナ As TextBox
    Friend WithEvents TextBox得意先コード As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBoxオーダーNO As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox品コード As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents RadioButton商品登録 As RadioButton
    Friend WithEvents Button条件クリア As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioButton12A13A As RadioButton
    Friend WithEvents RadioButtonLPG As RadioButton
    Friend WithEvents RadioButton全部 As RadioButton
    Friend WithEvents RadioButton適応機種 As RadioButton
End Class
