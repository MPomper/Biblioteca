using FluentValidation;
using SiemensEnergy.Library.Application.Validators.Livro;
using System.Reflection;

namespace SiemensEnergy.Library.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}