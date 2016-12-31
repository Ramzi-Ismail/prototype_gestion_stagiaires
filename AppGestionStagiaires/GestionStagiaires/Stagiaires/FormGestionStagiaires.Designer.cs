namespace Cplus
{
    partial class FormGestionStagiaires
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
            this.bt_Ajouter = new System.Windows.Forms.Button();
            this.tabControlStagiaires = new System.Windows.Forms.TabControl();
            this.tabPageStagiaires = new System.Windows.Forms.TabPage();
            this.gridStagiaire = new Cplus.GestionStagiaires.GridStagiaireUC();
            this.tabControlStagiaires.SuspendLayout();
            this.tabPageStagiaires.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Ajouter
            // 
            this.bt_Ajouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Ajouter.Location = new System.Drawing.Point(888, 12);
            this.bt_Ajouter.Name = "bt_Ajouter";
            this.bt_Ajouter.Size = new System.Drawing.Size(120, 23);
            this.bt_Ajouter.TabIndex = 11;
            this.bt_Ajouter.Text = "Ajouter un stagiaire";
            this.bt_Ajouter.UseVisualStyleBackColor = true;
            this.bt_Ajouter.Click += new System.EventHandler(this.bt_Ajouter_Click);
            // 
            // tabControlStagiaires
            // 
            this.tabControlStagiaires.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlStagiaires.Controls.Add(this.tabPageStagiaires);
            this.tabControlStagiaires.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlStagiaires.HotTrack = true;
            this.tabControlStagiaires.ItemSize = new System.Drawing.Size(60, 18);
            this.tabControlStagiaires.Location = new System.Drawing.Point(9, 48);
            this.tabControlStagiaires.Margin = new System.Windows.Forms.Padding(10);
            this.tabControlStagiaires.Name = "tabControlStagiaires";
            this.tabControlStagiaires.SelectedIndex = 0;
            this.tabControlStagiaires.ShowToolTips = true;
            this.tabControlStagiaires.Size = new System.Drawing.Size(999, 423);
            this.tabControlStagiaires.TabIndex = 12;
            // 
            // tabPageStagiaires
            // 
            this.tabPageStagiaires.AutoScroll = true;
            this.tabPageStagiaires.Controls.Add(this.gridStagiaire);
            this.tabPageStagiaires.Location = new System.Drawing.Point(4, 22);
            this.tabPageStagiaires.Name = "tabPageStagiaires";
            this.tabPageStagiaires.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStagiaires.Size = new System.Drawing.Size(991, 397);
            this.tabPageStagiaires.TabIndex = 0;
            this.tabPageStagiaires.Text = "Stagiaires";
            this.tabPageStagiaires.UseVisualStyleBackColor = true;
            // 
            // gridStagiaire
            // 
            this.gridStagiaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStagiaire.Location = new System.Drawing.Point(3, 3);
            this.gridStagiaire.Name = "gridStagiaire";
            this.gridStagiaire.Size = new System.Drawing.Size(985, 391);
            this.gridStagiaire.TabIndex = 0;
            this.gridStagiaire.Load += new System.EventHandler(this.gridStagiaire_Load);
            // 
            // FormGestionStagiaires
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 490);
            this.Controls.Add(this.tabControlStagiaires);
            this.Controls.Add(this.bt_Ajouter);
            this.Name = "FormGestionStagiaires";
            this.Text = "Gestion des stagiaires";
            this.Load += new System.EventHandler(this.FormGestionStagiaires_Load);
            this.Resize += new System.EventHandler(this.FormGestionStagiaires_Resize);
            this.tabControlStagiaires.ResumeLayout(false);
            this.tabPageStagiaires.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_Ajouter;
        private System.Windows.Forms.TabControl tabControlStagiaires;
        private System.Windows.Forms.TabPage tabPageStagiaires;
        private GestionStagiaires.GridStagiaireUC gridStagiaire;
    }
}

