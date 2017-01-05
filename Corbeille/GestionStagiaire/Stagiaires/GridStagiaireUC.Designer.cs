namespace App.GestionStagiaires
{
    partial class GridStagiaireUC
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
            this.dataGridViewStagiaires = new System.Windows.Forms.DataGridView();
            this.stagiaireBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Editer = new System.Windows.Forms.DataGridViewImageColumn();
            this.nomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prenomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateNaissanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supprimer = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStagiaires)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stagiaireBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStagiaires
            // 
            this.dataGridViewStagiaires.AllowUserToAddRows = false;
            this.dataGridViewStagiaires.AllowUserToDeleteRows = false;
            this.dataGridViewStagiaires.AutoGenerateColumns = false;
            this.dataGridViewStagiaires.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStagiaires.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editer,
            this.nomDataGridViewTextBoxColumn,
            this.prenomDataGridViewTextBoxColumn,
            this.dateNaissanceDataGridViewTextBoxColumn,
            this.groupeDataGridViewTextBoxColumn,
            this.Supprimer});
            this.dataGridViewStagiaires.DataSource = this.stagiaireBindingSource;
            this.dataGridViewStagiaires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStagiaires.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStagiaires.Name = "dataGridViewStagiaires";
            this.dataGridViewStagiaires.ReadOnly = true;
            this.dataGridViewStagiaires.Size = new System.Drawing.Size(833, 398);
            this.dataGridViewStagiaires.TabIndex = 9;
            this.dataGridViewStagiaires.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStagiaires_CellClick);
            this.dataGridViewStagiaires.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStagiaires_CellContentClick);
            // 
            // stagiaireBindingSource
            // 
            this.stagiaireBindingSource.DataSource = typeof(Entites.Stagiaire);
            // 
            // Editer
            // 
            this.Editer.HeaderText = "";
            this.Editer.Image = global::App.GestionStagiaires.Properties.Resources.edit_bleu;
            this.Editer.Name = "Editer";
            this.Editer.ReadOnly = true;
            this.Editer.Width = 50;
            // 
            // nomDataGridViewTextBoxColumn
            // 
            this.nomDataGridViewTextBoxColumn.DataPropertyName = "Nom";
            this.nomDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.nomDataGridViewTextBoxColumn.Name = "nomDataGridViewTextBoxColumn";
            this.nomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prenomDataGridViewTextBoxColumn
            // 
            this.prenomDataGridViewTextBoxColumn.DataPropertyName = "Prenom";
            this.prenomDataGridViewTextBoxColumn.HeaderText = "Prenom";
            this.prenomDataGridViewTextBoxColumn.Name = "prenomDataGridViewTextBoxColumn";
            this.prenomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateNaissanceDataGridViewTextBoxColumn
            // 
            this.dateNaissanceDataGridViewTextBoxColumn.DataPropertyName = "DateNaissance";
            this.dateNaissanceDataGridViewTextBoxColumn.HeaderText = "DateNaissance";
            this.dateNaissanceDataGridViewTextBoxColumn.Name = "dateNaissanceDataGridViewTextBoxColumn";
            this.dateNaissanceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupeDataGridViewTextBoxColumn
            // 
            this.groupeDataGridViewTextBoxColumn.DataPropertyName = "Groupe";
            this.groupeDataGridViewTextBoxColumn.HeaderText = "Groupe";
            this.groupeDataGridViewTextBoxColumn.Name = "groupeDataGridViewTextBoxColumn";
            this.groupeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Supprimer
            // 
            this.Supprimer.HeaderText = "";
            this.Supprimer.Image = global::App.GestionStagiaires.Properties.Resources.delete;
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.ReadOnly = true;
            this.Supprimer.Width = 50;
            // 
            // GridStagiaireUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewStagiaires);
            this.Name = "GridStagiaireUC";
            this.Size = new System.Drawing.Size(833, 398);
            this.Load += new System.EventHandler(this.GridStagiaireUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStagiaires)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stagiaireBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource stagiaireBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewStagiaires;
        private System.Windows.Forms.DataGridViewImageColumn Editer;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateNaissanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Supprimer;
    }
}
