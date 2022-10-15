using System.Linq.Expressions;

namespace Domain._Base.Repository
{
    public interface IRepositoryBase<TId, TEntity>
    {
        Task AddAsync(TEntity obj);
        void Add(TEntity obj);
        Task AddMany(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(TId id);
        void Remove(TEntity obj);
        void Save();
        IQueryable<TEntity> BeginQuery();
    }
}