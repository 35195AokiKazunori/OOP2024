using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class fmVersion : Form {
        public fmVersion() {
            InitializeComponent();
        }

        private void btVersionOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void fmVersion_Load(object sender, EventArgs e) {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var var = assembly.GetName().Version;
            label2.Text = "Ver." + var.ToString();

            var company = assembly.GetName();
            label3.Text = company.ToString();
        }
    }
}
