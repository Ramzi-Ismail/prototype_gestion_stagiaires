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
    public partial class FormBindingNavigator_old<T> : Form  
    {
        /// <summary>
        /// L'objet Service pour la manipulation de l'objet
        /// </summary>
        protected BaseRepository<BaseEntity> Service;
        /// <summary>
        /// Le nom de l'objet miniscule
        /// </summary>
        protected string NomMinisculeObjet = "";
        protected string NomPlurielObjet = "";
        public FormBindingNavigator_old() 
        {
            InitializeComponent();
        }

        /// <summary>
        /// Affichage de message de confirmation d'enregistrement dans une formulaire de gestion
        /// </summary>
        /// <param name="NombreInsertion"></param>
        /// <param name="NomObjet"></param>
        /// <param name="AffichageSiPasModification"></param>
        public void Enregistrer()
        {
            if (Service == null)  throw new Exception("L'objet Service n'est instancié");

            int NombreInsertion = Service.SaveChanges();

            if (NombreInsertion > 0)
            {
                MessageBox.Show("L'enregistrement des " + NomPlurielObjet + " a été bien fait", "Enregistrement des " + NomPlurielObjet);
            }
            else
            {
                MessageBox.Show("Il n'y a pas d'information à enregistrer", "Enregistrement des " + NomPlurielObjet);
            }

        }
    }
}
