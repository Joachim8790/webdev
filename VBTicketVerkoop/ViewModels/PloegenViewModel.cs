using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.ViewModels
{
    public class PloegenViewModel
    {
        public IEnumerable<SelectListItem> ploegen { get; set; }
        public int geselecteerdePloeg { get; set; }//dit is de index van de dropdownlist die de geselecteerde ploeg voorsteld.

    }
}