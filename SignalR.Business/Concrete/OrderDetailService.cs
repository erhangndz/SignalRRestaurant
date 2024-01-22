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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public OrderDetailService(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public void TAdd(OrderDetail entity)
        {
           _orderDetailRepository.Add(entity);
        }

        public int TCount()
        {
            return _orderDetailRepository.Count();
        }

        public void TDelete(int id)
        {
            _orderDetailRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<OrderDetail, bool>> predicate)
        {
            return _orderDetailRepository.FilterCount(predicate);
        }

        public List<OrderDetail> TGetAll()
        {
            return _orderDetailRepository.GetAll();
        }

        public OrderDetail TGetById(int id)
        {
           return _orderDetailRepository.GetById(id);
        }

        public List<OrderDetail> TGetFilteredList(Expression<Func<OrderDetail, bool>> predicate)
        {
            return _orderDetailRepository.GetFilteredList(predicate);
        }

        public void TUpdate(OrderDetail entity)
        {
           _orderDetailRepository.Update(entity);
        }
    }
}
