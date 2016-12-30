namespace AppGestionStagiaires
{
    partial class FormMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stagiairesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionStagiaires = new System.Windows.Forms.ToolStripMenuItem();
            this.binfingNavigatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesProjetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stagiairesToolStripMenuItem,
            this.gestionDesProjetsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(657, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stagiairesToolStripMenuItem
            // 
            this.stagiairesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionStagiaires,
            this.binfingNavigatorToolStripMenuItem});
            this.stagiairesToolStripMenuItem.Name = "stagiairesToolStripMenuItem";
            this.stagiairesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.stagiairesToolStripMenuItem.Text = "Stagiaires";
            // 
            // gestionStagiaires
            // 
            this.gestionStagiaires.Name = "gestionStagiaires";
            this.gestionStagiaires.Size = new System.Drawing.Size(171, 22);
            this.gestionStagiaires.Text = "Gérer les stagiaires";
            this.gestionStagiaires.Click += new System.EventHandler(this.gestionStagiaires_Click);
            // 
            // binfingNavigatorToolStripMenuItem
            // 
            this.binfingNavigatorToolStripMenuItem.Name = "binfingNavigatorToolStripMenuItem";
            this.binfingNavigatorToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.binfingNavigatorToolStripMenuItem.Text = "Binfing Navigator";
            this.binfingNavigatorToolStripMenuItem.Click += new System.EventHandler(this.binfingNavigatorToolStripMenuItem_Click);
            // 
            // gestionDesProjetsToolStripMenuItem
            // 
            this.gestionDesProjetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projetsToolStripMenuItem});
            this.gestionDesProjetsToolStripMenuItem.Name = "gestionDesProjetsToolStripMenuItem";
            this.gestionDesProjetsToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.gestionDesProjetsToolStripMenuItem.Text = "Gestion des projets";
            // 
            // projetsToolStripMenuItem
            // 
            this.projetsToolStripMenuItem.Name = "projetsToolStripMenuItem";
            this.projetsToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.projetsToolStripMenuItem.Text = "Projets";
            this.projetsToolStripMenuItem.Click += new System.EventHandler(this.projetsToolStripMenuItem_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 402);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application de gestion des stagiaires";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenu_FormClosed);
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stagiairesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionStagiaires;
        private System.Windows.Forms.ToolStripMenuItem binfingNavigatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesProjetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projetsToolStripMenuItem;
    }
}