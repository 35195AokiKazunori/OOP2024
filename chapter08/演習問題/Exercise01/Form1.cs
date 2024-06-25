using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            //"\r\n"¨‰üs
            var now = DateTime.Now;
            tbDisp.Text = now.ToString("yyyy/MM/dd hh:mm") + "\r\n" +
                          now.ToString("yyyy”NMMŒdd“ú hhmm•ªss•b") + "\r\n" +
                          now.ToString("ggyy”N MMŒdd“ú(dddd)");
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            DateTime nextWednesday = NextDay(today,DayOfWeek.Friday);
        }

        public static DateTime NextDay(DateTime date,DayOfWeek DayOfWeek) {
            var days = (int)DayOfWeek - (int)(date.DayOfWeek);
            if(days <= 0) 
                days += 7;
            return date.AddDays(days);
        }
    }
}
