using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MextFullstackSaaS.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContextFactory :IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
           // Build configuration
           var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

           // Get connection string
           var connectionString = configuration.GetConnectionString("DefaultConnection");

           // Create options
           var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseNpgsql(connectionString);

           return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
