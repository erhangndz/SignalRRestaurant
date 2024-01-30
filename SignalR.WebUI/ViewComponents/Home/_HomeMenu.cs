using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeMenu:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
