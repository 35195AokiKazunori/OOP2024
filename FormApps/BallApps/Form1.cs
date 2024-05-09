namespace BallApps {
    public partial class Form1 : Form {
        //Obj obj;
        //PictureBox pb;

        //List�R���N�V����
        private List<Obj> balls = new List<Obj>();
        private List<PictureBox> pbs = new List<PictureBox>();

        //Bar�p
        private Bar bar;
        private PictureBox pbBar;

        //�R���X�g���N�^
        public Form1() {
            InitializeComponent();
        }

        //�t�H�[�����ŏ��Ƀ��[�h�����Ƃ���x�������s�����
        private void Form1_Load(object sender, EventArgs e) {

            this.Text = "BallApps SoccerBall:0 TennisBall:0";

            bar = new Bar(340, 500);
            pbBar = new PictureBox();
            pbBar.Image = bar.Image;
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);
            pbBar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBar.Parent = this;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //obj.Move();
            //pb.Location = new Point((int)obj.PosX, (int)obj.PosY);

            for (int i = 0; i < balls.Count; i++) {
                balls[i].Move(pbBar, pbs[i]);
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);
            }

        }

        //�}�E�X�N���b�N�C�x���g�n���h��
        private void timer2_Tick(object sender, EventArgs e) {
            //obj.Move();
            //pb.Location = new Point((int)obj.PosX, (int)obj.PosY);
            for (int i = 0; i < balls.Count; i++) {
                balls[i].Move(pbBar, pbs[i]);
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = new PictureBox();   //�摜��\������R���g���[��
            Obj obj = null;

            if (e.Button == MouseButtons.Left) {
                ; obj = new SoccerBall(0, 0);
                pb.Size = new Size(50, 50);
                timer1.Start();

            } else if (e.Button == MouseButtons.Right) {
                ; obj = new TennisBall(e.X - 25, e.Y - 25);
                pb.Size = new Size(25, 25);
                timer2.Start();
            }
            pb.Image = obj.Image;
            pb.Location = new Point((int)obj.PosX, (int)obj.PosY);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Parent = this;

            balls.Add(obj);
            pbs.Add(pb);

            this.Text = "BallApps SoccerBall:" + SoccerBall.Count + "TennisBall:" + TennisBall.Count;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            bar.Move(e.KeyCode);
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);

        }
    }
}