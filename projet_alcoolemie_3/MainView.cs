/*
 * Sven Wikberg
 * 30 mars 2016
 * 
 * 
 */
using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;
using System.Collections.Generic;

namespace projet_alcoolemie_3 {
    public partial class MainView : Form {

        int cmptGC = 0;
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
            timUpdate.Interval = 17; //temps reel = 1000
            UpdateView();
        }

        private void timUpdate_Tick(object sender, EventArgs e) { 
            MyModele.CalculerBaisseTauxAlcoolemie();
            MyModele.AddARTT();

            UpdateView();

            if (cmptGC >= 60) {
                System.GC.Collect();
                cmptGC = 0;
            }
            cmptGC++;
        }

        private void UpdateView() {
            pbxGraph.Image = PaintGraph(pbxGraph.Width, pbxGraph.Height);

            lblAlcohol.Text = String.Format("{0:0.0000}‰", MyModele.TauxAlcoolemie);
            lblName.Text = String.Format("{0}", MyModele.Username);

            int tmpTimeToDrive = MyModele.GetTimeToRate(MyModele.GET_ALCOHOL_DRIVING_MAX_CH);
            if (tmpTimeToDrive > 0) {
                if (tmpTimeToDrive / 3600 > 0) {
                    lblDrive.Text = String.Format("Vous pourrez couduire dans {0} heures, {1} minutes et {2} secondes",
                        tmpTimeToDrive / 3600,
                        (tmpTimeToDrive % 3600) / 60,
                        tmpTimeToDrive % 60);
                }
                else if (tmpTimeToDrive / 60 > 0) {
                    lblDrive.Text = String.Format("Vous pourrez couduire dans {0} minutes et {1} secondes",
                        tmpTimeToDrive / 60,
                        tmpTimeToDrive % 60);
                }
                else {
                    lblDrive.Text = String.Format("Vous pourrez couduire dans {0} secondes", tmpTimeToDrive);
                }
            }
            else {
                lblDrive.Text = "Vous pouvez conduire";
            }

            int tmpTimeToSober = MyModele.GetTimeToRate(0);
            if (tmpTimeToSober > 0) {
                if (tmpTimeToSober / 3600 > 0) {
                    lblSober.Text = String.Format("Vous serez sobre dans {0} heures, {1} minutes et {2} secondes",
                        tmpTimeToSober / 3600,
                        (tmpTimeToSober % 3600) / 60,
                        tmpTimeToSober % 60);
                }
                else if (tmpTimeToSober / 60 > 0) {
                    lblSober.Text = String.Format("Vous serez sobre dans {0} minutes et {1} secondes",
                        tmpTimeToSober / 60,
                        tmpTimeToSober % 60);
                }
                else {
                    lblSober.Text = String.Format("Vous serez sobre dans {0} secondes",
                        tmpTimeToSober);
                }
            }
            else {
                lblSober.Text = "Vous êtes sobre";
            }
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
            List<Rectangle> gapRectList = new List<Rectangle>();

            double rowWidth = (double)width / MyModele.ListARTT.Count;
            double maxRate = 2;

            for (int i = 0; i < MyModele.ListARTT.Count; i++) {
                double x = width - rowWidth * i;
                double y = (1 - (MyModele.ListARTT[MyModele.ListARTT.Count - (i + 1)].AlcoholRate / maxRate)) * height;

                lstPt.Add(new Point((int)x, (int)y));
                if (!MyModele.ListARTT[MyModele.ListARTT.Count - (i + 1)].NormalTimeGap) {
                    //g.DrawLine(Pens.Red, new Point((int)x, 0), new Point((int)x, height));
                    gapRectList.Add(new Rectangle((int)(x) - (int)rowWidth - 1, 0, rowWidth < 2 ?  2 : (int)rowWidth, height));
                }
            }


            g.DrawLines(Pens.Black, lstPt.ToArray());
            g.DrawLine(Pens.Blue, new Point(0, height - (int)(MyModele.GET_ALCOHOL_DRIVING_MAX_CH / maxRate * height)), new Point(width, height - (int)(MyModele.GET_ALCOHOL_DRIVING_MAX_CH / maxRate * height)));
            if (gapRectList.Count > 0) {
                g.FillRectangles(Brushes.Red, gapRectList.ToArray());
            }
            return bmp;
        }

        private void gérerLesBoissonsToolStripMenuItem_Click(object sender, EventArgs e) {
            DrinkDataView ddView = new DrinkDataView(MyModele);
            ddView.Show();
        }
    }
}
