using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.CategoryDtos;
using SignalR.WebUI.Dtos.ProductDtos;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeMenu(HttpClient client):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7135/api/");
            var categories = await client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            var products = await client.GetFromJsonAsync<List<ResultProductDto>>("products/ProductListWithCategory");

            ViewBag.categories = categories;
            return View(products);
            
        }
    }
}
