using Entities.Entities;

namespace IRepository.IRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity> GetById(object id);
        Task<List<TEntity>> All(bool asNoTracking = false);
        Task<TEntity> Add(TEntity entity, bool saveAfter = false);
        Task AddBulk(TEntity entity);
        Task AddBulk(IList<TEntity> entities);
        Task<TEntity> Update(TEntity entity, bool saveAfter = false);
        Task UpdateRange(IList<TEntity> entities, bool saveAfter = false);
        Task UpdateBulk(IList<TEntity> entities);
        Task<TEntity> Delete(TEntity entity, bool saveAfter = false);
        Task<TEntity> DeleteById(object id, bool saveAfter = false);
        Task DeleteByIds<T>(List<T> ids, bool saveAfter = false);
        Task DeleteBulk(IList<TEntity> entities);
        Task DeleteRange(IList<TEntity> entities, bool saveAfter = false);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task AddRange(IList<TEntity> entities, bool saveAfter = false);
        Task<bool> Any();
        Task<int> Save();
    }
}
