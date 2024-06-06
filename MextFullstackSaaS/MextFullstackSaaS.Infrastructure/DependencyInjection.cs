using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Identity;
using MextFullstackSaaS.Domain.Settings;
using MextFullstackSaaS.Infrastructure.Persistence.Contexts;
using MextFullstackSaaS.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Extensions;
using Resend;


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

            services.Configure<JwtSettings>(jwtSettings => configuration.GetSection("JwtSettings").Bind(jwtSettings));

            services.AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                    options.User.RequireUniqueEmail = true;

                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
          
            // // Sets the token lifespan to three hours for the email confirmation token
            // services.Configure<DataProtectionTokenProviderOptions>(options =>
            // {
            //     options.TokenLifespan = TimeSpan.FromHours(3); // Sets the expiry to three hours
            // });
            
            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<IIdentityService, IdentityManager>();
            services.AddScoped<IEmailService, ResendEmailManager>();
            //OpenAI
            services.AddOpenAIService(settings => 
                settings.ApiKey = configuration.GetSection("OpenAIApiKey").Value!);

            services.AddScoped<IOpenAIService, OpenAIManager>();
            
            // Resend
            services.AddOptions();
            services.AddHttpClient<ResendClient>();
            services.Configure<ResendClientOptions>( o =>
            {
                o.ApiToken = configuration.GetSection("ReSendApiKey").Value!;
            } );
            services.AddTransient<IResend, ResendClient>();
            

            return services;
        }
    }
}
