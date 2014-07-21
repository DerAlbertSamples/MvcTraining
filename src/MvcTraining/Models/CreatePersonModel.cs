using System.ComponentModel.DataAnnotations;
using MvcTraining.Entities;

namespace MvcTraining.Models
{
    public class CreatePersonModel
    {
        [Display(Name = "Geschlecht")]
        public Gender Gender { get; set; }

        [Display(Name = "Vorname")]
        [Required]
        [StringLength(64)]
        public string GivenName { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "Nachname")]
        public string LastName { get; set; }
    }
}