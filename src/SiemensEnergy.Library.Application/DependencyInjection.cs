using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SiemensEnergy.Library.Application.Commands.Autor;
using SiemensEnergy.Library.Application.Commands.Genero;
using SiemensEnergy.Library.Application.Commands.Livro;
using SiemensEnergy.Library.Application.Validators.Livro;
using System.Reflection;

namespace SiemensEnergy.Library.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Add MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateLivroCommand).Assembly));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateAutorCommand).Assembly));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateGeneroCommand).Assembly));

            // Add FluentValidation
            services.AddValidatorsFromAssembly(typeof(CreateLivroDtoValidator).Assembly);

            return services;
        }
    }
}
