using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Base.Repository;
using SistemaERP.Infra.Data.Repository.Interfaces;

namespace SistemaERP.Infra.Data.Repository
{
    public class EmailConfigRepository : BaseRepository<EmailConfig>, IEmailConfigRepository
    {
        public EmailConfigRepository(SistemaERPContext db) : base(db)
        {
        }



    }
}
