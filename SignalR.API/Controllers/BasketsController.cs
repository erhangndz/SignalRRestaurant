using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.BasketDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController(IBasketService basketService,IMapper mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetBasketByTable(int id)
        {
            var values = basketService.GetBasketByTableNumber(id);
            return Ok(values);
        }

        [HttpGet]
        public IActionResult GetBasket()
        {
            var values = basketService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            var newBasket = mapper.Map<Basket>(createBasketDto);
            newBasket.Quantity = 1;
            newBasket.MenuTableId = 4;
            basketService.TAdd(newBasket);
            return Ok("Sepete Ürün Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBasketItem(int id)
        {
            basketService.TDelete(id);
            return Ok("Sepetten Ürün Silindi");
        }

    }
}
