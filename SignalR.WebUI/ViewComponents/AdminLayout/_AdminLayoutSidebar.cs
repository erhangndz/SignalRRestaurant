using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.AdminLayout
{
	public class _AdminLayoutSidebar:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
