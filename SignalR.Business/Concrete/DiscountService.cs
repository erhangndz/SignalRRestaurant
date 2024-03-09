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
    public class DiscountService(IRepository<Discount> _discountRepository) : IDiscountService
    {
       

        public void ChangeStatusToFalse(int id)
        {
            var values = _discountRepository.GetById(id);
            values.Status = false;
            _discountRepository.Update(values);
        }

        public void ChangeStatusToTrue(int id)
        {
            var values = _discountRepository.GetById(id);
            values.Status = true;
            _discountRepository.Update(values);
        }

        public void TAdd(Discount entity)
        {
            _discountRepository.Add(entity);
        }

        public int TCount()
        {
           return _discountRepository.Count();  
        }

        public void TDelete(int id)
        {
            _discountRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Discount, bool>> predicate)
        {
            return _discountRepository.FilterCount(predicate);
        }

        public List<Discount> TGetAll()
        {
           return _discountRepository.GetAll();
        }

        public Discount TGetById(int id)
        {
            return _discountRepository.GetById(id);
        }

        public List<Discount> TGetFilteredList(Expression<Func<Discount, bool>> predicate)
        {
            return _discountRepository.GetFilteredList(predicate);
        }

        public void TUpdate(Discount entity)
        {
            _discountRepository.Update(entity);
        }
    }
}
