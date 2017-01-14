
using App.WinForm.Annotation;
using App.WinFrom.Menu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace App.WinForm
{
    partial class EntityManagementForm
    {
        /// <summary>
        /// Insertion des colonne selon les annotation : AffichageProprieteAttribute
        /// </summary>
        private void InitDataGridView()
        {
            int index_colonne = 0;
            AffichageDansFormGestionAttribute AffichageDansFormGestion = this.Service.getAffichageDansFormGestionAttribute();
            foreach (PropertyInfo propertyInfo in this.ListePropriete)
            {
                if (propertyInfo.Name == "Ordre" &&  !AffichageDansFormGestion.siAffichageAvecOrdre)
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
                if(AffichagePropriete.WidthColonne!= 0) colonne.Width = AffichagePropriete.WidthColonne;
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
                    this.Service.Supprimer(obj);
                    this.Actualiser();
                }
            }
            // Editer
            if (e.ColumnIndex == dataGridView.Columns["Editer"].Index && e.RowIndex >= 0)
            {
                EditerObjet();
            }

            foreach (var item in this.ListePropriete.Where(p=>p.PropertyType.Name == "List`1"))
            {
                if (e.ColumnIndex == dataGridView.Columns[item.Name].Index && e.RowIndex >= 0)
                {
                    EditerCollection(item, obj);
                }
               
            }
        }

        /// <summary>
        /// Editer la collection ManyToOne
        /// </summary>
        /// <param name="name">Nom de la propriété</param>
        private void EditerCollection(PropertyInfo item,BaseEntity obj)
        {
            //IList ls = item.GetValue(obj) as IList;
            Type type_objet = item.PropertyType.GetGenericArguments()[0];
            AfficherForm Menu= new AfficherForm((Form)this.MdiParent);
            IBaseRepository service_objet = this.Service.CreateInstance_Of_Service_From_TypeEntity(type_objet);

            // Valeur Initial du Filtre
            Dictionary<string, object> ValeursFiltre = new Dictionary<string, object>();
            ValeursFiltre[item.DeclaringType.Name] = obj.Id;
            EntityManagementForm form = new EntityManagementForm(service_objet, ValeursFiltre);
            Menu.Afficher(form);
        }
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditerObjet();
            }
        }
    }
}
