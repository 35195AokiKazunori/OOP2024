namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btVersionOk = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btVersionOk
            // 
            btVersionOk.Location = new Point(375, 12);
            btVersionOk.Name = "btVersionOk";
            btVersionOk.Size = new Size(75, 23);
            btVersionOk.TabIndex = 0;
            btVersionOk.Text = "OK";
            btVersionOk.UseVisualStyleBackColor = true;
            btVersionOk.Click += btVersionOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("游明朝 Demibold", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(229, 34);
            label1.TabIndex = 1;
            label1.Text = "CarReportSystem";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("游明朝 Demibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 2;
            label2.Text = "Version";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("游明朝 Demibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label3.Location = new Point(12, 97);
            label3.Name = "label3";
            label3.Size = new Size(42, 21);
            label3.TabIndex = 3;
            label3.Text = "会社";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 262);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btVersionOk);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btVersionOk;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}