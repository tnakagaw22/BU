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
        T GetById(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");
        T Insert(T entity);
        void Delete(int id);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
    }
}
