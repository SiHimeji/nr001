<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSystemMult
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
        Me.TextBoxMSG = New System.Windows.Forms.TextBox()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.Buttonキャンセル = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBoxMSG
        '
        Me.TextBoxMSG.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextBoxMSG.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBoxMSG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBoxMSG.Location = New System.Drawing.Point(2, 2)
        Me.TextBoxMSG.Multiline = True
        Me.TextBoxMSG.Name = "TextBoxMSG"
        Me.TextBoxMSG.Size = New System.Drawing.Size(419, 186)
        Me.TextBoxMSG.TabIndex = 24
        Me.TextBoxMSG.Text = "ジェットフロー・クイックオート" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "（ＹＧＶ・ＹＶ　　　ＧＱ－ﾗﾗﾗﾗＡ・ＧＱ－ＣﾗﾗﾗﾗＡ）の点検項目" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "判定結果「0」で対象機種でない場合" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   ⇒　自11「" &
    "0」→「4」該当機種でないため" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "判定結果「4」で対象機種の場合 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  ⇒　自11「4」→該当機種です " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Button更新
        '
        Me.Button更新.Location = New System.Drawing.Point(300, 198)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(121, 23)
        Me.Button更新.TabIndex = 25
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = True
        '
        'Buttonキャンセル
        '
        Me.Buttonキャンセル.Location = New System.Drawing.Point(2, 194)
        Me.Buttonキャンセル.Name = "Buttonキャンセル"
        Me.Buttonキャンセル.Size = New System.Drawing.Size(121, 23)
        Me.Buttonキャンセル.TabIndex = 26
        Me.Buttonキャンセル.Text = "キャンセル"
        Me.Buttonキャンセル.UseVisualStyleBackColor = True
        '
        'FormSystemMult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 229)
        Me.ControlBox = False
        Me.Controls.Add(Me.Buttonキャンセル)
        Me.Controls.Add(Me.Button更新)
        Me.Controls.Add(Me.TextBoxMSG)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormSystemMult"
        Me.Text = "編集"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxMSG As TextBox
    Friend WithEvents Button更新 As Button
    Friend WithEvents Buttonキャンセル As Button
End Class
