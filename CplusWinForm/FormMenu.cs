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
using App.WinFrom.Menu;

namespace App
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            AfficherFormulaire = new ShowEntityManagementForm(this);
        }

        ShowEntityManagementForm AfficherFormulaire { set; get; }
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
            StagiaireEntryForm objetForm = new StagiaireEntryForm(service);

            AfficherFormulaire.AfficherUneGestion<Stagiaire>(service, objetForm);

        }

        private void projetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Projet>();
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
            AfficherFormulaire.AfficherUneGestion<Filiere>();
        }


        private void gérerLesTâchesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Tache>(new TachesService());
        }

        private void affecterTâcheÀUnStagiaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.Afficher(new GestionProjets.FormAffecterTachesAuxStagiaires());
        }

        private void affecterTâcheÀUnMiniGroupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.Afficher(new GestionProjets.FormAffecterTachesAuMiniGroupe());
        }

        private void editerGénériqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Gestion.FormGestion<GestionStagiaires.StagiaireEntryForm> f = new Gestion.FormGestion<GestionStagiaires.StagiaireEntryForm>("Stagiaires", new GestionStagiaires.GridStagiaireUC());
          //  AfficherFormulaire.Afficher(f);

        }

        private void formateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Formateur>();
        }

        private void gérerLesGroupesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AfficherFormulaire.AfficherUneGestion<Groupe>(new UserControlGroupeForm(new BaseRepository<Groupe>()));
        }

        private void tâchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Tache>();
        }

        private void gestionDesModulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EntityManagementForm form = new EntityManagementForm(
                new BaseRepository<Module>(),null,null,this);
            AfficherFormulaire.Afficher(form);
        }

        private void gestionDesPrécisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            AfficherFormulaire.AfficherUneGestion<Precision>(new BaseRepository<Precision>());
          
        }

        private void annéesDeFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<AnneeFormation>(new AnneeFormationFormulaire(new BaseRepository<AnneeFormation>()));
        }

      

        private void gestionMaisonDéditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<MaisonEdition>();
        }

        private void gestionDesLivresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Livre>();
        }

        private void gestionDesGroupesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Groupe>();
        }

        private void sallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void gestionDesSéancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Seance>(new SeancesService());
        }

        private void prévisionDesSéancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<PrevisionSeance>(new PrevisionSeancesService());
        }

        private void gestionDesFormationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Formation>();
            
        }

        private void gestionDesSallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Salle>();
        }

        private void catégoriesSalleDeFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<CategogiesSalleFormation>();
        }


        #region La méthode AfficherUneGestion
      

       
       
        #endregion

        private void contenuePrécisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<ContenuePrecision>();
        }

        private void gestionDesPréalablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Prealable>();
        }

        private void fériésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfficherFormulaire.AfficherUneGestion<Ferier>(new FeriesService());
        }
    }
}
