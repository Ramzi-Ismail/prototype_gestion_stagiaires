namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationGroupeAnneeFormation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groupes", "AnneeFormation_Id", c => c.Long());
            CreateIndex("dbo.Groupes", "AnneeFormation_Id");
            AddForeignKey("dbo.Groupes", "AnneeFormation_Id", "dbo.AnneeFormations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groupes", "AnneeFormation_Id", "dbo.AnneeFormations");
            DropIndex("dbo.Groupes", new[] { "AnneeFormation_Id" });
            DropColumn("dbo.Groupes", "AnneeFormation_Id");
        }
    }
}
