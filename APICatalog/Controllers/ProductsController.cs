using APICatalog.Context;
using APICatalog.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            var products = await _context.Products
                .Take(20)
                .AsNoTracking()
                .ToListAsync();
            
            if (products is null)
                return NotFound("Products not found.");

            return products;
        }

        [HttpGet("{id:int}", Name ="GetProduct")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product is null)
                return NotFound("Product not found.");

            return product;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Product product)
        {
            if (product is null)
                return BadRequest();

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetProduct", new { id = product.ProductId }, product );
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAsync(int id, Product product)
        {
            if (id != product.ProductId)
                return BadRequest();

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product is null)
                return NotFound("Product not found.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
