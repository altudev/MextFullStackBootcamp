using System.Globalization;
using System.Text;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace MextFullstackSaaS.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            // SignalR
            services.AddSignalR();
            
            services.AddMemoryCache();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });


            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var defaultCulture = new CultureInfo("en-GB");

                var supportedCultures = new List<CultureInfo>
                {
                    defaultCulture,
                    new CultureInfo("tr-TR")
                };

                options.DefaultRequestCulture = new RequestCulture(defaultCulture);

                options.SupportedCultures = supportedCultures;

                options.SupportedUICultures = supportedCultures;

                options.ApplyCurrentCultureToResponseHeaders = true;
            });

            services.AddEndpointsApiExplorer();
            
            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "v1",
                    new OpenApiInfo()
                    {
                        Title = "MextFullStackSaaS Web API",
                        Version = "1",
                        Description = "Through this API you can access MextFullStackSaaS App's details",
                        Contact = new OpenApiContact()
                        {
                            Email = "alper.tunga@yazilim.academy",
                            Name = "Alper Tunga",
                            Url = new Uri("https://yazilim.academy/")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "© 2024 Yazılım Academy Tüm Hakları Saklıdır",
                            Url = new Uri("https://yazilim.academy/")
                        }
                    });

                setupAction.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });
            
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();
            
            // Install Microsoft.AspNetCore.Authentication.JwtBearer nuget
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!))
                    };
                    
                });
            return services;
        }
    }
}
