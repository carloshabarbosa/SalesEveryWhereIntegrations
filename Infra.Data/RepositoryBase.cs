using System.Linq.Expressions;
using Domain._Base;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class RepositoryBase<TId, TEntity>
                    where TId : struct
                where TEntity : Entity<TId, TEntity>
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DataBaseContext _context;
        public RepositoryBase(DataBaseContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }
        public async Task AddAsync(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
            _context.SaveChanges();

        }
        public void Add(TEntity obj) => _dbSet.Add(obj);

        public async Task AddMany(IEnumerable<TEntity> entities) => await _dbSet.AddRangeAsync(entities);

        public void Remove(TEntity obj) => _dbSet.Remove(obj);

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _dbSet.Where(predicate).ToListAsync();
        public async Task<TEntity?> GetByIdAsync(TId id) =>

            await _dbSet.FindAsync(id);

        public void Save() => _context.SaveChanges();

        public IQueryable<TEntity> BeginQuery() => _dbSet.AsQueryable();
    }
}