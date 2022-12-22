using IntegrationAndUnitTesting.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegrationAndUnitTesting
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }


        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);
        }


    }
}
