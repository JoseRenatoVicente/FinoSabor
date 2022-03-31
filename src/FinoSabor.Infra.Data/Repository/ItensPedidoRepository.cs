using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;

namespace FinoSabor.Infra.Data.Repository
{
    public class ItensPedidoRepository : BaseRepository<ItensPedido>, IItens_PedidoRepository
    {
        public ItensPedidoRepository(FinoSaborContext context) : base(context) { }
    }
}
