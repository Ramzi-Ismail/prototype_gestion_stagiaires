using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Coordonnees
{
    public class Ville : BaseEntity
    {
        public string Nom { set; get; }

        public string Description { set; get; }

        public virtual Pays Pays { set; get; }
}
}
