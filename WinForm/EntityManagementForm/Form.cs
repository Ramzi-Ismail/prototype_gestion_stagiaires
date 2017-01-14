using App.WinForm;
using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    public partial class EntityManagementForm : Form
    {
        #region Variables

        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IBaseRepository Service;


        /// <summary>
        /// Le formulaire de l'édition et d'insertion
        /// </summary>
        protected BaseEntryForm Formulaire;


        /// <summary>
        /// Obient ou définire la liste des propriété de l'entity en cours de gestion
        /// </summary>
        protected List<PropertyInfo> ListePropriete { set; get; }

        /// <summary>
        /// définir les valeurs initiaux du filtre
        /// </summary>
        Dictionary<string, object> ValeursFiltre { set; get; }
        #endregion

        #region Constructeur
        /// <summary>
        /// On ne pas Créer ce formulaire sans Paramétre
        /// ce Constructeur est ajouter seuelement pour supproer le mode désigne de Visual Studio 2015
        /// </summary>
        public EntityManagementForm()
        {
            InitializeComponent();
        }

       /// <summary>
       /// Création d'une gestion générique 
       /// </summary>
       /// <param name="service"></param>
        public EntityManagementForm(IBaseRepository service)
        {
            InitializeComponent();
            BaseEntryForm formulaire = new EntryForm(service);
            initParams(service, formulaire);
        }

        
        public EntityManagementForm(IBaseRepository service, Dictionary<string, object> ValeursFiltre)
        {
            InitializeComponent();
            BaseEntryForm formulaire = new EntryForm(service);
            this.ValeursFiltre = ValeursFiltre;
            initParams(service, formulaire);
        }

        /// <summary>
        /// Création d'une gestion avec une formulaire personalisé
        /// </summary>
        /// <param name="formulaire">Une instance de formulaire de saisie, il est utilisr 
        /// pour la creation des autres instance en cas d'édition des objet
        /// </param>
        public EntityManagementForm(IBaseRepository service, BaseEntryForm formulaire)
        {
            InitializeComponent();
            initParams(service, formulaire);
        }


        /// <summary>
        /// Applelet dans le construcreur , pour initialiser cette formulaire
        /// </summary>
        /// <param name="service"></param>
        /// <param name="formulaire"></param>
        protected void initParams(IBaseRepository service, BaseEntryForm formulaire)
        {
            this.Service = service;
            this.Formulaire = formulaire;
            this.Name = "Interface_Gestion_" + service.TypeEntity.ToString();
            this.InitListePropriete();
            this.initFiltre();
            this.InitDataGridView();
            this.setTitre();
        }

        /// <summary>
        /// Lecture de la liste des Propriété de l'entity à partire son annotation
        /// </summary>
        private void InitListePropriete()
        {
           var requete = from i in Service.TypeEntity.GetProperties()
                                where i.GetCustomAttribute(typeof(AffichageProprieteAttribute)) != null &&
                                ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).isGridView
                                orderby ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).Ordre
                                select i;
            ListePropriete = requete.ToList<PropertyInfo>();
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
            lbl_titre_gestion.Text = AffichageDansFormGestion.Titre;
        }
        #endregion

        #region EntityManagementForm Actions
        private void EntityManagementForm_Load(object sender, EventArgs e)
        {
            if(!DesignMode)
            this.Actualiser();
        }

       



        private void EntityManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Solution de problème de fermiture de la forme en cas de validation
            // car le formulaire ne veut pas se fermer si il y a des validation active dans 
            // le formilaire
            e.Cancel = false;
        }
        #endregion

       

        private void dataGridView_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            IEnumerable<BaseEntryForm> ls = tabControl.SelectedTab.Controls.OfType<BaseEntryForm>();
            if(ls.Count() == 1) {
            BaseEntryForm BaseEntryForm = ls.First();
            this.AcceptButton = BaseEntryForm.btEnregistrer;
            }

        }

       
    }
}
