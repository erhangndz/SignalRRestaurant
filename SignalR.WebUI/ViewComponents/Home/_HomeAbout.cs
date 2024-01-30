using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeAbout:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
