using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.MenuTableDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController(IMenuTableService _menuTableService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateMenuTableDto createMenuTableDto)
        {
            var newTable = _mapper.Map<MenuTable>(createMenuTableDto);
            newTable.Status = false;
            _menuTableService.TAdd(newTable);
            return Ok("Yeni Masa Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateMenuTableDto updateMenuTableDto)
        {
            var table = _mapper.Map<MenuTable>(updateMenuTableDto);
            table.Status = false;
            _menuTableService.TUpdate(table);
            return Ok("Masa Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _menuTableService.TDelete(id);
            return Ok("Masa Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var value = _menuTableService.TCount();
            return Ok(value);
        }
    }
}
