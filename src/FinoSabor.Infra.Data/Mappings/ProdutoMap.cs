using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            /*
            builder.Property(c => c.nome)
                .HasColumnType("varchar(25)")
                .HasMaxLength(25)
                .IsUnicode()
                .IsRequired();

            builder.Property(c => c.descricao)
                .HasColumnType("varchar(80)")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(c => c.valor)
                .HasColumnType("FLOAT(5,2)")
                .IsRequired();

            builder.Property(c => c.slug)
               .HasColumnType("varchar(30)")
               .HasMaxLength(30)
               .IsUnicode()
               .IsRequired();

            builder.Property(c => c.quantidade_estoque)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.quantidade_minima)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.imagem_principal)
                .HasColumnType("varchar(60)");

            builder.Property(c => c.ativo)
                .IsRequired();


            builder.Property(c => c.largura)
                .IsRequired();

            builder.Property(c => c.altura)
                .IsRequired();

            builder.Property(c => c.comprimento)
                .IsRequired();
            */
        }
    }
}
