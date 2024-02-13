using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.NotificationDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController(INotificationService _notificationService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetNotificationList()
        {
            var values = _notificationService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            _notificationService.TDelete(id);
            return Ok("Bildirim Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
       
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var newNotification = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(newNotification);
            return Ok("Bildirim Oluşturuldu");
        }

      
    }
}
