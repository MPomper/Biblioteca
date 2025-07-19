using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiemensEnergy.Library.Domain.Entities;

namespace SiemensEnergy.Library.Infrastructure.Data.Configurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(255).IsRequired();
            builder.HasMany(g => g.Livros)
            .WithOne(l => l.Autor)
            .HasForeignKey(l => l.IdAutor);
        }
    }
}
