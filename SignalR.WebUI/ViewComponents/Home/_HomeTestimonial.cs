using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.TestimonialDtos;

namespace SignalR.WebUI.ViewComponents.Home
{
    public class _HomeTestimonial(HttpClient client):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7135/api/");
            var testimonials = await client.GetFromJsonAsync<List<ResultTestimonialDto>>("testimonials");
            return View(testimonials);
        }
    }
}
