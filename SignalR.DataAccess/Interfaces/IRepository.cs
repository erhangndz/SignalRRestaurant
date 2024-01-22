using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetFilteredList(Expression<Func<T, bool>> predicate);
        int Count();
        int FilterCount(Expression<Func<T, bool>> predicate);

    }
}
