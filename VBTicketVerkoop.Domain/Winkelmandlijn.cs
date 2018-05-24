using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBTicketVerkoop.Domain
{
    public class Winkelmandlijn
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Gebruiker")]
        public string gebruikerID { get; set; }
        public virtual Gebruiker Gebruiker { get; set; }
        [ForeignKey("Ticket")]
        public int? TicketID { get; set; }
        public virtual Ticket Ticket { get; set; }
        [ForeignKey("Abo")]
        public int? AboID { get; set; }
        public virtual Abo Abo { get; set; }


    }
}
