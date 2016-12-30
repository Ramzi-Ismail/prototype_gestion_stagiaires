using AppGestionStagiaires.GestionStagiaires;
using Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionStagiaires.GestionStagiaires
{
    public partial class FormBinfingNavigator : Form
    {
        ModelStagiaires context = new ModelStagiaires();

        public FormBinfingNavigator()
        {
            InitializeComponent();
        }

        private void FormBinfingNavigator_Load(object sender, EventArgs e)
        {
            // context.Stagiaires.Load();
            stagiaireBindingSource.DataSource = new BindingList<Stagiaire> (context.Stagiaires.ToList());
                //context.Stagiaires.Local.ToBindingList();
        }

        private void stagiaireBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
          
        }

        private void stagiaireBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            foreach (var s in context.Stagiaires.Local.ToList())
            {
              
                
                    MessageBox.Show(context.Entry(s).State.ToString());
                   
                
            }

            context.SaveChanges();
        }

        private void FormBinfingNavigator_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Dispose();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Stagiaire s = new Stagiaire();
            context.Stagiaires.Add();
        }
    }
}
