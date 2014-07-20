using System.ComponentModel.DataAnnotations;

namespace MvcTraining.Entities
{
    public enum Gender
    {
        Unknown,

        [Display(Name = "Mann")]
        Male,

        [Display(Name = "Frau")]
        Female,
    }
}