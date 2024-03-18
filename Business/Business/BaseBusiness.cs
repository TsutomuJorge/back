using Entities.Entities;
using IBusiness.IBusiness;
using IRepository.IRepositories;

namespace Business.Business
{
    public abstract class BaseBusiness<TEntity> : IBaseBusiness<TEntity> where TEntity : EntidadeBase
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        protected BaseBusiness(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<TEntity> Add(TEntity entidade)
        {
            return _repository.Add(entidade, true);
        }

        public virtual Task AddBulk(IList<TEntity> entities)
        {
            return _repository.AddBulk(entities);
        }

        public virtual Task<TEntity> Delete(TEntity entidade)
        {
            return _repository.Add(entidade);
        }

        public virtual Task DeleteBulk(IList<TEntity> entities)
        {
            return _repository.DeleteBulk(entities);
        }

        public virtual Task<List<TEntity>> GetAll(bool asNoTracking = false)
        {
            return _repository.All(asNoTracking);
        }

        public virtual Task<TEntity> GetById(object id)
        {
            return _repository.GetById(id);
        }

        public virtual Task<TEntity> Update(TEntity entidade, bool saveAfter = false)
        {
            return _repository.Update(entidade, saveAfter);
        }

        public virtual Task UpdateBulk(IList<TEntity> entities)
        {
            return _repository.UpdateBulk(entities);
        }
    }
}
