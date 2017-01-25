using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using App.WinForm.Annotation;

namespace App.WinForm
{
    public partial class EntityDataGridControl : UserControl, IEntityDataGrideControl
    {


        #region Propriétés
        /// <summary>
        /// Le service de l'entité en gestion  
        /// </summary>
        protected IBaseRepository Service { set; get; }


        /// <summary>
        /// Critère de filtre de recherche
        /// </summary>
        protected Dictionary<string, object> CritereRechercheFiltre { set; get; }

        /// <summary>
        /// Obient ou définire la liste des propriété de l'entity en cours de gestion
        /// </summary>
        protected List<PropertyInfo> ListePropriete { set; get; }
        #endregion


        #region Evénement
        /// <summary>
        /// Lancer aprés un click sur éditer
        /// </summary>
        public event EventHandler EditClick;
        protected void onEditClick(object sender, EventArgs e)
        {
            if (EditClick != null)
                EditClick(sender, e);
        }

        public event EventHandler EditManyToOneCollection;
        protected void onEditManyToOneCollection(object sender, EventArgs e)
        {
            
            if (EditManyToOneCollection != null)
                EditManyToOneCollection(sender, e);
        }

        
        public event EventHandler EditManyToManyCollection;
        protected void onEditManyToManyCollection(object sender, EventArgs e)
        {

            if (EditManyToManyCollection != null)
                EditManyToManyCollection(sender, e);
        }


        public event EventHandler RefreshEvent;
        

        protected void onRefreshEvent(object sender, EventArgs e)
        {
            RefreshEvent(sender, e);
        }


        #endregion


        #region Constructeurs

        public EntityDataGridControl(IBaseRepository Service, Dictionary<string, object> critereRechercheFiltre = null) 
        {
            InitializeComponent(); if (this.DesignMode) return;
            this.Service = Service;
            this.CritereRechercheFiltre = critereRechercheFiltre;
            InitDataGridView();
        }
        public EntityDataGridControl() : this(null) { }
        #endregion


        #region Actualiser
        /// <summary>
        /// Affichage des information dans DataGrid selon le filtre s'il exsiste
        /// </summary> 
        public void Actualiser()
        {
            this.Actualiser(this.CritereRechercheFiltre);
        }
        public void Actualiser(Dictionary<string, object> CritereRechercheFiltre)
        {
            ObjetBindingSource.Clear();
            var ls = Service.Recherche(CritereRechercheFiltre);
            ObjetBindingSource.DataSource = ls;
        }

        #endregion

        #region InitDisingeDataGrid

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

        /// <summary>
        /// Insertion des colonne selon les annotation : AffichageProprieteAttribute
        /// </summary>
        private void InitDataGridView()
        {
            InitPropertyListDataGrid();

            int index_colonne = 0;
            AffichageDansFormGestionAttribute AffichageDansFormGestion = this.Service.getAffichageDansFormGestionAttribute();
            foreach (PropertyInfo propertyInfo in this.ListePropriete)
            {
                if (propertyInfo.Name == "Ordre" && !AffichageDansFormGestion.siAffichageAvecOrdre)
                    continue;

                // Trouver l'objet AffichagePropriete depuis l'annotation
                Attribute getAffichagePropriete = propertyInfo.GetCustomAttribute(typeof(AffichageProprieteAttribute));
                if (getAffichagePropriete == null) continue;
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)getAffichagePropriete;

                // Insertion des la colonne selon le tupe de la propriété
                DataGridViewColumn colonne = new DataGridViewTextBoxColumn(); ;
                index_colonne++;

                switch (propertyInfo.PropertyType.Name)
                {
                    case "String":
                        {
                            colonne.ValueType = typeof(String);
                            colonne.DataPropertyName = propertyInfo.Name;
                        }
                        break;
                    case "Integer":
                        {
                            colonne.ValueType = typeof(String);
                            colonne.DataPropertyName = propertyInfo.Name;
                        }
                        break;
                    case "DateTime":
                        {
                            colonne = new DataGridViewTextBoxColumn();
                            colonne.ValueType = typeof(DateTime);
                            colonne.DataPropertyName = propertyInfo.Name;
                        }
                        break;
                    case "List`1":
                        {
                            DataGridViewButtonColumn c = new DataGridViewButtonColumn();
                            c.UseColumnTextForButtonValue = true;
                            c.Text = propertyInfo.Name;
                            colonne = c;
                            colonne.ReadOnly = true;
                        }
                        break;
                    default:
                        {
                            colonne.DataPropertyName = propertyInfo.Name;
                        }
                        break;
                }


                colonne.HeaderText = AffichagePropriete.Titre;

                colonne.Name = propertyInfo.Name;
                colonne.ReadOnly = true;
                if (AffichagePropriete.WidthColonne != 0) colonne.Width = AffichagePropriete.WidthColonne;
                this.dataGridView.Columns.Insert(index_colonne, colonne);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BaseEntity obj = (BaseEntity)ObjetBindingSource.Current;
            // Supprimer
            if (e.ColumnIndex == dataGridView.Columns["Supprimer"].Index && e.RowIndex >= 0)
            {
                if (DialogResult.Yes == MessageBox.Show(
                    "Voullez-vous vraimment supprimer :" + obj.ToString(),
                    "Confirmation de supprision", MessageBoxButtons.YesNo))
                {
                    this.Service.Delete(obj);
                    this.Actualiser();
                }
            }
            // Editer
            if (e.ColumnIndex == dataGridView.Columns["Editer"].Index && e.RowIndex >= 0)
            {
                onEditClick(this, null);
            }

            foreach (var item in this.ListePropriete.Where(p => p.PropertyType.Name == "List`1"))
            {
                if (e.ColumnIndex == dataGridView.Columns[item.Name].Index && e.RowIndex >= 0)
                {
                    this.SelectedProperty = item;
                    onEditManyToOneCollection(this, e);
                }

            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                onEditClick(this, null);
            }
        }

        #endregion


        public BaseEntity SelectedEntity
        {

            get
            {
                return this.ObjetBindingSource.Current as BaseEntity;
            }
        }
       

        public PropertyInfo SelectedProperty { set; get; }
        
    }
}
