using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;
using System.Collections.Generic;

namespace projet_alcoolemie_3 {
    public partial class MainView : Form {

        public Modele MyModele {
            get {
                return _myModele;
            }

            set {
                _myModele = value;
            }
        }
        Modele _myModele;

        public MainView() {
            InitializeComponent();

            MyModele = new Modele();

            if (File.Exists("myModelData.xml")) {
                FileStream fs = new FileStream("myModelData.xml", FileMode.Open);
                XmlSerializer xs = new XmlSerializer(typeof(Modele));
                MyModele = (Modele)xs.Deserialize(fs);
                fs.Close();
                timUpdate.Enabled = true;
            }
            else {
                UserDataView udView = new UserDataView(MyModele, true);
                udView.ShowDialog();
            }
        }

        private void MainView_Load(object sender, EventArgs e) {
            UpdateView();
        }

        private void timUpdate_Tick(object sender, EventArgs e) {
            MyModele.CalculerBaisseTauxAlcoolemie();
            MyModele.AddARTT();

            UpdateView();
        }

        private void UpdateView() {
            pbxGraph.Image = PaintGraph(pbxGraph.Width, pbxGraph.Height);

            lblAlcohol.Text = String.Format("{0:0.0000}‰", MyModele.TauxAlcoolemie);
            lblName.Text = String.Format("Bonjour, {0}", MyModele.Username);
        }

        private void btnBoire_Click(object sender, EventArgs e) {
            DrinkView dView = new DrinkView(MyModele);
            dView.Show();
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e) {
            if (File.Exists("myModelData.xml")) {
                MyModele.Serialize();
            }
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e) {
            UserDataView udView = new UserDataView(MyModele, false);
            udView.ShowDialog();
        }

        public Bitmap PaintGraph(int width, int height) {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            List<Point> lstPt = new List<Point>();

            for (int i = 0; i < MyModele.ListARTT.Count; i++) {
                double x = width - (width / 50) * i;
                double y = (height / 100) * MyModele.TauxAlcoolemie * 100;

                lstPt.Add(new Point((int)x, (int)y));
            }

            g.DrawLines(Pens.Black, lstPt.ToArray());
            return bmp;
        }
    }
}
