using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Concrete;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.DTO.Dtos.ProductDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _productService, IMapper _mapper) : ControllerBase
    {
       
        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(result);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()

        {
            var values = _productService.GetProductsWithCategories();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult Create(CreateProductDto createProductDto)
        {
            var newProduct = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(newProduct);
            return Ok("Yeni Ürün Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(product);
            return Ok("Ürün Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.TDelete(id);
            return Ok("Ürün Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var value = _productService.TCount();
            return Ok(value);
        }


        [HttpGet("getactives")]
        public IActionResult GetActives()
        {
            var value = _productService.TFilterCount(x => x.Status == true);
            return Ok(value);
        }

        [HttpGet("getpassives")]
        public IActionResult GetPassives()
        {
            var value = _productService.TFilterCount(x => x.Status == false);
            return Ok(value);
        }

        [HttpGet("CountByHamburger")]
        public IActionResult CountByHamburger()
        {
            var value = _productService.TFilterCount(x => x.Category.CategoryName.ToLower() == "hamburger");
            return Ok(value);
        }

        [HttpGet("CountByDrink")]
        public IActionResult CountBydrink()
        {
            var value = _productService.TFilterCount(x => x.Category.CategoryName.ToLower() == "içecek");
            return Ok(value);
        }

        [HttpGet("AvgPrice")]
        public IActionResult AvgPrice()
        {
            var value = _productService.AvgProductPrice();
            return Ok(value);
        }

        [HttpGet("Cheapest")]
        public IActionResult Cheapest()
        {
            var value = _productService.CheapestProduct();
            return Ok(value);
        }


        [HttpGet("MostExpensive")]
        public IActionResult MostExpensive()
        {
            var value = _productService.MostExpensiveProduct();
            return Ok(value);
        }

        [HttpGet("AvgHamburgerPrice")]
        public IActionResult AvgHamburgerPrice()
        {
            var value = _productService.AvgHamburgerPrice();
            return Ok(value);
        }


    }
}
