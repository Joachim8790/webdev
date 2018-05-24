using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VBTicketVerkoop.Domain
{
    public class Stadion
    {
        [Key]
        public int stadionID { get; set; }
        public String naam { get; set; }

        public int ORT { get; set; }
        public int ORB { get; set; }
        public int ORO { get; set; }
        public int ORW { get; set; }
        public int BRT { get; set; }
        public int BRB { get; set; }
        public int BRO { get; set; }
        public int BRW { get; set; }

        public virtual ICollection<Prijs> Prijzen { get; set; }
        public virtual ICollection<Wedstrijd> Wedstrijden { get; set; }
        


    }
}