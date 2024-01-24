using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.Business.Interfaces;
using SignalR.DataAccess.Concrete;

namespace SignalR.API.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SignalRHub(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
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
        }

        

    }
}
