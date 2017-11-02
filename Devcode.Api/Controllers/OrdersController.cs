using System.Collections.Generic;
using System.Threading.Tasks;
using Devcode.Api.Models;
using Devcode.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devcode.Api.Controllers
{
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private readonly OrderMockService _orderService;

        public OrdersController()
        {
            _orderService = new OrderMockService();
        }

        public async Task<List<Order>> Get()
        {
            var orders = await _orderService.GetOrdersAsync();
            return orders;
        }

        [Route("{orderId}")]
        public async Task<Order> Get(int orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);
            return order;
        }

        [HttpPost]
        public async Task Post(Order newOrder)
        {
            await _orderService.CreateOrderAsync(newOrder);
        }

        [HttpDelete]
        public async Task<bool> Delete(int orderId)
        {
            return await _orderService.CancelOrderAsync(orderId);
        }
    }
}
