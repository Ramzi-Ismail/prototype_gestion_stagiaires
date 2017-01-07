namespace App.GestionStagiaires.Groupes
{
    partial class UserControlGroupeForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nomLabel;
            System.Windows.Forms.Label label1;
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.comboBoxFiliere = new System.Windows.Forms.ComboBox();
            this.filiereBindingSource = new System.Windows.Forms.BindingSource(this.components);
            nomLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.filiereBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nomLabel
            // 
            nomLabel.AutoSize = true;
            nomLabel.Location = new System.Drawing.Point(11, 46);
            nomLabel.Name = "nomLabel";
            nomLabel.Size = new System.Drawing.Size(32, 13);
            nomLabel.TabIndex = 7;
            nomLabel.Text = "Nom:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 81);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 13);
            label1.TabIndex = 9;
            label1.Text = "Filiere :";
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(63, 46);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(200, 20);
            this.nomTextBox.TabIndex = 8;
            // 
            // comboBoxFiliere
            // 
            this.comboBoxFiliere.DataSource = this.filiereBindingSource;
            this.comboBoxFiliere.DisplayMember = "Code";
            this.comboBoxFiliere.FormattingEnabled = true;
            this.comboBoxFiliere.Location = new System.Drawing.Point(63, 81);
            this.comboBoxFiliere.Name = "comboBoxFiliere";
            this.comboBoxFiliere.Size = new System.Drawing.Size(200, 21);
            this.comboBoxFiliere.TabIndex = 10;
            this.comboBoxFiliere.ValueMember = "Id";
            // 
            // filiereBindingSource
            // 
            this.filiereBindingSource.DataSource = typeof(App.GestionStagiaires.Filiere);
            // 
            // UserControlGroupeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.comboBoxFiliere);
            this.Controls.Add(label1);
            this.Controls.Add(nomLabel);
            this.Controls.Add(this.nomTextBox);
            this.Name = "UserControlGroupeForm";
            this.Size = new System.Drawing.Size(358, 144);
            this.Load += new System.EventHandler(this.UserControlGroupeForm_Load);
            this.Controls.SetChildIndex(this.nomTextBox, 0);
            this.Controls.SetChildIndex(nomLabel, 0);
            this.Controls.SetChildIndex(label1, 0);
            this.Controls.SetChildIndex(this.comboBoxFiliere, 0);
            ((System.ComponentModel.ISupportInitialize)(this.filiereBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.ComboBox comboBoxFiliere;
        private System.Windows.Forms.BindingSource filiereBindingSource;
    }
}
