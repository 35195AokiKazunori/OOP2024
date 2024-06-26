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
            var dateTime = DateTime.Today;

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                var str1 = string.Format("{0:yy/MM/dd}の次週の{1}", dateTime, (DayOfWeek)dayofweek);
                //来週の日付を取得(戻り値を受け取ること)
                var str2 = string.Format("{0:yy/MM/dd(ddd)}", NextWeek(dateTime, (DayOfWeek)dayofweek));
                tbDisp.Text = str1 + str2 +"\r\n";
            }
        }

        //第1引数で指定した日付の、第2引数で指定した翌週の曜日のインスタンスを返却
        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);
            var day = (int)dayOfWeek - (int)date.DayOfWeek;
            return nextweek.AddDays(day);
        }

        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = String.Format("処理時間は{0}ミリ秒でした",duration.TotalMilliseconds);
            tbDisp.Text = str;
        }
    }

    class TimeWatch {
        private DateTime _time;

        public void Start() {
            _time = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - _time;
        }
    }
}
