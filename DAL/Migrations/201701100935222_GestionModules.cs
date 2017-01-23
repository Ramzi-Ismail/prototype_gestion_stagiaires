namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GestionModules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContenuePrecisions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                        Duree = c.Int(nullable: false),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Precision_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Precisions", t => t.Precision_Id)
                .Index(t => t.Precision_Id);
            
            CreateTable(
                "dbo.Precisions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Module_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modules", t => t.Module_Id)
                .Index(t => t.Module_Id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                        Duree = c.Int(nullable: false),
                        Presentation = c.String(),
                        Description = c.String(),
                        StrategieEnseignement = c.String(),
                        Apprentisage = c.String(),
                        Evaluation = c.String(),
                        Materiel = c.String(),
                        Equipement = c.String(),
                        Competence = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Filiere_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Filieres", t => t.Filiere_Id)
                .Index(t => t.Filiere_Id);
            
            CreateTable(
                "dbo.Prealables",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Precision_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Precisions", t => t.Precision_Id)
                .Index(t => t.Precision_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContenuePrecisions", "Precision_Id", "dbo.Precisions");
            DropForeignKey("dbo.Prealables", "Precision_Id", "dbo.Precisions");
            DropForeignKey("dbo.Precisions", "Module_Id", "dbo.Modules");
            DropForeignKey("dbo.Modules", "Filiere_Id", "dbo.Filieres");
            DropIndex("dbo.Prealables", new[] { "Precision_Id" });
            DropIndex("dbo.Modules", new[] { "Filiere_Id" });
            DropIndex("dbo.Precisions", new[] { "Module_Id" });
            DropIndex("dbo.ContenuePrecisions", new[] { "Precision_Id" });
            DropTable("dbo.Prealables");
            DropTable("dbo.Modules");
            DropTable("dbo.Precisions");
            DropTable("dbo.ContenuePrecisions");
        }
    }
}
