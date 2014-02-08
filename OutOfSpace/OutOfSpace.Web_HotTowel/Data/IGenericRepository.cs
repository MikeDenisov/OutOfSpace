using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OutOfSpace.API.Data
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
