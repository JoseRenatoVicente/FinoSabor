using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Base.Repository;
using SistemaERP.Infra.Data.Context;
using SistemaERP.Infra.Data.Repository.Interfaces;

namespace SistemaERP.Infra.Data.Repository
{
    public class ImagemRepository : BaseRepository<Imagem>, IImagemRepository
    {
        public ImagemRepository(SistemaERPContext db) : base(db)
        {
        }
    }
}
