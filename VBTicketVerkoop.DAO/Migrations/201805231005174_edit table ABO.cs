namespace VBTicketVerkoop.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableABO : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abonnementen", "GebruikersID", "dbo.Gebruikers");
            DropForeignKey("dbo.Abonnementen", "plaatsID", "dbo.Plaatsen");
            DropIndex("dbo.Abonnementen", new[] { "ploegID" });
            DropIndex("dbo.Abonnementen", new[] { "plaatsID" });
            DropIndex("dbo.Abonnementen", new[] { "GebruikersID" });
            RenameColumn(table: "dbo.Abonnementen", name: "ploegID", newName: "Ploeg_ploegID");
            AddColumn("dbo.Abonnementen", "prijsID", c => c.Int(nullable: false));
            AlterColumn("dbo.Abonnementen", "Ploeg_ploegID", c => c.Int());
            CreateIndex("dbo.Abonnementen", "prijsID");
            CreateIndex("dbo.Abonnementen", "Ploeg_ploegID");
            AddForeignKey("dbo.Abonnementen", "prijsID", "dbo.Prijs", "prijsID");
            DropColumn("dbo.Abonnementen", "plaatsID");
            DropColumn("dbo.Abonnementen", "prijs");
            DropColumn("dbo.Abonnementen", "GebruikersID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abonnementen", "GebruikersID", c => c.String(maxLength: 128));
            AddColumn("dbo.Abonnementen", "prijs", c => c.Double(nullable: false));
            AddColumn("dbo.Abonnementen", "plaatsID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Abonnementen", "prijsID", "dbo.Prijs");
            DropIndex("dbo.Abonnementen", new[] { "Ploeg_ploegID" });
            DropIndex("dbo.Abonnementen", new[] { "prijsID" });
            AlterColumn("dbo.Abonnementen", "Ploeg_ploegID", c => c.Int(nullable: false));
            DropColumn("dbo.Abonnementen", "prijsID");
            RenameColumn(table: "dbo.Abonnementen", name: "Ploeg_ploegID", newName: "ploegID");
            CreateIndex("dbo.Abonnementen", "GebruikersID");
            CreateIndex("dbo.Abonnementen", "plaatsID");
            CreateIndex("dbo.Abonnementen", "ploegID");
            AddForeignKey("dbo.Abonnementen", "plaatsID", "dbo.Plaatsen", "plaatsID");
            AddForeignKey("dbo.Abonnementen", "GebruikersID", "dbo.Gebruikers", "gebruikerID");
        }
    }
}
