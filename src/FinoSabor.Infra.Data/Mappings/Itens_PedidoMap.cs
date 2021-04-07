using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Infra.Data.Mappings
{
    public class Itens_PedidoMap : IEntityTypeConfiguration<Itens_Pedido>
    {
        public void Configure(EntityTypeBuilder<Itens_Pedido> builder)
        {

        }
    }
}
