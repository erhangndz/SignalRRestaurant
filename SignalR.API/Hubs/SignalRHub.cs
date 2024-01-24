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

        public async Task SendCategoryCount()
        {
            var categoryCount = _categoryService.TCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
        }

        public async Task SendProductCount()
        {
            var productCount = _productService.TCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);
        }

        public async Task ActiveCategoryCount()
        {
            var activeCategories = _categoryService.TFilterCount(x=>x.Status==true);
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategories);
        }

    }
}
