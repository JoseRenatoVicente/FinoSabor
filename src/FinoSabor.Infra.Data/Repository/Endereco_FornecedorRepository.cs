using Microsoft.EntityFrameworkCore;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository
{
    public class Endereco_FornecedorRepository : BaseRepository<EnderecoFornecedor>, IEnderecoRepository
    {
        public Endereco_FornecedorRepository(FinoSaborContext context) : base(context) { }

        /*public async Task<Endereco_Fornecedor> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.FornecedorEnderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.id_fornecedor == fornecedorId);
        }*/
    }
}
