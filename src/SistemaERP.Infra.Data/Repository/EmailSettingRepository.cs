using SistemaERP.Domain.Entities.Email;
using SistemaERP.Infra.Data.Base.Repository;
using SistemaERP.Infra.Data;
using SistemaERP.Infra.Data.Repository.Interfaces;

namespace SistemaERP.Infra.Data.Repository
{
    public class EmailSettingRepository : BaseRepository<EmailSetting>, IEmailSettingRepository
    {
        public EmailSettingRepository(SistemaERPContext db) : base(db)
        {
        }



    }
}
