using System.ComponentModel.DataAnnotations;
using MvcTraining.Entities;

namespace MvcTraining.Models
{
    public class CreateCompanyModel
    {
        public CreateCompanyModel()
        {
            Address = new Address();
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public Address Address { get; private set; }
    }

    public class EditCompanyModel : CreateCompanyModel
    {
        public EditCompanyModel()
        {
            Contact = new Contact();
        }

        public Contact Contact { get; private set; }
    }
}