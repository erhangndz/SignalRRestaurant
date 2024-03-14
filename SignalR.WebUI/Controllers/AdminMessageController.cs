using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.MessageDtos;

namespace SignalR.WebUI.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            var values = _client.GetFromJsonAsync<List<ResultMessageDto>>("messages");
            
            return View(values);
        }
    }
}
