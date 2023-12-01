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
    public class CategoryClipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryClipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoryClips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryClip>>> Getcategoryclip()
        {
          if (_context.categoryclip == null)
          {
              return NotFound();
          }
            return await _context.categoryclip.ToListAsync();
        }

        // GET: api/CategoryClips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryClip>> GetCategoryClip(int id)
        {
          if (_context.categoryclip == null)
          {
              return NotFound();
          }
            var categoryClip = await _context.categoryclip.FindAsync(id);

            if (categoryClip == null)
            {
                return NotFound();
            }

            return categoryClip;
        }

        // PUT: api/CategoryClips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryClip(int id, CategoryClip categoryClip)
        {
            if (id != categoryClip.CaclipId)
            {
                return BadRequest();
            }

            _context.Entry(categoryClip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryClipExists(id))
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

        // POST: api/CategoryClips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryClip>> PostCategoryClip(CategoryClip categoryClip)
        {
          if (_context.categoryclip == null)
          {
              return Problem("Entity set 'ApplicationDbContext.categoryclip'  is null.");
          }
            _context.categoryclip.Add(categoryClip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryClip", new { id = categoryClip.CaclipId }, categoryClip);
        }

        // DELETE: api/CategoryClips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryClip(int id)
        {
            if (_context.categoryclip == null)
            {
                return NotFound();
            }
            var categoryClip = await _context.categoryclip.FindAsync(id);
            if (categoryClip == null)
            {
                return NotFound();
            }

            _context.categoryclip.Remove(categoryClip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryClipExists(int id)
        {
            return (_context.categoryclip?.Any(e => e.CaclipId == id)).GetValueOrDefault();
        }
    }
}
