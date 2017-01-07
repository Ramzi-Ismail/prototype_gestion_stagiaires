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
    public partial class FormGestionFilieres : Form
    {
        FilieresService service = new FilieresService(new ModelContext());
        public FormGestionFilieres()
        {
            InitializeComponent();
        }
        private void Enregistrer()
        {
            FormBindingNavigatorHelper<Filiere>.Enregistrer(service,"Filieres");
        }

        private void filiereBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Enregistrer();
        }

        private void FormGestionFilieres_Load(object sender, EventArgs e)
        {
            filiereBindingSource.DataSource = service.ToBindingList();
        }

        private void filiereDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
            
        }

        private void FormGestionFilieres_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void filiereDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.Enregistrer();
        }

        private void filiereDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
