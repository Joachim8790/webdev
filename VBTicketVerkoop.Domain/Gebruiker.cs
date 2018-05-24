using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VBTicketVerkoop.Domain
{
    public class Gebruiker
    {
        [Key]
        public string gebruikerID { get; set; }
        [Required(ErrorMessage ="Voornaam is veplicht.")]
        public string voornaam { get; set; }
        [Required(ErrorMessage = "Familienaam is veplicht.")]
        public string familienaam { get; set; }
        [Required(ErrorMessage = "Email is veplicht.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage ="Verkeerde email.")]
        public string email { get; set; }
        [Required(ErrorMessage = "Gebruikersnaam is veplicht.")]
        public string gebruikersnaam { get; set; }
        public virtual IEnumerable<Bestelling> bestellingen { get; set; }
        public double? promotie { get; set; }
    }
}