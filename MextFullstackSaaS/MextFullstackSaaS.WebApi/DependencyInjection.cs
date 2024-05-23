using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetAll;
using MextFullstackSaaS.WebApi.Services;

namespace MextFullstackSaaS.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            return services;
        }
    }
}
