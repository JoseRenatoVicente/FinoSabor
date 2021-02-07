using SistemaERP.Domain.Entities.Base;
using SistemaERP.Domain.Helpers;
using SistemaERP.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaERP.Infra.Data.Base.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly SistemaERPContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(SistemaERPContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }


        public virtual async Task<Tuple<IEnumerable<TEntity>, int>> GetAll
        (
            int skip,
            int take,
            bool asNoTracking = true
        )
        {
            var databaseCount = await DbSet.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Tuple<IEnumerable<TEntity>, int>
                (
                    await DbSet.AsNoTracking().Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                    databaseCount
                );

            return new Tuple<IEnumerable<TEntity>, int>
            (
                await DbSet.Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                databaseCount
            );
        }


        public async Task<Paginacao<TEntity>> GetPagingAsync(int PagNumero, int PagRegistro)
        {
            var iquerable = await GetAllAsync();

            var quantidadeTotalRegistros = await iquerable.CountAsync();
            var list = await iquerable.Skip((PagNumero - 1) * PagRegistro).Take(PagRegistro).ToListAsync();

            return new Paginacao<TEntity>
            {
                NumeroPagina = PagNumero,
                RegistroPorPagina = quantidadeTotalRegistros <= PagRegistro ? quantidadeTotalRegistros : PagRegistro,
                TotalRegistros = quantidadeTotalRegistros,
                TotalPaginas = (int)Math.Ceiling((double)quantidadeTotalRegistros / PagRegistro),
                Data = list
            };
        }

        public async Task<IQueryable<TEntity>> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return (await GetAllAsync(includeProperties)).Where(where);
        }

        public async Task<Paginacao<TEntity>> GetPagingAsyncWhere(Expression<Func<TEntity, bool>> where, int PagNumero = 1, int PagRegistro = 4, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var iquerable = (await GetAllAsync(includeProperties)).Where(where);

            var quantidadeTotalRegistros = await iquerable.CountAsync();
            var list = await iquerable.Skip((PagNumero - 1) * PagRegistro).Take(PagRegistro).ToListAsync();

            return new Paginacao<TEntity>
            {
                NumeroPagina = PagNumero,
                RegistroPorPagina = PagRegistro,
                TotalRegistros = quantidadeTotalRegistros,
                TotalPaginas = (int)Math.Ceiling((double)quantidadeTotalRegistros / PagRegistro),
                Data = list
            };
        }


        public async Task<Paginacao<TEntity>> GetAllCount()
        {
            var iquerable = await GetAllAsync();

            var quantidadeTotalRegistros = await iquerable.CountAsync();

            return new Paginacao<TEntity>
            {
                TotalRegistros = quantidadeTotalRegistros,
                Data = iquerable.ToList()
            };
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = DbSet.AsNoTracking();

            if (includeProperties.Any())
            {
                return await Include(DbSet, includeProperties);
            }

            return query;
        }


        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var iquerable = await GetAllAsync();

            return await iquerable.FirstOrDefaultAsync(x => x.Id == id);
        }


        /// <summary>
        /// Verifica se existe algum objeto com a condição informada
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<bool> Existe(Func<TEntity, bool> where)
        {
            var iquerable = await GetAllAsync();
            return iquerable.Any(where);
        }

        /// <summary>
        /// Verifica se existe algum objeto pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> ExisteId(Guid? id)
        {
            if (id == null) return true;

            var iquerable = await GetAllAsync();
            return await iquerable.AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> where)
        {
            return await DbSet.AsNoTracking().Where(where).ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity).ConfigureAwait(false);
            await SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities).ConfigureAwait(false);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Db.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Db.UpdateRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            Db.Remove(new TEntity { Id = id });
            await SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(Guid[] entityArray)
        {
            Db.RemoveRange(entityArray);
            await SaveChangesAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Realiza include populando o objeto passado por parametro
        /// </summary>
        /// <param name="query">Informe o objeto do tipo IQuerable</param>
        /// <param name="includeProperties">Ínforme o array de expressões que deseja incluir</param>
        /// <returns></returns>
        private Task<IQueryable<TEntity>> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Task.Run(() =>
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }

                return query;

            });
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
