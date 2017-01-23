using App.Authentification;
using App.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (var context = new ModelContext())
            {


                //context.Database.CreateIfNotExists();


                // Migration automatique de la base de données
                // il provoque un problème loras de l'initialisation
                // de la base de donénes 
                // Database.SetInitializer(new MigrateDatabaseToLatestVersion<ModelStagiaires, Configuration>());

                //var configuration = new Configuration();
                //var migrator = new DbMigrator(configuration);
                //migrator.Update();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //  Application.Run(new FormAuthentification());
                Application.Run(new FormMenu());
                // Application.Run(new FormMenu());

            }






        }
    }
}
