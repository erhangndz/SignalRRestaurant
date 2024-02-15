using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.NotificationDtos;

namespace SignalR.WebUI.Controllers
{
	public class NotificationController : Controller
	{
		private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
		public async Task<IActionResult> Index()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultNotificationDto>>("notifications");
			return View(values);
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _httpClient.DeleteAsync($"notifications/{id}");
			return RedirectToAction("Index");
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]	
		public async Task<IActionResult> Create(CreateNotificationDto createNotificationDto)
		{
			await _httpClient.PostAsJsonAsync("notifications", createNotificationDto);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Update(int id)
		{
			var value = await _httpClient.GetFromJsonAsync<UpdateNotificationDto>($"notifications/{id}");
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateNotificationDto updateNotificationDto)
		{
			await _httpClient.PutAsJsonAsync("notifications", updateNotificationDto);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> MarkAsRead(int id)
		{
			await _httpClient.GetAsync($"notifications/markasread/{id}");
			return RedirectToAction("Index");
		}

        public async Task<IActionResult> MarkAsUnread(int id)
        {
            await _httpClient.GetAsync($"notifications/markasunread/{id}");
            return RedirectToAction("Index");
        }
    }
}
