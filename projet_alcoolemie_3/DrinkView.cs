/*
 * Sven Wikberg
 * 30 mars 2016
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet_alcoolemie_3 {
    public partial class DrinkView : Form {
        public Modele MyModele {
            get {
                return _myModele;
            }

            set {
                _myModele = value;
            }
        }
        Modele _myModele;

        public DrinkView(Modele myModele) {
            InitializeComponent();

            MyModele = myModele;
        }

        private void DrinkView_Load(object sender, EventArgs e) {
            cbxBoissons.DataSource = MyModele.Boissons;
        }

        private void btnConfimer_Click(object sender, EventArgs e) {
            for (int i = 0; i < nudBoissons.Value; i++) {
                MyModele.BoireUneBoisson((Boisson)cbxBoissons.SelectedItem);
            }
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e) {
            this.Close();

        }
    }
}
