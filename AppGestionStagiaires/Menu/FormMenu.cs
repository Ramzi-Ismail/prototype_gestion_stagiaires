using Cplus.Gestion;
using Cplus.GestionProjets;
using Cplus.GestionStagiaires;
using Cplus.GestionStagiaires.Formateurs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cplus
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void binfingNavigatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormBinfingNavigator().Show();
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
            this.AfficherForm(new FormGestionProjets());
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
            this.AfficherForm(new FormGestionFilieres());
        }


        private void gérerLesTâchesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new FormGestionTaches());
        }

        private void affecterTâcheÀUnStagiaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new FormAffecterTachesAuxStagiaires());
        }

        private void affecterTâcheÀUnMiniGroupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new FormAffecterTachesAuMiniGroupe());
        }

        private void editerGénériqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestion<FormStagiaireUC> f = new FormGestion<FormStagiaireUC>("Stagiaires", new GridStagiaireUC());
            this.AfficherForm(f);

        }

        private void formateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestion<FormateurFormUC> f = new FormGestion<FormateurFormUC>("Formateurs", new FormateurGrideUC());
            this.AfficherForm(f);

        }
    }
}
