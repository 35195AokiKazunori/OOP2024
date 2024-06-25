namespace DateTimeApp {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            dtpDate = new DateTimePicker();
            btDateCount = new Button();
            tbDisp = new TextBox();
            nmud = new NumericUpDown();
            btDaybefure = new Button();
            btDayafter = new Button();
            btYear = new Button();
            ((System.ComponentModel.ISupportInitialize)nmud).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(110, 32);
            label1.TabIndex = 0;
            label1.Text = "生年月日";
            label1.Click += label1_Click;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(128, 18);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 1;
            dtpDate.ValueChanged += dtpDate_ValueChanged_1;
            // 
            // btDateCount
            // 
            btDateCount.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDateCount.Location = new Point(218, 47);
            btDateCount.Name = "btDateCount";
            btDateCount.Size = new Size(110, 38);
            btDateCount.TabIndex = 2;
            btDateCount.Text = "今日までの日数";
            btDateCount.UseVisualStyleBackColor = true;
            btDateCount.Click += btDateCount_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbDisp.Location = new Point(12, 231);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(316, 33);
            tbDisp.TabIndex = 3;
            tbDisp.TextChanged += tbDisp_TextChanged;
            // 
            // nmud
            // 
            nmud.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nmud.Location = new Point(21, 129);
            nmud.Name = "nmud";
            nmud.Size = new Size(120, 46);
            nmud.TabIndex = 4;
            // 
            // btDaybefure
            // 
            btDaybefure.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDaybefure.Location = new Point(168, 105);
            btDaybefure.Name = "btDaybefure";
            btDaybefure.Size = new Size(120, 46);
            btDaybefure.TabIndex = 5;
            btDaybefure.Text = "日前";
            btDaybefure.UseVisualStyleBackColor = true;
            btDaybefure.Click += btDaybefure_Click;
            // 
            // btDayafter
            // 
            btDayafter.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDayafter.Location = new Point(168, 157);
            btDayafter.Name = "btDayafter";
            btDayafter.Size = new Size(120, 46);
            btDayafter.TabIndex = 6;
            btDayafter.Text = "日後";
            btDayafter.UseVisualStyleBackColor = true;
            btDayafter.Click += btDayafter_Click;
            // 
            // btYear
            // 
            btYear.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btYear.Location = new Point(294, 105);
            btYear.Name = "btYear";
            btYear.Size = new Size(120, 46);
            btYear.TabIndex = 7;
            btYear.Text = "年齢";
            btYear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btYear);
            Controls.Add(btDayafter);
            Controls.Add(btDaybefure);
            Controls.Add(nmud);
            Controls.Add(tbDisp);
            Controls.Add(btDateCount);
            Controls.Add(dtpDate);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nmud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDate;
        private Button btDateCount;
        private TextBox tbDisp;
        private NumericUpDown nmud;
        private Button btDaybefure;
        private Button btDayafter;
        private Button btYear;
    }
}
