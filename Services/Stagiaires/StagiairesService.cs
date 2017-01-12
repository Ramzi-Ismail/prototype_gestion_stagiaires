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

        public List<Stagiaire> Recherche(string NomObjet,int value)
        {
            //var query = from s in this.DbSet
            //            where s.
            //            select s;

            List < Stagiaire > ls = this.GetAll(0, 0, s => s.Filiere.Id == 1).ToList<Stagiaire>();
            return ls;
        }

    }
}
