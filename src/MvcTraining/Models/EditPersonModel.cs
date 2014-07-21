using System.Collections.Generic;

namespace MvcTraining.Models
{
    public class EditPersonModel : CreatePersonModel
    {
        public string AddressZipCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCountry { get; set; }

        public List<string> Countries { get; set; } 
    }
}