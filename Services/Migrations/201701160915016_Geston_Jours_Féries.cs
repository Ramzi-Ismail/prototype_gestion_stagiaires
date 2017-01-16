namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Geston_Jours_Féries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feriers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        AnneeFormation_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeFormations", t => t.AnneeFormation_Id, cascadeDelete: true)
                .Index(t => t.AnneeFormation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feriers", "AnneeFormation_Id", "dbo.AnneeFormations");
            DropIndex("dbo.Feriers", new[] { "AnneeFormation_Id" });
            DropTable("dbo.Feriers");
        }
    }
}
