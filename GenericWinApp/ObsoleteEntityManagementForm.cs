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
    public partial class ObsoleteEntityManagementForm : Form
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
        BaseFilterControl BaseFilterControl { set; get; }

        /// <summary>
        /// Instance de controle DataGrid
        /// </summary>
        EntityTabControl EntityManagerControl { set; get; }

        /// <summary>
        /// Le formulaire MDI de l'application
        /// il sert à afficher 
        /// </summary>
        Form FormApplicationMdi { set; get; }
        #endregion

        #region Constructeur
        /// <summary>
        /// On ne pas Créer ce formulaire sans Paramétre
        /// ce Constructeur est ajouter seuelement pour supproer le mode désigne de Visual Studio 2015
        /// </summary>
        [Obsolete]
        public ObsoleteEntityManagementForm()
        {
            InitializeComponent();

        }

        /// <summary>
        ///  Création d'une interface de gestion des entity 
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        /// <param name="formulaire">
        /// Le formulaire spécifique à l'objet Entity, 
        /// pour ne pas utiliser le formulaire générique
        /// </param>
        /// <param name="ValeursFiltre">Les valeurs de filtre</param>
        public ObsoleteEntityManagementForm(
            IBaseRepository Service, 
            BaseEntryForm formulaire, 
            Dictionary<string, object> ValeursFiltre,
            Form FormApplicationMdi)
        {
            InitializeComponent();
            this.Service = Service;
            this.ValeursFiltre = ValeursFiltre;
            this.FormApplicationMdi = FormApplicationMdi;
            // Création d'une instance de furmulaire générique 
            // si la formulaire spécifique est null
            this.Formulaire = formulaire;
            if (this.Formulaire == null)
                this.Formulaire = new EntryForm(this.Service);
           
          
            initControls();
        }

        /// <summary>
        /// Création d'une formulaire de gestion avec l'objet Service et 
        /// le formulaire générique
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        /// <param name="ValeursFiltre">Les valeurs de filtre</param>
        public ObsoleteEntityManagementForm(IBaseRepository Service, 
            Dictionary<string, object> ValeursFiltre,Form FormApplicationMdi)
            :this(Service, null, ValeursFiltre, FormApplicationMdi)
        {
        }


        /// <summary>
        /// Création d'une gestion des entity avec Une Instance de l'objet Service
        /// et la formulaire généique et sans valeurs de filtre
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        public ObsoleteEntityManagementForm(IBaseRepository Service, Form FormApplicationMdi) :this(Service, null,null, FormApplicationMdi)
        { 
        }


        /// <summary>
        /// Création d'une gestion avec une formulaire personalisé
        /// </summary>
        /// <param name="Formulaire">Une instance de formulaire de saisie, il est utilisr 
        /// pour la creation des autres instance en cas d'édition des objet
        /// </param>
        public ObsoleteEntityManagementForm(IBaseRepository Service, 
            BaseEntryForm Formulaire, Form FormApplicationMdi) :this(Service, Formulaire, null, FormApplicationMdi)
        {
        }

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialisation et Création des controles
        /// </summary>
        /// <param name="service"></param>
        /// <param name="formulaire"></param>
        protected void initControls()
        {
            //
            // Interface de gestion
            //
            AffichageDansFormGestionAttribute AffichageDansFormGestion = this.Service.getAffichageDansFormGestionAttribute();
            this.Name = "Interface_Gestion_" + this.Service.TypeEntity.ToString();
            this.Text = AffichageDansFormGestion.Titre;
            this.bt_Ajouter.Text = AffichageDansFormGestion.TitreButtonAjouter;
            lbl_titre_gestion.Text = AffichageDansFormGestion.Titre;

            //
            // Initialisation de filtre
            //
            this.BaseFilterControl = new BaseFilterControl(this.Service, this.ValeursFiltre);
            this.BaseFilterControl.Dock = DockStyle.Fill;
            this.panel_Filtre.Controls.Add(this.BaseFilterControl);
            this.BaseFilterControl.RefreshEvent += BaseFilterControl_RefreshEvent;

            //
            // Initialisation de DataGrid
            //
            this.EntityManagerControl = new EntityTabControl(
                this.Service, 
                this.BaseFilterControl, 
                this.FormApplicationMdi, 
                this.Formulaire);
            this.EntityManagerControl.Dock = DockStyle.Fill;
            this.panelDataGrid.Controls.Add(this.EntityManagerControl);
        }
        private void BaseFilterControl_RefreshEvent(object sender, EventArgs e)
        {
            this.Actualiser();
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
            this.RenomerTitrePage(this.BaseFilterControl.CritereRechercheFiltre());

        }
        public void bt_Ajouter_Click(object sender, EventArgs e)
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
