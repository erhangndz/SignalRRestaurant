using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeDiscount:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
