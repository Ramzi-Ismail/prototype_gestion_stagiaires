﻿using System;
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

            List<ColonneDataGridView> ListeColonne = new List<ColonneDataGridView> {
                    new ColonneDataGridView("Nom",ColonneDataGridView.TYPE_STRING,"Nom"),
                    new ColonneDataGridView("Prenom",ColonneDataGridView.TYPE_STRING,"Prénom"),
                    new ColonneDataGridView("Groupe",ColonneDataGridView.TYPE_STRING,"Groupe"),
                    new ColonneDataGridView("Filiere",ColonneDataGridView.TYPE_STRING,"Filiere"),
                    new ColonneDataGridView("DateModification",ColonneDataGridView.TYPE_DATATIME,"Date de modification"),
            };

            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("TitreGestion", "Gestion des stagiaires");
            Params.Add("TitrePageGrid", "Stagiaires");
            Params.Add("TitreButtonAjouter", "Ajouter un stagiaire");

            FormGestionTabPage form = new FormGestionTabPage(service, objetForm, ListeColonne, Params);
            this.AfficherForm(form);
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
           // Gestion.FormGestion<GestionStagiaires.FormStagiaireUC> f = new Gestion.FormGestion<GestionStagiaires.FormStagiaireUC>("Stagiaires", new GestionStagiaires.GridStagiaireUC());
          //  this.AfficherForm(f);

        }

        private void formateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ModelContext context = new ModelContext();
            //FormateurFormUC FormObjet = new FormateurFormUC(new FormateursService(context),context);
            //List<FormGestionTabPage.ColonneDataGridView> ListeColonne = new List<FormGestionTabPage.ColonneDataGridView> {
            //        new FormGestionTabPage.ColonneDataGridView("Matricule",FormGestionTabPage.ColonneDataGridView.TYPE_STRING,"Matricule"),
            //        new FormGestionTabPage.ColonneDataGridView("Nom",FormGestionTabPage.ColonneDataGridView.TYPE_STRING,"Nom"),
            //        new FormGestionTabPage.ColonneDataGridView("Prenom",FormGestionTabPage.ColonneDataGridView.TYPE_STRING,"Prénom"),
            //        new FormGestionTabPage.ColonneDataGridView("Filiere",FormGestionTabPage.ColonneDataGridView.TYPE_STRING,"Filiere"),
            //        new FormGestionTabPage.ColonneDataGridView("DateModification",FormGestionTabPage.ColonneDataGridView.TYPE_DATATIME,"Date de modification"),
            //};
            //FormGestionTabPage form = new FormGestionTabPage(FormObjet, ListeColonne);
            //this.AfficherForm(form);

        }

        private void gérerLesGroupesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.AfficherForm(new FormGestionGroupes());
        }

        private void tâchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AfficherForm(new FormGestionTaches());
        }
    }
}
