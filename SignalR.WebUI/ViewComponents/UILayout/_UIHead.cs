using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.UILayout
{
    public class _UIHead: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
