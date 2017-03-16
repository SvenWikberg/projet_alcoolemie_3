using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

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
                UserDataView udView = new UserDataView(MyModele);
                udView.ShowDialog();
            }
        }

        private void MainView_Load(object sender, EventArgs e) {
            UpdateView();
        }

        private void timUpdate_Tick(object sender, EventArgs e) {
            MyModele.CalculerBaisseTauxAlcoolemie();
            UpdateView();
        }

        private void UpdateView() {
            lblAlcohol.Text = String.Format("{0:0.0000}‰", MyModele.TauxAlcoolemie);
        }

        private void btnBoire_Click(object sender, EventArgs e) {
            DrinkView dView = new DrinkView(MyModele);
            dView.Show();
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e) {
            if (File.Exists("myModelData.xml")) {
                //MyModele.Serialize();
            }
        }
    }
}
