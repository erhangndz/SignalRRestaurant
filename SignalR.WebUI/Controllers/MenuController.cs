using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.BasketDtos;

namespace SignalR.WebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController(HttpClient client) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
