using App.GestionStagiaires;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.GestionStagiaires
{
    public partial class FormBinfingNavigator : Form
    {
        StagiairesService service = new StagiairesService();

        public FormBinfingNavigator()
        {
            InitializeComponent();
        }

        private void FormBinfingNavigator_Load(object sender, EventArgs e)
        {
            stagiaireBindingSource.DataSource = service.ToBindingList();

        }

        private void stagiaireBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
          
        }

        private void stagiaireBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            service.SaveChanges();
        }

        private void FormBinfingNavigator_FormClosed(object sender, FormClosedEventArgs e)
        {
            service.Dispose();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
        }

        private void stagiaireDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
