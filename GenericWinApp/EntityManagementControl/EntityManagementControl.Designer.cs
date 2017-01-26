namespace App.WinForm
{
    partial class EntityManagementControl
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
            this.panelDataGrid = new System.Windows.Forms.Panel();
            this.tabControl_MainManager = new System.Windows.Forms.TabControl();
            this.TabGrid = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelFilter = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_titre_gestion = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_Ajouter = new System.Windows.Forms.Button();
            this.panel_Filtre = new System.Windows.Forms.Panel();
            this.tabControlManagers = new System.Windows.Forms.TabControl();
            this.main = new System.Windows.Forms.TabPage();
            this.tabPageAdd = new System.Windows.Forms.TabPage();
            this.panelDataGrid.SuspendLayout();
            this.tabControl_MainManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanelFilter.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControlManagers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDataGrid.Controls.Add(this.tabControlManagers);
            this.panelDataGrid.Controls.Add(this.tabControl_MainManager);
            this.panelDataGrid.Location = new System.Drawing.Point(12, 14);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(1065, 305);
            this.panelDataGrid.TabIndex = 17;
            this.panelDataGrid.Tag = "";
            // 
            // tabControl_MainManager
            // 
            this.tabControl_MainManager.CausesValidation = false;
            this.tabControl_MainManager.Controls.Add(this.TabGrid);
            this.tabControl_MainManager.Controls.Add(this.tabPageAdd);
            this.tabControl_MainManager.HotTrack = true;
            this.tabControl_MainManager.Location = new System.Drawing.Point(564, 41);
            this.tabControl_MainManager.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl_MainManager.Name = "tabControl_MainManager";
            this.tabControl_MainManager.SelectedIndex = 0;
            this.tabControl_MainManager.ShowToolTips = true;
            this.tabControl_MainManager.Size = new System.Drawing.Size(439, 219);
            this.tabControl_MainManager.TabIndex = 15;
            this.tabControl_MainManager.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_MainManager_Selecting);
            // 
            // TabGrid
            // 
            this.TabGrid.CausesValidation = false;
            this.TabGrid.Location = new System.Drawing.Point(4, 22);
            this.TabGrid.Name = "TabGrid";
            this.TabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.TabGrid.Size = new System.Drawing.Size(431, 193);
            this.TabGrid.TabIndex = 0;
            this.TabGrid.Text = "Informations";
            this.TabGrid.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.CausesValidation = false;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanelFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.CausesValidation = false;
            this.splitContainer1.Panel2.Controls.Add(this.panelDataGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1089, 439);
            this.splitContainer1.SplitterDistance = 104;
            this.splitContainer1.TabIndex = 15;
            // 
            // tableLayoutPanelFilter
            // 
            this.tableLayoutPanelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelFilter.ColumnCount = 2;
            this.tableLayoutPanelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.18779F));
            this.tableLayoutPanelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.81221F));
            this.tableLayoutPanelFilter.Controls.Add(this.lbl_titre_gestion, 0, 0);
            this.tableLayoutPanelFilter.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanelFilter.Controls.Add(this.panel_Filtre, 0, 1);
            this.tableLayoutPanelFilter.Location = new System.Drawing.Point(12, 3);
            this.tableLayoutPanelFilter.Name = "tableLayoutPanelFilter";
            this.tableLayoutPanelFilter.RowCount = 2;
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.77099F));
            this.tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.229F));
            this.tableLayoutPanelFilter.Size = new System.Drawing.Size(1065, 98);
            this.tableLayoutPanelFilter.TabIndex = 14;
            // 
            // lbl_titre_gestion
            // 
            this.lbl_titre_gestion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_titre_gestion.AutoSize = true;
            this.lbl_titre_gestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titre_gestion.Location = new System.Drawing.Point(3, 4);
            this.lbl_titre_gestion.Name = "lbl_titre_gestion";
            this.lbl_titre_gestion.Size = new System.Drawing.Size(77, 20);
            this.lbl_titre_gestion.TabIndex = 14;
            this.lbl_titre_gestion.Text = "Gestion ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.4023F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.597701F));
            this.tableLayoutPanel2.Controls.Add(this.bt_Ajouter, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(856, 32);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.37037F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.62963F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(206, 63);
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
            this.bt_Ajouter.Size = new System.Drawing.Size(190, 38);
            this.bt_Ajouter.TabIndex = 12;
            this.bt_Ajouter.Text = "Ajouter";
            this.bt_Ajouter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Ajouter.UseVisualStyleBackColor = true;
            this.bt_Ajouter.Click += new System.EventHandler(this.bt_Ajouter_Click);
            // 
            // panel_Filtre
            // 
            this.panel_Filtre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Filtre.Location = new System.Drawing.Point(3, 32);
            this.panel_Filtre.Name = "panel_Filtre";
            this.panel_Filtre.Size = new System.Drawing.Size(847, 63);
            this.panel_Filtre.TabIndex = 16;
            this.panel_Filtre.Tag = "";
            // 
            // tabControlManagers
            // 
            this.tabControlManagers.Controls.Add(this.main);
            this.tabControlManagers.HotTrack = true;
            this.tabControlManagers.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControlManagers.Location = new System.Drawing.Point(31, 41);
            this.tabControlManagers.Multiline = true;
            this.tabControlManagers.Name = "tabControlManagers";
            this.tabControlManagers.SelectedIndex = 0;
            this.tabControlManagers.Size = new System.Drawing.Size(393, 215);
            this.tabControlManagers.TabIndex = 16;
            // 
            // main
            // 
            this.main.AutoScroll = true;
            this.main.Location = new System.Drawing.Point(4, 34);
            this.main.Name = "main";
            this.main.Padding = new System.Windows.Forms.Padding(3);
            this.main.Size = new System.Drawing.Size(385, 177);
            this.main.TabIndex = 0;
            this.main.Text = "Gestion";
            this.main.UseVisualStyleBackColor = true;
            // 
            // tabPageAdd
            // 
            this.tabPageAdd.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdd.Name = "tabPageAdd";
            this.tabPageAdd.Size = new System.Drawing.Size(431, 193);
            this.tabPageAdd.TabIndex = 1;
            this.tabPageAdd.Text = "+";
            this.tabPageAdd.UseVisualStyleBackColor = true;
            // 
            // EntityManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "EntityManagementControl";
            this.Size = new System.Drawing.Size(1089, 439);
            this.Load += new System.EventHandler(this.EntityManagementForm_Load);
            this.panelDataGrid.ResumeLayout(false);
            this.tabControl_MainManager.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanelFilter.ResumeLayout(false);
            this.tableLayoutPanelFilter.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControlManagers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDataGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFilter;
        private System.Windows.Forms.Label lbl_titre_gestion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bt_Ajouter;
        private System.Windows.Forms.Panel panel_Filtre;
        private System.Windows.Forms.TabControl tabControl_MainManager;
        private System.Windows.Forms.TabPage TabGrid;
        private System.Windows.Forms.TabControl tabControlManagers;
        private System.Windows.Forms.TabPage main;
        private System.Windows.Forms.TabPage tabPageAdd;
    }
}
