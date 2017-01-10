
using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace App.WinForm
{
    partial class InterfaceGestion
    {
       

        public void Actualiser()
        {
            Service.SaveChanges();
            ObjetBindingSource.Clear();
            //  System.Type T = this.Formulaire.Entity.GetType();
            var ls = Service.GetAll();

            ObjetBindingSource.DataSource = ls;

        }

        private void ConfigDataGridView()
        {
              
            // Obtien la liste des PropertyInfo par ordrer d'affichage
            var listeProprite = from i in Service.TypeEntity.GetProperties()
                                where i.GetCustomAttribute(typeof(AffichageProprieteAttribute)) != null &&
                                ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).isGridView
                                orderby ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).Ordre
                                select i;

            int index_colonne = 0;
            foreach (PropertyInfo propertyInfo in listeProprite)
            {
                Attribute getAffichagePropriete = propertyInfo.GetCustomAttribute(typeof(AffichageProprieteAttribute));
                if (getAffichagePropriete == null) continue;
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)getAffichagePropriete;

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
           
        }
    }
}
