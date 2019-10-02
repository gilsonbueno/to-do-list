using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected DataBaseContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(DataBaseContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToArray();
        }

        public virtual TEntity Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual TEntity GetById(int id)
        {
            var result = _dbSet.Find(id);
            _context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
