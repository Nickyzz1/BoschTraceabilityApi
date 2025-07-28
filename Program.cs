using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Interfaces;
using MyApi.Repositories;
using MyApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BoschDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    // options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    // options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// todos os repos e services
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddScoped<PartService>();

builder.Services.AddScoped<IStationRepository, StationRepository>();
builder.Services.AddScoped<StationService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
