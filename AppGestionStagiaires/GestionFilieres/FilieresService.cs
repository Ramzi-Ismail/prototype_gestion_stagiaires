using Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionStagiaires.GestionFilieres
{
    public class FilieresService
    {
        ModelStagiaires db = new ModelStagiaires();
        public bool Ajouter(Filiere g)
        {
            db.Filieres.Add(g);
            return db.SaveChanges() > 0;
        }
        public Filiere RechercheParId(int id)
        {
            Filiere g = db.Filieres
                .Where(i => i.Id == id)
                .SingleOrDefault();
            return g;
        }
        public bool Supprimer(int id)
        {
            var g = db.Filieres.Find(id);
            db.Filieres.Remove(g);
            return db.SaveChanges() > 0;
        }

        public bool Update(Filiere g)
        {
            db.Filieres.Attach(g);
            db.Entry(g).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public List<Filiere> Liste()
        {
            var query = from s in db.Filieres select s;
            return query.ToList<Filiere>();

        }
    }
}
