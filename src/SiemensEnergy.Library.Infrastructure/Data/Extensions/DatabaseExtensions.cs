using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SiemensEnergy.Library.Infrastructure.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }
        private static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedAutorAsync(context);
            await SeedGeneroAsync(context);
            await SeedLivroAsync(context);
        }

        private static async Task SeedAutorAsync(ApplicationDbContext context)
        {
            if (!await context.Autores.AnyAsync())
            {
                await using var transaction = await context.Database.BeginTransactionAsync();

                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Autores ON");
                await context.Autores.AddRangeAsync(InitialData.Autores);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Autores OFF");

                await transaction.CommitAsync();
            }
        }

        private static async Task SeedGeneroAsync(ApplicationDbContext context)
        {
            if (!await context.Generos.AnyAsync())
            {
                await using var transaction = await context.Database.BeginTransactionAsync();

                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Generos ON");
                await context.Generos.AddRangeAsync(InitialData.Generos);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Generos OFF");

                await transaction.CommitAsync();
            }
        }

        private static async Task SeedLivroAsync(ApplicationDbContext context)
        {
            if (!await context.Livros.AnyAsync())
            {
                await using var transaction = await context.Database.BeginTransactionAsync();

                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Livros ON");
                await context.Livros.AddRangeAsync(InitialData.Livros);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Livros OFF");

                await transaction.CommitAsync();
            }
        }
    }
}
