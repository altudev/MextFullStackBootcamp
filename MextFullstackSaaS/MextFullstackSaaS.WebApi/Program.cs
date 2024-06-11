using MextFullstackSaaS.Application;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Settings;
using MextFullstackSaaS.Infrastructure;
using MextFullstackSaaS.WebApi;
using MextFullstackSaaS.WebApi.Filters;
using MextFullstackSaaS.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("C:\\Users\\alper\\Desktop\\log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting web application");
    
    var builder = WebApplication.CreateBuilder(args);
    
    builder.Services.AddSerilog();

// Add services to the container.

    builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add<GlobalExceptionFilter>();
    });

    builder.Services.AddApplication();

    builder.Services.AddInfrastructure(builder.Configuration);

    builder.Services.AddWebServices(builder.Configuration);

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    builder.Services.AddSingleton<IRootPathService>(new RootPathManager(builder.Environment.WebRootPath));

    var app = builder.Build();

    app.UseCors("AllowAll");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseStaticFiles();

    var requestLocalizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();

    app.UseRequestLocalization(requestLocalizationOptions.Value);

    app.UseHttpsRedirection();

    app.UseAuthentication();
    
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception e)
{
    Log.Fatal(e, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}