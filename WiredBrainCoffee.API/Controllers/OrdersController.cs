using Microsoft.AspNetCore.Mvc;
using WiredBrainCoffee.Models;
namespace WiredBrainCoffee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        // private readonly ILogger<OrdersController> _logger;

        // public OrdersController(ILogger<OrdersController> logger)
        // {
        //     _logger = logger;
        // }

        private OrderDbContext _context;

        public OrdersController(OrderDbContext context)
        {
            _context = context;
        }

        [HttpGet("history")]
        public IActionResult Get()
        {
            // Replicate this in minimal API?

            return Ok();
        }
        [HttpGet]
        public IEnumerable<Order> GetOrdersList()
        {
            return _context.Orders.ToList();
        }

        [HttpGet("{id}")]
        public Order GetOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if(order != null)
            {
                return order;
            }
            else
            {
                return new Order();
            }
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("TestingId")]
        public string GetTestingId(string TestingId)
        {
            return "Testing:" + TestingId;
        }

        [HttpPost]
        public Order AddOrder(Order order)
        {
                List<OrderItem> items = new List<OrderItem>();
                OrderItem it1 = new OrderItem()
                {
                    Id = 2,
                    Name = "Special",
                    Price = 100
                };
                items.Add(it1);
                Order order2 = new Order()
                {
                    Id = 120,
                    Description = "Test",
                    Total = 100,
                    Items = items,
                    Created = DateTime.Now,
                    PromoCode = "Phil Special"
                };
                _context.Orders.Add(order2);
                _context.SaveChanges();
            // Console.WriteLine("Adding Order");
            // try
            // {
            // _context.Orders.Add(order);
            // _context.SaveChanges();
            // }
            // catch(Exception ex)
            // {
            //     Console.Write(ex.InnerException);
            // }
            return order2;
        }
        [HttpPut]
        public void UpdateOrder(int id, Order newOrder)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if(order != null)
            {
            order.Description = newOrder.Description;
            order.PromoCode = newOrder.PromoCode;
            order.Total = newOrder.Total;
            order.OrderNumber = newOrder.OrderNumber;
            _context.SaveChanges();
            }       
        }
        [HttpDelete]
        public void DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if(order != null)
            {
            _context.Orders.Remove(order);

            _context.SaveChanges();
            }
        }
    }

    public interface IOrderService
    {
        Order AddOrder(Order order);
        void DeleteOrder(int id);
        Order GetOrderById(int id);
        List<Order> GetOrders();
        void UpdateOrder(int id, Order newOrder);
    }
}