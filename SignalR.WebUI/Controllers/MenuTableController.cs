using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.MenuTableDtos;

namespace SignalR.WebUI.Controllers
{
    public class MenuTableController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMenuTableDto>>("menutables");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"menutables/{id}");
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuTableDto createMenuTableDto)
        {
            await _client.PostAsJsonAsync("menutables", createMenuTableDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateMenuTableDto>($"menutables/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMenuTableDto updateMenuTableDto)
        {
            await _client.PutAsJsonAsync("menutables", updateMenuTableDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TableListByStatus()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMenuTableDto>>("menutables");
            return View(values);
        }


    }
}
