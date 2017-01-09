using App.GestionStagiaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Formations
{
    public class Formateur: Utilisateur
    {
        public virtual Filiere Filiere { set; get; }

        public override string GetNomObjets()
        {
            return "Formateurs";
        }
        public override string GetNomObjet()
        {
            return "Formateur";
        }
        public override string ToString()
        {
            return this.Nom + " " + this.Prenom;
        }
    }
}
