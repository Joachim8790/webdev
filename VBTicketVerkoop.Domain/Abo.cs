using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VBTicketVerkoop.Domain
{
    public class Abo
    {
        [Key]
        public int aboID { get; set; }
        [ForeignKey("Ploeg")]
        public int ploegID { get; set; }
        public virtual Ploeg Ploeg { get; set; }
        [ForeignKey("Plaats")]
        public int plaatsID { get; set; }
        public virtual Plaats Plaats { get; set; }
        public double prijs { get; set; }
        

    }

}