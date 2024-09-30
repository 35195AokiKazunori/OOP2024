namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.btGenre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRssSave = new System.Windows.Forms.ListBox();
            this.btSave = new System.Windows.Forms.Button();
            this.dtDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.色設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.このアプリについてToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            resources.ApplyResources(this.lbRssTitle, "lbRssTitle");
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.SelectedIndexChanged += new System.EventHandler(this.lbRssTitle_SelectedIndexChanged);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            resources.ApplyResources(this.webView21, "webView21");
            this.webView21.Name = "webView21";
            this.webView21.ZoomFactor = 1D;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbGenre
            // 
            this.cbGenre.FormattingEnabled = true;
            resources.ApplyResources(this.cbGenre, "cbGenre");
            this.cbGenre.Name = "cbGenre";
            // 
            // btGenre
            // 
            this.btGenre.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.btGenre, "btGenre");
            this.btGenre.Name = "btGenre";
            this.btGenre.UseVisualStyleBackColor = false;
            this.btGenre.Click += new System.EventHandler(this.btGenre_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbRssSave
            // 
            this.lbRssSave.FormattingEnabled = true;
            resources.ApplyResources(this.lbRssSave, "lbRssSave");
            this.lbRssSave.Name = "lbRssSave";
            this.lbRssSave.SelectedIndexChanged += new System.EventHandler(this.lbRssSave_SelectedIndexChanged);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.btSave, "btSave");
            this.btSave.Name = "btSave";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // dtDelete
            // 
            this.dtDelete.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.dtDelete, "dtDelete");
            this.dtDelete.Name = "dtDelete";
            this.dtDelete.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.色設定ToolStripMenuItem,
            this.終了ToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            resources.ApplyResources(this.ファイルFToolStripMenuItem, "ファイルFToolStripMenuItem");
            // 
            // 色設定ToolStripMenuItem
            // 
            this.色設定ToolStripMenuItem.Name = "色設定ToolStripMenuItem";
            resources.ApplyResources(this.色設定ToolStripMenuItem, "色設定ToolStripMenuItem");
            this.色設定ToolStripMenuItem.Click += new System.EventHandler(this.色設定ToolStripMenuItem_Click);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            resources.ApplyResources(this.終了ToolStripMenuItem, "終了ToolStripMenuItem");
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.このアプリについてToolStripMenuItem});
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            resources.ApplyResources(this.ヘルプHToolStripMenuItem, "ヘルプHToolStripMenuItem");
            // 
            // このアプリについてToolStripMenuItem
            // 
            this.このアプリについてToolStripMenuItem.Name = "このアプリについてToolStripMenuItem";
            resources.ApplyResources(this.このアプリについてToolStripMenuItem, "このアプリについてToolStripMenuItem");
            this.このアプリについてToolStripMenuItem.Click += new System.EventHandler(this.このアプリについてToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtDelete);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lbRssSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGenre);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbRssTitle;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.Button btGenre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbRssSave;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button dtDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 色設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem このアプリについてToolStripMenuItem;
        private System.Windows.Forms.ColorDialog cdColor;
    }
}

