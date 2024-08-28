using APICatalog.Context;
using APICatalog.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesProductsAsync()
        {
            try
            {
                return await _context.Categories
                    .Take(10)
                    .AsNoTracking()
                    .Include(c => c.Products)//.Where(c => c.CategoriaId <= 5).ToList();
                    .ToListAsync();
            } 
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There was a problem processing your request");
            }   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Take(10)
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id:int:min(1)}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            if (category is null)
                return NotFound("Category not found.");

            return category;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Category category)
        {
            if (category is null)
                return BadRequest("The category body not be null.");

            await _context.Categories.AddAsync(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategory", new { id = category.CategoryId }, category);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult> UpdateAsync(int id, Category category)
        {
            if (id != category.CategoryId)
                return BadRequest();

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (category is null)
                return NotFound("Category not found.");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
