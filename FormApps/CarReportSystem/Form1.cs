using System.ComponentModel;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {


        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //�ݒ�N���X�̃C���X�^���X�쐬
        Settings settings = Settings.getInstance();

        //�R���X�g���N�^
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }


        //���͂����l��ǉ�����
        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
                return;
            } else {
                tslbMessage.Text = "";
            }

            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);

            setCbAuthor(cbAuthor.Text);

            dgvCarReport.ClearSelection();
            inputItemsAllClear();
        }


        //���͍��ڂ����ׂăN���A
        private void inputItemsAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            setRadioButtonMaker(CarReport.MakerGroup.�Ȃ�);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
        }


        //�L�^�҂̗������R���{�{�b�N�X�֓o�^(�d���Ȃ�)
        private void setCbAuthor(string author) {

            if (cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }


        //�Ԗ��̗������R���{�{�b�N�X�ֈړ�(�d���Ȃ�)
        private void setCbCarName(string carName) {
            cbCarName.Text = carName;
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }


        //�I������Ă��郁�[�J�[����񋓌^�ŕԂ�
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.�g���^;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.���Y;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.�z���_;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.�X�o��;
            if (rbImport.Checked)
                return CarReport.MakerGroup.�A����;
            if (rbOther.Checked)
                return CarReport.MakerGroup.���̑�;

            return CarReport.MakerGroup.���̑�;
        }


        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {

            switch (targetMaker) {
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.���̑�:
                    rbOther.Checked = true;
                    break;
                default:
                    break;
            }
        }


        //�t�H���_����ʐ^��Y�t����
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }


        //�Y�t�����ʐ^���폜����
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }


        //�摜�\�����Ȃ�
        private void Form1_Load(object sender, EventArgs e) {
            //dgvCarReport.Columns["Picture"].Visible = false;  //�摜�\�����Ȃ�

            //���݂ɐF��ݒ�(�f�[�^�O���b�g�r���[)
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            if (File.Exists("settings.xml")) {
                //�ݒ�t�@�C�����t�V���A�������Ĕw�i��ݒ�(P301 ���X�g12.7���Q�l)
                try {
                    using (var reader = XmlReader.Create("settings.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var settings = serializer.Deserialize(reader) as Settings;
                        BackColor = Color.FromArgb(settings.MainFormColor);
                        settings.MainFormColor = BackColor.ToArgb();
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "�F���t�@�C���G���[";
                }
            } else {
                tslbMessage.Text = "�F���t�@�C��������܂���";
            }
        }


        //�쐬�������|�[�g��ۑ�
        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == 0) ||
                (!dgvCarReport.CurrentRow.Selected)) return;

            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;

            setRadioButtonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);

            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;

            //pbPicture.Image = dgvCarReport.CurrentRow.Cells["Picture"].Value as Image;
        }


        //�폜�{�^��
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null) ||
                (!dgvCarReport.CurrentRow.Selected)) return;
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            dgvCarReport.ClearSelection();
        }


        //�C���{�^��
        private void btModifyReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null) ||
                (!dgvCarReport.CurrentRow.Selected)) return;


            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;

            dgvCarReport.Refresh(); //�f�[�^�O���b�h�r���[�̍X�V
        }


        //�L�^�҂̃e�L�X�g���ҏW
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }


        //�Ԗ��̃e�L�X�g���ҏW
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }


        //�ۑ��{�^��
        private void sfdReportFileSave_FileOk(object sender, CancelEventArgs e) {
            ReportSaveFile();
        }
        private void ReportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���[�`���ŃV���A����
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "�������݃G���[";
                }
            }
        }


        //�t�H���_���烌�|�[�g�������Ă���
        private void dtReportOpen_Click(object sender, EventArgs e) {
            ReportSaveOpen();
        }
        private void ReportSaveOpen() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A�����Ńo�C�i���`���Ŏ��g��
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReport.DataSource = listCarReports;

                        foreach (var carReport in listCarReports) {
                            setCbAuthor(carReport.Author);
                            setCbCarName(carReport.CarName);
                        }

                    }
                }
                catch (Exception ex) {
                    tslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
                }
                dgvCarReport.ClearSelection();
            }
        }


        //�e���ڂ��N���A����
        private void btReportClear_Click(object sender, EventArgs e) {
            inputItemsAllClear();
        }


        //�J���{�^��
        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveOpen();
        }


        //�ۑ��{�^��
        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }


        //�I���{�^��
        private void �I��ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MessageBox.Show("�{���ɏI�����܂����H", "�m�F",
                MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Application.Exit();
            }
        }


        //�F�ݒ�{�^��
        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;  //�w�i�F�ݒ�
                settings.MainFormColor = cdColor.Color.ToArgb(); //�w�i�F�ۑ�
            }
        }


        //���I���{�^��
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //�ݒ�t�@�C���̃V���A����
            try {
                using (var writer = XmlWriter.Create("settings.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings); //�G���[
                }
            }
            catch (Exception) {
                MessageBox.Show("�ݒ�t�@�C���������݃G���[");
                throw;
            }
        }


        //
        private void ���̃A�v���ɂ���ToolStripMenuItem_Click(object sender, EventArgs e) {
            var fmVersion = new fmVersion();
            fmVersion.ShowDialog();
        }
    }
}