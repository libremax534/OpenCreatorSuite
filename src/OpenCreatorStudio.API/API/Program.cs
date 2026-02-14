using Microsoft.EntityFrameworkCore;
using OpenCreatorStudio.Application.Interfaces;
using OpenCreatorStudio.Application.Services;
using OpenCreatorStudio.Infrastructure.Data;
using OpenCreatorStudio.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuration MySQL
var connectionString = builder.Configuration.GetConnectionString("MySql")
    ?? throw new InvalidOperationException("Chaîne de connexion MySQL manquante");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Injection de dépendances - Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<NodeRepository>();
builder.Services.AddScoped<ConnectionRepository>();

// Injection de dépendances - Services
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Configuration CORS pour Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Configuration Controllers
builder.Services.AddControllers();

// Configuration Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "OpenCreatorStudio API",
        Version = "v1",
        Description = "API REST pour OpenCreatorStudio - Migration WPF vers Angular 20 + .NET 9"
    });
});

var app = builder.Build();

// Configuration du pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

app.Run();
