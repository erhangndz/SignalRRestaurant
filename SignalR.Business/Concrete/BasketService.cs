using Microsoft.EntityFrameworkCore;
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
    public class BasketService(IRepository<Basket> basketRepository, SignalRContext context) : IBasketService
    {
        public List<Basket> GetBasketByTableNumber(int tableNumber)
        {
            return context.Baskets.Where(x => x.MenuTableId == tableNumber).Include(y => y.Product).ToList();
        }

        public void RemoveBasketItem(int id)
        {
            var basketItem = context.Baskets.Where(x => x.ProductId == id && x.MenuTableId == 4).FirstOrDefault();
            context.Baskets.Remove(basketItem);
            context.SaveChanges();
        }

        public void TAdd(Basket entity)
        {
           basketRepository.Add(entity);
        }

        public int TCount()
        {
            return basketRepository.Count();
        }

        public void TDelete(int id)
        {
            basketRepository.Delete(id);
        }

        public int TFilterCount(Expression<Func<Basket, bool>> predicate)
        {
            return basketRepository.FilterCount(predicate);
        }

        public List<Basket> TGetAll()
        {
            return basketRepository.GetAll();
        }

        public Basket TGetById(int id)
        {
           return basketRepository.GetById(id);
        }

        public List<Basket> TGetFilteredList(Expression<Func<Basket, bool>> predicate)
        {
           return basketRepository.GetFilteredList(predicate);
        }

        public void TUpdate(Basket entity)
        {
           basketRepository.Update(entity);
        }
    }
}
