namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelatonPrevisionSanceEtModule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrevisionSeances", "Module_Id", c => c.Long());
            CreateIndex("dbo.PrevisionSeances", "Module_Id");
            AddForeignKey("dbo.PrevisionSeances", "Module_Id", "dbo.Modules", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrevisionSeances", "Module_Id", "dbo.Modules");
            DropIndex("dbo.PrevisionSeances", new[] { "Module_Id" });
            DropColumn("dbo.PrevisionSeances", "Module_Id");
        }
    }
}
