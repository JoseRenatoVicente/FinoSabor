using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Base;

namespace FinoSabor.Infra.Data.Repository.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        /*Task<Categoria> ObterSubCategorias(Guid id);
        Task<List<Categoria>> ObterCategoriasPorCategoriaPai(Guid id);*/
    }
}
