namespace App.GestionStagiaires.Groupes
{
    partial class FormGestionGroupe2
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
            System.Windows.Forms.DataGridView groupeDataGridView;
            this.filiereBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColonneFiliere = new System.Windows.Forms.DataGridViewComboBoxColumn();
            groupeDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ObjetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(groupeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filiereBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupeDataGridView
            // 
            groupeDataGridView.AllowUserToOrderColumns = true;
            groupeDataGridView.AutoGenerateColumns = false;
            groupeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            groupeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.ColonneFiliere});
            groupeDataGridView.DataSource = this.groupeBindingSource;
            groupeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            groupeDataGridView.Location = new System.Drawing.Point(0, 25);
            groupeDataGridView.Name = "groupeDataGridView";
            groupeDataGridView.Size = new System.Drawing.Size(708, 365);
            groupeDataGridView.TabIndex = 1;
            groupeDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.groupeDataGridView_CellValuePushed);
            groupeDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.groupeDataGridView_RowPostPaint);
            groupeDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.groupeDataGridView_RowsAdded);
            groupeDataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.groupeDataGridView_MouseDoubleClick);
            // 
            // filiereBindingSource
            // 
            this.filiereBindingSource.DataSource = typeof(App.Entites.Filiere);
            // 
            // groupeBindingSource
            // 
            this.groupeBindingSource.DataSource = typeof(App.Entites.Groupe);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nom";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nom";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DateModification";
            this.dataGridViewTextBoxColumn5.HeaderText = "DateModification";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // ColonneFiliere
            // 
            this.ColonneFiliere.DataPropertyName = "Filiere";
            this.ColonneFiliere.DataSource = this.filiereBindingSource;
            this.ColonneFiliere.HeaderText = "Filiere";
            this.ColonneFiliere.Name = "ColonneFiliere";
            this.ColonneFiliere.ReadOnly = true;
            // 
            // FormGestionGroupe2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(708, 390);
            this.Controls.Add(groupeDataGridView);
            this.Name = "FormGestionGroupe2";
            this.Controls.SetChildIndex(groupeDataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ObjetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(groupeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filiereBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource groupeBindingSource;
        private System.Windows.Forms.BindingSource filiereBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColonneFiliere;
    }
}
