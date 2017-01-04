namespace App
{
    using Entites;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    public class ModelContext : DbContext
    {
        // public ModelContext() : base("name = ModelStagiaires")
         public ModelContext() : base(@"data source =192.168.1.57\SQLEXPRESS; initial catalog = AppGestionStagiaires.ModelStagiaires; user = sa; password = admintp4; MultipleActiveResultSets = True; App = EntityFramework")
   
       // public ModelContext()
        {
         
            
            //Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        // Application de Gestion des stagiaires
        public virtual DbSet<Stagiaire> Stagiaires { get; set; }
        public virtual DbSet<Formateur> Formateur { get; set; }
        public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<Filiere> Filieres { get; set; }

        // Application de Gestion des projets
        public virtual DbSet<Projet> Projets { get; set; }
        public virtual DbSet<Tache> Taches { get; set; }
        public virtual DbSet<MiniGroupe> MiniGroupes { get; set; }
   

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>()
            //  .Map<OnlineCourse>(m => m.Requires("Type").HasValue("OnlineCourse "))
            //  .Map<OfflineCourse>(m => m.Requires("Type").HasValue("OfflineCourse "));
        }

        //public override int SaveChanges()
        //{
        //    try
        //    {
        //        return base.SaveChanges();
        //    }
            
        //    catch (DbUpdateException dbu)
        //    {
        //        var exception = HandleDbUpdateException(dbu);
        //        throw exception;
        //    }
        //}

        //private Exception HandleDbUpdateException(DbUpdateException dbu)
        //{
        //    var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

        //    try
        //    {
        //        foreach (var result in dbu.Entries)
        //        {
        //            builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        builder.Append("Error parsing DbUpdateException: " + e.ToString());
        //    }

        //    string message = builder.ToString();
        //    return new Exception(message, dbu);
        //}


    }

    


}