using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.ViewModels
{
    public class BestellingDetailViewModel
    {
        public Bestelling Bestelling { get; set; }
        public IEnumerable<Ploeg> thuisPloegen { get; set; }
        public IEnumerable<Ploeg> uitploegen { get; set; }
        public IEnumerable<Ploeg> AbonnementPloeg { get; set; }
        public IEnumerable<Prijs> Prijzen { get; set; }
        public IEnumerable<Abo> Abonnementen { get; set; }
        public IEnumerable<Plaats> Plaatsen { get; set; }
        public IEnumerable<Plaats> AbonnementPlaatsen { get; set; }
        public IEnumerable<Stadion> Stadions { get; set; }
        public IEnumerable<Stadion> AbonnementStadions { get; set; }
    }
}