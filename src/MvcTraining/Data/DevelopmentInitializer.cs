using System.Data.Entity;
using MvcTraining.Entities;

namespace MvcTraining.Data
{
    public class DevelopmentInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            var companyA = new Company
            {
                Name = "Oscorp Industries",
                Address =
                {
                    Street = "Im Kämpchen 5",
                    City = "Rommerskirchen",
                    ZipCode = "41569",
                    Country = "Deutschland"
                }
            };
            var companyB = new Company
            {
                Name = "Acme Corporation",
                Address =
                {
                    Street = "Feldblumenweg 2",
                    ZipCode = "50829",
                    City = "Köln",
                    Country = "Deutschland"
                }
            };
            var companyC = new Company
            {
                Name = "Massive Dynamic",
                Address =
                {
                    Street = "Unter den Linden 17",
                    ZipCode = "10115",
                    City = "Berlin",
                    Country = "Deutschland"
                }
            };
            context.Companies.Add(companyA);
            context.Companies.Add(companyB);
            context.Companies.Add(companyC);

            companyA.Employees.Add(new Person
            {
                Gender = Gender.Male,
                GivenName = "Albert",
                LastName = "Weinert",
                Contact =
                {
                    EMail = "info@der-albert.com",
                    Homepage = "http://blog.der-albert",
                    Phone = "0221 357 99 88"
                }
            });
            companyA.Employees.Add(new Person
            {
                Gender = Gender.Male,
                GivenName = "Peter",
                LastName = "Schmitz",
                Contact =
                {
                    EMail = "timo@beil.de"
                }
            });
        }
    }
}