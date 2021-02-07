using Microsoft.EntityFrameworkCore;
using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Base.Repository;
using SistemaERP.Infra.Data.Repository.Interfaces;
using System.Threading.Tasks;

namespace SistemaERP.Infra.Data.Repository
{
    public class EmailConfigRepository : BaseRepository<EmailConfig>, IEmailConfigRepository
    {
        public EmailConfigRepository(SistemaERPContext db) : base(db)
        {
        }

        public async Task<EmailConfig> PegarEmailPorPrioridade(int prioridade)
        {
            var iquerable = await GetAllAsync();

            return await iquerable.FirstOrDefaultAsync(x => x.Prioridade == prioridade);
        }

    }
}
