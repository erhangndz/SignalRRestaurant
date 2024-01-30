using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.UILayout
{
    public class _UIFooter:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
