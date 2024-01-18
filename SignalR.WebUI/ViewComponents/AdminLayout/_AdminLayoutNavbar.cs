using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.AdminLayout
{
	public class _AdminLayoutNavbar:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
