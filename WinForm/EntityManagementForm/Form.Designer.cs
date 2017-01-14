namespace App.WinForm
{
    partial class EntityManagementForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabGrid = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Editer = new System.Windows.Forms.DataGridViewImageColumn();
            this.Supprimer = new System.Windows.Forms.DataGridViewImageColumn();
            this.ObjetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_Ajouter = new System.Windows.Forms.Button();
            this.lbl_titre_gestion = new System.Windows.Forms.Label();
            this.groupBoxFiltrage = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl.SuspendLayout();
            this.TabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.CausesValidation = false;
            this.tabControl.Controls.Add(this.TabGrid);
            this.tabControl.Location = new System.Drawing.Point(12, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(870, 426);
            this.tabControl.TabIndex = 13;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // TabGrid
            // 
            this.TabGrid.CausesValidation = false;
            this.TabGrid.Controls.Add(this.dataGridView);
            this.TabGrid.Location = new System.Drawing.Point(4, 22);
            this.TabGrid.Name = "TabGrid";
            this.TabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.TabGrid.Size = new System.Drawing.Size(862, 400);
            this.TabGrid.TabIndex = 0;
            this.TabGrid.Text = "Informations";
            this.TabGrid.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.CausesValidation = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editer,
            this.Supprimer});
            this.dataGridView.DataSource = this.ObjetBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(856, 394);
            this.dataGridView.TabIndex = 10;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            this.dataGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyUp);
            // 
            // Editer
            // 
            this.Editer.HeaderText = "";
            this.Editer.Image = global::App.WinForm.Properties.Resources.edit;
            this.Editer.Name = "Editer";
            this.Editer.ReadOnly = true;
            this.Editer.ToolTipText = "Editer";
            this.Editer.Width = 50;
            // 
            // Supprimer
            // 
            this.Supprimer.HeaderText = "";
            this.Supprimer.Image = global::App.WinForm.Properties.Resources.delete;
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.ReadOnly = true;
            this.Supprimer.Width = 50;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.CausesValidation = false;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.CausesValidation = false;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(891, 567);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 14;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.4023F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.597701F));
            this.tableLayoutPanel2.Controls.Add(this.bt_Ajouter, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(681, 41);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(183, 87);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // bt_Ajouter
            // 
            this.bt_Ajouter.AccessibleDescription = "Ajouter";
            this.bt_Ajouter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Ajouter.AutoEllipsis = true;
            this.bt_Ajouter.Image = global::App.WinForm.Properties.Resources.edit_bleu;
            this.bt_Ajouter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Ajouter.Location = new System.Drawing.Point(3, 3);
            this.bt_Ajouter.Name = "bt_Ajouter";
            this.bt_Ajouter.Size = new System.Drawing.Size(168, 36);
            this.bt_Ajouter.TabIndex = 12;
            this.bt_Ajouter.Text = "Ajouter";
            this.bt_Ajouter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Ajouter.UseVisualStyleBackColor = true;
            this.bt_Ajouter.Click += new System.EventHandler(this.bt_Ajouter_Click);
            // 
            // lbl_titre_gestion
            // 
            this.lbl_titre_gestion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_titre_gestion.AutoSize = true;
            this.lbl_titre_gestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titre_gestion.Location = new System.Drawing.Point(3, 9);
            this.lbl_titre_gestion.Name = "lbl_titre_gestion";
            this.lbl_titre_gestion.Size = new System.Drawing.Size(77, 20);
            this.lbl_titre_gestion.TabIndex = 14;
            this.lbl_titre_gestion.Text = "Gestion ";
            // 
            // groupBoxFiltrage
            // 
            this.groupBoxFiltrage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFiltrage.Location = new System.Drawing.Point(3, 41);
            this.groupBoxFiltrage.Name = "groupBoxFiltrage";
            this.groupBoxFiltrage.Size = new System.Drawing.Size(672, 87);
            this.groupBoxFiltrage.TabIndex = 13;
            this.groupBoxFiltrage.TabStop = false;
            this.groupBoxFiltrage.Text = "Filtre";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.26087F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.73913F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxFiltrage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_titre_gestion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.77099F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.229F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(867, 131);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // EntityManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(891, 567);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EntityManagementForm";
            this.Text = "FormGestion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EntityManagementForm_FormClosing);
            this.Load += new System.EventHandler(this.EntityManagementForm_Load);
            this.tabControl.ResumeLayout(false);
            this.TabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjetBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage TabGrid;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource ObjetBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewImageColumn Editer;
        private System.Windows.Forms.DataGridViewImageColumn Supprimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxFiltrage;
        private System.Windows.Forms.Label lbl_titre_gestion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bt_Ajouter;
    }
}