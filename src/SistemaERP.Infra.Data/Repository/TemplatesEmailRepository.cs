using SistemaERP.Domain.Entities.Email;
using SistemaERP.Infra.Data.Base.Repository;
using SistemaERP.Infra.Data.Context;
using SistemaERP.Infra.Data.Repository.Interfaces;

namespace SistemaERP.Infra.Data.Repository
{
    public class TemplatesEmailRepository : BaseRepository<TemplatesEmail>, ITemplatesEmailRepository
    {
        public TemplatesEmailRepository(SistemaERPContext db) : base(db)
        {
        }



    }

}