namespace App
{
    using Formations;
    using GestionProjets;
    using GestionStagiaires;
    using Livres;
    using Modules;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    public class ModelContext : DbContext
    {

        //public ModelContext() : base(@"data source =localhost\SQLEXPRESS; initial catalog = AppGestionStagiaires.ModelStagiaires; user = sa; password = admintp4; MultipleActiveResultSets = True; App = EntityFramework")
       public ModelContext() : base(@"data source =192.168.1.57\SQLEXPRESS; initial catalog = CplusESSARRAJ; user = sa; password = admintp4; MultipleActiveResultSets = True; App = EntityFramework")

        {
          
            
            //Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public ModelContext(string connectionString):base(connectionString)
        {

        }

        //
        // Gestion des formations
        //
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<AnneeFormation> AnneeFormations { get; set; }
        public virtual DbSet<PrevisionSeance> PrevisionSeances { get; set; }
        public virtual DbSet<Salle> Salles { get; set; }
        public virtual DbSet<Activite> Activites { get; set; }

        public virtual DbSet<CategogieActivite> CategogieActivites { get; set; }

        public virtual DbSet<StrategiePedagogie> StrategiePedagogies { get; set; }
        
        public virtual DbSet<CategogiesSalleFormation> CategogiesSalleFormations { get; set; }

        public virtual DbSet<Ferier> Feriers { get; set; }
        



        // Gestion Livre 
        public virtual DbSet<Livre> Livres { get; set; }
        public virtual DbSet<MaisonEdition> MaisonEditions { get; set; }

        // Gestion des formation
 


        // Application de Gestion des stagiaires
        public virtual DbSet<Stagiaire> Stagiaires { get; set; }
        public virtual DbSet<Formateur> Formateur { get; set; }
        public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<Filiere> Filieres { get; set; }

        // Application de Gestion des projets
        public virtual DbSet<Projet> Projets { get; set; }
        public virtual DbSet<Tache> Taches { get; set; }
        public virtual DbSet<MiniGroupe> MiniGroupes { get; set; }

        // Application de gestion des modules
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Precision> Precisions { get; set; }
        public virtual DbSet<Prealable> Prealables { get; set; }
        public virtual DbSet<ContenuePrecision> ContenuePrecisions { get; set; }


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


        /// <summary>
        /// trouver la liste des type des objets dans le context
        /// </summary>
        /// <returns></returns>
        public List<Type> GetTypesSets()
        {
            var sets = from p in typeof(ModelContext).GetProperties() where p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) let entityType = p.PropertyType.GetGenericArguments().First() select p.PropertyType.GetGenericArguments()[0];
            return sets.ToList<Type>();
        }

    }

    


}