using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services.Interfaces
{
    public interface ICompraService : IDisposable
    {
        Task<IEnumerable<CompraViewModel>> ObterTodos();
        Task<CompraDetalhadaViewModel> ObterPorId(Guid id);
        Task<bool> Adicionar(Compra compra);
        Task<bool> Atualizar(Compra compra);
        Task<bool> Remover(Guid id);
    }
}
