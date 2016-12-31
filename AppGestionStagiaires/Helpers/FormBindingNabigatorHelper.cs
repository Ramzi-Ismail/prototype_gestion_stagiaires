using Cplus.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cplus
{
    public class FormBindingNavigatorHelper<T>  where T : BaseEntity
    {
        /// <summary>
        /// Affichage de message de confirmation d'enregistrement dans une formulaire de gestion
        /// </summary>
        /// <param name="NombreInsertion"></param>
        /// <param name="NomObjet"></param>
        /// <param name="AffichageSiPasModification"></param>
        public static void Enregistrer(BaseRepository<T> Service,string NomObjet)
        {

            int NombreInsertion = Service.SaveChanges();
            


            if (NombreInsertion > 0) {
                MessageBox.Show("L'enregistrement des " + NomObjet + " a été bien fait", "Enregistrement des " + NomObjet);
            } else {
                MessageBox.Show("Il n'y a pas d'information à enregistrer", "Enregistrement des " + NomObjet);
            } 

        }
    }
}
