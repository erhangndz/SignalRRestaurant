using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;

namespace SignalR.WebUI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            

            return View();
        }
    }
}
