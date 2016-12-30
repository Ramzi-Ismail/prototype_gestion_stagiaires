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

namespace AppGestionStagiaires.GestionProjets
{
    public partial class FormGestionProjets : Form
    {
        ProjetsService service;
        public FormGestionProjets()
        {
            InitializeComponent();
        }

        private void FormGestionProjets_Load(object sender, EventArgs e)
        {
            service = new ProjetsService();
            service.Context.Projets.Load();
            projetBindingSource.DataSource = service.Context.Projets.Local.ToBindingList();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
          //  service.Context.Projets.Local.Add(new Projet());
        }

        private void projetBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            service.SaveChanges();
        }
    }
}
