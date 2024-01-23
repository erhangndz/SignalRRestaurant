using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.BookingDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IBookingService _bookingsService,IMapper _mapper) : ControllerBase
    {
      

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _bookingsService.TGetAll();
            var result = _mapper.Map<List<ResultBookingDto>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateBookingDto createBookingDto)
        {
            var newBooking = _mapper.Map<Booking>(createBookingDto);
            _bookingsService.TAdd(newBooking);
            return Ok("Yeni Rezervaston Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateBookingDto updateBookingDto)
        {
            var booking = _mapper.Map<Booking>(updateBookingDto);
            _bookingsService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookingsService.TDelete(id);
            return Ok("Rezervasyon Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _bookingsService.TGetById(id);
            return Ok(value);
        }
    }
}
