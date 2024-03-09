using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.ClientHandler;
using SignalR.WebUI.Dtos.BookingDtos;

namespace SignalR.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookATableController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookTable(CreateBookingDto createBookingDto)
        {

            createBookingDto.ReservationStatus = "Rezervasyon Alındı";
            await _client.PostAsJsonAsync("bookings", createBookingDto);
            return NoContent();
        }
    }
}
