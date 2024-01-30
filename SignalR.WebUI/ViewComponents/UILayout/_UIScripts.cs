using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.UILayout
{
    public class _UIScripts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
