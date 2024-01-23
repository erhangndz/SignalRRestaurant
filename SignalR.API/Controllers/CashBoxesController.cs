using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Concrete;
using SignalR.Business.Interfaces;
using SignalR.Business.Validators;
using SignalR.DTO.Dtos.CashBoxDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashBoxesController(ICashBoxService _cashBoxService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _cashBoxService.TGetAll();
            var result = _mapper.Map<List<ResultCashBoxDto>>(values);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cashBoxService.TDelete(id);
            return Ok("Kasa Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _cashBoxService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateCashBoxDto createCashBoxDto)
        {
            var newAbout = _mapper.Map<CashBox>(createCashBoxDto);
            _cashBoxService.TAdd(newAbout);
            return Ok("Kasa başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateCashBoxDto updateCashBoxDto)
        {
            var cashbox = _mapper.Map<CashBox>(updateCashBoxDto);
            _cashBoxService.TUpdate(cashbox);
            return Ok("Kasa başarıyla güncellendi");
        }

        [HttpGet("Total")]
        public IActionResult Total()
        {
            var value = _cashBoxService.TotalCashBox();
            return Ok(value);
        }

    }
}
