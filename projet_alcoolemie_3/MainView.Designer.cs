namespace projet_alcoolemie_3 {
    partial class MainView {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAlcohol = new System.Windows.Forms.Label();
            this.timUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnBoire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(22, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(97, 34);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // lblAlcohol
            // 
            this.lblAlcohol.AutoSize = true;
            this.lblAlcohol.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlcohol.Location = new System.Drawing.Point(22, 121);
            this.lblAlcohol.Name = "lblAlcohol";
            this.lblAlcohol.Size = new System.Drawing.Size(105, 40);
            this.lblAlcohol.TabIndex = 1;
            this.lblAlcohol.Text = "label2";
            // 
            // timUpdate
            // 
            this.timUpdate.Interval = 1000;
            this.timUpdate.Tick += new System.EventHandler(this.timUpdate_Tick);
            // 
            // btnBoire
            // 
            this.btnBoire.Location = new System.Drawing.Point(13, 419);
            this.btnBoire.Name = "btnBoire";
            this.btnBoire.Size = new System.Drawing.Size(259, 31);
            this.btnBoire.TabIndex = 2;
            this.btnBoire.Text = "Boire";
            this.btnBoire.UseVisualStyleBackColor = true;
            this.btnBoire.Click += new System.EventHandler(this.btnBoire_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 462);
            this.Controls.Add(this.btnBoire);
            this.Controls.Add(this.lblAlcohol);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainView";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.Load += new System.EventHandler(this.MainView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAlcohol;
        private System.Windows.Forms.Timer timUpdate;
        private System.Windows.Forms.Button btnBoire;
    }
}

