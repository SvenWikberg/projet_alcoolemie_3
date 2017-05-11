using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace projet_alcoolemie_3 {
    public partial class UserDataView : Form {

        public bool IsChanging {
            get {
                return _isChanging;
            }

            set {
                _isChanging = value;
            }
        }
        bool _isChanging;

        private Modele MyModele {
            get {
                return _myModele;
            }

            set {
                _myModele = value;
            }
        }
        Modele _myModele;

        public UserDataView(Modele myModele, bool isChanging) {
            InitializeComponent();

            MyModele = myModele;
            IsChanging = isChanging;
        }

        private void UserDataView_Load(object sender, EventArgs e) {
            UpdateView();
            cbxSexe.SelectedIndex = 0;
        }

        private void UpdateView() {
            if (IsChanging) {
                btnEdit.Hide();
                btnClose.Hide();
                btnSave.Show();
                tbxUsername.Show();
                cbxSexe.Show();
                nudPoids.Show();
                lblUsername.Text = "Username : ";
                lblSexe.Text = "Sexe : ";
                lblPoids.Text = "Poids : ";

                if (File.Exists("myModelData.xml")) {
                    tbxUsername.Text = MyModele.Username;
                    nudPoids.Value = MyModele.Poids;
                }
            }
            else {
                btnEdit.Show();
                btnClose.Show();
                btnSave.Hide();
                tbxUsername.Hide();
                cbxSexe.Hide();
                nudPoids.Hide();
                lblUsername.Text = "Username : " + MyModele.Username;
                lblSexe.Text = "Sexe : " + (MyModele.EstHomme ? "Homme" : "Femme");
                lblPoids.Text = "Poids : " + MyModele.Poids.ToString() + " kg";
            }
        }

        private void tbxUsername_TextChanged(object sender, EventArgs e) {
            if (tbxUsername.Text == String.Empty) {
                btnSave.Enabled = false;
            }
            else {
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!File.Exists("myModelData.xml")) {
                MyModele.TauxAlcoolemie = 0;
                MyModele.DernierCalculTauxAlcoolemie = DateTime.Now;
            }
            MyModele.Username = tbxUsername.Text;
            MyModele.EstHomme = (cbxSexe.SelectedIndex == 0 ? true : false);
            MyModele.Poids = (int)nudPoids.Value;


            MyModele.Serialize();
            FileStream fs = new FileStream("myModelData.xml", FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(Modele));
            MyModele = (Modele)xs.Deserialize(fs);
            fs.Close();

            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            IsChanging = true;
            UpdateView();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

