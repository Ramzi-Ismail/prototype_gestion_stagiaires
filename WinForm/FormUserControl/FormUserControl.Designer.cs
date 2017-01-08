namespace App.WinForm
{
    partial class FormUserControl
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
            this.btEnregistrer = new System.Windows.Forms.Button();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btEnregistrer
            // 
            this.btEnregistrer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btEnregistrer.Location = new System.Drawing.Point(2, 3);
            this.btEnregistrer.Name = "btEnregistrer";
            this.btEnregistrer.Size = new System.Drawing.Size(75, 23);
            this.btEnregistrer.TabIndex = 0;
            this.btEnregistrer.Text = "Enregistrer";
            this.btEnregistrer.UseVisualStyleBackColor = true;
            this.btEnregistrer.Click += new System.EventHandler(this.btEnregistrer_Click);
            // 
            // btAnnuler
            // 
            this.btAnnuler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btAnnuler.Location = new System.Drawing.Point(83, 3);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btAnnuler.TabIndex = 1;
            this.btAnnuler.Text = "Annuler";
            this.btAnnuler.UseVisualStyleBackColor = true;
            this.btAnnuler.Click += new System.EventHandler(this.btAnnuler_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btEnregistrer);
            this.panel1.Controls.Add(this.btAnnuler);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 37);
            this.panel1.TabIndex = 2;
            // 
            // FormUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FormUserControl";
            this.Size = new System.Drawing.Size(647, 374);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btEnregistrer;
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Panel panel1;
    }
}
