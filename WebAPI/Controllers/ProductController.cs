using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _dataContext.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _dataContext.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            else
                return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Product product)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
                _dataContext.Entry(product).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _dataContext.Products.FindAsync(id);
            if(product != null)
            {
                _dataContext.Products.Remove(product);
                await _dataContext.SaveChangesAsync();

                return Ok();
            }
            else
                return NotFound();
        }
    }
}
