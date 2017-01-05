using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.GestionProjets
{
    public partial class FormGestionProjets : Form
    {
        ProjetsService service = new ProjetsService();
        public FormGestionProjets()
        {
            InitializeComponent();
        }

        private void projetBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            service.SaveChanges();
        }

        private void FormGestionProjets_Load(object sender, EventArgs e)
        {
            projetBindingSource.DataSource = service.ToBindingList();

        }

        private void projetDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
