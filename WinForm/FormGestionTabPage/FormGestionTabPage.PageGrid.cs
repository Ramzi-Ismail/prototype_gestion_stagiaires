
using System.Collections.Generic;
using System.Windows.Forms;

namespace App.WinForm
{
    partial class FormGestionTabPage
    {
       

        public void Actualiser()
        {
            Service.SaveChanges();
            ObjetBindingSource.Clear();
            List<object> ls =  Service.GetAllSansProxy();
            ObjetBindingSource.DataSource = ls;

        }

        private void ConfigDataGridView()
        {
            int index = 0;
            foreach (ColonneDataGridView item in this.ListColonnesDataGrid)
            {
                
                DataGridViewColumn colonne;
                index++;
                if (item.Type == ColonneDataGridView.TYPE_STRING) { 
                  colonne = new DataGridViewTextBoxColumn();
                }else if (item.Type == ColonneDataGridView.TYPE_DATATIME)
                {
                    colonne = new DataGridViewTextBoxColumn();
                }
                else
                {
                  colonne = new DataGridViewTextBoxColumn();
                }

                colonne.HeaderText =  item.Titre;
                colonne.DataPropertyName = item.Code;
                colonne.Name = item.Code;
                colonne.ReadOnly = true;
                this.dataGridView.Columns.Insert(index, colonne);
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
