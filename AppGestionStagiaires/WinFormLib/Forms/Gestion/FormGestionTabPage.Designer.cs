namespace App.WinFormLib.Forms.Gestion
{
    partial class FormGestionTabPage
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
            this.components = new System.ComponentModel.Container();
            this.bt_Ajouter = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabGrid = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Editer = new System.Windows.Forms.DataGridViewImageColumn();
            this.Supprimer = new System.Windows.Forms.DataGridViewImageColumn();
            this.ObjetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl.SuspendLayout();
            this.TabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Ajouter
            // 
            this.bt_Ajouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Ajouter.Location = new System.Drawing.Point(759, 12);
            this.bt_Ajouter.Name = "bt_Ajouter";
            this.bt_Ajouter.Size = new System.Drawing.Size(120, 23);
            this.bt_Ajouter.TabIndex = 12;
            this.bt_Ajouter.Text = "Ajouter";
            this.bt_Ajouter.UseVisualStyleBackColor = true;
            this.bt_Ajouter.Click += new System.EventHandler(this.bt_Ajouter_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.TabGrid);
            this.tabControl.Location = new System.Drawing.Point(9, 38);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(878, 520);
            this.tabControl.TabIndex = 13;
            // 
            // TabGrid
            // 
            this.TabGrid.Controls.Add(this.dataGridView);
            this.TabGrid.Location = new System.Drawing.Point(4, 22);
            this.TabGrid.Name = "TabGrid";
            this.TabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.TabGrid.Size = new System.Drawing.Size(870, 494);
            this.TabGrid.TabIndex = 0;
            this.TabGrid.Text = "Informations";
            this.TabGrid.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editer,
            this.Supprimer});
            this.dataGridView.DataSource = this.ObjetBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(864, 488);
            this.dataGridView.TabIndex = 10;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // Editer
            // 
            this.Editer.HeaderText = "";
            this.Editer.Image = global::App.Properties.Resources.edit;
            this.Editer.Name = "Editer";
            this.Editer.ReadOnly = true;
            this.Editer.ToolTipText = "Editer";
            this.Editer.Width = 50;
            // 
            // Supprimer
            // 
            this.Supprimer.HeaderText = "";
            this.Supprimer.Image = global::App.Properties.Resources.delete;
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.ReadOnly = true;
            this.Supprimer.Width = 50;
            // 
            // FormGestionTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 567);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.bt_Ajouter);
            this.Name = "FormGestionTabPage";
            this.Text = "FormGestion";
            this.Load += new System.EventHandler(this.FormGestion_Load);
            this.tabControl.ResumeLayout(false);
            this.TabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_Ajouter;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage TabGrid;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource ObjetBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn Editer;
        private System.Windows.Forms.DataGridViewImageColumn Supprimer;
    }
}