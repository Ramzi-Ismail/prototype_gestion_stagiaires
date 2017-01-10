namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GestionLivre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livres",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titre = c.String(),
                        DateSortie = c.DateTime(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        MaisonEdition_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaisonEditions", t => t.MaisonEdition_Id)
                .Index(t => t.MaisonEdition_Id);
            
            CreateTable(
                "dbo.MaisonEditions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                        Adresse = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livres", "MaisonEdition_Id", "dbo.MaisonEditions");
            DropIndex("dbo.Livres", new[] { "MaisonEdition_Id" });
            DropTable("dbo.MaisonEditions");
            DropTable("dbo.Livres");
        }
    }
}
