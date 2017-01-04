using App.Entites;
using App.WinFrom.GestionBinfingNavigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.GestionStagiaires.Groupes
{
    public partial class FormGestionGroupes : FormGestionBindingNavigator<Groupe>
    {
        public FormGestionGroupes()
        {
            InitializeComponent();
            this.NomObjet = "Groupe";
            ObjetBindinSource = this.groupeBindingSource;
            ObjeBindingNavigator = this.groupeBindingNavigator;
            ObjetBindingNavigatorSaveItem = this.groupeBindingNavigatorSaveItem;
        }

        private void FormGestionGroupes_Load(object sender, EventArgs e)
        {

        }

        private void groupeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
           
           
        }

        private void bindingNavigatorAddNewItem_OwnerChanged(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.service.AddElement();
            this.Enregistrer();
        }

        private void groupeBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
           
        }
    }
}
