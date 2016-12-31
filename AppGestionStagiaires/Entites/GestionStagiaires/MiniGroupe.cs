using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cplus.Entites
{
    public class MiniGroupe  : BaseEntity
    {
        public virtual List<Stagiaire> Stagiaires { set; get; }
    }
}
