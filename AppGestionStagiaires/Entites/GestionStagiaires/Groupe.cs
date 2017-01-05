using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFlib.Entites;
namespace App.Entites
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
