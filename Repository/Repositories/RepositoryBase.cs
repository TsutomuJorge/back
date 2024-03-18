using EFCore.BulkExtensions;
using Entities.Entities;
using IRepository.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Repository.Context;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Repository.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : EntidadeBase
    {
        protected readonly EstabelecimentoContext _context;
        protected virtual DbSet<TEntity> EntitySet { get; }
        public EstabelecimentoContext GetContext() => _context;
        private bool _disposedValue;
        private readonly SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        protected RepositoryBase(EstabelecimentoContext context)
        {
            _context = context;
            EntitySet = _context.Set<TEntity>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }

                _disposedValue = true;
            }
        }

        public virtual Task<TEntity> GetById(object id) => Task.Run(async () => await EntitySet.FindAsync(id));

        public async Task<TEntity> Add(TEntity entity, bool saveAfter = false)
        {
            var entityEntry = await EntitySet.AddAsync(entity);
            if (saveAfter) await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual async Task AddRange(IList<TEntity> entities, bool saveAfter = false)
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    await Add(entity, saveAfter);
                }
            }
        }

        public virtual async Task AddBulk(TEntity entity)
        {
            await AddBulk(new List<TEntity>() { entity });
        }

        public virtual async Task AddBulk(IList<TEntity> entities)
        {
            if (entities != null)
            {
                await _context.BulkInsertAsync(entities, options => options.IncludeGraph = true);
            }
        }

        public virtual async Task<bool> Any()
        {
            return await EntitySet.AnyAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity, bool saveAfter = false)
        {
            var entityEntry = EntitySet.Update(entity);
            if (saveAfter) await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual async Task UpdateRange(IList<TEntity> entities, bool saveAfter = false)
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    await Update(entity, saveAfter);
                }
            }
        }

        public virtual async Task UpdateBulk(IList<TEntity> entities)
        {
            if (entities != null)
            {
                await _context.BulkUpdateAsync(entities);
            }
        }

        public virtual async Task<TEntity> Delete(TEntity entity, bool saveAfter = false)
        {
            var entityEntry = EntitySet.Remove(entity);
            if (saveAfter) await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> DeleteById(object id, bool saveAfter = false)
        {
            var entity = await EntitySet.FindAsync(id);
            var entityEntry = EntitySet.Remove(entity);
            if (saveAfter) await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual async Task DeleteByIds<T>(List<T> ids, bool saveAfter = false)
        {
            foreach (var id in ids)
                await DeleteById(id, saveAfter);
        }

        public virtual async Task DeleteRange(IList<TEntity> entities, bool saveAfter = false)
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    await Delete(entity, saveAfter);
                }
            }
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            EntitySet.RemoveRange(entities);
        }

        public virtual async Task DeleteBulk(IList<TEntity> entities)
        {
            if (entities != null)
            {
                await _context.BulkDeleteAsync(entities);
            }
        }

        public virtual Task<List<TEntity>> All(bool asNoTracking = false)
        {
            if (asNoTracking)
                return EntitySet.AsNoTracking().ToListAsync();
            else
                return EntitySet.ToListAsync();
        }

        public virtual Task<int> Save() => _context.SaveChangesAsync();

        public virtual IQueryable<TEntity> AgregarIncludes(Expression<Func<TEntity, object>>[] includes)
        {
            return includes.Aggregate(EntitySet.AsQueryable(), (current, include) => current.Include(include));
        }
    }
}
