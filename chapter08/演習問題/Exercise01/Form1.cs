using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            //"\r\n"→改行
            var now = DateTime.Now;
            tbDisp.Text = now.ToString("yyyy/MM/dd hh:mm") + "\r\n" +
                          now.ToString("yyyy年MM月dd日 hh時mm分ss秒") + "\r\n" +
                          now.ToString("ggyy年 MM月dd日(dddd)");
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
