using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

  

namespace App.WinFrom.GestionBinfingNavigator
{
    public class FormGestionBindingNavigator<T> : Form where T: EFlib.Entites.BaseEntity
    {
        protected EFlib.BaseRepository<T> service;
        /// <summary>
        /// Nom de l'objet
        /// </summary>
        protected string NomObjet = "";
        protected BindingSource ObjetBindinSource;
        protected BindingNavigator ObjeBindingNavigator;
        protected ToolStripButton ObjetBindingNavigatorSaveItem;


        public FormGestionBindingNavigator()
        {
            
           this.Load += GestionBindingNavigator_Load;
        }

        private void GestionBindingNavigator_Load(object sender, EventArgs e)
        {
            service = new EFlib.BaseRepository<T>();
            service = Activator.CreateInstance<EFlib.BaseRepository<T>>();
            ObjetBindinSource.DataSource = service.ToBindingList();
            ObjetBindingNavigatorSaveItem.Click += ObjetBindingNavigatorSaveItem_Click;
        }

        private void ObjetBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Enregistrer();
        }


        /// <summary>
        /// Affichage de message de confirmation d'enregistrement dans une formulaire de gestion
        /// </summary>
        /// <param name="NombreInsertion"></param>
        /// <param name="NomObjet"></param>
        /// <param name="AffichageSiPasModification"></param>
        public  void Enregistrer()
        {

            int NombreInsertion = service.SaveChanges();



            if (NombreInsertion > 0)
            {
                MessageBox.Show("L'enregistrement des " + NomObjet + " a été bien fait", "Enregistrement des " + NomObjet);
            }
            else
            {
                MessageBox.Show("Il n'y a pas d'information à enregistrer", "Enregistrement des " + NomObjet);
            }

        }

       
    }
}
