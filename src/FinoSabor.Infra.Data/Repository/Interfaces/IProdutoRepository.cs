using FinoSabor.Application.ViewModels;
using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Infra.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<ProdutoViewModel> ObterProdutoPorId(Guid id);
        Task<ProdutoClienteViewModel> ObterProdutoPorSlug(string slug);
        Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterProdutosCliente();
        Task<List<ProdutoClienteObterTodosViewModel>> ObterProdutosPorIds(string ids);
        Task<PagedList<ProdutoViewModel>> PaginacaoAdminAsync(int PagNumero, int PagRegistro, string busca = null);
    }
}
