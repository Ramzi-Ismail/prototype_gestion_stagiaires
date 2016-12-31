using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cplus.Entites
{
    public class Tache : BaseEntity 
    {
        public string Titre { set; get; }
        public string Description { set; get; }
        public virtual Projet Projet {set;get;}
 
    }
}
