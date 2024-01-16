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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

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
    }
}
