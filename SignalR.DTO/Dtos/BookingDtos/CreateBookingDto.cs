using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SignalR.DTO.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
      
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
