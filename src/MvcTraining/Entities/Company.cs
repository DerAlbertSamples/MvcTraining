using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MvcTraining.Entities
{
    public class Company
    {
        public Company()
        {
            Address = new Address();
            Contact = new Contact();
            Employees=new Collection<Person>();
        }

        public long Id { get; private set; }
        public string Name { get; set; }

        public Address Address { get; private set; }
        public Contact Contact { get; private set; }

        public virtual ICollection<Person> Employees { get; private set; }
    }
}