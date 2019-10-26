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
    public class RouteSegmentController : ControllerBase
    {
        private readonly DragonLoopContext _context;

        public RouteSegmentController(DragonLoopContext context)
        {
            _context = context;
        }

        // GET: api/RouteSegment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteSegment>>> GetRouteSegments()
        {
            return await _context.RouteSegments.ToListAsync();
        }

        // GET: api/RouteSegment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteSegment>> GetRouteSegment(int id)
        {
            var routeSegment = await _context.RouteSegments.FindAsync(id);

            if (routeSegment == null)
            {
                return NotFound();
            }

            return routeSegment;
        }

        // PUT: api/RouteSegment/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteSegment(int id, RouteSegment routeSegment)
        {
            if (id != routeSegment.RouteSegmentId)
            {
                return BadRequest();
            }

            _context.Entry(routeSegment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteSegmentExists(id))
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

        // POST: api/RouteSegment
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RouteSegment>> PostRouteSegment(RouteSegment routeSegment)
        {
            _context.RouteSegments.Add(routeSegment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRouteSegment", new { id = routeSegment.RouteSegmentId }, routeSegment);
        }

        // DELETE: api/RouteSegment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RouteSegment>> DeleteRouteSegment(int id)
        {
            var routeSegment = await _context.RouteSegments.FindAsync(id);
            if (routeSegment == null)
            {
                return NotFound();
            }

            _context.RouteSegments.Remove(routeSegment);
            await _context.SaveChangesAsync();

            return routeSegment;
        }

        private bool RouteSegmentExists(int id)
        {
            return _context.RouteSegments.Any(e => e.RouteSegmentId == id);
        }
    }
}
