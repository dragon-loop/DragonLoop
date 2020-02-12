using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonLoopModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DragonLoopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly DragonLoopContext _context;

        public RouteController(DragonLoopContext context)
        {
            _context = context;
        }

        // GET: api/Route
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Route>>> GetRoutes()
        {
            return await _context.Routes.ToListAsync();
        }

        // GET: api/Route/5/Buses
        [HttpGet("{id}/Buses")]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses(int id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route.Buses.Where(b => b.InactiveFlag == false).ToList();
        }

        // GET: api/Route/5/Stops
        [HttpGet("{id}/Stops")]
        public async Task<ActionResult<IEnumerable<Stop>>> GetStops(int id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route.Stops.ToList();
        }

        // GET: api/Route/5/Schedules
        [HttpGet("{id}/Schedules")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules(int id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route.Schedules.ToList();
        }

        // GET: api/Route/5/RouteSegments
        [HttpGet("{id}/RouteSegments")]
        public async Task<ActionResult<IEnumerable<RouteSegment>>> GetRouteSegments(int id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route.RouteSegments.ToList();
        }
    }
}
