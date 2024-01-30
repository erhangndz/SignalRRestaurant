using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.UILayout
{
    public class _UINavbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
