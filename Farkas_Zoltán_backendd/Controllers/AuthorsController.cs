using Farkas_Zoltán_backendd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farkas_Zoltán_backendd.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibrarydbContext _context;

        public AuthorsController(LibrarydbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat9")]
        public async Task<ActionResult> Get(string name)
        {
            var authors = await _context.Authors.Include(aut => aut.Books).FirstOrDefaultAsync(aut => aut.AuthorName == name);

            if(authors != null)
            {
                return Ok(authors);
            }

            return NotFound();
           
        }

        [HttpGet("feladat12")]
        public async Task<ActionResult> NumOfAuthors()
        {
            var num = await _context.Authors.CountAsync();

            if(num >= 0)
            {
                return Ok($"A szerzők száma: {num}");
            }

            return BadRequest();
        }
    }
}
