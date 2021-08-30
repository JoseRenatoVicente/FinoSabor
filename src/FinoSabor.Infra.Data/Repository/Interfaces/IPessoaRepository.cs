using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Domain.ViewModels.Pessoa;
using FinoSabor.Infra.Data.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository.Interfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        Task<PagedList<PessoaViewModel>> PaginacaoGetAllAdminAsync(int PagNumero, int PagRegistro, string busca = null);
        Task<PagedList<PessoaViewModel>> PaginacaoGetAllClientesAsync(int PagNumero, int PagRegistro, string busca = null);
    }
}
