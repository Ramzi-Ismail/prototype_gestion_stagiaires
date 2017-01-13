namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdreSance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seances", "Ordre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seances", "Ordre");
        }
    }
}
