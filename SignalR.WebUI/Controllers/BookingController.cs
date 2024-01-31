using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.BookingDtos;

namespace SignalR.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly HttpClient _client;


        public BookingController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7135/api/");

        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBookingDto>>("bookings");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"bookings/{id}");
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDto createBookingDto)
        {
            await _client.PostAsJsonAsync("bookings", createBookingDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> BookTable(CreateBookingDto createBookingDto)
        {
            await _client.PostAsJsonAsync("bookings", createBookingDto);
            return RedirectToAction("Index","Default");
        }

        public async Task<IActionResult> Update(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBookingDto>($"bookings/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBookingDto updateBookingDto)
        {
             await _client.PutAsJsonAsync("bookings", updateBookingDto);

            return RedirectToAction("Index");
        }
    }
}
