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

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var notification = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(notification);
            return Ok("Bildirim Güncellendi");
        }

        [HttpGet("UnreadNotificationCount")]
        public IActionResult UnreadNotificationCount()
        {
            var value = _notificationService.UnreadNotificationCount();
            return Ok(value);
        }

        [HttpGet("ReadNotificationCount")]
        public IActionResult ReadNotificationCount()
        {
            var value = _notificationService.ReadNotificationCount();
            return Ok(value);
        }


        [HttpGet("GetUnreadNotifications")]

        public IActionResult GetUnreadNotifications()
        {
            var values = _notificationService.TGetFilteredList(x => x.Status == false);
            return Ok(values);
        }

        [HttpGet("MarkAsRead/{id}")]
        public IActionResult MarkAsRead(int id)
        {
            _notificationService.MarkAsRead(id);
            return Ok("Okundu Olarak İşaretlendi");
        }

        [HttpGet("MarkAsUnread/{id}")]
        public IActionResult MarkAsUnread(int id)
        {
            _notificationService.MarkAsUnread(id);
            return Ok("Okunmadı Olarak İşaretlendi");
        }







    }
}
