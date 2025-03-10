using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sistema_Bancario.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        // Método de extensión `AddPersistence` para configurar el servicio de DbContext con SQL Server.
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura el contexto de la base de datos `DbContextSQL`.
            services.AddDbContext<DbContextSQL>(opt =>
            {
                // Habilita el registro de comandos SQL en la consola para facilitar la depuración.
                opt.LogTo(Console.WriteLine, new[]
            {
                // Solo registra los comandos de la base de datos.

                DbLoggerCategory.Database.Command.Name

                // Habilita el registro de datos sensibles para propósitos de depuración.
            }, LogLevel.Information).EnableSensitiveDataLogging();

                // Configura SQL Server como proveedor de la base de datos y obtiene la cadena de conexión desde el archivo de configuración.
                opt.UseSqlServer(configuration.GetConnectionString("SQL"));
            });




            // Devuelve el servicio de colección modificado, que incluye `DbContextSQL`
            return services;
        }
    }
}
