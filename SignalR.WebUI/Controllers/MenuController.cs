using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.BasketDtos;

namespace SignalR.WebUI.Controllers
{
    public class MenuController(HttpClient client) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
