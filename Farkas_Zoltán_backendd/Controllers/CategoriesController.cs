using Farkas_Zoltán_backendd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farkas_Zoltán_backendd.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly LibrarydbContext _context;

        public CategoriesController(LibrarydbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat11")]
        public async Task<ActionResult> Get() 
        {
            var categories = await _context.Categories.Include(ctg=> ctg.Books).ToListAsync();

            if(categories!= null)
            {
                return Ok(categories);
            }

            Exception e = new();
            return BadRequest(e.Message);
        }

    }
}
