using AppGestionStagiaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
using System.Data.Entity;

namespace AppGestionStagiaires.GestionStagiaires
{
    public class StagiairesService : BaseRepository<Stagiaire>
    {

        //private ModelStagiaires db = new ModelStagiaires();
        //public bool Ajouter(Stagiaire s)
        //{
        //    db.Stagiaires.Add(s);
        //    return db.SaveChanges() > 0;
        //}
        //public Stagiaire RechercheParId(int id)
        //{
        //    Stagiaire s = db.Stagiaires
        //        .Where(i => i.Id == id)
        //        .SingleOrDefault();
        //    return s;
        //}
        //public bool Supprimer(int id)
        //{
        //    var s = db.Stagiaires.Find(id);
        //    db.Stagiaires.Remove(s);
        //    return db.SaveChanges() > 0;
        //}

        //public bool Update(Stagiaire s)
        //{
        //    var original = db.Stagiaires.Find(s.Id);

        //    if (original != null)
        //    {
        //        db.Entry(original).CurrentValues.SetValues(s);
        //        return db.SaveChanges() >0 ;
        //    }
        //    return false;
        //}
        //public List<Stagiaire> Recherche(int Id, string Nom,string Prenom, string Operation)
        //{
        //    List<Stagiaire> stagiaires = db.Stagiaires.Where(s =>
        //    Operation == "AND" ? ((Id == s.Id) && (Nom == s.Nom))
        //        : ((Id == s.Id) || (Nom == s.Nom))
        //  ).ToList<Stagiaire>();
        //    return stagiaires;
        //}

        //public List<Stagiaire>  ListStagiaires()
        //{
        //    var query = from s in db.Stagiaires   select s;
        //    return query.ToList<Stagiaire>();

        //}

        //public void valider()
        //{
        //    db.SaveChanges();
        //}

        //public ModelStagiaires conrext()
        //{
        //    return db;
        //}
       
    }
}
