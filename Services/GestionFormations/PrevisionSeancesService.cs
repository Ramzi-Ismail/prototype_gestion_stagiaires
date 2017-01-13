using App.Formations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionFormations
{
    public class PrevisionSeancesService : BaseRepository<PrevisionSeance>
    {
        public PrevisionSeancesService():base()
        {
        }

        public PrevisionSeancesService(ModelContext context) : base(context)
        {
        }

        public override int Save(PrevisionSeance item)
        {
            // Calcule de l'ordre dans le cas d'insertoin
            if(item.Ordre == 0) { 
                int ordre = this.DbSet.Where(p => p.Module.Id == item.Module.Id).Count();
                item.Ordre = ++ordre;
            }
            return base.Save(item);
        }

    }
}
