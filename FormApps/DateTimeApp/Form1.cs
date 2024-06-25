using Microsoft.VisualBasic;

namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void btDateCount_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            TimeSpan diff = today - dtpDate.Value;

            //tbDisp.Text = "ÅZÅZì˙ñ⁄";
            tbDisp.Text = (diff.Days + 1) + "ì˙ñ⁄";
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e) {

        }

        private void tbDisp_TextChanged(object sender, EventArgs e) {

        }

        private void btDaybefure_Click(object sender, EventArgs e) {
            var past = dtpDate.Value.AddDays((double)-nmud.Value);
            tbDisp.Text = past.ToString("D");
        }

        private void btDayafter_Click(object sender, EventArgs e) {
            var future = dtpDate.Value.AddDays((double)+nmud.Value);
            tbDisp.Text = future.ToString("D");
        }

        private void btYear_Click(object sender, EventArgs e) {
            var birthday = dtpDate.Value;
            var today = DateTime.Today;
            int age = GetAge(birthday, today);
            tbDisp.Text = age.ToString("D");
        }

        public static int GetAge(DateTime birthday, DateTime tergetDay) {
            var age = tergetDay.Year - birthday.Year;
            if (tergetDay < (birthday.AddYears(age)).AddDays(-1)) {
                age--;
            }
            return age;
        }

        private void dtpDate_ValueChanged_1(object sender, EventArgs e) {

        }
    }
}
