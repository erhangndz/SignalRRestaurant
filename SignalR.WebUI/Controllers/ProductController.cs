using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.CategoryDtos;
using SignalR.WebUI.Dtos.ProductDtos;

namespace SignalR.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductDto>>("products/ProductListWithCategory");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"products/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");

            ViewBag.categories = new List<SelectListItem>(from x in categories
                                                          select new SelectListItem
                                                          {
                                                              Text = x.CategoryName,
                                                              Value = x.CategoryId.ToString()
                                                          }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            await _client.PostAsJsonAsync("products", createProductDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            ViewBag.categories = new List<SelectListItem>(from x in categories
                                                          select new SelectListItem
                                                          {
                                                              Text = x.CategoryName,
                                                              Value = x.CategoryId.ToString()
                                                          }).ToList();
            var value = await _client.GetFromJsonAsync<UpdateProductDto>($"products/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
           await _client.PutAsJsonAsync("products", updateProductDto);
            
            return RedirectToAction("Index");
        }
    }
}
