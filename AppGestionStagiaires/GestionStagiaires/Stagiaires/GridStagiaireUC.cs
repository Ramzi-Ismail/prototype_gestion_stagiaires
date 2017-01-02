using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cplus.Entites;
using Cplus.Gestion;

namespace Cplus.GestionStagiaires
{
    public partial class GridStagiaireUC : BaseGridUC
    {
        public GridStagiaireUC()
        {
            InitializeComponent();
         
        }

        

       
        public override BaseEntity Current()
        {
            return (Stagiaire) stagiaireBindingSource.Current;
        }

        public override void Actualiser()
        {
            stagiaireBindingSource.Clear();
            stagiaireBindingSource.DataSource = new StagiairesService().GetAll();

        }
        private void GridStagiaireUC_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewStagiaires_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Supprimer
            if (e.ColumnIndex == dataGridViewStagiaires.Columns["Supprimer"].Index && e.RowIndex >= 0)
            {

                if (DialogResult.Yes == MessageBox.Show(
                    "Voullez-vous vraimment supprimer ce stagiaire",
                    "Confirmation de supprision", MessageBoxButtons.YesNo))
                {
                    Stagiaire s = (Stagiaire)stagiaireBindingSource.Current;
                    new StagiairesService().Delete(s);
                    this.Actualiser();
                }

            }
            // Editer
            if (e.ColumnIndex == dataGridViewStagiaires.Columns["Editer"].Index && e.RowIndex >= 0)
            {
                onEditerEvent(sender, e);
            }
        }

        private void dataGridViewStagiaires_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
