using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;



namespace VBTicketVerkoop.Domain
{
    public class Ploeg
    {
        [Key]
        public int ploegID { get; set; }
        public string naam { get; set; }
        [ForeignKey("Stadion")]
        public int stadionID { get; set; }
        public virtual Stadion Stadion { get; set; }

        public virtual ICollection<Abo> abo { get; set; }
        public virtual ICollection<Wedstrijd> wedstrijden { get; set; }


    }
}