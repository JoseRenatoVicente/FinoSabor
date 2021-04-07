using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Base;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco_Fornecedor>
    {
        //Task<Endereco_Fornecedor> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
