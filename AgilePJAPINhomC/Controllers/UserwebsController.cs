using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgilePJAPINhomC.Data;
using AgilePJAPINhomC.Models;

namespace AgilePJAPINhomC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserwebsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserwebsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Userwebs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userweb>>> GetUserweb()
        {
          if (_context.Userweb == null)
          {
              return NotFound();
          }
            return await _context.Userweb.ToListAsync();
        }

        // GET: api/Userwebs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userweb>> GetUserweb(int id)
        {
          if (_context.Userweb == null)
          {
              return NotFound();
          }
            var userweb = await _context.Userweb.FindAsync(id);

            if (userweb == null)
            {
                return NotFound();
            }

            return userweb;
        }

        // PUT: api/Userwebs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserweb(int id, Userweb userweb)
        {
            if (id != userweb.userid)
            {
                return BadRequest();
            }

            _context.Entry(userweb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserwebExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Userwebs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userweb>> PostUserweb(Userweb userweb)
        {
          if (_context.Userweb == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Userweb'  is null.");
          }
            _context.Userweb.Add(userweb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserweb", new { id = userweb.userid }, userweb);
        }

        // DELETE: api/Userwebs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserweb(int id)
        {
            if (_context.Userweb == null)
            {
                return NotFound();
            }
            var userweb = await _context.Userweb.FindAsync(id);
            if (userweb == null)
            {
                return NotFound();
            }

            _context.Userweb.Remove(userweb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserwebExists(int id)
        {
            return (_context.Userweb?.Any(e => e.userid == id)).GetValueOrDefault();
        }
    }
}
