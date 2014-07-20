using System.Data.Entity;
using MvcTraining.Data;

namespace MvcTraining
{
    public class DatabaseConfig
    {
        public static void Configure()
        {
            Database.SetInitializer(new DevelopmentInitializer());
        } 
    }
}