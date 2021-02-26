using SistemaERP.Domain.Entities;
using SistemaERP.Infra.Data.Repository.Base;

namespace SistemaERP.Infra.Data.Repository.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        /*Task<Categoria> ObterSubCategorias(Guid id);
        Task<List<Categoria>> ObterCategoriasPorCategoriaPai(Guid id);*/
    }
}
