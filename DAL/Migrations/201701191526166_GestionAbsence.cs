namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GestionAbsence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absences",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Autorisation = c.Boolean(nullable: false),
                        CauseAbsence = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Seance_Id = c.Long(),
                        Stagiaire_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seances", t => t.Seance_Id)
                .ForeignKey("dbo.Stagiaires", t => t.Stagiaire_Id)
                .Index(t => t.Seance_Id)
                .Index(t => t.Stagiaire_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Absences", "Stagiaire_Id", "dbo.Stagiaires");
            DropForeignKey("dbo.Absences", "Seance_Id", "dbo.Seances");
            DropIndex("dbo.Absences", new[] { "Stagiaire_Id" });
            DropIndex("dbo.Absences", new[] { "Seance_Id" });
            DropTable("dbo.Absences");
        }
    }
}
