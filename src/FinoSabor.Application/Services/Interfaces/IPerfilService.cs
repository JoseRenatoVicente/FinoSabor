using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels.Pessoa;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services.Interfaces
{
    public interface IPerfilService : IDisposable
    {
        Task<PessoaUpdateViewModel> ObterDados(Guid id_usuario);
        Task<bool> Atualizar(Pessoa pessoa);
    }
}
