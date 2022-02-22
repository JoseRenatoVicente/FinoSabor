using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Infra.Data.Mappings
{
    public class Itens_CompraMap : IEntityTypeConfiguration<ItensCompra>
    {
        public void Configure(EntityTypeBuilder<ItensCompra> builder)
        {

        }
    }
}
