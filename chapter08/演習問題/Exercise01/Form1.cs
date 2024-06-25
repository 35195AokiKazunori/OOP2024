namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {

            var now = DateTime.Now;
            tbDisp.Text = now.ToString("yyyy/MM/dd hh:mm") + "\r\n" +
                          now.ToString("yyyy”NMMŒŽdd“ú hhŽžmm•ªss•b") + "\r\n" +
                          now.ToString("ggyy”N MMŒŽdd“ú(dddd)");

        }
    }
}
