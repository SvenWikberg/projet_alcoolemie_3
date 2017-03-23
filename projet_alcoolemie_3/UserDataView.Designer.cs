namespace projet_alcoolemie_3 {
    partial class UserDataView {
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
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSexe = new System.Windows.Forms.Label();
            this.lblPoids = new System.Windows.Forms.Label();
            this.cbxSexe = new System.Windows.Forms.ComboBox();
            this.nudPoids = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoids)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(12, 28);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(260, 20);
            this.tbxUsername.TabIndex = 0;
            this.tbxUsername.TextChanged += new System.EventHandler(this.tbxUsername_TextChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(61, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username :";
            // 
            // lblSexe
            // 
            this.lblSexe.AutoSize = true;
            this.lblSexe.Location = new System.Drawing.Point(9, 71);
            this.lblSexe.Name = "lblSexe";
            this.lblSexe.Size = new System.Drawing.Size(37, 13);
            this.lblSexe.TabIndex = 2;
            this.lblSexe.Text = "Sexe :";
            // 
            // lblPoids
            // 
            this.lblPoids.AutoSize = true;
            this.lblPoids.Location = new System.Drawing.Point(7, 98);
            this.lblPoids.Name = "lblPoids";
            this.lblPoids.Size = new System.Drawing.Size(39, 13);
            this.lblPoids.TabIndex = 3;
            this.lblPoids.Text = "Poids :";
            // 
            // cbxSexe
            // 
            this.cbxSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSexe.FormattingEnabled = true;
            this.cbxSexe.Items.AddRange(new object[] {
            "Homme",
            "Femme"});
            this.cbxSexe.Location = new System.Drawing.Point(52, 68);
            this.cbxSexe.Name = "cbxSexe";
            this.cbxSexe.Size = new System.Drawing.Size(220, 21);
            this.cbxSexe.TabIndex = 4;
            // 
            // nudPoids
            // 
            this.nudPoids.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPoids.Location = new System.Drawing.Point(52, 96);
            this.nudPoids.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudPoids.Name = "nudPoids";
            this.nudPoids.Size = new System.Drawing.Size(220, 20);
            this.nudPoids.TabIndex = 5;
            this.nudPoids.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(15, 409);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(257, 41);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(143, 408);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 41);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Fermer";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(15, 408);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(129, 41);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Modifier";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // UserDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 462);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nudPoids);
            this.Controls.Add(this.cbxSexe);
            this.Controls.Add(this.lblPoids);
            this.Controls.Add(this.lblSexe);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.tbxUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserDataView";
            this.Text = "UserDataView";
            this.Load += new System.EventHandler(this.UserDataView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPoids)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblSexe;
        private System.Windows.Forms.Label lblPoids;
        private System.Windows.Forms.ComboBox cbxSexe;
        private System.Windows.Forms.NumericUpDown nudPoids;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
    }
}