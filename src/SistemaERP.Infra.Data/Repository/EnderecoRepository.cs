using Microsoft.EntityFrameworkCore;
using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Base.Repository;
using SistemaERP.Infra.Data.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace SistemaERP.Infra.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco_Fornecedor>, IEnderecoRepository
    {
        public EnderecoRepository(SistemaERPContext context) : base(context) { }

        /*public async Task<Endereco_Fornecedor> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.FornecedorEnderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.id_fornecedor == fornecedorId);
        }*/
    }
}
