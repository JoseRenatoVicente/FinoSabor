using Microsoft.EntityFrameworkCore;
using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Base.Repository;
using SistemaERP.Infra.Data.Context;
using SistemaERP.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaERP.Infra.Data.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(SistemaERPContext db) : base(db)
        {
        }


        public async Task<Categoria> ObterSubCategorias(Guid id)
        {
            return await Db.Categorias.AsNoTracking()
                .Include(c => c.CategoriaPai)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Categoria>> ObterCategoriasPorCategoriaPai(Guid id)
        {
            return await Db.Categorias.OrderBy(a => a.Nome).Where(a => a.CategoriaPaiId == id).ToListAsync();
        }

    }
}
