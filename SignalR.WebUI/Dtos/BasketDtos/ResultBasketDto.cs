using SignalR.WebUI.Dtos.MenuTableDtos;
using SignalR.WebUI.Dtos.ProductDtos;

namespace SignalR.WebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public ResultProductDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get => Quantity * Product.Price; }

        public int MenuTableId { get; set; }
        public ResultMenuTableDto MenuTable { get; set; }
    }
}
