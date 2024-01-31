using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.AboutDtos;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeAbout(HttpClient client):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7135/api/");
            var abouts = await client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(abouts);
        }
    }
}
