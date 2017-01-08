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
            this.SuspendLayout();
            // 
            // formulaire
            // 
            this.formulaire.Location = new System.Drawing.Point(5, 69);
            this.formulaire.Name = "formulaire";
            this.formulaire.Size = new System.Drawing.Size(617, 222);
            this.formulaire.TabIndex = 3;
            this.formulaire.TabStop = false;
            this.formulaire.Text = "Formulaire";
            // 
            // FormulaireControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.formulaire);
            this.Name = "FormulaireControle";
            this.Controls.SetChildIndex(this.formulaire, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox formulaire;
    }
}
