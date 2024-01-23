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
    public class OrderService(IRepository<Order> _orderRepository, SignalRContext _context) : IOrderService
    {
        
        public decimal LastOrderPrice()
        {
           return _context.Orders.OrderByDescending(x=>x.OrderDate).Select(x=>x.TotalPrice).FirstOrDefault();
        }

        public void TAdd(Order entity)
        {
            _orderRepository.Add(entity);
        }

        public int TCount()
        {
            return _orderRepository.Count();
        }

        public void TDelete(int id)
        {
            _orderRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Order, bool>> predicate)
        {
            return _orderRepository.FilterCount(predicate);
        }

        public List<Order> TGetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order TGetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public List<Order> TGetFilteredList(Expression<Func<Order, bool>> predicate)
        {
            return _orderRepository.GetFilteredList(predicate);
        }

        public decimal TodaysTotalPrice()
        {
           return _context.Orders.Where(x => x.OrderDate.Date == DateTime.Today).Sum(x => x.TotalPrice);
        }

        public void TUpdate(Order entity)
        {
            _orderRepository.Update(entity);
        }
    }
}
