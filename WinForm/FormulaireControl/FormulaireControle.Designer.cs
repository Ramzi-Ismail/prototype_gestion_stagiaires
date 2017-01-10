namespace App.WinForm
{
    partial class FormulaireControle
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
            this.formulaire = new System.Windows.Forms.GroupBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.formulaire);
            this.splitContainer1.Size = new System.Drawing.Size(695, 383);
            this.splitContainer1.SplitterDistance = 321;
            // 
            // formulaire
            // 
            this.formulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formulaire.Location = new System.Drawing.Point(0, 0);
            this.formulaire.Margin = new System.Windows.Forms.Padding(10);
            this.formulaire.Name = "formulaire";
            this.formulaire.Padding = new System.Windows.Forms.Padding(10);
            this.formulaire.Size = new System.Drawing.Size(695, 321);
            this.formulaire.TabIndex = 3;
            this.formulaire.TabStop = false;
            this.formulaire.Text = "Formulaire";
            // 
            // FormulaireControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FormulaireControle";
            this.Size = new System.Drawing.Size(695, 383);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox formulaire;
    }
}
