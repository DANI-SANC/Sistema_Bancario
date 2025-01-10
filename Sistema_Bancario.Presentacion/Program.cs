

using Sistema_Bancario.Infrastructure.Persistence;
using Sistema_Bancario.Application;
using MediatR;
using Sistema_Bancario.Application.Account.Register;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Sistema_Bancario.Dominio;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


//Inyeccion DbContext
builder.Services.AddPersistence(builder.Configuration);

// Configurar Identity
builder.Services.AddIdentity<AplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DbContextSQL>()
    .AddDefaultTokenProviders();

// Registrar MediatR directamente sin el paquete obsoleto
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddControllers();// Agrega el soporte para los controladores, que manejan las solicitudes HTTP.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

