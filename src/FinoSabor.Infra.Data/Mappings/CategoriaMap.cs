using FinoSabor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinoSabor.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            /*
            builder.HasIndex(c => c.nome).IsUnique();
            builder.Property(c => c.nome)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)                
                .IsRequired();

            builder.Property(c => c.slug)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsUnicode()
                .IsRequired();
            */
        }
    }
}
