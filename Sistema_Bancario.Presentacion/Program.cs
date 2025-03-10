

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
    // Configura los requisitos de la contrase�a
    options.Password.RequireDigit = false; // Permite contrase�as sin d�gitos
    options.Password.RequireLowercase = true; // Requiere letras min�sculas
    options.Password.RequireUppercase = false; // Permite contrase�as sin may�sculas
    options.Password.RequireNonAlphanumeric = false; // Permite contrase�as sin caracteres especiales
    options.Password.RequiredLength = 3; // Configura la longitud m�nima de la contrase�a
})
    .AddEntityFrameworkStores<DbContextSQL>()
    .AddDefaultTokenProviders();

// Registrar MediatR para m�ltiples ensamblados
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

// Aseg�rate de que este registro est� en el contenedor de dependencias
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

