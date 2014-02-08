using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OutOfSpace.Web.Data
{
    interface IGenericRepository<T> where T : class 
    {
        T Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(Int64 id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
