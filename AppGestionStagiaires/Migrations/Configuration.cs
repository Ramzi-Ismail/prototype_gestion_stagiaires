namespace AppGestionStagiaires.Migrations
{
    using Entites;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppGestionStagiaires.ModelStagiaires>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AppGestionStagiaires.ModelStagiaires";
        }

        protected override void Seed(AppGestionStagiaires.ModelStagiaires context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Filieres.AddOrUpdate(
              f => f.Code
              ,
              new Filiere { Code = "TDI" },
              new Filiere { Code = "TRI" },
              new Filiere { Code = "TDM" },
              new Filiere { Code = "Info Graphie" },
              new Filiere { Code = "TMSIR" },
              new Filiere { Code = "CCP" }
            );
            //
        }
    }
}
