using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.CategoryDtos;
using SignalR.WebUI.Dtos.ProductDtos;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeMenu:ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            var products = await _client.GetFromJsonAsync<List<ResultProductDto>>("products/ProductListWithCategory");

            ViewBag.categories = categories;
            return View(products);
            
        }
    }
}
