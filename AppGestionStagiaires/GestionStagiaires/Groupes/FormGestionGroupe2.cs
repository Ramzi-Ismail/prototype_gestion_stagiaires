using App.GestionFormations;
using App.WinFromLib.Forms.Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App.GestionStagiaires.Groupes
{
    public partial class FormGestionGroupe2 : FormBindingNavigator
    {
        public FormGestionGroupe2()
        {
            InitializeComponent();

            DataGridView groupeDataGridView = (DataGridView) this.Controls.Find("groupeDataGridView", true)[0];
            
            this.InitBaseForm(new FormateursService(), groupeDataGridView, groupeBindingSource);
            ColonneFiliere.DataSource =     new FilieresService().GetAll();

            groupeDataGridView.VirtualMode = true;





        }

      

        private void groupeDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void groupeDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void groupeDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void groupeDataGridView_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
           
        }
    }
}
