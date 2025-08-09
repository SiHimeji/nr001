<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCheck))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.実行ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCEL未回収ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.チェックToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.条件初期ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.チェックToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ALLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全OFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.反転ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.更新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel件数 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CheckBoxCIM = New System.Windows.Forms.CheckBox()
        Me.CheckBoxZero = New System.Windows.Forms.CheckBox()
        Me.CheckBox物件重複を外す = New System.Windows.Forms.CheckBox()
        Me.CheckBox回収対象外 = New System.Windows.Forms.CheckBox()
        Me.CheckBox完了を除く = New System.Windows.Forms.CheckBox()
        Me.Button正常を削除 = New System.Windows.Forms.Button()
        Me.CheckBox建物 = New System.Windows.Forms.CheckBox()
        Me.GroupBox請求先 = New System.Windows.Forms.GroupBox()
        Me.Button請求先電話CLEAR = New System.Windows.Forms.Button()
        Me.Button請求先名CLEAR = New System.Windows.Forms.Button()
        Me.Button請求先会社名CLEAR = New System.Windows.Forms.Button()
        Me.ComboBoxJy3 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy2 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.TextBox請求先電話 = New System.Windows.Forms.TextBox()
        Me.TextBox請求先名 = New System.Windows.Forms.TextBox()
        Me.TextBox請求先会社名 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label条件 = New System.Windows.Forms.Label()
        Me.CheckBoxモバイル修理完了 = New System.Windows.Forms.CheckBox()
        Me.CheckBox修理完了 = New System.Windows.Forms.CheckBox()
        Me.CheckBox再訪問 = New System.Windows.Forms.CheckBox()
        Me.CheckBox訪問前キャンセル = New System.Windows.Forms.CheckBox()
        Me.CheckBoxナンセンスコール = New System.Windows.Forms.CheckBox()
        Me.CheckBox受付キャンセル = New System.Windows.Forms.CheckBox()
        Me.CheckBox受付保留 = New System.Windows.Forms.CheckBox()
        Me.CheckBox受付完了 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxNR後日請求 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSS後日請求 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSS現金徴収 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox訪問ｷｬﾝｾﾙ = New System.Windows.Forms.CheckBox()
        Me.CheckBox受付ｷｬﾝｾﾙ = New System.Windows.Forms.CheckBox()
        Me.CheckBox訪問前ｷｬﾝｾﾙ = New System.Windows.Forms.CheckBox()
        Me.CheckBox回収完了 = New System.Windows.Forms.CheckBox()
        Me.CheckBox請求書発行済 = New System.Windows.Forms.CheckBox()
        Me.CheckBox点検完了 = New System.Windows.Forms.CheckBox()
        Me.CheckBox点検受付 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox期間 = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker期間2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker期間1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox項目 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox請求先.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.実行ToolStripMenuItem, Me.出力ToolStripMenuItem, Me.チェックToolStripMenuItem, Me.条件初期ToolStripMenuItem, Me.チェックToolStripMenuItem1, Me.更新ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1145, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '実行ToolStripMenuItem
        '
        Me.実行ToolStripMenuItem.Name = "実行ToolStripMenuItem"
        Me.実行ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.実行ToolStripMenuItem.Text = "検索"
        '
        '出力ToolStripMenuItem
        '
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem, Me.CSVToolStripMenuItem, Me.EXCEL未回収ToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CSVToolStripMenuItem.Text = "CSV"
        '
        'EXCEL未回収ToolStripMenuItem
        '
        Me.EXCEL未回収ToolStripMenuItem.Name = "EXCEL未回収ToolStripMenuItem"
        Me.EXCEL未回収ToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.EXCEL未回収ToolStripMenuItem.Text = "EXCEL(未回収)"
        '
        'チェックToolStripMenuItem
        '
        Me.チェックToolStripMenuItem.Name = "チェックToolStripMenuItem"
        Me.チェックToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.チェックToolStripMenuItem.Text = "再 Check"
        '
        '条件初期ToolStripMenuItem
        '
        Me.条件初期ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.条件初期ToolStripMenuItem.Name = "条件初期ToolStripMenuItem"
        Me.条件初期ToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.条件初期ToolStripMenuItem.Text = "条件(初期)"
        '
        'チェックToolStripMenuItem1
        '
        Me.チェックToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ALLToolStripMenuItem, Me.全OFFToolStripMenuItem, Me.反転ToolStripMenuItem})
        Me.チェックToolStripMenuItem1.Name = "チェックToolStripMenuItem1"
        Me.チェックToolStripMenuItem1.Size = New System.Drawing.Size(52, 20)
        Me.チェックToolStripMenuItem1.Text = "チェック"
        '
        'ALLToolStripMenuItem
        '
        Me.ALLToolStripMenuItem.Name = "ALLToolStripMenuItem"
        Me.ALLToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ALLToolStripMenuItem.Text = "全ON"
        '
        '全OFFToolStripMenuItem
        '
        Me.全OFFToolStripMenuItem.Name = "全OFFToolStripMenuItem"
        Me.全OFFToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.全OFFToolStripMenuItem.Text = "全OFF"
        '
        '反転ToolStripMenuItem
        '
        Me.反転ToolStripMenuItem.Name = "反転ToolStripMenuItem"
        Me.反転ToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.反転ToolStripMenuItem.Text = "反転"
        '
        '更新ToolStripMenuItem
        '
        Me.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem"
        Me.更新ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.更新ToolStripMenuItem.Text = "更新"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel件数, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 572)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1145, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel件数
        '
        Me.ToolStripStatusLabel件数.Name = "ToolStripStatusLabel件数"
        Me.ToolStripStatusLabel件数.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel件数.Text = "ToolStripStatusLabel2"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(200, 16)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxCIM)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxZero)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox物件重複を外す)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox回収対象外)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox完了を除く)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button正常を削除)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox建物)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox請求先)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox期間)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker期間2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker期間1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox項目)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1145, 548)
        Me.SplitContainer1.SplitterDistance = 167
        Me.SplitContainer1.TabIndex = 2
        '
        'CheckBoxCIM
        '
        Me.CheckBoxCIM.AutoSize = True
        Me.CheckBoxCIM.Location = New System.Drawing.Point(15, 146)
        Me.CheckBoxCIM.Name = "CheckBoxCIM"
        Me.CheckBoxCIM.Size = New System.Drawing.Size(114, 16)
        Me.CheckBoxCIM.TabIndex = 18
        Me.CheckBoxCIM.Text = "旧システムを含める"
        Me.CheckBoxCIM.UseVisualStyleBackColor = True
        '
        'CheckBoxZero
        '
        Me.CheckBoxZero.AutoSize = True
        Me.CheckBoxZero.Checked = True
        Me.CheckBoxZero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxZero.Location = New System.Drawing.Point(698, 8)
        Me.CheckBoxZero.Name = "CheckBoxZero"
        Me.CheckBoxZero.Size = New System.Drawing.Size(108, 16)
        Me.CheckBoxZero.TabIndex = 17
        Me.CheckBoxZero.Text = "値引き０円を含む"
        Me.CheckBoxZero.UseVisualStyleBackColor = True
        '
        'CheckBox物件重複を外す
        '
        Me.CheckBox物件重複を外す.AutoSize = True
        Me.CheckBox物件重複を外す.Checked = True
        Me.CheckBox物件重複を外す.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox物件重複を外す.Location = New System.Drawing.Point(618, 138)
        Me.CheckBox物件重複を外す.Name = "CheckBox物件重複を外す"
        Me.CheckBox物件重複を外す.Size = New System.Drawing.Size(103, 16)
        Me.CheckBox物件重複を外す.TabIndex = 16
        Me.CheckBox物件重複を外す.Text = "物件重複を外す"
        Me.CheckBox物件重複を外す.UseVisualStyleBackColor = True
        '
        'CheckBox回収対象外
        '
        Me.CheckBox回収対象外.AutoSize = True
        Me.CheckBox回収対象外.Checked = True
        Me.CheckBox回収対象外.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox回収対象外.Location = New System.Drawing.Point(721, 138)
        Me.CheckBox回収対象外.Name = "CheckBox回収対象外"
        Me.CheckBox回収対象外.Size = New System.Drawing.Size(134, 16)
        Me.CheckBox回収対象外.TabIndex = 15
        Me.CheckBox回収対象外.Text = "回収対象外を含まない"
        Me.CheckBox回収対象外.UseVisualStyleBackColor = True
        '
        'CheckBox完了を除く
        '
        Me.CheckBox完了を除く.AutoSize = True
        Me.CheckBox完了を除く.Location = New System.Drawing.Point(606, 8)
        Me.CheckBox完了を除く.Name = "CheckBox完了を除く"
        Me.CheckBox完了を除く.Size = New System.Drawing.Size(75, 16)
        Me.CheckBox完了を除く.TabIndex = 14
        Me.CheckBox完了を除く.Text = "完了を除く"
        Me.CheckBox完了を除く.UseVisualStyleBackColor = True
        '
        'Button正常を削除
        '
        Me.Button正常を削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button正常を削除.Location = New System.Drawing.Point(988, 142)
        Me.Button正常を削除.Name = "Button正常を削除"
        Me.Button正常を削除.Size = New System.Drawing.Size(134, 23)
        Me.Button正常を削除.TabIndex = 13
        Me.Button正常を削除.Text = "正常を削除"
        Me.Button正常を削除.UseVisualStyleBackColor = False
        '
        'CheckBox建物
        '
        Me.CheckBox建物.AutoSize = True
        Me.CheckBox建物.Checked = True
        Me.CheckBox建物.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox建物.Location = New System.Drawing.Point(521, 138)
        Me.CheckBox建物.Name = "CheckBox建物"
        Me.CheckBox建物.Size = New System.Drawing.Size(91, 16)
        Me.CheckBox建物.TabIndex = 12
        Me.CheckBox建物.Text = "建物名を含む"
        Me.CheckBox建物.UseVisualStyleBackColor = True
        '
        'GroupBox請求先
        '
        Me.GroupBox請求先.Controls.Add(Me.Button請求先電話CLEAR)
        Me.GroupBox請求先.Controls.Add(Me.Button請求先名CLEAR)
        Me.GroupBox請求先.Controls.Add(Me.Button請求先会社名CLEAR)
        Me.GroupBox請求先.Controls.Add(Me.ComboBoxJy3)
        Me.GroupBox請求先.Controls.Add(Me.ComboBoxJy2)
        Me.GroupBox請求先.Controls.Add(Me.ComboBoxJy1)
        Me.GroupBox請求先.Controls.Add(Me.TextBox請求先電話)
        Me.GroupBox請求先.Controls.Add(Me.TextBox請求先名)
        Me.GroupBox請求先.Controls.Add(Me.TextBox請求先会社名)
        Me.GroupBox請求先.Controls.Add(Me.Label6)
        Me.GroupBox請求先.Controls.Add(Me.Label5)
        Me.GroupBox請求先.Controls.Add(Me.Label4)
        Me.GroupBox請求先.Location = New System.Drawing.Point(827, 8)
        Me.GroupBox請求先.Name = "GroupBox請求先"
        Me.GroupBox請求先.Size = New System.Drawing.Size(295, 135)
        Me.GroupBox請求先.TabIndex = 11
        Me.GroupBox請求先.TabStop = False
        Me.GroupBox請求先.Text = "請求先"
        '
        'Button請求先電話CLEAR
        '
        Me.Button請求先電話CLEAR.Location = New System.Drawing.Point(143, 106)
        Me.Button請求先電話CLEAR.Name = "Button請求先電話CLEAR"
        Me.Button請求先電話CLEAR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求先電話CLEAR.TabIndex = 12
        Me.Button請求先電話CLEAR.Text = "X"
        Me.Button請求先電話CLEAR.UseVisualStyleBackColor = True
        '
        'Button請求先名CLEAR
        '
        Me.Button請求先名CLEAR.Location = New System.Drawing.Point(177, 68)
        Me.Button請求先名CLEAR.Name = "Button請求先名CLEAR"
        Me.Button請求先名CLEAR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求先名CLEAR.TabIndex = 11
        Me.Button請求先名CLEAR.Text = "X"
        Me.Button請求先名CLEAR.UseVisualStyleBackColor = True
        '
        'Button請求先会社名CLEAR
        '
        Me.Button請求先会社名CLEAR.Location = New System.Drawing.Point(177, 31)
        Me.Button請求先会社名CLEAR.Name = "Button請求先会社名CLEAR"
        Me.Button請求先会社名CLEAR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求先会社名CLEAR.TabIndex = 10
        Me.Button請求先会社名CLEAR.Text = "X"
        Me.Button請求先会社名CLEAR.UseVisualStyleBackColor = True
        '
        'ComboBoxJy3
        '
        Me.ComboBoxJy3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy3.FormattingEnabled = True
        Me.ComboBoxJy3.Items.AddRange(New Object() {"一致", "一部"})
        Me.ComboBoxJy3.Location = New System.Drawing.Point(207, 105)
        Me.ComboBoxJy3.Name = "ComboBoxJy3"
        Me.ComboBoxJy3.Size = New System.Drawing.Size(85, 20)
        Me.ComboBoxJy3.TabIndex = 8
        '
        'ComboBoxJy2
        '
        Me.ComboBoxJy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy2.FormattingEnabled = True
        Me.ComboBoxJy2.Items.AddRange(New Object() {"一致", "一部"})
        Me.ComboBoxJy2.Location = New System.Drawing.Point(207, 67)
        Me.ComboBoxJy2.Name = "ComboBoxJy2"
        Me.ComboBoxJy2.Size = New System.Drawing.Size(85, 20)
        Me.ComboBoxJy2.TabIndex = 7
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"一致", "一部"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(207, 30)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(85, 20)
        Me.ComboBoxJy1.TabIndex = 6
        '
        'TextBox請求先電話
        '
        Me.TextBox請求先電話.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox請求先電話.Location = New System.Drawing.Point(7, 106)
        Me.TextBox請求先電話.MaxLength = 12
        Me.TextBox請求先電話.Name = "TextBox請求先電話"
        Me.TextBox請求先電話.Size = New System.Drawing.Size(137, 19)
        Me.TextBox請求先電話.TabIndex = 5
        '
        'TextBox請求先名
        '
        Me.TextBox請求先名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求先名.Location = New System.Drawing.Point(7, 68)
        Me.TextBox請求先名.MaxLength = 32
        Me.TextBox請求先名.Name = "TextBox請求先名"
        Me.TextBox請求先名.Size = New System.Drawing.Size(172, 19)
        Me.TextBox請求先名.TabIndex = 4
        '
        'TextBox請求先会社名
        '
        Me.TextBox請求先会社名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求先会社名.Location = New System.Drawing.Point(7, 31)
        Me.TextBox請求先会社名.MaxLength = 32
        Me.TextBox請求先会社名.Name = "TextBox請求先会社名"
        Me.TextBox請求先会社名.Size = New System.Drawing.Size(172, 19)
        Me.TextBox請求先会社名.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "請求先電話"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "請求先名"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "請求先会社名"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label条件)
        Me.GroupBox3.Controls.Add(Me.CheckBoxモバイル修理完了)
        Me.GroupBox3.Controls.Add(Me.CheckBox修理完了)
        Me.GroupBox3.Controls.Add(Me.CheckBox再訪問)
        Me.GroupBox3.Controls.Add(Me.CheckBox訪問前キャンセル)
        Me.GroupBox3.Controls.Add(Me.CheckBoxナンセンスコール)
        Me.GroupBox3.Controls.Add(Me.CheckBox受付キャンセル)
        Me.GroupBox3.Controls.Add(Me.CheckBox受付保留)
        Me.GroupBox3.Controls.Add(Me.CheckBox受付完了)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 78)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(497, 65)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "点検状態区分"
        '
        'Label条件
        '
        Me.Label条件.Location = New System.Drawing.Point(387, 44)
        Me.Label条件.Name = "Label条件"
        Me.Label条件.Size = New System.Drawing.Size(104, 12)
        Me.Label条件.TabIndex = 12
        Me.Label条件.Text = "Label7"
        '
        'CheckBoxモバイル修理完了
        '
        Me.CheckBoxモバイル修理完了.AutoSize = True
        Me.CheckBoxモバイル修理完了.Checked = True
        Me.CheckBoxモバイル修理完了.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxモバイル修理完了.Location = New System.Drawing.Point(90, 40)
        Me.CheckBoxモバイル修理完了.Name = "CheckBoxモバイル修理完了"
        Me.CheckBoxモバイル修理完了.Size = New System.Drawing.Size(110, 16)
        Me.CheckBoxモバイル修理完了.TabIndex = 7
        Me.CheckBoxモバイル修理完了.Text = "モバイル修理完了"
        Me.CheckBoxモバイル修理完了.UseVisualStyleBackColor = True
        '
        'CheckBox修理完了
        '
        Me.CheckBox修理完了.AutoSize = True
        Me.CheckBox修理完了.Checked = True
        Me.CheckBox修理完了.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox修理完了.Location = New System.Drawing.Point(6, 40)
        Me.CheckBox修理完了.Name = "CheckBox修理完了"
        Me.CheckBox修理完了.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox修理完了.TabIndex = 6
        Me.CheckBox修理完了.Text = "修理完了"
        Me.CheckBox修理完了.UseVisualStyleBackColor = True
        '
        'CheckBox再訪問
        '
        Me.CheckBox再訪問.AutoSize = True
        Me.CheckBox再訪問.Location = New System.Drawing.Point(277, 44)
        Me.CheckBox再訪問.Name = "CheckBox再訪問"
        Me.CheckBox再訪問.Size = New System.Drawing.Size(60, 16)
        Me.CheckBox再訪問.TabIndex = 5
        Me.CheckBox再訪問.Text = "再訪問"
        Me.CheckBox再訪問.UseVisualStyleBackColor = True
        '
        'CheckBox訪問前キャンセル
        '
        Me.CheckBox訪問前キャンセル.AutoSize = True
        Me.CheckBox訪問前キャンセル.Location = New System.Drawing.Point(382, 18)
        Me.CheckBox訪問前キャンセル.Name = "CheckBox訪問前キャンセル"
        Me.CheckBox訪問前キャンセル.Size = New System.Drawing.Size(107, 16)
        Me.CheckBox訪問前キャンセル.TabIndex = 4
        Me.CheckBox訪問前キャンセル.Text = "訪問前キャンセル"
        Me.CheckBox訪問前キャンセル.UseVisualStyleBackColor = True
        '
        'CheckBoxナンセンスコール
        '
        Me.CheckBoxナンセンスコール.AutoSize = True
        Me.CheckBoxナンセンスコール.Location = New System.Drawing.Point(277, 18)
        Me.CheckBoxナンセンスコール.Name = "CheckBoxナンセンスコール"
        Me.CheckBoxナンセンスコール.Size = New System.Drawing.Size(99, 16)
        Me.CheckBoxナンセンスコール.TabIndex = 3
        Me.CheckBoxナンセンスコール.Text = "ナンセンスコール"
        Me.CheckBoxナンセンスコール.UseVisualStyleBackColor = True
        '
        'CheckBox受付キャンセル
        '
        Me.CheckBox受付キャンセル.AutoSize = True
        Me.CheckBox受付キャンセル.Location = New System.Drawing.Point(169, 18)
        Me.CheckBox受付キャンセル.Name = "CheckBox受付キャンセル"
        Me.CheckBox受付キャンセル.Size = New System.Drawing.Size(95, 16)
        Me.CheckBox受付キャンセル.TabIndex = 2
        Me.CheckBox受付キャンセル.Text = "受付キャンセル"
        Me.CheckBox受付キャンセル.UseVisualStyleBackColor = True
        '
        'CheckBox受付保留
        '
        Me.CheckBox受付保留.AutoSize = True
        Me.CheckBox受付保留.Location = New System.Drawing.Point(90, 18)
        Me.CheckBox受付保留.Name = "CheckBox受付保留"
        Me.CheckBox受付保留.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox受付保留.TabIndex = 1
        Me.CheckBox受付保留.Text = "受付保留"
        Me.CheckBox受付保留.UseVisualStyleBackColor = True
        '
        'CheckBox受付完了
        '
        Me.CheckBox受付完了.AutoSize = True
        Me.CheckBox受付完了.Location = New System.Drawing.Point(6, 18)
        Me.CheckBox受付完了.Name = "CheckBox受付完了"
        Me.CheckBox受付完了.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox受付完了.TabIndex = 0
        Me.CheckBox受付完了.Text = "受付完了"
        Me.CheckBox受付完了.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBoxNR後日請求)
        Me.GroupBox2.Controls.Add(Me.CheckBoxSS後日請求)
        Me.GroupBox2.Controls.Add(Me.CheckBoxSS現金徴収)
        Me.GroupBox2.Location = New System.Drawing.Point(518, 82)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 50)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "回収区分"
        '
        'CheckBoxNR後日請求
        '
        Me.CheckBoxNR後日請求.AutoSize = True
        Me.CheckBoxNR後日請求.Checked = True
        Me.CheckBoxNR後日請求.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxNR後日請求.Location = New System.Drawing.Point(200, 17)
        Me.CheckBoxNR後日請求.Name = "CheckBoxNR後日請求"
        Me.CheckBoxNR後日請求.Size = New System.Drawing.Size(88, 16)
        Me.CheckBoxNR後日請求.TabIndex = 2
        Me.CheckBoxNR後日請求.Text = "NR後日請求"
        Me.CheckBoxNR後日請求.UseVisualStyleBackColor = True
        '
        'CheckBoxSS後日請求
        '
        Me.CheckBoxSS後日請求.AutoSize = True
        Me.CheckBoxSS後日請求.Checked = True
        Me.CheckBoxSS後日請求.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSS後日請求.Location = New System.Drawing.Point(106, 17)
        Me.CheckBoxSS後日請求.Name = "CheckBoxSS後日請求"
        Me.CheckBoxSS後日請求.Size = New System.Drawing.Size(86, 16)
        Me.CheckBoxSS後日請求.TabIndex = 1
        Me.CheckBoxSS後日請求.Text = "SS後日請求"
        Me.CheckBoxSS後日請求.UseVisualStyleBackColor = True
        '
        'CheckBoxSS現金徴収
        '
        Me.CheckBoxSS現金徴収.AutoSize = True
        Me.CheckBoxSS現金徴収.Location = New System.Drawing.Point(14, 17)
        Me.CheckBoxSS現金徴収.Name = "CheckBoxSS現金徴収"
        Me.CheckBoxSS現金徴収.Size = New System.Drawing.Size(86, 16)
        Me.CheckBoxSS現金徴収.TabIndex = 0
        Me.CheckBoxSS現金徴収.Text = "SS現金徴収"
        Me.CheckBoxSS現金徴収.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox訪問ｷｬﾝｾﾙ)
        Me.GroupBox1.Controls.Add(Me.CheckBox受付ｷｬﾝｾﾙ)
        Me.GroupBox1.Controls.Add(Me.CheckBox訪問前ｷｬﾝｾﾙ)
        Me.GroupBox1.Controls.Add(Me.CheckBox回収完了)
        Me.GroupBox1.Controls.Add(Me.CheckBox請求書発行済)
        Me.GroupBox1.Controls.Add(Me.CheckBox点検完了)
        Me.GroupBox1.Controls.Add(Me.CheckBox点検受付)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(796, 45)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "スターﾀｽ"
        '
        'CheckBox訪問ｷｬﾝｾﾙ
        '
        Me.CheckBox訪問ｷｬﾝｾﾙ.AutoSize = True
        Me.CheckBox訪問ｷｬﾝｾﾙ.Location = New System.Drawing.Point(591, 19)
        Me.CheckBox訪問ｷｬﾝｾﾙ.Name = "CheckBox訪問ｷｬﾝｾﾙ"
        Me.CheckBox訪問ｷｬﾝｾﾙ.Size = New System.Drawing.Size(85, 16)
        Me.CheckBox訪問ｷｬﾝｾﾙ.TabIndex = 9
        Me.CheckBox訪問ｷｬﾝｾﾙ.Text = "訪問ｷｬﾝｾﾙ"
        Me.CheckBox訪問ｷｬﾝｾﾙ.UseVisualStyleBackColor = True
        '
        'CheckBox受付ｷｬﾝｾﾙ
        '
        Me.CheckBox受付ｷｬﾝｾﾙ.AutoSize = True
        Me.CheckBox受付ｷｬﾝｾﾙ.Location = New System.Drawing.Point(382, 19)
        Me.CheckBox受付ｷｬﾝｾﾙ.Name = "CheckBox受付ｷｬﾝｾﾙ"
        Me.CheckBox受付ｷｬﾝｾﾙ.Size = New System.Drawing.Size(85, 16)
        Me.CheckBox受付ｷｬﾝｾﾙ.TabIndex = 8
        Me.CheckBox受付ｷｬﾝｾﾙ.Text = "受付ｷｬﾝｾﾙ"
        Me.CheckBox受付ｷｬﾝｾﾙ.UseVisualStyleBackColor = True
        '
        'CheckBox訪問前ｷｬﾝｾﾙ
        '
        Me.CheckBox訪問前ｷｬﾝｾﾙ.AutoSize = True
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Location = New System.Drawing.Point(483, 18)
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Name = "CheckBox訪問前ｷｬﾝｾﾙ"
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Size = New System.Drawing.Size(97, 16)
        Me.CheckBox訪問前ｷｬﾝｾﾙ.TabIndex = 7
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Text = "訪問前ｷｬﾝｾﾙ"
        Me.CheckBox訪問前ｷｬﾝｾﾙ.UseVisualStyleBackColor = True
        '
        'CheckBox回収完了
        '
        Me.CheckBox回収完了.AutoSize = True
        Me.CheckBox回収完了.Location = New System.Drawing.Point(279, 19)
        Me.CheckBox回収完了.Name = "CheckBox回収完了"
        Me.CheckBox回収完了.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox回収完了.TabIndex = 3
        Me.CheckBox回収完了.Text = "回収完了"
        Me.CheckBox回収完了.UseVisualStyleBackColor = True
        '
        'CheckBox請求書発行済
        '
        Me.CheckBox請求書発行済.AutoSize = True
        Me.CheckBox請求書発行済.Location = New System.Drawing.Point(169, 19)
        Me.CheckBox請求書発行済.Name = "CheckBox請求書発行済"
        Me.CheckBox請求書発行済.Size = New System.Drawing.Size(96, 16)
        Me.CheckBox請求書発行済.TabIndex = 2
        Me.CheckBox請求書発行済.Text = "請求書発行済"
        Me.CheckBox請求書発行済.UseVisualStyleBackColor = True
        '
        'CheckBox点検完了
        '
        Me.CheckBox点検完了.AutoSize = True
        Me.CheckBox点検完了.Checked = True
        Me.CheckBox点検完了.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox点検完了.Location = New System.Drawing.Point(90, 19)
        Me.CheckBox点検完了.Name = "CheckBox点検完了"
        Me.CheckBox点検完了.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox点検完了.TabIndex = 1
        Me.CheckBox点検完了.Text = "点検完了"
        Me.CheckBox点検完了.UseVisualStyleBackColor = True
        '
        'CheckBox点検受付
        '
        Me.CheckBox点検受付.AutoSize = True
        Me.CheckBox点検受付.Location = New System.Drawing.Point(6, 19)
        Me.CheckBox点検受付.Name = "CheckBox点検受付"
        Me.CheckBox点検受付.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox点検受付.TabIndex = 0
        Me.CheckBox点検受付.Text = "点検受付"
        Me.CheckBox点検受付.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(445, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "～"
        '
        'ComboBox期間
        '
        Me.ComboBox期間.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox期間.FormattingEnabled = True
        Me.ComboBox期間.Location = New System.Drawing.Point(170, 6)
        Me.ComboBox期間.Name = "ComboBox期間"
        Me.ComboBox期間.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox期間.TabIndex = 5
        '
        'DateTimePicker期間2
        '
        Me.DateTimePicker期間2.Location = New System.Drawing.Point(468, 7)
        Me.DateTimePicker期間2.Name = "DateTimePicker期間2"
        Me.DateTimePicker期間2.Size = New System.Drawing.Size(107, 19)
        Me.DateTimePicker期間2.TabIndex = 4
        '
        'DateTimePicker期間1
        '
        Me.DateTimePicker期間1.Location = New System.Drawing.Point(338, 7)
        Me.DateTimePicker期間1.Name = "DateTimePicker期間1"
        Me.DateTimePicker期間1.Size = New System.Drawing.Size(103, 19)
        Me.DateTimePicker期間1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(297, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "期間"
        '
        'ComboBox項目
        '
        Me.ComboBox項目.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox項目.FormattingEnabled = True
        Me.ComboBox項目.Location = New System.Drawing.Point(43, 6)
        Me.ComboBox項目.Name = "ComboBox項目"
        Me.ComboBox項目.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox項目.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "項目"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1145, 377)
        Me.DataGridView1.TabIndex = 0
        '
        'FormCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 594)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "チェック"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox請求先.ResumeLayout(False)
        Me.GroupBox請求先.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox期間 As ComboBox
    Friend WithEvents DateTimePicker期間2 As DateTimePicker
    Friend WithEvents DateTimePicker期間1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox項目 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents 実行ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBoxNR後日請求 As CheckBox
    Friend WithEvents CheckBoxSS後日請求 As CheckBox
    Friend WithEvents CheckBoxSS現金徴収 As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox回収完了 As CheckBox
    Friend WithEvents CheckBox請求書発行済 As CheckBox
    Friend WithEvents CheckBox点検完了 As CheckBox
    Friend WithEvents CheckBox点検受付 As CheckBox
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel件数 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CheckBoxモバイル修理完了 As CheckBox
    Friend WithEvents CheckBox修理完了 As CheckBox
    Friend WithEvents CheckBox再訪問 As CheckBox
    Friend WithEvents CheckBox訪問前キャンセル As CheckBox
    Friend WithEvents CheckBoxナンセンスコール As CheckBox
    Friend WithEvents CheckBox受付キャンセル As CheckBox
    Friend WithEvents CheckBox受付保留 As CheckBox
    Friend WithEvents CheckBox受付完了 As CheckBox
    Friend WithEvents チェックToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox請求先 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox請求先電話 As TextBox
    Friend WithEvents TextBox請求先名 As TextBox
    Friend WithEvents TextBox請求先会社名 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBoxJy3 As ComboBox
    Friend WithEvents ComboBoxJy2 As ComboBox
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents Label条件 As Label
    Friend WithEvents CheckBox訪問ｷｬﾝｾﾙ As CheckBox
    Friend WithEvents CheckBox受付ｷｬﾝｾﾙ As CheckBox
    Friend WithEvents CheckBox訪問前ｷｬﾝｾﾙ As CheckBox
    Friend WithEvents CheckBox建物 As CheckBox
    Friend WithEvents Button正常を削除 As Button
    Friend WithEvents CheckBox完了を除く As CheckBox
    Friend WithEvents Button請求先電話CLEAR As Button
    Friend WithEvents Button請求先名CLEAR As Button
    Friend WithEvents Button請求先会社名CLEAR As Button
    Friend WithEvents 条件初期ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBox回収対象外 As CheckBox
    Friend WithEvents CheckBox物件重複を外す As CheckBox
    Friend WithEvents EXCEL未回収ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBoxZero As CheckBox
    Friend WithEvents チェックToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ALLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 全OFFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 反転ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 更新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBoxCIM As CheckBox
End Class
