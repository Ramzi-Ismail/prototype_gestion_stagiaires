
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cplus.Entites;
using Cplus.GestionStagiaires;

namespace Cplus
{
    public partial class FormGestionStagiaires : Form
    {
        public FormGestionStagiaires()
        {
            InitializeComponent();

        }

        private void FormGestionStagiaires_Load(object sender, EventArgs e)
        {
            // Actualiser la liste des stagiaires
            this.gridStagiaire.Actualiser();

            // événement Supprimer et Editer sur la liste des stagiaires
            gridStagiaire.EditerStagiaireEvent += GridStagiaire_EditerStagiaireEvent;
        }
       

        #region Editer Un Stagiaire
        /// <summary>
        /// Implémentation de event Editer Stagiaire du GridStagiaire
        /// </summary>

        private void GridStagiaire_EditerStagiaireEvent(object sender, EventArgs e)
        {
            Stagiaire stagiaire = gridStagiaire.Current;
            string tabEditerName = "TabEditer-" + stagiaire.Id;

            if (tabControlStagiaires.TabPages.IndexOfKey(tabEditerName) == -1)
            {
                // Création de Tab
                TabPage tabEditerStagiaire = new TabPage();
                tabEditerStagiaire.Text = stagiaire.Nom + " " + stagiaire.Prenom;
                tabEditerStagiaire.Name = tabEditerName;
                tabControlStagiaires.TabPages.Add(tabEditerStagiaire);
                tabControlStagiaires.SelectedTab = tabEditerStagiaire;

                // Insertion du formulaire 
                FormStagiaireUC stagiaireForm = new FormStagiaireUC();
                stagiaireForm.Name = "stagiaireForm";
                stagiaireForm.Stagiaire = stagiaire;
                stagiaireForm.AfficherStagiaire();
                this.tabControlStagiaires.TabPages[tabEditerName].Controls.Add(stagiaireForm);
                stagiaireForm.EnregistrerClick += StagiaireForm_EditerClick;
                stagiaireForm.AnnulerClick += StagiaireForm_AnnulerEditerClick;
            }
        } 
        
        private void StagiaireForm_EditerClick(object sender, EventArgs e)
        {
            FormStagiaireUC formStagiaire = (FormStagiaireUC)sender;
            Stagiaire stagiaire = formStagiaire.Stagiaire;
            string tabEditerName = "TabEditer-" + stagiaire.Id;
            TabPage tabEditer = this.tabControlStagiaires.TabPages[tabEditerName];

            if(new StagiairesService().Save(stagiaire) > 0)
            {
                MessageBox.Show("Le Stagiaire :" + stagiaire.ToString() + " a été bien enregistrer");
            }
            else
            {
                MessageBox.Show("Le Stagiaire :" + stagiaire.ToString() + " n'est pas enregistrer car il n'y a pas des modifications");
            }
            

            // Suppression de la page Editer
            this.tabControlStagiaires.TabPages.Remove(tabEditer);
            this.gridStagiaire.Actualiser();
        }


       
        private void StagiaireForm_AnnulerEditerClick(object sender, EventArgs e)
        {
            FormStagiaireUC formStagiaire = (FormStagiaireUC)sender;
            Stagiaire stagiaire = formStagiaire.Stagiaire;
            string tabEditerName = "TabEditer-" + stagiaire.Id;
            TabPage tabEditer = this.tabControlStagiaires.TabPages[tabEditerName];
            tabControlStagiaires.TabPages.Remove(tabEditer);
        }
        #endregion

        #region Ajouter un Stagiaire
        private void bt_Ajouter_Click(object sender, EventArgs e)
        {
            // Insertion du formulaire Si la page TabAjouter n'existe pas
            if (tabControlStagiaires.TabPages.IndexOfKey("TabAjouter") == -1)
            {
                // Création de Tab
                TabPage tabAjouterStagiaire = new TabPage();
                tabAjouterStagiaire.Text = "Ajouter un stagiaire";
                tabAjouterStagiaire.Name = "TabAjouter";
                tabControlStagiaires.TabPages.Add(tabAjouterStagiaire);
                tabControlStagiaires.SelectedTab = tabAjouterStagiaire;

                // Insertion du formulaire 
                FormStagiaireUC stagiaireForm = new FormStagiaireUC();
                stagiaireForm.Name = "stagiaireForm";
                this.tabControlStagiaires.TabPages["TabAjouter"].Controls.Add(stagiaireForm);
                stagiaireForm.EnregistrerClick += StagiaireForm_EnregistrerClick;
                stagiaireForm.AnnulerClick += StagiaireForm_AnnulerAjouterClick;
            }
        }

        /// <summary>
        /// Enregistrer un Stagiaire
        /// </summary>
        private void StagiaireForm_EnregistrerClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControlStagiaires.TabPages["TabAjouter"];
            FormStagiaireUC form = (FormStagiaireUC)tabAjouter.Controls
                .Find("stagiaireForm", false).First();

            if (new StagiairesService().Save(form.Stagiaire) > 0)
            {
                MessageBox.Show("Le Stagiaire :" + form.Stagiaire.ToString() + " a été bien enregistrer");
            }
            else
            {
                MessageBox.Show("Le Stagiaire :" + form.Stagiaire.ToString() + " n'est pas enregistrer");
            }

            this.tabControlStagiaires.TabPages.Remove(tabAjouter);
            this.gridStagiaire.Actualiser();
        }
        /// <summary>
        /// Annuler l'insertion d'un stagiaire
        /// </summary>
        private void StagiaireForm_AnnulerAjouterClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControlStagiaires.TabPages["TabAjouter"];
            tabControlStagiaires.TabPages.Remove(tabAjouter);
        }
        #endregion


        private void FormGestionStagiaires_Resize(object sender, EventArgs e)
        {
            this.tabControlStagiaires.Location = new Point(10, 50);
        }

        private void dataGridViewStagiaires_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridStagiaire_Load(object sender, EventArgs e)
        {

        }
        
    }
}
