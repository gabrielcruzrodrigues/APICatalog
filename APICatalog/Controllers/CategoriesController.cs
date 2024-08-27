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
        public ActionResult<IEnumerable<Category>> GetAllCategoriesProducts()
        {
            return _context.Categories.Include(c => c.Products).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (category is null)
                return NotFound("Category not found.");

            return category;
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (category is null)
                return BadRequest("The category body not be null.");

            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategory", new { id = category.CategoryId }, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int id, Category category)
        {
            if (id != category.CategoryId)
                return BadRequest();

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (category is null)
                return NotFound("Category not found.");

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
