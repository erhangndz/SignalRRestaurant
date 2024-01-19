﻿using SignalR.WebUI.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
       
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; } = true;
        public int CategoryId { get; set; }
        
    }
}
