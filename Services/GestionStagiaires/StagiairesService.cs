using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionStagiaires
{
    public class StagiairesService : BaseRepository<Stagiaire>
    {
        public StagiairesService(ModelContext context) : base(context)
        {
        }
        public StagiairesService() : base()
        {
        }
    }
}
