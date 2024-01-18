﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.DiscountDtos
{
    public class CreateDiscountDto
    {
        
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
