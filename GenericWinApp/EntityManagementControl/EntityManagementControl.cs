using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.WinForm.Annotation;
using App.WinForm.EntityManagement;
using System.Reflection;

namespace App.WinForm
{
    /// <summary>
    /// Interface de mise à jour d'une entity
    /// </summary>
    public partial class EntityManagementControl : UserControl
    {

        #region Propriétés
        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IBaseRepository Service { set; get; }

        /// <summary>
        /// Instance de filtre controle
        /// </summary>
        protected BaseFilterControl BaseFilterControl { set; get; }

        /// <summary>
        /// Le formulaire de l'édition et d'insertion
        /// </summary>
        protected BaseEntryForm Formulaire { set; get; }

        /// <summary>
        /// La formulaire MdiParent de l'application
        /// il est utiliser pour afficher une interface de gestion
        /// </summary>
        protected Form MdiParent { set; get; }


        /// <summary>
        /// Obient ou définire la liste des propriété de l'entity en cours de gestion
        /// </summary>
        protected List<PropertyInfo> ListePropriete { set; get; }

        /// <summary>
        /// définir les valeurs initiaux du filtre
        /// </summary>
        Dictionary<string, object> ValeursFiltre { set; get; }
        #endregion

        #region Controls
        /// <summary>
        /// L'objet Binding source la classe hérité
        /// </summary>
        protected BindingSource BaseObjetBindingSource { set; get; }

        /// <summary>
        /// L'objet DataGrid de la classe hérité
        /// </summary>
        protected DataGridView BaseDataGridView { set; get; }

        /// <summary>
        /// Le formulaire MDI de l'application
        /// il sert à afficher 
        /// </summary>
        Form FormApplicationMdi { set; get; }

        /// <summary>
        /// Instance de filter control
        /// </summary>
        public BaseFilterControl FilterControl { get; private set; }

        /// <summary>
        /// Instance de EntiteDataGridControl
        /// </summary>
        public EntityDataGridControl DataGridControl { get; private set; }
        #endregion

        #region Evénement
        public event EventHandler RefreshEvent;
        protected void onRefreshEvent(object sender, EventArgs e)
        {
            RefreshEvent(sender, e);
        }
        #endregion

        #region Constructeur
        /// <summary>
        ///  Création d'une interface de gestion des entity 
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        /// <param name="formulaire">
        /// Le formulaire spécifique à l'objet Entity, 
        /// pour ne pas utiliser le formulaire générique
        /// </param>
        /// <param name="ValeursFiltre">Les valeurs de filtre</param>
        public EntityManagementControl(
            IBaseRepository Service,
            BaseEntryForm Formulaire,
            BaseFilterControl FilterControl,
            EntityDataGridControl EntityDataGridControl,
            Dictionary<string, object> ValeursFiltre,
            Form FormApplicationMdi)
        {
            InitializeComponent();
            this.Service = Service;
            this.Formulaire = Formulaire;
            this.FilterControl = FilterControl;
            this.DataGridControl = EntityDataGridControl;
            this.ValeursFiltre = ValeursFiltre;
            this.FormApplicationMdi = FormApplicationMdi;

            initControls();
        }

        /// <summary>
        /// Création d'une formulaire de gestion avec l'objet Service et 
        /// le formulaire générique
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        /// <param name="ValeursFiltre">Les valeurs de filtre</param>
        public EntityManagementControl(IBaseRepository Service,
            Dictionary<string, object> ValeursFiltre, Form FormApplicationMdi)
            : this(Service, null,null,null, ValeursFiltre, FormApplicationMdi)
        {
        }


        /// <summary>
        /// Création d'une gestion des entity avec Une Instance de l'objet Service
        /// et la formulaire généique et sans valeurs de filtre
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        public EntityManagementControl(IBaseRepository Service, Form FormApplicationMdi) 
            : this(Service, null, null,null,null, FormApplicationMdi)
        {
        }


        /// <summary>
        /// Création d'une gestion avec une formulaire personalisé
        /// </summary>
        /// <param name="Formulaire">Une instance de formulaire de saisie, il est utilisr 
        /// pour la creation des autres instance en cas d'édition des objet
        /// </param>
        public EntityManagementControl(IBaseRepository Service,
            BaseEntryForm Formulaire, Form FormApplicationMdi) : this(Service, Formulaire,null,null, null, FormApplicationMdi)
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
            // Formulaire
            //
            if (this.Formulaire == null)
                this.Formulaire = new EntryForm(this.Service);

            //
            // Filtre
            //
            if(this.FilterControl == null)
            {
                this.BaseFilterControl = new BaseFilterControl(this.Service, this.ValeursFiltre);
            }
            this.BaseFilterControl.Dock = DockStyle.Fill;
            this.panel_Filtre.Controls.Add(this.BaseFilterControl);
            this.BaseFilterControl.RefreshEvent += BaseFilterControl_RefreshEvent;


            //
            // DataGrid
            //
            if (this.DataGridControl == null)
                this.DataGridControl = new EntityDataGridControl(this.Service, this.ValeursFiltre);
            this.DataGridControl.Dock = DockStyle.Fill;
            this.tabControl.TabPages["TabGrid"].Controls.Add(this.DataGridControl);
            this.DataGridControl.EditClick += EntityDataGridControl_EditClick;
            this.DataGridControl.EditManyToOneCollection += DataGridControl_EditManyToOneCollection;
            this.DataGridControl.EditManyToManyCollection += DataGridControl_EditManyToManyCollection;

            //
            // Modification des Titre 
            //
            AffichageDansFormGestionAttribute AffichageDansFormGestion = this.Service.getAffichageDansFormGestionAttribute();
            this.Name = "Interface_Gestion_" + this.Service.TypeEntity.ToString();
            this.Text = AffichageDansFormGestion.Titre;
            this.bt_Ajouter.Text = AffichageDansFormGestion.TitreButtonAjouter;
            lbl_titre_gestion.Text = AffichageDansFormGestion.Titre;
        }

 

        #endregion

        #region Actualiser
        /// <summary>
        /// Affichage des information dans DataGrid selon le filtre s'il exsiste
        /// </summary> 
        public void Actualiser()
        {
            this.DataGridControl.Actualiser(this.BaseFilterControl.CritereRechercheFiltre());
            this.RenomerTitrePage(this.BaseFilterControl.CritereRechercheFiltre());

        }
        #endregion

        #region Filtre
        private void BaseFilterControl_RefreshEvent(object sender, EventArgs e)
        {
            this.Actualiser();
        }
        #endregion

        #region DataGrid
        private void EntityDataGridControl_EditClick(object sender, EventArgs e)
        {
            BaseEntity entity = (BaseEntity) this.DataGridControl.SelectedEntity;
            string tabEditerName = "TabEditer-" + entity.Id;

            if (tabControl.TabPages.IndexOfKey(tabEditerName) == -1)
            {
                // Création de Tab
                TabPage tabEditer = new TabPage();
                tabEditer.Text = entity.ToString();
                tabEditer.Name = tabEditerName;
                tabControl.TabPages.Add(tabEditer);
                tabControl.CausesValidation = false;

                // Insertion du formulaire 
                BaseEntryForm form = Formulaire.CreateInstance(this.Service, entity, null);
                form.Name = "EntityForm";
                form.Dock = DockStyle.Fill;

                this.tabControl.TabPages[tabEditerName].Controls.Add(form);
                tabControl.SelectedTab = tabEditer;

                form.WriteEntityToField(this.BaseFilterControl.CritereRechercheFiltre());
                form.EnregistrerClick += Form_EditerClick;
                form.AnnulerClick += Form_AnnulerEditerClick;

            }
            else
            {
                TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
                tabControl.SelectedTab = tabEditer;
            }

        }
        private void Form_EditerClick(object sender, EventArgs e)
        {
            BaseEntryForm form = (BaseEntryForm)sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;


            TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
            // Suppression de la page Editer
            this.tabControl.TabPages.Remove(tabEditer);
            this.Actualiser();
        }

        private void Form_AnnulerEditerClick(object sender, EventArgs e)
        {
            BaseEntryForm form = (BaseEntryForm)sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;
            TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
            tabControl.TabPages.Remove(tabEditer);
        }

        /// <summary>
        /// Editer la collection ManyToOne
        /// </summary>
        private void DataGridControl_EditManyToOneCollection(object sender, EventArgs e)
        {
            BaseEntity obj = this.DataGridControl.SelectedEntity;
            PropertyInfo item = this.DataGridControl.SelectedProperty;

            // Obient le Service de l'objet de Collection<Objet>
            Type type_objet_of_collection = item.PropertyType.GetGenericArguments()[0];
            IBaseRepository service_objet_of_collection = this.Service.CreateInstance_Of_Service_From_TypeEntity(type_objet_of_collection);

            // Valeur Initial du Filtre
            Dictionary<string, object> ValeursFiltre = new Dictionary<string, object>();
            ValeursFiltre[item.DeclaringType.Name] = obj.Id;
            ObsoleteEntityManagementForm form = new ObsoleteEntityManagementForm(service_objet_of_collection, null, ValeursFiltre, this.MdiParent);

            // Affichage de Fomulaire de gestion de la collection ManytoOne
            //AfficherFormHelper Menu = new AfficherFormHelper((Form)this.MdiParent);
            //Menu.Afficher(form);
        }
        private void DataGridControl_EditManyToManyCollection(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

      
        #endregion

        #region Formulaire
        /// <summary>
        /// Boutton Ajouter un nouveau entité
        /// </summary>
        public void bt_Ajouter_Click(object sender, EventArgs e)
        {

            // Insertion de la page TabAjouter s'il n'existe pas
            if (tabControl.TabPages.IndexOfKey("TabAjouter") == -1)
            {
                // 
                // Création de TabPage - Ajouter 
                //
                TabPage tabAjouter = new TabPage();
                tabAjouter.Text = this.Service.getAffichageDansFormGestionAttribute().TitreButtonAjouter;
                tabAjouter.Name = "TabAjouter";
                tabControl.TabPages.Add(tabAjouter);
                tabControl.CausesValidation = false;

                //
                // Insertion du formulaire 
                //
                BaseEntity Entity = (BaseEntity)this.Service.CreateInstanceObjet();
                BaseEntryForm form = Formulaire.CreateInstance(Service, Entity, this.BaseFilterControl.CritereRechercheFiltre());
                form.Name = "Form";
                form.Dock = DockStyle.Fill;
                form.WriteEntityToField(this.BaseFilterControl.CritereRechercheFiltre());


                this.tabControl.TabPages["TabAjouter"].Controls.Add(form);
                tabControl.SelectedTab = tabAjouter;
                form.EnregistrerClick += Form_EnregistrerClick;
                form.AnnulerClick += Form_AnnulerAjouterClick;
            }
        }
        /// <summary>
        /// Enregistrer un Stagiaire
        /// </summary>
        private void Form_EnregistrerClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControl.TabPages["TabAjouter"];
            BaseEntryForm form = (BaseEntryForm)tabAjouter.Controls
                .Find("Form", false).First();
            this.tabControl.TabPages.Remove(tabAjouter);
            this.Actualiser();
        }
        /// <summary>
        /// Annuler l'insertion d'un stagiaire
        /// </summary>
        private void Form_AnnulerAjouterClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControl.TabPages["TabAjouter"];
            tabControl.TabPages.Remove(tabAjouter);
        }
       

        #endregion


        #region EntityManagementControl 

        private void EntityManagementForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                this.Actualiser();
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
