namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColonneCodeToModule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modules", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modules", "Code");
        }
    }
}
