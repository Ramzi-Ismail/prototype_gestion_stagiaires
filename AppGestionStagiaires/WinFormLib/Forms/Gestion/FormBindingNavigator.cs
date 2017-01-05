using EFlib;
using EFlib.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinFromLib.Forms.Gestion
{
    public partial class FormBindingNavigator  : Form
    {
        /// <summary>
        /// L'objet Service pour la manipulation de l'objet
        /// </summary>
        protected IBaseRepository Service;
        
        public FormBindingNavigator()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  Branchement de la base avec le formulaire actuel
        /// </summary>
        /// <param name="groupesService">l'objet Service</param>
        /// <param name="groupeDataGridView">DataGrid de l'objet </param>
        /// <param name="groupeBindingSource">Binding source</param>
        protected void InitBaseForm(IBaseRepository groupesService,DataGridView groupeDataGridView, BindingSource groupeBindingSource)
        {
            this.Service = groupesService;
            this.ObjetBindingSource = groupeBindingSource;
            this.ObjetBindingNavigator.BindingSource = this.ObjetBindingSource;
            groupeBindingSource.DataSource = this.Service.ToBindingList();

            groupeDataGridView.CellEndEdit += GroupeDataGridView_CellEndEdit;
            
           
        }

       
 

        private void GroupeDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.Enregistrer();
        }

  
        private void FormBindingNavigator_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Affichage de message de confirmation d'enregistrement dans une formulaire de gestion
        /// </summary>
        /// <param name="NombreInsertion"></param>
        /// <param name="NomObjet"></param>
        /// <param name="AffichageSiPasModification"></param>
        public void Enregistrer()
        {
            string NomInformation = Service.GetNomObjets();
            if (Service == null) throw new Exception("L'objet Service n'est instancié");

            int NombreInsertion = Service.SaveChanges();

            if (NombreInsertion > 0)
            {
                MessageBox.Show("L'enregistrement des " + NomInformation + " a été bien fait", "Enregistrement des " + NomInformation);
            }
            else
            {
                MessageBox.Show("Il n'y a pas d'information à enregistrer", "Enregistrement des " + NomInformation);
            }

        }
       

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.Enregistrer();
        }

        private void toolStripButtonEnregistrer_Click(object sender, EventArgs e)
        {
            this.Enregistrer();
        }
    }
}
