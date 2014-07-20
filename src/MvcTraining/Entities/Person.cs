using System.ComponentModel.DataAnnotations;

namespace MvcTraining.Entities
{
    public class Person
    {
        public Person()
        {
            Address=new Address();
            Contact=new Contact();
        }
        public long Id { get; private set; }
        public Gender Gender { get; set; }

        [StringLength(64)]
        public string GivenName { get; set; }
        [StringLength(64)]
        public string LastName { get; set; }

        public Address Address { get; private set; }
        public Contact Contact { get; private set; }
    }
}