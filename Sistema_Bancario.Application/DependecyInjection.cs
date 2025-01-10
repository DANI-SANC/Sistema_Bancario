using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Sistema_Bancario.Application
{
    public static class DependecyInjection
    {
         // Se declara una clase estática llamada 'DependencyInjection'. Este tipo de clases se utilizan para contener métodos
    // de extensión o configuraciones relacionadas con la inyección de dependencias en el proyecto.

    

        public static IServiceCollection AddApplication(this IServiceCollection services)
        // Se define un método de extensión para la interfaz IServiceCollection. Este método extiende la funcionalidad
        // del contenedor de servicios, lo que permite registrar y configurar servicios adicionales.

        {
            services.AddMediatR(configuration =>
            // Se registra MediatR en el contenedor de servicios. MediatR es una biblioteca que implementa el patrón mediador,
            // lo que permite manejar solicitudes, comandos y notificaciones a través de manejadores (handlers) sin que las partes
            // estén directamente acopladas.

            {
                configuration.RegisterServicesFromAssembly(typeof(DependecyInjection).Assembly);
                // Se registra automáticamente en MediatR todos los manejadores definidos dentro del ensamblado donde se encuentra
                // la clase 'DependencyInjection'. Esto permite que MediatR encuentre y utilice los manejadores relevantes sin tener
                // que registrarlos manualmente.

                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

            });

            //   services.AddFluentValidationAutoValidation();
            // services.AddValidatorsFromAssemblyContaining<CursoCreateCommand>();

            services.AddValidatorsFromAssembly(typeof(DependecyInjection).Assembly);

            // services.AddAutoMapper(typeof(MappingProfile).Assembly);


            return services;
            // Retorna la colección de servicios después de registrar MediatR, lo que permite encadenar más registros si es necesario.

        }

    }
}
