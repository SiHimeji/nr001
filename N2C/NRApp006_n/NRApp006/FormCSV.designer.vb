<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCSV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCSV))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel件数 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSV選択ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.取り込み実行ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.条件初期ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ButtonDM番号CLEAR = New System.Windows.Forms.Button()
        Me.Button点検受付番号CLEAR = New System.Windows.Forms.Button()
        Me.Button集約 = New System.Windows.Forms.Button()
        Me.CheckBox集約データ = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxモバイル修理完了 = New System.Windows.Forms.CheckBox()
        Me.CheckBox修理完了 = New System.Windows.Forms.CheckBox()
        Me.CheckBox再訪問 = New System.Windows.Forms.CheckBox()
        Me.CheckBox訪問前キャンセル = New System.Windows.Forms.CheckBox()
        Me.CheckBoxナンセンスコール = New System.Windows.Forms.CheckBox()
        Me.CheckBox受付キャンセル = New System.Windows.Forms.CheckBox()
        Me.CheckBox受付保留 = New System.Windows.Forms.CheckBox()
        Me.CheckBox受付完了 = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button請求先電話CLEAR = New System.Windows.Forms.Button()
        Me.Button請求先名CLEAR = New System.Windows.Forms.Button()
        Me.Button請求先会社名CLEAR = New System.Windows.Forms.Button()
        Me.ComboBoxJy3 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy2 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.TextBox請求先電話 = New System.Windows.Forms.TextBox()
        Me.TextBox請求先名 = New System.Windows.Forms.TextBox()
        Me.TextBox請求先会社名 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ComboBox期間 = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker期間2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker期間1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxDM番号 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox点検受付番号 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox訪問ｷｬﾝｾﾙ = New System.Windows.Forms.CheckBox()
        Me.CheckBox受付ｷｬﾝｾﾙ = New System.Windows.Forms.CheckBox()
        Me.CheckBox訪問前ｷｬﾝｾﾙ = New System.Windows.Forms.CheckBox()
        Me.CheckBox回収完了 = New System.Windows.Forms.CheckBox()
        Me.CheckBox請求書発行済 = New System.Windows.Forms.CheckBox()
        Me.CheckBox点検完了 = New System.Windows.Forms.CheckBox()
        Me.CheckBox点検受付 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxNR後日請求 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSS後日請求 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSS現金徴収 = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CheckBoxCIM = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel件数, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 560)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1125, 22)
        Me.StatusStrip1.TabIndex = 0
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel件数
        '
        Me.ToolStripStatusLabel件数.Name = "ToolStripStatusLabel件数"
        Me.ToolStripStatusLabel件数.Size = New System.Drawing.Size(43, 17)
        Me.ToolStripStatusLabel件数.Text = "9999件"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel3.Text = "  "
        Me.ToolStripStatusLabel3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripStatusLabel4.Text = "　"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(300, 16)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.CSV選択ToolStripMenuItem, Me.取り込み実行ToolStripMenuItem, Me.条件初期ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1125, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'CSV選択ToolStripMenuItem
        '
        Me.CSV選択ToolStripMenuItem.Checked = True
        Me.CSV選択ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CSV選択ToolStripMenuItem.Name = "CSV選択ToolStripMenuItem"
        Me.CSV選択ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.CSV選択ToolStripMenuItem.Text = "検索"
        '
        '取り込み実行ToolStripMenuItem
        '
        Me.取り込み実行ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem, Me.CSVToolStripMenuItem})
        Me.取り込み実行ToolStripMenuItem.Name = "取り込み実行ToolStripMenuItem"
        Me.取り込み実行ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.取り込み実行ToolStripMenuItem.Text = "出力"
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
        '条件初期ToolStripMenuItem
        '
        Me.条件初期ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.条件初期ToolStripMenuItem.Name = "条件初期ToolStripMenuItem"
        Me.条件初期ToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.条件初期ToolStripMenuItem.Text = "条件(初期)"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonDM番号CLEAR)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button点検受付番号CLEAR)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button集約)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox集約データ)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxDM番号)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox点検受付番号)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1125, 536)
        Me.SplitContainer1.SplitterDistance = 195
        Me.SplitContainer1.TabIndex = 2
        '
        'ButtonDM番号CLEAR
        '
        Me.ButtonDM番号CLEAR.Location = New System.Drawing.Point(843, 15)
        Me.ButtonDM番号CLEAR.Name = "ButtonDM番号CLEAR"
        Me.ButtonDM番号CLEAR.Size = New System.Drawing.Size(26, 19)
        Me.ButtonDM番号CLEAR.TabIndex = 24
        Me.ButtonDM番号CLEAR.Text = "X"
        Me.ButtonDM番号CLEAR.UseVisualStyleBackColor = True
        '
        'Button点検受付番号CLEAR
        '
        Me.Button点検受付番号CLEAR.Location = New System.Drawing.Point(656, 15)
        Me.Button点検受付番号CLEAR.Name = "Button点検受付番号CLEAR"
        Me.Button点検受付番号CLEAR.Size = New System.Drawing.Size(26, 19)
        Me.Button点検受付番号CLEAR.TabIndex = 23
        Me.Button点検受付番号CLEAR.Text = "X"
        Me.Button点検受付番号CLEAR.UseVisualStyleBackColor = True
        '
        'Button集約
        '
        Me.Button集約.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button集約.Location = New System.Drawing.Point(880, 13)
        Me.Button集約.Name = "Button集約"
        Me.Button集約.Size = New System.Drawing.Size(126, 23)
        Me.Button集約.TabIndex = 22
        Me.Button集約.Text = "集約データのみ"
        Me.Button集約.UseVisualStyleBackColor = False
        '
        'CheckBox集約データ
        '
        Me.CheckBox集約データ.AutoSize = True
        Me.CheckBox集約データ.Location = New System.Drawing.Point(1012, 16)
        Me.CheckBox集約データ.Name = "CheckBox集約データ"
        Me.CheckBox集約データ.Size = New System.Drawing.Size(96, 16)
        Me.CheckBox集約データ.TabIndex = 21
        Me.CheckBox集約データ.Text = "ALL集約データ"
        Me.CheckBox集約データ.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CheckBoxモバイル修理完了)
        Me.GroupBox5.Controls.Add(Me.CheckBox修理完了)
        Me.GroupBox5.Controls.Add(Me.CheckBox再訪問)
        Me.GroupBox5.Controls.Add(Me.CheckBox訪問前キャンセル)
        Me.GroupBox5.Controls.Add(Me.CheckBoxナンセンスコール)
        Me.GroupBox5.Controls.Add(Me.CheckBox受付キャンセル)
        Me.GroupBox5.Controls.Add(Me.CheckBox受付保留)
        Me.GroupBox5.Controls.Add(Me.CheckBox受付完了)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 102)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(497, 77)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "点検状態区分"
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
        Me.CheckBox再訪問.Checked = True
        Me.CheckBox再訪問.CheckState = System.Windows.Forms.CheckState.Checked
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
        Me.CheckBox受付完了.Checked = True
        Me.CheckBox受付完了.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox受付完了.Location = New System.Drawing.Point(6, 18)
        Me.CheckBox受付完了.Name = "CheckBox受付完了"
        Me.CheckBox受付完了.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox受付完了.TabIndex = 0
        Me.CheckBox受付完了.Text = "受付完了"
        Me.CheckBox受付完了.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button請求先電話CLEAR)
        Me.GroupBox4.Controls.Add(Me.Button請求先名CLEAR)
        Me.GroupBox4.Controls.Add(Me.Button請求先会社名CLEAR)
        Me.GroupBox4.Controls.Add(Me.ComboBoxJy3)
        Me.GroupBox4.Controls.Add(Me.ComboBoxJy2)
        Me.GroupBox4.Controls.Add(Me.ComboBoxJy1)
        Me.GroupBox4.Controls.Add(Me.TextBox請求先電話)
        Me.GroupBox4.Controls.Add(Me.TextBox請求先名)
        Me.GroupBox4.Controls.Add(Me.TextBox請求先会社名)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(814, 50)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(291, 135)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "請求先"
        '
        'Button請求先電話CLEAR
        '
        Me.Button請求先電話CLEAR.Location = New System.Drawing.Point(157, 106)
        Me.Button請求先電話CLEAR.Name = "Button請求先電話CLEAR"
        Me.Button請求先電話CLEAR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求先電話CLEAR.TabIndex = 11
        Me.Button請求先電話CLEAR.Text = "X"
        Me.Button請求先電話CLEAR.UseVisualStyleBackColor = True
        '
        'Button請求先名CLEAR
        '
        Me.Button請求先名CLEAR.Location = New System.Drawing.Point(174, 68)
        Me.Button請求先名CLEAR.Name = "Button請求先名CLEAR"
        Me.Button請求先名CLEAR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求先名CLEAR.TabIndex = 10
        Me.Button請求先名CLEAR.Text = "X"
        Me.Button請求先名CLEAR.UseVisualStyleBackColor = True
        '
        'Button請求先会社名CLEAR
        '
        Me.Button請求先会社名CLEAR.Location = New System.Drawing.Point(174, 31)
        Me.Button請求先会社名CLEAR.Name = "Button請求先会社名CLEAR"
        Me.Button請求先会社名CLEAR.Size = New System.Drawing.Size(26, 19)
        Me.Button請求先会社名CLEAR.TabIndex = 9
        Me.Button請求先会社名CLEAR.Text = "X"
        Me.Button請求先会社名CLEAR.UseVisualStyleBackColor = True
        '
        'ComboBoxJy3
        '
        Me.ComboBoxJy3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy3.FormattingEnabled = True
        Me.ComboBoxJy3.Items.AddRange(New Object() {"一致", "一部"})
        Me.ComboBoxJy3.Location = New System.Drawing.Point(202, 105)
        Me.ComboBoxJy3.Name = "ComboBoxJy3"
        Me.ComboBoxJy3.Size = New System.Drawing.Size(85, 20)
        Me.ComboBoxJy3.TabIndex = 8
        '
        'ComboBoxJy2
        '
        Me.ComboBoxJy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy2.FormattingEnabled = True
        Me.ComboBoxJy2.Items.AddRange(New Object() {"一致", "一部"})
        Me.ComboBoxJy2.Location = New System.Drawing.Point(202, 67)
        Me.ComboBoxJy2.Name = "ComboBoxJy2"
        Me.ComboBoxJy2.Size = New System.Drawing.Size(85, 20)
        Me.ComboBoxJy2.TabIndex = 7
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"一致", "一部"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(202, 31)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(85, 20)
        Me.ComboBoxJy1.TabIndex = 6
        '
        'TextBox請求先電話
        '
        Me.TextBox請求先電話.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox請求先電話.Location = New System.Drawing.Point(21, 106)
        Me.TextBox請求先電話.MaxLength = 12
        Me.TextBox請求先電話.Name = "TextBox請求先電話"
        Me.TextBox請求先電話.Size = New System.Drawing.Size(137, 19)
        Me.TextBox請求先電話.TabIndex = 5
        '
        'TextBox請求先名
        '
        Me.TextBox請求先名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求先名.Location = New System.Drawing.Point(21, 68)
        Me.TextBox請求先名.MaxLength = 32
        Me.TextBox請求先名.Name = "TextBox請求先名"
        Me.TextBox請求先名.Size = New System.Drawing.Size(155, 19)
        Me.TextBox請求先名.TabIndex = 4
        '
        'TextBox請求先会社名
        '
        Me.TextBox請求先会社名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox請求先会社名.Location = New System.Drawing.Point(21, 31)
        Me.TextBox請求先会社名.MaxLength = 32
        Me.TextBox請求先会社名.Name = "TextBox請求先会社名"
        Me.TextBox請求先会社名.Size = New System.Drawing.Size(155, 19)
        Me.TextBox請求先会社名.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "請求先電話"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "請求先名"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "請求先会社名"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboBox期間)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker期間2)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker期間1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(453, 41)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "期間"
        '
        'ComboBox期間
        '
        Me.ComboBox期間.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox期間.FormattingEnabled = True
        Me.ComboBox期間.Location = New System.Drawing.Point(6, 15)
        Me.ComboBox期間.Name = "ComboBox期間"
        Me.ComboBox期間.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox期間.TabIndex = 17
        '
        'DateTimePicker期間2
        '
        Me.DateTimePicker期間2.Location = New System.Drawing.Point(308, 16)
        Me.DateTimePicker期間2.Name = "DateTimePicker期間2"
        Me.DateTimePicker期間2.Size = New System.Drawing.Size(107, 19)
        Me.DateTimePicker期間2.TabIndex = 16
        '
        'DateTimePicker期間1
        '
        Me.DateTimePicker期間1.Location = New System.Drawing.Point(153, 16)
        Me.DateTimePicker期間1.Name = "DateTimePicker期間1"
        Me.DateTimePicker期間1.Size = New System.Drawing.Size(103, 19)
        Me.DateTimePicker期間1.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(269, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "から"
        '
        'TextBoxDM番号
        '
        Me.TextBoxDM番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxDM番号.Location = New System.Drawing.Point(733, 15)
        Me.TextBoxDM番号.MaxLength = 20
        Me.TextBoxDM番号.Name = "TextBoxDM番号"
        Me.TextBoxDM番号.Size = New System.Drawing.Size(111, 19)
        Me.TextBoxDM番号.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(686, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 12)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "DM番号"
        '
        'TextBox点検受付番号
        '
        Me.TextBox点検受付番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox点検受付番号.Location = New System.Drawing.Point(542, 15)
        Me.TextBox点検受付番号.MaxLength = 12
        Me.TextBox点検受付番号.Name = "TextBox点検受付番号"
        Me.TextBox点検受付番号.Size = New System.Drawing.Size(114, 19)
        Me.TextBox点検受付番号.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(464, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "点検受付番号"
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
        Me.GroupBox1.Location = New System.Drawing.Point(7, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 46)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "スターﾀｽ"
        '
        'CheckBox訪問ｷｬﾝｾﾙ
        '
        Me.CheckBox訪問ｷｬﾝｾﾙ.AutoSize = True
        Me.CheckBox訪問ｷｬﾝｾﾙ.Location = New System.Drawing.Point(546, 18)
        Me.CheckBox訪問ｷｬﾝｾﾙ.Name = "CheckBox訪問ｷｬﾝｾﾙ"
        Me.CheckBox訪問ｷｬﾝｾﾙ.Size = New System.Drawing.Size(85, 16)
        Me.CheckBox訪問ｷｬﾝｾﾙ.TabIndex = 6
        Me.CheckBox訪問ｷｬﾝｾﾙ.Text = "訪問ｷｬﾝｾﾙ"
        Me.CheckBox訪問ｷｬﾝｾﾙ.UseVisualStyleBackColor = True
        '
        'CheckBox受付ｷｬﾝｾﾙ
        '
        Me.CheckBox受付ｷｬﾝｾﾙ.AutoSize = True
        Me.CheckBox受付ｷｬﾝｾﾙ.Location = New System.Drawing.Point(460, 18)
        Me.CheckBox受付ｷｬﾝｾﾙ.Name = "CheckBox受付ｷｬﾝｾﾙ"
        Me.CheckBox受付ｷｬﾝｾﾙ.Size = New System.Drawing.Size(85, 16)
        Me.CheckBox受付ｷｬﾝｾﾙ.TabIndex = 5
        Me.CheckBox受付ｷｬﾝｾﾙ.Text = "受付ｷｬﾝｾﾙ"
        Me.CheckBox受付ｷｬﾝｾﾙ.UseVisualStyleBackColor = True
        '
        'CheckBox訪問前ｷｬﾝｾﾙ
        '
        Me.CheckBox訪問前ｷｬﾝｾﾙ.AutoSize = True
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Location = New System.Drawing.Point(357, 18)
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Name = "CheckBox訪問前ｷｬﾝｾﾙ"
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Size = New System.Drawing.Size(97, 16)
        Me.CheckBox訪問前ｷｬﾝｾﾙ.TabIndex = 4
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Text = "訪問前ｷｬﾝｾﾙ"
        Me.CheckBox訪問前ｷｬﾝｾﾙ.UseVisualStyleBackColor = True
        '
        'CheckBox回収完了
        '
        Me.CheckBox回収完了.AutoSize = True
        Me.CheckBox回収完了.Location = New System.Drawing.Point(270, 18)
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
        Me.CheckBox点検受付.Checked = True
        Me.CheckBox点検受付.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox点検受付.Location = New System.Drawing.Point(6, 19)
        Me.CheckBox点検受付.Name = "CheckBox点検受付"
        Me.CheckBox点検受付.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox点検受付.TabIndex = 0
        Me.CheckBox点検受付.Text = "点検受付"
        Me.CheckBox点検受付.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBoxNR後日請求)
        Me.GroupBox2.Controls.Add(Me.CheckBoxSS後日請求)
        Me.GroupBox2.Controls.Add(Me.CheckBoxSS現金徴収)
        Me.GroupBox2.Location = New System.Drawing.Point(509, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 39)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "回収区分"
        '
        'CheckBoxNR後日請求
        '
        Me.CheckBoxNR後日請求.AutoSize = True
        Me.CheckBoxNR後日請求.Checked = True
        Me.CheckBoxNR後日請求.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxNR後日請求.Location = New System.Drawing.Point(200, 19)
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
        Me.CheckBoxSS後日請求.Location = New System.Drawing.Point(106, 19)
        Me.CheckBoxSS後日請求.Name = "CheckBoxSS後日請求"
        Me.CheckBoxSS後日請求.Size = New System.Drawing.Size(86, 16)
        Me.CheckBoxSS後日請求.TabIndex = 1
        Me.CheckBoxSS後日請求.Text = "SS後日請求"
        Me.CheckBoxSS後日請求.UseVisualStyleBackColor = True
        '
        'CheckBoxSS現金徴収
        '
        Me.CheckBoxSS現金徴収.AutoSize = True
        Me.CheckBoxSS現金徴収.Checked = True
        Me.CheckBoxSS現金徴収.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSS現金徴収.Location = New System.Drawing.Point(14, 19)
        Me.CheckBoxSS現金徴収.Name = "CheckBoxSS現金徴収"
        Me.CheckBoxSS現金徴収.Size = New System.Drawing.Size(86, 16)
        Me.CheckBoxSS現金徴収.TabIndex = 0
        Me.CheckBoxSS現金徴収.Text = "SS現金徴収"
        Me.CheckBoxSS現金徴収.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1125, 337)
        Me.DataGridView1.TabIndex = 0
        '
        'CheckBoxCIM
        '
        Me.CheckBoxCIM.AutoSize = True
        Me.CheckBoxCIM.Location = New System.Drawing.Point(509, 159)
        Me.CheckBoxCIM.Name = "CheckBoxCIM"
        Me.CheckBoxCIM.Size = New System.Drawing.Size(114, 16)
        Me.CheckBoxCIM.TabIndex = 25
        Me.CheckBoxCIM.Text = "旧システムも含める"
        Me.CheckBoxCIM.UseVisualStyleBackColor = True
        '
        'FormCSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 582)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormCSV"
        Me.Text = "点検集約データ"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents CSV選択ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 取り込み実行ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel件数 As ToolStripStatusLabel
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBoxNR後日請求 As CheckBox
    Friend WithEvents CheckBoxSS後日請求 As CheckBox
    Friend WithEvents CheckBoxSS現金徴収 As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox訪問ｷｬﾝｾﾙ As CheckBox
    Friend WithEvents CheckBox受付ｷｬﾝｾﾙ As CheckBox
    Friend WithEvents CheckBox訪問前ｷｬﾝｾﾙ As CheckBox
    Friend WithEvents CheckBox回収完了 As CheckBox
    Friend WithEvents CheckBox請求書発行済 As CheckBox
    Friend WithEvents CheckBox点検完了 As CheckBox
    Friend WithEvents CheckBox点検受付 As CheckBox
    Friend WithEvents TextBox点検受付番号 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxDM番号 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox期間 As ComboBox
    Friend WithEvents DateTimePicker期間2 As DateTimePicker
    Friend WithEvents DateTimePicker期間1 As DateTimePicker
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ComboBoxJy3 As ComboBox
    Friend WithEvents ComboBoxJy2 As ComboBox
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents TextBox請求先電話 As TextBox
    Friend WithEvents TextBox請求先名 As TextBox
    Friend WithEvents TextBox請求先会社名 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents CheckBoxモバイル修理完了 As CheckBox
    Friend WithEvents CheckBox修理完了 As CheckBox
    Friend WithEvents CheckBox再訪問 As CheckBox
    Friend WithEvents CheckBox訪問前キャンセル As CheckBox
    Friend WithEvents CheckBoxナンセンスコール As CheckBox
    Friend WithEvents CheckBox受付キャンセル As CheckBox
    Friend WithEvents CheckBox受付保留 As CheckBox
    Friend WithEvents CheckBox受付完了 As CheckBox
    Friend WithEvents CheckBox集約データ As CheckBox
    Friend WithEvents Button集約 As Button
    Friend WithEvents 条件初期ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button請求先会社名CLEAR As Button
    Friend WithEvents Button請求先名CLEAR As Button
    Friend WithEvents Button請求先電話CLEAR As Button
    Friend WithEvents Button点検受付番号CLEAR As Button
    Friend WithEvents ButtonDM番号CLEAR As Button
    Friend WithEvents CheckBoxCIM As CheckBox
End Class
