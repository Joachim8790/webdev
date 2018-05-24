using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VBTicketVerkoop.Domain
{
    public class Plaats
    {
        [Key]
        public int plaatsID { get; set; }
        public string plaatsNaam { get; set; }
        public virtual ICollection<Prijs> Prijzen { get; set; }
    }

}