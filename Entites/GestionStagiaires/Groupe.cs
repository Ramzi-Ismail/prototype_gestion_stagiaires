using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace App.GestionStagiaires
{
    public class Groupe : BaseEntity
    {
        
        public string Nom { set; get; }

        
        public virtual Filiere Filiere { set; get; }

        public override string GetNomObjets()
        {
            return "Groupes";
        }
        public override string ToString()
        {
            return this.Nom;
        }
    }
}
