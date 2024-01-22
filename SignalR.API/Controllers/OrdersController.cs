using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Concrete;
using SignalR.Business.Interfaces;
using SignalR.Business.Validators;
using SignalR.DTO.Dtos.OrderDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _orderService.TGetAll();
            var result = _mapper.Map<List<ResultOrderDto>>(values);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.TDelete(id);
            return Ok("Sipariş Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _orderService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDto createOrderDto)
        {
            var newOrder = _mapper.Map<Order>(createOrderDto);
            _orderService.TAdd(newOrder);
            return Ok("Sipariş başarıyla oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateOrderDto updateOrderDto)
        {
            var order = _mapper.Map<Order>(updateOrderDto);
            _orderService.TUpdate(order);
            return Ok("Sipariş başarıyla güncellendi");
        }
    }
}
