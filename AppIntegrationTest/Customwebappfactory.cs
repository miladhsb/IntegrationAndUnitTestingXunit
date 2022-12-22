using IntegrationAndUnitTesting;
using IntegrationAndUnitTesting.Repository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIntegrationTest
{
    internal class Customwebappfactory<T> : WebApplicationFactory<T>  where T : class
    {
        private readonly string _environment;

        public Customwebappfactory(string environment = "Development")
        {
            _environment = environment;
        }
        
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment(_environment);


         
            builder.ConfigureServices(Services =>
            {
                //Services.Remove(Services.First(p => p.ServiceType == typeof(DbContextOptions<AppDbContext>)));
                //Services.AddDbContext<AppDbContext>(p => p.UseInMemoryDatabase("milad"));
                //Services.Remove(Services.First(p => p.ServiceType == typeof(IPersonRepository)));
                //Services.AddScoped<IPersonRepository, PersonRepository>();
                //Services.AddDbContext<AppDbContext>(p => p.UseSqlServer("Data Source=.;Initial Catalog=UnitTestDb;Integrated Security=True;MultipleActiveResultSets=True"));
                //Services.AddScoped<IPersonRepository, PersonRepository>();
            });

            return base.CreateHost(builder);
        }
    }
}
