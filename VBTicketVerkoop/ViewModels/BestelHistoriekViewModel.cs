using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.ViewModels
{
    public class BestelHistoriekViewModel
    {
        public IEnumerable<Bestelling> Bestellingen { get; set; }
        public IEnumerable<double> TotaalBedragen { get; set; }

    }
}