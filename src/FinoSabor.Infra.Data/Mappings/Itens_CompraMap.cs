using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Infra.Data.Mappings
{
    public class Itens_CompraMap : IEntityTypeConfiguration<Itens_Compra>
    {
        public void Configure(EntityTypeBuilder<Itens_Compra> builder)
        {

        }
    }
}
