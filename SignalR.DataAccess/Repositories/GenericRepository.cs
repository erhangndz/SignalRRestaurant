using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.Repositories
{
    public class GenericRepository<T>(SignalRContext _context) : IRepository<T> where T : class
    {
        
        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public int Count()
        {
           return _context.Set<T>().Count();
        }

        public void Delete(int id)
        {
            var value = _context.Set<T>().Find(id);
            _context.Remove<T>(value);
            _context.SaveChanges();
        }

        public int FilterCount(Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().Where(predicate).Count();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();  
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
