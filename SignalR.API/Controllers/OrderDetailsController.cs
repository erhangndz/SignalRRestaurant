using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.OrderDetailDtos;
using SignalR.DTO.Dtos.OrderDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController(IOrderDetailService _orderDetailService, IMapper _mapper) : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _orderDetailService.TGetAll();
            var result = _mapper.Map<List<ResultOrderDetailDto>>(values);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderDetailService.TDelete(id);
            return Ok("Sipariş Detayı Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _orderDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDetailDto createOrderDetailDto)
        {
            var newOrderDetail = _mapper.Map<OrderDetail>(createOrderDetailDto);
            _orderDetailService.TAdd(newOrderDetail);
            return Ok("Sipariş Detayı başarıyla oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateOrderDetailDto updateOrderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(updateOrderDetailDto);
            _orderDetailService.TUpdate(orderDetail);
            return Ok("Sipariş detayı başarıyla güncellendi");
        }
    }
}
