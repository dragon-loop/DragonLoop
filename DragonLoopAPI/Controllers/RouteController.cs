using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonLoopModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DragonLoopAPI.Models;
using DragonLoopAPI.Managers;


namespace DragonLoopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly DragonLoopContext _context;
        private readonly RouteManager _scheduleManager;

        public RouteController(DragonLoopContext context)
        {
            _context = context;
            _scheduleManager = new RouteManager(context);
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

        // POST: api/Route/5/UpdateRouteSchedule
        [HttpPost("{id}/UpdateRouteSchedule")]
        public async Task<IActionResult> PostSchedule(int id, ScheduleInput[] input)
        {
            var truncated = await _scheduleManager.TruncateRouteSchedule(id);
            if (!truncated)
            {
                return NotFound();
            }
            Console.WriteLine(truncated);
            var schedules = input.Select(async s =>
            {
                Schedule schedule = await _scheduleManager.GetNewSchedule(s, id);
                Console.WriteLine(schedule);
                return schedule;
            }).Select(t =>
            {
                return t.Result;
            }).ToList();
            await _scheduleManager.SetRouteSchedules(id, schedules);
            await _context.SaveChangesAsync();

            return Ok(id);
        }
    }
}
