using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);
        void TDelete(int id);
        void TUpdate(T entity);
        T TGetById(int id);
        List<T> TGetAll();
        List<T> TGetFilteredList(Expression<Func<T, bool>> predicate);
        int TCount();

        int TFilterCount(Expression<Func<T, bool>> predicate);
    }
}
