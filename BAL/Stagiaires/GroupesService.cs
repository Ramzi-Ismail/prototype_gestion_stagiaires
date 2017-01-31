using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionStagiaires
{
    public class GroupesService : BaseRepository<Groupe>
    {
        public GroupesService(DbContext context) : base(context)
        {
        }
        public GroupesService() : base()
        {
        }

    }
}
