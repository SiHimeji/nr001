<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormZaikoKanri
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormZaikoKanri))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NEXTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button希望納期 = New System.Windows.Forms.Button()
        Me.DateTimePicker希望納期 = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button補充数１以上 = New System.Windows.Forms.Button()
        Me.TextBoxルール = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox備考 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBoxJy = New System.Windows.Forms.ComboBox()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.NumericUpDown補充数 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown受注中 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown現在庫 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown基準 = New System.Windows.Forms.NumericUpDown()
        Me.TextBox品名 = New System.Windows.Forms.TextBox()
        Me.ComboBox倉庫 = New System.Windows.Forms.ComboBox()
        Me.Button品コード検索 = New System.Windows.Forms.Button()
        Me.TextBox品コード = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.NumericUpDown補充数, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown受注中, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown現在庫, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown基準, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.閉じるToolStripMenuItem, Me.出力ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(914, 30)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '閉じるToolStripMenuItem
        '
        Me.閉じるToolStripMenuItem.Font = New System.Drawing.Font("Yu Gothic UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem"
        Me.閉じるToolStripMenuItem.Size = New System.Drawing.Size(58, 24)
        Me.閉じるToolStripMenuItem.Text = "閉じる"
        '
        '出力ToolStripMenuItem
        '
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NEXTToolStripMenuItem})
        Me.出力ToolStripMenuItem.Font = New System.Drawing.Font("Yu Gothic UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(51, 24)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'NEXTToolStripMenuItem
        '
        Me.NEXTToolStripMenuItem.Name = "NEXTToolStripMenuItem"
        Me.NEXTToolStripMenuItem.Size = New System.Drawing.Size(119, 24)
        Me.NEXTToolStripMenuItem.Text = "EXCEL"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 507)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(914, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 30)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button希望納期)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker希望納期)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button補充数１以上)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxルール)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox備考)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button更新)
        Me.SplitContainer1.Panel1.Controls.Add(Me.NumericUpDown補充数)
        Me.SplitContainer1.Panel1.Controls.Add(Me.NumericUpDown受注中)
        Me.SplitContainer1.Panel1.Controls.Add(Me.NumericUpDown現在庫)
        Me.SplitContainer1.Panel1.Controls.Add(Me.NumericUpDown基準)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox品名)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox倉庫)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button品コード検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox品コード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(914, 477)
        Me.SplitContainer1.SplitterDistance = 164
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 2
        '
        'Button希望納期
        '
        Me.Button希望納期.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button希望納期.Location = New System.Drawing.Point(545, 13)
        Me.Button希望納期.Name = "Button希望納期"
        Me.Button希望納期.Size = New System.Drawing.Size(135, 41)
        Me.Button希望納期.TabIndex = 27
        Me.Button希望納期.Text = "希望納期,補充数" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "再計算"
        Me.Button希望納期.UseVisualStyleBackColor = False
        '
        'DateTimePicker希望納期
        '
        Me.DateTimePicker希望納期.Location = New System.Drawing.Point(545, 73)
        Me.DateTimePicker希望納期.Name = "DateTimePicker希望納期"
        Me.DateTimePicker希望納期.Size = New System.Drawing.Size(135, 23)
        Me.DateTimePicker希望納期.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(466, 77)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "希望納期"
        '
        'Button補充数１以上
        '
        Me.Button補充数１以上.Location = New System.Drawing.Point(779, 12)
        Me.Button補充数１以上.Name = "Button補充数１以上"
        Me.Button補充数１以上.Size = New System.Drawing.Size(118, 51)
        Me.Button補充数１以上.TabIndex = 24
        Me.Button補充数１以上.Text = "補充数１以上"
        Me.Button補充数１以上.UseVisualStyleBackColor = True
        '
        'TextBoxルール
        '
        Me.TextBoxルール.Location = New System.Drawing.Point(94, 130)
        Me.TextBoxルール.Name = "TextBoxルール"
        Me.TextBoxルール.Size = New System.Drawing.Size(116, 23)
        Me.TextBoxルール.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(230, 75)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "現在庫"
        '
        'TextBox備考
        '
        Me.TextBox備考.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox備考.Location = New System.Drawing.Point(469, 130)
        Me.TextBox備考.Multiline = True
        Me.TextBox備考.Name = "TextBox備考"
        Me.TextBox備考.Size = New System.Drawing.Size(211, 23)
        Me.TextBox備考.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(423, 133)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "備考"
        '
        'ComboBoxJy
        '
        Me.ComboBoxJy.AutoCompleteCustomSource.AddRange(New String() {"一致", "部分", "前方", "後方"})
        Me.ComboBoxJy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJy.FormattingEnabled = True
        Me.ComboBoxJy.Items.AddRange(New Object() {"一致", "一部", "前方", "後方"})
        Me.ComboBoxJy.Location = New System.Drawing.Point(248, 12)
        Me.ComboBoxJy.Name = "ComboBoxJy"
        Me.ComboBoxJy.Size = New System.Drawing.Size(74, 24)
        Me.ComboBoxJy.TabIndex = 18
        '
        'Button検索
        '
        Me.Button検索.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button検索.Location = New System.Drawing.Point(328, 13)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(75, 23)
        Me.Button検索.TabIndex = 19
        Me.Button検索.Text = "検索"
        Me.Button検索.UseVisualStyleBackColor = False
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(779, 110)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(123, 43)
        Me.Button更新.TabIndex = 17
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'NumericUpDown補充数
        '
        Me.NumericUpDown補充数.Location = New System.Drawing.Point(287, 130)
        Me.NumericUpDown補充数.Name = "NumericUpDown補充数"
        Me.NumericUpDown補充数.Size = New System.Drawing.Size(116, 23)
        Me.NumericUpDown補充数.TabIndex = 16
        '
        'NumericUpDown受注中
        '
        Me.NumericUpDown受注中.Location = New System.Drawing.Point(287, 101)
        Me.NumericUpDown受注中.Name = "NumericUpDown受注中"
        Me.NumericUpDown受注中.Size = New System.Drawing.Size(116, 23)
        Me.NumericUpDown受注中.TabIndex = 15
        '
        'NumericUpDown現在庫
        '
        Me.NumericUpDown現在庫.Location = New System.Drawing.Point(287, 72)
        Me.NumericUpDown現在庫.Name = "NumericUpDown現在庫"
        Me.NumericUpDown現在庫.Size = New System.Drawing.Size(116, 23)
        Me.NumericUpDown現在庫.TabIndex = 14
        '
        'NumericUpDown基準
        '
        Me.NumericUpDown基準.Location = New System.Drawing.Point(94, 73)
        Me.NumericUpDown基準.Name = "NumericUpDown基準"
        Me.NumericUpDown基準.Size = New System.Drawing.Size(116, 23)
        Me.NumericUpDown基準.TabIndex = 13
        '
        'TextBox品名
        '
        Me.TextBox品名.Location = New System.Drawing.Point(90, 42)
        Me.TextBox品名.Name = "TextBox品名"
        Me.TextBox品名.Size = New System.Drawing.Size(310, 23)
        Me.TextBox品名.TabIndex = 11
        '
        'ComboBox倉庫
        '
        Me.ComboBox倉庫.FormattingEnabled = True
        Me.ComboBox倉庫.Location = New System.Drawing.Point(94, 102)
        Me.ComboBox倉庫.Name = "ComboBox倉庫"
        Me.ComboBox倉庫.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox倉庫.TabIndex = 10
        '
        'Button品コード検索
        '
        Me.Button品コード検索.Location = New System.Drawing.Point(194, 12)
        Me.Button品コード検索.Name = "Button品コード検索"
        Me.Button品コード検索.Size = New System.Drawing.Size(37, 24)
        Me.Button品コード検索.TabIndex = 9
        Me.Button品コード検索.UseVisualStyleBackColor = True
        '
        'TextBox品コード
        '
        Me.TextBox品コード.Location = New System.Drawing.Point(90, 13)
        Me.TextBox品コード.Name = "TextBox品コード"
        Me.TextBox品コード.Size = New System.Drawing.Size(100, 23)
        Me.TextBox品コード.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(230, 133)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "補充数"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(230, 104)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "受注中"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(48, 133)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "ルール"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(53, 77)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "基準"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 45)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "品名"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 103)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "倉庫"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "品コード"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(914, 308)
        Me.DataGridView1.TabIndex = 0
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'FormZaikoKanri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 529)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormZaikoKanri"
        Me.Text = "在庫移動"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.NumericUpDown補充数, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown受注中, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown現在庫, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown基準, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NEXTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button更新 As Button
    Friend WithEvents NumericUpDown補充数 As NumericUpDown
    Friend WithEvents NumericUpDown受注中 As NumericUpDown
    Friend WithEvents NumericUpDown現在庫 As NumericUpDown
    Friend WithEvents NumericUpDown基準 As NumericUpDown
    Friend WithEvents TextBox品名 As TextBox
    Friend WithEvents ComboBox倉庫 As ComboBox
    Friend WithEvents Button品コード検索 As Button
    Friend WithEvents TextBox品コード As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxJy As ComboBox
    Friend WithEvents Button検索 As Button
    Friend WithEvents TextBox備考 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBoxルール As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button補充数１以上 As Button
    Friend WithEvents DateTimePicker希望納期 As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Button希望納期 As Button
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
End Class
