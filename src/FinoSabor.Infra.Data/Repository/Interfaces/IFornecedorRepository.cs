using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Infra.Data.Repository.Base;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository.Interfaces
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
        Task<PagedList<FornecedorViewModel>> PaginacaoAsync(int PagNumero, int PagRegistro);
    }
}
