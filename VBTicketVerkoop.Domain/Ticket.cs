using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VBTicketVerkoop.Domain
{
    public class Ticket
    {
        [Key]
        public int ticketID { get; set; }
        
        [ForeignKey("Wedstrijd")]
        public int wedstrijdID { get; set; }
        public virtual Wedstrijd Wedstrijd { get; set; }
        [ForeignKey("Prijs")]
        public int? PrijsID { get; set; }
        public virtual Prijs Prijs { get; set; }
    }
}