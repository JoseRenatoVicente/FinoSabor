using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;

namespace FinoSabor.Infra.Data.Repository
{
    public class EnderecoFornecedorRepository : BaseRepository<EnderecoFornecedor>, IEnderecoRepository
    {
        public EnderecoFornecedorRepository(FinoSaborContext context) : base(context) { }

        /*public async Task<Endereco_Fornecedor> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.FornecedorEnderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.id_fornecedor == fornecedorId);
        }*/
    }
}
