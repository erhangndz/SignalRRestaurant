using SignalR.Business.Interfaces;
using SignalR.DataAccess.Concrete;
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
    public class CashBoxService(IRepository<CashBox> _cashBoxRepository, SignalRContext _context) : ICashBoxService
    {

        public void TAdd(CashBox entity)
        {
            _cashBoxRepository.Add(entity);
        }

        public int TCount()
        {
            return _cashBoxRepository.Count();
        }

        public void TDelete(int id)
        {
            _cashBoxRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<CashBox, bool>> predicate)
        {
            return _cashBoxRepository.FilterCount(predicate);
        }

        public List<CashBox> TGetAll()
        {
            return _cashBoxRepository.GetAll();
        }

        public CashBox TGetById(int id)
        {
            return _cashBoxRepository.GetById(id);
        }

        public List<CashBox> TGetFilteredList(Expression<Func<CashBox, bool>> predicate)
        {
            return _cashBoxRepository.GetFilteredList(predicate);
        }

        public decimal TotalCashBox()
        {
            return _context.CashBoxes.Sum(x => x.TotalAmount);
        }

        public void TUpdate(CashBox entity)
        {
            _cashBoxRepository.Update(entity);
        }
    }
}
