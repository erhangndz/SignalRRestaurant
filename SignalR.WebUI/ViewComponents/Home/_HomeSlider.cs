using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.FeatureDtos;

namespace SignalR.WebUI.ViewComponents.Default_Index
{
    public class _HomeSlider:ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var features = await _client.GetFromJsonAsync<List<ResultFeatureDto>>("features");
            return View(features);
        }
    }
}
