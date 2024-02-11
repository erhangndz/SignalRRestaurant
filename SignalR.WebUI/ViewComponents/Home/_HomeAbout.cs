using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.AboutDtos;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeAbout:ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(abouts);
        }
    }
}
