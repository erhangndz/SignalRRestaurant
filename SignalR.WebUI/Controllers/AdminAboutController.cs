using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos;
using SignalR.WebUI.Dtos.AboutDtos;

namespace SignalR.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
          
            var values = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"abouts/{id}");
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
           var result =  await _client.PostAsJsonAsync("abouts", createAboutDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            return View(createAboutDto);
            
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateAboutDto>($"abouts/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            await _client.PutAsJsonAsync("abouts", updateAboutDto);
            return RedirectToAction("Index");
        }
    }
}
