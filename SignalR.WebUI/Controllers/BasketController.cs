using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.BasketDtos;

namespace SignalR.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly HttpClient client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
          
            var values = await client.GetFromJsonAsync<List<ResultBasketDto>>("baskets/4" );
            return View(values);
        }

        public async Task<IActionResult> RemoveBasketItem(int id)
        {
            
            await client.DeleteAsync($"baskets/{id}");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(int id)
        {
            
            var createBasketDto = new CreateBasketDto();
            createBasketDto.ProductId = id;
            createBasketDto.MenuTableId = 4;
            createBasketDto.Quantity = 1;
            var result = await client.PostAsJsonAsync("baskets", createBasketDto);
            if (result.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return Json(createBasketDto);

        }
    }
}
