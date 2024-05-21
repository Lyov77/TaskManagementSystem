using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagementSystem.BLL.Repositories.Base;
using TaskManagementSystem.Core.Entities.Base;
using TaskManagementSystem.DAL.Context;

namespace TaskManagementSystem.DAL.Repositories.Base
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected TaskerApplicationDbContext _context;
        protected RepositoryBase(TaskerApplicationDbContext context)
            => _context = context;

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            return entity;
        }

        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>>? expression = null,
            bool noTrack = false)
        {
            if (expression == null)
            {
                return _context.Set<TEntity>();
            }

            var query = _context.Set<TEntity>().Where(expression);

            return noTrack ? query : query.AsNoTracking();
        }
    }
}
