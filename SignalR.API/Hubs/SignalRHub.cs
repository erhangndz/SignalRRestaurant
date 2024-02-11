﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.Business.Interfaces;
using SignalR.DataAccess.Concrete;

namespace SignalR.API.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ICashBoxService _cashBoxService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, ICashBoxService cashBoxService, IMenuTableService menuTableService, IBookingService bookingService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _cashBoxService = cashBoxService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
        }

        public async Task SendStatistics()
        {
            var categoryCount = _categoryService.TCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
            var productCount = _productService.TCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);
            var activeCategories = _categoryService.TFilterCount(x => x.Status == true);
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategories);
            var passiveCategories = _categoryService.TFilterCount(x => x.Status == false);
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategories);
            var hamburgerCount = _productService.TFilterCount(x => x.Category.CategoryName.ToLower() == "hamburger");
            await Clients.All.SendAsync("ReceiveHamburgerCount", hamburgerCount);
            var drinkCount = _productService.TFilterCount(x => x.Category.CategoryName.ToLower() == "içecek");
            await Clients.All.SendAsync("ReceiveDrinkCount", drinkCount);
            var avgPrice = _productService.AvgProductPrice();
            await Clients.All.SendAsync("ReceiveAvgPrice", avgPrice.ToString("00.00")+" ₺");
            var expensiveProduct = _productService.MostExpensiveProduct();
            await Clients.All.SendAsync("ReceiveExpensiveProduct", expensiveProduct);
            var cheapestProduct = _productService.CheapestProduct();
            await Clients.All.SendAsync("ReceiveCheapestProduct", cheapestProduct);
            var avgHamburgerPrice = _productService.AvgHamburgerPrice();
            await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice.ToString("00.00")+" ₺");
            var totalOrderCount = _orderService.TCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);
            var activeOrders= _orderService.TFilterCount(x => x.Description == "Müşteri Masada");
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrders);
            var lastOrderPrice = _orderService.LastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("00.00") + " ₺");
            var totalCash = _cashBoxService.TotalCashBox();
            await Clients.All.SendAsync("ReceiveTotalCash", totalCash.ToString("00.00") + " ₺");
            var todaysTotalPrice = _orderService.TodaysTotalPrice();
            await Clients.All.SendAsync("ReceiveTodaysTotalPrice", todaysTotalPrice.ToString("00.00") + " ₺");
            var totalTableCount = _menuTableService.TCount();
            await Clients.All.SendAsync("ReceiveTotalTableCount", totalTableCount);

        }


        public async Task SendProgress()
        {
            var totalCash = _cashBoxService.TotalCashBox();
            await Clients.All.SendAsync("ReceiveTotalCash", totalCash.ToString("00.00")+" ₺");
            var activeOrders = _orderService.TFilterCount(x => x.Description == "Müşteri Masada");
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrders);
            var totalTableCount = _menuTableService.TCount();
            await Clients.All.SendAsync("ReceiveTotalTableCount", totalTableCount);
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        

    }
}
