using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Repository.Base;
using System.Threading.Tasks;

namespace SistemaERP.Infra.Data.Repository.Interfaces
{
    public interface IEmailConfigRepository : IBaseRepository<EmailConfig>
    {
        Task<EmailConfig> PegarEmailPorPrioridade(int prioridade);
    }
}
