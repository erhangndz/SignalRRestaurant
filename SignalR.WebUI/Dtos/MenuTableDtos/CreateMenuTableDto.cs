using SignalR.WebUI.Dtos.BasketDtos;

namespace SignalR.WebUI.Dtos.MenuTableDtos
{
    public class CreateMenuTableDto
    {
        
        public string Name { get; set; }
        public bool Status { get; set; }

        public List<ResultBasketDto> Baskets { get; set; }
    }
}
