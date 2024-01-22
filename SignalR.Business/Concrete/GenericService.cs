using SignalR.Business.Interfaces;
using SignalR.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public int TFilterCount(Expression<Func<T, bool>> predicate)
        {
           return _repository.FilterCount(predicate);
        }

        public void TAdd(T entity)
        {
            _repository.Add(entity);
        }

        public int TCount()
        {
          return _repository.Count();
        }

        public void TDelete(int id)
        {
            _repository.Delete(id);
        }

        public List<T> TGetAll()
        {
            return _repository.GetAll();    
        }

        public T TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<T> TGetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetFilteredList(predicate);
        }

        public void TUpdate(T entity)
        {
           _repository.Update(entity);
        }
    }
}
