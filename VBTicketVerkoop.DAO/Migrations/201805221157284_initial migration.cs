namespace VBTicketVerkoop.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnementen",
                c => new
                    {
                        aboID = c.Int(nullable: false, identity: true),
                        ploegID = c.Int(nullable: false),
                        plaatsID = c.Int(nullable: false),
                        prijs = c.Double(nullable: false),
                        GebruikersID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.aboID)
                .ForeignKey("dbo.Gebruikers", t => t.GebruikersID)
                .ForeignKey("dbo.Plaatsen", t => t.plaatsID)
                .ForeignKey("dbo.Ploegen", t => t.ploegID)
                .Index(t => t.ploegID)
                .Index(t => t.plaatsID)
                .Index(t => t.GebruikersID);
            
            CreateTable(
                "dbo.Gebruikers",
                c => new
                    {
                        gebruikerID = c.String(nullable: false, maxLength: 128),
                        voornaam = c.String(nullable: false),
                        familienaam = c.String(nullable: false),
                        email = c.String(nullable: false),
                        gebruikersnaam = c.String(nullable: false),
                        promotie = c.Double(),
                    })
                .PrimaryKey(t => t.gebruikerID);
            
            CreateTable(
                "dbo.Plaatsen",
                c => new
                    {
                        plaatsID = c.Int(nullable: false, identity: true),
                        plaatsNaam = c.String(),
                    })
                .PrimaryKey(t => t.plaatsID);
            
            CreateTable(
                "dbo.Prijs",
                c => new
                    {
                        prijsID = c.Int(nullable: false, identity: true),
                        stadionID = c.Int(nullable: false),
                        plaatsID = c.Int(nullable: false),
                        prijs = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.prijsID)
                .ForeignKey("dbo.Plaatsen", t => t.plaatsID)
                .ForeignKey("dbo.Stadions", t => t.stadionID)
                .Index(t => t.stadionID)
                .Index(t => t.plaatsID);
            
            CreateTable(
                "dbo.Stadions",
                c => new
                    {
                        stadionID = c.Int(nullable: false, identity: true),
                        naam = c.String(),
                        ORT = c.Int(nullable: false),
                        ORB = c.Int(nullable: false),
                        ORO = c.Int(nullable: false),
                        ORW = c.Int(nullable: false),
                        BRT = c.Int(nullable: false),
                        BRB = c.Int(nullable: false),
                        BRO = c.Int(nullable: false),
                        BRW = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.stadionID);
            
            CreateTable(
                "dbo.Wedstrijden",
                c => new
                    {
                        wedstrijdID = c.Int(nullable: false, identity: true),
                        thuisID = c.Int(nullable: false),
                        uitID = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        stadionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.wedstrijdID)
                .ForeignKey("dbo.Ploegen", t => t.thuisID)
                .ForeignKey("dbo.Stadions", t => t.stadionID)
                .Index(t => t.thuisID)
                .Index(t => t.stadionID);
            
            CreateTable(
                "dbo.Ploegen",
                c => new
                    {
                        ploegID = c.Int(nullable: false, identity: true),
                        naam = c.String(),
                        stadionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ploegID)
                .ForeignKey("dbo.Stadions", t => t.stadionID)
                .Index(t => t.stadionID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ticketID = c.Int(nullable: false, identity: true),
                        wedstrijdID = c.Int(nullable: false),
                        PrijsID = c.Int(),
                    })
                .PrimaryKey(t => t.ticketID)
                .ForeignKey("dbo.Prijs", t => t.PrijsID)
                .ForeignKey("dbo.Wedstrijden", t => t.wedstrijdID)
                .Index(t => t.wedstrijdID)
                .Index(t => t.PrijsID);
            
            CreateTable(
                "dbo.Bestellijnen",
                c => new
                    {
                        BestellijnID = c.Int(nullable: false, identity: true),
                        ticketID = c.Int(nullable: false),
                        aboID = c.Int(nullable: false),
                        bestellingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BestellijnID)
                .ForeignKey("dbo.Abonnementen", t => t.aboID)
                .ForeignKey("dbo.Bestellingen", t => t.bestellingID)
                .ForeignKey("dbo.Tickets", t => t.ticketID)
                .Index(t => t.ticketID)
                .Index(t => t.aboID)
                .Index(t => t.bestellingID);
            
            CreateTable(
                "dbo.Bestellingen",
                c => new
                    {
                        BestellingID = c.Int(nullable: false, identity: true),
                        naam = c.String(),
                        date = c.DateTime(nullable: false),
                        gebruikerID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BestellingID)
                .ForeignKey("dbo.Gebruikers", t => t.gebruikerID)
                .Index(t => t.gebruikerID);
            
            CreateTable(
                "dbo.Winkelmandlijnen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        gebruikerID = c.String(maxLength: 128),
                        TicketID = c.Int(),
                        AboID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Abonnementen", t => t.AboID)
                .ForeignKey("dbo.Gebruikers", t => t.gebruikerID)
                .ForeignKey("dbo.Tickets", t => t.TicketID)
                .Index(t => t.gebruikerID)
                .Index(t => t.TicketID)
                .Index(t => t.AboID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Winkelmandlijnen", "TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Winkelmandlijnen", "gebruikerID", "dbo.Gebruikers");
            DropForeignKey("dbo.Winkelmandlijnen", "AboID", "dbo.Abonnementen");
            DropForeignKey("dbo.Bestellijnen", "ticketID", "dbo.Tickets");
            DropForeignKey("dbo.Bestellijnen", "bestellingID", "dbo.Bestellingen");
            DropForeignKey("dbo.Bestellingen", "gebruikerID", "dbo.Gebruikers");
            DropForeignKey("dbo.Bestellijnen", "aboID", "dbo.Abonnementen");
            DropForeignKey("dbo.Abonnementen", "ploegID", "dbo.Ploegen");
            DropForeignKey("dbo.Abonnementen", "plaatsID", "dbo.Plaatsen");
            DropForeignKey("dbo.Prijs", "stadionID", "dbo.Stadions");
            DropForeignKey("dbo.Tickets", "wedstrijdID", "dbo.Wedstrijden");
            DropForeignKey("dbo.Tickets", "PrijsID", "dbo.Prijs");
            DropForeignKey("dbo.Wedstrijden", "stadionID", "dbo.Stadions");
            DropForeignKey("dbo.Wedstrijden", "thuisID", "dbo.Ploegen");
            DropForeignKey("dbo.Ploegen", "stadionID", "dbo.Stadions");
            DropForeignKey("dbo.Prijs", "plaatsID", "dbo.Plaatsen");
            DropForeignKey("dbo.Abonnementen", "GebruikersID", "dbo.Gebruikers");
            DropIndex("dbo.Winkelmandlijnen", new[] { "AboID" });
            DropIndex("dbo.Winkelmandlijnen", new[] { "TicketID" });
            DropIndex("dbo.Winkelmandlijnen", new[] { "gebruikerID" });
            DropIndex("dbo.Bestellingen", new[] { "gebruikerID" });
            DropIndex("dbo.Bestellijnen", new[] { "bestellingID" });
            DropIndex("dbo.Bestellijnen", new[] { "aboID" });
            DropIndex("dbo.Bestellijnen", new[] { "ticketID" });
            DropIndex("dbo.Tickets", new[] { "PrijsID" });
            DropIndex("dbo.Tickets", new[] { "wedstrijdID" });
            DropIndex("dbo.Ploegen", new[] { "stadionID" });
            DropIndex("dbo.Wedstrijden", new[] { "stadionID" });
            DropIndex("dbo.Wedstrijden", new[] { "thuisID" });
            DropIndex("dbo.Prijs", new[] { "plaatsID" });
            DropIndex("dbo.Prijs", new[] { "stadionID" });
            DropIndex("dbo.Abonnementen", new[] { "GebruikersID" });
            DropIndex("dbo.Abonnementen", new[] { "plaatsID" });
            DropIndex("dbo.Abonnementen", new[] { "ploegID" });
            DropTable("dbo.Winkelmandlijnen");
            DropTable("dbo.Bestellingen");
            DropTable("dbo.Bestellijnen");
            DropTable("dbo.Tickets");
            DropTable("dbo.Ploegen");
            DropTable("dbo.Wedstrijden");
            DropTable("dbo.Stadions");
            DropTable("dbo.Prijs");
            DropTable("dbo.Plaatsen");
            DropTable("dbo.Gebruikers");
            DropTable("dbo.Abonnementen");
        }
    }
}
