using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.AdminLayout
{
	public class _AdminLayoutFooter:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
