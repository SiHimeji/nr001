<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMstSystem
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Buttonマルチ = New System.Windows.Forms.Button()
        Me.TextBox項目 = New System.Windows.Forms.TextBox()
        Me.Label項目 = New System.Windows.Forms.Label()
        Me.ComboBox条件 = New System.Windows.Forms.ComboBox()
        Me.Label条件 = New System.Windows.Forms.Label()
        Me.TextBox値 = New System.Windows.Forms.TextBox()
        Me.Label値 = New System.Windows.Forms.Label()
        Me.TextBox内容２ = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox備考 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxJy1 = New System.Windows.Forms.ComboBox()
        Me.Button削除 = New System.Windows.Forms.Button()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.Button検索１ = New System.Windows.Forms.Button()
        Me.TextBox内容 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxSEQ = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox区分 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.内容２ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.出力ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(882, 24)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Buttonマルチ)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox項目)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label項目)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox条件)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label条件)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox値)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label値)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox内容２)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox備考)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button削除)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button更新)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索１)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox内容)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxSEQ)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox区分)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(882, 473)
        Me.SplitContainer1.SplitterDistance = 116
        Me.SplitContainer1.TabIndex = 2
        '
        'Buttonマルチ
        '
        Me.Buttonマルチ.Location = New System.Drawing.Point(491, 87)
        Me.Buttonマルチ.Name = "Buttonマルチ"
        Me.Buttonマルチ.Size = New System.Drawing.Size(75, 23)
        Me.Buttonマルチ.TabIndex = 50
        Me.Buttonマルチ.Text = "マルチ"
        Me.Buttonマルチ.UseVisualStyleBackColor = True
        '
        'TextBox項目
        '
        Me.TextBox項目.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox項目.Location = New System.Drawing.Point(612, 59)
        Me.TextBox項目.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox項目.MaxLength = 50
        Me.TextBox項目.Name = "TextBox項目"
        Me.TextBox項目.Size = New System.Drawing.Size(113, 19)
        Me.TextBox項目.TabIndex = 48
        '
        'Label項目
        '
        Me.Label項目.AutoSize = True
        Me.Label項目.Location = New System.Drawing.Point(580, 62)
        Me.Label項目.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label項目.Name = "Label項目"
        Me.Label項目.Size = New System.Drawing.Size(29, 12)
        Me.Label項目.TabIndex = 49
        Me.Label項目.Text = "項目"
        '
        'ComboBox条件
        '
        Me.ComboBox条件.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox条件.FormattingEnabled = True
        Me.ComboBox条件.Items.AddRange(New Object() {"=", ">", "<", "=>", "<=", "<>"})
        Me.ComboBox条件.Location = New System.Drawing.Point(757, 83)
        Me.ComboBox条件.Name = "ComboBox条件"
        Me.ComboBox条件.Size = New System.Drawing.Size(113, 20)
        Me.ComboBox条件.TabIndex = 47
        '
        'Label条件
        '
        Me.Label条件.AutoSize = True
        Me.Label条件.Location = New System.Drawing.Point(724, 86)
        Me.Label条件.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label条件.Name = "Label条件"
        Me.Label条件.Size = New System.Drawing.Size(29, 12)
        Me.Label条件.TabIndex = 46
        Me.Label条件.Text = "条件"
        '
        'TextBox値
        '
        Me.TextBox値.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox値.Location = New System.Drawing.Point(758, 58)
        Me.TextBox値.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox値.MaxLength = 50
        Me.TextBox値.Name = "TextBox値"
        Me.TextBox値.Size = New System.Drawing.Size(113, 19)
        Me.TextBox値.TabIndex = 44
        '
        'Label値
        '
        Me.Label値.AutoSize = True
        Me.Label値.Location = New System.Drawing.Point(737, 61)
        Me.Label値.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label値.Name = "Label値"
        Me.Label値.Size = New System.Drawing.Size(17, 12)
        Me.Label値.TabIndex = 45
        Me.Label値.Text = "値"
        '
        'TextBox内容２
        '
        Me.TextBox内容２.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox内容２.Location = New System.Drawing.Point(294, 62)
        Me.TextBox内容２.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox内容２.MaxLength = 50
        Me.TextBox内容２.Name = "TextBox内容２"
        Me.TextBox内容２.Size = New System.Drawing.Size(272, 19)
        Me.TextBox内容２.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(254, 65)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "内容２"
        '
        'TextBox備考
        '
        Me.TextBox備考.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox備考.Location = New System.Drawing.Point(45, 88)
        Me.TextBox備考.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox備考.MaxLength = 100
        Me.TextBox備考.Name = "TextBox備考"
        Me.TextBox備考.Size = New System.Drawing.Size(441, 19)
        Me.TextBox備考.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 91)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "備考"
        '
        'ComboBoxJy1
        '
        Me.ComboBoxJy1.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy1.FormattingEnabled = True
        Me.ComboBoxJy1.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy1.Location = New System.Drawing.Point(243, 11)
        Me.ComboBoxJy1.Name = "ComboBoxJy1"
        Me.ComboBoxJy1.Size = New System.Drawing.Size(74, 20)
        Me.ComboBoxJy1.TabIndex = 1
        '
        'Button削除
        '
        Me.Button削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button削除.Location = New System.Drawing.Point(729, 10)
        Me.Button削除.Name = "Button削除"
        Me.Button削除.Size = New System.Drawing.Size(75, 23)
        Me.Button削除.TabIndex = 8
        Me.Button削除.Text = "削除"
        Me.Button削除.UseVisualStyleBackColor = False
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(648, 10)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(75, 23)
        Me.Button更新.TabIndex = 7
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'Button検索１
        '
        Me.Button検索１.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索１.Location = New System.Drawing.Point(327, 9)
        Me.Button検索１.Name = "Button検索１"
        Me.Button検索１.Size = New System.Drawing.Size(75, 25)
        Me.Button検索１.TabIndex = 2
        Me.Button検索１.Text = "検索"
        Me.Button検索１.UseVisualStyleBackColor = False
        '
        'TextBox内容
        '
        Me.TextBox内容.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox内容.Location = New System.Drawing.Point(45, 62)
        Me.TextBox内容.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox内容.MaxLength = 50
        Me.TextBox内容.Name = "TextBox内容"
        Me.TextBox内容.Size = New System.Drawing.Size(191, 19)
        Me.TextBox内容.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "内容"
        '
        'TextBoxSEQ
        '
        Me.TextBoxSEQ.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxSEQ.Location = New System.Drawing.Point(45, 37)
        Me.TextBoxSEQ.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxSEQ.MaxLength = 10
        Me.TextBoxSEQ.Name = "TextBoxSEQ"
        Me.TextBoxSEQ.Size = New System.Drawing.Size(191, 19)
        Me.TextBoxSEQ.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 12)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "SEQ"
        '
        'TextBox区分
        '
        Me.TextBox区分.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox区分.Location = New System.Drawing.Point(45, 12)
        Me.TextBox区分.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox区分.MaxLength = 10
        Me.TextBox区分.Name = "TextBox区分"
        Me.TextBox区分.Size = New System.Drawing.Size(191, 19)
        Me.TextBox区分.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "区分"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.内容２, Me.Column9, Me.Column7, Me.Column8, Me.Column4, Me.Column5, Me.Column6})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(882, 353)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "区分"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.HeaderText = "SEQ"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 125
        '
        'Column3
        '
        Me.Column3.HeaderText = "内容"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 125
        '
        '内容２
        '
        Me.内容２.HeaderText = "内容２"
        Me.内容２.Name = "内容２"
        '
        'Column9
        '
        Me.Column9.HeaderText = "項目"
        Me.Column9.Name = "Column9"
        '
        'Column7
        '
        Me.Column7.HeaderText = "値"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "条件"
        Me.Column8.Name = "Column8"
        '
        'Column4
        '
        Me.Column4.HeaderText = "備考"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 125
        '
        'Column5
        '
        Me.Column5.HeaderText = "登録日"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 125
        '
        'Column6
        '
        Me.Column6.HeaderText = "更新者"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 125
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 497)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(882, 22)
        Me.StatusStrip1.TabIndex = 6
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = " "
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(200, 16)
        '
        'FormMstSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 519)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "FormMstSystem"
        Me.Text = "システム設定マスタ"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TextBox備考 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBoxJy1 As ComboBox
    Friend WithEvents Button削除 As Button
    Friend WithEvents Button更新 As Button
    Friend WithEvents Button検索１ As Button
    Friend WithEvents TextBox内容 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxSEQ As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox区分 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox内容２ As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents ComboBox条件 As ComboBox
    Friend WithEvents Label条件 As Label
    Friend WithEvents TextBox値 As TextBox
    Friend WithEvents Label値 As Label
    Friend WithEvents TextBox項目 As TextBox
    Friend WithEvents Label項目 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents 内容２ As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Buttonマルチ As Button
End Class
