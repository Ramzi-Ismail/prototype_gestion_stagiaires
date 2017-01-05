using App.Entites;
using App.Gestion;
using App.WinFromLib.FormUC;
using EFlib;
using EFlib.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinFormLib.Forms.Gestion
{
    public partial class FormGestionTabPage : Form
    {
        /// <summary>
        /// L'objet Service pour la manipulation de l'objet
        /// </summary>
        protected IBaseRepository Service;
        /// <summary>
        /// Le formulaire de l'édition et d'insertion
        /// </summary>
        protected BaseFormUserControl Formulaire;

        /// <summary>
        /// Liste des colonnes à afficher dans le DataGridView
        /// </summary>
        public List<FormGestionTabPage.ColonneDataGridView> ListColonnesDataGrid;
        /// <summary>
        /// On ne pas Créer ce formulaire sans Paramétre
        /// </summary>
        private FormGestionTabPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creation du Formulaire de gestion des TabPages
        /// </summary>
        /// <param name="formulaire">Une instance de formulaire de saisie, il est utilisr 
        /// pour la creation des autres instance en cas d'édition des objet
        /// </param>
        public FormGestionTabPage(BaseFormUserControl formulaire, List<FormGestionTabPage.ColonneDataGridView> listColonnesDataGrid)
        {
            InitializeComponent();

            this.Formulaire = formulaire;
            this.Service = formulaire.Service;
            this.ListColonnesDataGrid = listColonnesDataGrid;
            this.ConfigDataGridView();
            this.setTitre();


        }

       
        /// <summary>
        /// Configuration de Titre du formulaire et le titre de Page Grid
        /// </summary>
        private void setTitre()
        {
            string NomObjets = Service.GetNomObjets();
            string NomObjet = Service.GetNomObjet();
            this.Text = "Gestion des " + NomObjets;
            TabPage tabGrid = this.tabControl.TabPages["TabGrid"];
            tabGrid.Text = NomObjets;
        }
        
        private void FormGestion_Load(object sender, EventArgs e)
        {
            this.Actualiser();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
                    }
    }
}
