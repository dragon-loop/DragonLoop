using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrexelBusAPI.Models;

namespace DrexelBusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly DrexelBusContext _context;

        public RouteController(DrexelBusContext context)
        {
            _context = context;
        }

        // GET: api/Route
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Route>>> GetRoute()
        {
            return await _context.Routes.ToListAsync();
        }

        // GET: api/Route/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> GetRoute(int id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        // GET: api/Route/5/Stops
        [HttpGet("{id}/Stops")]
        public async Task<ActionResult<IEnumerable<Stop>>> GetRouteStops(int id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route.Stops.ToList();
        }

        // PUT: api/Route/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute(int id, Route route)
        {
            if (id != route.RouteId)
            {
                return BadRequest();
            }

            _context.Entry(route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
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

        // POST: api/Route
        [HttpPost]
        public async Task<ActionResult<Route>> PostRoute(Route route)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoute", new { id = route.RouteId }, route);
        }

        // DELETE: api/Route/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Route>> DeleteRoute(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();

            return route;
        }

        private bool RouteExists(int id)
        {
            return _context.Routes.Any(e => e.RouteId == id);
        }
    }
}
