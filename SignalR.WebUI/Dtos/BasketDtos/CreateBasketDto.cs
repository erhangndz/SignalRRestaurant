using SignalR.WebUI.Dtos.MenuTableDtos;
using SignalR.WebUI.Dtos.ProductDtos;

namespace SignalR.WebUI.Dtos.BasketDtos
{
    public class CreateBasketDto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        
        public int MenuTableId { get; set; }
        
    }
}
