using App.WinForm;
using App.WinForm.Annotation;
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
    public partial class InterfaceGestion : Form
    {

        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IBaseRepository Service;
        /// <summary>
        /// Le formulaire de l'édition et d'insertion
        /// </summary>
        protected BaseFormulaire Formulaire;

      
        /// <summary>
        /// On ne pas Créer ce formulaire sans Paramétre
        /// ce Constructeur est ajouter seuelement pour supproer le mode désigne de Visual Studio 2015
        /// </summary>
        public  InterfaceGestion()
        {
            InitializeComponent();
        }

       /// <summary>
       /// Création d'une gestion générique 
       /// </summary>
       /// <param name="service"></param>
        public InterfaceGestion(IBaseRepository service)
        {
            InitializeComponent();
            BaseFormulaire formulaire = new FormulaireControle(service);
            initParams(service, formulaire);
        }
        /// <summary>
        /// Création d'une gestion avec une formulaire personalisé
        /// </summary>
        /// <param name="formulaire">Une instance de formulaire de saisie, il est utilisr 
        /// pour la creation des autres instance en cas d'édition des objet
        /// </param>
        public InterfaceGestion(IBaseRepository service, BaseFormulaire formulaire)
        {
            InitializeComponent();
            initParams(service, formulaire);
        }

        protected void initParams(IBaseRepository service, BaseFormulaire formulaire)
        {
            this.Service = service;
            this.Formulaire = formulaire;
            this.Name = "Interface_Gestion_" + service.TypeEntity.ToString();
            this.ConfigDataGridView();
            this.setTitre();
        }

        /// <summary>
        /// Configuration de Titre du formulaire et le titre de Page Grid
        /// </summary>
        private void setTitre()
        {
            AffichageDansFormGestionAttribute AffichageDansFormGestion = this.Service.getAffichageDansFormGestionAttribute();
            this.Text = AffichageDansFormGestion.Titre;
            this.bt_Ajouter.Text = AffichageDansFormGestion.TitreButtonAjouter;
            TabPage tabGrid = this.tabControl.TabPages["TabGrid"];
            tabGrid.Text = AffichageDansFormGestion.TitrePageGridView;
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
