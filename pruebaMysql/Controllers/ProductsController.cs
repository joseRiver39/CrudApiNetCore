using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaMysql.Data;
using pruebaMysql.Models;

namespace pruebaMysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

         private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult> AddProducts(Produc produc)
        {
            _context.Producs.Add(produc);
            await _context.SaveChangesAsync();
            return Ok(produc);

        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
             var product = await _context.Producs.ToListAsync();
            return Ok(product);
                

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produc>> GetById(int id) { 
        
            var product = await _context.Producs.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct( int id, Produc pdo)
        {
            if (id != pdo.Id)
            {
                return BadRequest();
            }
            _context.Entry(pdo).State = EntityState.Modified;   
            await _context.SaveChangesAsync();

            
            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var pdoItem = await _context.Producs.FindAsync(id);

            if (pdoItem == null)
            {
                return NoContent();
            }

            _context.Producs.Remove(pdoItem);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
