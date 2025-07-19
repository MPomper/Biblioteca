using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiemensEnergy.Library.Domain.Entities;

namespace SiemensEnergy.Library.Infrastructure.Data.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).HasMaxLength(150).IsRequired();

            builder.HasOne(x => x.Autor)
            .WithMany(a => a.Livros)
            .HasForeignKey(x => x.IdAutor)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Genero)
            .WithMany(g => g.Livros)
            .HasForeignKey(x => x.IdGenero)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
