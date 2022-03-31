using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Base;

namespace FinoSabor.Infra.Data.Repository.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<EnderecoFornecedor>
    {
        //Task<Endereco_Fornecedor> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
