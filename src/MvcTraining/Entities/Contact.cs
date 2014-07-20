using System.ComponentModel.DataAnnotations;

namespace MvcTraining.Entities
{
    public class Contact
    {
        [StringLength(64)]
        public string Phone { get; set; }

        [StringLength(256)]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [StringLength(256)]
        [DataType(DataType.Url)]
        public string Homepage { get; set; }
    }
}