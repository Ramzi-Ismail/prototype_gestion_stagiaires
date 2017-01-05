namespace App.GestionStagiaires.Formateurs
{
    partial class FormateurFormUC
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label cinLabel;
            System.Windows.Forms.Label dateNaissanceLabel;
            System.Windows.Forms.Label nomLabel;
            System.Windows.Forms.Label prenomLabel;
            System.Windows.Forms.Label adressLabel;
            System.Windows.Forms.Label telephoneLabel;
            System.Windows.Forms.Label emailLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonFamme = new System.Windows.Forms.RadioButton();
            this.radioButtonHomme = new System.Windows.Forms.RadioButton();
            this.cinTextBox = new System.Windows.Forms.TextBox();
            this.dateNaissanceDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.prenomTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.adressTextBox = new System.Windows.Forms.TextBox();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_password2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Combo_Filiere = new System.Windows.Forms.ComboBox();
            this.filiereBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            cinLabel = new System.Windows.Forms.Label();
            dateNaissanceLabel = new System.Windows.Forms.Label();
            nomLabel = new System.Windows.Forms.Label();
            prenomLabel = new System.Windows.Forms.Label();
            adressLabel = new System.Windows.Forms.Label();
            telephoneLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filiereBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cinLabel
            // 
            cinLabel.AutoSize = true;
            cinLabel.Location = new System.Drawing.Point(6, 85);
            cinLabel.Name = "cinLabel";
            cinLabel.Size = new System.Drawing.Size(25, 13);
            cinLabel.TabIndex = 10;
            cinLabel.Text = "Cin:";
            // 
            // dateNaissanceLabel
            // 
            dateNaissanceLabel.AutoSize = true;
            dateNaissanceLabel.Location = new System.Drawing.Point(6, 112);
            dateNaissanceLabel.Name = "dateNaissanceLabel";
            dateNaissanceLabel.Size = new System.Drawing.Size(86, 13);
            dateNaissanceLabel.TabIndex = 12;
            dateNaissanceLabel.Text = "Date Naissance:";
            // 
            // nomLabel
            // 
            nomLabel.AutoSize = true;
            nomLabel.Location = new System.Drawing.Point(6, 30);
            nomLabel.Name = "nomLabel";
            nomLabel.Size = new System.Drawing.Size(32, 13);
            nomLabel.TabIndex = 20;
            nomLabel.Text = "Nom:";
            // 
            // prenomLabel
            // 
            prenomLabel.AutoSize = true;
            prenomLabel.Location = new System.Drawing.Point(6, 56);
            prenomLabel.Name = "prenomLabel";
            prenomLabel.Size = new System.Drawing.Size(46, 13);
            prenomLabel.TabIndex = 22;
            prenomLabel.Text = "Prenom:";
            // 
            // adressLabel
            // 
            adressLabel.AutoSize = true;
            adressLabel.Location = new System.Drawing.Point(6, 83);
            adressLabel.Name = "adressLabel";
            adressLabel.Size = new System.Drawing.Size(42, 13);
            adressLabel.TabIndex = 8;
            adressLabel.Text = "Adress:";
            // 
            // telephoneLabel
            // 
            telephoneLabel.AutoSize = true;
            telephoneLabel.Location = new System.Drawing.Point(6, 31);
            telephoneLabel.Name = "telephoneLabel";
            telephoneLabel.Size = new System.Drawing.Size(61, 13);
            telephoneLabel.TabIndex = 28;
            telephoneLabel.Text = "Telephone:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(6, 57);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 14;
            emailLabel.Text = "Email:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(cinLabel);
            this.groupBox1.Controls.Add(this.cinTextBox);
            this.groupBox1.Controls.Add(dateNaissanceLabel);
            this.groupBox1.Controls.Add(this.dateNaissanceDateTimePicker);
            this.groupBox1.Controls.Add(nomLabel);
            this.groupBox1.Controls.Add(this.nomTextBox);
            this.groupBox1.Controls.Add(prenomLabel);
            this.groupBox1.Controls.Add(this.prenomTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 214);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Etat civil";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonFamme);
            this.groupBox4.Controls.Add(this.radioButtonHomme);
            this.groupBox4.Location = new System.Drawing.Point(98, 138);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 54);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sexe";
            // 
            // radioButtonFamme
            // 
            this.radioButtonFamme.AutoSize = true;
            this.radioButtonFamme.Location = new System.Drawing.Point(73, 19);
            this.radioButtonFamme.Name = "radioButtonFamme";
            this.radioButtonFamme.Size = new System.Drawing.Size(59, 17);
            this.radioButtonFamme.TabIndex = 31;
            this.radioButtonFamme.TabStop = true;
            this.radioButtonFamme.Text = "Femme";
            this.radioButtonFamme.UseVisualStyleBackColor = true;
            // 
            // radioButtonHomme
            // 
            this.radioButtonHomme.AutoSize = true;
            this.radioButtonHomme.Location = new System.Drawing.Point(6, 19);
            this.radioButtonHomme.Name = "radioButtonHomme";
            this.radioButtonHomme.Size = new System.Drawing.Size(61, 17);
            this.radioButtonHomme.TabIndex = 30;
            this.radioButtonHomme.TabStop = true;
            this.radioButtonHomme.Text = "Homme";
            this.radioButtonHomme.UseVisualStyleBackColor = true;
            // 
            // cinTextBox
            // 
            this.cinTextBox.Location = new System.Drawing.Point(98, 82);
            this.cinTextBox.Name = "cinTextBox";
            this.cinTextBox.Size = new System.Drawing.Size(200, 20);
            this.cinTextBox.TabIndex = 11;
            // 
            // dateNaissanceDateTimePicker
            // 
            this.dateNaissanceDateTimePicker.Location = new System.Drawing.Point(98, 108);
            this.dateNaissanceDateTimePicker.Name = "dateNaissanceDateTimePicker";
            this.dateNaissanceDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateNaissanceDateTimePicker.TabIndex = 13;
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(98, 27);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(200, 20);
            this.nomTextBox.TabIndex = 21;
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.Location = new System.Drawing.Point(98, 53);
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.Size = new System.Drawing.Size(200, 20);
            this.prenomTextBox.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(adressLabel);
            this.groupBox3.Controls.Add(telephoneLabel);
            this.groupBox3.Controls.Add(this.adressTextBox);
            this.groupBox3.Controls.Add(this.telephoneTextBox);
            this.groupBox3.Controls.Add(this.emailTextBox);
            this.groupBox3.Controls.Add(emailLabel);
            this.groupBox3.Location = new System.Drawing.Point(331, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 234);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Coordonnées";
            // 
            // adressTextBox
            // 
            this.adressTextBox.Location = new System.Drawing.Point(98, 80);
            this.adressTextBox.Multiline = true;
            this.adressTextBox.Name = "adressTextBox";
            this.adressTextBox.Size = new System.Drawing.Size(200, 148);
            this.adressTextBox.TabIndex = 9;
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.Location = new System.Drawing.Point(98, 28);
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(200, 20);
            this.telephoneTextBox.TabIndex = 29;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(98, 54);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 20);
            this.emailTextBox.TabIndex = 15;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txt_password2);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txt_password);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txt_login);
            this.groupBox5.Location = new System.Drawing.Point(3, 267);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(325, 157);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Votre Identité";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Répéter le mot de passe";
            // 
            // txt_password2
            // 
            this.txt_password2.Location = new System.Drawing.Point(134, 88);
            this.txt_password2.Name = "txt_password2";
            this.txt_password2.Size = new System.Drawing.Size(164, 20);
            this.txt_password2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Login";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(134, 62);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(164, 20);
            this.txt_password.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mot de passe";
            // 
            // txt_login
            // 
            this.txt_login.Location = new System.Drawing.Point(134, 25);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(164, 20);
            this.txt_login.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Combo_Filiere);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(340, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 112);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Affectations";
            // 
            // Combo_Filiere
            // 
            this.Combo_Filiere.DataSource = this.filiereBindingSource;
            this.Combo_Filiere.DisplayMember = "Code";
            this.Combo_Filiere.FormattingEnabled = true;
            this.Combo_Filiere.Location = new System.Drawing.Point(89, 26);
            this.Combo_Filiere.Name = "Combo_Filiere";
            this.Combo_Filiere.Size = new System.Drawing.Size(200, 21);
            this.Combo_Filiere.TabIndex = 30;
            this.Combo_Filiere.ValueMember = "Id";
            // 
            // filiereBindingSource
            // 
            this.filiereBindingSource.DataSource = typeof(App.Entites.Filiere);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Filiere";
            // 
            // FormateurFormUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormateurFormUC";
            this.Size = new System.Drawing.Size(693, 425);
            this.Load += new System.EventHandler(this.FormateurFormUC_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filiereBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonFamme;
        private System.Windows.Forms.RadioButton radioButtonHomme;
        private System.Windows.Forms.TextBox cinTextBox;
        private System.Windows.Forms.DateTimePicker dateNaissanceDateTimePicker;
        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.TextBox prenomTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox adressTextBox;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_password2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox Combo_Filiere;
        private System.Windows.Forms.BindingSource filiereBindingSource;
        private System.Windows.Forms.Label label1;
    }
}
