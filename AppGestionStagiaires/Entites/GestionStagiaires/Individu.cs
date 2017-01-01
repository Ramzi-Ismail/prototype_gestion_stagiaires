using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cplus.Entites
{
    public class Individu : BaseEntity
    {
        // Etat Civil
        public String Nom { set; get; }
        public String Prenom { set; get; }
        public DateTime DateNaissance { set; get; }
        public bool Sexe { set; get; }
        public String Cin { set; get; }
        public String ProfilImage { set; get; }

        // Coordonnées
        public String Email { set; get; }
        public String Telephone { set; get; }
        public String Adress { set; get; }

        public Individu()
        {
            this.DateNaissance = DateTime.Now.AddYears(-23);
        }
    }
}
