using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class VoetbalContext : DbContext
    {
        
        public VoetbalContext() : base("VoetbalTicketDatabase")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruikers");
            modelBuilder.Entity<Ploeg>().ToTable("Ploegen");
            modelBuilder.Entity<Plaats>().ToTable("Plaatsen");
            modelBuilder.Entity<Abo>().ToTable("Abonnementen");
            modelBuilder.Entity<Bestellijn>().ToTable("Bestellijnen");
            modelBuilder.Entity<Bestelling>().ToTable("Bestellingen");
            modelBuilder.Entity<Stadion>().ToTable("Stadions");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Wedstrijd>().ToTable("Wedstrijden");
            modelBuilder.Entity<Winkelmandlijn>().ToTable("Winkelmandlijnen");
            modelBuilder.Entity<Prijs>().ToTable("Prijs");
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Ploeg> Ploegen { get; set; }
        public DbSet<Plaats> Plaatsen { get; set; }
        public DbSet<Abo> Abonnementen { get; set; }
        public DbSet<Bestellijn> Bestellijnen { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Stadion> Stadions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Prijs> Prijs { get; set; }
        public DbSet<Wedstrijd> Wedstrijden { get; set; }
        public DbSet<Winkelmandlijn> Winkelmandlijnen { get; set; }



    }
}