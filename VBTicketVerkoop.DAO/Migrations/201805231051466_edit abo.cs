namespace VBTicketVerkoop.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editabo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abonnementen", "prijsID", "dbo.Prijs");
            DropIndex("dbo.Abonnementen", new[] { "prijsID" });
            DropIndex("dbo.Abonnementen", new[] { "Ploeg_ploegID" });
            RenameColumn(table: "dbo.Abonnementen", name: "Ploeg_ploegID", newName: "ploegID");
            AddColumn("dbo.Abonnementen", "plaatsID", c => c.Int(nullable: false));
            AddColumn("dbo.Abonnementen", "prijs", c => c.Double(nullable: false));
            AlterColumn("dbo.Abonnementen", "ploegID", c => c.Int(nullable: false));
            CreateIndex("dbo.Abonnementen", "ploegID");
            CreateIndex("dbo.Abonnementen", "plaatsID");
            AddForeignKey("dbo.Abonnementen", "plaatsID", "dbo.Plaatsen", "plaatsID");
            DropColumn("dbo.Abonnementen", "prijsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abonnementen", "prijsID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Abonnementen", "plaatsID", "dbo.Plaatsen");
            DropIndex("dbo.Abonnementen", new[] { "plaatsID" });
            DropIndex("dbo.Abonnementen", new[] { "ploegID" });
            AlterColumn("dbo.Abonnementen", "ploegID", c => c.Int());
            DropColumn("dbo.Abonnementen", "prijs");
            DropColumn("dbo.Abonnementen", "plaatsID");
            RenameColumn(table: "dbo.Abonnementen", name: "ploegID", newName: "Ploeg_ploegID");
            CreateIndex("dbo.Abonnementen", "Ploeg_ploegID");
            CreateIndex("dbo.Abonnementen", "prijsID");
            AddForeignKey("dbo.Abonnementen", "prijsID", "dbo.Prijs", "prijsID");
        }
    }
}
