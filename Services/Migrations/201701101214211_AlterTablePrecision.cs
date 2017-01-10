namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTablePrecision : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Precisions", "Nom", c => c.String());
            AddColumn("dbo.Precisions", "Duree", c => c.Int(nullable: false));
            AddColumn("dbo.Precisions", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Precisions", "Description");
            DropColumn("dbo.Precisions", "Duree");
            DropColumn("dbo.Precisions", "Nom");
        }
    }
}
