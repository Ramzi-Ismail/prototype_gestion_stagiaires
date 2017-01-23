namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_GestionPorjet_Required_Titre_Tache : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projets", "Titre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projets", "Titre", c => c.String());
        }
    }
}
