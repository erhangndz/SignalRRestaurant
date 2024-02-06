using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.BookingDtos;

namespace SignalR.WebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly HttpClient _client;

        public BookATableController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7135/api/");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookTable(CreateBookingDto createBookingDto)
        {
            await _client.PostAsJsonAsync("bookings", createBookingDto);
            return NoContent();
        }
    }
}
