using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionProjets
{
    public class TachesService : BaseRepository<Tache>
    {
        public TachesService()
        {
        }

        public TachesService(ModelContext context) : base(context)
        {
        }
    }
}
