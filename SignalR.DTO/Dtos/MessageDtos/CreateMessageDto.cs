using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTO.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
      
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; } = DateTime.Now;

        public bool isRead { get; set; } = false;
    }
}
