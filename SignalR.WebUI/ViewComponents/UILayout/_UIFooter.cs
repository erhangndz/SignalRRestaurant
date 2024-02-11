using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.ContactDtos;
using SignalR.WebUI.Dtos.SocialMediaDtos;

namespace SignalR.WebUI.ViewComponents.UILayout
{
    public class _UIFooter:ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");

            ViewBag.socialMedias = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialmedias");
            return View(values);
        }
    }
}
