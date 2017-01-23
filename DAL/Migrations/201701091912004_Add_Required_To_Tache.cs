namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Required_To_Tache : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Taches", "Titre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Taches", "Titre", c => c.String());
        }
    }
}
