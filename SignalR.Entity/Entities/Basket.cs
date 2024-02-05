using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Entity.Entities
{
    public class Basket
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get => Quantity * Product.Price; } 

        public int MenuTableId { get; set; }
        public MenuTable MenuTable { get; set; }
    }
}
