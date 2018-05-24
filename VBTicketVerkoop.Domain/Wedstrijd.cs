using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VBTicketVerkoop.Domain
{
    public class Wedstrijd
    {
        [Key]
        public int wedstrijdID { get; set; }
        [ForeignKey("Ploeg")]
        public int thuisID { get; set; }
        public int uitID { get; set; }
        public virtual Ploeg Ploeg { get; set; }
           
        public DateTime date { get; set; }
        [ForeignKey("Stadion")]
        public int stadionID { get; set; }
        public virtual Stadion Stadion { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}