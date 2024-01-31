using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.ContactDtos;
using SignalR.WebUI.Dtos.SocialMediaDtos;

namespace SignalR.WebUI.ViewComponents.UILayout
{
    public class _UIFooter(HttpClient client):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            client.BaseAddress=new Uri("https://localhost:7135/api/");
            var values = await client.GetFromJsonAsync<List<ResultContactDto>>("contacts");

            ViewBag.socialMedias = await client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialmedias");
            return View(values);
        }
    }
}
