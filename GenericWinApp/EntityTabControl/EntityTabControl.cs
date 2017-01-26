using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace App.WinForm.EntityManagement
{
    public partial class EntityTabControl : App.WinForm.EntityManagement.BaseEntityTabControl
    {
        #region Constructeurs
        public EntityTabControl()
        {
            InitializeComponent();
        }

        public EntityTabControl(IBaseRepository Service, 
            EntityFilterControl BaseFilterControl, Form MdiParent, BaseEntryForm Formulaire) :base(Service, BaseFilterControl, MdiParent, Formulaire)
        {
            InitializeComponent();
            InitDataGridView();
            setTitre();
        }
        #endregion

        #region Form_Load
        /// <summary>
        /// Affichage des information dans DataGrid selon le filtre s'il exsiste
        /// </summary> 
        public void Actualiser()
        {
            ObjetBindingSource.Clear();
            Dictionary<string, object> critereRechercheFiltre = this.BaseFilterControl.CritereRechercheFiltre();
            var ls = Service.Recherche(critereRechercheFiltre);
            ObjetBindingSource.DataSource = ls;
        }

        protected void setTitre()
        {
            AffichageDansFormGestionAttribute AffichageDansFormGestion = this.Service.getAffichageDansFormGestionAttribute();
            this.Text = AffichageDansFormGestion.Titre;
            TabPage tabGrid = this.tabControl.TabPages["TabGrid"];
            tabGrid.Text = AffichageDansFormGestion.TitrePageGridView;
  
        }
        #endregion


        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            IEnumerable<BaseEntryForm> ls = tabControl.SelectedTab.Controls.OfType<BaseEntryForm>();
            if (ls.Count() == 1)
            {
                BaseEntryForm BaseEntryForm = ls.First();
               this.ParentForm.AcceptButton = BaseEntryForm.btEnregistrer;
            }

        }


        #region InitDisingeDataGrid


        /// <summary>
        /// Insertion des colonne selon les annotation : AffichageProprieteAttribute
        /// </summary>
        private void InitDataGridView()
        {
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
                EditerObjet();
            }

            foreach (var item in this.ListePropriete.Where(p => p.PropertyType.Name == "List`1"))
            {
                if (e.ColumnIndex == dataGridView.Columns[item.Name].Index && e.RowIndex >= 0)
                {
                    EditerCollection(item, obj);
                }

            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditerObjet();
            }
        }
        #endregion

     


    }
}
