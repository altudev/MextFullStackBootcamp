using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.WebApi.Services;

namespace MextFullstackSaaS.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            return services;
        }
    }
}
