using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sunglass_ecom.Data;
using Sunglass_ecom.Models;

namespace Sunglass_ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly EcommerceDbContext _context;

        public OrderItemsController(EcommerceDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderItem(PlaceOrderRequest orderDto)
        {


            // Validate stock availability for each order item
            foreach (var item in orderDto.Items)
            {
                var product = await _context.Product
                    .FirstOrDefaultAsync(p => p.Id == item.ProductId);

                if (product == null)
                {
                    return NotFound($"Product with ID {item.ProductId} not found.");
                }

                if (product.Stock < item.Quantity)
                {
                    return BadRequest($"Not enough stock for product {product.ProductName}. Only {product.Stock} available.");
                }
            }
 


            return Ok("Item added successfully");
        }



    }
}
   
