using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTO.Dtos.BasketDtos
{
    public class UpdateBasketDto
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int MenuTableId { get; set; }
    }
}
