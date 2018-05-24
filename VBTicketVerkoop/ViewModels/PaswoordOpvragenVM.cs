using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VBTicketVerkoop.ViewModels
{
    public class PaswoordOpvragenVM
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}