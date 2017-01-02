using System.Windows.Forms;

namespace Cplus
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
            this.menuStrip1 = new MenuStrip();
            this.stagiairesToolStripMenuItem = new ToolStripMenuItem();
            this.gestionStagiaires = new ToolStripMenuItem();

            this.miniGroupesToolStripMenuItem1 = new ToolStripMenuItem();
            this.gestionDesProjetsToolStripMenuItem = new ToolStripMenuItem();
            this.tâchesToolStripMenuItem = new ToolStripMenuItem();
            this.affecterTâcheÀUnStagiaireToolStripMenuItem = new ToolStripMenuItem();
            this.affecterTâcheÀUnMiniGroupeToolStripMenuItem = new ToolStripMenuItem();

            this.editerGénériqueToolStripMenuItem = new ToolStripMenuItem();

            this.projetsToolStripMenuItem = new ToolStripMenuItem();
            this.etablissementDeFormationToolStripMenuItem = new ToolStripMenuItem();
            this.gérerLesGroupesToolStripMenuItem = new ToolStripMenuItem();
            this.annéesDeFormationToolStripMenuItem = new ToolStripMenuItem();
            this.formateursToolStripMenuItem = new ToolStripMenuItem();
            this.gérerLesFilieresToolStripMenuItem = new ToolStripMenuItem();

            this.gérerLesProjetsToolStripMenuItem = new ToolStripMenuItem();
            this.gérerLesTâchesToolStripMenuItem1 = new ToolStripMenuItem();

            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 402);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Application de gestion des stagiaires";
            this.WindowState = FormWindowState.Maximized;
            this.FormClosed += new FormClosedEventHandler(this.FormMenu_FormClosed);
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.stagiairesToolStripMenuItem,
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
            this.stagiairesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.gestionStagiaires,

            this.miniGroupesToolStripMenuItem1});

         

            this.stagiairesToolStripMenuItem.Name = "stagiairesToolStripMenuItem";
            this.stagiairesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.stagiairesToolStripMenuItem.Text = "Stagiaires";


            // 
            // gestionStagiaires
            // 
            this.gestionStagiaires.Name = "gestionStagiaires";

            this.gestionStagiaires.Size = new System.Drawing.Size(190, 22);
            this.gestionStagiaires.Text = "Gérer les Stagiaires";
            this.gestionStagiaires.Click += new System.EventHandler(this.gestionStagiaires_Click);
            // 
            // miniGroupesToolStripMenuItem1
            // 
            this.miniGroupesToolStripMenuItem1.Name = "miniGroupesToolStripMenuItem1";
            this.miniGroupesToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.miniGroupesToolStripMenuItem1.Text = "Gérer les MiniGroupes";

            this.gestionStagiaires.Size = new System.Drawing.Size(173, 22);
            this.gestionStagiaires.Text = "Editer les stagiaires";
            this.gestionStagiaires.Click += new System.EventHandler(this.gestionStagiaires_Click);
            // 
            // editerGénériqueToolStripMenuItem
            // 
            this.editerGénériqueToolStripMenuItem.Name = "editerGénériqueToolStripMenuItem";
            this.editerGénériqueToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.editerGénériqueToolStripMenuItem.Text = "Editer Générique";
            this.editerGénériqueToolStripMenuItem.Click += new System.EventHandler(this.editerGénériqueToolStripMenuItem_Click);

            // 
            // gestionDesProjetsToolStripMenuItem
            // 
            this.gestionDesProjetsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.tâchesToolStripMenuItem,
            this.projetsToolStripMenuItem});
            this.gestionDesProjetsToolStripMenuItem.Name = "gestionDesProjetsToolStripMenuItem";
            this.gestionDesProjetsToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.gestionDesProjetsToolStripMenuItem.Text = "Gestion des projets";
            // 
            // tâchesToolStripMenuItem
            // 
            this.tâchesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.affecterTâcheÀUnStagiaireToolStripMenuItem,
            this.affecterTâcheÀUnMiniGroupeToolStripMenuItem});
            this.tâchesToolStripMenuItem.Name = "tâchesToolStripMenuItem";
            this.tâchesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.tâchesToolStripMenuItem.Text = "Affectation des tâches";

            // 
            // affecterTâcheÀUnStagiaireToolStripMenuItem
            // 
            this.affecterTâcheÀUnStagiaireToolStripMenuItem.Name = "affecterTâcheÀUnStagiaireToolStripMenuItem";
            this.affecterTâcheÀUnStagiaireToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.affecterTâcheÀUnStagiaireToolStripMenuItem.Text = "Affecter les tâches à un Stagiaire";
            this.affecterTâcheÀUnStagiaireToolStripMenuItem.Click += new System.EventHandler(this.affecterTâcheÀUnStagiaireToolStripMenuItem_Click);
            // 

            // affecterTâcheÀUnMiniGroupeToolStripMenuItem
            // 
            this.affecterTâcheÀUnMiniGroupeToolStripMenuItem.Name = "affecterTâcheÀUnMiniGroupeToolStripMenuItem";
            this.affecterTâcheÀUnMiniGroupeToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.affecterTâcheÀUnMiniGroupeToolStripMenuItem.Text = "Affecter  les tâche à un Mini Groupe";
            this.affecterTâcheÀUnMiniGroupeToolStripMenuItem.Click += new System.EventHandler(this.affecterTâcheÀUnMiniGroupeToolStripMenuItem_Click);
            // 
            // projetsToolStripMenuItem
            // 
            this.projetsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.gérerLesProjetsToolStripMenuItem,
            this.gérerLesTâchesToolStripMenuItem1});
            this.projetsToolStripMenuItem.Name = "projetsToolStripMenuItem";
            this.projetsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.projetsToolStripMenuItem.Text = "Projets et Tâches";
            // tâchesToolStripMenuItem
            // 
            this.tâchesToolStripMenuItem.Name = "tâchesToolStripMenuItem";
            this.tâchesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.tâchesToolStripMenuItem.Text = "Tâches";
            // 
            // projetsToolStripMenuItem
            // 
            this.projetsToolStripMenuItem.Name = "projetsToolStripMenuItem";
            this.projetsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.projetsToolStripMenuItem.Text = "Projets";
            this.projetsToolStripMenuItem.Click += new System.EventHandler(this.projetsToolStripMenuItem_Click);
            // 
            // etablissementDeFormationToolStripMenuItem
            // 
            this.etablissementDeFormationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.gérerLesGroupesToolStripMenuItem,
            this.annéesDeFormationToolStripMenuItem,
            this.formateursToolStripMenuItem,
            this.gérerLesFilieresToolStripMenuItem});
            this.etablissementDeFormationToolStripMenuItem.Name = "etablissementDeFormationToolStripMenuItem";
            this.etablissementDeFormationToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.etablissementDeFormationToolStripMenuItem.Text = "Etablissement de formation";
            // 
            // gérerLesGroupesToolStripMenuItem
            // 
            this.gérerLesGroupesToolStripMenuItem.Name = "gérerLesGroupesToolStripMenuItem";
            this.gérerLesGroupesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.gérerLesGroupesToolStripMenuItem.Text = "Groupes";
            // 
            // annéesDeFormationToolStripMenuItem
            // 
            this.annéesDeFormationToolStripMenuItem.Name = "annéesDeFormationToolStripMenuItem";
            this.annéesDeFormationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.annéesDeFormationToolStripMenuItem.Text = "Années de formation";
            // 
            // formateursToolStripMenuItem
            // 
            this.formateursToolStripMenuItem.Name = "formateursToolStripMenuItem";
            this.formateursToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.formateursToolStripMenuItem.Text = "Formateurs";
            this.formateursToolStripMenuItem.Click += new System.EventHandler(this.formateursToolStripMenuItem_Click);
            // 
            // gérerLesFilieresToolStripMenuItem
            // 
            this.gérerLesFilieresToolStripMenuItem.Name = "gérerLesFilieresToolStripMenuItem";
            this.gérerLesFilieresToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.gérerLesFilieresToolStripMenuItem.Text = "Filieres";
            this.gérerLesFilieresToolStripMenuItem.Click += new System.EventHandler(this.gérerLesFilieresToolStripMenuItem_Click);
            // 
            // gérerLesFilieresToolStripMenuItem
            // 
            this.gérerLesFilieresToolStripMenuItem.Name = "gérerLesFilieresToolStripMenuItem";
            this.gérerLesFilieresToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.gérerLesFilieresToolStripMenuItem.Text = "Filieres";
            this.gérerLesFilieresToolStripMenuItem.Click += new System.EventHandler(this.gérerLesFilieresToolStripMenuItem_Click);
            // 
            // gérerLesProjetsToolStripMenuItem
            // 
            this.gérerLesProjetsToolStripMenuItem.Name = "gérerLesProjetsToolStripMenuItem";
            this.gérerLesProjetsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.gérerLesProjetsToolStripMenuItem.Text = "Gérer les projets";
            // 
            // gérerLesTâchesToolStripMenuItem1
            // 
            this.gérerLesTâchesToolStripMenuItem1.Name = "gérerLesTâchesToolStripMenuItem1";
            this.gérerLesTâchesToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.gérerLesTâchesToolStripMenuItem1.Text = "Gérer les tâches";
            this.gérerLesTâchesToolStripMenuItem1.Click += new System.EventHandler(this.gérerLesTâchesToolStripMenuItem1_Click);


        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem stagiairesToolStripMenuItem;
        private ToolStripMenuItem gestionStagiaires;
        private ToolStripMenuItem gestionDesProjetsToolStripMenuItem;
        private ToolStripMenuItem projetsToolStripMenuItem;
        private ToolStripMenuItem tâchesToolStripMenuItem;
        private ToolStripMenuItem etablissementDeFormationToolStripMenuItem;
        private ToolStripMenuItem gérerLesGroupesToolStripMenuItem;
        private ToolStripMenuItem annéesDeFormationToolStripMenuItem;
        private ToolStripMenuItem formateursToolStripMenuItem;
        private ToolStripMenuItem gérerLesFilieresToolStripMenuItem;
        private ToolStripMenuItem miniGroupesToolStripMenuItem1;
        private ToolStripMenuItem affecterTâcheÀUnStagiaireToolStripMenuItem;
        private ToolStripMenuItem affecterTâcheÀUnMiniGroupeToolStripMenuItem;
        private ToolStripMenuItem gérerLesProjetsToolStripMenuItem;
        private ToolStripMenuItem gérerLesTâchesToolStripMenuItem1;
        private ToolStripMenuItem editerGénériqueToolStripMenuItem;
    }
}