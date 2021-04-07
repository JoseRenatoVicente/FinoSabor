using Microsoft.EntityFrameworkCore;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(FinoSaborContext db) : base(db)
        {
        }

        /*public async Task<Categoria> ObterSubCategorias(Guid id)
        {
            return await Db.Categorias.AsNoTracking()
                .Include(c => c.CategoriaPai)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Categoria>> ObterCategoriasPorCategoriaPai(Guid id)
        {
            return await Db.Categorias.OrderBy(a => a.Nome).Where(a => a.CategoriaPaiId == id).ToListAsync();
        }*/

    }
}
