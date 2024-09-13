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
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
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
            resources.ApplyResources(this.btGenre, "btGenre");
            this.btGenre.Name = "btGenre";
            this.btGenre.UseVisualStyleBackColor = true;
            this.btGenre.Click += new System.EventHandler(this.btGenre_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btGenre);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.lbRssTitle);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbRssTitle;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.Button btGenre;
    }
}

