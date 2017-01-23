namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changement1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StrategiePedagogies", "Titre", c => c.String());
            AddColumn("dbo.StrategiePedagogies", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StrategiePedagogies", "Description");
            DropColumn("dbo.StrategiePedagogies", "Titre");
        }
    }
}
