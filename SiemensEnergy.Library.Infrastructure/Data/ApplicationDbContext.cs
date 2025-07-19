using SiemensEnergy.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SiemensEnergy.Library.Domain.Entities;
using System.Reflection;

namespace SiemensEnergy.Library.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Livro> Livros => Set<Livro>();
        public DbSet<Autor> Autores => Set<Autor>();
        public DbSet<Genero> Generos => Set<Genero>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
