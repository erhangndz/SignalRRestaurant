using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.MessageDtos;

namespace SignalR.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            await _client.PostAsJsonAsync("messages", createMessageDto);
            return NoContent();
        }
    }
}
