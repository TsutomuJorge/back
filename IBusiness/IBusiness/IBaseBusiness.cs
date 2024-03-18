using Entities.Entities;

namespace IBusiness.IBusiness
{
    public interface IBaseBusiness<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity> GetById(object id);
        Task<List<TEntity>> GetAll(bool asNoTracking = false);
        Task<TEntity> Add(TEntity entidade);
        Task AddBulk(IList<TEntity> entities);
        Task<TEntity> Update(TEntity entidade, bool saveAfter = false);
        Task UpdateBulk(IList<TEntity> entities);
        Task<TEntity> Delete(TEntity entidade);
        Task DeleteBulk(IList<TEntity> entities);
    }
}
