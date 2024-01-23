using SignalR.Business.Interfaces;
using SignalR.DataAccess.Interfaces;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Concrete
{
    public class MenuTableService(IRepository<MenuTable> _menuTableRepository) : IMenuTableService
    {
        public void TAdd(MenuTable entity)
        {
            _menuTableRepository.Add(entity);
        }

        public int TCount()
        {
           return _menuTableRepository.Count();
        }

        public void TDelete(int id)
        {
            _menuTableRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<MenuTable, bool>> predicate)
        {
            return _menuTableRepository.FilterCount(predicate);
        }

        public List<MenuTable> TGetAll()
        {
            return _menuTableRepository.GetAll();
        }

        public MenuTable TGetById(int id)
        {
            return _menuTableRepository.GetById(id);
        }

        public List<MenuTable> TGetFilteredList(Expression<Func<MenuTable, bool>> predicate)
        {
           return _menuTableRepository.GetFilteredList(predicate);
        }

        public void TUpdate(MenuTable entity)
        {
            _menuTableRepository.Update(entity);
        }
    }
}
