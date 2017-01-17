namespace App.WinForm.EntityManagement
{
    partial class BaseFilterControl
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
            this.groupBoxFiltrage = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBoxFiltrage
            // 
            this.groupBoxFiltrage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFiltrage.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFiltrage.Name = "groupBoxFiltrage";
            this.groupBoxFiltrage.Size = new System.Drawing.Size(815, 199);
            this.groupBoxFiltrage.TabIndex = 14;
            this.groupBoxFiltrage.TabStop = false;
            this.groupBoxFiltrage.Text = "Filtre";
            // 
            // BaseFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxFiltrage);
            this.Name = "BaseFilterControl";
            this.Size = new System.Drawing.Size(815, 199);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBoxFiltrage;
    }
}
