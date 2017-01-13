namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GestionFormations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activites",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Objectif = c.String(),
                        Duree = c.Int(nullable: false),
                        Description = c.String(),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        CategogieActivite_Id = c.Long(),
                        StrategiePedagogie_Id = c.Long(),
                        PrevisionSeance_Id = c.Long(),
                        Seance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategogieActivites", t => t.CategogieActivite_Id)
                .ForeignKey("dbo.StrategiePedagogies", t => t.StrategiePedagogie_Id)
                .ForeignKey("dbo.PrevisionSeances", t => t.PrevisionSeance_Id)
                .ForeignKey("dbo.Seances", t => t.Seance_Id)
                .Index(t => t.CategogieActivite_Id)
                .Index(t => t.StrategiePedagogie_Id)
                .Index(t => t.PrevisionSeance_Id)
                .Index(t => t.Seance_Id);
            
            CreateTable(
                "dbo.CategogieActivites",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StrategiePedagogies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategogiesSalleFormations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        AnneeFormation_Id = c.Long(),
                        Filiere_Id = c.Long(),
                        Formateur_Id = c.Long(),
                        Groupe_Id = c.Long(),
                        Module_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnneeFormations", t => t.AnneeFormation_Id)
                .ForeignKey("dbo.Filieres", t => t.Filiere_Id)
                .ForeignKey("dbo.Formateurs", t => t.Formateur_Id)
                .ForeignKey("dbo.Groupes", t => t.Groupe_Id)
                .ForeignKey("dbo.Modules", t => t.Module_Id)
                .Index(t => t.AnneeFormation_Id)
                .Index(t => t.Filiere_Id)
                .Index(t => t.Formateur_Id)
                .Index(t => t.Groupe_Id)
                .Index(t => t.Module_Id);
            
            CreateTable(
                "dbo.PrevisionSeances",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titre = c.String(),
                        Objectif = c.String(),
                        Duree = c.Int(nullable: false),
                        Ordre = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        categogiesSalleFormation_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategogiesSalleFormations", t => t.categogiesSalleFormation_Id)
                .Index(t => t.categogiesSalleFormation_Id);
            
            CreateTable(
                "dbo.Salles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        CategogiesSalleFormation_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategogiesSalleFormations", t => t.CategogiesSalleFormation_Id)
                .Index(t => t.CategogiesSalleFormation_Id);
            
            CreateTable(
                "dbo.Seances",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titre = c.String(),
                        Objectif = c.Int(nullable: false),
                        DateRealisation = c.DateTime(nullable: false),
                        Duree = c.Int(nullable: false),
                        heureDebut = c.DateTime(nullable: false),
                        heureFin = c.DateTime(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Formation_Id = c.Long(),
                        PrevisionSeance_Id = c.Long(),
                        Salle_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Formations", t => t.Formation_Id)
                .ForeignKey("dbo.PrevisionSeances", t => t.PrevisionSeance_Id)
                .ForeignKey("dbo.Salles", t => t.Salle_Id)
                .Index(t => t.Formation_Id)
                .Index(t => t.PrevisionSeance_Id)
                .Index(t => t.Salle_Id);
            
            AddColumn("dbo.ContenuePrecisions", "Objectif", c => c.String());
            AddColumn("dbo.ContenuePrecisions", "PrevisionSeance_Id", c => c.Long());
            CreateIndex("dbo.ContenuePrecisions", "PrevisionSeance_Id");
            AddForeignKey("dbo.ContenuePrecisions", "PrevisionSeance_Id", "dbo.PrevisionSeances", "Id");
            DropColumn("dbo.ContenuePrecisions", "Nom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContenuePrecisions", "Nom", c => c.String());
            DropForeignKey("dbo.Seances", "Salle_Id", "dbo.Salles");
            DropForeignKey("dbo.Seances", "PrevisionSeance_Id", "dbo.PrevisionSeances");
            DropForeignKey("dbo.Seances", "Formation_Id", "dbo.Formations");
            DropForeignKey("dbo.Activites", "Seance_Id", "dbo.Seances");
            DropForeignKey("dbo.Salles", "CategogiesSalleFormation_Id", "dbo.CategogiesSalleFormations");
            DropForeignKey("dbo.ContenuePrecisions", "PrevisionSeance_Id", "dbo.PrevisionSeances");
            DropForeignKey("dbo.PrevisionSeances", "categogiesSalleFormation_Id", "dbo.CategogiesSalleFormations");
            DropForeignKey("dbo.Activites", "PrevisionSeance_Id", "dbo.PrevisionSeances");
            DropForeignKey("dbo.Formations", "Module_Id", "dbo.Modules");
            DropForeignKey("dbo.Formations", "Groupe_Id", "dbo.Groupes");
            DropForeignKey("dbo.Formations", "Formateur_Id", "dbo.Formateurs");
            DropForeignKey("dbo.Formations", "Filiere_Id", "dbo.Filieres");
            DropForeignKey("dbo.Formations", "AnneeFormation_Id", "dbo.AnneeFormations");
            DropForeignKey("dbo.Activites", "StrategiePedagogie_Id", "dbo.StrategiePedagogies");
            DropForeignKey("dbo.Activites", "CategogieActivite_Id", "dbo.CategogieActivites");
            DropIndex("dbo.Seances", new[] { "Salle_Id" });
            DropIndex("dbo.Seances", new[] { "PrevisionSeance_Id" });
            DropIndex("dbo.Seances", new[] { "Formation_Id" });
            DropIndex("dbo.Salles", new[] { "CategogiesSalleFormation_Id" });
            DropIndex("dbo.PrevisionSeances", new[] { "categogiesSalleFormation_Id" });
            DropIndex("dbo.Formations", new[] { "Module_Id" });
            DropIndex("dbo.Formations", new[] { "Groupe_Id" });
            DropIndex("dbo.Formations", new[] { "Formateur_Id" });
            DropIndex("dbo.Formations", new[] { "Filiere_Id" });
            DropIndex("dbo.Formations", new[] { "AnneeFormation_Id" });
            DropIndex("dbo.ContenuePrecisions", new[] { "PrevisionSeance_Id" });
            DropIndex("dbo.Activites", new[] { "Seance_Id" });
            DropIndex("dbo.Activites", new[] { "PrevisionSeance_Id" });
            DropIndex("dbo.Activites", new[] { "StrategiePedagogie_Id" });
            DropIndex("dbo.Activites", new[] { "CategogieActivite_Id" });
            DropColumn("dbo.ContenuePrecisions", "PrevisionSeance_Id");
            DropColumn("dbo.ContenuePrecisions", "Objectif");
            DropTable("dbo.Seances");
            DropTable("dbo.Salles");
            DropTable("dbo.PrevisionSeances");
            DropTable("dbo.Formations");
            DropTable("dbo.CategogiesSalleFormations");
            DropTable("dbo.StrategiePedagogies");
            DropTable("dbo.CategogieActivites");
            DropTable("dbo.Activites");
        }
    }
}
