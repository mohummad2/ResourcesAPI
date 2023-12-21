using Microsoft.EntityFrameworkCore;
using ResourcesAPI.Configuration;
using ResourcesAPI.Data;
using ResourcesAPI.Repositories;
using ResourcesAPI.Repositories.Interfaces;
using ResourcesAPI.Services;
using ResourcesAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.Get<AppSettings>();

builder.Services.AddDbContext<ResourcesContext>(options =>
{
    options.EnableDetailedErrors();
    options.UseSqlServer(appSettings.ConnectionStrings!.DefaultConnection);
}, contextLifetime: ServiceLifetime.Scoped,
optionsLifetime: ServiceLifetime.Singleton);

builder.Services.AddScoped(typeof(IResourcesRepository<>), typeof(ResourcesRepository<>));

builder.Services.AddScoped<IWorkersService, WorkersService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
