using App.WinForm;
using App.WinForm.Annotation;
using App.WinForm.EntityManagement;
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
        #region Propriétés
        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IBaseRepository Service { set; get; }

        /// <summary>
        /// Le formulaire de l'édition et d'insertion
        /// </summary>
        protected BaseEntryForm Formulaire { set; get; }

        /// <summary>
        /// définir les valeurs initiaux du filtre
        /// </summary>
        Dictionary<string, object> ValeursFiltre { set; get; }
        #endregion

        #region Controls
        /// <summary>
        /// Instance de filtre
        /// </summary>
        FiltreControl FiltreControl { set; get; }

        /// <summary>
        /// Instance de controle DataGrid
        /// </summary>
        EntityManagerControl EntityManagerControl { set; get; }
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

        #endregion

        #region Initialisation

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

            //
            // Initialisation de filtre
            //
            this.FiltreControl = new FiltreControl(this.Service, this.ValeursFiltre);
            this.FiltreControl.Dock = DockStyle.Fill;
            this.panel_Filtre.Controls.Add(this.FiltreControl);
            this.FiltreControl.RefreshEvent += FiltreControl_RefreshEvent;

            //
            // Initialisation de DataGrid
            //
            this.EntityManagerControl = new EntityManagerControl(
                this.Service, 
                this.FiltreControl, 
                this.MdiParent, 
                this.Formulaire);
            this.EntityManagerControl.Dock = DockStyle.Fill;
            this.panelDataGrid.Controls.Add(this.EntityManagerControl);
     
            // Afficher le titre de la gestion
            this.setTitre();
        }

        private void FiltreControl_RefreshEvent(object sender, EventArgs e)
        {
            this.Actualiser();
        }

      

        /// <summary>
        /// Configuration de Titre du formulaire et le titre de Page Grid
        /// </summary>
        private void setTitre()
        {
            AffichageDansFormGestionAttribute AffichageDansFormGestion = this.Service.getAffichageDansFormGestionAttribute();
            this.Text = AffichageDansFormGestion.Titre;
            this.bt_Ajouter.Text = AffichageDansFormGestion.TitreButtonAjouter;
            lbl_titre_gestion.Text = AffichageDansFormGestion.Titre;
        }
        #endregion

        #region EntityManagementForm Load
        private void EntityManagementForm_Load(object sender, EventArgs e)
        {
            if(!DesignMode)
            this.Actualiser();
        }
        /// <summary>
        /// Affichage des information dans DataGrid selon le filtre s'il exsiste
        /// </summary> 
        public void Actualiser()
        {
            this.EntityManagerControl.Actualiser();
            this.RenomerTitrePage(this.FiltreControl.CritereRechercheFiltre());

        }
        protected void bt_Ajouter_Click(object sender, EventArgs e)
        {
            this.EntityManagerControl.bt_Ajouter_Click(sender, e);
        }
        private void EntityManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Solution de problème de fermiture de la forme en cas de validation
            // car le formulaire ne veut pas se fermer si il y a des validation active dans 
            // le formilaire
            e.Cancel = false;
        }
        protected void RenomerTitrePage(Dictionary<string, object> critereRechercheFiltre)
        {
            // Renommer le Titre de la page
            lbl_titre_gestion.Text = this.Text;
            if (critereRechercheFiltre != null && critereRechercheFiltre.Count() > 0)
            {
                lbl_titre_gestion.Text += " par ( ";
                lbl_titre_gestion.Text += string.Join(",", critereRechercheFiltre.Select(d => d.Key));
                lbl_titre_gestion.Text += " )";
            }

        }
        #endregion
    }
}
