using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionProjets
{
    public class ProjetsService : BaseRepository<Projet>
    {
        public ProjetsService()
        {
        }

        public ProjetsService(ModelContext context) : base(context)
        {
        }
    }
}
