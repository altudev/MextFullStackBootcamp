using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MextFullstackSaaS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(
                container => container.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
