using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionStagiaires
{
    public class FilieresService : BaseRepository<Filiere>
    {
        public FilieresService(ModelContext context) : base(context)
        {

        }
        public FilieresService() : base()
        {

        }
    }
}
