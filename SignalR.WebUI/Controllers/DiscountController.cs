using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.DiscountDtos;

namespace SignalR.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultDiscountDto>>("discounts");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"discounts/{id}");
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountDto createDiscountDto)
        {
            await _client.PostAsJsonAsync("discounts", createDiscountDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateDiscountDto>($"discounts/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDiscountDto updateDiscountDto)
        {
           await _client.PutAsJsonAsync("discounts", updateDiscountDto);

            return RedirectToAction("Index");
        }
    }
}
