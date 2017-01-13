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
using App.Livres;

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
            InterfaceGestion form = new InterfaceGestion(service, objetForm);
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
            this.AfficherUneGestion<Filiere>();
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
            this.AfficherUneGestion<Formateur>();
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
            InterfaceGestion form = new InterfaceGestion(new BaseRepository<Module>());
            this.AfficherForm(form);
        }

        private void gestionDesPrécisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfaceGestion form = new InterfaceGestion(new BaseRepository<Precision>());
            this.AfficherForm(form);
        }

        private void annéesDeFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<AnneeFormation>(new AnneeFormationFormulaire());
        }

      

        private void gestionMaisonDéditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<MaisonEdition>();
        }

        private void gestionDesLivresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<Livre>();
        }

        private void gestionDesGroupesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<Groupe>();
        }

        private void sallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void gestionDesSéancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<Seance>(new SeancesService());
        }

        private void prévisionDesSéancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<PrevisionSeance>(new PrevisionSeancesService());
        }

        private void gestionDesFormationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<Formation>();
            
        }

        private void gestionDesSallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<Salle>();
        }

        private void catégoriesSalleDeFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<CategogiesSalleFormation>();
        }


        #region La méthode AfficherUneGestion
        private void AfficherUneGestion<T>() where T : BaseEntity
        {
            InterfaceGestion form = new InterfaceGestion(new BaseRepository<T>());
            this.AfficherForm(form);
        }

        private void AfficherUneGestion<T>(IBaseRepository Service) where T : BaseEntity
        {
            InterfaceGestion form = new InterfaceGestion(Service);
            this.AfficherForm(form);
        }

        /// <summary>
        /// Afficher une gestion avec une formulaire spécifique
        /// </summary>
        /// <typeparam name="T">L'objet à gérer</typeparam>
        /// <param name="formulaire">Le Formulaire spécifique</param>
        private void AfficherUneGestion<T>(BaseFormulaire formulaire) where T : BaseEntity
        {
            InterfaceGestion form = new InterfaceGestion(new BaseRepository<T>(), formulaire);
            this.AfficherForm(form);
        }

       
        /// <summary>
        /// Affichage d'une formulaire de Type : Form
        /// </summary>
        /// <param name="f">Le controle Form à afficher </param>
        private void AfficherForm(Form addForm)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form form = this.MdiChildren.Where(f => f.Name == addForm.Name).FirstOrDefault();
            if (form == null)
            {
                addForm.MdiParent = this;
                addForm.StartPosition = FormStartPosition.CenterScreen;
                addForm.WindowState = FormWindowState.Maximized;
                addForm.Show();
            }
            else
            {
                form.WindowState = FormWindowState.Normal;

            }

            Cursor.Current = Cursors.Default;
        }
        #endregion

        private void contenuePrécisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherUneGestion<ContenuePrecision>();
        }
    }
}
