using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository
{
    public class EmailConfigRepository : BaseRepository<EmailConfig>, IEmailConfigRepository
    {
        public EmailConfigRepository(FinoSaborContext db) : base(db)
        {
        }

        public async Task<EmailConfig> PegarEmailPorPrioridade(int prioridade)
        {
            var iquerable = await GetAllAsync();

            return await iquerable.FirstOrDefaultAsync(x => x.Prioridade == prioridade);
        }

    }
}
