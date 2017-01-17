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
using System.Reflection;
using App.WinFrom.Menu;

namespace App.WinForm.EntityManagement
{
    public partial class BaseEntityManagerControl : UserControl
    {

        #region Propriétés
        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IBaseRepository Service { set; get; }

        /// <summary>
        /// Instance de filtre controle
        /// </summary>
        protected FiltreControl FiltreControl { set; get; }

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
        #endregion

        #region Evénement
        public event EventHandler RefreshEvent;
        protected void onRefreshEvent(object sender, EventArgs e)
        {
            RefreshEvent(sender, e);
        }
        #endregion

        #region Constructeur
        public BaseEntityManagerControl()
        {
            InitializeComponent();
            
        }
        public BaseEntityManagerControl(IBaseRepository Service,FiltreControl FiltreControl,Form MdiParent, BaseEntryForm Formulaire)
        {
            InitializeComponent();
            this.Service = Service;
            this.FiltreControl = FiltreControl;
            this.MdiParent = MdiParent;
            this.Formulaire = Formulaire;
            InitPropertyListDataGrid();
        }

        protected void InitPropertyListDataGrid()
        {
            // [Bug]
            // Ajoutez la condition filtre 
            var requete = from i in Service.TypeEntity.GetProperties()
                          where i.GetCustomAttribute(typeof(AffichageProprieteAttribute)) != null &&
                          ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).isGridView
                          orderby ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).Ordre
                          select i;
            this.ListePropriete = requete.ToList<PropertyInfo>();
        }

        #endregion

        #region Load
    
        #endregion

        #region Editer une liste ManyToManu
        /// <summary>
        /// Editer la collection ManyToOne
        /// </summary>
        /// <param name="name">Nom de la propriété</param>
        protected void EditerCollection(PropertyInfo item, BaseEntity obj)
        {
            //IList ls = item.GetValue(obj) as IList;
            Type type_objet = item.PropertyType.GetGenericArguments()[0];
            AfficherForm Menu = new AfficherForm((Form)this.MdiParent);
            IBaseRepository service_objet = this.Service.CreateInstance_Of_Service_From_TypeEntity(type_objet);

            // Valeur Initial du Filtre
            Dictionary<string, object> ValeursFiltre = new Dictionary<string, object>();
            ValeursFiltre[item.DeclaringType.Name] = obj.Id;
            EntityManagementForm form = new EntityManagementForm(service_objet, ValeursFiltre);
            Menu.Afficher(form);
        }
        #endregion
 

    }
}
