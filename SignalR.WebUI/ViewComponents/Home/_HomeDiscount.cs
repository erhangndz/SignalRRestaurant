using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.DiscountDtos;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeDiscount(HttpClient client):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7135/api/");
            var features = await client.GetFromJsonAsync<List<ResultDiscountDto>>("discounts");
            return View(features);
        }
    }
}
