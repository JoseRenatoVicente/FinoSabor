﻿using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;

namespace FinoSabor.Infra.Data.Repository
{
    public class ImagemRepository : BaseRepository<Imagem_Produto>, IImagemRepository
    {
        public ImagemRepository(FinoSaborContext db) : base(db)
        {
        }
    }
}
