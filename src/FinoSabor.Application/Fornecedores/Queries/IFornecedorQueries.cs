using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Application.Fornecedores.Queries
{
    public interface IFornecedorQueries
    {
        Task<PagedList<FornecedorViewModel>> ObterFornecedores(int PagNumero, int PagRegistro, string busca = null);
        Task<Fornecedor> ObterFornecedorPorId(Guid id);
        Task<EnderecoViewModel> ObterEnderecorPorId(Guid id);

    }
}
