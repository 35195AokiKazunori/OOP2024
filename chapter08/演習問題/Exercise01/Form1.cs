using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            //"\r\n"�����s
            var now = DateTime.Now;
            tbDisp.Text = now.ToString("yyyy/MM/dd hh:mm") + "\r\n" +
                          now.ToString("yyyy�NMM��dd�� hh��mm��ss�b") + "\r\n" +
                          now.ToString("ggyy�N MM��dd��(dddd)");
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Today;

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                var str1 = string.Format("{0:yy/MM/dd}�̎��T��{1}", dateTime, (DayOfWeek)dayofweek);
                //���T�̓��t���擾(�߂�l���󂯎�邱��)
                var str2 = string.Format("{0:yy/MM/dd(ddd)}", NextWeek(dateTime, (DayOfWeek)dayofweek));
                tbDisp.Text = str1 + str2 +"\r\n";
            }
        }

        //��1�����Ŏw�肵�����t�́A��2�����Ŏw�肵�����T�̗j���̃C���X�^���X��ԋp
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
            var str = String.Format("�������Ԃ�{0}�~���b�ł���",duration.TotalMilliseconds);
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
