using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OutOfSpace.Web.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private readonly IDbSet<T> _dbset;

        public GenericRepository(IDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            var entry = _context.Entry(entity);
            _dbset.Attach(entity);
            entry.State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual T GetById(Int64 id)
        {
            return _dbset.Find(id);
        }

        public virtual IEnumerable<T> All()
        {
            return _dbset;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }
    }
}