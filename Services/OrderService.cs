using OrderTrackingApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderTrackingApi.Services
{
    public class OrderService
    {
        private static readonly List<Order> _orders = new();
        private static int _nextOrderId = 1;

        public Order CreateOrder(Order order)
        {
            order.OrderId = _nextOrderId++;
            order.Timestamp = DateTime.UtcNow;
            order.Total = order.Items.Sum(item => item.Total);
            order.Status = "Pending";

            _orders.Add(order);
            return order;
        }

        public List<Order> GetOrdersByUsername(string username)
        {
            return _orders.Where(o => o.Username == username).ToList();
        }

        public Order? GetOrderById(int id, string username)
        {
            return _orders.FirstOrDefault(o => o.OrderId == id && o.Username == username);
        }
    }
}
