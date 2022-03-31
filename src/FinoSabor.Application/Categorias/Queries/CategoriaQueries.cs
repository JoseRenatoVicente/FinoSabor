using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Application.Categorias.Queries
{
    public class CategoriaQueries : ICategoriaQueries
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaQueries(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _categoriaRepository.GetAllAsync();
        }
        public async Task<Categoria> ObterCategoriaPorId(Guid id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }
    }
}
