using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VBTicketVerkoop.Domain
{
    public class Prijs
    {
        [Key]
        public int prijsID { get; set; }
        [ForeignKey("Stadion")]
        public int stadionID { get; set; }
        public virtual Stadion Stadion { get; set; }
        [ForeignKey("Plaats")]
        public int plaatsID { get; set; }
        public virtual Plaats Plaats { get; set; }
        public double prijs { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}