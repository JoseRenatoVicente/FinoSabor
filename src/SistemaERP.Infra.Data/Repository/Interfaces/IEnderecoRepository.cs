using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Repository.Base;
using System;
using System.Threading.Tasks;

namespace SistemaERP.Infra.Data.Repository.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
