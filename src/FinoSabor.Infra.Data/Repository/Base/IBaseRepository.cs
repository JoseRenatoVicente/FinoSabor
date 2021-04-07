using FinoSabor.Domain.Entities.Base;
using FinoSabor.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository.Base
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        //Geral
        Task<PagedList<TEntity>> GetAllCount();

        Task<Tuple<IEnumerable<TEntity>, int>> GetAll(int skip, int take, bool asNoTracking = true);
        Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IQueryable<TEntity>> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<PagedList<TEntity>> GetPagingAsyncWhere(Expression<Func<TEntity, bool>> where, int PagNumero = 1, int PagRegistro = 4, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<PagedList<TEntity>> GetPagingAsync(int PagNumero = 1, int PagRegistro = 4);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<bool> Existe(Func<TEntity, bool> where);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> where);
        Task<TEntity> ObterPor(Expression<Func<TEntity, bool>> where);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(Guid id);
        Task DeleteRangeAsync(Func<TEntity, bool> where);
        Task SaveChangesAsync();
    }
}
