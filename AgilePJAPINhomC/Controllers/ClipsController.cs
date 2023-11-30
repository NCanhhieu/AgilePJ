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
    public class ClipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clip>>> GetClip()
        {
          if (_context.Clip == null)
          {
              return NotFound();
          }
            return await _context.Clip.ToListAsync();
        }

        // GET: api/Clips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clip>> GetClip(int id)
        {
          if (_context.Clip == null)
          {
              return NotFound();
          }
            var clip = await _context.Clip.FindAsync(id);

            if (clip == null)
            {
                return NotFound();
            }

            return clip;
        }

        // PUT: api/Clips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClip(int id, Clip clip)
        {
            if (id != clip.ClipId)
            {
                return BadRequest();
            }

            _context.Entry(clip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClipExists(id))
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

        // POST: api/Clips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clip>> PostClip(Clip clip)
        {
          if (_context.Clip == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Clip'  is null.");
          }
            _context.Clip.Add(clip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClip", new { id = clip.ClipId }, clip);
        }

        // DELETE: api/Clips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClip(int id)
        {
            if (_context.Clip == null)
            {
                return NotFound();
            }
            var clip = await _context.Clip.FindAsync(id);
            if (clip == null)
            {
                return NotFound();
            }

            _context.Clip.Remove(clip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClipExists(int id)
        {
            return (_context.Clip?.Any(e => e.ClipId == id)).GetValueOrDefault();
        }
    }
}
