using FinoSabor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinoSabor.Infra.Data.Mappings
{
    public class ItensCompraMap : IEntityTypeConfiguration<ItensCompra>
    {
        public void Configure(EntityTypeBuilder<ItensCompra> builder)
        {

        }
    }
}
