using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Core.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        T Insert(T entity);
        void Delete(T entity);
        void Save();
    }
}
