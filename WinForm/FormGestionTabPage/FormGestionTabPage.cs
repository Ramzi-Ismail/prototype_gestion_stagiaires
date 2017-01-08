using App.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    public partial class FormGestionTabPage : Form
    {
        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IBaseRepository Service;
        /// <summary>
        /// Le formulaire de l'édition et d'insertion
        /// </summary>
        protected FormUserControl Formulaire;

        /// <summary>
        /// Liste des colonnes à afficher dans le DataGridView
        /// </summary>
        public List<ColonneDataGridView> ListColonnesDataGrid;
        /// <summary>
        /// On ne pas Créer ce formulaire sans Paramétre
        /// </summary>
        public  FormGestionTabPage()
        {
            InitializeComponent();
        }


        Dictionary<string, string> Params;

       

        /// <summary>
        /// Creation du Formulaire de gestion des TabPages
        /// </summary>
        /// <param name="formulaire">Une instance de formulaire de saisie, il est utilisr 
        /// pour la creation des autres instance en cas d'édition des objet
        /// </param>
        public FormGestionTabPage(IBaseRepository service,FormUserControl formulaire, List<ColonneDataGridView> listColonnesDataGrid, Dictionary<string, string> Params)
        {
            InitializeComponent();
            initParams(service, formulaire, listColonnesDataGrid, Params);
        }
        protected void initParams(IBaseRepository service, FormUserControl formulaire, List<ColonneDataGridView> listColonnesDataGrid, Dictionary<string, string> Params)
        {
            this.Params = Params;
            this.Service = service;
            this.Formulaire = formulaire;
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
            this.Text = Params["TitreGestion"];
            this.bt_Ajouter.Text = Params["TitreButtonAjouter"];
            TabPage tabGrid = this.tabControl.TabPages["TabGrid"];
            tabGrid.Text = Params["TitrePageGrid"] ;
        }
        
        private void FormGestion_Load(object sender, EventArgs e)
        {
            if(!DesignMode)
            this.Actualiser();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
