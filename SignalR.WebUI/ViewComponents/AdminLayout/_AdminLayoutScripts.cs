﻿using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.AdminLayout
{
	public class _AdminLayoutScripts:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
