namespace App
{
    partial class AnneeFormationFormulaire
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
            System.Windows.Forms.Label dateDebutLabel;
            System.Windows.Forms.Label dateFinLabel;
            System.Windows.Forms.Label titreLabel;
            this.dateDebutDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateFinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.titreTextBox = new System.Windows.Forms.TextBox();
            dateDebutLabel = new System.Windows.Forms.Label();
            dateFinLabel = new System.Windows.Forms.Label();
            titreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(dateDebutLabel);
            this.splitContainer1.Panel1.Controls.Add(this.dateDebutDateTimePicker);
            this.splitContainer1.Panel1.Controls.Add(dateFinLabel);
            this.splitContainer1.Panel1.Controls.Add(this.dateFinDateTimePicker);
            this.splitContainer1.Panel1.Controls.Add(titreLabel);
            this.splitContainer1.Panel1.Controls.Add(this.titreTextBox);
            // 
            // dateDebutLabel
            // 
            dateDebutLabel.AutoSize = true;
            dateDebutLabel.Location = new System.Drawing.Point(23, 62);
            dateDebutLabel.Name = "dateDebutLabel";
            dateDebutLabel.Size = new System.Drawing.Size(65, 13);
            dateDebutLabel.TabIndex = 2;
            dateDebutLabel.Text = "Date Debut:";
            // 
            // dateFinLabel
            // 
            dateFinLabel.AutoSize = true;
            dateFinLabel.Location = new System.Drawing.Point(23, 88);
            dateFinLabel.Name = "dateFinLabel";
            dateFinLabel.Size = new System.Drawing.Size(50, 13);
            dateFinLabel.TabIndex = 4;
            dateFinLabel.Text = "Date Fin:";
            // 
            // titreLabel
            // 
            titreLabel.AutoSize = true;
            titreLabel.Location = new System.Drawing.Point(23, 35);
            titreLabel.Name = "titreLabel";
            titreLabel.Size = new System.Drawing.Size(31, 13);
            titreLabel.TabIndex = 10;
            titreLabel.Text = "Titre:";
            // 
            // dateDebutDateTimePicker
            // 
            this.dateDebutDateTimePicker.Location = new System.Drawing.Point(122, 58);
            this.dateDebutDateTimePicker.Name = "dateDebutDateTimePicker";
            this.dateDebutDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateDebutDateTimePicker.TabIndex = 3;
            this.dateDebutDateTimePicker.ValueChanged += new System.EventHandler(this.dateDebutDateTimePicker_ValueChanged);
            // 
            // dateFinDateTimePicker
            // 
            this.dateFinDateTimePicker.Location = new System.Drawing.Point(122, 84);
            this.dateFinDateTimePicker.Name = "dateFinDateTimePicker";
            this.dateFinDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateFinDateTimePicker.TabIndex = 5;
            this.dateFinDateTimePicker.ValueChanged += new System.EventHandler(this.dateFinDateTimePicker_ValueChanged);
            // 
            // titreTextBox
            // 
            this.titreTextBox.Location = new System.Drawing.Point(122, 32);
            this.titreTextBox.Name = "titreTextBox";
            this.titreTextBox.Size = new System.Drawing.Size(200, 20);
            this.titreTextBox.TabIndex = 11;
            // 
            // AnneeFormationFormulaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "AnneeFormationFormulaire";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDebutDateTimePicker;
        private System.Windows.Forms.DateTimePicker dateFinDateTimePicker;
        private System.Windows.Forms.TextBox titreTextBox;
    }
}
