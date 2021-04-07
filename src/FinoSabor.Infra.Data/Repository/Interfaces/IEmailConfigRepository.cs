using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Base;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository.Interfaces
{
    public interface IEmailConfigRepository : IBaseRepository<EmailConfig>
    {
        Task<EmailConfig> PegarEmailPorPrioridade(int prioridade);
    }
}
