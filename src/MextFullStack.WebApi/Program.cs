using MextFullStack.Persistence.Contexts;
using MextFullStack.Persistence.Services;
using MextFullStack.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true)
            .AllowAnyHeader());
});

// Singleton
builder.Services.AddSingleton<RequestCounterManager>();
builder.Services.AddSingleton<IRootPathService,RootPathManager>(container => new RootPathManager(builder.Environment.WebRootPath,
    container.GetRequiredService<RequestCounterManager>()
    ));
// Scoped
// Transient

//var applicationName = builder.Configuration["ApplicationName123"];

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//var connectionString = builder.Configuration.GetConnectionString("SQLiteConnection");

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase(connectionString)); 

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
