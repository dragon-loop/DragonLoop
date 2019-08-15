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
    public class ScheduleController : ControllerBase
    {
        private readonly DragonLoopContext _context;

        public ScheduleController(DragonLoopContext context)
        {
            _context = context;
        }

        // GET: api/Schedule?routeid=5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules(int? routeId)
        {
            var route = await _context.Routes.FindAsync(routeId);

            if (route == null)
            {
                return NotFound();
            }

            return route.Schedules.ToList();
        }

        //// PUT: api/Schedule/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
        //{
        //    if (id != schedule.RouteId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(schedule).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ScheduleExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Schedule
        //[HttpPost]
        //public async Task<ActionResult<Schedule>> PostSchedule(Schedule schedule)
        //{
        //    _context.Schedules.Add(schedule);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ScheduleExists(schedule.RouteId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetSchedule", new { id = schedule.RouteId }, schedule);
        //}

        //// DELETE: api/Schedule/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Schedule>> DeleteSchedule(int id)
        //{
        //    var schedule = await _context.Schedules.FindAsync(id);
        //    if (schedule == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Schedules.Remove(schedule);
        //    await _context.SaveChangesAsync();

        //    return schedule;
        //}

        //private bool ScheduleExists(int id)
        //{
        //    return _context.Schedules.Any(e => e.RouteId == id);
        //}
    }
}
