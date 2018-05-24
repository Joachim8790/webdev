using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.ViewModels
{
    public class ShopViewModel
    {
        public IEnumerable<SelectListItem> ploegen { get; set; }
        public int geselecteerdePloeg { get; set; }//dit is de index van de dropdownlist die de geselecteerde ploeg voorsteld.
        public IEnumerable<Ticket> tickets { get; set; }
        public IEnumerable<Plaats> plaatsen { get; set; }
        public IEnumerable<Stadion> stadia { get; set; }
        public int[] numberOfAbos { get; set; }
        public IEnumerable<Plaats> abonnementPlaatsen { get; set; }
        public IEnumerable<Abo> Abonnementen { get; set; }
        public Gebruiker gebruiker { get; set; }
        

    }
}