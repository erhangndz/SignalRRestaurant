using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Interfaces
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<Basket> GetBasketByTableNumber(int tableNumber);

        void RemoveBasketItem(int id);
    }
}
