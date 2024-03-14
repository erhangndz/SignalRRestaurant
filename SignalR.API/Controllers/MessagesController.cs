using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.MessageDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IMessageService _messageService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessages()
        {
            var values = _messageService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return Ok("Mesaj Silindi");
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var newMessage = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(newMessage);
            return Ok("Mesaj Oluşturuldu");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var message = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(message);
            return Ok("Mesaj Güncellendi");
        }

        [HttpGet("ReadMessages")]
        public IActionResult ReadMessages()
        {
            var values = _messageService.TGetFilteredList(x=>x.isRead==true);
            return Ok(values);
        }


        [HttpGet("UnreadMessages")]
        public IActionResult UnreadMessages()
        {
            var values = _messageService.TGetFilteredList(x => x.isRead == false);
            return Ok(values);
        }
    }
}
