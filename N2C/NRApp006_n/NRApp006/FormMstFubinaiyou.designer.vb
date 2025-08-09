<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMstFubinaiyou
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMstFubinaiyou))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button新規採番 = New System.Windows.Forms.Button()
        Me.ComboBox判定２ = New System.Windows.Forms.ComboBox()
        Me.ComboBox点検項目２ = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxNo = New System.Windows.Forms.TextBox()
        Me.TextBox不備内容 = New System.Windows.Forms.TextBox()
        Me.TextBox製品名 = New System.Windows.Forms.TextBox()
        Me.ComboBox判定１ = New System.Windows.Forms.ComboBox()
        Me.ComboBox点検項目１ = New System.Windows.Forms.ComboBox()
        Me.ComboBox機器分類 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button削除 = New System.Windows.Forms.Button()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.機器分類 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.製品名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.点検項目 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.判定 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.不備内容 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.出力ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1037, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '出力ToolStripMenuItem1
        '
        Me.出力ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem})
        Me.出力ToolStripMenuItem1.Name = "出力ToolStripMenuItem1"
        Me.出力ToolStripMenuItem1.Size = New System.Drawing.Size(43, 20)
        Me.出力ToolStripMenuItem1.Text = "出力"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button新規採番)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox判定２)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox点検項目２)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox不備内容)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox製品名)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox判定１)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox点検項目１)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox機器分類)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button削除)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button更新)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1037, 549)
        Me.SplitContainer1.SplitterDistance = 134
        Me.SplitContainer1.TabIndex = 2
        '
        'Button新規採番
        '
        Me.Button新規採番.Location = New System.Drawing.Point(123, 7)
        Me.Button新規採番.Name = "Button新規採番"
        Me.Button新規採番.Size = New System.Drawing.Size(75, 23)
        Me.Button新規採番.TabIndex = 29
        Me.Button新規採番.Text = "新規採番"
        Me.Button新規採番.UseVisualStyleBackColor = True
        '
        'ComboBox判定２
        '
        Me.ComboBox判定２.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox判定２.FormattingEnabled = True
        Me.ComboBox判定２.Location = New System.Drawing.Point(250, 90)
        Me.ComboBox判定２.Name = "ComboBox判定２"
        Me.ComboBox判定２.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox判定２.TabIndex = 28
        '
        'ComboBox点検項目２
        '
        Me.ComboBox点検項目２.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox点検項目２.FormattingEnabled = True
        Me.ComboBox点検項目２.Location = New System.Drawing.Point(72, 90)
        Me.ComboBox点検項目２.Name = "ComboBox点検項目２"
        Me.ComboBox点検項目２.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox点検項目２.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(212, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 12)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "判定２"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 12)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "点検項目２"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 12)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "No"
        '
        'TextBoxNo
        '
        Me.TextBoxNo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxNo.Location = New System.Drawing.Point(72, 10)
        Me.TextBoxNo.Name = "TextBoxNo"
        Me.TextBoxNo.Size = New System.Drawing.Size(44, 19)
        Me.TextBoxNo.TabIndex = 23
        '
        'TextBox不備内容
        '
        Me.TextBox不備内容.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox不備内容.Location = New System.Drawing.Point(459, 91)
        Me.TextBox不備内容.Name = "TextBox不備内容"
        Me.TextBox不備内容.Size = New System.Drawing.Size(277, 19)
        Me.TextBox不備内容.TabIndex = 22
        '
        'TextBox製品名
        '
        Me.TextBox製品名.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox製品名.Location = New System.Drawing.Point(459, 63)
        Me.TextBox製品名.Name = "TextBox製品名"
        Me.TextBox製品名.Size = New System.Drawing.Size(178, 19)
        Me.TextBox製品名.TabIndex = 21
        '
        'ComboBox判定１
        '
        Me.ComboBox判定１.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox判定１.FormattingEnabled = True
        Me.ComboBox判定１.Location = New System.Drawing.Point(250, 62)
        Me.ComboBox判定１.Name = "ComboBox判定１"
        Me.ComboBox判定１.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox判定１.TabIndex = 20
        '
        'ComboBox点検項目１
        '
        Me.ComboBox点検項目１.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox点検項目１.FormattingEnabled = True
        Me.ComboBox点検項目１.Location = New System.Drawing.Point(72, 62)
        Me.ComboBox点検項目１.Name = "ComboBox点検項目１"
        Me.ComboBox点検項目１.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox点検項目１.TabIndex = 19
        '
        'ComboBox機器分類
        '
        Me.ComboBox機器分類.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox機器分類.FormattingEnabled = True
        Me.ComboBox機器分類.Location = New System.Drawing.Point(72, 35)
        Me.ComboBox機器分類.Name = "ComboBox機器分類"
        Me.ComboBox機器分類.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox機器分類.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(401, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "不備内容"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(212, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "判定１"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(413, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "製品名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 12)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "点検項目１"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "機器分類"
        '
        'Button削除
        '
        Me.Button削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button削除.Location = New System.Drawing.Point(708, 3)
        Me.Button削除.Name = "Button削除"
        Me.Button削除.Size = New System.Drawing.Size(75, 23)
        Me.Button削除.TabIndex = 12
        Me.Button削除.Text = "削除"
        Me.Button削除.UseVisualStyleBackColor = False
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(627, 3)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(75, 23)
        Me.Button更新.TabIndex = 11
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.機器分類, Me.製品名, Me.点検項目, Me.判定, Me.Column1, Me.Column2, Me.不備内容})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1037, 411)
        Me.DataGridView1.TabIndex = 0
        '
        'No
        '
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.Width = 30
        '
        '機器分類
        '
        Me.機器分類.HeaderText = "機器分類"
        Me.機器分類.Name = "機器分類"
        '
        '製品名
        '
        Me.製品名.HeaderText = "製品名"
        Me.製品名.Name = "製品名"
        Me.製品名.Width = 150
        '
        '点検項目
        '
        Me.点検項目.HeaderText = "点検項目１"
        Me.点検項目.Name = "点検項目"
        '
        '判定
        '
        Me.判定.HeaderText = "判定１"
        Me.判定.Name = "判定"
        Me.判定.Width = 70
        '
        'Column1
        '
        Me.Column1.HeaderText = "点検項目２"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "判定２"
        Me.Column2.Name = "Column2"
        '
        '不備内容
        '
        Me.不備内容.HeaderText = "不備内容"
        Me.不備内容.Name = "不備内容"
        Me.不備内容.Width = 300
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 573)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1037, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 30
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "機器分類"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "点検項目"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "製品名"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "判定"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "不備内容"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 300
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(904, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 12)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "※システム区分番号150"
        '
        'FormMstFubinaiyou
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1037, 595)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMstFubinaiyou"
        Me.Text = "不備内容マスタ（製品）"
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
    Friend WithEvents Button削除 As Button
    Friend WithEvents Button更新 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox不備内容 As TextBox
    Friend WithEvents TextBox製品名 As TextBox
    Friend WithEvents ComboBox判定１ As ComboBox
    Friend WithEvents ComboBox点検項目１ As ComboBox
    Friend WithEvents ComboBox機器分類 As ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents TextBoxNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents ComboBox判定２ As ComboBox
    Friend WithEvents ComboBox点検項目２ As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents 出力ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents 機器分類 As DataGridViewTextBoxColumn
    Friend WithEvents 製品名 As DataGridViewTextBoxColumn
    Friend WithEvents 点検項目 As DataGridViewTextBoxColumn
    Friend WithEvents 判定 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents 不備内容 As DataGridViewTextBoxColumn
    Friend WithEvents Button新規採番 As Button
    Friend WithEvents Label9 As Label
End Class
