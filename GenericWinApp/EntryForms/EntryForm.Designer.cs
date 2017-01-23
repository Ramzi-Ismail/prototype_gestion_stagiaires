namespace App.WinForm
{
    partial class EntryForm
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
            this.groupBoxListChoix = new System.Windows.Forms.GroupBox();
            this.tabControlManytoMany = new System.Windows.Forms.TabControl();
            this.splitContainerFormulaire = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxListChoix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFormulaire)).BeginInit();
            this.splitContainerFormulaire.Panel2.SuspendLayout();
            this.splitContainerFormulaire.SuspendLayout();
            this.SuspendLayout();
            // 
            // btEnregistrer
            // 
            this.btEnregistrer.Location = new System.Drawing.Point(10, 14);
            this.btEnregistrer.Click += new System.EventHandler(this.btEnregistrer_Click);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerFormulaire);
            this.splitContainer1.Size = new System.Drawing.Size(695, 383);
            this.splitContainer1.SplitterDistance = 336;
            // 
            // groupBoxListChoix
            // 
            this.groupBoxListChoix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxListChoix.Controls.Add(this.tabControlManytoMany);
            this.groupBoxListChoix.Location = new System.Drawing.Point(3, 15);
            this.groupBoxListChoix.Name = "groupBoxListChoix";
            this.groupBoxListChoix.Size = new System.Drawing.Size(184, 311);
            this.groupBoxListChoix.TabIndex = 4;
            this.groupBoxListChoix.TabStop = false;
            this.groupBoxListChoix.Text = "Liste de choix";
            // 
            // tabControlManytoMany
            // 
            this.tabControlManytoMany.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlManytoMany.Location = new System.Drawing.Point(6, 19);
            this.tabControlManytoMany.Name = "tabControlManytoMany";
            this.tabControlManytoMany.SelectedIndex = 0;
            this.tabControlManytoMany.Size = new System.Drawing.Size(172, 286);
            this.tabControlManytoMany.TabIndex = 0;
            // 
            // splitContainerFormulaire
            // 
            this.splitContainerFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFormulaire.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFormulaire.Name = "splitContainerFormulaire";
            // 
            // splitContainerFormulaire.Panel2
            // 
            this.splitContainerFormulaire.Panel2.Controls.Add(this.groupBoxListChoix);
            this.splitContainerFormulaire.Size = new System.Drawing.Size(695, 336);
            this.splitContainerFormulaire.SplitterDistance = 501;
            this.splitContainerFormulaire.TabIndex = 5;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "EntryForm";
            this.Size = new System.Drawing.Size(695, 383);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxListChoix.ResumeLayout(false);
            this.splitContainerFormulaire.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFormulaire)).EndInit();
            this.splitContainerFormulaire.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxListChoix;
        private System.Windows.Forms.TabControl tabControlManytoMany;
        private System.Windows.Forms.SplitContainer splitContainerFormulaire;
    }
}
