using System;
using System.Data.Entity;
using MvcTraining.Entities;
using MvcTraining.Models;

namespace MvcTraining.Data
{
    public class TrainingDbContext : ApplicationDbContext
    {
        private TrainingDbContext():base()
        {
            
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }

        public static ApplicationDbContext Create()
        {
            return new TrainingDbContext();
        }
    }
}