using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VBTicketVerkoop.Domain
{
    public class Bestellijn
    {
        [Key]
        public int BestellijnID { get; set; }
        [ForeignKey("Ticket")]
        public int? ticketID { get; set; }
        public virtual Ticket Ticket { get; set; }
        [ForeignKey("Abo")]
        public int? aboID { get; set; }
        public virtual Abo Abo { get; set; }
        [ForeignKey("Bestelling")]
        public int bestellingID { get; set; }
        public virtual Bestelling Bestelling { get; set; }

    }
}