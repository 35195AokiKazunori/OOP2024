using System.ComponentModel;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //CarReport�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //�R���X�g���N�^
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
            };
            listCarReports.Add(carReport);
        }
    }
}
