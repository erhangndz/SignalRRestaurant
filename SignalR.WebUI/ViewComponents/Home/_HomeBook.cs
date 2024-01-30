using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeBook:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
