

using Sistema_Bancario.Infrastructure.Persistence;
using Sistema_Bancario.Application;
using MediatR;
using Sistema_Bancario.Application.Account.Register;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Sistema_Bancario.Dominio;
using System.Reflection;
using Sistema_Bancario.Application.Interfaces;
using Sistema_Bancario.Infrastructure.Respositories;
using Sistema_Bancario.Application.RoleCommand.Create;

var builder = WebApplication.CreateBuilder(args);


//Inyeccion DbContext
builder.Services.AddPersistence(builder.Configuration);

// Configurar Identity
builder.Services.AddIdentity<AplicationUser, IdentityRole>(options =>
{
    // Configura los requisitos de la contraseña
    options.Password.RequireDigit = false; // Permite contraseñas sin dígitos
    options.Password.RequireLowercase = true; // Requiere letras minúsculas
    options.Password.RequireUppercase = false; // Permite contraseñas sin mayúsculas
    options.Password.RequireNonAlphanumeric = false; // Permite contraseñas sin caracteres especiales
    options.Password.RequiredLength = 3; // Configura la longitud mínima de la contraseña
})
    .AddEntityFrameworkStores<DbContextSQL>()
    .AddDefaultTokenProviders();

// Registrar MediatR para múltiples ensamblados
/*
foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}*/

builder.Services.AddApplication();


builder.Services.AddControllers();// Agrega el soporte para los controladores, que manejan las solicitudes HTTP.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Asegúrate de que este registro esté en el contenedor de dependencias
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Solo habilita Swagger en entorno de desarrollo para documentar y probar la API
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

