using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sunglass_ecom.Models;
using Sunglass_ecom.Data;
using System.Text.Json;

namespace Sunglass_ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;
        public ProductController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var data = await _dbContext.Product.ToListAsync();
            
            return Ok(data);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Product>>> GetProductById(int Id)
        {
            var product = await _dbContext.Product.FindAsync(Id);
            if (product == null)
            {
                return NotFound("Id Not Found");
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody]Product prod)
        {
            if (prod == null)
            {
                return BadRequest("Product data is missing or invalid.");
            }

            Console.WriteLine($"Received Product: {JsonSerializer.Serialize(prod)}");

            await _dbContext.Product.AddAsync(prod);
            await _dbContext.SaveChangesAsync();
            return Ok(prod);
            
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int Id,Product Name)
        {
            if (Id != Name.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(Name).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok(Name);
            
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int Id)
        {
            var prod = await _dbContext.Product.FindAsync(Id);
            if (prod == null)
            {
                return NotFound();
            }
           
             _dbContext.Product.Remove(prod);
            await _dbContext.SaveChangesAsync();

            return Ok();

            
        }
    }
}
