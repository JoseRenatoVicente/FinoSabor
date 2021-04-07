using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Infra.Data.Mappings
{
    public class Imagem_ProdutoMap : IEntityTypeConfiguration<Imagem_Produto>
    {
        public void Configure(EntityTypeBuilder<Imagem_Produto> builder)
        {

        }
    }
}
