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
    public partial class DrinkDataView : Form {
        public Modele MyModele {
            get {
                return _myModele;
            }

            set {
                _myModele = value;
            }
        }
        Modele _myModele;

        public DrinkDataView(Modele myModele) {
            InitializeComponent();

            MyModele = myModele;
        }

        private void DrinkDataView_Load(object sender, EventArgs e) {
            btnAdd.Enabled = false;
            btnComfirmEdit.Hide();

            UpdateView();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            MyModele.Boissons.RemoveAt(lbxBoissons.SelectedIndex);
            UpdateView();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            MyModele.Boissons.Add(new Boisson(tbxName.Text, (double)nudQuantity.Value, (double)nudDegree.Value));
            UpdateView();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            btnComfirmEdit.Show();
            btnAdd.Hide();
            lbxBoissons.Enabled = false;
            btnDelete.Enabled = false;

            tbxName.Text = MyModele.Boissons[lbxBoissons.SelectedIndex].Nom;
            nudQuantity.Value = (int)MyModele.Boissons[lbxBoissons.SelectedIndex].Quantite;
            nudDegree.Value = (int)MyModele.Boissons[lbxBoissons.SelectedIndex].Degre;
        }

        private void tbxName_TextChanged(object sender, EventArgs e) {
            btnAdd.Enabled = (tbxName.Text != "");
            btnComfirmEdit.Enabled = (tbxName.Text != "");
        }

        public void UpdateView() {
            lbxBoissons.DataSource = null;
            lbxBoissons.DataSource = MyModele.Boissons;
        }

        private void btnComfirmEdit_Click(object sender, EventArgs e) {
            btnComfirmEdit.Hide();
            btnAdd.Show();
            lbxBoissons.Enabled = true;
            btnDelete.Enabled = true;

            MyModele.Boissons[lbxBoissons.SelectedIndex].Nom = tbxName.Text;
            MyModele.Boissons[lbxBoissons.SelectedIndex].Quantite = (double)nudQuantity.Value;
            MyModele.Boissons[lbxBoissons.SelectedIndex].Degre = (double)nudDegree.Value;

            tbxName.Text = "";
            nudQuantity.Value = 200;
            nudDegree.Value = 0;

            UpdateView();
        }
    }
}
