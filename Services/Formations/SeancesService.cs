using App.Formations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionFormations
{
   public class SeancesService : BaseRepository<Seance>
    {
        public SeancesService():base()
        {
        }

        public SeancesService(ModelContext context) : base(context)
        {
        }

        public override int Save(Seance item)
        {
            // Calcule de l'ordre dans le cas d'insertoin
            if (item.Ordre == 0)
            {
                int ordre = this.DbSet.Where(p => p.Formation.Id == item.Formation.Id).Count();
                item.Ordre = ++ordre;
            }
            return base.Save(item);
        }
    }
}
