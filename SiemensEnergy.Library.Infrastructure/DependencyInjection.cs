using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiemensEnergy.Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Infrastructure.Repositories;

namespace SiemensEnergy.Library.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddScoped<IAutorRepository, AutorRepository>();

            return services;
        }
    }
}
