using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Application.Produtos.Queries
{
    public interface IProdutoQueries
    {
        Task<IEnumerable<ProdutoViewModel>> ObterProdutos();
        Task<PagedList<ProdutoViewModel>> ObterProdutos(int PagNumero, int PagRegistro, string busca = null);

        Task<ProdutoViewModel> ObterProdutosPorId(Guid id);
    }
}
