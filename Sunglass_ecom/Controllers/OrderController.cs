/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sunglass_ecom.Data;
using Sunglass_ecom.Models;

namespace Sunglass_ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly EcommerceDbContext _context;

        public OrderController(EcommerceDbContext context)
        {
            _context = context;
        }
        [HttpPost("{PlaceOrder}")]
        
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderRequest orderRequest)
        {
            // Validate order and save to database
            var order = new Orders
            {
                UserId = orderRequest.UserId,
                TotalAmount = orderRequest.TotalAmount,
                OrderDate = DateTime.Now,
                Status = "Pending",
                ProductName = orderRequest.ProductName
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return Ok("Order placed successfully");
        }
    }
}
*/