using AppGestionStagiaires.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionStagiaires
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {


           // Migration automatique de la base de données
           // il provoque un problème loras de l'initialisation
           // de la base de donénes 
          // Database.SetInitializer(new MigrateDatabaseToLatestVersion<ModelStagiaires, Configuration>());

            //var configuration = new Configuration();
            //var migrator = new DbMigrator(configuration);
            //migrator.Update();



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMenu());
        }
    }
}
