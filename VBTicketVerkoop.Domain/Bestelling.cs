using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VBTicketVerkoop.Domain
{
    public class Bestelling
    {
        [Key]
        public int BestellingID { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("Gebruiker")]
        public string gebruikerID { get; set; }
        public virtual Gebruiker Gebruiker { get; set; }
        public virtual ICollection<Bestellijn> orders { get; set; }

    }
}