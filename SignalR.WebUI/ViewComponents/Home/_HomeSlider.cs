using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.FeatureDtos;

namespace SignalR.WebUI.ViewComponents.Default_Index
{
    public class _HomeSlider(HttpClient client):ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            client.BaseAddress= new Uri("https://localhost:7135/api/");
            var features = await client.GetFromJsonAsync<List<ResultFeatureDto>>("features");
            return View(features);
        }
    }
}
