using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.Default_Index
{
    public class _HomeSlider:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
