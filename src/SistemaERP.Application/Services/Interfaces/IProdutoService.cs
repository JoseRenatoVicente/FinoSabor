using SistemaERP.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SistemaERP.Application.Services.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
