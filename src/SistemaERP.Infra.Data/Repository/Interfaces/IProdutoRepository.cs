using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaERP.Infra.Data.Repository.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);

        Task<List<Produto>> ObterProdutoPorCategoria(Guid id);
    }
}
