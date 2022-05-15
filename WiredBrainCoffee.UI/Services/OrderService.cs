using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.UI.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient http;

        public OrderService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = await http.GetFromJsonAsync<List<Order>>("orders");
            return orders;
        }

        public async Task<Order> PlaceOrder(Order order)
        {
                var company = JsonSerializer.Serialize(order);
                //Console.Write(company);
                //Console.Write("Base Address: " + http.BaseAddress);
                var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                var response = await http.PostAsJsonAsync("orders", requestContent);
                //Console.WriteLine("Working");
                return order;
        }
    }
}
