using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.TestimonialDtos;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeTestimonial:ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var testimonials = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("testimonials");
            return View(testimonials);
        }
    }
}
