using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerformancesController : ControllerBase
    {
        private readonly ModelContext _context;

        public PerformancesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Performances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Performance>>> GetPerformances()
        {
          if (_context.Performances == null)
          {
              return NotFound();
          }
            return await _context.Performances.ToListAsync();
        }

        // GET: api/Performances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Performance>> GetPerformance(string id)
        {
          if (_context.Performances == null)
          {
              return NotFound();
          }
            var performance = await _context.Performances.FindAsync(id);

            if (performance == null)
            {
                return NotFound();
            }

            return performance;
        }

        // PUT: api/Performances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerformance(string id, Performance performance)
        {
            if (id != performance.PerformanceId)
            {
                return BadRequest();
            }

            _context.Entry(performance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformanceExists(id))
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

        // POST: api/Performances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Performance>> PostPerformance(Performance performance)
        {
          if (_context.Performances == null)
          {
              return Problem("Entity set 'ModelContext.Performances'  is null.");
          }
            _context.Performances.Add(performance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PerformanceExists(performance.PerformanceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPerformance", new { id = performance.PerformanceId }, performance);
        }

        // DELETE: api/Performances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformance(string id)
        {
            if (_context.Performances == null)
            {
                return NotFound();
            }
            var performance = await _context.Performances.FindAsync(id);
            if (performance == null)
            {
                return NotFound();
            }

            _context.Performances.Remove(performance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerformanceExists(string id)
        {
            return (_context.Performances?.Any(e => e.PerformanceId == id)).GetValueOrDefault();
        }
    }
}
