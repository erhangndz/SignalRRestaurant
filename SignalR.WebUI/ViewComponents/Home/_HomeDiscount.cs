using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.DiscountDtos;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeDiscount:ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var discounts = await _client.GetFromJsonAsync<List<ResultDiscountDto>>("discounts");
            return View(discounts);
        }
    }
}
