using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Repository.Base;
using System;
using System.Threading.Tasks;

namespace SistemaERP.Infra.Data.Repository.Interfaces
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
