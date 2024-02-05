using SignalR.WebUI.Dtos.BasketDtos;

namespace SignalR.WebUI.Dtos.MenuTableDtos
{
    public class UpdateMenuTableDto
    {
        public int MenuTableId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public List<ResultBasketDto> Baskets { get; set; }
    }
}
