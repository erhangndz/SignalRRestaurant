using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Concrete;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.BookingDtos;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService,IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            
            var result = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto createCategoryDto)
        {
            var newCategory = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(newCategory);
            return Ok("Yeni Kategori Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Kategori Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }


        [HttpGet("Count")]
        public IActionResult Count()
        {
            var value = _categoryService.TCount();
            return Ok(value);
        }

        [HttpGet("getactives")]
        public IActionResult GetActives()
        {
            var value = _categoryService.TFilterCount(x => x.Status == true);
            return Ok(value);
        }

        [HttpGet("getpassives")]
        public IActionResult GetPassives()
        {
            var value = _categoryService.TFilterCount(x => x.Status == false);
            return Ok(value);
        }
    }
}
