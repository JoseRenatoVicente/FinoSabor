using SistemaERP.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SistemaERP.Application.Services.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<bool> Adicionar(Fornecedor fornecedor);
        Task<bool> Atualizar(Fornecedor fornecedor);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(Endereco_Fornecedor endereco);
    }
}
