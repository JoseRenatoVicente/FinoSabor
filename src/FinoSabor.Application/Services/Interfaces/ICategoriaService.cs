using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services.Interfaces
{
    public interface ICategoriaService : IDisposable
    {
        Task<IEnumerable<Categoria>> ObterCategorias();
        Task<Categoria> ObterCategoriaPorId(Guid id);
        Task<bool> Adicionar(Categoria fornecedor);
        Task<bool> Atualizar(Categoria fornecedor);
        Task<bool> Remover(Guid id);
    }
}
