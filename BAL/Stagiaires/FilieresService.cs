using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionStagiaires
{
    public class FilieresService : BaseRepository<Filiere>
    {
        public FilieresService(DbContext context) : base(context)
        {

        }
        public FilieresService() : base()
        {

        }
    }
}
