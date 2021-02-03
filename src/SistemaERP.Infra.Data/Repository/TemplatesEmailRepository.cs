﻿using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Base.Repository;
using SistemaERP.Infra.Data.Repository.Interfaces;

namespace SistemaERP.Infra.Data.Repository
{
    public class TemplatesEmailRepository : BaseRepository<EmailModelo>, ITemplatesEmailRepository
    {
        public TemplatesEmailRepository(SistemaERPContext db) : base(db)
        {
        }



    }

}