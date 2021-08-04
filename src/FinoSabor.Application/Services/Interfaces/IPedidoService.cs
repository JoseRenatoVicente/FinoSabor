using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services.Interfaces
{
    public interface IPedidoService : IDisposable
    {
        Task<IEnumerable<PedidoViewModel>> ObterPedidosDoUsuario(Guid id_usuario);
        Task<PedidoDetalhadoViewModel> ObterPedidoDoUsuarioPorId(Guid id, Guid id_usuario);
        Task<IEnumerable<PedidoViewModel>> ObterTodosOsPedidos();
        Task<PedidoDetalhadoViewModel> ObterPorId(Guid id);
        Task<bool> Adicionar(Pedido pedido);
        Task<bool> Atualizar(Pedido pedido, Guid id_usuario);
        Task<bool> Remover(Guid id_pedido, Guid id_usuario);
    }
}
