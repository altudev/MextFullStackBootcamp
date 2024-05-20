using MextFullStack.Domain.Entities;
using MextFullStack.Persistence.Services;
using Microsoft.EntityFrameworkCore;

namespace MextFullStack.Persistence.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        private readonly IRootPathService _rootPathService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IRootPathService rootPathService):base(options)
        {
            _rootPathService = rootPathService;

            var rootPath = _rootPathService.GetRootPath();

            _rootPathService.WriteTotalCount();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MextFullStackDB");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
