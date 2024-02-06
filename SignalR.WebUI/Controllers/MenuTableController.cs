using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class MenuTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
