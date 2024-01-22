﻿using SignalR.DTO.Dtos.OrderDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTO.Dtos.OrderDtos
{
    public class ResultOrderDto
    {
        public int OrderId { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public List<ResultOrderDetailDto> OrderDetails { get; set; }
    }
}
