namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableAnneFormation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnneeFormations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titre = c.String(),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnneeFormations");
        }
    }
}
