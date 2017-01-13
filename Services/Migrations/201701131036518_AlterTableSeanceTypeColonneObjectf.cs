namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableSeanceTypeColonneObjectf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seances", "Objectif", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seances", "Objectif", c => c.Int(nullable: false));
        }
    }
}
