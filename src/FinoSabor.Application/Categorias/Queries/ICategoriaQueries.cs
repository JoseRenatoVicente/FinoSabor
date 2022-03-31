using FinoSabor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Application.Categorias.Queries
{
    public interface ICategoriaQueries
    {
        Task<IEnumerable<Categoria>> ObterCategorias();
        Task<Categoria> ObterCategoriaPorId(Guid id);
    }
}
