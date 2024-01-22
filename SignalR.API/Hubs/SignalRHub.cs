using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.Business.Interfaces;
using SignalR.DataAccess.Concrete;

namespace SignalR.API.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;

        public SignalRHub(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task SendCategoryCount()
        {
            var value = _categoryService.TCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }

    }
}
