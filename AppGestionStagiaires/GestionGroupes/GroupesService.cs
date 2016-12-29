using Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionStagiaires.GestionGroupes
{
    public class GroupesService
    {
        ModelStagiaires db = new ModelStagiaires();
        public bool Ajouter(Groupe g)
        {
            db.Groupes.Add(g);
            return db.SaveChanges() > 0;
        }
        public Groupe RechercheParId(int id)
        {
            Groupe g = db.Groupes
                .Where(i => i.Id == id)
                .SingleOrDefault();
            return g;
        }
        public bool Supprimer(int id)
        {
            var g = db.Groupes.Find(id);
            db.Groupes.Remove(g);
            return db.SaveChanges() > 0;
        }
       
        public bool Update(Groupe g)
        {
            db.Groupes.Attach(g);
            db.Entry(g).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public List<Groupe> Recherche(int Id, string Nom, string Operation)
        {
                List<Groupe> groupes = db.Groupes.Where(g =>
                Operation == "AND" ?( (Id == g.Id) && ( Nom == g.Nom))
                    : ( (Id == g.Id) || (Nom == g.Nom))
              ) .ToList<Groupe>();
            return groupes;
        }

        public List<Groupe> Liste()
        {
            var query = from s in db.Groupes select s;
            return query.ToList<Groupe>();

        }


    }
}
