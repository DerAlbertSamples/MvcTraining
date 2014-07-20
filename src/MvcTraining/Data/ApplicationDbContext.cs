using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcTraining.Entities;
using MvcTraining.Models;

namespace MvcTraining.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Person> People { get; set; }
        public IDbSet<Company> Companies { get; set; } 
    }
}