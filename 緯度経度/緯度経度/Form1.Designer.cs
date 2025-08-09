namespace 緯度経度
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXCLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRACLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sLserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIdoFrom = new System.Windows.Forms.TextBox();
            this.textBoxKeidoFrom = new System.Windows.Forms.TextBox();
            this.textBoxKeidoTo = new System.Windows.Forms.TextBox();
            this.textBoxIdoTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxKyori = new System.Windows.Forms.TextBox();
            this.textBoxken = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem,
            this.eXCLToolStripMenuItem,
            this.dBToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(473, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // eXCLToolStripMenuItem
            // 
            this.eXCLToolStripMenuItem.Name = "eXCLToolStripMenuItem";
            this.eXCLToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.eXCLToolStripMenuItem.Text = "EXCEL";
            this.eXCLToolStripMenuItem.Click += new System.EventHandler(this.eXCLToolStripMenuItem_Click);
            // 
            // dBToolStripMenuItem
            // 
            this.dBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oRACLEToolStripMenuItem,
            this.sLserverToolStripMenuItem});
            this.dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            this.dBToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.dBToolStripMenuItem.Text = "DB";
            // 
            // oRACLEToolStripMenuItem
            // 
            this.oRACLEToolStripMenuItem.Name = "oRACLEToolStripMenuItem";
            this.oRACLEToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.oRACLEToolStripMenuItem.Text = "ORACLE";
            this.oRACLEToolStripMenuItem.Click += new System.EventHandler(this.oRACLEToolStripMenuItem_Click);
            // 
            // sLserverToolStripMenuItem
            // 
            this.sLserverToolStripMenuItem.Name = "sLserverToolStripMenuItem";
            this.sLserverToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.sLserverToolStripMenuItem.Text = "SQLserver";
            this.sLserverToolStripMenuItem.Click += new System.EventHandler(this.sLserverToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "緯度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "経度";
            // 
            // textBoxIdoFrom
            // 
            this.textBoxIdoFrom.Location = new System.Drawing.Point(48, 24);
            this.textBoxIdoFrom.Name = "textBoxIdoFrom";
            this.textBoxIdoFrom.Size = new System.Drawing.Size(100, 19);
            this.textBoxIdoFrom.TabIndex = 3;
            // 
            // textBoxKeidoFrom
            // 
            this.textBoxKeidoFrom.Location = new System.Drawing.Point(201, 24);
            this.textBoxKeidoFrom.Name = "textBoxKeidoFrom";
            this.textBoxKeidoFrom.Size = new System.Drawing.Size(100, 19);
            this.textBoxKeidoFrom.TabIndex = 4;
            // 
            // textBoxKeidoTo
            // 
            this.textBoxKeidoTo.Location = new System.Drawing.Point(201, 49);
            this.textBoxKeidoTo.Name = "textBoxKeidoTo";
            this.textBoxKeidoTo.Size = new System.Drawing.Size(100, 19);
            this.textBoxKeidoTo.TabIndex = 8;
            // 
            // textBoxIdoTo
            // 
            this.textBoxIdoTo.Location = new System.Drawing.Point(48, 49);
            this.textBoxIdoTo.Name = "textBoxIdoTo";
            this.textBoxIdoTo.Size = new System.Drawing.Size(100, 19);
            this.textBoxIdoTo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "経度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "緯度";
            // 
            // textBoxKyori
            // 
            this.textBoxKyori.Location = new System.Drawing.Point(48, 74);
            this.textBoxKyori.Name = "textBoxKyori";
            this.textBoxKyori.Size = new System.Drawing.Size(100, 19);
            this.textBoxKyori.TabIndex = 9;
            // 
            // textBoxken
            // 
            this.textBoxken.Location = new System.Drawing.Point(380, 27);
            this.textBoxken.Name = "textBoxken";
            this.textBoxken.Size = new System.Drawing.Size(52, 19);
            this.textBoxken.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(322, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 19);
            this.textBox1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 142);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxken);
            this.Controls.Add(this.textBoxKyori);
            this.Controls.Add(this.textBoxKeidoTo);
            this.Controls.Add(this.textBoxIdoTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxKeidoFrom);
            this.Controls.Add(this.textBoxIdoFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "緯度経度";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIdoFrom;
        private System.Windows.Forms.TextBox textBoxKeidoFrom;
        private System.Windows.Forms.TextBox textBoxKeidoTo;
        private System.Windows.Forms.TextBox textBoxIdoTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxKyori;
        private System.Windows.Forms.ToolStripMenuItem eXCLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRACLEToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxken;
        private System.Windows.Forms.ToolStripMenuItem sLserverToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}

