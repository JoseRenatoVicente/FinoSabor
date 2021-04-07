using Microsoft.EntityFrameworkCore;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(FinoSaborContext db) : base(db)
        {
        }


    }
}
