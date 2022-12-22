using IntegrationAndUnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest
{
    public static class AppDbcontextFactory
    {

        public static AppDbContext CreateDbContext()
        {
           DbContextOptionsBuilder<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>();
           
           AppDbContext appDbContext = new AppDbContext(options.UseInMemoryDatabase("milad").Options);

            return appDbContext;
        }
    }
}
