namespace VBTicketVerkoop.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Bestellijnen", new[] { "ticketID" });
            DropIndex("dbo.Bestellijnen", new[] { "aboID" });
            AlterColumn("dbo.Bestellijnen", "ticketID", c => c.Int());
            AlterColumn("dbo.Bestellijnen", "aboID", c => c.Int());
            CreateIndex("dbo.Bestellijnen", "ticketID");
            CreateIndex("dbo.Bestellijnen", "aboID");
            DropColumn("dbo.Bestellingen", "naam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bestellingen", "naam", c => c.String());
            DropIndex("dbo.Bestellijnen", new[] { "aboID" });
            DropIndex("dbo.Bestellijnen", new[] { "ticketID" });
            AlterColumn("dbo.Bestellijnen", "aboID", c => c.Int(nullable: false));
            AlterColumn("dbo.Bestellijnen", "ticketID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bestellijnen", "aboID");
            CreateIndex("dbo.Bestellijnen", "ticketID");
        }
    }
}
