namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdreColonne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategogieActivites", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.StrategiePedagogies", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.AnneeFormations", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.CategogiesSalleFormations", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Modules", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Filieres", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Formateurs", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Formations", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Groupes", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Livres", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.MaisonEditions", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.MiniGroupes", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Stagiaires", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Taches", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Projets", "Ordre", c => c.Int(nullable: false));
            AddColumn("dbo.Salles", "Ordre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salles", "Ordre");
            DropColumn("dbo.Projets", "Ordre");
            DropColumn("dbo.Taches", "Ordre");
            DropColumn("dbo.Stagiaires", "Ordre");
            DropColumn("dbo.MiniGroupes", "Ordre");
            DropColumn("dbo.MaisonEditions", "Ordre");
            DropColumn("dbo.Livres", "Ordre");
            DropColumn("dbo.Groupes", "Ordre");
            DropColumn("dbo.Formations", "Ordre");
            DropColumn("dbo.Formateurs", "Ordre");
            DropColumn("dbo.Filieres", "Ordre");
            DropColumn("dbo.Modules", "Ordre");
            DropColumn("dbo.CategogiesSalleFormations", "Ordre");
            DropColumn("dbo.AnneeFormations", "Ordre");
            DropColumn("dbo.StrategiePedagogies", "Ordre");
            DropColumn("dbo.CategogieActivites", "Ordre");
        }
    }
}
