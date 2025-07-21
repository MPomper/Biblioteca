using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiemensEnergy.Library.Domain.Entities;

namespace SiemensEnergy.Library.Infrastructure.Data.Configurations
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasMaxLength(50).IsRequired();
            builder.HasMany(g => g.Livros)
            .WithOne(l => l.Genero)
            .HasForeignKey(l => l.IdGenero);
        }
    }
}
