using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Concrete;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.DTO.Dtos.TestimonialDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateTestimonialDto createTestimonialDto)
        {
            var newTestimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(newTestimonial);
            return Ok("Yeni Referans Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(testimonial);
            return Ok("Referans Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Referans Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
    }
}
