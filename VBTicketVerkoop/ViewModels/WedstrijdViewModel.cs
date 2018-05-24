using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.ViewModels
{
    public class WedstrijdViewModel
    {
        public Wedstrijd wedstrijd { get; set; }
        public int WedstrijdID { get; set; }
        public Stadion stadion { get; set; }
        public Gebruiker gebruiker { get; set; }
        public Ploeg thuisPloeg { get; set; }
        public Ploeg uitPloeg { get; set; }
        public IEnumerable<Prijs> prijzen { get; set; }
        public IEnumerable<Plaats> plaatsen { get; set; }
        public int[] numberOfTickets { get; set; }
    }
}