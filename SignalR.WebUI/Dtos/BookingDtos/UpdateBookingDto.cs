﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }
        public string? ReservationStatus { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
