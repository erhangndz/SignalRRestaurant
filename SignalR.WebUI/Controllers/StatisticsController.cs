using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly HttpClient _client;

        public StatisticsController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7135/api/");
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.categoryCount = await _client.GetStringAsync("categories/count");
            ViewBag.productCount = await _client.GetStringAsync("products/count");
            ViewBag.activeProducts = await _client.GetStringAsync("products/getactives");
            ViewBag.activeCategories = await _client.GetStringAsync("categories/getactives");
            ViewBag.passiveProducts = await _client.GetStringAsync("products/getpassives");
            ViewBag.passiveCategories = await _client.GetStringAsync("categories/getpassives");
            ViewBag.countByHamburger = await _client.GetStringAsync("products/countbyhamburger");
            ViewBag.countByDrink = await _client.GetStringAsync("products/countbydrink");
            ViewBag.avgProductPrice = await _client.GetStringAsync("products/avgprice");
            ViewBag.cheapestProduct = await _client.GetStringAsync("products/cheapest");
            ViewBag.mostExpensiveProduct = await _client.GetStringAsync("products/mostexpensive");
            ViewBag.orderCount = await _client.GetStringAsync("orders/count");
            ViewBag.activeOrders = await _client.GetStringAsync("orders/activeorders");
            ViewBag.lastOrderPrice = await _client.GetStringAsync("orders/lastorderprice");
            ViewBag.totalCashBox = await _client.GetStringAsync("cashboxes/total");
            ViewBag.tableCount = await _client.GetStringAsync("menutables/count");

            return View();
        }
    }
}
