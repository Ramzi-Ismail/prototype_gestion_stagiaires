namespace App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stagiairesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionStagiaires = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesGroupesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesProjetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tâchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniGroupesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.séancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesSéancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prévisionDesSéancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesFormationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesModulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesModulesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.etablissementDeFormationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formateursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annéesDeFormationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerLesFilieresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catégoriesSalleDeFormationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesSallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fériésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.séancesToolStripMenuItem,
            this.stagiairesToolStripMenuItem,
            this.formationsToolStripMenuItem,
            this.gestionDesModulesToolStripMenuItem,
            this.gestionDesProjetsToolStripMenuItem,
            this.etablissementDeFormationToolStripMenuItem});
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
            this.gestionDesGroupesToolStripMenuItem});
            this.stagiairesToolStripMenuItem.Name = "stagiairesToolStripMenuItem";
            this.stagiairesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.stagiairesToolStripMenuItem.Text = "Stagiaires";
            // 
            // gestionStagiaires
            // 
            this.gestionStagiaires.Name = "gestionStagiaires";
            this.gestionStagiaires.Size = new System.Drawing.Size(188, 22);
            this.gestionStagiaires.Text = "Gestion des Stagiaires";
            this.gestionStagiaires.Click += new System.EventHandler(this.gestionStagiaires_Click);
            // 
            // gestionDesGroupesToolStripMenuItem
            // 
            this.gestionDesGroupesToolStripMenuItem.Name = "gestionDesGroupesToolStripMenuItem";
            this.gestionDesGroupesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.gestionDesGroupesToolStripMenuItem.Text = "Gestion des groupes";
            this.gestionDesGroupesToolStripMenuItem.Click += new System.EventHandler(this.gestionDesGroupesToolStripMenuItem_Click);
            // 
            // gestionDesProjetsToolStripMenuItem
            // 
            this.gestionDesProjetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tâchesToolStripMenuItem,
            this.projetsToolStripMenuItem,
            this.miniGroupesToolStripMenuItem});
            this.gestionDesProjetsToolStripMenuItem.Name = "gestionDesProjetsToolStripMenuItem";
            this.gestionDesProjetsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.gestionDesProjetsToolStripMenuItem.Text = "Projets";
            // 
            // tâchesToolStripMenuItem
            // 
            this.tâchesToolStripMenuItem.Name = "tâchesToolStripMenuItem";
            this.tâchesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tâchesToolStripMenuItem.Text = "Tâches";
            this.tâchesToolStripMenuItem.Click += new System.EventHandler(this.tâchesToolStripMenuItem_Click);
            // 
            // projetsToolStripMenuItem
            // 
            this.projetsToolStripMenuItem.Name = "projetsToolStripMenuItem";
            this.projetsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.projetsToolStripMenuItem.Text = "Projets";
            this.projetsToolStripMenuItem.Click += new System.EventHandler(this.projetsToolStripMenuItem_Click);
            // 
            // miniGroupesToolStripMenuItem
            // 
            this.miniGroupesToolStripMenuItem.Name = "miniGroupesToolStripMenuItem";
            this.miniGroupesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.miniGroupesToolStripMenuItem.Text = "Mini groupes";
            // 
            // séancesToolStripMenuItem
            // 
            this.séancesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesSéancesToolStripMenuItem,
            this.prévisionDesSéancesToolStripMenuItem,
            this.fériésToolStripMenuItem});
            this.séancesToolStripMenuItem.Name = "séancesToolStripMenuItem";
            this.séancesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.séancesToolStripMenuItem.Text = "Séances";
            // 
            // gestionDesSéancesToolStripMenuItem
            // 
            this.gestionDesSéancesToolStripMenuItem.Name = "gestionDesSéancesToolStripMenuItem";
            this.gestionDesSéancesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.gestionDesSéancesToolStripMenuItem.Text = "Gestion des séances";
            this.gestionDesSéancesToolStripMenuItem.Click += new System.EventHandler(this.gestionDesSéancesToolStripMenuItem_Click);
            // 
            // prévisionDesSéancesToolStripMenuItem
            // 
            this.prévisionDesSéancesToolStripMenuItem.Name = "prévisionDesSéancesToolStripMenuItem";
            this.prévisionDesSéancesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.prévisionDesSéancesToolStripMenuItem.Text = "Prévision des séances";
            this.prévisionDesSéancesToolStripMenuItem.Click += new System.EventHandler(this.prévisionDesSéancesToolStripMenuItem_Click);
            // 
            // formationsToolStripMenuItem
            // 
            this.formationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesFormationsToolStripMenuItem});
            this.formationsToolStripMenuItem.Name = "formationsToolStripMenuItem";
            this.formationsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.formationsToolStripMenuItem.Text = "Formations";
            // 
            // gestionDesFormationsToolStripMenuItem
            // 
            this.gestionDesFormationsToolStripMenuItem.Name = "gestionDesFormationsToolStripMenuItem";
            this.gestionDesFormationsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.gestionDesFormationsToolStripMenuItem.Text = "Gestion des formations";
            this.gestionDesFormationsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesFormationsToolStripMenuItem_Click);
            // 
            // gestionDesModulesToolStripMenuItem
            // 
            this.gestionDesModulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesModulesToolStripMenuItem1});
            this.gestionDesModulesToolStripMenuItem.Name = "gestionDesModulesToolStripMenuItem";
            this.gestionDesModulesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.gestionDesModulesToolStripMenuItem.Text = "Modules";
            // 
            // gestionDesModulesToolStripMenuItem1
            // 
            this.gestionDesModulesToolStripMenuItem1.Name = "gestionDesModulesToolStripMenuItem1";
            this.gestionDesModulesToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.gestionDesModulesToolStripMenuItem1.Text = "Gestion des modules";
            this.gestionDesModulesToolStripMenuItem1.Click += new System.EventHandler(this.gestionDesModulesToolStripMenuItem1_Click);
            // 
            // etablissementDeFormationToolStripMenuItem
            // 
            this.etablissementDeFormationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formateursToolStripMenuItem,
            this.annéesDeFormationToolStripMenuItem,
            this.gérerLesFilieresToolStripMenuItem,
            this.sallesToolStripMenuItem});
            this.etablissementDeFormationToolStripMenuItem.Name = "etablissementDeFormationToolStripMenuItem";
            this.etablissementDeFormationToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.etablissementDeFormationToolStripMenuItem.Text = "Etablissement ";
            // 
            // formateursToolStripMenuItem
            // 
            this.formateursToolStripMenuItem.Name = "formateursToolStripMenuItem";
            this.formateursToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.formateursToolStripMenuItem.Text = "Formateurs";
            this.formateursToolStripMenuItem.Click += new System.EventHandler(this.formateursToolStripMenuItem_Click);
            // 
            // annéesDeFormationToolStripMenuItem
            // 
            this.annéesDeFormationToolStripMenuItem.Name = "annéesDeFormationToolStripMenuItem";
            this.annéesDeFormationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.annéesDeFormationToolStripMenuItem.Text = "Années de formation";
            this.annéesDeFormationToolStripMenuItem.Click += new System.EventHandler(this.annéesDeFormationToolStripMenuItem_Click);
            // 
            // gérerLesFilieresToolStripMenuItem
            // 
            this.gérerLesFilieresToolStripMenuItem.Name = "gérerLesFilieresToolStripMenuItem";
            this.gérerLesFilieresToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.gérerLesFilieresToolStripMenuItem.Text = "Filieres";
            this.gérerLesFilieresToolStripMenuItem.Click += new System.EventHandler(this.gérerLesFilieresToolStripMenuItem_Click);
            // 
            // sallesToolStripMenuItem
            // 
            this.sallesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catégoriesSalleDeFormationToolStripMenuItem,
            this.gestionDesSallesToolStripMenuItem});
            this.sallesToolStripMenuItem.Name = "sallesToolStripMenuItem";
            this.sallesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.sallesToolStripMenuItem.Text = "Salles";
            this.sallesToolStripMenuItem.Click += new System.EventHandler(this.sallesToolStripMenuItem_Click);
            // 
            // catégoriesSalleDeFormationToolStripMenuItem
            // 
            this.catégoriesSalleDeFormationToolStripMenuItem.Name = "catégoriesSalleDeFormationToolStripMenuItem";
            this.catégoriesSalleDeFormationToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.catégoriesSalleDeFormationToolStripMenuItem.Text = "Catégories salle de formation";
            this.catégoriesSalleDeFormationToolStripMenuItem.Click += new System.EventHandler(this.catégoriesSalleDeFormationToolStripMenuItem_Click);
            // 
            // gestionDesSallesToolStripMenuItem
            // 
            this.gestionDesSallesToolStripMenuItem.Name = "gestionDesSallesToolStripMenuItem";
            this.gestionDesSallesToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.gestionDesSallesToolStripMenuItem.Text = "Gestion des salles";
            this.gestionDesSallesToolStripMenuItem.Click += new System.EventHandler(this.gestionDesSallesToolStripMenuItem_Click);
            // 
            // fériésToolStripMenuItem
            // 
            this.fériésToolStripMenuItem.Name = "fériésToolStripMenuItem";
            this.fériésToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.fériésToolStripMenuItem.Text = "Fériés";
            this.fériésToolStripMenuItem.Click += new System.EventHandler(this.fériésToolStripMenuItem_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 402);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.ToolStripMenuItem gestionDesProjetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miniGroupesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tâchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etablissementDeFormationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annéesDeFormationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formateursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerLesFilieresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesModulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesModulesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gestionDesGroupesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem séancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesSéancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prévisionDesSéancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesFormationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catégoriesSalleDeFormationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesSallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fériésToolStripMenuItem;
    }
}