namespace App.Migrations
{
    using Entites;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AppGestionStagiaires.ModelStagiaires";
        }

        protected override void Seed(App.ModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Filieres.AddOrUpdate(
              f => f.Id
              ,
              new Filiere { Id = 1, Code = "TDI" },
              new Filiere { Id = 2, Code = "TRI" },
              new Filiere { Id = 3, Code = "TDM" },
              new Filiere { Id = 4, Code = "Info Graphie" },
              new Filiere { Id = 5, Code = "TMSIR" },
              new Filiere { Id = 6, Code = "CCP" }
            );

            context.Formateur.AddOrUpdate(f => f.Id, 
               new Formateur { Id = 1,Login = "admin", Password = "admin" ,role="ADMIN"});
            //
        }
    }
}
