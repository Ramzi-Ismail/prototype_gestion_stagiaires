namespace App.Gestion
{
    partial class FormGestion<T>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_Ajouter = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabGrid = new System.Windows.Forms.TabPage();
            this.dataGridViewStagiaires = new System.Windows.Forms.DataGridView();
            this.Editer = new System.Windows.Forms.DataGridViewImageColumn();
            this.Supprimer = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControl.SuspendLayout();
            this.TabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStagiaires)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Ajouter
            // 
            this.bt_Ajouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Ajouter.Location = new System.Drawing.Point(692, 12);
            this.bt_Ajouter.Name = "bt_Ajouter";
            this.bt_Ajouter.Size = new System.Drawing.Size(120, 23);
            this.bt_Ajouter.TabIndex = 12;
            this.bt_Ajouter.Text = "Ajouter";
            this.bt_Ajouter.UseVisualStyleBackColor = true;
            this.bt_Ajouter.Click += new System.EventHandler(this.bt_Ajouter_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.TabGrid);
            this.tabControl.Location = new System.Drawing.Point(12, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 438);
            this.tabControl.TabIndex = 13;
            // 
            // TabGrid
            // 
            this.TabGrid.Controls.Add(this.dataGridViewStagiaires);
            this.TabGrid.Location = new System.Drawing.Point(4, 22);
            this.TabGrid.Name = "TabGrid";
            this.TabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.TabGrid.Size = new System.Drawing.Size(792, 412);
            this.TabGrid.TabIndex = 0;
            this.TabGrid.Text = "tabPage1";
            this.TabGrid.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStagiaires
            // 
            this.dataGridViewStagiaires.AllowUserToAddRows = false;
            this.dataGridViewStagiaires.AllowUserToDeleteRows = false;
            this.dataGridViewStagiaires.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStagiaires.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editer,
            this.Supprimer});
            this.dataGridViewStagiaires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStagiaires.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewStagiaires.Name = "dataGridViewStagiaires";
            this.dataGridViewStagiaires.ReadOnly = true;
            this.dataGridViewStagiaires.Size = new System.Drawing.Size(786, 406);
            this.dataGridViewStagiaires.TabIndex = 10;
            this.dataGridViewStagiaires.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStagiaires_CellContentClick);
            // 
            // Editer
            // 
            this.Editer.HeaderText = "";
         
            this.Editer.Name = "Editer";
            this.Editer.ReadOnly = true;
            this.Editer.Width = 50;
            // 
            // Supprimer
            // 
            this.Supprimer.HeaderText = "";
  
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.ReadOnly = true;
            this.Supprimer.Width = 50;
            // 
            // FormGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 491);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.bt_Ajouter);
            this.Name = "FormGestion";
            this.Text = "FormGestion";
            this.Load += new System.EventHandler(this.FormGestion_Load);
            this.Resize += new System.EventHandler(this.FormGestion_Resize);
            this.tabControl.ResumeLayout(false);
            this.TabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStagiaires)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_Ajouter;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage TabGrid;
        private System.Windows.Forms.DataGridView dataGridViewStagiaires;
        private System.Windows.Forms.DataGridViewImageColumn Editer;
        private System.Windows.Forms.DataGridViewImageColumn Supprimer;
    }
}