using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.CategoryDtos;

namespace SignalR.WebUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
		{
			var values = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
			return View(values);
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _client.DeleteAsync($"categories/{id}" );
			return RedirectToAction("Index");
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
		{
			await _client.PostAsJsonAsync("categories", createCategoryDto);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Update(int id)
		{
			var value = await _client.GetFromJsonAsync<UpdateCategoryDto>($"categories/{id}");
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
		{
			 await _client.PutAsJsonAsync("categories", updateCategoryDto);
		
			return RedirectToAction("Index");
		}
	}
}
