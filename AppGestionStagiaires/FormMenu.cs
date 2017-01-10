using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionStagiaires;
using App.GestionStagiaires;
using App.GestionStagiaires.Groupes;
using App.WinForm;
using App.GestionStagiaires.Formateurs;
using App.GestionFormations;
using App.GestionProjets;
using App.Modules;
using App.Formations;

namespace App
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void binfingNavigatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // new FormBinfingNavigator().Show();
        }
        private void AfficherForm(Form f)
        {
            Cursor.Current = Cursors.WaitCursor;
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Gestion des stagiaires
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gestionStagiaires_Click(object sender, EventArgs e)
        {
            // Gestion des stagiaire
            StagiairesService service = new StagiairesService();
            FormStagiaireUC objetForm = new FormStagiaireUC(service);
            FormGestionTabPage form = new FormGestionTabPage(service, objetForm);
            this.AfficherForm(form);
        }

        private void projetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new GestionProjets.FormGestionProjet());
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void filieresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gérerLesFilieresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUnGestion<Filiere>();
        }


        private void gérerLesTâchesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new GestionProjets.FormGestionTaches());
        }

        private void affecterTâcheÀUnStagiaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new GestionProjets.FormAffecterTachesAuxStagiaires());
        }

        private void affecterTâcheÀUnMiniGroupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new GestionProjets.FormAffecterTachesAuMiniGroupe());
        }

        private void editerGénériqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Gestion.FormGestion<GestionStagiaires.FormStagiaireUC> f = new Gestion.FormGestion<GestionStagiaires.FormStagiaireUC>("Stagiaires", new GestionStagiaires.GridStagiaireUC());
          //  this.AfficherForm(f);

        }

        private void formateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUnGestion<Formateur>();
        }

        private void gérerLesGroupesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.AfficherForm(new FormGestionGroupes());
        }

        private void tâchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new FormGestionTaches());
        }

        private void gestionDesModulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGestionTabPage form = new FormGestionTabPage(new BaseRepository<Module>());
            this.AfficherForm(form);
        }

        private void gestionDesPrécisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionTabPage form = new FormGestionTabPage(new BaseRepository<Precision>());
            this.AfficherForm(form);
        }

        private void annéesDeFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUnGestion<AnneeFormation>();
        }

        private void AfficherUnGestion<T>() where T:BaseEntity
        {
            FormGestionTabPage form = new FormGestionTabPage(new BaseRepository<T>());
            this.AfficherForm(form);
        }
    }
}
