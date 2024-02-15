using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.NotificationDtos;

namespace SignalR.WebUI.ViewComponents.AdminLayout
{
	public class _AdminLayoutNavbar:ViewComponent
	{

		private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();


		public async Task<IViewComponentResult> InvokeAsync()
		{
			ViewBag.unread = await _httpClient.GetStringAsync("notifications/UnreadNotificationCount");
			//var values =await _httpClient.GetFromJsonAsync<List<ResultNotificationDto>>("notifications/getunreadnotifications");
			return View();

			
		}
	}
}
