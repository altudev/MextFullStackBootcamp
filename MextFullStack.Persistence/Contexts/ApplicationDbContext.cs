using MextFullStack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MextFullStack.Persistence.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("MextFullStackDB");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
