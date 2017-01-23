namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColonneOrdre_update_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Precisions", "Ordre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Precisions", "Ordre");
        }
    }
}
