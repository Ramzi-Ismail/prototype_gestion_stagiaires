using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Projet  :BaseEntity
    {
         
        public string Titre { set; get; }
        public string Description { set; get; }

        public virtual List<Tache> Taches { set; get; }

    }
}
