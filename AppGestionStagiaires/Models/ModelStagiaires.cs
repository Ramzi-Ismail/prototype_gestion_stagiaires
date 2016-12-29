namespace AppGestionStagiaires
{
    using Entites;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelStagiaires : DbContext
    {
         public ModelStagiaires() : base("name=ModelStagiaires")
        {
        }
         public virtual DbSet<Stagiaire> Stagiaires { get; set; }
         public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<Filiere> Filieres { get; set; }
    }

}