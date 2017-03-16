namespace projet_alcoolemie_3 {
    partial class DrinkView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cbxBoissons = new System.Windows.Forms.ComboBox();
            this.nudBoissons = new System.Windows.Forms.NumericUpDown();
            this.btnConfimer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoissons)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxBoissons
            // 
            this.cbxBoissons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBoissons.FormattingEnabled = true;
            this.cbxBoissons.Location = new System.Drawing.Point(12, 12);
            this.cbxBoissons.Name = "cbxBoissons";
            this.cbxBoissons.Size = new System.Drawing.Size(259, 21);
            this.cbxBoissons.TabIndex = 0;
            // 
            // nudBoissons
            // 
            this.nudBoissons.Location = new System.Drawing.Point(13, 142);
            this.nudBoissons.Name = "nudBoissons";
            this.nudBoissons.Size = new System.Drawing.Size(259, 20);
            this.nudBoissons.TabIndex = 1;
            this.nudBoissons.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnConfimer
            // 
            this.btnConfimer.Location = new System.Drawing.Point(12, 402);
            this.btnConfimer.Name = "btnConfimer";
            this.btnConfimer.Size = new System.Drawing.Size(105, 48);
            this.btnConfimer.TabIndex = 2;
            this.btnConfimer.Text = "Confirmer";
            this.btnConfimer.UseVisualStyleBackColor = true;
            this.btnConfimer.Click += new System.EventHandler(this.btnConfimer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(167, 402);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(105, 48);
            this.btnAnnuler.TabIndex = 3;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // DrinkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 462);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnConfimer);
            this.Controls.Add(this.nudBoissons);
            this.Controls.Add(this.cbxBoissons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DrinkView";
            this.Text = "DrinkView";
            this.Load += new System.EventHandler(this.DrinkView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBoissons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxBoissons;
        private System.Windows.Forms.NumericUpDown nudBoissons;
        private System.Windows.Forms.Button btnConfimer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}