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

        private void gestionStagiaires_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new FormGestionStagiaires());
        }

        private void projetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new GestionProjets.FormGestionProjets());
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
            this.AfficherForm(new GestionStagiaires.FormGestionFilieres());
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
            Gestion.FormGestion<GestionStagiaires.FormStagiaireUC> f = new Gestion.FormGestion<GestionStagiaires.FormStagiaireUC>("Stagiaires", new GestionStagiaires.GridStagiaireUC());
            this.AfficherForm(f);

        }

        private void formateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gestion.FormGestion<GestionStagiaires.Formateurs.FormateurFormUC> f = new Gestion.FormGestion<GestionStagiaires.Formateurs.FormateurFormUC>("Formateurs", new GestionStagiaires.Formateurs.FormateurGrideUC());
            this.AfficherForm(f);

        }
    }
}
