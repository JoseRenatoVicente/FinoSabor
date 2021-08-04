using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels.Pessoa;
using FinoSabor.Infra.Data.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository.Interfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        Task<IEnumerable<PessoaViewModel>> GetAllAdmins();
        Task<IEnumerable<PessoaViewModel>> GetAllComuns();
    }
}
