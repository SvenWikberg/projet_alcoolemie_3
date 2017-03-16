using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace projet_alcoolemie_3 {
    public partial class UserDataView : Form {

        public Modele MyModele {
            get {
                return _myModele;
            }

            set {
                _myModele = value;
            }
        }
        Modele _myModele;

        public UserDataView(Modele myModele) {
            InitializeComponent();

            MyModele = myModele;
        }

        private void UserDataView_Load(object sender, EventArgs e) {
            cbxSexe.SelectedIndex = 0;
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


            MyModele.Serialize(); //////


            this.Close();
        }
    }
}
