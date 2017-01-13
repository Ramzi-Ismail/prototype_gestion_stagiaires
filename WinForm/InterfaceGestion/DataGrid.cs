
using App.WinForm.Annotation;
using App.WinFrom.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace App.WinForm
{
    partial class InterfaceGestion
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
                if (propertyInfo.PropertyType.Name == "String" || propertyInfo.PropertyType.Name ==  "Integer") { 
                  colonne.ValueType = typeof(String);
                     
                }
                if (propertyInfo.PropertyType.Name == "DateTime")
                {
                    colonne = new DataGridViewTextBoxColumn();
                    colonne.ValueType = typeof(DateTime);
                }
                // Type Liste 
                if (propertyInfo.PropertyType.Name == "List`1")
                {

                    colonne = new DataGridViewButtonColumn();
                    colonne.ReadOnly = true;
                   
                }

               
                colonne.HeaderText = AffichagePropriete.Titre;
                colonne.DataPropertyName = propertyInfo.Name;
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
                    EditerCollection(item.Name);
                }
               
            }
            // Action sur les colonnes ManyToOne

           
        }

        /// <summary>
        /// Editer la collection ManyToOne
        /// </summary>
        /// <param name="name">Nom de la propriété</param>
        private void EditerCollection(string name)
        {
            AfficherForm Menu= new AfficherForm((Form)this.MdiParent);
            Menu.AfficherUneGestion<App.Modules.Precision>();

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
