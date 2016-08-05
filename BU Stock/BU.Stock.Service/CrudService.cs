using BU.Stock.Core.Interfaces;
using BU.Stock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BU.Stock.Service
{
    public abstract class CrudService<T> : ICrudService<T> where T : Entity
    {
        protected IRepository<T> _repo;

        public CrudService(IRepository<T> repo)
        {
            this._repo = repo;
        }

        public void Delete(T entity)
        {
            _repo.Delete(entity);
            //_repo.SaveAsync();
        }

        public IQueryable<T> GetAll()
        {
            return from p in _repo.GetAll()
                   select p;
        }

        public T GetById(int id)
        {
           return _repo.GetById(id);
        }

        public int Insert(T entity)
        {
            var newItem = _repo.Insert(entity);
            //_repo.SaveAsync();
            return newItem.Id;
        }

        //public Task<int> SaveAsync()
        //{
        //   return _repo.SaveAsync();
        //}

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return from p in _repo.Where(predicate)
                   select p;
        }
    }
}
