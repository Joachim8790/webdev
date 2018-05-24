using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.ViewModels
{
    public class WinkelmandViewModel
    {
        public ICollection<Winkelmandlijn> winkelmandlijnen { get; set; }
        public int[] winkelmandlineIDS { get; set; }
        public Gebruiker gebruiker { get; set; }
        public ICollection<Ploeg> thuis { get; set; }
        public ICollection<Ploeg> uit { get; set; }
        public ICollection<Prijs> prijs { get; set; }
        public ICollection<Plaats> plaats { get; set; }
        public ICollection<Stadion> stadion { get; set; }
        public ICollection<Ploeg> abonnementPloeg { get; set; }
        public ICollection<Plaats> abonnementPlaats { get; set; }
        public ICollection<double> abonnementPrijs { get; set; }
        public ICollection<Stadion> abonnementStadion { get; set; }

    }
}