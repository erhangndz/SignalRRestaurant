using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Concrete;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.DTO.Dtos.ContactDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IContactService _contactService, IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto createContactDto)
        {
            var newContact = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(newContact);
            return Ok("Yeni İletişim Bilgisi Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(contact);
            return Ok("İletişim Bilgisi Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.TDelete(id);
            return Ok("İletişim Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
    }
}
