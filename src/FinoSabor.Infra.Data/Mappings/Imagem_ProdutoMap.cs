using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Infra.Data.Mappings
{
    public class Imagem_ProdutoMap : IEntityTypeConfiguration<ImagemProduto>
    {
        public void Configure(EntityTypeBuilder<ImagemProduto> builder)
        {

        }
    }
}
