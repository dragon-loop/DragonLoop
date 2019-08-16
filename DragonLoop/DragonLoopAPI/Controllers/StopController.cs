using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DragonLoopModels;

namespace DragonLoopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopController : ControllerBase
    {
        private readonly DragonLoopContext _context;

        public StopController(DragonLoopContext context)
        {
            _context = context;
        }

        // GET: api/Stop?routeid=5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stop>>> GetStop(int? routeId = null)
        {
            if (routeId == null)
            {
                return await _context.Stops.ToListAsync();
            }
            else
            {
                var route = await _context.Routes.FindAsync(routeId);

                if (route == null)
                {
                    return NotFound();
                }

                return route.Stops.ToList();
            }
        }

        // GET: api/Stop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stop>> GetStop(int id)
        {
            var stop = await _context.Stops.FindAsync(id);

            if (stop == null)
            {
                return NotFound();
            }

            return stop;
        }

        // PUT: api/Stop/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStop(int id, Stop stop)
        {
            if (id != stop.StopId)
            {
                return BadRequest();
            }

            _context.Entry(stop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopExists(id))
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

        // POST: api/Stop
        [HttpPost]
        public async Task<ActionResult<Stop>> PostStop(Stop stop)
        {
            _context.Stops.Add(stop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStop", new { id = stop.StopId }, stop);
        }

        // DELETE: api/Stop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stop>> DeleteStop(int id)
        {
            var stop = await _context.Stops.FindAsync(id);
            if (stop == null)
            {
                return NotFound();
            }

            _context.Stops.Remove(stop);
            await _context.SaveChangesAsync();

            return stop;
        }

        private bool StopExists(int id)
        {
            return _context.Stops.Any(e => e.StopId == id);
        }
    }
}
