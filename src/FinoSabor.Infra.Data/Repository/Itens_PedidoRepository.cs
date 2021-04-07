using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;

namespace FinoSabor.Infra.Data.Repository
{
    public class Itens_PedidoRepository : BaseRepository<Itens_Pedido>, IItens_PedidoRepository
    {
        public Itens_PedidoRepository(FinoSaborContext context) : base(context) { }
    }
}
